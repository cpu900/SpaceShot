using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;

namespace SpaceShot
{
    /// <summary>
    /// Author: Alexander Tofer
    /// Assignment 7 @ mau.se
    /// Version: 2
    /// Date: 2023-06-09
    /// </summary>
    internal class FileManager
    {
        // Ändra om ny version
        private const string fileVersionToken = "SSPACE_VER";
        private const double fileVersionNr = 1.6;

        public class HighScoreData
        {
            public int HighScore { get; set; }
            public int GameLevel { get; set; }
            public DateTime Date { get; set; }
        }

        /// <summary>
        /// Skriver till fil med score + tid för skrivning
        /// </summary>
        /// <param name="highScore">score att spara</param>
        /// <param name="fileName">sökväg till filen</param>
        /// <returns></returns>
        public bool SaveHighScoreToFile(int highScore, int gameLevel, string fileName)
        {
            bool ok = true;
            StreamWriter writer = null;
            try
            {
                // Kontroll om score är högre än det som finns sparat 
                HighScoreData highScoreData = ReadHighScoreFromFile(fileName);
                int existingHighScore = highScoreData.HighScore;

                if (highScore > existingHighScore)
                {
                    writer = new StreamWriter(fileName);
                    writer.WriteLine(fileVersionToken);
                    writer.WriteLine(fileVersionNr);
                    writer.WriteLine(highScore);
                    writer.WriteLine(gameLevel);
                    writer.WriteLine(DateTime.Now.ToString()); // Spara även aktuell tid
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("FELMEDDELANDE för skriva fil! -- " + e.Message);
                ok = false;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
            return ok;
        }

        /// <summary>
        /// Läser från fil
        /// </summary>
        /// <param name="fileName">sökväg till filen</param>
        /// <returns>objekt med HighScoreData</returns>
        public HighScoreData ReadHighScoreFromFile(string fileName)
        {
            HighScoreData highScoreData = new HighScoreData();

            try
            {
                if (File.Exists(fileName))
                {
                    using (StreamReader reader = new StreamReader(fileName))
                    {
                        string versionTest = reader.ReadLine();
                        string versionStr = reader.ReadLine();
                        double version = Convert.ToDouble(versionStr);
                        if ((versionTest == fileVersionToken) && (version == fileVersionNr)) // Kontroll av version + token
                        {
                            string highScoreStr = reader.ReadLine();
                            highScoreData.HighScore = int.Parse(highScoreStr);

                            string gameLevelStr = reader.ReadLine();
                            highScoreData.GameLevel = int.Parse(gameLevelStr);

                            string dateStr = reader.ReadLine();
                            highScoreData.Date = DateTime.ParseExact(dateStr, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        }
                        else // Felaktigt format på fil
                        {
                            Console.WriteLine("Incompatible file version or invalid format for the HighScoreData file."); // För felsökning
                            highScoreData.HighScore = 999999;
                            highScoreData.Date = DateTime.Now;
                        }
                    }
                }
                else // ingen fil finns - skapa en ny
                {
                    highScoreData.HighScore = 1000;
                    highScoreData.GameLevel = 1;
                    highScoreData.Date = DateTime.Now;

                    using (StreamWriter writer = new StreamWriter(fileName))
                    {
                        writer.WriteLine(fileVersionToken);
                        writer.WriteLine(fileVersionNr);
                        writer.WriteLine(highScoreData.HighScore);
                        writer.WriteLine(highScoreData.GameLevel);
                        writer.WriteLine(highScoreData.Date.ToString("yyyy-MM-dd HH:mm:ss"));
                        writer.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("FELMEDDELANDE för läsa/skriva fil! -- " + e.Message); // Övriga fel loggas till terminalen
            }

            return highScoreData;
        }

    }
}
