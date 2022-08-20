using System;
using System.IO;
using System.Windows;
using System.Windows.Shapes;

namespace drop_file_to_FTP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void saveConfig_Click(object sender, RoutedEventArgs e)
        {
            debugTextBox.Text = "save button clicked";

            string filePath = "./credentials.cfg";

            if (!File.Exists(filePath))
            {
                string credentials =
                    hostname.Text + Environment.NewLine +
                    port.Text + Environment.NewLine +
                    username.Text + Environment.NewLine +
                    password.Password.ToString() + Environment.NewLine;

                File.WriteAllText(filePath, credentials);
            }
        }

        private void list_Drop(object sender, DragEventArgs e)
        {
            debugTextBox.Text = "file dropped";
        }

        private void list_DragEnter(object sender, DragEventArgs e)
        {
            debugTextBox.Text = "drag enter started";
        }

        private void list_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            debugTextBox.Text = "list view double clicked";
        }
    }
}
