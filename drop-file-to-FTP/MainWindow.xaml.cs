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

        private void list_Drop(object sender, DragEventArgs e)
        {
            debugTextBox.Text = "file dropped";
        }

        private void list_DragEnter(object sender, DragEventArgs e)
        {
            debugTextBox.Text = "drag enter started";
        }

        private void saveConfig_Click(object sender, RoutedEventArgs e)
        {
            debugTextBox.Text = "save button clicked";
        }

        private void list_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            debugTextBox.Text = "list view double clicked";
        }
    }
}
