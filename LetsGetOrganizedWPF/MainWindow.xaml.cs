using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LetsGetOrganizedWPF
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

        private void StartOrganizing_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for organizing logic
            MessageBox.Show("Organizing started!");
        }

        private void SelectFolders_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for folder selection logic
            MessageBox.Show("Folder selection dialog opened!");
        }
    }
}