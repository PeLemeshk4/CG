using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using КГ.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace КГ
{
    public partial class LAB2 : Form
    {
        private Bitmap bitmap;

        private int xn, yn;
        private int xMin, yMin, xMax, yMax;
        private bool hasScreen = false;
        private Color backgroundColor;
        private Color lineColor = Color.Red;
        private Color fillingColor = Color.DarkBlue;
        private Color targetColor = Color.Red;
        private int thickness = 2;

        public LAB2()
        {
            InitializeComponent();
        }

        private void LAB2_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(CanvasPB.Width, CanvasPB.Height);
            backgroundColor = CanvasPB.BackColor;

            ThicknessL.Text = thickness.ToString();
            LineColorPB.BackColor = lineColor;
            FillingColorPB.BackColor = fillingColor;
            BackgroundColorPB.BackColor = backgroundColor;
            TargetColorPB.BackColor = targetColor;
            CDARB.Checked = true;
            UpdateCanvas();
        }

        private void Thickness_Click(object sender, EventArgs e)
        {
            EnterNumber form = new EnterNumber("Толщина линии", 1, 40);
            if (form.ShowDialog() == DialogResult.OK)
            {
                thickness = form.Value;
                ThicknessL.Text = thickness.ToString();
            }
        }

        private void LineColorB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                lineColor = colorDialog.Color;
                LineColorPB.BackColor = lineColor;
            }

        }

        private void FillingColorB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                fillingColor = colorDialog.Color;
                FillingColorPB.BackColor = fillingColor;
            }
        }

        private void BackgroundColorB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                backgroundColor = colorDialog.Color;
                BackgroundColorPB.BackColor = backgroundColor;
                CanvasPB.BackColor = backgroundColor;
            }
        }
        private void TargetColorB_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                targetColor = colorDialog.Color;
                TargetColorPB.BackColor = targetColor;
            }
        }

        private void ClearB_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    bitmap.SetPixel(x, y, backgroundColor);
                }
            }
            hasScreen = false;

            UpdateCanvas();
        }

        private void UpdateCanvas()
        {
            CanvasPB.Image = bitmap;
        }

        private void UpdateBitmap()
        {
            bitmap = CanvasPB.Image as Bitmap;
        }

        private void CanvasPB_MouseDown(object sender, MouseEventArgs e)
        {
            if (CDARB.Checked == true || AsymmetricCDARB.Checked == true
                || ClipRB.Checked == true || CDAClipRB.Checked == true)
            {
                xn = e.X;
                yn = e.Y;
            }
        }

        private void CanvasPB_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateBitmap();

            if (CDARB.Checked == true)
            {
                CDA(xn, yn, e.X, e.Y);
            }
            else if (FillingRB.Checked == true)
            {
                Filling(e.X, e.Y);
            }
            else if (AsymmetricCDARB.Checked == true)
            {
                AsymmetricCDA(xn, yn, e.X, e.Y);
            }
            else if (ClipRB.Checked == true)
            {
                xMin = Math.Min(xn, e.X);
                yMin = Math.Min(yn, e.Y);
                xMax = Math.Max(xn, e.X);
                yMax = Math.Max(yn, e.Y);
                hasScreen = true;
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    Pen pen = new Pen(Color.Black, 1);

                    g.DrawRectangle(pen, xMin, yMin, xMax - xMin, yMax - yMin);

                    pen.Dispose();
                }
            }
            else if (CDAClipRB.Checked == true)
            {
                if (hasScreen)
                {
                    ClipAndDraw(xn, yn, e.X, e.Y);
                }
            }

            UpdateCanvas();
        }

        private void BypassB_Click(object sender, EventArgs e)
        {
            List<Point> list = ExploreContourFromBitmap(targetColor);

            Form form = new Form();
            form.Size = new Size(bitmap.Width, bitmap.Height);
            PictureBox pb = new PictureBox();
            pb.Size = new Size(bitmap.Width, bitmap.Height);
            pb.BackColor = backgroundColor;
            form.Controls.Add(pb);
            Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            foreach (Point p in list)
            {
                newBitmap.SetPixel(p.X, p.Y, targetColor);
            }
            pb.Image = newBitmap;
            Image image = pb.Image;
            image.Save("..\\..\\SWaGA.png", ImageFormat.Png);
            form.ShowDialog();
        }

        private void CDA(int xStart, int yStart, int xEnd, int yEnd)
        {
            int dx = xEnd - xStart;
            int dy = yEnd - yStart;
            int steps;

            steps = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);

            double xIncrement = (double)dx / steps;
            double yIncrement = (double)dy / steps;

            double x = xStart;
            double y = yStart;

            for (int i = 0; i <= steps; i++)
            {
                int pixelX = (int)Math.Round(x);
                int pixelY = (int)Math.Round(y);

                DrawPixelSquare(pixelX, pixelY);

                x += xIncrement;
                y += yIncrement;
            }
        }

        private void DrawPixelSquare(int centerX, int centerY)
        {
            int halfThickness = thickness / 2;

            int startX = centerX - halfThickness;
            int startY = centerY - halfThickness;
            int endX = startX + thickness - 1;
            int endY = startY + thickness - 1;

            for (int y = startY; y <= endY; y++)
            {
                for (int x = startX; x <= endX; x++)
                {
                    if (CDAClipRB.Checked == true && hasScreen && (x < xMin || x > xMax || y < yMin || y > yMax)) continue;

                    if (x >= 0 && x < bitmap.Width && y >= 0 && y < bitmap.Height)
                    {
                        bitmap.SetPixel(x, y, lineColor);
                    }
                }
            }
        }

        private void Filling(int x, int y)
        {
            if (x < 0 || x >= bitmap.Width || y < 0 || y >= bitmap.Height)
                return;

            Color beforeColor = bitmap.GetPixel(x, y);

            if (beforeColor.ToArgb() == fillingColor.ToArgb())
            {
                return;
            }

            Stack<Point> pixels = new Stack<Point>();
            pixels.Push(new Point(x, y));

            while (pixels.Count > 0)
            {
                Point currentPoint = pixels.Pop();
                int currentX = currentPoint.X;
                int currentY = currentPoint.Y;

                if (currentX < 0 || currentX >= bitmap.Width || currentY < 0 || currentY >= bitmap.Height)
                    continue;

                Color color = bitmap.GetPixel(currentX, currentY);
                if (color.ToArgb() != beforeColor.ToArgb())
                {
                    continue;
                }

                bitmap.SetPixel(currentX, currentY, fillingColor);

                pixels.Push(new Point(currentX + 1, currentY));
                pixels.Push(new Point(currentX - 1, currentY));
                pixels.Push(new Point(currentX, currentY + 1));
                pixels.Push(new Point(currentX, currentY - 1));
            }

        }

        private void AsymmetricCDA(int xStart, int yStart, int xEnd, int yEnd)
        {
            if (bitmap == null) return;

            int steps;
            double xOutput, yOutput, dx, dy;

            dx = xEnd - xStart;
            dy = yEnd - yStart;

            // Определяем количество шагов по оси с большим приращением
            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs((int)dx);
            else
                steps = Math.Abs((int)dy);

            // Если отрезок вырожденный (точка)
            if (steps == 0)
            {
                DrawPixelSquare(xStart, yStart);
                return;
            }

            double xIncrement = dx / steps;
            double yIncrement = dy / steps;

            xOutput = xStart;
            yOutput = yStart;

            for (int index = 1; index <= steps; index++)
            {
                DrawPixelSquare((int)xOutput, (int)yOutput);
                xOutput += xIncrement;
                yOutput += yIncrement;
            }

            CanvasPB.Refresh();
        }

        private readonly (int dx, int dy)[] Directions = {
            (1, 1),    // SE
            (1, 0),   // E
            (1, -1),  // NE
            (0, -1),  // N
            (-1, -1), // NW
            (-1, 0),  // W
            (-1, 1),  // SW
            (0, 1),   // S                   
            };

        private List<Point> ExploreContourFromBitmap(Color targetColor)
        {
            UpdateBitmap();

            var visited = new HashSet<string>();
            var contour = new List<Point>();
            var stack = new Stack<Point>();

            int width = bitmap.Width;
            int height = bitmap.Height;

            Point start = FindFirstContourPixel(targetColor);
            if (start.X == -1) return new List<Point>();

            Point current = start;
            visited.Add($"{current.X},{current.Y}");
            contour.Add(current);

            while (true)
            {
                var unvisitedNeighbors = new List<Point>();

                foreach (var (dx, dy) in Directions)
                {
                    int nx = current.X + dx;
                    int ny = current.Y + dy;

                    if (nx < 0 || nx >= width || ny < 0 || ny >= height) continue;

                    if (IsColorMatch(bitmap.GetPixel(nx, ny), targetColor))
                    {
                        string key = $"{nx},{ny}";
                        if (!visited.Contains(key))
                        {
                            unvisitedNeighbors.Add(new Point(nx, ny));
                        }
                    }
                }
                if (unvisitedNeighbors.Count == 0)
                {
                    if (stack.Count > 0)
                    {
                        current = stack.Pop();
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                else if (unvisitedNeighbors.Count == 1)
                {
                    current = unvisitedNeighbors[0];
                    visited.Add($"{current.X},{current.Y}");
                    contour.Add(current);
                }
                else
                {
                    stack.Push(current);
                    current = unvisitedNeighbors[0];
                    visited.Add($"{current.X},{current.Y}");
                    contour.Add(current);
                }
            }

            return contour;
        }

        private Point FindFirstContourPixel(Color targetColor)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    if (IsColorMatch(bitmap.GetPixel(x, y), targetColor))
                    {
                        return new Point(x, y);
                    }
                }
            }
            return new Point(-1, -1);
        }

        private bool IsColorMatch(Color c1, Color c2)
        {
            return c1.R == c2.R && c1.G == c2.G && c1.B == c2.B;
        }

        private void ClipAndDraw(int x1, int y1, int x2, int y2)
        {
            double X1 = x1, Y1 = y1, X2 = x2, Y2 = y2;
            int c1 = 0, c2 = 0;
            if (X1 < xMin) c1 = 1; if (X1 > xMax) c1 = 2; if (Y1 < yMin) c1 = 4; if (Y1 > yMax) c1 = 8;
            if (X2 < xMin) c2 = 1; if (X2 > xMax) c2 = 2; if (Y2 < yMin) c2 = 4; if (Y2 > yMax) c2 = 8;

            if ((c1 | c2) == 0) { CDA((int)X1, (int)Y1, (int)X2, (int)Y2); return; }
            if ((c1 & c2) != 0) return;

            while (true)
            {
                int c = c1 != 0 ? c1 : c2;
                double x = 0, y = 0;
                if ((c & 8) != 0) { x = X1 + (X2 - X1) * (yMax - Y1) / (Y2 - Y1); y = yMax; }
                else if ((c & 4) != 0) { x = X1 + (X2 - X1) * (yMin - Y1) / (Y2 - Y1); y = yMin; }
                else if ((c & 2) != 0) { y = Y1 + (Y2 - Y1) * (xMax - X1) / (X2 - X1); x = xMax; }
                else { y = Y1 + (Y2 - Y1) * (xMin - X1) / (X2 - X1); x = xMin; }

                if (c == c1) { X1 = x; Y1 = y; c1 = 0; if (X1 < xMin) c1 |= 1; if (X1 > xMax) c1 |= 2; if (Y1 < yMin) c1 |= 4; if (Y1 > yMax) c1 |= 8; }
                else { X2 = x; Y2 = y; c2 = 0; if (X2 < xMin) c2 |= 1; if (X2 > xMax) c2 |= 2; if (Y2 < yMin) c2 |= 4; if (Y2 > yMax) c2 |= 8; }

                if ((c1 | c2) == 0) { CDA((int)X1, (int)Y1, (int)X2, (int)Y2); return; }
                if ((c1 & c2) != 0) return;
            }
        }
    }
}
