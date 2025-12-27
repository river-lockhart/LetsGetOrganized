using LetsGetOrganizedWPF.Core;
using LetsGetOrganizedWPF.UserControls.OptionsPageTwo;
using System.Runtime.Intrinsics.X86;
using System.Windows;
using System.Windows.Controls;

namespace LetsGetOrganizedWPF.Pages
{
    public partial class OptionsPageTwo : Page
    {
        private readonly RulesConfig rulesConfig = new RulesConfig();
        public OptionsPageTwo()
        {
            InitializeComponent();
            ToggleControl.Toggled += OnToggleChanged;
            DisplayPresetsOrCustomControl(ToggleControl.IsChecked);
        }

        public OptionsPageTwo(RulesConfig rulesConfig)
        {
            InitializeComponent();
            this.rulesConfig = rulesConfig;
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

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            CheckBox? selectedOption = PresetsControl.GetSelectedPreset();
            if (ToggleControl.PresetCustomToggleButton.IsChecked == false && selectedOption != null)
            {
                rulesConfig.Ruleset.Rules.Add(new RulesConfig.Rule
                {
                    RuleId = "preset-chosen",
                    Description = "The preset the user chose in Step Two",
                    Params =
                {
                    ["presetClicked"] = true,
                    ["presetSelected"] = selectedOption.Name,
                }
                });
            }
            else
            {
                // Custom is selected
            }

            string debugText = "";
            foreach (var rule in rulesConfig.Ruleset.Rules)
            {
                debugText += $"RuleId: {rule.RuleId}\n";
                debugText += $"Description: {rule.Description}\n";

                foreach (var kv in rule.Params)
                {
                    debugText += $"  {kv.Key}: {kv.Value}\n";
                }

                debugText += "\n";
            }

            MessageBox.Show(debugText, "Ruleset Debug");

            NavigationService.GoBack();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
