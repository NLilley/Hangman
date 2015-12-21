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
    /// This class provides the features for the CreditsScreen accessible from the start screen.
    /// </summary>
    class CreditsScreen : IScreen
    {
        Canvas CreditsCanvas { get; set; }
        CustomButton BackButton { get; set; }
        CustomButton ClickMeButton { get; set; }
        Image Star { get; set; }

        public CreditsScreen(Canvas CreditsCanvas)
        {
            this.CreditsCanvas = CreditsCanvas;

            Star = new Image();
            Star.Source = SharedAssets.Star;

            BackButton = new CustomButton();
            BackButton.SetText(LocalisationAssets.MenuString);
            BackButton.Width = 160;
            BackButton.LeftOffset(120);
            BackButton.TopOffset(502);
            BackButton.BackgroundColourHover = Brushes.DarkBlue;
            BackButton.TextColourHover = Brushes.White;
            BackButton.MouseUpActions += BackButtonActions;
            CreditsCanvas.Children.Add(BackButton);

            ClickMeButton = new CustomButton();
            ClickMeButton.TextLabel.Content = Star;
            ClickMeButton.Width = 120;
            ClickMeButton.LeftOffset(140);
            ClickMeButton.TopOffset(200);
            ClickMeButton.BackgroundColourHover = Brushes.Gold;
            ClickMeButton.MouseUpActions += ClickMeButtonActions;
            CreditsCanvas.Children.Add(ClickMeButton);

        }

        //Return to the menu
        public void BackButtonActions()
        {
            Hide();
            GameState.StartScreen.Show();
        }

        //When the star is clicked, the users base browser will pop up and link to the github repo for the project.
        public void ClickMeButtonActions()
        {
            System.Diagnostics.Process.Start("https://github.com/NLilley/General-Projects/tree/master/Hangman");
        }

        public void Show()
        {
            CreditsCanvas.Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            CreditsCanvas.Visibility = Visibility.Hidden;
        }

        public void Reset()
        {
            BackButton.SetText(LocalisationAssets.MenuString);
        }
    }
}
