namespace SpaceShot
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.lblMyScore = new System.Windows.Forms.Label();
            this.timeGame = new System.Windows.Forms.Timer(this.components);
            this.lblHiScore = new System.Windows.Forms.Label();
            this.lblMenuText = new System.Windows.Forms.Label();
            this.lblAbout = new System.Windows.Forms.Label();
            this.lblReadHiScoreFromFile = new System.Windows.Forms.Label();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.PictureBox();
            this.picLifeTwo = new System.Windows.Forms.PictureBox();
            this.picLifeOne = new System.Windows.Forms.PictureBox();
            this.bullet = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblGameLevel = new System.Windows.Forms.Label();
            this.picboxScreenRed = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLifeTwo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLifeOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxScreenRed)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMyScore
            // 
            this.lblMyScore.AutoSize = true;
            this.lblMyScore.BackColor = System.Drawing.Color.Gray;
            this.lblMyScore.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMyScore.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMyScore.Location = new System.Drawing.Point(20, 672);
            this.lblMyScore.Name = "lblMyScore";
            this.lblMyScore.Size = new System.Drawing.Size(119, 34);
            this.lblMyScore.TabIndex = 3;
            this.lblMyScore.Text = "10000001";
            // 
            // timeGame
            // 
            this.timeGame.Enabled = true;
            this.timeGame.Interval = 10;
            this.timeGame.Tick += new System.EventHandler(this.timeGame_Tick);
            // 
            // lblHiScore
            // 
            this.lblHiScore.AutoSize = true;
            this.lblHiScore.BackColor = System.Drawing.Color.Gray;
            this.lblHiScore.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHiScore.ForeColor = System.Drawing.Color.DarkRed;
            this.lblHiScore.Location = new System.Drawing.Point(205, 672);
            this.lblHiScore.Name = "lblHiScore";
            this.lblHiScore.Size = new System.Drawing.Size(153, 34);
            this.lblHiScore.TabIndex = 8;
            this.lblHiScore.Text = "HI   9900000";
            // 
            // lblMenuText
            // 
            this.lblMenuText.BackColor = System.Drawing.Color.Black;
            this.lblMenuText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMenuText.Font = new System.Drawing.Font("Impact", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuText.ForeColor = System.Drawing.Color.Silver;
            this.lblMenuText.Location = new System.Drawing.Point(0, 0);
            this.lblMenuText.Name = "lblMenuText";
            this.lblMenuText.Size = new System.Drawing.Size(639, 716);
            this.lblMenuText.TabIndex = 10;
            this.lblMenuText.Text = "Welcome to SPACE SHOOTER";
            this.lblMenuText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAbout.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout.ForeColor = System.Drawing.Color.Silver;
            this.lblAbout.Location = new System.Drawing.Point(452, 100);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(69, 29);
            this.lblAbout.TabIndex = 11;
            this.lblAbout.Text = "About";
            this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
            // 
            // lblReadHiScoreFromFile
            // 
            this.lblReadHiScoreFromFile.AutoSize = true;
            this.lblReadHiScoreFromFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblReadHiScoreFromFile.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReadHiScoreFromFile.ForeColor = System.Drawing.Color.Silver;
            this.lblReadHiScoreFromFile.Location = new System.Drawing.Point(100, 100);
            this.lblReadHiScoreFromFile.Name = "lblReadHiScoreFromFile";
            this.lblReadHiScoreFromFile.Size = new System.Drawing.Size(118, 29);
            this.lblReadHiScoreFromFile.TabIndex = 12;
            this.lblReadHiScoreFromFile.Text = "High Score";
            this.lblReadHiScoreFromFile.Click += new System.EventHandler(this.lblHi_Click);
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInstructions.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.ForeColor = System.Drawing.Color.Silver;
            this.lblInstructions.Location = new System.Drawing.Point(268, 100);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(134, 29);
            this.lblInstructions.TabIndex = 13;
            this.lblInstructions.Text = "Instructions";
            this.lblInstructions.Click += new System.EventHandler(this.lblInstructions_Click);
            // 
            // player
            // 
            this.player.Image = global::SpaceShot.Properties.Resources.ship_a2;
            this.player.Location = new System.Drawing.Point(268, 596);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(62, 62);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 5;
            this.player.TabStop = false;
            // 
            // picLifeTwo
            // 
            this.picLifeTwo.BackColor = System.Drawing.Color.Gray;
            this.picLifeTwo.Image = global::SpaceShot.Properties.Resources.ship_a2;
            this.picLifeTwo.Location = new System.Drawing.Point(561, 672);
            this.picLifeTwo.Name = "picLifeTwo";
            this.picLifeTwo.Size = new System.Drawing.Size(32, 32);
            this.picLifeTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLifeTwo.TabIndex = 7;
            this.picLifeTwo.TabStop = false;
            // 
            // picLifeOne
            // 
            this.picLifeOne.BackColor = System.Drawing.Color.Gray;
            this.picLifeOne.Image = global::SpaceShot.Properties.Resources.ship_a2;
            this.picLifeOne.Location = new System.Drawing.Point(599, 672);
            this.picLifeOne.Name = "picLifeOne";
            this.picLifeOne.Size = new System.Drawing.Size(32, 32);
            this.picLifeOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLifeOne.TabIndex = 6;
            this.picLifeOne.TabStop = false;
            // 
            // bullet
            // 
            this.bullet.Image = global::SpaceShot.Properties.Resources.bullet_d4;
            this.bullet.Location = new System.Drawing.Point(289, 562);
            this.bullet.Name = "bullet";
            this.bullet.Size = new System.Drawing.Size(24, 24);
            this.bullet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bullet.TabIndex = 4;
            this.bullet.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Location = new System.Drawing.Point(-4, 662);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(643, 58);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // lblGameLevel
            // 
            this.lblGameLevel.AutoSize = true;
            this.lblGameLevel.BackColor = System.Drawing.Color.Gray;
            this.lblGameLevel.Font = new System.Drawing.Font("Impact", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameLevel.ForeColor = System.Drawing.Color.DarkRed;
            this.lblGameLevel.Location = new System.Drawing.Point(382, 672);
            this.lblGameLevel.Name = "lblGameLevel";
            this.lblGameLevel.Size = new System.Drawing.Size(63, 34);
            this.lblGameLevel.TabIndex = 14;
            this.lblGameLevel.Text = "LVL 1";
            // 
            // picboxScreenRed
            // 
            this.picboxScreenRed.BackColor = System.Drawing.Color.Firebrick;
            this.picboxScreenRed.Location = new System.Drawing.Point(0, 0);
            this.picboxScreenRed.Name = "picboxScreenRed";
            this.picboxScreenRed.Size = new System.Drawing.Size(639, 666);
            this.picboxScreenRed.TabIndex = 15;
            this.picboxScreenRed.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(639, 716);
            this.Controls.Add(this.lblGameLevel);
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.lblReadHiScoreFromFile);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.player);
            this.Controls.Add(this.lblHiScore);
            this.Controls.Add(this.picLifeTwo);
            this.Controls.Add(this.picLifeOne);
            this.Controls.Add(this.bullet);
            this.Controls.Add(this.lblMyScore);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblMenuText);
            this.Controls.Add(this.picboxScreenRed);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLifeTwo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLifeOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picboxScreenRed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMyScore;
        private System.Windows.Forms.PictureBox bullet;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer timeGame;
        private System.Windows.Forms.PictureBox picLifeOne;
        private System.Windows.Forms.PictureBox picLifeTwo;
        private System.Windows.Forms.Label lblHiScore;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblMenuText;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label lblReadHiScoreFromFile;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label lblGameLevel;
        private System.Windows.Forms.PictureBox picboxScreenRed;
    }
}

