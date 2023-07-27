using System.Windows;
using Microsoft.AspNetCore.SignalR.Client;

namespace Application1
{
    public partial class MainWindow : Window
    {
        private readonly HubConnection _connection;
        public MainWindow()
        {
            InitializeComponent();

            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/chatHub")
                .Build();

            _connection.On<string>("ReceiveDataInApp2",
                data =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        // Append the new message to the existing text in the TextBlock
                        Output.Text += data + "\n";

                        // Clear the input TextBox for the next input
                        InputTextBox.Text = string.Empty;
                    });
                });

            _connection.StartAsync().ContinueWith(task =>
            {
                if (task is { IsFaulted: true, Exception.InnerException: { } }) Helpers.HandleException(task.Exception.InnerException);
                else
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        Helpers.ShowAlert("Connected desktop client to the server!");
                    });
                }
            });
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            var data = InputTextBox.Text;
            
            _connection.InvokeAsync("SendDataToApp1", data)
                .ContinueWith(task =>
                {
                    if (task is { IsFaulted: true, Exception.InnerException: { } }) Helpers.HandleException(task.Exception.InnerException);
                });
            
            InputTextBox.Text = string.Empty;
        }
        

    }
}