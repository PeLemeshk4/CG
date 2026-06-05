using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КГ.Forms
{
    public partial class Hexahedron : Form
    {
        private struct Point3D
        {
            public double X, Y, Z;
            public Point3D(double x, double y, double z) { X = x; Y = y; Z = z; }

            public static Point3D operator -(Point3D a, Point3D b)
            {
                return new Point3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
            }

            public static Point3D Cross(Point3D a, Point3D b)
            {
                return new Point3D(
                    a.Y * b.Z - a.Z * b.Y,
                    a.Z * b.X - a.X * b.Z,
                    a.X * b.Y - a.Y * b.X
                );
            }

            public static double Dot(Point3D a, Point3D b)
            {
                return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
            }
        }

        private class Face
        {
            public int[] Vertices;
            public bool IsVisible;
            public Face(int v1, int v2, int v3, int v4) { Vertices = new int[] { v1, v2, v3, v4 }; }
        }

        private class Edge
        {
            public int V1, V2;
            public bool Visible;
            public Edge(int v1, int v2) { V1 = v1; V2 = v2; }
        }

        private Point3D[] vertices;
        private Point3D[] originalVertices;
        private List<Face> faces;
        private List<Edge> edges;

        // Матрица поворота 4x4
        private double[,] rotationMatrix;

        // Углы поворота в радианах
        private double rotX = 0;
        private double rotY = 0;
        private double rotZ = 0;

        // Направление взгляда (камера смотрит вдоль оси Z)
        private Point3D viewDirection = new Point3D(0, 0, 1);

        public Hexahedron()
        {
            InitializeComponent();
            InitializeCube();

            originalVertices = (Point3D[])vertices.Clone();

            rotationMatrix = new double[4, 4];
            for (int i = 0; i < 4; i++)
                rotationMatrix[i, i] = 1;

            // Начальный поворот
            rotX = Math.PI / 12;
            rotY = Math.PI / 12;
            UpdateRotationMatrix();
            ApplyRotationToVertices();
        }

        private void InitializeCube()
        {
            double size = 100;
            double h = size / 2;

            vertices = new Point3D[]
            {
                new Point3D(-h, -h, -h), new Point3D( h, -h, -h),
                new Point3D( h,  h, -h), new Point3D(-h,  h, -h),
                new Point3D(-h, -h,  h), new Point3D( h, -h,  h),
                new Point3D( h,  h,  h), new Point3D(-h,  h,  h)
            };

            faces = new List<Face>
            {
                new Face(0, 1, 2, 3), // нижняя грань (Z = -h)
                new Face(4, 7, 6, 5), // верхняя грань (Z = h)
                new Face(0, 4, 5, 1), // передняя? (Y = -h)
                new Face(2, 6, 7, 3), // задняя? (Y = h)
                new Face(0, 3, 7, 4), // левая (X = -h)
                new Face(1, 5, 6, 2)  // правая (X = h)
            };

            edges = new List<Edge>
            {
                new Edge(0,1), new Edge(1,2), new Edge(2,3), new Edge(3,0), // нижняя
                new Edge(4,5), new Edge(5,6), new Edge(6,7), new Edge(7,4), // верхняя
                new Edge(0,4), new Edge(1,5), new Edge(2,6), new Edge(3,7)  // вертикальные
            };
        }

        private double[,] MultiplyMatrix(double[,] a, double[,] b)
        {
            double[,] result = new double[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        result[i, j] += a[i, k] * b[k, j];
            return result;
        }

        private void UpdateRotationMatrix()
        {
            double[,] rotMatrixX = new double[4, 4];
            rotMatrixX[0, 0] = 1; rotMatrixX[0, 1] = 0; rotMatrixX[0, 2] = 0; rotMatrixX[0, 3] = 0;
            rotMatrixX[1, 0] = 0; rotMatrixX[1, 1] = Math.Cos(rotX); rotMatrixX[1, 2] = -Math.Sin(rotX); rotMatrixX[1, 3] = 0;
            rotMatrixX[2, 0] = 0; rotMatrixX[2, 1] = Math.Sin(rotX); rotMatrixX[2, 2] = Math.Cos(rotX); rotMatrixX[2, 3] = 0;
            rotMatrixX[3, 0] = 0; rotMatrixX[3, 1] = 0; rotMatrixX[3, 2] = 0; rotMatrixX[3, 3] = 1;

            double[,] rotMatrixY = new double[4, 4];
            rotMatrixY[0, 0] = Math.Cos(rotY); rotMatrixY[0, 1] = 0; rotMatrixY[0, 2] = Math.Sin(rotY); rotMatrixY[0, 3] = 0;
            rotMatrixY[1, 0] = 0; rotMatrixY[1, 1] = 1; rotMatrixY[1, 2] = 0; rotMatrixY[1, 3] = 0;
            rotMatrixY[2, 0] = -Math.Sin(rotY); rotMatrixY[2, 1] = 0; rotMatrixY[2, 2] = Math.Cos(rotY); rotMatrixY[2, 3] = 0;
            rotMatrixY[3, 0] = 0; rotMatrixY[3, 1] = 0; rotMatrixY[3, 2] = 0; rotMatrixY[3, 3] = 1;

            double[,] rotMatrixZ = new double[4, 4];
            rotMatrixZ[0, 0] = Math.Cos(rotZ); rotMatrixZ[0, 1] = -Math.Sin(rotZ); rotMatrixZ[0, 2] = 0; rotMatrixZ[0, 3] = 0;
            rotMatrixZ[1, 0] = Math.Sin(rotZ); rotMatrixZ[1, 1] = Math.Cos(rotZ); rotMatrixZ[1, 2] = 0; rotMatrixZ[1, 3] = 0;
            rotMatrixZ[2, 0] = 0; rotMatrixZ[2, 1] = 0; rotMatrixZ[2, 2] = 1; rotMatrixZ[2, 3] = 0;
            rotMatrixZ[3, 0] = 0; rotMatrixZ[3, 1] = 0; rotMatrixZ[3, 2] = 0; rotMatrixZ[3, 3] = 1;

            rotationMatrix = MultiplyMatrix(rotMatrixZ, MultiplyMatrix(rotMatrixY, rotMatrixX));
        }

        private void ApplyRotationToVertices()
        {
            for (int i = 0; i < originalVertices.Length; i++)
            {
                double x = originalVertices[i].X;
                double y = originalVertices[i].Y;
                double z = originalVertices[i].Z;

                vertices[i] = new Point3D(
                    rotationMatrix[0, 0] * x + rotationMatrix[0, 1] * y + rotationMatrix[0, 2] * z,
                    rotationMatrix[1, 0] * x + rotationMatrix[1, 1] * y + rotationMatrix[1, 2] * z,
                    rotationMatrix[2, 0] * x + rotationMatrix[2, 1] * y + rotationMatrix[2, 2] * z
                );
            }
        }

        // Вычисление нормали грани в 3D
        private Point3D GetFaceNormal(Face face)
        {
            Point3D p0 = vertices[face.Vertices[0]];
            Point3D p1 = vertices[face.Vertices[1]];
            Point3D p2 = vertices[face.Vertices[2]];

            Point3D v1 = p1 - p0;
            Point3D v2 = p2 - p0;

            return Point3D.Cross(v1, v2);
        }

        // Правильное удаление невидимых линий
        private void CalculateVisibility()
        {
            foreach (var edge in edges) edge.Visible = false;

            var edgeMap = edges.ToDictionary(e => (Math.Min(e.V1, e.V2), Math.Max(e.V1, e.V2)));

            foreach (var face in faces)
            {
                // Получаем нормаль грани в 3D пространстве
                Point3D normal = GetFaceNormal(face);

                // Вычисляем скалярное произведение нормали и направления взгляда
                // Если результат > 0, грань видима (нормаль направлена к наблюдателю)
                // Если < 0, грань невидима (отвернута от наблюдателя)
                double dot = Point3D.Dot(normal, viewDirection);

                if (dot > 0) // Грань видима
                {
                    // Все рёбра этой грани становятся видимыми
                    for (int i = 0; i < face.Vertices.Length; i++)
                    {
                        int v1 = face.Vertices[i];
                        int v2 = face.Vertices[(i + 1) % face.Vertices.Length];
                        var key = (Math.Min(v1, v2), Math.Max(v1, v2));
                        if (edgeMap.TryGetValue(key, out var edge))
                            edge.Visible = true;
                    }
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private PointF ProjectDimetry(Point3D p)
        {
            double angle = Math.PI / 4;
            double k = 0.5;

            double screenX = p.X + k * p.Z * Math.Cos(angle);
            double screenY = p.Y + k * p.Z * Math.Sin(angle);

            float centerX = pictureBox1.Width / 2f;
            float centerY = pictureBox1.Height / 2f;

            return new PointF((float)(centerX + screenX), (float)(centerY - screenY));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rotY += Math.PI / 36;
            UpdateRotationMatrix();
            ApplyRotationToVertices();
            DrawScene();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rotY -= Math.PI / 36;
            UpdateRotationMatrix();
            ApplyRotationToVertices();
            DrawScene();
        }

        private void DrawScene()
        {
            if (pictureBox1.Width <= 0 || pictureBox1.Height <= 0) return;
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.White);

                // Оси координат
                double axisLength = 150;
                Pen axisPen = new Pen(Color.Black, 1);
                g.DrawLine(axisPen, ProjectDimetry(new Point3D(0, 0, 0)), ProjectDimetry(new Point3D(axisLength, 0, 0)));
                g.DrawLine(axisPen, ProjectDimetry(new Point3D(0, 0, 0)), ProjectDimetry(new Point3D(0, axisLength, 0)));
                g.DrawLine(axisPen, ProjectDimetry(new Point3D(0, 0, 0)), ProjectDimetry(new Point3D(0, 0, axisLength)));

                // Удаление невидимых линий
                CalculateVisibility();

                Pen visiblePen = new Pen(Color.Black, 2);
                Pen invisiblePen = new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };

                // Рисуем все рёбра
                foreach (var edge in edges)
                {
                    PointF p1 = ProjectDimetry(vertices[edge.V1]);
                    PointF p2 = ProjectDimetry(vertices[edge.V2]);
                    g.DrawLine(edge.Visible ? visiblePen : invisiblePen, p1, p2);
                }
            }

            if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
            pictureBox1.Image = bmp;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DrawScene();
        }
    }
}
