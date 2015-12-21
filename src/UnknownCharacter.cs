using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Hangman
{
    /// <summary>
    /// This class is used to create characters in the UnknownPhrase object.
    /// When the character is unknown it is presented as a line and when it
    /// is discovered it is presented as the character of the word.
    /// </summary>
    class UnknownCharacter
    {
        //Used to control the size of the character marks.
        private const double lineWidth = 18;

        string character { get; set; }

        //The spot which a character will replace when it has been correctly guessed.
        Line Mark { get; set; }
        //The label which will present the character to the user once it has been guessed correctly.
        Label Label { get; set; }

        //used to control the state of the individual character
        public bool IsKnown { private set; get; }
        public bool IsShown { private set; get; }


        public UnknownCharacter(string character)
        {
            this.character = character;

            IsKnown = false;
            IsShown = true;

            Mark = new Line();

            Mark.X1 = 5;
            Mark.X2 = lineWidth;
            Mark.Y1 = 30;
            Mark.Y2 = 30;
            Mark.Stroke = Brushes.Black;
            Mark.StrokeThickness = 4;

            Mark.Visibility = Visibility.Visible;

            Label = new Label();
            Label.Content = this.character;
            Label.Visibility = Visibility.Hidden;
            Label.Width = lineWidth + 15;
            Label.FontSize = 18;
            Label.FontFamily = new FontFamily("Arial Black");
        }

        /// <summary>
        /// This function checks the guess tring against the content of the UnknownCharacter.
        /// If the guess is correct it instructs the UnknownCharacter to display its
        /// Character.
        /// </summary>
        /// <param name="guess"></param>
        /// <returns>true if the guess is correct, false otherwise.</returns>
        public bool GuessCharacter(string guess)
        {
            if (guess == character)
            {
                Mark.Visibility = Visibility.Hidden;
                Label.Visibility = Visibility.Visible;

                IsKnown = true;
                return true;

            }
            else
            {
                return false;
            }
        }

        //Adds the character to the specified canvas.
        public void AddToCanvas(Canvas c)
        {
            c.Children.Add(Mark);
            c.Children.Add(Label);
        }

        //Removes the character from the specified canvas
        public void RemoveFromCanvas(Canvas c)
        {
            if (c.Children.Contains(Mark))
            {
                c.Children.Remove(Mark);
            }

            if (c.Children.Contains(Label))
            {
                c.Children.Remove(Label);
            }
        }

        //hide the character
        public void Hide()
        {
            Mark.Visibility = Visibility.Hidden;
            Label.Visibility = Visibility.Hidden;

            IsShown = false;
        }

        //SHow the character
        public void Show()
        {
            if (IsKnown == true)
            {
                Mark.Visibility = Visibility.Hidden;
                Label.Visibility = Visibility.Visible;

            }
            else
            {
                Mark.Visibility = Visibility.Visible;
                Label.Visibility = Visibility.Hidden;
            }

            IsShown = true;
        }

        /// <summary>
        /// Positions the character within the canvas, creating an offset from the left.
        /// </summary>
        /// <param name="offset">The number of pixels to offset from the left.</param>
        public void LeftOffset(double offset)
        {
            Canvas.SetLeft(Mark, offset);
            Canvas.SetLeft(Label, offset);
        }

        /// <summary>
        /// Positions the character withing the canvas, creating an offset from the top.
        /// </summary>
        /// <param name="offset">The number of pixels to offset from the top.</param>
        public void TopOffset(double offset)
        {
            Canvas.SetTop(Mark, offset);
            Canvas.SetTop(Label, offset);
        }





    }
}
