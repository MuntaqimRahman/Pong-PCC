namespace Pong_PCC
{
    partial class formGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGame));
            this.pboxGameboard = new System.Windows.Forms.PictureBox();
            this.lblScoreLeft = new System.Windows.Forms.Label();
            this.lblScoreRight = new System.Windows.Forms.Label();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblWinMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pboxGameboard)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxGameboard
            // 
            this.pboxGameboard.BackColor = System.Drawing.Color.Black;
            this.pboxGameboard.Location = new System.Drawing.Point(0, 0);
            this.pboxGameboard.Name = "pboxGameboard";
            this.pboxGameboard.Size = new System.Drawing.Size(640, 480);
            this.pboxGameboard.TabIndex = 0;
            this.pboxGameboard.TabStop = false;
            this.pboxGameboard.Paint += new System.Windows.Forms.PaintEventHandler(this.pboxGameboard_Paint);
            // 
            // lblScoreLeft
            // 
            this.lblScoreLeft.AutoSize = true;
            this.lblScoreLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreLeft.Font = new System.Drawing.Font("Cooper Black", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreLeft.ForeColor = System.Drawing.Color.White;
            this.lblScoreLeft.Location = new System.Drawing.Point(67, 39);
            this.lblScoreLeft.Name = "lblScoreLeft";
            this.lblScoreLeft.Size = new System.Drawing.Size(108, 74);
            this.lblScoreLeft.TabIndex = 2;
            this.lblScoreLeft.Text = "00";
            // 
            // lblScoreRight
            // 
            this.lblScoreRight.AutoSize = true;
            this.lblScoreRight.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreRight.Font = new System.Drawing.Font("Cooper Black", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScoreRight.ForeColor = System.Drawing.Color.White;
            this.lblScoreRight.Location = new System.Drawing.Point(431, 39);
            this.lblScoreRight.Name = "lblScoreRight";
            this.lblScoreRight.Size = new System.Drawing.Size(108, 74);
            this.lblScoreRight.TabIndex = 3;
            this.lblScoreRight.Text = "00";
            // 
            // btnRestart
            // 
            this.btnRestart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestart.ForeColor = System.Drawing.Color.White;
            this.btnRestart.Location = new System.Drawing.Point(554, 12);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 4;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblWinMessage
            // 
            this.lblWinMessage.AutoSize = true;
            this.lblWinMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblWinMessage.Font = new System.Drawing.Font("Cooper Black", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinMessage.ForeColor = System.Drawing.Color.White;
            this.lblWinMessage.Location = new System.Drawing.Point(131, 204);
            this.lblWinMessage.Name = "lblWinMessage";
            this.lblWinMessage.Size = new System.Drawing.Size(0, 74);
            this.lblWinMessage.TabIndex = 5;
            // 
            // formGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 481);
            this.Controls.Add(this.lblWinMessage);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.lblScoreRight);
            this.Controls.Add(this.lblScoreLeft);
            this.Controls.Add(this.pboxGameboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "formGame";
            this.Text = "PONG";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PONG_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PONG_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pboxGameboard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxGameboard;
        private System.Windows.Forms.Label lblScoreLeft;
        private System.Windows.Forms.Label lblScoreRight;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblWinMessage;
    }
}

