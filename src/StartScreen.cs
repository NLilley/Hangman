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
    /// This class sets up the GUI for the main menu of the program.  It contains buttons which provide access
    /// to the entire functionality of the application.
    /// </summary>
    class StartScreen : IScreen
    {
        Canvas StartCanvas;

        Image HangmanTitle { get; set; }
        Image Gallow { get; set; }

        CustomButton EasyGameButton { get; set; }
        CustomButton MediumGameButton { get; set; }
        CustomButton HardGameButton { get; set; }
        CustomButton OptionsButton { get; set; }
        CustomButton CreditsButton { get; set; }

        public StartScreen(Canvas StartCanvas)
        {
            this.StartCanvas = StartCanvas;

            //Setup the images used for the start canvas.
            HangmanTitle = new Image();
            HangmanTitle.Source = SharedAssets.HangmanTitle;
            Canvas.SetLeft(HangmanTitle, 40);
            Canvas.SetTop(HangmanTitle, 20);
            HangmanTitle.Width = 300;
            HangmanTitle.Height = 100;
            StartCanvas.Children.Add(HangmanTitle);

            Gallow = new Image();
            Gallow.Source = SharedAssets.Gallow;
            Canvas.SetTop(Gallow, 134);
            Canvas.SetLeft(Gallow, 80);
            Gallow.Height = 320;
            Gallow.Width = 240;
            StartCanvas.Children.Add(Gallow);

            EasyGameButton = new CustomButton();
            EasyGameButton.SetText(LocalisationAssets.EasyString);
            EasyGameButton.LeftOffset(10);
            EasyGameButton.TopOffset(460);
            EasyGameButton.Width = 120;
            EasyGameButton.BackgroundColourHover = Brushes.LimeGreen;
            EasyGameButton.MouseUpActions += EasyGameButtonActions;
            StartCanvas.Children.Add(EasyGameButton);

            MediumGameButton = new CustomButton();
            MediumGameButton.SetText(LocalisationAssets.MediumString);
            MediumGameButton.LeftOffset(130);
            MediumGameButton.TopOffset(460);
            MediumGameButton.Width = 120;
            MediumGameButton.MouseUpActions += MediumGameButtonActions;
            StartCanvas.Children.Add(MediumGameButton);

            HardGameButton = new CustomButton();
            HardGameButton.SetText(LocalisationAssets.HardString);
            HardGameButton.LeftOffset(250);
            HardGameButton.TopOffset(460);
            HardGameButton.Width = 120;
            HardGameButton.BackgroundColourHover = Brushes.Red;
            HardGameButton.MouseUpActions += HardGameButtonActions;
            StartCanvas.Children.Add(HardGameButton);

            OptionsButton = new CustomButton();
            OptionsButton.SetText(LocalisationAssets.OptionsString);
            OptionsButton.LeftOffset(42);
            OptionsButton.TopOffset(503);
            OptionsButton.Width = 150;
            OptionsButton.BackgroundColourHover = Brushes.DarkBlue;
            OptionsButton.TextColourHover = Brushes.White;
            OptionsButton.MouseUpActions += OptionsButtonActions;
            StartCanvas.Children.Add(OptionsButton);

            CreditsButton = new CustomButton();
            CreditsButton.SetText(LocalisationAssets.CreditsString);
            CreditsButton.LeftOffset(192);
            CreditsButton.TopOffset(503);
            CreditsButton.Width = 150;
            CreditsButton.BackgroundColourHover = Brushes.Yellow;
            CreditsButton.MouseUpActions += CreditsButtonActions;
            StartCanvas.Children.Add(CreditsButton);

        }

        /// <summary>
        /// Actions for the easy game button.
        /// When pressed, changes the game difficulty to easy and then
        /// starts a game for the user.
        /// </summary>
        private void EasyGameButtonActions()
        {
            Hide();
            GameState.Difficulty = GameState.GameDifficulty.Easy;
            GameState.GameScreen.Show();
            SharedAssets.PlaySound(SharedAssets.SelectSound);
        }

        private void MediumGameButtonActions()
        {
            Hide();
            GameState.Difficulty = GameState.GameDifficulty.Medium;
            GameState.GameScreen.Show();
            SharedAssets.PlaySound(SharedAssets.SelectSound);
        }

        private void HardGameButtonActions()
        {
            Hide();
            GameState.Difficulty = GameState.GameDifficulty.Hard;
            GameState.GameScreen.Show();
            SharedAssets.PlaySound(SharedAssets.SelectSound);
        }

        private void OptionsButtonActions()
        {
            Hide();
            GameState.OptionsScreen.Show();
        }

        private void CreditsButtonActions()
        {
            Hide();
            GameState.CreditsScreen.Show();
        }

        public void Show()
        {
            Reset();
            StartCanvas.Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            StartCanvas.Visibility = Visibility.Hidden;
        }

        //Changes the text content of the buttons.  Called upon a language change.
        public void Reset()
        {
            EasyGameButton.SetText(LocalisationAssets.EasyString);
            MediumGameButton.SetText(LocalisationAssets.MediumString);
            HardGameButton.SetText(LocalisationAssets.HardString);
            OptionsButton.SetText(LocalisationAssets.OptionsString);
            CreditsButton.SetText(LocalisationAssets.CreditsString);
        }

    }
}
