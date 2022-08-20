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
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                debugTextBox.Text = "file(s) dropped" + Environment.NewLine;
                string[] droppedFilePaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                foreach (var filePath in droppedFilePaths)
                {
                    debugTextBox.Text += filePath + Environment.NewLine;
                }
            }
        }
    }
}
