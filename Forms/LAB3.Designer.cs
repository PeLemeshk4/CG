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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LAB3));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ShearL = new System.Windows.Forms.Label();
            this.ShearNUP = new System.Windows.Forms.NumericUpDown();
            this.AngleIncrementNUP = new System.Windows.Forms.NumericUpDown();
            this.StartStopRotationB = new System.Windows.Forms.Button();
            this.RandomB = new System.Windows.Forms.Button();
            this.SpaceShipB = new System.Windows.Forms.Button();
            this.ScaleL = new System.Windows.Forms.Label();
            this.ScaleNUP = new System.Windows.Forms.NumericUpDown();
            this.TextTB = new System.Windows.Forms.TextBox();
            this.AngleNUP = new System.Windows.Forms.NumericUpDown();
            this.SizeNUP = new System.Windows.Forms.NumericUpDown();
            this.TextL = new System.Windows.Forms.Label();
            this.AngleL = new System.Windows.Forms.Label();
            this.ColorL = new System.Windows.Forms.Label();
            this.ColorB = new System.Windows.Forms.Button();
            this.SizeL = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShearNUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngleIncrementNUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleNUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngleNUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeNUP)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ShearL);
            this.splitContainer1.Panel2.Controls.Add(this.ShearNUP);
            this.splitContainer1.Panel2.Controls.Add(this.AngleIncrementNUP);
            this.splitContainer1.Panel2.Controls.Add(this.StartStopRotationB);
            this.splitContainer1.Panel2.Controls.Add(this.RandomB);
            this.splitContainer1.Panel2.Controls.Add(this.SpaceShipB);
            this.splitContainer1.Panel2.Controls.Add(this.ScaleL);
            this.splitContainer1.Panel2.Controls.Add(this.ScaleNUP);
            this.splitContainer1.Panel2.Controls.Add(this.TextTB);
            this.splitContainer1.Panel2.Controls.Add(this.AngleNUP);
            this.splitContainer1.Panel2.Controls.Add(this.SizeNUP);
            this.splitContainer1.Panel2.Controls.Add(this.TextL);
            this.splitContainer1.Panel2.Controls.Add(this.AngleL);
            this.splitContainer1.Panel2.Controls.Add(this.ColorL);
            this.splitContainer1.Panel2.Controls.Add(this.ColorB);
            this.splitContainer1.Panel2.Controls.Add(this.SizeL);
            this.splitContainer1.Size = new System.Drawing.Size(647, 448);
            this.splitContainer1.SplitterDistance = 435;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(435, 448);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // ShearL
            // 
            this.ShearL.AutoSize = true;
            this.ShearL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShearL.Location = new System.Drawing.Point(9, 302);
            this.ShearL.Name = "ShearL";
            this.ShearL.Size = new System.Drawing.Size(56, 20);
            this.ShearL.TabIndex = 14;
            this.ShearL.Text = "Shear:";
            // 
            // ShearNUP
            // 
            this.ShearNUP.DecimalPlaces = 1;
            this.ShearNUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShearNUP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ShearNUP.Location = new System.Drawing.Point(69, 300);
            this.ShearNUP.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.ShearNUP.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            -2147418112});
            this.ShearNUP.Name = "ShearNUP";
            this.ShearNUP.Size = new System.Drawing.Size(91, 26);
            this.ShearNUP.TabIndex = 13;
            this.ShearNUP.ValueChanged += new System.EventHandler(this.ShearNUP_ValueChanged);
            // 
            // AngleIncrementNUP
            // 
            this.AngleIncrementNUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AngleIncrementNUP.Location = new System.Drawing.Point(154, 249);
            this.AngleIncrementNUP.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.AngleIncrementNUP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AngleIncrementNUP.Name = "AngleIncrementNUP";
            this.AngleIncrementNUP.Size = new System.Drawing.Size(43, 31);
            this.AngleIncrementNUP.TabIndex = 12;
            this.AngleIncrementNUP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AngleIncrementNUP.ValueChanged += new System.EventHandler(this.AngleIncrementNUP_ValueChanged);
            // 
            // StartStopRotationB
            // 
            this.StartStopRotationB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartStopRotationB.Location = new System.Drawing.Point(7, 237);
            this.StartStopRotationB.Name = "StartStopRotationB";
            this.StartStopRotationB.Size = new System.Drawing.Size(140, 57);
            this.StartStopRotationB.TabIndex = 11;
            this.StartStopRotationB.Text = "Start Rotating";
            this.StartStopRotationB.UseVisualStyleBackColor = true;
            this.StartStopRotationB.Click += new System.EventHandler(this.StartStopRotationB_Click);
            // 
            // RandomB
            // 
            this.RandomB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RandomB.Location = new System.Drawing.Point(7, 179);
            this.RandomB.Name = "RandomB";
            this.RandomB.Size = new System.Drawing.Size(195, 52);
            this.RandomB.TabIndex = 10;
            this.RandomB.Text = "Random Size and Color";
            this.RandomB.UseVisualStyleBackColor = true;
            this.RandomB.Click += new System.EventHandler(this.RandomB_Click);
            // 
            // SpaceShipB
            // 
            this.SpaceShipB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SpaceShipB.Location = new System.Drawing.Point(12, 380);
            this.SpaceShipB.Name = "SpaceShipB";
            this.SpaceShipB.Size = new System.Drawing.Size(185, 56);
            this.SpaceShipB.TabIndex = 9;
            this.SpaceShipB.Text = "Space Ship By #avice";
            this.SpaceShipB.UseVisualStyleBackColor = true;
            this.SpaceShipB.Click += new System.EventHandler(this.SpaceShipB_Click);
            // 
            // ScaleL
            // 
            this.ScaleL.AutoSize = true;
            this.ScaleL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScaleL.Location = new System.Drawing.Point(8, 149);
            this.ScaleL.Name = "ScaleL";
            this.ScaleL.Size = new System.Drawing.Size(53, 20);
            this.ScaleL.TabIndex = 8;
            this.ScaleL.Text = "Scale:";
            // 
            // ScaleNUP
            // 
            this.ScaleNUP.DecimalPlaces = 1;
            this.ScaleNUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScaleNUP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ScaleNUP.Location = new System.Drawing.Point(68, 147);
            this.ScaleNUP.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ScaleNUP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ScaleNUP.Name = "ScaleNUP";
            this.ScaleNUP.Size = new System.Drawing.Size(92, 26);
            this.ScaleNUP.TabIndex = 7;
            this.ScaleNUP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ScaleNUP.ValueChanged += new System.EventHandler(this.ScaleNUP_ValueChanged);
            // 
            // TextTB
            // 
            this.TextTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextTB.Location = new System.Drawing.Point(68, 115);
            this.TextTB.Margin = new System.Windows.Forms.Padding(2);
            this.TextTB.Name = "TextTB";
            this.TextTB.Size = new System.Drawing.Size(92, 26);
            this.TextTB.TabIndex = 6;
            this.TextTB.TextChanged += new System.EventHandler(this.TextTB_TextChanged);
            // 
            // AngleNUP
            // 
            this.AngleNUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AngleNUP.Location = new System.Drawing.Point(68, 86);
            this.AngleNUP.Margin = new System.Windows.Forms.Padding(2);
            this.AngleNUP.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.AngleNUP.Name = "AngleNUP";
            this.AngleNUP.Size = new System.Drawing.Size(91, 26);
            this.AngleNUP.TabIndex = 5;
            this.AngleNUP.ValueChanged += new System.EventHandler(this.AngleNUP_ValueChanged);
            // 
            // SizeNUP
            // 
            this.SizeNUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeNUP.Location = new System.Drawing.Point(68, 24);
            this.SizeNUP.Margin = new System.Windows.Forms.Padding(2);
            this.SizeNUP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SizeNUP.Name = "SizeNUP";
            this.SizeNUP.Size = new System.Drawing.Size(91, 26);
            this.SizeNUP.TabIndex = 4;
            this.SizeNUP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SizeNUP.ValueChanged += new System.EventHandler(this.SizeNUP_ValueChanged);
            // 
            // TextL
            // 
            this.TextL.AutoSize = true;
            this.TextL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextL.Location = new System.Drawing.Point(15, 114);
            this.TextL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TextL.Name = "TextL";
            this.TextL.Size = new System.Drawing.Size(43, 20);
            this.TextL.TabIndex = 3;
            this.TextL.Text = "Text:";
            // 
            // AngleL
            // 
            this.AngleL.AutoSize = true;
            this.AngleL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AngleL.Location = new System.Drawing.Point(15, 86);
            this.AngleL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AngleL.Name = "AngleL";
            this.AngleL.Size = new System.Drawing.Size(54, 20);
            this.AngleL.TabIndex = 3;
            this.AngleL.Text = "Angle:";
            // 
            // ColorL
            // 
            this.ColorL.AutoSize = true;
            this.ColorL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ColorL.Location = new System.Drawing.Point(15, 57);
            this.ColorL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ColorL.Name = "ColorL";
            this.ColorL.Size = new System.Drawing.Size(50, 20);
            this.ColorL.TabIndex = 3;
            this.ColorL.Text = "Color:";
            // 
            // ColorB
            // 
            this.ColorB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ColorB.Location = new System.Drawing.Point(68, 53);
            this.ColorB.Margin = new System.Windows.Forms.Padding(2);
            this.ColorB.Name = "ColorB";
            this.ColorB.Size = new System.Drawing.Size(91, 28);
            this.ColorB.TabIndex = 2;
            this.ColorB.UseVisualStyleBackColor = true;
            this.ColorB.Click += new System.EventHandler(this.ColorB_Click);
            // 
            // SizeL
            // 
            this.SizeL.AutoSize = true;
            this.SizeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SizeL.Location = new System.Drawing.Point(15, 24);
            this.SizeL.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SizeL.Name = "SizeL";
            this.SizeL.Size = new System.Drawing.Size(44, 20);
            this.SizeL.TabIndex = 1;
            this.SizeL.Text = "Size:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LAB3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 448);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LAB3";
            this.Text = "62 года ТУСУР";
            this.Load += new System.EventHandler(this.LAB3_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShearNUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngleIncrementNUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleNUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AngleNUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeNUP)).EndInit();
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
        private System.Windows.Forms.Label ScaleL;
        private System.Windows.Forms.NumericUpDown ScaleNUP;
        private System.Windows.Forms.Button SpaceShipB;
        private System.Windows.Forms.Button RandomB;
        private System.Windows.Forms.Button StartStopRotationB;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown AngleIncrementNUP;
        private System.Windows.Forms.Label ShearL;
        private System.Windows.Forms.NumericUpDown ShearNUP;
    }
}