using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Hangman
{
    /// <summary>
    /// This screen where the majority of the game draws its functionality.
    /// This screen contains the Character select, the Phrase displayer(UnknownPhrase)
    /// and the hangman itself.
    /// </summary>
    class GameScreen : IScreen
    {
        //All of the controls used by the GameScreen to provide the UI
        Canvas GameCanvas { get; set; }
        Label UsedCharacterLabel { get; set; }
        CharacterSelect Characters { get; set; }
        UnknownPhrase Phrase { get; set; }
        Man Man { get; set; }
        Image HangmanTitle { get; set; }

        public GameScreen(Canvas GameCanvas, Canvas ManCanvas)
        {

            //<Label x:Name="UsedCharacterLabel" Canvas.Left="57" Canvas.Top="500" Width="280"/>

            this.GameCanvas = GameCanvas;

            UsedCharacterLabel = new Label();
            UsedCharacterLabel.Width = 280;
            Canvas.SetLeft(UsedCharacterLabel, 57);
            Canvas.SetTop(UsedCharacterLabel, 500);
            GameCanvas.Children.Add(UsedCharacterLabel);


            UsedCharacterLabel.FontSize = 16;
            UsedCharacterLabel.FontWeight = FontWeights.Bold;

            Phrase = new UnknownPhrase(this);
            Phrase.AddToCanvas(GameCanvas);
            Phrase.TopOffset(320);
            Phrase.LeftOffset(57);

            Characters = new CharacterSelect();
            Characters.phrase = Phrase;
            GameCanvas.Children.Add(Characters.canvas);

            Man = new Man(ManCanvas);

            Characters.AddCharacterSet();

            HangmanTitle = new Image();
            HangmanTitle.Source = SharedAssets.HangmanTitle;
            Canvas.SetLeft(HangmanTitle, 40);
            Canvas.SetTop(HangmanTitle, 20);
            HangmanTitle.Width = 300;
            HangmanTitle.Height = 100;
            GameCanvas.Children.Add(HangmanTitle);

        }

        /// <summary>
        /// Set the game up so that its playable, and then show the gamescreen.
        /// </summary>
        public void Setup()
        {
            Reset();

            Show();
        }

        /// <summary>
        /// This functiomn is called in when the user selects an incorrect character.
        /// It plays a sound and then updates the man and game state.
        /// </summary>
        public void GuessIncorrectly(string character)
        {
            AddCharacterToLabel(character);

            SharedAssets.MistakeSound.Stop();
            SharedAssets.PlaySound(SharedAssets.MistakeSound);


            if (IsGameLost())
            {
                LoseGame();
            }
            else
            {
                Man.AddNextPeice();
                GameState.Guesses++;
            }

        }

        /// <summary>
        /// This function is called when the user selects a correct character.
        /// After playing a sound it checks to see if the game is won.
        /// </summary>
        public void GuessCorrectly(string character)
        {
            AddCharacterToLabel(character);

            SharedAssets.CorrectSound.Stop();
            SharedAssets.PlaySound(SharedAssets.CorrectSound);

            if (IsGameWon())
            {
                WinGame();
            }
        }

        public bool IsGameWon()
        {
            if (Phrase.PhraseGuessed())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsGameLost()
        {
            if (GameState.Guesses >= GameState.MaxGuesses - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Called when the game has been won.
        /// </summary>
        public void WinGame()
        {
            Hide();
            GameState.WinScreen.Show();

            SharedAssets.PlaySound(SharedAssets.WinSound);

        }

        /// <summary>
        /// Called when the game has been lost.
        /// </summary>
        public void LoseGame()
        {
            Hide();
            GameState.LoseScreen.Show();

            SharedAssets.PlaySound(SharedAssets.LoseSound);
        }

        public void AddCharacterToLabel(string character)
        {
            UsedCharacterLabel.Content += character + " ";
        }

        public void Hide()
        {
            GameCanvas.Visibility = Visibility.Hidden;
        }

        public void Show()
        {
            Reset();
            GameCanvas.Visibility = Visibility.Visible;
        }

        public void Reset()
        {
            GameState.ResetGame();
            Man.Reset();
            Phrase.Reset();
            Characters.Reset();
            UsedCharacterLabel.Content = "";

        }


    }
}
