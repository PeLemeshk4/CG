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
using КГ.Models;

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

        Dictionary<char, Letter3D> lettersDictionary;
        private void InitializeLetters()
        {
            lettersDictionary = new Dictionary<char, Letter3D>();

            // Буква H
            var letterH = new Letter3D();
            letterH.Character = 'H';
            letterH.Vertices = new double[,]
            {
                { -1, -1, 0, 1 }, { -1, 1, 0, 1 },
                {  1, -1, 0, 1 }, {  1, 1, 0, 1 },
                { -1,   0, 0, 1 }, {  1,  0, 0, 1 }
            };
            letterH.Edges = new int[,]
            {
                { 0, 1 }, { 2, 3 }, { 4, 5 }
            };
            lettersDictionary.Add('H', letterH);

            // Буква E
            var letterE = new Letter3D();
            letterE.Character = 'E';
            letterE.Vertices = new double[,]
            {
                { -1, -1, 0, 1 }, { -1, 1, 0, 1 },
                {  1, -1, 0, 1 }, {  1, 1, 0, 1 },
                { -1,  0, 0, 1 }, {  1, 0, 0, 1 }
            };
            letterE.Edges = new int[,]
            {
                { 0, 1 }, { 0, 2 }, { 1, 3 }, { 4, 5 }
            };
            lettersDictionary.Add('E', letterE);

            // Буква L
            var letterL = new Letter3D();
            letterL.Character = 'L';
            letterL.Vertices = new double[,]
            {
                { -1, -1, 0, 1 }, { -1, 1, 0, 1 }, { 1, 1, 0, 1 }
            };
            letterL.Edges = new int[,]
            {
                { 0, 1 }, { 1, 2 }
            };
            lettersDictionary.Add('L', letterL);

            // Буква O
            var letterO = new Letter3D();
            letterO.Character = 'O';
            letterO.Vertices = new double[,]
            {
                { -1, -1, 0, 1 }, { -1, 1, 0, 1 },
                {  1, 1, 0, 1 }, {  1, -1, 0, 1 }
            };
            letterO.Edges = new int[,]
            {
                { 0, 1 }, { 1, 2 }, { 2, 3 }, { 3, 0 }
            };
            lettersDictionary.Add('O', letterO);
        }

        private void LAB3_Load(object sender, EventArgs e)
        {
            random = new Random();

            widthPb = pictureBox1.Width;
            heightPb = pictureBox1.Height;

            InitializeLetters();
            InitializeClearedBmp();
            ClearBmp();
            pictureBox1.Image = bmp;

            SizeNUP.Value = size;
            ColorB.BackColor = color;
            AngleNUP.Value = angle;
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

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        { 
            textPosition = new Point(e.X, e.Y);

            UpdatePb();
        }

        private Bitmap DrawText(string text)
        {
            int letterSize = size * 2;
            int spaceBetweenLetters = 2;
            int textLength = text.Length;

            int width = (letterSize + spaceBetweenLetters) * textLength + (int)(letterSize * Math.Abs(shear)) + letterSize;
            int height = width;
            Bitmap helloBmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(helloBmp))
            {
                g.TranslateTransform(width / 2, height / 2);
                g.RotateTransform(angle);

                for (int i = 0; i < textLength; i++)
                {
                    Bitmap letterBmp = lettersDictionary[text[i]].DrawLetter(size, color, shear);
                    int xPosition = (letterSize + spaceBetweenLetters) * i - width / 2 + size;

                    g.DrawImage(letterBmp, xPosition, -size);
                }
            }

            return helloBmp;
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
                Bitmap textBmp = DrawText("HELLO");
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
