using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КГ.Forms
{
    public partial class LAB3 : Form
    {
        Bitmap bmp;
        Bitmap clearedBmp;

        Point textPosition;
        int size = 14;
        Color color = Color.Black;
        int angle = 0;
        string text = "Hello World!";
        float scale = 1;
        bool isTextDraw = false;
        Random random;
        bool isRotating = false;
        int angleIncrement = 1;
        float shear = 0;

        int widthPb, heightPb;

        public LAB3()
        {
            InitializeComponent();
        }

        private void LAB3_Load(object sender, EventArgs e)
        {
            random = new Random();

            widthPb = pictureBox1.Width;
            heightPb = pictureBox1.Height;

            InitializeClearedBmp();
            ClearBmp();
            pictureBox1.Image = bmp;

            SizeNUP.Value = size;
            ColorB.BackColor = color;
            AngleNUP.Value = angle;
            TextTB.Text = text;
        }

        private void InitializeClearedBmp()
        {
            clearedBmp = new Bitmap(widthPb, heightPb);
            for (int x = 0; x < widthPb; x++)
            {
                for (int y = 0; y < heightPb; y++)
                {
                    clearedBmp.SetPixel(x, y, Color.White);
                }
            }
        }

        private void ClearBmp()
        {
            bmp = new Bitmap(clearedBmp);
        }

        private Bitmap DrawText()
        {
            if (text == "") return new Bitmap(1, 1);

            Font font = new Font("Arial", (int)(size * scale));
            Bitmap measureBmp = new Bitmap(1, 1);
            using (Graphics measureG = Graphics.FromImage(measureBmp))
            {
                SizeF textSize = measureG.MeasureString(text, font);
                float originalWidth = textSize.Width;
                float originalHeight = textSize.Height;

                int width = (int)Math.Ceiling(originalWidth * originalWidth / originalHeight);
                int height = (int)Math.Ceiling(originalHeight * originalWidth / originalHeight);

                Bitmap textBmp = new Bitmap(width, height);

                using (Graphics g = Graphics.FromImage(textBmp))
                {
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    float centerX = width / 2f;
                    float centerY = height / 2f;
                    g.TranslateTransform(centerX, centerY);

                    g.RotateTransform(angle);

                    float offsetX = -textSize.Width / 2f;
                    float offsetY = -textSize.Height / 2f;

                    g.DrawString(text, font, new SolidBrush(color), offsetX, offsetY);
                }

                if (shear != 0)
                {
                    textBmp = MakeShear(textBmp);
                }

                return textBmp;
            }
        }

        private Bitmap MakeShear(Bitmap textBmp)
        {
            int width = textBmp.Width;
            int height = textBmp.Height;

            var corners = new[] {
            new Point(0, 0),
            new Point(width, 0),
            new Point(0, height),
            new Point(width, height)
        };

            var transformedCorners = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                var p = corners[i];
                double newX = p.X + shear * p.Y;
                double newY = p.Y;
                transformedCorners[i] = new Point((int)Math.Round(newX), (int)Math.Round(newY));
            }

            int minX = int.MaxValue, minY = int.MaxValue;
            int maxX = int.MinValue, maxY = int.MinValue;
            foreach (var p in transformedCorners)
            {
                minX = Math.Min(minX, p.X);
                minY = Math.Min(minY, p.Y);
                maxX = Math.Max(maxX, p.X);
                maxY = Math.Max(maxY, p.Y);
            }

            int newWidth = maxX - minX + 1;
            int newHeight = maxY - minY + 1;

            Bitmap newBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.Clear(Color.Transparent);
            }

            for (int newY = 0; newY < newHeight; newY++)
            {
                for (int newX = 0; newX < newWidth; newX++)
                {
                    double xPrime = newX + minX;
                    double yPrime = newY + minY;

                    double originalX = xPrime - shear * yPrime;
                    double originalY = yPrime;

                    if (originalX >= 0 && originalX < width && originalY >= 0 && originalY < height)
                    {
                        Color pixelColor = textBmp.GetPixel((int)originalX, (int)originalY);
                        newBitmap.SetPixel(newX, newY, pixelColor);
                    }
                }
            }

            return newBitmap;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        { 
            textPosition = new Point(e.X, e.Y);

            UpdatePb();
        }

        private void UpdatePb()
        {
            if (pictureBox1.Width != widthPb || pictureBox1.Height != heightPb)
            {
                widthPb = pictureBox1.Width;
                heightPb = pictureBox1.Height;
                InitializeClearedBmp();
            }


            ClearBmp();
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Bitmap textBmp = DrawText();
                int drawX = (int)(textPosition.X - textBmp.Width / 2f);
                int drawY = (int)(textPosition.Y - textBmp.Height / 2f);
                g.DrawImage(textBmp, drawX, drawY);
            }
            pictureBox1.Image = bmp;
            isTextDraw = true;
        }

        private void ColorB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                color = colorDialog1.Color;
                ColorB.BackColor = color;

                if (isTextDraw) UpdatePb();
            }
        }

        private void SizeNUP_ValueChanged(object sender, EventArgs e)
        {
            size = (int)SizeNUP.Value;

            if (isTextDraw) UpdatePb();
        }

        private void AngleNUP_ValueChanged(object sender, EventArgs e)
        {
            angle = (int)AngleNUP.Value;

            if (isTextDraw) UpdatePb();
        }

        private void TextTB_TextChanged(object sender, EventArgs e)
        {
            text = TextTB.Text;

            if (isTextDraw) UpdatePb();
        }

        private void ScaleNUP_ValueChanged(object sender, EventArgs e)
        {
            scale = (float)ScaleNUP.Value;

            if (isTextDraw) UpdatePb();
        }

        private void RandomB_Click(object sender, EventArgs e)
        {
            size = random.Next((int)SizeNUP.Minimum, (int)SizeNUP.Maximum);
            SizeNUP.Value = size;
            color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            ColorB.BackColor = color;

            if (isTextDraw) UpdatePb();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            angle += angleIncrement;
            AngleNUP.Value = angle % 360;

            if (isTextDraw) UpdatePb();
        }

        private void StartStopRotationB_Click(object sender, EventArgs e)
        {
            if (isRotating)
            {
                isRotating = false;
                StartStopRotationB.Text = "Start Rotating";
                timer1.Stop();
            }
            else
            {
                isRotating = true;
                StartStopRotationB.Text = "Stop Rotating";
                timer1.Start();
            }
        }

        private void AngleIncrementNUP_ValueChanged(object sender, EventArgs e)
        {
            angleIncrement = (int)AngleIncrementNUP.Value;
        }

        private void ShearNUP_ValueChanged(object sender, EventArgs e)
        {
            shear = (float)ShearNUP.Value;

            if (isTextDraw) UpdatePb();
        }

        private void SpaceShipB_Click(object sender, EventArgs e)
        {
            SpaceShip form = new SpaceShip();
            form.ShowDialog();
        }
    }
}
