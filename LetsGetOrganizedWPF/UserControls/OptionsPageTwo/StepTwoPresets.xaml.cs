using LetsGetOrganizedWPF.Core;
using System.Windows;
using System.Windows.Controls;

namespace LetsGetOrganizedWPF.UserControls.OptionsPageTwo
{
    public partial class StepTwoPresets : UserControl
    {
        public CheckBox[] presetCheckBoxes { get; private set; }
        public StepTwoPresets()
        {
            InitializeComponent();
            presetCheckBoxes = new CheckBox[] { };
            AddPresetCheckBox();
        }

        public void AddPresetCheckBox()
        {
            foreach (var child in PresetTable.Children)
            {
                if(child is CheckBox checkBox)
                presetCheckBoxes = presetCheckBoxes.Append(checkBox).ToArray();
            }
        }

        public void OnChecked(object? sender, RoutedEventArgs clickEvent)
        {
            if(sender is CheckBox clicked)
            {
                foreach (CheckBox checkBox in presetCheckBoxes)
                {
                    if (checkBox != clicked)
                    {
                        checkBox.IsChecked = false;
                    }
                }
            }
            
        }

        public CheckBox? GetSelectedPreset()
        {
            foreach (CheckBox checkBox in presetCheckBoxes)
            {
                if (checkBox.IsChecked == true)
                {
                    return checkBox;
                }
            }
            return null;
        }

    }
}
