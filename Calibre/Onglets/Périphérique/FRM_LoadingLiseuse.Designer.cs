namespace PPE { 
    partial class FRM_LoadingLiseuse
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
            this.PB_bar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // PB_bar
            // 
            this.PB_bar.Location = new System.Drawing.Point(63, 197);
            this.PB_bar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PB_bar.Name = "PB_bar";
            this.PB_bar.Size = new System.Drawing.Size(526, 35);
            this.PB_bar.Step = 1;
            this.PB_bar.TabIndex = 0;
            // 
            // FRM_LoadingLiseuse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(662, 312);
            this.ControlBox = false;
            this.Controls.Add(this.PB_bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_LoadingLiseuse";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FRM_LoadingLiseuse";
            this.ResumeLayout(false);

        }

    #endregion

    public System.Windows.Forms.ProgressBar PB_bar;
    }
}