using SpaceShot.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShot
{
    /// <summary>
    /// Author: Alexander Tofer
    /// Assignment 7 @ mau.se
    /// Version: 2
    /// Date: 2023-06-09
    /// </summary>
    internal class Enemy
    {
        public PictureBox EnemyPictureBox { get; set; }
        public int Speed { get; private set; }

        private bool isExploding = false; // Träff är registrerad
        private Random rnd;
        private Player player;

        /// <summary>
        /// Skapar en ny fiende
        /// </summary>
        /// <param name="speed">hastighet att röra sig med</param>
        /// <param name="rnd"></param>
        /// <param name="image"></param>
        /// <param name="gamePlayer"></param>
        public Enemy(int speed, Random rnd, System.Drawing.Image image, Player gamePlayer)
        {
            this.Speed = speed;
            this.rnd = rnd;
            player = gamePlayer;
            InitializeEnemyPictureBox(image);
            Reset();
        }

        /// <summary>
        /// Skapar ny bild en fiende
        /// </summary>
        /// <param name="image">Bild att visa</param>
        private void InitializeEnemyPictureBox(System.Drawing.Image image)
        {
            EnemyPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(58, 58),
                BackColor = Color.Transparent,
                Image = image
            };
        }

        /// <summary>
        /// Ställer in position på bilden
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        public void SetPosition(int left, int top)
        {
            EnemyPictureBox.Left = left;
            EnemyPictureBox.Top = top;
        }

        /// <summary>
        /// Flytta ner fiender
        /// </summary>
        public void Move(int mv_speed)
        {
            if (!isExploding) // Kör om enemy inte är träffad
            {
                // flytta ner med den hastighet på fiende
                EnemyPictureBox.Top += mv_speed;

                // fiende har nått botten
                if (EnemyPictureBox.Top > 735)
                {               
                    Reset(); // Nollställ enemy
                }
            }
        }

        /// <summary>
        /// För att återställa en fiende
        /// </summary>
        public void Reset()
        {
            isExploding = false; // Ta bort explosion
            EnemyPictureBox.Size = new Size(58, 58); // Återställ storlek på fiende

            // Räkna ut en slumpmässig position
            SetPosition(rnd.Next(20, 600), rnd.Next(-200, -30));

            // Kontroll att start är från top
            if (EnemyPictureBox.Top > 0)
            {
                EnemyPictureBox.Top = -EnemyPictureBox.Height;
            }
        }


        /// <summary>
        /// Vid träff byt ut bilden mot en explosion
        /// </summary>
        public void ShowExplosion()
        {
            isExploding = true; // Sluta upp att flytta

            int randomExplosion = rnd.Next(3); // Ta fram en explosion mellan 0-2

            switch (randomExplosion)
            {
                case 0:
                    EnemyPictureBox.Image = SpaceShot.Properties.Resources.explosions_a;
                    break;
                case 1:
                    EnemyPictureBox.Image = SpaceShot.Properties.Resources.explosions_b;
                    break;
                case 2:
                    EnemyPictureBox.Image = SpaceShot.Properties.Resources.explosions_c;
                    break;
            }

            // Ändra storlek på picturebox för explosionen
            EnemyPictureBox.Size = new Size(32, 32);
        }

    }
}
