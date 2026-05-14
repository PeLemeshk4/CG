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
    public partial class SpaceShip : Form
    {
        private Timer timer;
        private Ship ship1, ship2;
        private Point earthCenter;
        private int earthRadius = 50;

        public SpaceShip()
        {
            this.Text = "Полёт космических кораблей вокруг Земли";
            this.Width = 700;
            this.Height = 700;
            this.BackColor = Color.Black;
            this.DoubleBuffered = true;
            this.Paint += SpaceShip_Paint;
            this.Resize += (s, e) => { UpdateCenter(); };

            timer = new Timer();
            timer.Interval = 30;
            timer.Tick += Timer_Tick;

            // Корабли: радиус орбиты, начальный угол, цвет, скорость
            ship1 = new Ship(180, 0, Color.Red, 0.03f);
            ship2 = new Ship(280, Math.PI, Color.Cyan, 0.025f);

            UpdateCenter();
            timer.Start();
        }

        private void UpdateCenter()
        {
            earthCenter = new Point(this.ClientSize.Width / 2, this.ClientSize.Height / 2);
        }

        private void SpaceShip_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Рисуем Землю
            g.FillEllipse(Brushes.Blue, earthCenter.X - earthRadius, earthCenter.Y - earthRadius,
                          earthRadius * 2, earthRadius * 2);
            g.DrawEllipse(Pens.White, earthCenter.X - earthRadius, earthCenter.Y - earthRadius,
                          earthRadius * 2, earthRadius * 2);

            // Подпись
            Font font = new Font("Arial", 12);
            g.DrawString("Земля", font, Brushes.White, earthCenter.X - 20, earthCenter.Y - 30);

            // Рисуем орбиты
            g.DrawEllipse(Pens.Gray, earthCenter.X - ship1.OrbitRadius, earthCenter.Y - ship1.OrbitRadius,
                          ship1.OrbitRadius * 2, ship1.OrbitRadius * 2);
            g.DrawEllipse(Pens.Gray, earthCenter.X - ship2.OrbitRadius, earthCenter.Y - ship2.OrbitRadius,
                          ship2.OrbitRadius * 2, ship2.OrbitRadius * 2);
            // Рисуем корабли
            ship1.Draw(g, earthCenter, this.ClientSize.Height);
            ship2.Draw(g, earthCenter, this.ClientSize.Height);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ship1.Update();
            ship2.Update();
            this.Invalidate();
        }
    }

    public class Ship
    {
        public double Angle { get; private set; }
        public float OrbitRadius { get; private set; }
        private float speed;
        private Color color;
        private Point position;

        public Ship(float orbitRadius, double startAngle, Color color, float speed)
        {
            this.OrbitRadius = orbitRadius;
            this.Angle = startAngle;
            this.color = color;
            this.speed = speed;
        }

        public void Update()
        {
            Angle += speed;
            if (Angle > Math.PI * 2) Angle -= Math.PI * 2;
        }

        public void Draw(Graphics g, Point center, int formHeight)
        {
            // Вычисляем позицию на экране
            int x = center.X + (int)(OrbitRadius * Math.Cos(Angle));
            int y = center.Y + (int)(OrbitRadius * Math.Sin(Angle));
            position = new Point(x, y);
            // ГЛАВНОЕ: размер зависит от Y-координаты (верха/низа экрана)
            // Чем больше Y (ближе к низу), тем больше размер
            // Чем меньше Y (ближе к верху), тем меньше размер
            float t = (float)position.Y / formHeight; // от 0 (верх) до 1 (низ)

            // Минимальный размер 10 пикселей, максимальный 60
            int shipSize = (int)(10 + t * 50);

            // Поворачиваем корабль по направлению движения (по касательной)
            float angleDeg = (float)(Angle + Math.PI / 2);

            // Рисуем корабль в виде треугольника
            PointF[] shape = new PointF[3];
            float halfSize = shipSize / 2f;

            shape[0] = new PointF(0, -halfSize);           // нос
            shape[1] = new PointF(-halfSize, halfSize);    // левое крыло
            shape[2] = new PointF(halfSize, halfSize);     // правое крыло

            // Поворот
            for (int i = 0; i < shape.Length; i++)
            {
                float dx = shape[i].X;
                float dy = shape[i].Y;
                float newX = dx * (float)Math.Cos(angleDeg) - dy * (float)Math.Sin(angleDeg);
                float newY = dx * (float)Math.Sin(angleDeg) + dy * (float)Math.Cos(angleDeg);
                shape[i] = new PointF(position.X + newX, position.Y + newY);
            }

            g.FillPolygon(new SolidBrush(color), shape);
            g.DrawPolygon(Pens.White, shape);

            // Небольшой "огонь" для красоты
            PointF fire = new PointF(position.X, position.Y + halfSize * 0.7f);
            g.FillEllipse(Brushes.Orange, fire.X - 3, fire.Y - 2, 6, 4);
        }
    }
}