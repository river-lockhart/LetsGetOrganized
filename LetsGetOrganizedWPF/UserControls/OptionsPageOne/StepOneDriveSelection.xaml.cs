using System.Windows.Controls;

namespace LetsGetOrganizedWPF.UserControls.OptionsPageOne
{
    
    public partial class StepOneDriveSelection : UserControl
    {
        public StepOneDriveSelection()
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
