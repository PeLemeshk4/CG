namespace КГ
{
    partial class MainForm
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
            this.Lab1B = new System.Windows.Forms.Button();
            this.Lab2B = new System.Windows.Forms.Button();
            this.Lab4B = new System.Windows.Forms.Button();
            this.Lab3B = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lab1B
            // 
            this.Lab1B.Location = new System.Drawing.Point(10, 10);
            this.Lab1B.Name = "Lab1B";
            this.Lab1B.Size = new System.Drawing.Size(100, 80);
            this.Lab1B.TabIndex = 0;
            this.Lab1B.Text = "LAB1";
            this.Lab1B.UseVisualStyleBackColor = true;
            this.Lab1B.Click += new System.EventHandler(this.Lab1B_Click);
            // 
            // Lab2B
            // 
            this.Lab2B.Location = new System.Drawing.Point(115, 10);
            this.Lab2B.Name = "Lab2B";
            this.Lab2B.Size = new System.Drawing.Size(100, 80);
            this.Lab2B.TabIndex = 0;
            this.Lab2B.Text = "LAB2";
            this.Lab2B.UseVisualStyleBackColor = true;
            // 
            // Lab4B
            // 
            this.Lab4B.Location = new System.Drawing.Point(115, 95);
            this.Lab4B.Name = "Lab4B";
            this.Lab4B.Size = new System.Drawing.Size(100, 80);
            this.Lab4B.TabIndex = 0;
            this.Lab4B.Text = "LAB4";
            this.Lab4B.UseVisualStyleBackColor = true;
            // 
            // Lab3B
            // 
            this.Lab3B.Location = new System.Drawing.Point(10, 95);
            this.Lab3B.Name = "Lab3B";
            this.Lab3B.Size = new System.Drawing.Size(100, 80);
            this.Lab3B.TabIndex = 0;
            this.Lab3B.Text = "LAB3";
            this.Lab3B.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 181);
            this.Controls.Add(this.Lab3B);
            this.Controls.Add(this.Lab4B);
            this.Controls.Add(this.Lab2B);
            this.Controls.Add(this.Lab1B);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Lab1B;
        private System.Windows.Forms.Button Lab2B;
        private System.Windows.Forms.Button Lab4B;
        private System.Windows.Forms.Button Lab3B;
    }
}