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
    /// The purpose of this class is to provide the user with a method of entering in character guesses for the game.
    /// It controls the character select canvas and populates it with buttons which it monitors.
    /// </summary>
    class CharacterSelect
    {

        const int ButtonWidth = 25;
        const int ButtonHeight = 25;

        //used for button layout later.
        const int PerButtonOffset = 27;

        public int NumberOfButtons { get; set; }

        List<CustomButton> CharacterButtons { get; set; }

        public Canvas canvas { get; private set; }

        //This reference is used to send character selection information to the UnknownPhrase so
        //that it can check the selected character against the phrase. 
        public UnknownPhrase phrase { get; set; }

        public CharacterSelect()
        {
            NumberOfButtons = 0;
            CharacterButtons = new List<CustomButton>();

            Border border = new Border();
            border.BorderThickness = new Thickness(4);
            border.BorderBrush = Brushes.Black;
            border.Height = 100;
            border.Width = 280;
            border.CornerRadius = new CornerRadius(3);

            canvas = new Canvas();
            canvas.Height = 100;
            canvas.Width = 280;
            canvas.Background = Brushes.AliceBlue;
            Canvas.SetLeft(canvas, 50);
            Canvas.SetTop(canvas, 395);
            canvas.Children.Add(border);

        }

        /// <summary>
        /// Adds a button to the character select object by creating and positioning it on the canvas.
        /// The maximum number of buttons that can be added is 30.
        /// </summary>
        /// <param name="character">The character to add</param>
        public void AddCharacter(string character)
        {
            CustomButton newButton = new CustomButton();
            newButton.Width = ButtonWidth;
            newButton.Height = ButtonHeight;
            newButton.SetText(character);
            newButton.TextLabel.FontSize = 12;
            newButton.TextLabel.FontWeight = FontWeights.Light;
            newButton.BorderThickness = new Thickness(2);
            newButton.BackgroundColourBase = Brushes.White;
            newButton.BackgroundColourHover = Brushes.DarkOrange;

            double xOffset = 5;
            double yOffset = 7;

            if (CharacterButtons.Count < 10)
            {
                xOffset += CharacterButtons.Count * PerButtonOffset;
                xOffset += CenteringOffset();
                yOffset += 0;
            }
            else if (CharacterButtons.Count < 20)
            {
                xOffset += (CharacterButtons.Count - 10) * PerButtonOffset;
                xOffset += CenteringOffset();
                yOffset += 30;
            }
            else if (CharacterButtons.Count < 30)
            {
                xOffset += (CharacterButtons.Count - 20) * PerButtonOffset;
                xOffset += CenteringOffset();
                yOffset += 60;
            }

            Canvas.SetLeft(newButton, xOffset);
            Canvas.SetTop(newButton, yOffset);

            canvas.Children.Add(newButton);

            CharacterButtons.Add(newButton);

            newButton.MouseUp += CharacterButtonPress;
            newButton.MouseEnter += OnMouseOverButton;


        }


        /// <summary>
        /// Adds a complete character set to the canvas.
        /// </summary>
        public void AddCharacterSet()
        {
            NumberOfButtons = LocalisationAssets.CharacterSet.Length;

            foreach (char c in LocalisationAssets.CharacterSet)
            {
                AddCharacter(c.ToString().ToUpper());
            }

        }

        /// <summary>
        /// Removes the specified character from the canvas
        /// </summary>
        /// <param name="character"></param>
        public void RemoveCharacter(string character)
        {
            if (CharacterButtons.Count != 0)
            {
                foreach (CustomButton b in CharacterButtons)
                {
                    if (b.TextLabel.Content.ToString() == character)
                    {
                        canvas.Children.Remove(b);
                        CharacterButtons.Remove(b);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Completely removes all buttons from the canvas.
        /// </summary>
        public void RemoveAll()
        {
            if (CharacterButtons.Count != 0)
            {
                foreach (CustomButton b in CharacterButtons)
                {
                    canvas.Children.Remove(b);
                }
                CharacterButtons.Clear();
            }

            NumberOfButtons = 0;
        }

        /// <summary>
        /// Restores the Character Select to its starting state.
        /// </summary>
        public void Reset()
        {
            RemoveAll();
            AddCharacterSet();
        }

        //Called when one of the character buttons is pressed.
        public void CharacterButtonPress(object sender, RoutedEventArgs e)
        {
            string character;
            foreach (CustomButton b in CharacterButtons)
            {
                if (b.Equals(sender))
                {
                    character = b.TextLabel.Content.ToString();
                    if (phrase != null)
                    {
                        phrase.GuessCharacter(character);
                    }
                    RemoveCharacter(character);

                    break;

                }
            }
        }

        //Play a noise when a button is hovered over.
        public void OnMouseOverButton(object sender, RoutedEventArgs e)
        {
            SharedAssets.SelectSound.Stop();
            SharedAssets.PlaySound(SharedAssets.SelectSound);
        }

        /// <summary>
        /// private function that provides an offset to center the last line of the character buttons.
        /// </summary>
        /// <returns>The offset required to center the current line.</returns>
        private double CenteringOffset()
        {
            if ((NumberOfButtons - CharacterButtons.Count) <= (NumberOfButtons % 10))
            {
                double lastLineOffset = ((NumberOfButtons % 10) / 2) - 1;
                lastLineOffset *= PerButtonOffset;

                return lastLineOffset;
            }

            return 0;
        }


    }
}
