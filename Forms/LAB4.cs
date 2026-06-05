using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace КГ.Forms
{
    public partial class LAB4 : Form
    {  
        private int gridSize = 10;
        private float step = 0.1f;
        private int pointsPerSide;

        private float[,] transformMatr = new float[4, 4];
        private Point lastMousePos;

        private float scale = 1.0f;
        private float xAngle = 0.0f;
        private float yAngle = 0.0f;
        private float dx = 0.0f;
        private float dy = 0.0f;

        private bool isFirst = false;
        private bool isSecond = false;

        public LAB4()
        {
            InitializeComponent();
            pictureBox1.MouseWheel += PictureBox1_MouseWheel;

            pointsPerSide = (int)(gridSize / step);
            GridSizeNUP.Value = gridSize;
        }

        private float GetFirstZ(float x, float y)
        {
            return (float)Math.Sin(x * x - y * y);
        }

        private float GetSecondZ(float x, float y)
        {
            return (float)Math.Pow(Math.E, Math.Sin(x) - Math.Cos(y));
        }

        private float[,] ApplyTransform(float[,] points)
        {
            transformMatr = Multiply(RotationX(xAngle), RotationY(yAngle));
            transformMatr = Multiply(transformMatr, Scale(scale, scale, scale));
            transformMatr = Multiply(transformMatr, Translate(dx, dy, 0));
            return Multiply(points, transformMatr);
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!(isFirst || isSecond)) return;

            Graphics g = e.Graphics;
            g.Clear(Color.White);

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            float[,] points = new float[pointsPerSide * pointsPerSide, 4];

            if (isFirst)
            {
                for (int i = 0; i < pointsPerSide; i++)
                {
                    for (int j = 0; j < pointsPerSide; j++)
                    {
                        float x = (i - (pointsPerSide - 1) / 2f) * step;
                        float y = (j - (pointsPerSide - 1) / 2f) * step;
                        float z = GetFirstZ(x, y);
                        points[i * pointsPerSide + j, 0] = x;
                        points[i * pointsPerSide + j, 1] = y;
                        points[i * pointsPerSide + j, 2] = z;
                        points[i * pointsPerSide + j, 3] = 1;
                    }
                }
            }
            else
            {
                for (int i = 0; i < pointsPerSide; i++)
                {
                    for (int j = 0; j < pointsPerSide; j++)
                    {
                        float x = (i - (pointsPerSide - 1) / 2f) * step;
                        float y = (j - (pointsPerSide - 1) / 2f) * step;
                        float z = GetSecondZ(x, y);
                        points[i * pointsPerSide + j, 0] = x;
                        points[i * pointsPerSide + j, 1] = y;
                        points[i * pointsPerSide + j, 2] = z;
                        points[i * pointsPerSide + j, 3] = 1;
                    }
                }
            }

            float[,] transformedPoints = ApplyTransform(points);

            PointF[] projectedPoints = ProjectTo2D(transformedPoints, width, height);

            using (Pen pen = new Pen(Color.Black, 1f))
            {
                for (int i = 0; i < pointsPerSide; i++)
                {
                    for (int j = 0; j < pointsPerSide - 1; j++)
                    {
                        int idx1 = i * pointsPerSide + j;
                        int idx2 = i * pointsPerSide + j + 1;
                        g.DrawLine(pen, projectedPoints[idx1], projectedPoints[idx2]);
                    }
                }

                for (int i = 0; i < pointsPerSide - 1; i++)
                {
                    for (int j = 0; j < pointsPerSide; j++)
                    {
                        int idx1 = i * pointsPerSide + j;
                        int idx2 = (i + 1) * pointsPerSide + j;
                        g.DrawLine(pen, projectedPoints[idx1], projectedPoints[idx2]);
                    }
                }
            }
        }

        private PointF[] ProjectTo2D(float[,] points, int width, int height)
        {
            float scale = 100;
            PointF[] projectedPoints = new PointF[points.GetLength(0)];
            for (int i = 0; i < points.GetLength(0); i++)
            {
                projectedPoints[i].X = points[i, 0] * scale + width / 2f;
                projectedPoints[i].Y = -points[i, 1] * scale + height / 2f;
            }
            return projectedPoints;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            lastMousePos = e.Location;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                float dx = e.X - lastMousePos.X;
                float dy = e.Y - lastMousePos.Y;

                xAngle += dy * 0.01f;
                yAngle += dx * 0.01f;
            }
            else if (e.Button == MouseButtons.Left)
            {
                dx += (e.X - lastMousePos.X) * 0.01f;
                dy += -(e.Y - lastMousePos.Y) * 0.01f;
            }

            lastMousePos = e.Location;
            pictureBox1.Invalidate();
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            float scaleFactor = e.Delta > 0 ? 0.1f : -0.1f;
            if (scale + scaleFactor > 0)
            {
                scale += scaleFactor;
            }
            pictureBox1.Invalidate();
        }

        private float[,] Multiply(float[,] a, float[,] b)
        {
            int n = a.GetLength(0);
            int m = b.GetLength(1);

            float[,] r = new float[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;
                    for (int ii = 0; ii < m; ii++)
                    {
                        r[i, j] += a[i, ii] * b[ii, j];
                    }
                }
            }
            return r;
        }
        public float[,] RotationX(float angle)
        {
            float c = (float)Math.Cos(angle);
            float s = (float)Math.Sin(angle);
            return new float[4, 4]
            {
                { 1, 0, 0, 0 },
                { 0, c, -s, 0 },
                { 0, s, c, 0 },
                { 0, 0, 0, 1 }
            };  
        }
        public float[,] RotationY(float angle)
        {
            float c = (float)Math.Cos(angle);
            float s = (float)Math.Sin(angle);
            return new float[4, 4]
            {
                { c, 0, s, 0 },
                { 0, 1, 0, 0 },
                { -s, 0, c, 0 },
                { 0, 0, 0, 1 }
            };
        }
        public float[,] Scale(float x, float y, float z)
        {
            return new float[4, 4]
            {
                { x, 0, 0, 0 },
                { 0, y, 0, 0 },
                { 0, 0, z, 0 },
                { 0, 0, 0, 1 }
            }; 
        }
        public float[,] Translate(float x, float y, float z)
        {
            return new float[4, 4]
            {
                { 1, 0, 0, 1 },
                { 0, 1, 0, 1 },
                { 0, 0, 1, 1 },
                { x, y, z, 1 }
            };
        }

        private void Hexahedron_Click(object sender, EventArgs e)
        {
            Hexahedron form = new Hexahedron();
            form.ShowDialog();
        }

        private void FirstB_Click(object sender, EventArgs e)
        {
            isFirst = true;
            isSecond = false;
            pictureBox1.Invalidate();
        }

        private void SecondB_Click(object sender, EventArgs e)
        {
            isFirst = false;
            isSecond = true;
            pictureBox1.Invalidate();
        }

        private void GridSizeNUP_ValueChanged(object sender, EventArgs e)
        {
            gridSize = (int)GridSizeNUP.Value;
            pointsPerSide = (int)(gridSize / step);
            pictureBox1.Invalidate();
        }
    }
}
