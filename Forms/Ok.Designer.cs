namespace КГ
{
    partial class Ok
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
            this.SuspendLayout();
            // 
            // OkB
            // 
            this.OkB.Location = new System.Drawing.Point(202, 79);
            this.OkB.Name = "OkB";
            this.OkB.Size = new System.Drawing.Size(75, 23);
            this.OkB.TabIndex = 0;
            this.OkB.Text = "Ok";
            this.OkB.UseVisualStyleBackColor = true;
            this.OkB.Click += new System.EventHandler(this.OkB_Click);
            // 
            // Ok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 114);
            this.Controls.Add(this.OkB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Ok";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ok";
            this.Load += new System.EventHandler(this.Ok_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button OkB;
    }
}