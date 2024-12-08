using System;
using System.Collections.Generic;
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
    internal class Player
    {
        private int lives; // Antalet liv för spelaren
        private PictureBox picLifeOne; // Extra liv 1
        private PictureBox picLifeTwo; // Extra liv 2
        private GameForm gameForm; // Aktuell spelyta

        /// <summary>
        /// Skapa en ny spelare
        /// </summary>
        /// <param name="initialLives"></param>
        /// <param name="lifeOne"></param>
        /// <param name="lifeTwo"></param>
        /// <param name="form"></param>
        public Player(int initialLives, PictureBox lifeOne, PictureBox lifeTwo, GameForm form)
        {
            lives = initialLives;
            picLifeOne = lifeOne;
            picLifeTwo = lifeTwo;
            gameForm = form;
        }

        /// <summary>
        /// Räkna av ett liv från spelaren samt dölj extra liv
        /// Om liv är 0 hantera gameover på spelytan
        /// </summary>
        public void RemoveLife()
        {
            lives--; // Ta bort ett liv

            // Dölja extra liv
            if (lives < 3)
            {
                picLifeTwo.Hide();
            }
            if (lives < 2)
            {
                picLifeOne.Hide();
            }

            // Slut på liv skicka game over
            if (lives == 0)
            {
                gameForm.HandleGameOver();
            }

        }

    }
}
