namespace КГ.Forms
{
    partial class EnterNumber
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
            this.OkB = new System.Windows.Forms.Button();
            this.CancelB = new System.Windows.Forms.Button();
            this.EnterValueL = new System.Windows.Forms.Label();
            this.EnterValueNUP = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.EnterValueNUP)).BeginInit();
            this.SuspendLayout();
            // 
            // OkB
            // 
            this.OkB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OkB.Location = new System.Drawing.Point(174, 70);
            this.OkB.Name = "OkB";
            this.OkB.Size = new System.Drawing.Size(79, 30);
            this.OkB.TabIndex = 0;
            this.OkB.Text = "Ok";
            this.OkB.UseVisualStyleBackColor = true;
            this.OkB.Click += new System.EventHandler(this.OkB_Click);
            // 
            // CancelB
            // 
            this.CancelB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CancelB.Location = new System.Drawing.Point(12, 70);
            this.CancelB.Name = "CancelB";
            this.CancelB.Size = new System.Drawing.Size(79, 30);
            this.CancelB.TabIndex = 0;
            this.CancelB.Text = "Cancel";
            this.CancelB.UseVisualStyleBackColor = true;
            this.CancelB.Click += new System.EventHandler(this.CancelB_Click);
            // 
            // EnterValueL
            // 
            this.EnterValueL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterValueL.Location = new System.Drawing.Point(12, 33);
            this.EnterValueL.Name = "EnterValueL";
            this.EnterValueL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EnterValueL.Size = new System.Drawing.Size(156, 23);
            this.EnterValueL.TabIndex = 1;
            this.EnterValueL.Text = "Value";
            // 
            // EnterValueNUP
            // 
            this.EnterValueNUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EnterValueNUP.Location = new System.Drawing.Point(174, 30);
            this.EnterValueNUP.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EnterValueNUP.Name = "EnterValueNUP";
            this.EnterValueNUP.Size = new System.Drawing.Size(76, 26);
            this.EnterValueNUP.TabIndex = 2;
            this.EnterValueNUP.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // EnterNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 111);
            this.Controls.Add(this.EnterValueNUP);
            this.Controls.Add(this.EnterValueL);
            this.Controls.Add(this.CancelB);
            this.Controls.Add(this.OkB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EnterNumber";
            this.Text = "Введите число";
            ((System.ComponentModel.ISupportInitialize)(this.EnterValueNUP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkB;
        private System.Windows.Forms.Button CancelB;
        private System.Windows.Forms.Label EnterValueL;
        private System.Windows.Forms.NumericUpDown EnterValueNUP;
    }
}