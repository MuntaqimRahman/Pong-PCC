namespace Pong_PCC
{
    partial class formMenu
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

        #region Windows Form Designer generated code and custom button hover code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMenu));
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.gboxPlay = new System.Windows.Forms.GroupBox();
            this.btnTwoPlayer = new System.Windows.Forms.Button();
            this.btnSinglePlayer = new System.Windows.Forms.Button();
            this.gboxRules = new System.Windows.Forms.GroupBox();
            this.btnRules = new System.Windows.Forms.Button();
            this.gboxPlay.SuspendLayout();
            this.gboxRules.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLogo.BackgroundImage")));
            this.pnlLogo.Location = new System.Drawing.Point(1, 12);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(627, 114);
            this.pnlLogo.TabIndex = 0;
            // 
            // gboxPlay
            // 
            this.gboxPlay.Controls.Add(this.btnTwoPlayer);
            this.gboxPlay.Controls.Add(this.btnSinglePlayer);
            this.gboxPlay.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxPlay.ForeColor = System.Drawing.Color.White;
            this.gboxPlay.Location = new System.Drawing.Point(12, 146);
            this.gboxPlay.Name = "gboxPlay";
            this.gboxPlay.Size = new System.Drawing.Size(600, 146);
            this.gboxPlay.TabIndex = 1;
            this.gboxPlay.TabStop = false;
            this.gboxPlay.Text = "PLAY";
            // 
            // btnTwoPlayer
            // 
            this.btnTwoPlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTwoPlayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnTwoPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTwoPlayer.ForeColor = System.Drawing.Color.White;
            this.btnTwoPlayer.Location = new System.Drawing.Point(18, 90);
            this.btnTwoPlayer.Name = "btnTwoPlayer";
            this.btnTwoPlayer.Size = new System.Drawing.Size(561, 29);
            this.btnTwoPlayer.TabIndex = 1;
            this.btnTwoPlayer.Text = "2 Player";
            this.btnTwoPlayer.UseVisualStyleBackColor = true;
            this.btnTwoPlayer.Click += new System.EventHandler(this.btnTwoPlayer_Click);
            // 
            // btnSinglePlayer
            // 
            this.btnSinglePlayer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSinglePlayer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnSinglePlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSinglePlayer.ForeColor = System.Drawing.Color.White;
            this.btnSinglePlayer.Location = new System.Drawing.Point(18, 36);
            this.btnSinglePlayer.Name = "btnSinglePlayer";
            this.btnSinglePlayer.Size = new System.Drawing.Size(561, 29);
            this.btnSinglePlayer.TabIndex = 0;
            this.btnSinglePlayer.Text = "Single Player";
            this.btnSinglePlayer.UseVisualStyleBackColor = true;
            this.btnSinglePlayer.Click += new System.EventHandler(this.btnSinglePlayer_Click);
            // 
            // gboxRules
            // 
            this.gboxRules.Controls.Add(this.btnRules);
            this.gboxRules.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxRules.ForeColor = System.Drawing.Color.White;
            this.gboxRules.Location = new System.Drawing.Point(12, 298);
            this.gboxRules.Name = "gboxRules";
            this.gboxRules.Size = new System.Drawing.Size(600, 89);
            this.gboxRules.TabIndex = 4;
            this.gboxRules.TabStop = false;
            this.gboxRules.Text = "RULES";
            // 
            // btnRules
            // 
            this.btnRules.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRules.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRules.ForeColor = System.Drawing.Color.White;
            this.btnRules.Location = new System.Drawing.Point(18, 36);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(561, 29);
            this.btnRules.TabIndex = 0;
            this.btnRules.Text = "Show Rules and Controls";
            this.btnRules.UseVisualStyleBackColor = true;
            this.btnRules.Click += new System.EventHandler(this.btnRules_Click);
            // 
            // formMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(624, 410);
            this.Controls.Add(this.gboxRules);
            this.Controls.Add(this.gboxPlay);
            this.Controls.Add(this.pnlLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formMenu";
            this.Text = "Menu";
            this.gboxPlay.ResumeLayout(false);
            this.gboxRules.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.GroupBox gboxPlay;
        private System.Windows.Forms.Button btnTwoPlayer;
        private System.Windows.Forms.Button btnSinglePlayer;
        private System.Windows.Forms.GroupBox gboxRules;
        private System.Windows.Forms.Button btnRules;
    }
}