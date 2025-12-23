using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;

namespace LetsGetOrganizedWPF
{
    public partial class MainPage : Page
    {

        public MainPage()
        {
            InitializeComponent();
        }

        public void StartOrganizingFullDrive_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OptionsPage1("full", @"C:"));
        }

        public void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog openFolderDialog = new OpenFolderDialog();

            openFolderDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            openFolderDialog.Multiselect = false;
            Nullable<bool> folderResult = openFolderDialog.ShowDialog();


            if (folderResult.HasValue && folderResult.Value)
            {
                SelectedPathTextBox.Text = openFolderDialog.FolderName;
                OrganizeFolderButton.IsEnabled = true;
            }
        }

        public void OrgBrowsedDirectory_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OptionsPage1("partial", SelectedPathTextBox.Text));
        }

    }
}
