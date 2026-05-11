namespace КГ.Forms
{
    partial class LAB3
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SizeL = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ColorB = new System.Windows.Forms.Button();
            this.ColorL = new System.Windows.Forms.Label();
            this.SizeNUP = new System.Windows.Forms.NumericUpDown();
            this.AngleL = new System.Windows.Forms.Label();
            this.AngleNUP = new System.Windows.Forms.NumericUpDown();
            this.TextL = new System.Windows.Forms.Label();
            this.TextTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeNUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngleNUP)).BeginInit();
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
            this.splitContainer1.Panel2.Controls.Add(this.TextTB);
            this.splitContainer1.Panel2.Controls.Add(this.AngleNUP);
            this.splitContainer1.Panel2.Controls.Add(this.SizeNUP);
            this.splitContainer1.Panel2.Controls.Add(this.TextL);
            this.splitContainer1.Panel2.Controls.Add(this.AngleL);
            this.splitContainer1.Panel2.Controls.Add(this.ColorL);
            this.splitContainer1.Panel2.Controls.Add(this.ColorB);
            this.splitContainer1.Panel2.Controls.Add(this.SizeL);
            this.splitContainer1.Size = new System.Drawing.Size(863, 552);
            this.splitContainer1.SplitterDistance = 581;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(581, 552);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // SizeL
            // 
            this.SizeL.AutoSize = true;
            this.SizeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeL.Location = new System.Drawing.Point(20, 29);
            this.SizeL.Name = "SizeL";
            this.SizeL.Size = new System.Drawing.Size(57, 25);
            this.SizeL.TabIndex = 1;
            this.SizeL.Text = "Size:";
            // 
            // ColorB
            // 
            this.ColorB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ColorB.Location = new System.Drawing.Point(91, 65);
            this.ColorB.Name = "ColorB";
            this.ColorB.Size = new System.Drawing.Size(121, 35);
            this.ColorB.TabIndex = 2;
            this.ColorB.UseVisualStyleBackColor = true;
            this.ColorB.Click += new System.EventHandler(this.ColorB_Click);
            // 
            // ColorL
            // 
            this.ColorL.AutoSize = true;
            this.ColorL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ColorL.Location = new System.Drawing.Point(20, 70);
            this.ColorL.Name = "ColorL";
            this.ColorL.Size = new System.Drawing.Size(65, 25);
            this.ColorL.TabIndex = 3;
            this.ColorL.Text = "Color:";
            // 
            // SizeNUP
            // 
            this.SizeNUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeNUP.Location = new System.Drawing.Point(91, 29);
            this.SizeNUP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SizeNUP.Name = "SizeNUP";
            this.SizeNUP.Size = new System.Drawing.Size(121, 30);
            this.SizeNUP.TabIndex = 4;
            this.SizeNUP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AngleL
            // 
            this.AngleL.AutoSize = true;
            this.AngleL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AngleL.Location = new System.Drawing.Point(20, 106);
            this.AngleL.Name = "AngleL";
            this.AngleL.Size = new System.Drawing.Size(69, 25);
            this.AngleL.TabIndex = 3;
            this.AngleL.Text = "Angle:";
            // 
            // AngleNUP
            // 
            this.AngleNUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AngleNUP.Location = new System.Drawing.Point(91, 106);
            this.AngleNUP.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.AngleNUP.Name = "AngleNUP";
            this.AngleNUP.Size = new System.Drawing.Size(121, 30);
            this.AngleNUP.TabIndex = 5;
            this.AngleNUP.ValueChanged += new System.EventHandler(this.AngleNUP_ValueChanged);
            // 
            // TextL
            // 
            this.TextL.AutoSize = true;
            this.TextL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextL.Location = new System.Drawing.Point(20, 140);
            this.TextL.Name = "TextL";
            this.TextL.Size = new System.Drawing.Size(57, 25);
            this.TextL.TabIndex = 3;
            this.TextL.Text = "Text:";
            // 
            // TextTB
            // 
            this.TextTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextTB.Location = new System.Drawing.Point(91, 142);
            this.TextTB.Name = "TextTB";
            this.TextTB.Size = new System.Drawing.Size(121, 30);
            this.TextTB.TabIndex = 6;
            this.TextTB.TextChanged += new System.EventHandler(this.TextTB_TextChanged);
            // 
            // LAB3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 552);
            this.Controls.Add(this.splitContainer1);
            this.Name = "LAB3";
            this.Text = "LAB3";
            this.Load += new System.EventHandler(this.LAB3_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeNUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngleNUP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label SizeL;
        private System.Windows.Forms.Button ColorB;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label ColorL;
        private System.Windows.Forms.NumericUpDown SizeNUP;
        private System.Windows.Forms.NumericUpDown AngleNUP;
        private System.Windows.Forms.Label TextL;
        private System.Windows.Forms.Label AngleL;
        private System.Windows.Forms.TextBox TextTB;
    }
}