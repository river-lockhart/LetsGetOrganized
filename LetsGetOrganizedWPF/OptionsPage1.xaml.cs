using System.Windows;
using System.Windows.Controls;

namespace LetsGetOrganizedWPF
{
    public partial class OptionsPage1 : Page
    {
        private readonly StartScript startScript = new StartScript();
        private readonly RulesConfig rulesConfig = new RulesConfig();

        private readonly string? mode;
        private readonly string? path;

        public OptionsPage1()
        {
            InitializeComponent();

            mode = string.Empty;
            path = string.Empty;

            rulesConfig.setRulesMode(mode);

            Step1Control.RulesMode = rulesConfig.getRulesMode();
            Step1Control.ApplyRulesMode();
        }

        public OptionsPage1(string? mode, string? path) : this()
        {
            this.mode = mode;
            this.path = path;

            rulesConfig.setRulesMode(mode ?? string.Empty);

            Step1Control.RulesMode = rulesConfig.getRulesMode();
            Step1Control.ApplyRulesMode();
        }

        private void OrganizeButton_Click(object sender, RoutedEventArgs e)
        {
            startScript.RunLogic(this.mode, this.path);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Step1Control.TryBuildOptions(out SharedRules step1))
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

            NavigationService.GoBack();
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }
    }
}
