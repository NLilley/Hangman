using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;

namespace Hangman
{

    /// <summary>
    /// This static class maintains some of the important data required to run the game.
    /// It also provides methods which modify the state of the game.
    /// </summary>
    static class GameState
    {
        public enum GameDifficulty { Easy, Medium, Hard };

        public const int MaxGuesses = 12;

        static string dictionaryLocation { get; set; }

        public static int Guesses { get; set; }
        public static string GamePhrase { get; set; }
        public static GameDifficulty Difficulty { get; set; }


        //Static references to the various screens used during the game.
        public static StartScreen StartScreen { get; set; }
        public static GameScreen GameScreen { get; set; }
        public static WinScreen WinScreen { get; set; }
        public static LoseScreen LoseScreen { get; set; }
        public static OptionsScreen OptionsScreen { get; set; }
        public static CreditsScreen CreditsScreen { get; set; }


        static GameState()
        {
            Difficulty = GameDifficulty.Medium;
            ResetGame();
        }

        public static void ResetGame()
        {
            GetNewGamePhrase(Difficulty);
            Guesses = 0;
        }

        public static void ResetGame(GameDifficulty d)
        {
            GetNewGamePhrase(d);
            Guesses = 0;
        }

        public static void ResetScreens()
        {
            StartScreen.Reset();
            GameScreen.Reset();
            WinScreen.Reset();
            LoseScreen.Reset();
            OptionsScreen.Reset();
            CreditsScreen.Reset();
        }

        /// <summary>
        /// Retrieves a new game phrase randomly from an appropriate source.
        /// </summary>
        private static void GetNewGamePhrase(GameDifficulty d)
        {
            try
            {
                if (d == GameDifficulty.Easy)
                {
                    dictionaryLocation = LocalisationAssets.EasyDictionary;
                    Difficulty = GameDifficulty.Easy;
                }
                else if (d == GameDifficulty.Medium)
                {
                    dictionaryLocation = LocalisationAssets.MediumDictionary;
                    Difficulty = GameDifficulty.Medium;
                }
                else if (d == GameDifficulty.Hard)
                {
                    dictionaryLocation = LocalisationAssets.HardDictionary;
                    Difficulty = GameDifficulty.Hard;
                }

                int noLines = System.IO.File.ReadAllLines(dictionaryLocation).Count();

                Random rnd = new Random();
                int wordChoice = rnd.Next(0, noLines);

                GamePhrase = File.ReadLines(dictionaryLocation).Skip(wordChoice).Take(1).First();

            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem reading the GamePhrase: " + e.Message);
            }

        }

    }
}