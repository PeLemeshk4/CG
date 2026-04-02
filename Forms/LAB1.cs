using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КГ
{
    public partial class LAB1 : Form
    {
        const int MaxN = 10; // максимально допустимая размерность матрицы
        int n = 3; // текущая размерность матрицы
        TextBox[,] MatrText = null; // матрица элементов типа TextBox
        double[,] Matr1 = new double[MaxN, MaxN]; // матрица 1 чисел с плавающей точкой
        double[,] Matr2 = new double[MaxN, MaxN]; // матрица 2 чисел с плавающей точкой
        double[,] Matr3 = new double[MaxN, MaxN]; // матрица результатов
        bool f1; // флажок, который указывает о вводе данных в матрицу Matr1
        int dx = 40, dy = 20; // ширина и высота ячейки в MatrText[,]
        Ok okForm;

        public LAB1()
        {
            InitializeComponent();
        }

        private void LAB1_Load(object sender, EventArgs e)
        {
            // І. Инициализация элементов управления и внутренних переменных
            EnterL.Text = "false";
            SizeTB.Text = "";
            f1 = false; // матрицы еще не заполнены
            // ІІ. Выделение памяти и настройка MatrText
            int i, j;
            // 1. Выделение памяти для формы Form2
            okForm = new Ok();
            // 2. Выделение памяти под самую матрицу
            MatrText = new TextBox[MaxN, MaxN];
            // 3. Выделение памяти для каждой ячейки матрицы и ее настройка
            for (i = 0; i < MaxN; i++)
            {
                for (j = 0; j < MaxN; j++)
                {
                    // 3.1. Выделить память
                    MatrText[i, j] = new TextBox();
                    // 3.2. Обнулить эту ячейку
                    MatrText[i, j].Text = "0";
                    // 3.3. Установить позицию ячейки в форме Form2
                    MatrText[i, j].Location = new System.Drawing.Point(10 + j *
                    dx, 10 + i * dy);
                    // 3.4. Установить размер ячейки
                    MatrText[i, j].Size = new System.Drawing.Size(dx, dy);
                    // 3.5. Пока что спрятать ячейку
                    MatrText[i, j].Visible = false;
                    // 3.6. Добавить MatrText[i,j] в форму form2
                    okForm.Controls.Add(MatrText[i, j]);
                }
            }
        }

        private void EnterB_Click(object sender, EventArgs e)
        {
            // 1. Чтение размерности матрицы
            if (SizeTB.Text == "") return;
            n = int.Parse(SizeTB.Text);
            // 2. Обнуление ячейки MatrText
            Clear_MatrText();
            // 3. Настройка свойств ячеек матрицы MatrText
            // с привязкой к значению n и форме Form2
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    // 3.1. Порядок табуляции
                    MatrText[i, j].TabIndex = i * n + j + 1;
                    // 3.2. Сделать ячейку видимой
                    MatrText[i, j].Visible = true;
                }
            // 4. Корректировка размеров формы
            okForm.Width = 10 + n * dx + 20;
            okForm.Height = 10 + n * dy + okForm.OkB.Height + 50;
            // 5. Корректировка позиции и размеров кнопки на форме Form2
            okForm.OkB.Left = 10;
            okForm.OkB.Top = 10 + n * dy + 10;
            okForm.OkB.Width = okForm.Width - 30;
            // 6. Вызов формы Form2
            if (okForm.ShowDialog() == DialogResult.OK)
            {
                // 7. Перенос строк из формы Form2 в матрицу Matr1
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (MatrText[i, j].Text != "")
                            Matr1[i, j] = Double.Parse(MatrText[i, j].Text);
                        else
                            Matr1[i, j] = 0;
                // 8. Данные в матрицу Matr1 внесены
                f1 = true;
                EnterL.Text = "true";
            }
        }

        private void ShowB_Click(object sender, EventArgs e)
        {
            if (!f1) return;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText[i, j].Text = Matr1[i, j].ToString();

            if (okForm.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        if (MatrText[i, j].Text != "")
                            Matr1[i, j] = Double.Parse(MatrText[i, j].Text);
                        else
                            Matr1[i, j] = 0;
            }
        }

        // Транспонирование
        private void TranspositionB_Click(object sender, EventArgs e)
        {
            if (!f1) return;

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    Matr3[j, i] = Matr1[i, j];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText[i, j].Text = Matr3[i, j].ToString();

            okForm.ShowDialog();
        }

        // Умножение на константу
        private void MultiplicationButtonB_Click(object sender, EventArgs e)
        {
            // Проверка, введены ли данные в матрице
            if (!f1)
            {
                MessageBox.Show("Сначала введите первую матрицу!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем свою форму для ввода константы
            double constant = 2.0;

            Form inputForm = new Form();
            inputForm.Text = "Умножение на константу";
            inputForm.Size = new Size(300, 150);
            inputForm.StartPosition = FormStartPosition.CenterParent;
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputForm.MaximizeBox = false;
            inputForm.MinimizeBox = false;

            Label label = new Label();
            label.Text = "Введите константу:";
            label.Location = new Point(20, 20);
            label.Size = new Size(100, 20);

            TextBox textBox = new TextBox();
            textBox.Location = new Point(130, 20);
            textBox.Size = new Size(100, 20);
            textBox.Text = constant.ToString();

            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Location = new Point(60, 60);
            btnOK.Size = new Size(75, 30);
            btnOK.DialogResult = DialogResult.OK;

            Button btnCancel = new Button();
            btnCancel.Text = "Отмена";
            btnCancel.Location = new Point(145, 60);
            btnCancel.Size = new Size(75, 30);
            btnCancel.DialogResult = DialogResult.Cancel;

            inputForm.Controls.AddRange(new Control[] { label, textBox, btnOK, btnCancel });
            inputForm.AcceptButton = btnOK;
            inputForm.CancelButton = btnCancel;

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    constant = double.Parse(textBox.Text);
                }
                catch
                {
                    MessageBox.Show("Неверный формат числа!", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Умножение матрицы Matr1 на константу
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        Matr3[i, j] = Matr1[i, j] * constant;
                    }

                // Отображение результата
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                    {
                        MatrText[i, j].TabIndex = i * n + j + 1;
                        MatrText[i, j].Text = Matr3[i, j].ToString();
                    }

                okForm.ShowDialog();
            }
        }

        private void VectorModule_Click(object sender, EventArgs e)
        {
            // Проверка, введены ли данные в матрице
            if (!f1)
            {
                MessageBox.Show("Сначала введите первую матрицу!", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем форму для выбора строки/столбца
            Form selectForm = new Form();
            selectForm.Text = "Выбор вектора";
            selectForm.Size = new Size(300, 200);
            selectForm.StartPosition = FormStartPosition.CenterParent;

            Label label1 = new Label();
            label1.Text = "Выберите тип вектора:";
            label1.Location = new Point(20, 20);
            label1.Size = new Size(150, 20);

            RadioButton rbRow = new RadioButton();
            rbRow.Text = "Вектор-строка";
            rbRow.Location = new Point(30, 50);
            rbRow.Checked = true;

            RadioButton rbColumn = new RadioButton();
            rbColumn.Text = "Вектор-столбец";
            rbColumn.Location = new Point(30, 80);

            NumericUpDown nudIndex = new NumericUpDown();
            nudIndex.Location = new Point(160, 65);
            nudIndex.Size = new Size(60, 20);
            nudIndex.Minimum = 0;
            nudIndex.Maximum = n - 1;
            nudIndex.Value = 0;

            Button btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Location = new Point(100, 120);
            btnOK.Size = new Size(80, 30);
            btnOK.DialogResult = DialogResult.OK;

            selectForm.Controls.AddRange(new Control[] { label1, rbRow, rbColumn, nudIndex, btnOK });

            if (selectForm.ShowDialog() == DialogResult.OK)
            {
                int index = (int)nudIndex.Value;
                double vectorModulus = 0;

                if (rbRow.Checked) // Вектор-строка
                {
                    for (int j = 0; j < n; j++)
                    {
                        vectorModulus += Matr1[index, j] * Matr1[index, j];
                    }
                }
                else // Вектор-столбец
                {
                    for (int i = 0; i < n; i++)
                    {
                        vectorModulus += Matr1[i, index] * Matr1[i, index];
                    }
                }

                vectorModulus = Math.Sqrt(vectorModulus);

                MessageBox.Show($"Модуль вектора = {vectorModulus:F4}",
                                "Результат",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private double Determinant(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            if (n != matrix.GetLength(1))
                throw new ArgumentException("Matrix must be square.");

            double[,] a = (double[,])matrix.Clone();

            double det = 1.0;
            int sign = 1;

            for (int i = 0; i < n; i++)
            {
                int pivotRow = i;
                double maxAbs = Math.Abs(a[i, i]);

                for (int r = i + 1; r < n; r++)
                {
                    double absVal = Math.Abs(a[r, i]);
                    if (absVal > maxAbs)
                    {
                        maxAbs = absVal;
                        pivotRow = r;
                    }
                }

                if (Math.Abs(a[pivotRow, i]) < 1e-12)
                    return 0.0;

                if (pivotRow != i)
                {
                    for (int c = 0; c < n; c++)
                    {
                        double tmp = a[i, c];
                        a[i, c] = a[pivotRow, c];
                        a[pivotRow, c] = tmp;
                    }
                    sign *= -1;
                }

                double pivot = a[i, i];
                det *= pivot;

                for (int r = i + 1; r < n; r++)
                {
                    double factor = a[r, i] / pivot;
                    for (int c = i; c < n; c++)
                    {
                        a[r, c] -= factor * a[i, c];
                    }
                }
            }

            return det * sign;
        }

        private void DeterminantB_Click(object sender, EventArgs e)
        {
            if (!f1) return;

            double[,] matr = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matr[i, j] = Matr1[i, j];
                }
            }
            double determinant = Determinant(matr);
            MessageBox.Show($"Определитель матрицы = {determinant}",
                               "Результат",
                               MessageBoxButtons.OK);
        }

        private void ScalarB_Click(object sender, EventArgs e)
        {
            try
            {
                double x1 = double.Parse(textBox1.Text);
                double y1 = double.Parse(textBox2.Text);
                double z1 = double.Parse(textBox3.Text);

                double x2 = double.Parse(textBox4.Text);
                double y2 = double.Parse(textBox5.Text);
                double z2 = double.Parse(textBox6.Text);

                double dotProduct = Math.Sqrt(x1 * x2 + y1 * y2 + z1 * z2);

                MessageBox.Show($"Скалярное произведение = {dotProduct}");
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод!");
            }
        }

        private void VectorB_Click(object sender, EventArgs e)
        {
            try
            {
                double x1 = double.Parse(textBox1.Text);
                double y1 = double.Parse(textBox2.Text);
                double z1 = double.Parse(textBox3.Text);

                double x2 = double.Parse(textBox4.Text);
                double y2 = double.Parse(textBox5.Text);
                double z2 = double.Parse(textBox6.Text);

                double resultX = y1 * z2 - z1 * y2;
                double resultY = z1 * x2 - x1 * z2;
                double resultZ = x1 * y2 - y1 * x2;

                MessageBox.Show($"Векторное произведение = ({resultX}, {resultY}, {resultZ})");
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при вычислении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Clear_MatrText()
        {
            // Обнуление ячеек MatrText
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    MatrText[i, j].Text = "0";
        }
    }
}
