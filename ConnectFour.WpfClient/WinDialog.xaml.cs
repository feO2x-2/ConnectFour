using System.Windows;

namespace ConnectFour.WpfClient
{
    public sealed partial class WinDialog
    {
        public WinDialog()
        {
            InitializeComponent();
        }

        public WinDialog(string playerName) : this()
        {
            TextBlock.Text = $"{playerName} won!";
        }

        private void QuitApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            Close();
        }
    }
}