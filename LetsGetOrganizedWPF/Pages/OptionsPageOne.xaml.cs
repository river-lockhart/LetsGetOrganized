using LetsGetOrganizedWPF.Core;
using System.Windows;
using System.Windows.Controls;

namespace LetsGetOrganizedWPF.Pages
{
    public partial class OptionsPageOne : Page
    {
        private readonly StartScript startScript = new StartScript();
        private readonly RulesConfig rulesConfig = new RulesConfig();

        private readonly string? mode;
        private readonly string? path;

        public OptionsPageOne()
        {
            InitializeComponent();

            mode = string.Empty;
            path = string.Empty;
        }

        public OptionsPageOne(string? mode, string? path, RulesConfig rulesConfig) : this()
        {
            this.mode = mode;
            this.path = path;

            rulesConfig.setRulesMode(mode ?? string.Empty);
            rulesConfig.setRulesPath(path ?? string.Empty);

            StepOneControl.RulesMode = rulesConfig.getRulesMode();
            StepOneControl.RulesPath = rulesConfig.getRulesPath();
            StepOneControl.ApplyRulesMode();

            this.rulesConfig.Ruleset = rulesConfig.Ruleset;
        }

        private void OrganizeButton_Click(object sender, RoutedEventArgs e)
        {
            startScript.RunLogic(this.mode, this.path);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!StepOneControl.TryBuildOptions(out SharedRules step1))
                return;

            rulesConfig.Ruleset.Rules.Clear();

            rulesConfig.Ruleset.Rules.Add(new RulesConfig.Rule
            {
                RuleId = "file-types",
                Description = "Controls which file extensions are included",
                Params =
                {
                    ["allExtensions"] = step1.AllExtensions,
                    ["customExtensions"] = step1.CustomExtensions
                }
            });

            rulesConfig.Ruleset.Rules.Add(new RulesConfig.Rule
            {
                RuleId = "subfolders",
                Description = "Include files from subdirectories",
                Params =
                {
                    ["includeSubfolders"] = step1.IncludeSubfolders
                }
            });

            rulesConfig.Ruleset.Rules.Add(new RulesConfig.Rule
            {
                RuleId = "hidden-files",
                Description = "Include hidden files",
                Params =
                {
                    ["includeHiddenFiles"] = step1.IncludeHiddenFiles
                }
            });

            NavigationService.Navigate(new OptionsPageTwo(rulesConfig));
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }
    }
}
