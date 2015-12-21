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
    /// This screen is displayed when in the event of the user winning the game.
    /// </summary>
    class WinScreen : IScreen
    {

        Canvas WinCanvas { get; set; }

        Image Happy { get; set; }
        Image Star { get; set; }

        Label WinLabel { get; set; }

        CustomButton MainMenuButton { get; set; }
        CustomButton PlayAgainButton { get; set; }
        CustomButton StarButton { get; set; }

        public WinScreen(Canvas WinCanvas)
        {
            this.WinCanvas = WinCanvas;

            Happy = new Image();
            Happy.Source = SharedAssets.Happy;
            Canvas.SetLeft(Happy, 95);
            Canvas.SetTop(Happy, 200);
            Happy.Width = 200;
            Happy.Height = 133;
            WinCanvas.Children.Add(Happy);

            Star = new Image();
            Star.Source = SharedAssets.Star;

            WinLabel = new Label();
            WinLabel.FontSize = 48;
            Canvas.SetTop(WinLabel, 40);
            Canvas.SetLeft(WinLabel, 20);
            WinLabel.Content = LocalisationAssets.YouWinString;
            WinLabel.Width = 340;
            WinLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            WinCanvas.Children.Add(WinLabel);

            MainMenuButton = new CustomButton();
            MainMenuButton.SetText(LocalisationAssets.MenuString);
            MainMenuButton.LeftOffset(130);
            MainMenuButton.TopOffset(490);
            MainMenuButton.Width = 120;
            MainMenuButton.BackgroundColourHover = Brushes.DarkBlue;
            MainMenuButton.TextColourHover = Brushes.White;
            MainMenuButton.MouseUpActions += MainMenuButtonActions;
            WinCanvas.Children.Add(MainMenuButton);

            PlayAgainButton = new CustomButton();
            PlayAgainButton.SetText(LocalisationAssets.ReplayString);
            PlayAgainButton.LeftOffset(130);
            PlayAgainButton.TopOffset(445);
            PlayAgainButton.Width = 120;
            PlayAgainButton.BackgroundColourHover = Brushes.Orange;
            PlayAgainButton.MouseUpActions += PlayAgainButtonActions;
            WinCanvas.Children.Add(PlayAgainButton);

            StarButton = new CustomButton();
            StarButton.TextLabel.Content = Star;
            StarButton.Width = 40;
            StarButton.LeftOffset(255);
            StarButton.TopOffset(445);
            StarButton.BackgroundColourHover = Brushes.Gold;
            StarButton.MouseUpActions += StarButtonActions;
            WinCanvas.Children.Add(StarButton);

        }

        public void MainMenuButtonActions()
        {
            GameState.WinScreen.Hide();
            GameState.StartScreen.Show();
        }

        //Starts another game of the same difficulty.
        public void PlayAgainButtonActions()
        {
            GameState.GameScreen.Reset();
            GameState.WinScreen.Hide();
            GameState.GameScreen.Show();
        }

        //Opens up a web browser linked directly to the wiktionary page for the finsihed game's word.
        public void StarButtonActions()
        {
            System.Diagnostics.Process.Start("www.wiktionary.org/wiki/" + GameState.GamePhrase);
        }

        public void Show()
        {
            WinCanvas.Visibility = Visibility.Visible;

        }

        public void Hide()
        {
            WinCanvas.Visibility = Visibility.Hidden;
        }

        public void Reset()
        {
            WinLabel.Content = LocalisationAssets.YouWinString;
            PlayAgainButton.SetText(LocalisationAssets.ReplayString);
            MainMenuButton.SetText(LocalisationAssets.MenuString);
        }
    }
}
