using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КГ.Models
{
    public class Letter3D
    {
        public char Character;
        public double[,] Vertices;
        public int[,] Edges;

        private static double[,] Multiply(double[,] vertices, double[,] matr)
        {
            int n = vertices.GetLength(0);
            int m = matr.GetLength(1);

            double[,] r = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;
                    for (int ii = 0; ii < m; ii++)
                    {
                        r[i, j] += vertices[i, ii] * matr[ii, j];
                    }
                }
            }
            return r;
        }

        private static double[,] Scale(double[,] vertices, int scale)
        {
            double[,] scaleMatr =
                {
                    { scale, 0, 0 },
                    { 0, scale, 0 },
                    { 0, 0, 1 }
                };
            return Multiply(vertices, scaleMatr);
        }

        private static double[,] Shear(double[,] vertices, double shear)
        {
            double[,] shearMatr =
                {
                    { 1, 0, 0 },
                    { shear, 1, 0 },
                    { 0, 0, 1 }
                };

            return Multiply(vertices, shearMatr);
        }

        public Bitmap DrawLetter(int size, Color color, float shear = 0)
        {
            int width = size * 2 + (int)(size * 2 * Math.Abs(shear)) + 1;
            int height = size * 2 + 1;
            Bitmap letterBmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(letterBmp))
            {
                g.Clear(Color.Transparent);

                g.TranslateTransform(width / 2, height / 2);

                Pen pen = new Pen(color, 3);

                double[,] newVertices = Scale(Vertices, size);
                if (shear != 0)
                {
                    newVertices = Shear(newVertices, shear);
                }
                for (int i = 0; i < Edges.Length / 2; i++)
                {
                    Point p1 = new Point((int)newVertices[Edges[i, 0], 0], (int)newVertices[Edges[i, 0], 1]);
                    Point p2 = new Point((int)newVertices[Edges[i, 1], 0], (int)newVertices[Edges[i, 1], 1]);

                    g.DrawLine(pen, p1, p2);
                }
            }

            return letterBmp;
        }
    }
}
