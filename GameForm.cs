using SpaceShot.Properties;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceShot
{
    /// <summary>
    /// Author: Alexander Tofer | GAME ART from: https://ansimuz.itch.io/star-fighter
    /// Assignment 7 @ mau.se
    /// Version: 2
    /// Date: 2023-06-09
    /// </summary>
    public partial class GameForm : Form
    {
        
        // Spelaren + 3st fiender
        private Player newPlayer;
        private Enemy enemyOne;
        private Enemy enemyTwo;
        private Enemy enemyThree;

        bool moveLeft, moveRight, shooting, gameOver;

        int bulletSpeed; // Normal hastighet på skott
        int extraBulletSpeed; // Extra hastighet
        int playerSpeed; // Spelarens hstighet
        int score; // Poäng
        int gameLevel = 1; // Börja spelt på nivå 1
        int enemySpeed = 2; // Start hastighet på fiender

        Random rnd = new Random(); // Slumptal generator

        // Hantera läs/skriv till fil för high score
        FileManager fileManager = new FileManager();
        string fileName = Application.StartupPath + "\\highscore.txt"; // Sökväg till data fil att spara


        public GameForm()
        {         
            InitializeComponent();

            // Ändra meny text
            this.Text = "SPACE SHOOTER PRO v1.1 by Alex";
            lblMenuText.Text = "Welcome!" + Environment.NewLine + Environment.NewLine + "Press -1-  for SPEED" + Environment.NewLine + "Press -2- for POWER" + Environment.NewLine + "Press -3- for LIVES";
            lblMyScore.Text = "SPACE SHOOTER";
            lblGameLevel.Text = "LVL START";

            // Vänta med att starta spelet
            gameOver = true; 
            timeGame.Stop();
            picLifeTwo.Hide();        
            spawnEnemies();
            picboxScreenRed.Visible = false;

            // Läs in aktuell High Score från fil
            int highScore = fileManager.ReadHighScoreFromFile(fileName).HighScore;
            lblHiScore.Text = "HI " + highScore.ToString();

        }
        /// <summary>
        /// Skapar en ny spelare
        /// </summary>
        /// <param name="lives">ange antalet extra liv</param>
        private void spawnPlayer(int lives)
        {
            newPlayer = new Player(lives, picLifeOne, picLifeTwo, this);

            // Visa hur många extra liv som finns
            picLifeOne.Show();
            if (lives > 2 ) { picLifeTwo.Show(); }         
        }

        /// <summary>
        /// Skapar nya fiender och lägger till de på form
        /// </summary>
        private void spawnEnemies()
        {
            // Skapar nya instanser av fiender
            enemyOne = new Enemy(enemySpeed, rnd, Resources.enemy_ship1, newPlayer);
            enemyTwo = new Enemy(enemySpeed, rnd, Resources.enemy_ship2, newPlayer);
            enemyThree = new Enemy(enemySpeed, rnd, Resources.enemy_ship3, newPlayer);

            // Lägg till fiender på spelytan(GameForm)
            Controls.Add(enemyOne.EnemyPictureBox);
            Controls.Add(enemyTwo.EnemyPictureBox);
            Controls.Add(enemyThree.EnemyPictureBox);

        }

        /// <summary>
        /// För att flytta Pil Höger + Vänster
        /// </summary>
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = true;
            } 
        }

        /// <summary>
        /// Alla kontroller efter knapptryckning
        /// </summary>
        private void keyisup(object sender, KeyEventArgs e)
        {
            // För kontroll om spelare ska rör sig 
            if (e.KeyCode == Keys.Left)
            {
                moveLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                moveRight = false;
            }
            if (e.KeyCode == Keys.Space && shooting == false) // Nytt skott
            {
                shooting = true;

                bullet.Top = player.Top - 30;
                bullet.Left = player.Left + (player.Width / 2);

            }

            // ----------------------------------
            // 1 - 2 - 3 har tryckts för START + GAME OVER läge
            // ----------------------------------

            // Extra SPEED
            if (e.KeyCode == Keys.D1 && gameOver == true)
            {
                playerSpeed = 8;
                extraBulletSpeed = 15;
                spawnPlayer(2);
                resetGame();
            }

            // BULLETS faster
            if (e.KeyCode == Keys.D2 && gameOver == true)
            {
                playerSpeed = 4;
                extraBulletSpeed = 45;
                spawnPlayer(2);
                resetGame();
            }

            // EXTRA lives
            if (e.KeyCode == Keys.D3 && gameOver == true)
            {
                playerSpeed = 4;
                extraBulletSpeed = 15;
                spawnPlayer(3);
                resetGame();
            }
        }

        /// <summary>
        /// Rita om spelytan vid varje timer 10ms
        /// </summary>
        private async void timeGame_Tick(object sender, EventArgs e)
        {
            // ----------------------------------
            // Räknare för poäng
            // ----------------------------------
            score++; // öka poäng med tiden
            lblMyScore.Text = score.ToString();

            // ----------------------------------
            // Olika nivåer - enemySpeed++ 
            // ----------------------------------
            if (score >= 5000)
            {
                gameLevel = 2; // Ändra till nivå 2
                lblGameLevel.Text = "LVL GET READY"; // Uppdatera text
                enemySpeed = 3; // öka hstighet på fiender
            }
            if (score >= 10000)
            {
                gameLevel = 3;
                lblGameLevel.Text = "LVL BEGINNER";
                enemySpeed = 4;
            }
            if (score >= 20000)
            {
                gameLevel = 4;
                lblGameLevel.Text = "LVL ADVANCE";
                enemySpeed = 4;
            }
            if (score >= 30000)
            {
                gameLevel = 5;
                lblGameLevel.Text = "LVL EXPERT";
                enemySpeed = 5;
            }
            if (score >= 40000)
            {
                gameLevel = 6;
                lblGameLevel.Text = "LVL MASTER";
                enemySpeed = 6;
            }
            if (score >= 50000)
            {
                gameLevel = 7;
                lblGameLevel.Text = "LVL CHAMPION";
                enemySpeed = 7;
            }
            if (score >= 80000)
            {
                gameLevel = 8;
                lblGameLevel.Text = "LVL INSANE";
                enemySpeed = 8;
            }
            if (score >= 99999)
            {
                gameLevel = 9;
                lblGameLevel.Text = "LVL +++++";
                enemySpeed = 9;
            }


            // ----------------------------------
            // Flytta fiender med hastighet för varje nivå
            // ----------------------------------
            enemyOne.Move(enemySpeed);
            enemyTwo.Move(enemySpeed);
            enemyThree.Move(enemySpeed);


            // ----------------------------------
            // Flytta spelare HR + VR
            // ----------------------------------

            if (moveLeft == true && player.Left > 0)
            {
                player.Left -= playerSpeed;
            }
            if (moveRight == true && player.Left < 595)
            {
                player.Left += playerSpeed;
            }


            // ----------------------------------
            // Rita om skott från spelaren
            // ----------------------------------

            if (shooting == true)
            {
                bulletSpeed = extraBulletSpeed;
                bullet.Top -= bulletSpeed;
            }
            else
            {
                bullet.Left = -300;
                bulletSpeed = 0;
            }

            // Är utanför spelet
            if (bullet.Top < -30) 
            {
                shooting = false;
            }


            // ----------------------------------
            // Om skott har träffat enemy
            // ----------------------------------

            if (bullet.Bounds.IntersectsWith(enemyOne.EnemyPictureBox.Bounds))
            {
                score += 100; // Uppdatera poäng               
                shooting = false; // Ta bort skott
                enemyOne.ShowExplosion(); // Visa explosionen
                await Task.Delay(700); // vänta 0,7 second
                enemyOne.EnemyPictureBox.Image = Resources.enemy_ship1; // Byt tillbaka bild
                enemyOne.Reset(); // Nollställ fiende

            }

            if (bullet.Bounds.IntersectsWith(enemyTwo.EnemyPictureBox.Bounds))
            {
                score += 300;                
                shooting = false;
                enemyTwo.ShowExplosion();
                await Task.Delay(700);
                enemyTwo.EnemyPictureBox.Image = Resources.enemy_ship2;
                enemyTwo.Reset();

            }

            if (bullet.Bounds.IntersectsWith(enemyThree.EnemyPictureBox.Bounds))
            {
                score += 500;
                shooting = false;
                enemyThree.ShowExplosion();
                await Task.Delay(700); 
                enemyThree.EnemyPictureBox.Image = Resources.enemy_ship3;
                enemyThree.Reset();
            }

            // ----------------------------------
            // Spelaren träffas av enemy ta bort ett liv
            // ----------------------------------
            if (player.Bounds.IntersectsWith(enemyOne.EnemyPictureBox.Bounds))
            {
                enemyOne.ShowExplosion(); // Visa explosionen
                FlashGameScreen(); // visa röd skärm
                await Task.Delay(700); // vänta 0,7sek
                enemyOne.EnemyPictureBox.Image = Resources.enemy_ship1; // Byt tillbaka bild
                enemyOne.Reset(); // Nollställ fiende
                newPlayer.RemoveLife(); // räkna av ett liv från spelaren

            }
            else if (player.Bounds.IntersectsWith(enemyTwo.EnemyPictureBox.Bounds))
            {
                enemyTwo.ShowExplosion();
                FlashGameScreen();             
                await Task.Delay(700);
                enemyTwo.EnemyPictureBox.Image = Resources.enemy_ship2;
                enemyTwo.Reset();
                newPlayer.RemoveLife();

            }
            else if (player.Bounds.IntersectsWith(enemyThree.EnemyPictureBox.Bounds))
            {
                enemyThree.ShowExplosion();
                FlashGameScreen();             
                await Task.Delay(700);
                enemyThree.EnemyPictureBox.Image = Resources.enemy_ship3;
                enemyThree.Reset();
                newPlayer.RemoveLife();
            }

        }

        /// <summary>
        /// Nollställning av spelet
        /// </summary>
        private void resetGame()
        {
            gameOver = false;

            //Starta en ny spel timer
            timeGame.Start();

            // Rensa spelytan
            enemyOne.SetPosition(-300,-300);
            enemyTwo.SetPosition(-300, -300);
            enemyThree.SetPosition(-300, -300);
            bulletSpeed = 0;
            bullet.Left = -300;
            shooting = false;

            // Dölj info text
            lblAbout.Hide();
            lblReadHiScoreFromFile.Hide();
            lblInstructions.Hide();
            lblMenuText.Visible = false;
            lblGameLevel.Text = "LVL NEW PLAYER";

            // Läs in aktuell high score från fil
            int highScore = fileManager.ReadHighScoreFromFile(fileName).HighScore;
            lblHiScore.Text = "HI " + highScore.ToString();

            // Nollställ score och start värden för spelet
            score = 0;
            gameLevel = 1;
            enemySpeed = 2;
            lblMyScore.Text = score.ToString();

            // Skapa nya fiender
            spawnEnemies();
        }

        /// <summary>
        /// Hantering av game over
        /// public kan anropas från player också
        /// </summary>
        public void HandleGameOver()
        {
            gameOver = true;
            timeGame.Stop();

            // Ändra meny text
            lblMenuText.Show();
            lblMenuText.Text = "GAME OVER!" + Environment.NewLine + Environment.NewLine + "Press -1-  for SPEED" + Environment.NewLine + "Press -2- for POWER" + Environment.NewLine + "Press -3- for LIVES";

            // Visa info knappar
            lblReadHiScoreFromFile.Show();
            lblInstructions.Show();
            lblAbout.Show();

            // Läs in high score från fil           
            int highScore = fileManager.ReadHighScoreFromFile(fileName).HighScore;

            // Kontroll om nuvarande score är högre än den i filen
            if (score > highScore)
            {
                // ändra text till nytt high score
                lblHiScore.Text = "New High Score !!!";

                // Spara nya score
                fileManager.SaveHighScoreToFile(score, gameLevel, fileName);
            }
        }

        /// <summary>
        /// Visar röd bild över spelytan
        /// </summary>
        private async void FlashGameScreen()
        {
            picboxScreenRed.Visible = true;
            player.Visible = false; // Göm spelaren
            await Task.Delay(300); // vänta 0,3sek
            player.Visible = true; // visa spelare
            picboxScreenRed.Visible = false; // göm röd bild
        }



        // ----------------------------------
        // MessageBox med lite info om spelet
        // ----------------------------------

        /// <summary>
        /// About - info
        /// </summary>
        private void lblAbout_Click(object sender, EventArgs e)
        {
            string author = "Alexander Tofer";
            string version = "1.1";
            DateTime date = new DateTime(2023, 6, 9);
            string gameArtSource = "https://ansimuz.itch.io/star-fighter";

            string message = $"Author: {author}\n" +
                             $"Version: {version}\n" +
                             $"Date: {date.ToShortDateString()}\n" +
                             $"Game Art from : {gameArtSource}";

            message = message.Replace("\n", Environment.NewLine); // Replace \n with new lines

            MessageBox.Show(message, "About...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Spel instruktioner
        /// </summary>
        private void lblInstructions_Click(object sender, EventArgs e)
        {
            string instructions = "GAME INSTRUCTIONS" + Environment.NewLine + Environment.NewLine +
                                   "Move your ship using the LEFT and RIGHT arrow keys." + Environment.NewLine +
                                   "Press the SPACE BAR to shoot and destroy enemies." + Environment.NewLine + Environment.NewLine +
                                   "Get the highest score possible by shooting down enemies." + Environment.NewLine +
                                   "Avoid the enemy hitting your ship." + Environment.NewLine + Environment.NewLine +
                                   "Good luck and have fun!";

            MessageBox.Show(instructions, "Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Visar high score med datum
        /// </summary>
        private void lblHi_Click(object sender, EventArgs e)
        {
            FileManager fileManager = new FileManager();

            int highScore = fileManager.ReadHighScoreFromFile(fileName).HighScore;
            int gameLevel = fileManager.ReadHighScoreFromFile(fileName).GameLevel;
            DateTime highScoreDate = fileManager.ReadHighScoreFromFile(fileName).Date;

            string message = $"HIGH SCORE\n{highScore}\n\n" +
                             $"LEVEL\n{gameLevel}\n\n" +
                             $"DATE: {highScoreDate}";

            MessageBox.Show(message, "High Score", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }

}
