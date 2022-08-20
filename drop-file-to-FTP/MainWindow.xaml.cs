using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;

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

        private string credentialsFilePath = "./credentials.cfg";

        private void saveConfig_Click(object sender, RoutedEventArgs e)
        {
            debugTextBox.Text = "save button clicked";

            if (!File.Exists(credentialsFilePath))
            {
                string credentials =
                    hostname.Text + Environment.NewLine +
                    port.Text + Environment.NewLine +
                    username.Text + Environment.NewLine +
                    password.Password.ToString() + Environment.NewLine;

                File.WriteAllText(credentialsFilePath, credentials);
            }
        }

        private void list_Drop(object sender, DragEventArgs e)
        {
            if (!File.Exists(credentialsFilePath))
            {
                debugTextBox.Text = "No credentials.cfg-file found." + Environment.NewLine +
                                    "Save credentials and try again" + Environment.NewLine;
            }
            else
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
                {
                    var readCredentials = File.ReadAllText(credentialsFilePath);
                    string[] splitCredentials = readCredentials.Split(
                        new string[] { Environment.NewLine},
                        StringSplitOptions.None
                    );

                    debugTextBox.Text = "File(s) dropped:" + Environment.NewLine;
                    string[] droppedFilesPaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];

                    using (var client = new WebClient())
                    {
                        string FTPURI = splitCredentials[0] + ":" + splitCredentials[1];
                        client.Credentials = new NetworkCredential(splitCredentials[2], splitCredentials[3]);
                        foreach (var filePath in droppedFilesPaths)
                        {
                            string filename = filePath.Split("\\").Last();
                            debugTextBox.Text += filename + Environment.NewLine;
                            client.UploadFile("ftp://" + FTPURI + "/" + filename, WebRequestMethods.Ftp.UploadFile, filePath);
                        }
                    }
                }
            }
        }
    }
}
