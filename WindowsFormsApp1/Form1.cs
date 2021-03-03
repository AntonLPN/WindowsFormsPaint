using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics g;
        Color brushColor = Color.Black;
        Color backColor = Color.White;
        Point p1, p2;
        string shapes = "point";


        public Form1()
        {
            InitializeComponent();

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            pictureBox1.Image = bitmap;

            g = Graphics.FromImage(pictureBox1.Image);

            g.FillRectangle(Brushes.White, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));

            toolStripButton1.BackColor = brushColor;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (shapes == "point")
                {
                    g.FillRectangle(new SolidBrush(brushColor), e.X, e.Y, 5, 5);
                }
                if (shapes == "clean")
                {
                    g.FillRectangle(new SolidBrush(Color.White), e.X, e.Y, 20, 20);
                }
                pictureBox1.Image = bitmap;
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

            bitmap.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);

            saveFileDialog1.Dispose();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();

            bitmap.Dispose();
            g.Dispose();

            bitmap = new Bitmap(openFileDialog1.FileName);

            pictureBox1.Image = bitmap;

            g = Graphics.FromImage(pictureBox1.Image);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            brushColor = Color.Black;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            brushColor = Color.Blue;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            brushColor = Color.Green;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            brushColor = Color.Fuchsia;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            brushColor = Color.Red;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            brushColor = Color.Yellow;
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

            brushColor = colorDialog1.Color;

          
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            p1.X = e.X;
            p1.Y = e.Y;
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            shapes = "line";
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            shapes = "elipse";
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            shapes = "rectangle";
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            shapes = "point";
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            shapes = "clean";
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            p2.X = e.X;
            p2.Y = e.Y;

            if (shapes == "line")
            {
                g.DrawLine(new Pen(brushColor, 5), p1.X, p1.Y, p2.X, p2.Y);
            }
            else if (shapes == "elipse")
            {
                g.DrawEllipse(new Pen(brushColor, 5), new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y));

            }
            else if (shapes == "rectangle")
            {
                g.DrawRectangle(new Pen(brushColor, 5), new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y));
            }

            pictureBox1.Image = bitmap;

        }


    }

}
