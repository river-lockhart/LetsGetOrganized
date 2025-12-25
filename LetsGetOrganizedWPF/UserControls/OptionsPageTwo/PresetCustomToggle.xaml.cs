using System;
using System.Windows;
using System.Windows.Controls;

namespace LetsGetOrganizedWPF.UserControls.OptionsPageTwo
{
    public partial class PresetCustomToggle : UserControl
    {
        public bool IsChecked { get; private set; }

        public event EventHandler<bool>? Toggled;

        public PresetCustomToggle()
        {
            InitializeComponent();
            IsChecked = false;
        }

        public void ToggleSetPreset(object sender, RoutedEventArgs e)
        {
            IsChecked = false;
            Toggled?.Invoke(this, IsChecked);
        }

        public void ToggleSetCustom(object sender, RoutedEventArgs e)
        {
            IsChecked = true;
            Toggled?.Invoke(this, IsChecked);
        }
    }
}
