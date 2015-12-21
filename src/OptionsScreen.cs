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
    /// The options screen provides a means for the user to change the settings of the game,
    /// including the current language and the game volume.
    /// </summary>
    class OptionsScreen : IScreen
    {

        Canvas OptionsCanvas { get; set; }

        CustomButton MuteButton { get; set; }
        CustomButton BackButton { get; set; }
        List<CustomButton> LanguageButtons { get; set; }

        public OptionsScreen(Canvas OptionsCanvas)
        {
            this.OptionsCanvas = OptionsCanvas;

            MuteButton = new CustomButton();
            MuteButton.SetText(LocalisationAssets.MuteString);
            MuteButton.Width = 160;
            MuteButton.LeftOffset(120);
            MuteButton.TopOffset(40);
            MuteButton.BackgroundColourHover = Brushes.Silver;
            MuteButton.TextColourHover = Brushes.Black;
            if (SharedAssets.IsMuted)
            {
                MuteButton.BackgroundColourBase = Brushes.Black;
                MuteButton.Background = Brushes.Black;
                MuteButton.TextColourBase = Brushes.White;
                MuteButton.TextLabel.Foreground = Brushes.White;
                MuteButton.BorderBrush = Brushes.Silver;
            }
            else
            {
                MuteButton.BackgroundColourBase = Brushes.White;
                MuteButton.TextColourBase = Brushes.Black;
                MuteButton.BorderBrush = Brushes.Black;
            }
            MuteButton.MouseUpActions += MuteButtonActions;
            OptionsCanvas.Children.Add(MuteButton);

            BackButton = new CustomButton();
            BackButton.SetText(LocalisationAssets.MenuString);
            BackButton.Width = 160;
            BackButton.LeftOffset(120);
            BackButton.TopOffset(502);
            BackButton.BackgroundColourHover = Brushes.DarkBlue;
            BackButton.TextColourHover = Brushes.White;
            BackButton.MouseUpActions += BackButtonActions;

            OptionsCanvas.Children.Add(BackButton);

            LanguageButtons = new List<CustomButton>();

            //For each language available to the user, add a button which will allow them to select it.
            foreach (string s in LocalisationAssets.Languages)
            {
                CustomButton b = new CustomButton();

                b.SetText(s);
                b.Width = 160;
                b.LeftOffset(120);
                b.TopOffset(90 + (50 * LanguageButtons.Count));
                b.BackgroundColourHover = Brushes.Orange;
                if (UserSettings.Language == b.TextLabel.Content.ToString())
                {
                    b.BackgroundColourBase = Brushes.Orange;
                    b.Background = Brushes.Orange;
                }
                //When clicked, change the user language and change the contents of controls that rely on localisation assets.
                b.MouseUpActions += () =>
                {
                    UserSettings.SetLanguage(s);
                    LocalisationAssets.ReadAssets();
                    GameState.ResetScreens();
                    SharedAssets.PlaySound(SharedAssets.SelectSound);

                };

                OptionsCanvas.Children.Add(b);
                LanguageButtons.Add(b);

            }

        }

        public void BackButtonActions()
        {
            Hide();
            GameState.StartScreen.Show();
        }

        //When clicked, will toggle the application to be muted.
        public void MuteButtonActions()
        {
            //If muted, unmute and vice versa.
            UserSettings.SetIsMuted(!SharedAssets.IsMuted);

            if (SharedAssets.IsMuted)
            {
                MuteButton.BackgroundColourBase = Brushes.Black;
                MuteButton.TextColourBase = Brushes.White;
                MuteButton.BorderBrush = Brushes.Silver;
            }
            else
            {
                MuteButton.BackgroundColourBase = Brushes.White;
                MuteButton.TextColourBase = Brushes.Black;
                MuteButton.BorderBrush = Brushes.Black;
            }

            SharedAssets.PlaySound(SharedAssets.SelectSound);
        }

        public void Show()
        {
            OptionsCanvas.Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            OptionsCanvas.Visibility = Visibility.Hidden;
        }

        public void Reset()
        {
            BackButton.SetText(LocalisationAssets.MenuString);

            foreach (CustomButton b in LanguageButtons)
            {
                if (b.TextLabel.Content.ToString() == UserSettings.Language)
                {
                    b.BackgroundColourBase = Brushes.Orange;
                    b.Background = Brushes.Orange;
                }
                else
                {
                    b.BackgroundColourBase = Brushes.White;
                    b.Background = Brushes.White;
                }

                b.SetText(b.TextLabel.Content.ToString());
            }

        }
    }
}
