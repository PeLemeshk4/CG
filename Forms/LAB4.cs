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
    public partial class LAB4 : Form
    {

        private float angleX = 0; // Угол вращения по оси X
        private float angleY = 0; // Угол вращения по оси Y
        private float scale = 1.0f; // Коэффициент масштабирования
        private float offsetX = 0, offsetY = 0; // Смещение по экрану

        public LAB4()
        {
            InitializeComponent();
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.BackColor = Color.White;

            // Настройка таймера для анимации
            timer1.Interval = 50; // ~20 FPS
            timer1.Tick += TimerTick;
            timer1.Start();

            // Обработка клавиш
            this.KeyDown += Form1_KeyDown;
            pictureBox1.MouseWheel += PictureBox1_MouseWheel;
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;

            // Первоначальная отрисовка
            DrawGraph();
        }

        // Основная функция отрисовки графика
        private void DrawGraph()
        {
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bitmap);

            // Очищаем битмап
            g.Clear(Color.White);

            // Рисуем сетку
            DrawGrid(g);

            // Рисуем поверхность
            DrawSurface(g);

            g.Dispose();
            pictureBox1.Image = bitmap;
        }

        // Функция для расчёта значения поверхности (z = f(x, y))
        private double CalculateZ(double x, double y)
        {
            // Пример: z = sin(√(x² + y²))
            return Math.Sin(Math.Sqrt(x * x + y * y)) * 3;
        }

        // Проекция 3D-точки в 2D (аксонометрия)
        private PointF Project3DTo2D(double x, double y, double z)
        {
            float screenWidth = pictureBox1.Width;
            float screenHeight = pictureBox1.Height;

            // Вращение по X и Y
            double cosX = Math.Cos(angleX), sinX = Math.Sin(angleX);
            double cosY = Math.Cos(angleY), sinY = Math.Sin(angleY);

            // Применяем вращение
            double xRot = x * cosY + z * sinY;
            double yRot = y;
            double zRot = -x * sinY + z * cosY;

            double xProj = xRot * cosX - zRot * sinX;
            double yProj = yRot;

            // Масштабирование и смещение
            float xScreen = (float)(screenWidth / 2 + xProj * scale * 5 + offsetX);
            float yScreen = (float)(screenHeight / 2 - yProj * scale * 5 + offsetY);

            return new PointF(xScreen, yScreen);
        }

        // Рисуем сетку
        private void DrawGrid(Graphics g)
        {
            Pen pen = new Pen(Color.LightGray, 1);
            for (int i = -10; i <= 10; i += 2)
            {
                // Оси X и Y
                PointF p1 = Project3DTo2D(i, -10, 0);
                PointF p2 = Project3DTo2D(i, 10, 0);
                g.DrawLine(pen, p1, p2);

                p1 = Project3DTo2D(-10, i, 0);
                p2 = Project3DTo2D(10, i, 0);
                g.DrawLine(pen, p1, p2);
            }
            pen.Dispose();
        }

        // Рисуем поверхность
        private void DrawSurface(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 1);
            int steps = 20;

            for (int i = 0; i < steps; i++)
            {
                for (int j = 0; j < steps; j++)
                {
                    double x1 = -10 + (i * 20.0 / steps);
                    double y1 = -10 + (j * 20.0 / steps);
                    double z1 = CalculateZ(x1, y1);

                    double x2 = -10 + ((i + 1) * 20.0 / steps);
                    double y2 = -10 + (j * 20.0 / steps);
                    double z2 = CalculateZ(x2, y2);

                    double x3 = -10 + (i * 20.0 / steps);
                    double y3 = -10 + ((j + 1) * 20.0 / steps);
                    double z3 = CalculateZ(x3, y3);

                    // Проецируем точки
                    PointF p1 = Project3DTo2D(x1, y1, z1);
                    PointF p2 = Project3DTo2D(x2, y2, z2);
                    PointF p3 = Project3DTo2D(x3, y3, z3);

                    // Рисуем линии между точками
                    g.DrawLine(pen, p1, p2);
                    g.DrawLine(pen, p1, p3);
                }
            }
            pen.Dispose();
        }

        // Обработка тика таймера (вращение)
        private void TimerTick(object sender, EventArgs e)
        {
            angleX += 0.05f; // Вращение по X
            angleY += 0.03f; // Вращение по Y
            DrawGraph();
        }

        // Управление клавиатурой
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left: angleY += 0.1f; break;
                case Keys.Right: angleY -= 0.1f; break;
                case Keys.Up: angleX += 0.1f; break;
                case Keys.Down: angleX -= 0.1f; break;
                case Keys.Add: scale *= 1.1f; break; // Увеличение
                case Keys.Subtract: scale /= 1.1f; break; // Уменьшение
                case Keys.W: offsetY -= 10; break; // Двигаем по Y
                case Keys.S: offsetY += 10; break;
                case Keys.A: offsetX -= 10; break; // Двигаем по X
                case Keys.D: offsetX += 10; break;
            }
            DrawGraph();
        }

        // Колесо мыши для масштабирования
        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0) scale *= 1.1f; // Увеличение
            else scale /= 1.1f; // Уменьшение
            DrawGraph();
        }

        // Перенос мышью (для панорамирования)
        private Point lastMousePos;
        private bool isDragging = false;

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastMousePos = e.Location;
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                offsetX += (e.X - lastMousePos.X);
                offsetY += (e.Y - lastMousePos.Y);
                lastMousePos = e.Location;
                DrawGraph();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isDragging = false;
        }
    }
}
