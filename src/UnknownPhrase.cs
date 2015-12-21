using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Hangman
{
    /// <summary>
    /// This class presents the Unknown Phrase which the user needs to guess.
    /// It contains a mark for every letter of the Phrase.
    /// </summary>
    class UnknownPhrase
    {
        const double CanvasWidth = 340;
        const double CanvasHeight = 60;

        List<UnknownCharacter> Characters { get; set; }
        GameScreen GameScreen { get; set; }

        public Canvas PhraseCanvas { get; set; }
        public bool IsShown { get; private set; }

        public UnknownPhrase(GameScreen GameScreen)
        {
            this.GameScreen = GameScreen;

            PhraseCanvas = new Canvas();
            PhraseCanvas.Width = CanvasWidth;
            PhraseCanvas.Height = CanvasHeight;
            
            Characters = new List<UnknownCharacter>();

        }

        /// <summary>
        /// Takes the parameter phrase and builds the UnknownPhrase object from it.
        /// </summary>
        /// <param name="phrase">The phrase to be turned into the game phrase.</param>
        public void SetPhrase(string phrase)
        {
            string upperPhrase = phrase.ToUpper();
            string characterSet = LocalisationAssets.CharacterSet.ToUpper();

            foreach (char c in upperPhrase)
            {
                if (characterSet.Contains(c))
                {
                    Characters.Add(new UnknownCharacter(c.ToString()));
                }
            }

            //Use this offset to make sure the phrase appears in the middle of the screen.
            int offset = 130 - (10 * Characters.Count);

            int position = 0;

            foreach (UnknownCharacter c in Characters)
            {
                c.AddToCanvas(PhraseCanvas);
                c.LeftOffset(offset + (position * 20));
                position++;

            }
        }

        /// <summary>
        /// Clears the current UnknownPhrase object and constructs another from the static GameState.GamePhrase
        /// </summary>
        public void Reset()
        {
            //Clean up the old phrase by removing objects from canvas and removing references to them
            foreach (UnknownCharacter c in Characters)
            {
                c.RemoveFromCanvas(PhraseCanvas);
            }

            Characters.Clear();

            SetPhrase(GameState.GamePhrase);

        }

        /// <summary>
        /// Checks every UnknownCharacter against the input character.
        /// If there are no matches it calls the GameScreen to register an 
        /// incorrect answer.  Otherwise it registers a correct answer
        /// and chagnes state accordingly.
        /// </summary>
        /// <param name="character">The character guessed.</param>
        public void GuessCharacter(String character)
        {


            int numberOfMatches = 0;
            foreach (UnknownCharacter c in Characters)
            {

                if (c.GuessCharacter(character) == true)
                {
                    numberOfMatches++;
                }
            }

            if (numberOfMatches == 0)
            {
                GameScreen.GuessIncorrectly(character);
            }
            else
            {
                GameScreen.GuessCorrectly(character);
            }
        }

        /// <summary>
        /// Returns true if the phrase has been completely revealed. Otherwise, it returns false.
        /// </summary>
        /// <returns></returns>
        public bool PhraseGuessed()
        {
            foreach (UnknownCharacter c in Characters)
            {
                if (c.IsKnown == false)
                {
                    return false;
                }
            }
            return true;
        }

        public void ShowPhrase()
        {
            PhraseCanvas.Visibility = Visibility.Visible;
            IsShown = true;

        }

        public void HidePhrase()
        {
            PhraseCanvas.Visibility = Visibility.Hidden;
            IsShown = false;
        }

        public void AddToCanvas(Canvas c)
        {
            c.Children.Add(PhraseCanvas);
        }

        public void RemoveFromCanvas(Canvas c)
        {
            if (c.Children.Contains(PhraseCanvas))
            {
                c.Children.Remove(PhraseCanvas);
            }
        }

        public void TopOffset(double offset)
        {
            Canvas.SetTop(PhraseCanvas, offset);
        }

        public void LeftOffset(double offset)
        {
            Canvas.SetLeft(PhraseCanvas, offset);
        }

    }
}
