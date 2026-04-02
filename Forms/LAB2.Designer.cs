namespace КГ
{
    partial class LAB2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LAB2));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CanvasPB = new System.Windows.Forms.PictureBox();
            this.TargetColorB = new System.Windows.Forms.Button();
            this.ThicknessL = new System.Windows.Forms.Label();
            this.ThicknessB = new System.Windows.Forms.Button();
            this.TargetColorPB = new System.Windows.Forms.PictureBox();
            this.BackgroundColorPB = new System.Windows.Forms.PictureBox();
            this.FillingColorPB = new System.Windows.Forms.PictureBox();
            this.LineColorPB = new System.Windows.Forms.PictureBox();
            this.ThicknessTitleL = new System.Windows.Forms.Label();
            this.ColorTitleL = new System.Windows.Forms.Label();
            this.BackgroundColorB = new System.Windows.Forms.Button();
            this.FillingColorB = new System.Windows.Forms.Button();
            this.LineColorB = new System.Windows.Forms.Button();
            this.BypassB = new System.Windows.Forms.Button();
            this.ClearB = new System.Windows.Forms.Button();
            this.AlgorithmsGB = new System.Windows.Forms.GroupBox();
            this.CDAClipRB = new System.Windows.Forms.RadioButton();
            this.ClipRB = new System.Windows.Forms.RadioButton();
            this.AsymmetricCDARB = new System.Windows.Forms.RadioButton();
            this.FillingRB = new System.Windows.Forms.RadioButton();
            this.CDARB = new System.Windows.Forms.RadioButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CanvasPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetColorPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundColorPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillingColorPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineColorPB)).BeginInit();
            this.AlgorithmsGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.CanvasPB);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TargetColorB);
            this.splitContainer1.Panel2.Controls.Add(this.ThicknessL);
            this.splitContainer1.Panel2.Controls.Add(this.ThicknessB);
            this.splitContainer1.Panel2.Controls.Add(this.TargetColorPB);
            this.splitContainer1.Panel2.Controls.Add(this.BackgroundColorPB);
            this.splitContainer1.Panel2.Controls.Add(this.FillingColorPB);
            this.splitContainer1.Panel2.Controls.Add(this.LineColorPB);
            this.splitContainer1.Panel2.Controls.Add(this.ThicknessTitleL);
            this.splitContainer1.Panel2.Controls.Add(this.ColorTitleL);
            this.splitContainer1.Panel2.Controls.Add(this.BackgroundColorB);
            this.splitContainer1.Panel2.Controls.Add(this.FillingColorB);
            this.splitContainer1.Panel2.Controls.Add(this.LineColorB);
            this.splitContainer1.Panel2.Controls.Add(this.BypassB);
            this.splitContainer1.Panel2.Controls.Add(this.ClearB);
            this.splitContainer1.Panel2.Controls.Add(this.AlgorithmsGB);
            // 
            // CanvasPB
            // 
            this.CanvasPB.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.CanvasPB, "CanvasPB");
            this.CanvasPB.Name = "CanvasPB";
            this.CanvasPB.TabStop = false;
            this.CanvasPB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasPB_MouseDown);
            this.CanvasPB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CanvasPB_MouseUp);
            // 
            // TargetColorB
            // 
            resources.ApplyResources(this.TargetColorB, "TargetColorB");
            this.TargetColorB.Name = "TargetColorB";
            this.TargetColorB.UseVisualStyleBackColor = true;
            this.TargetColorB.Click += new System.EventHandler(this.TargetColorB_Click);
            // 
            // ThicknessL
            // 
            resources.ApplyResources(this.ThicknessL, "ThicknessL");
            this.ThicknessL.Name = "ThicknessL";
            // 
            // ThicknessB
            // 
            resources.ApplyResources(this.ThicknessB, "ThicknessB");
            this.ThicknessB.Name = "ThicknessB";
            this.ThicknessB.UseVisualStyleBackColor = true;
            this.ThicknessB.Click += new System.EventHandler(this.Thickness_Click);
            // 
            // TargetColorPB
            // 
            resources.ApplyResources(this.TargetColorPB, "TargetColorPB");
            this.TargetColorPB.Name = "TargetColorPB";
            this.TargetColorPB.TabStop = false;
            // 
            // BackgroundColorPB
            // 
            resources.ApplyResources(this.BackgroundColorPB, "BackgroundColorPB");
            this.BackgroundColorPB.Name = "BackgroundColorPB";
            this.BackgroundColorPB.TabStop = false;
            // 
            // FillingColorPB
            // 
            resources.ApplyResources(this.FillingColorPB, "FillingColorPB");
            this.FillingColorPB.Name = "FillingColorPB";
            this.FillingColorPB.TabStop = false;
            // 
            // LineColorPB
            // 
            resources.ApplyResources(this.LineColorPB, "LineColorPB");
            this.LineColorPB.Name = "LineColorPB";
            this.LineColorPB.TabStop = false;
            // 
            // ThicknessTitleL
            // 
            resources.ApplyResources(this.ThicknessTitleL, "ThicknessTitleL");
            this.ThicknessTitleL.Name = "ThicknessTitleL";
            // 
            // ColorTitleL
            // 
            resources.ApplyResources(this.ColorTitleL, "ColorTitleL");
            this.ColorTitleL.Name = "ColorTitleL";
            // 
            // BackgroundColorB
            // 
            resources.ApplyResources(this.BackgroundColorB, "BackgroundColorB");
            this.BackgroundColorB.Name = "BackgroundColorB";
            this.BackgroundColorB.UseVisualStyleBackColor = true;
            this.BackgroundColorB.Click += new System.EventHandler(this.BackgroundColorB_Click);
            // 
            // FillingColorB
            // 
            resources.ApplyResources(this.FillingColorB, "FillingColorB");
            this.FillingColorB.Name = "FillingColorB";
            this.FillingColorB.UseVisualStyleBackColor = true;
            this.FillingColorB.Click += new System.EventHandler(this.FillingColorB_Click);
            // 
            // LineColorB
            // 
            resources.ApplyResources(this.LineColorB, "LineColorB");
            this.LineColorB.Name = "LineColorB";
            this.LineColorB.UseVisualStyleBackColor = true;
            this.LineColorB.Click += new System.EventHandler(this.LineColorB_Click);
            // 
            // BypassB
            // 
            resources.ApplyResources(this.BypassB, "BypassB");
            this.BypassB.Name = "BypassB";
            this.BypassB.UseVisualStyleBackColor = true;
            this.BypassB.Click += new System.EventHandler(this.BypassB_Click);
            // 
            // ClearB
            // 
            resources.ApplyResources(this.ClearB, "ClearB");
            this.ClearB.Name = "ClearB";
            this.ClearB.UseVisualStyleBackColor = true;
            this.ClearB.Click += new System.EventHandler(this.ClearB_Click);
            // 
            // AlgorithmsGB
            // 
            this.AlgorithmsGB.Controls.Add(this.CDAClipRB);
            this.AlgorithmsGB.Controls.Add(this.ClipRB);
            this.AlgorithmsGB.Controls.Add(this.AsymmetricCDARB);
            this.AlgorithmsGB.Controls.Add(this.FillingRB);
            this.AlgorithmsGB.Controls.Add(this.CDARB);
            resources.ApplyResources(this.AlgorithmsGB, "AlgorithmsGB");
            this.AlgorithmsGB.Name = "AlgorithmsGB";
            this.AlgorithmsGB.TabStop = false;
            // 
            // CDAClipRB
            // 
            resources.ApplyResources(this.CDAClipRB, "CDAClipRB");
            this.CDAClipRB.Name = "CDAClipRB";
            this.CDAClipRB.TabStop = true;
            this.CDAClipRB.UseVisualStyleBackColor = true;
            // 
            // ClipRB
            // 
            resources.ApplyResources(this.ClipRB, "ClipRB");
            this.ClipRB.Name = "ClipRB";
            this.ClipRB.TabStop = true;
            this.ClipRB.UseVisualStyleBackColor = true;
            // 
            // AsymmetricCDARB
            // 
            resources.ApplyResources(this.AsymmetricCDARB, "AsymmetricCDARB");
            this.AsymmetricCDARB.Name = "AsymmetricCDARB";
            this.AsymmetricCDARB.TabStop = true;
            this.AsymmetricCDARB.UseVisualStyleBackColor = true;
            // 
            // FillingRB
            // 
            resources.ApplyResources(this.FillingRB, "FillingRB");
            this.FillingRB.Name = "FillingRB";
            this.FillingRB.TabStop = true;
            this.FillingRB.UseVisualStyleBackColor = true;
            // 
            // CDARB
            // 
            resources.ApplyResources(this.CDARB, "CDARB");
            this.CDARB.Name = "CDARB";
            this.CDARB.TabStop = true;
            this.CDARB.UseVisualStyleBackColor = true;
            // 
            // LAB2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LAB2";
            this.Load += new System.EventHandler(this.LAB2_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CanvasPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TargetColorPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundColorPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FillingColorPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LineColorPB)).EndInit();
            this.AlgorithmsGB.ResumeLayout(false);
            this.AlgorithmsGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox CanvasPB;
        private System.Windows.Forms.GroupBox AlgorithmsGB;
        private System.Windows.Forms.RadioButton CDARB;
        private System.Windows.Forms.RadioButton FillingRB;
        private System.Windows.Forms.Button ClearB;
        private System.Windows.Forms.Button BypassB;
        private System.Windows.Forms.PictureBox LineColorPB;
        private System.Windows.Forms.Label ColorTitleL;
        private System.Windows.Forms.Button BackgroundColorB;
        private System.Windows.Forms.Button FillingColorB;
        private System.Windows.Forms.Button LineColorB;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.PictureBox BackgroundColorPB;
        private System.Windows.Forms.PictureBox FillingColorPB;
        private System.Windows.Forms.Label ThicknessTitleL;
        private System.Windows.Forms.Label ThicknessL;
        private System.Windows.Forms.Button ThicknessB;
        private System.Windows.Forms.RadioButton AsymmetricCDARB;
        private System.Windows.Forms.RadioButton ClipRB;
        private System.Windows.Forms.RadioButton CDAClipRB;
        private System.Windows.Forms.Button TargetColorB;
        private System.Windows.Forms.PictureBox TargetColorPB;
    }
}