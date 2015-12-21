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
    /// This screen is displayed in the event of the user losing the game.
    /// </summary>
    class LoseScreen : IScreen
    {
        Canvas LoseCanvas { get; set; }

        Image Noose { get; set; }
        Image Star { get; set; }

        Label LoseLabel;

        CustomButton MainMenuButton { get; set; }
        CustomButton PlayAgainButton { get; set; }
        CustomButton StarButton { get; set; }

        public LoseScreen(Canvas LoseCanvas)
        {
            this.LoseCanvas = LoseCanvas;

            Noose = new Image();
            Noose.Source = SharedAssets.Noose;
            Canvas.SetLeft(Noose, 140);
            Canvas.SetTop(Noose, 120);
            Noose.Width = 100;
            Noose.Height = 300;
            LoseCanvas.Children.Add(Noose);

            Star = new Image();
            Star.Source = SharedAssets.Star;

            LoseLabel = new Label();
            LoseLabel.FontSize = 48;
            LoseLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            Canvas.SetTop(LoseLabel, 40);
            Canvas.SetLeft(LoseLabel, 20);
            LoseLabel.Content = LocalisationAssets.YouLoseString;
            LoseLabel.Width = 340;
            LoseCanvas.Children.Add(LoseLabel);

            MainMenuButton = new CustomButton();
            MainMenuButton.SetText(LocalisationAssets.MenuString);
            MainMenuButton.LeftOffset(130);
            MainMenuButton.TopOffset(490);
            MainMenuButton.Width = 120;
            MainMenuButton.BackgroundColourHover = Brushes.DarkBlue;
            MainMenuButton.TextColourHover = Brushes.White;
            MainMenuButton.MouseUpActions += MainMenuButtonActions;
            LoseCanvas.Children.Add(MainMenuButton);

            PlayAgainButton = new CustomButton();
            PlayAgainButton.SetText(LocalisationAssets.ReplayString);
            PlayAgainButton.LeftOffset(130);
            PlayAgainButton.TopOffset(445);
            PlayAgainButton.Width = 120;
            PlayAgainButton.BackgroundColourHover = Brushes.Orange;
            PlayAgainButton.MouseUpActions += PlayAgainButtonActions;
            LoseCanvas.Children.Add(PlayAgainButton);

            StarButton = new CustomButton();
            StarButton.TextLabel.Content = Star;
            StarButton.Width = 40;
            StarButton.LeftOffset(255);
            StarButton.TopOffset(445);
            StarButton.BackgroundColourHover = Brushes.Gold;
            StarButton.MouseUpActions += StarButtonActions;
            LoseCanvas.Children.Add(StarButton);
        }

        public void MainMenuButtonActions()
        {
            GameState.LoseScreen.Hide();
            GameState.StartScreen.Show();
        }

        //Starts another game of the same difficulty.
        public void PlayAgainButtonActions()
        {
            GameState.GameScreen.Reset();
            GameState.LoseScreen.Hide();
            GameState.GameScreen.Show();
        }

        //Opens up a web browser linked directly to the wiktionary page for the finsihed game's word.
        public void StarButtonActions()
        {
            System.Diagnostics.Process.Start("www.wiktionary.org/wiki/" + GameState.GamePhrase.ToLower());
        }

        public void Show()
        {
            LoseCanvas.Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            LoseCanvas.Visibility = Visibility.Hidden;
        }

        public void Reset()
        {
            LoseLabel.Content = LocalisationAssets.YouLoseString;
            PlayAgainButton.SetText(LocalisationAssets.ReplayString);
            MainMenuButton.SetText(LocalisationAssets.MenuString);
        }
    }
}
