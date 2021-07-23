using System.Windows;
using System.Windows.Controls;
using SniffCore.MessageBoxes;

namespace Tryout
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var options = new WPFMessageBoxOptions
            {
                ShowDoNotShowAgainCheckBox = true
            };
            WPFMessageBox.Show(this, "text", "caption", WPFMessageBoxButtons.OKCancel, WPFMessageBoxImages.Question, WPFMessageBoxResult.Cancel, options);
        }
    }
}