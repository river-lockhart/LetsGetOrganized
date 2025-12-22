using System.Windows;
using System.Windows.Controls;

namespace LetsGetOrganizedWPF
{
    public partial class OptionsPagePartial : Page
    {
        private readonly StartScript startScript = new StartScript();
        private readonly RulesConfig rulesConfig = new RulesConfig();
        private readonly OptionsStep1Control step1Control = new OptionsStep1Control();

        private readonly string? mode;
        private readonly string? path;

        public OptionsPagePartial()
        {
            InitializeComponent();
            mode = string.Empty;
            path = string.Empty;
        }

        public OptionsPagePartial(string? mode, string? path) : this()
        {
            this.mode = mode;
            this.path = path;
        }

        private void OrganizeButton_Click(object sender, RoutedEventArgs e)
        {
            startScript.RunLogic(this.mode, this.path);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Step1Control.TryBuildOptions(out SharedRules step1))
                return;

            // clear rules if re-running wizard
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
