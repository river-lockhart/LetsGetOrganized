using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace LetsGetOrganizedWPF
{
    public partial class OptionsPagePartial : Page
    {
        StartScript startScript = new StartScript();

        private readonly String? mode;
        private readonly String? path;

        public OptionsPagePartial()
        {
            InitializeComponent();
            mode = string.Empty;
            path = string.Empty;
        }

        public OptionsPagePartial(String? mode, String? path) : this()
        {
            this.mode = mode;
            this.path = path;
        }

        private void OrganizeButton_Click(object sender, RoutedEventArgs e)
        {
            startScript.RunLogic(this.mode, this.path);
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();

            }
        }

    }
}
