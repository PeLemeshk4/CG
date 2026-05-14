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

        private Bitmap DrawText(string text, Font font, Color color, float angle)
        {
            if (text == "") return new Bitmap(1, 1);

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

                textBmp = MakeShear(textBmp, shear);

                return textBmp;
            }
        }

        private Bitmap MakeShear(Bitmap textBmp, float shear)
        {
            int width = textBmp.Width;
            int height = textBmp.Height;

            // Применяем прямое преобразование к углам, чтобы найти новый bounding box
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
                // Горизонтальный сдвиг: x' = x + shearX * y, y' = y
                double newX = p.X + shear * p.Y;
                double newY = p.Y;
                transformedCorners[i] = new Point((int)Math.Round(newX), (int)Math.Round(newY));
            }

            // Находим границы нового изображения
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

            // Создаём новое изображение с прозрачным фоном (32bppArgb)
            Bitmap newBitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.Clear(Color.Transparent);
            }

            // --- ОПТИМИЗАЦИЯ: LockBits для прямого доступа к памяти ---
            Rectangle rect = new Rectangle(0, 0, newWidth, newHeight);
            BitmapData newBitmapData = newBitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            Rectangle originalRect = new Rectangle(0, 0, width, height);
            BitmapData originalBitmapData = textBmp.LockBits(originalRect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            int bytesPerPixel = 4; // 32bppArgb = 4 байта на пиксель
            int strideNew = newBitmapData.Stride;
            int strideOriginal = originalBitmapData.Stride;

            unsafe
            {
                byte* ptrNew = (byte*)newBitmapData.Scan0.ToPointer();
                byte* ptrOriginal = (byte*)originalBitmapData.Scan0.ToPointer();

                double det = 1.0; // Для shearX только — детерминант = 1

                for (int y = 0; y < newHeight; y++)
                {
                    for (int x = 0; x < newWidth; x++)
                    {
                        // Координата в "сдвинутой" системе
                        double xPrime = x + minX;
                        double yPrime = y + minY;

                        // Обратное преобразование: x = x' - shearX * y', y = y'
                        double originalX = xPrime - shear * yPrime;
                        double originalY = yPrime;

                        // Проверяем, попадает ли точка в исходное изображение
                        if (originalX >= 0 && originalX < width && originalY >= 0 && originalY < height)
                        {
                            int srcX = (int)originalX;
                            int srcY = (int)originalY;

                            // Смещение в байтах для исходного изображения
                            int srcOffset = srcY * strideOriginal + srcX * bytesPerPixel;

                            // Смещение в байтах для нового изображения
                            int dstOffset = y * strideNew + x * bytesPerPixel;

                            // Копируем 4 байта (BGRA)
                            ptrNew[dstOffset + 0] = ptrOriginal[srcOffset + 0]; // B
                            ptrNew[dstOffset + 1] = ptrOriginal[srcOffset + 1]; // G
                            ptrNew[dstOffset + 2] = ptrOriginal[srcOffset + 2]; // R
                            ptrNew[dstOffset + 3] = ptrOriginal[srcOffset + 3]; // A
                        }
                        // Иначе остаётся прозрачным (по умолчанию — 0,0,0,0)
                    }
                }
            }

            // Разблокируем биты
            newBitmap.UnlockBits(newBitmapData);
            textBmp.UnlockBits(originalBitmapData);

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
                Bitmap textBmp = DrawText(text, new Font("Arial", (int)(size * scale)), color, angle);
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
