namespace КГ
{
    partial class LAB1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EnterB = new System.Windows.Forms.Button();
            this.SizeL = new System.Windows.Forms.Label();
            this.SizeTB = new System.Windows.Forms.TextBox();
            this.VectorB = new System.Windows.Forms.Button();
            this.ShowB = new System.Windows.Forms.Button();
            this.EnterL = new System.Windows.Forms.Label();
            this.TranspositionB = new System.Windows.Forms.Button();
            this.MultiplicationConstB = new System.Windows.Forms.Button();
            this.VectorModule = new System.Windows.Forms.Button();
            this.DeterminantB = new System.Windows.Forms.Button();
            this.ScalarB = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.Vector1L = new System.Windows.Forms.Label();
            this.Vector2L = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EnterB
            // 
            this.EnterB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.EnterB.Location = new System.Drawing.Point(15, 65);
            this.EnterB.Name = "EnterB";
            this.EnterB.Size = new System.Drawing.Size(123, 49);
            this.EnterB.TabIndex = 0;
            this.EnterB.Text = "Enter the matrix";
            this.EnterB.UseVisualStyleBackColor = true;
            this.EnterB.Click += new System.EventHandler(this.EnterB_Click);
            // 
            // SizeL
            // 
            this.SizeL.AutoSize = true;
            this.SizeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeL.Location = new System.Drawing.Point(12, 29);
            this.SizeL.Name = "SizeL";
            this.SizeL.Size = new System.Drawing.Size(27, 15);
            this.SizeL.TabIndex = 1;
            this.SizeL.Text = "n = ";
            // 
            // SizeTB
            // 
            this.SizeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeTB.Location = new System.Drawing.Point(38, 29);
            this.SizeTB.Name = "SizeTB";
            this.SizeTB.Size = new System.Drawing.Size(100, 21);
            this.SizeTB.TabIndex = 2;
            // 
            // VectorB
            // 
            this.VectorB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VectorB.Location = new System.Drawing.Point(470, 120);
            this.VectorB.Name = "VectorB";
            this.VectorB.Size = new System.Drawing.Size(100, 60);
            this.VectorB.TabIndex = 0;
            this.VectorB.Text = "Vector";
            this.VectorB.UseVisualStyleBackColor = true;
            this.VectorB.Click += new System.EventHandler(this.VectorB_Click);
            // 
            // ShowB
            // 
            this.ShowB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ShowB.Location = new System.Drawing.Point(15, 120);
            this.ShowB.Name = "ShowB";
            this.ShowB.Size = new System.Drawing.Size(123, 49);
            this.ShowB.TabIndex = 0;
            this.ShowB.Text = "Show the matrix";
            this.ShowB.UseVisualStyleBackColor = true;
            this.ShowB.Click += new System.EventHandler(this.ShowB_Click);
            // 
            // EnterL
            // 
            this.EnterL.AutoSize = true;
            this.EnterL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterL.Location = new System.Drawing.Point(144, 81);
            this.EnterL.Name = "EnterL";
            this.EnterL.Size = new System.Drawing.Size(33, 15);
            this.EnterL.TabIndex = 3;
            this.EnterL.Text = "false";
            // 
            // TranspositionB
            // 
            this.TranspositionB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.TranspositionB.Location = new System.Drawing.Point(364, 54);
            this.TranspositionB.Name = "TranspositionB";
            this.TranspositionB.Size = new System.Drawing.Size(100, 60);
            this.TranspositionB.TabIndex = 0;
            this.TranspositionB.Text = "Transposition";
            this.TranspositionB.UseVisualStyleBackColor = true;
            this.TranspositionB.Click += new System.EventHandler(this.TranspositionB_Click);
            // 
            // MultiplicationConstB
            // 
            this.MultiplicationConstB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.MultiplicationConstB.Location = new System.Drawing.Point(258, 54);
            this.MultiplicationConstB.Name = "MultiplicationConstB";
            this.MultiplicationConstB.Size = new System.Drawing.Size(100, 60);
            this.MultiplicationConstB.TabIndex = 0;
            this.MultiplicationConstB.Text = "Multiplication";
            this.MultiplicationConstB.UseVisualStyleBackColor = true;
            this.MultiplicationConstB.Click += new System.EventHandler(this.MultiplicationButtonB_Click);
            // 
            // VectorModule
            // 
            this.VectorModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.VectorModule.Location = new System.Drawing.Point(258, 120);
            this.VectorModule.Name = "VectorModule";
            this.VectorModule.Size = new System.Drawing.Size(100, 60);
            this.VectorModule.TabIndex = 0;
            this.VectorModule.Text = "Vector module";
            this.VectorModule.UseVisualStyleBackColor = true;
            this.VectorModule.Click += new System.EventHandler(this.VectorModule_Click);
            // 
            // DeterminantB
            // 
            this.DeterminantB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.DeterminantB.Location = new System.Drawing.Point(364, 120);
            this.DeterminantB.Name = "DeterminantB";
            this.DeterminantB.Size = new System.Drawing.Size(100, 60);
            this.DeterminantB.TabIndex = 0;
            this.DeterminantB.Text = "Determinant";
            this.DeterminantB.UseVisualStyleBackColor = true;
            this.DeterminantB.Click += new System.EventHandler(this.DeterminantB_Click);
            // 
            // ScalarB
            // 
            this.ScalarB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ScalarB.Location = new System.Drawing.Point(470, 54);
            this.ScalarB.Name = "ScalarB";
            this.ScalarB.Size = new System.Drawing.Size(100, 60);
            this.ScalarB.TabIndex = 0;
            this.ScalarB.Text = "Scalar";
            this.ScalarB.UseVisualStyleBackColor = true;
            this.ScalarB.Click += new System.EventHandler(this.ScalarB_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(627, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(21, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(654, 65);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(21, 20);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(681, 65);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(21, 20);
            this.textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(627, 94);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(21, 20);
            this.textBox4.TabIndex = 4;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(654, 94);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(21, 20);
            this.textBox5.TabIndex = 4;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(681, 94);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(21, 20);
            this.textBox6.TabIndex = 4;
            // 
            // Vector1L
            // 
            this.Vector1L.AutoSize = true;
            this.Vector1L.Location = new System.Drawing.Point(577, 68);
            this.Vector1L.Name = "Vector1L";
            this.Vector1L.Size = new System.Drawing.Size(44, 13);
            this.Vector1L.TabIndex = 5;
            this.Vector1L.Text = "Vector1";
            // 
            // Vector2L
            // 
            this.Vector2L.AutoSize = true;
            this.Vector2L.Location = new System.Drawing.Point(577, 97);
            this.Vector2L.Name = "Vector2L";
            this.Vector2L.Size = new System.Drawing.Size(44, 13);
            this.Vector2L.TabIndex = 5;
            this.Vector2L.Text = "Vector2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(632, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X      Y       Z";
            // 
            // LAB1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 203);
            this.Controls.Add(this.Vector2L);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Vector1L);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.EnterL);
            this.Controls.Add(this.SizeTB);
            this.Controls.Add(this.SizeL);
            this.Controls.Add(this.TranspositionB);
            this.Controls.Add(this.MultiplicationConstB);
            this.Controls.Add(this.VectorModule);
            this.Controls.Add(this.DeterminantB);
            this.Controls.Add(this.ScalarB);
            this.Controls.Add(this.VectorB);
            this.Controls.Add(this.ShowB);
            this.Controls.Add(this.EnterB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LAB1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAB1";
            this.Load += new System.EventHandler(this.LAB1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EnterB;
        private System.Windows.Forms.Label SizeL;
        private System.Windows.Forms.TextBox SizeTB;
        private System.Windows.Forms.Button VectorB;
        private System.Windows.Forms.Button ShowB;
        private System.Windows.Forms.Label EnterL;
        private System.Windows.Forms.Button TranspositionB;
        private System.Windows.Forms.Button MultiplicationConstB;
        private System.Windows.Forms.Button VectorModule;
        private System.Windows.Forms.Button DeterminantB;
        private System.Windows.Forms.Button ScalarB;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label Vector1L;
        private System.Windows.Forms.Label Vector2L;
        private System.Windows.Forms.Label label1;
    }
}