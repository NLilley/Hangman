using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hangman
{

    /// <summary>
    /// This is the entry point of the application.  The GUI for the program is set up here
    /// in conjunction with the MainWindow.xaml file and the screens
    /// useds for the purpose of the game are instantiated here aswell.
    /// </summary>
    public partial class MainWindow : Window
    {
        //Declare all of the different game screens
        StartScreen StartScreen { get; set; }
        GameScreen GameScreen { get; set; }
        WinScreen WinScreen { get; set; }
        LoseScreen LoseScreen { get; set; }
        OptionsScreen OptionsScreen { get; set; }
        CreditsScreen CreditsScreen { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            //Read user settings and localised assets from xml files and update static classes.
            UserSettings.SetupSettings();
            LocalisationAssets.ReadAssets();

            GameWindow.ResizeMode = ResizeMode.NoResize;

            //Setup the important screen objects that are used to present the game
            GameScreen = new GameScreen(GameCanvas, ManCanvas);
            WinScreen = new WinScreen(WinCanvas);
            LoseScreen = new LoseScreen(LoseCanvas);
            StartScreen = new StartScreen(StartScreenCanvas);
            OptionsScreen = new OptionsScreen(OptionsCanvas);
            CreditsScreen = new CreditsScreen(CreditsCanvas);

            //Set up the Screen statics for later use.
            GameState.StartScreen = this.StartScreen;
            GameState.GameScreen = this.GameScreen;
            GameState.WinScreen = this.WinScreen;
            GameState.LoseScreen = this.LoseScreen;
            GameState.OptionsScreen = this.OptionsScreen;
            GameState.CreditsScreen = this.CreditsScreen;

        }

    }
}
