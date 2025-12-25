using System.Windows;
using System.Windows.Controls;

namespace LetsGetOrganizedWPF.Pages
{
    public partial class OptionsPageTwo : Page
    {
        public OptionsPageTwo()
        {
            InitializeComponent();

            ToggleControl.Toggled += OnToggleChanged;

            DisplayPresetsOrCustomControl(ToggleControl.IsChecked);
        }

        private void OnToggleChanged(object? sender, bool isCustom)
        {
            DisplayPresetsOrCustomControl(isCustom);
        }

        private void DisplayPresetsOrCustomControl(bool isCustom)
        {
            PresetsControl.Visibility = isCustom
                ? Visibility.Collapsed
                : Visibility.Visible;

            CustomControl.Visibility = isCustom
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
