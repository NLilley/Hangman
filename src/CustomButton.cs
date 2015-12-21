using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Hangman
{
    /// <summary>
    /// This class provides a combination of WPF controls which function similar to WPF button.
    /// </summary>
    class CustomButton : Border
    {
        public delegate void MouseActions();

        //Delegates allowing events to occur.
        public MouseActions MouseEnterActions { get; set; }
        public MouseActions MouseLeaveActions { get; set; }
        public MouseActions MouseUpActions { get; set; }

        public Label TextLabel { get; set; }

        //Brushes that allow for buttons to have various appearances.
        public Brush BackgroundColourBase { get; set; }
        public Brush BackgroundColourHover { get; set; }
        public Brush TextColourBase { get; set; }
        public Brush TextColourHover { get; set; }

        public CustomButton()
        {
            BackgroundColourBase = Brushes.White;
            BackgroundColourHover = Brushes.DarkOrange;
            TextColourBase = Brushes.Black;
            TextColourHover = Brushes.Black;

            TextLabel = new Label();
            TextLabel.FontSize = 18;
            TextLabel.Foreground = TextColourBase;
            TextLabel.FontWeight = FontWeights.Bold;
            TextLabel.FontFamily = new FontFamily("Arial Black");
            TextLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
            TextLabel.VerticalContentAlignment = VerticalAlignment.Center;
            TextLabel.HorizontalAlignment = HorizontalAlignment.Center;
            TextLabel.VerticalAlignment = VerticalAlignment.Center;

            this.Child = TextLabel;
            this.BorderBrush = Brushes.Black;
            this.BorderThickness = new System.Windows.Thickness(5);
            this.CornerRadius = new System.Windows.CornerRadius(5);
            this.HorizontalAlignment = HorizontalAlignment.Center;
            this.VerticalAlignment = VerticalAlignment.Center;
            this.Background = this.BackgroundColourBase;

            //Add a dummy function to the delegates to prevent Null reference exceptions.
            MouseEnterActions = new MouseActions(dummy);
            MouseLeaveActions = new MouseActions(dummy);
            MouseUpActions = new MouseActions(dummy);

            this.MouseEnter += OnMouseEnter;
            this.MouseLeave += OnMouseLeave;
            this.MouseUp += OnMouseUp;

        }

        public void SetText(string text)
        {
            TextLabel.Content = text;
        }

        public void LeftOffset(double offset)
        {
            Canvas.SetLeft(this, offset);
        }

        public void TopOffset(double offset)
        {
            Canvas.SetTop(this, offset);
        }

        //Change the colour of the button and fire off the delegate functions.
        public void OnMouseEnter(object sender, RoutedEventArgs args)
        {
            this.TextLabel.Foreground = TextColourHover;
            this.Background = BackgroundColourHover;
            MouseEnterActions();
        }

        public void OnMouseLeave(object sender, RoutedEventArgs args)
        {
            this.TextLabel.Foreground = TextColourBase;
            this.Background = BackgroundColourBase;
            MouseLeaveActions();
        }

        public void OnMouseUp(object sender, RoutedEventArgs args)
        {
            MouseUpActions();
        }

        //Dummy function for the sake of initialising the delegates used above.
        public void dummy() { }
    }
}
