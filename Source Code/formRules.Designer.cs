namespace Pong_PCC
{
    partial class formRules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formRules));
            this.pnlRules = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlRules
            // 
            this.pnlRules.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlRules.BackgroundImage")));
            this.pnlRules.Location = new System.Drawing.Point(0, 0);
            this.pnlRules.Name = "pnlRules";
            this.pnlRules.Size = new System.Drawing.Size(640, 382);
            this.pnlRules.TabIndex = 0;
            // 
            // formRules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(639, 394);
            this.Controls.Add(this.pnlRules);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formRules";
            this.Text = "Rules";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRules;
    }
}