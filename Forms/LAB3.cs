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
        int size = 14;
        Color color = Color.Black;
        int angle = 0;
        string text = "Hello World!";

        public LAB3()
        {
            InitializeComponent();
        }

        private void LAB3_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    bmp.SetPixel(x, y, Color.White);
                }
            }

            pictureBox1.Image = bmp;

            SizeNUP.Value = size;
            ColorB.BackColor = color;
            AngleNUP.Value = angle;
            TextTB.Text = text;
        }

        private Bitmap DrawText(string text, Font font, Color color, float angle)
        {
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

                    return textBmp;
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Bitmap textBmp = DrawText(text, new Font("Arial", size), color, angle);
                int drawX = (int)(e.X - textBmp.Width / 2f);
                int drawY = (int)(e.Y - textBmp.Height / 2f);
                g.DrawImage(textBmp, drawX, drawY);
            }
            pictureBox1.Image = bmp;
        }

        private void ColorB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                color = colorDialog1.Color;
                ColorB.BackColor = color;
            }
        }

        private void SizeNUP_ValueChanged(object sender, EventArgs e)
        {
            size = (int)SizeNUP.Value;
        }

        private void AngleNUP_ValueChanged(object sender, EventArgs e)
        {
            angle = (int)AngleNUP.Value;
        }

        private void TextTB_TextChanged(object sender, EventArgs e)
        {
            text = TextTB.Text;
        }
    }
}
