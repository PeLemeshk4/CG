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
        float a1 = 0, a2 = 120;

        public SpaceShip()
        {
            Size = new Size(800, 800);
            DoubleBuffered = true;
            var timer = new Timer { Interval = 20 };
            timer.Tick += (s, e) => { a1 += 3; a2 += 4; Refresh(); };
            timer.Start();
            Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.Clear(Color.Black);
                int cx = 400, cy = 350;

                g.FillEllipse(Brushes.Green, cx - 50, cy - 50, 100, 100);

                float rad1 = a1 * (float)Math.PI / 180;
                int x1 = cx + (int)(150 * Math.Cos(rad1));
                int y1 = cy + (int)(150 * Math.Sin(rad1));
                float size1 = 0.3f + (y1 - 200) / 250f;
                g.FillEllipse(Brushes.Red, x1 - 12 * size1, y1 - 8 * size1, 24 * size1, 16 * size1);

                float rad2 = a2 * (float)Math.PI / 180;
                int x2 = cx + (int)(220 * Math.Cos(rad2));
                int y2 = cy + (int)(220 * Math.Sin(rad2));
                float size2 = 0.3f + (y2 - 200) / 250f;
                g.FillEllipse(Brushes.Blue, x2 - 12 * size2, y2 - 8 * size2, 24 * size2, 16 * size2);
            };
        }
    }
}