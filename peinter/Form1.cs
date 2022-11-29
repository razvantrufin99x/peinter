using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace peinter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public Image img;
        public Bitmap bm;
        public Graphics g;
        public Font font0;
        public Pen pen0 = new Pen(Color.Black);
        public Pen pen1 = new Pen(Color.Black, 7);
        public Pen pen2 = new Pen(Color.Red, 30);
        public Brush brush0 = new SolidBrush(Color.Black);
        public Brush brush1 = new SolidBrush(Color.Silver);
        public float cx, cy, px, py;
        public float step = 5.0f;
        public const double g2r = 180 / Math.PI;
        public string mod = "";
        public int ismd = 0;

        public void drawcircle()
        {
            
            cx = (float)Math.Cos(0 / g2r) * 25 * 2 + 100;
            cy = (float)Math.Sin(0 / g2r) * 25 * 2 + 100;
            px = cx;
            py = cy;

            for (float i = 0; i < 360 + step; i += step)
            {
                cx = (float)Math.Cos(i / g2r) * 25 * 2 + 100;
                cy = (float)Math.Sin(i / g2r) * 25 * 2 + 100;
                try
                {
                    g.DrawLine(pen0, cx, cy, px, py);
                }
                catch { }
                px = cx;
                py = cy;
            }

            

        }

        public void drawsquare()
        {
            g.DrawRectangle(pen0, 10, 10, 100, 100);
                
        }

        public void drawdot()
        {
            g.DrawEllipse(pen0, 10, 10, 2, 2);
        }
        public void drawline()
        {
            g.DrawLine(pen0, 10, 10, 200, 2);
        }
        public void drawdreptunghi()
        {
            g.DrawRectangle(pen0, 10, 10, 200, 200);
        }

        public void drawelipsa()
        {
            g.DrawEllipse(pen0, 10, 10, 200, 200);
        }
        public void drawarc()
        {
            g.DrawArc(pen0, 0, 0, 200, 200, 50, 78);
        }
        public void clearall()
        {
            g.Clear(Color.White); // Set Bitmap background to white
        
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            font0 = this.Font;
            g = pictureBox1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            bm = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);

        }


        public void draw(string cmd)
        {
            mod = cmd;
            switch(cmd)
            {
                case "circle": drawcircle(); break;
                case "square": drawsquare(); break;
                case "dot" : drawdot(); break;
                case "line": drawline(); break;
                case "dreptunghi": drawdreptunghi(); break;
                case "elipsa": drawelipsa(); break;
                case "arc": drawarc(); break;
            }
            img = pictureBox1.Image; //create a persistant image
            bm = (Bitmap)img;
        }


        private void cercToolStripMenuItem_Click(object sender, EventArgs e)
        {
            draw("circle");

        }

        /*
            pictureBox1.Image = bm;
            bm.SetPixel(0, y, Color.Black);
            bm = bm.Scroll(1, 0);
            pictureBox1.Image = bm;
            g = Graphics.FromImage(bm);
            g.Dispose();
         */
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.Image = bm;
            g = Graphics.FromImage(bm);
            //g.Dispose();
        }

        private void squareToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            draw("square");
        }

        private void dotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            draw("dot");
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            draw("line");
        }

        private void dreptunghiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            draw("dreptunghi");
        }

        private void elipsaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            draw("elipsa");
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            px = cx;
            py = cy;
            ismd = 1;
            if (mod == "dot") { 
                g.DrawEllipse(pen0, e.X, e.Y, 2, 2);
                g.DrawString(Text, font0, brush1, e.X, e.Y);
            }
            cx = e.X;
            cy = e.Y;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = e.X + " : " + e.Y;
            px = cx;
            py = cy;
            cx = e.X;
            cy = e.Y;
            if (ismd == 1)
            {
                if (mod == "dot")
                {
                    g.DrawLine(pen0, cx, cy, px, py);
                }
            }
        }

        private void arcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            draw("arc");
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ismd = 0;
        }
    }
}
