namespace КГ.Forms
{
    partial class LAB4
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SecondB = new System.Windows.Forms.Button();
            this.FirstB = new System.Windows.Forms.Button();
            this.Hexahedron = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.GridSizeL = new System.Windows.Forms.Label();
            this.GridSizeNUP = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSizeNUP)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GridSizeNUP);
            this.splitContainer1.Panel2.Controls.Add(this.GridSizeL);
            this.splitContainer1.Panel2.Controls.Add(this.SecondB);
            this.splitContainer1.Panel2.Controls.Add(this.FirstB);
            this.splitContainer1.Panel2.Controls.Add(this.Hexahedron);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 540;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(540, 450);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            // 
            // SecondB
            // 
            this.SecondB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SecondB.Location = new System.Drawing.Point(12, 71);
            this.SecondB.Name = "SecondB";
            this.SecondB.Size = new System.Drawing.Size(223, 53);
            this.SecondB.TabIndex = 1;
            this.SecondB.Text = "e^(Sin(x)-Cos(y))";
            this.SecondB.UseVisualStyleBackColor = true;
            this.SecondB.Click += new System.EventHandler(this.SecondB_Click);
            // 
            // FirstB
            // 
            this.FirstB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstB.Location = new System.Drawing.Point(12, 12);
            this.FirstB.Name = "FirstB";
            this.FirstB.Size = new System.Drawing.Size(223, 53);
            this.FirstB.TabIndex = 1;
            this.FirstB.Text = "Sin(x^2-y^2)";
            this.FirstB.UseVisualStyleBackColor = true;
            this.FirstB.Click += new System.EventHandler(this.FirstB_Click);
            // 
            // Hexahedron
            // 
            this.Hexahedron.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Hexahedron.Location = new System.Drawing.Point(25, 380);
            this.Hexahedron.Name = "Hexahedron";
            this.Hexahedron.Size = new System.Drawing.Size(210, 58);
            this.Hexahedron.TabIndex = 0;
            this.Hexahedron.Text = "Hexahedron";
            this.Hexahedron.UseVisualStyleBackColor = true;
            this.Hexahedron.Click += new System.EventHandler(this.Hexahedron_Click);
            // 
            // GridSizeL
            // 
            this.GridSizeL.AutoSize = true;
            this.GridSizeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GridSizeL.Location = new System.Drawing.Point(12, 145);
            this.GridSizeL.Name = "GridSizeL";
            this.GridSizeL.Size = new System.Drawing.Size(78, 20);
            this.GridSizeL.TabIndex = 2;
            this.GridSizeL.Text = "Grid Size:";
            // 
            // GridSizeNUP
            // 
            this.GridSizeNUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GridSizeNUP.Location = new System.Drawing.Point(97, 144);
            this.GridSizeNUP.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.GridSizeNUP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GridSizeNUP.Name = "GridSizeNUP";
            this.GridSizeNUP.Size = new System.Drawing.Size(120, 26);
            this.GridSizeNUP.TabIndex = 3;
            this.GridSizeNUP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GridSizeNUP.ValueChanged += new System.EventHandler(this.GridSizeNUP_ValueChanged);
            // 
            // LAB4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "LAB4";
            this.Text = "LAB4";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridSizeNUP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Hexahedron;
        private System.Windows.Forms.Button SecondB;
        private System.Windows.Forms.Button FirstB;
        private System.Windows.Forms.NumericUpDown GridSizeNUP;
        private System.Windows.Forms.Label GridSizeL;
    }
}