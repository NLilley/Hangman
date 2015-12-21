using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hangman
{
    /// <summary>
    /// This class is responsible for the hangman man used to represent the number of incorrect guesses the user has made.
    /// </summary>
    class Man
    {
        Canvas ManCanvas;

        Image Cautious { get; set; }
        Image Upset { get; set; }
        Image Tearful { get; set; }

        public Man(Canvas ManCanvas)
        {
            this.ManCanvas = ManCanvas;

            Cautious = new Image();
            Cautious.Source = SharedAssets.Cautious;
            Canvas.SetLeft(Cautious, 126);
            Canvas.SetTop(Cautious, 67);
            Cautious.Width = 40;
            Cautious.Height = 40;

            Upset = new Image();
            Upset.Source = SharedAssets.Upset;
            Canvas.SetLeft(Upset, 126);
            Canvas.SetTop(Upset, 67);
            Upset.Width = 40;
            Upset.Height = 40;

            Tearful = new Image();
            Tearful.Source = SharedAssets.Tearful;
            Canvas.SetLeft(Tearful, 126);
            Canvas.SetTop(Tearful, 67);
            Tearful.Width = 40;
            Tearful.Height = 40;

            //These elements will be added to the end of the canvas' child collection.
            ManCanvas.Children.Add(Cautious);
            ManCanvas.Children.Add(Upset);
            ManCanvas.Children.Add(Tearful);


        }

        /// <summary>
        /// Reset the man object so that no hangman peices can be seen.
        /// </summary>
        public void Reset()
        {
            for (int i = 0; i < ManCanvas.Children.Count; i++)
            {
                ManCanvas.Children[i].Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Adds the next peice of the man to the game board.
        /// </summary>
        public void AddNextPeice()
        {
            ManCanvas.Children[GameState.Guesses].Visibility = Visibility.Visible;

            if (GameState.Guesses == 6)
            {
                Cautious.Visibility = Visibility.Visible;
            }
            else if (GameState.Guesses == 8)
            {
                Cautious.Visibility = Visibility.Hidden;
                Upset.Visibility = Visibility.Visible;
            }
            else if (GameState.Guesses == 10)
            {
                Upset.Visibility = Visibility.Hidden;
                Tearful.Visibility = Visibility.Visible;
            }
        }
    }
}
