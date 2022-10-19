
namespace Boatbattle
{
    partial class Level1_forrm
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
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.gameDetailsBox = new System.Windows.Forms.GroupBox();
            this.lblMainMenu = new System.Windows.Forms.Label();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblLives = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.gameDetailsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Enabled = true;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // gameDetailsBox
            // 
            this.gameDetailsBox.Controls.Add(this.lblMainMenu);
            this.gameDetailsBox.Controls.Add(this.lblLevel);
            this.gameDetailsBox.Controls.Add(this.lblLives);
            this.gameDetailsBox.Controls.Add(this.lblScore);
            this.gameDetailsBox.Location = new System.Drawing.Point(0, 0);
            this.gameDetailsBox.Name = "gameDetailsBox";
            this.gameDetailsBox.Size = new System.Drawing.Size(1382, 50);
            this.gameDetailsBox.TabIndex = 0;
            this.gameDetailsBox.TabStop = false;
            // 
            // lblMainMenu
            // 
            this.lblMainMenu.AutoSize = true;
            this.lblMainMenu.BackColor = System.Drawing.Color.DarkOrange;
            this.lblMainMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainMenu.Location = new System.Drawing.Point(1258, 16);
            this.lblMainMenu.Name = "lblMainMenu";
            this.lblMainMenu.Size = new System.Drawing.Size(98, 22);
            this.lblMainMenu.TabIndex = 3;
            this.lblMainMenu.Text = "Main Menu";
            // 
            // lblLevel
            // 
            this.lblLevel.AutoSize = true;
            this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevel.Location = new System.Drawing.Point(397, 16);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(66, 20);
            this.lblLevel.TabIndex = 2;
            this.lblLevel.Text = "Level 1";
            // 
            // lblLives
            // 
            this.lblLives.AutoSize = true;
            this.lblLives.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLives.Location = new System.Drawing.Point(252, 16);
            this.lblLives.Name = "lblLives";
            this.lblLives.Size = new System.Drawing.Size(65, 20);
            this.lblLives.TabIndex = 1;
            this.lblLives.Text = "Lives 3";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(91, 16);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(73, 20);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score --";
            // 
            // Level1_forrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Boatbattle.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 705);
            this.Controls.Add(this.gameDetailsBox);
            this.DoubleBuffered = true;
            this.Name = "Level1_forrm";
            this.Text = "Boat Battle";
            this.Load += new System.EventHandler(this.Level1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Level1_KeyDown);
            this.gameDetailsBox.ResumeLayout(false);
            this.gameDetailsBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.GroupBox gameDetailsBox;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblMainMenu;
        private System.Windows.Forms.Label lblLevel;
        private System.Windows.Forms.Label lblLives;
    }
}

