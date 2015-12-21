using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Hangman
{
    /// <summary>
    /// This class provides static access to several shared resources such as sounds and graphics.
    /// </summary>
    static class SharedAssets
    {
        public static bool IsMuted { get; set; }

        //Sound files
        public static SoundPlayer MistakeSound { get; set; }
        public static SoundPlayer SelectSound { get; set; }
        public static SoundPlayer CorrectSound { get; set; }
        public static SoundPlayer WinSound { get; set; }
        public static SoundPlayer LoseSound { get; set; }

        //Graphics
        public static BitmapImage Happy { get; set; }
        public static BitmapImage Cautious { get; set; }
        public static BitmapImage Upset { get; set; }
        public static BitmapImage Tearful { get; set; }
        public static BitmapImage HangmanTitle { get; set; }
        public static BitmapImage Noose { get; set; }
        public static BitmapImage Gallow { get; set; }
        public static BitmapImage Star { get; set; }

        static SharedAssets()
        {
            try
            {
                IsMuted = false;

                MistakeSound = new SoundPlayer(@".\assets\sfx\mistake.wav");
                SelectSound = new SoundPlayer(@".\assets\sfx\select.wav");
                CorrectSound = new SoundPlayer(@".\assets\sfx\correct.wav");
                WinSound = new SoundPlayer(@".\assets\sfx\cheer.wav");
                LoseSound = new SoundPlayer(@".\assets\sfx\gameover.wav");

                Happy = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/assets/img/Happy.png"));
                Cautious = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/assets/img/Cautious.png"));
                Upset = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/assets/img/Upset.png"));
                Tearful = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/assets/img/Tearful.png"));
                HangmanTitle = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/assets/img/HangmanTitle.png"));
                Noose = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/assets/img/Noose.png"));
                Gallow = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/assets/img/Gallow.png"));
                Star = new BitmapImage(new Uri(@"pack://siteoforigin:,,,/assets/img/Star.png"));
            }
            catch (Exception e)
            {
                Console.WriteLine("There was a problem aquring required application assets: " + e.Message);
            }
        }

        //This function will only play the desired sound when the application is unmuted.
        public static void PlaySound(SoundPlayer s)
        {
            if (!IsMuted)
            {
                s.Play();
            }
        }
    }
}
