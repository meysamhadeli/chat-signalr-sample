using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Application1;

public static class Helpers
{
    private static DispatcherTimer? _timer;
    private static Window? _alertWindow;
    
    public static void HandleException(Exception ex)
    {
        // Display a user-friendly error message
        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    public static void ShowAlert(string message)
    {
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(2) // Set the duration for 5 seconds
        };
        _timer.Tick += Timer_Tick;

        if (Application.Current.MainWindow != null)
        {
            var mainWindowPosition = Application.Current.MainWindow.PointToScreen(new Point(0, 0));
            var mainWindowSize = new Size(Application.Current.MainWindow.ActualWidth, Application.Current.MainWindow.ActualHeight);
            var alertWindowWidth = 250;
            var alertWindowHeight = 100;
            
            _alertWindow = new Window
            {
                Width = alertWindowWidth,
                Height = alertWindowHeight,
                Title = "Alert",
                Content = new TextBlock { Text = message, TextWrapping = TextWrapping.Wrap },
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = mainWindowPosition.X + (mainWindowSize.Width - alertWindowWidth) / 2,
                Top = mainWindowPosition.Y + (mainWindowSize.Height - alertWindowHeight) / 2
            };
        }

        _alertWindow?.Show();

        // Start the timer when the alert window is shown
        _timer.Start();
    }
    
    private static void Timer_Tick(object? sender, EventArgs e)
    {
        // Stop the timer when it ticks and close the alert window
        _timer?.Stop();
        _alertWindow?.Close();
    }
}