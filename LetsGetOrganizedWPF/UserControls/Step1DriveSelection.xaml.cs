using System.Windows.Controls;

namespace LetsGetOrganizedWPF.UserControls
{
    
    public partial class Step1DriveSelection : UserControl
    {
        public Step1DriveSelection()
        {
            InitializeComponent();
            FillDriveComboBox();
        }

        private void DriveComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedDrive = (ComboBoxItem)DriveSelectionComboBox.SelectedItem;
            string drivePath = selectedDrive.Content.ToString() ?? string.Empty;
        }

        private void FillDriveComboBox()
        {
                       DriveSelectionComboBox.Items.Clear();
            foreach (var drive in System.IO.DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    ComboBoxItem item = new ComboBoxItem
                    {
                        Content = drive.RootDirectory.FullName
                    };
                    DriveSelectionComboBox.Items.Add(item);
                }
            }

        }
    }
}
