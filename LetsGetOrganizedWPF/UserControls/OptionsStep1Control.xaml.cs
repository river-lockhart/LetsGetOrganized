
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LetsGetOrganizedWPF.UserControls
{
    public partial class OptionsStep1Control : UserControl
    {
        public string RulesMode { get; set; } = string.Empty;

        private bool allExtensions = true;
        private bool includeSubfolders = false;
        private bool includeHiddenFiles = false;

        private static readonly Brush PlaceholderNormalBrush =
            (Brush)new BrushConverter().ConvertFromString("#FF94A3B8");

        private static readonly Brush ErrorBrush = Brushes.Red;

        public OptionsStep1Control()
        {
            InitializeComponent();
            ClearCustomExtensionsErrorUi();
        }

        public void ApplyRulesMode()
        {
            ModeDeterminesDriveComboBox();
        }

        public bool TryBuildOptions(out SharedRules options)
        {
            ClearCustomExtensionsErrorUi();

            var customExtensions = new List<string>();

            if (!allExtensions)
            {
                if (!TryParseCustomExtensions(CustomExtensionsTextBox.Text, out customExtensions, out string error))
                {
                    ApplyCustomExtensionsErrorUi(error);
                    CustomExtensionsTextBox.Focus();
                    options = new SharedRules();
                    return false;
                }
            }

            options = new SharedRules
            {
                AllExtensions = allExtensions,
                CustomExtensions = customExtensions,
                IncludeSubfolders = includeSubfolders,
                IncludeHiddenFiles = includeHiddenFiles
            };

            return true;
        }

        // radio button handlers
        private void AllExtensionsRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (CustomExtensionsPanel != null)
            {
                CustomExtensionsPanel.Visibility = Visibility.Collapsed;
                CustomExtensionsTextBox.IsEnabled = false;
                CustomExtensionsTextBox.Clear();
            }

            allExtensions = true;
            ClearCustomExtensionsErrorUi();
        }

        private void CustomExtensionsRadio_Checked(object sender, RoutedEventArgs e)
        {
            CustomExtensionsPanel.Visibility = Visibility.Visible;
            CustomExtensionsTextBox.IsEnabled = true;

            allExtensions = false;
            ClearCustomExtensionsErrorUi();
        }

        // checkbox handlers
        private void HiddenCheckbox_Checked(object sender, RoutedEventArgs e) => includeHiddenFiles = true;
        private void HiddenCheckbox_Unchecked(object sender, RoutedEventArgs e) => includeHiddenFiles = false;

        private void SubfoldersCheckbox_Checked(object sender, RoutedEventArgs e) => includeSubfolders = true;
        private void SubfoldersCheckbox_Unchecked(object sender, RoutedEventArgs e) => includeSubfolders = false;

        private bool TryParseCustomExtensions(string input, out List<string> parsedExtensions, out string errorMessage)
        {
            parsedExtensions = new List<string>();
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "Please enter at least one file extension.";
                return false;
            }

            var tokens = input.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                var ext = token.Trim().ToLowerInvariant();

                if (!ext.StartsWith("."))
                    ext = "." + ext;

                if (ext.Length < 2 || ext.Any(c => !char.IsLetterOrDigit(c) && c != '.'))
                {
                    errorMessage = $"Invalid extension: {token}";
                    return false;
                }

                parsedExtensions.Add(ext);
            }

            return parsedExtensions.Count > 0;
        }

        // ui helpers
        private void ApplyCustomExtensionsErrorUi(string message)
        {
            CustomExtensionsTextBox.Tag = "Error";
            CustomExtensionsTextBox.BorderBrush = ErrorBrush;

            PlaceholderTextBlock.Text = string.IsNullOrWhiteSpace(message)
                ? "Invalid file extensions. Please try again!"
                : message;

            PlaceholderTextBlock.Foreground = ErrorBrush;
        }

        private void ClearCustomExtensionsErrorUi()
        {
            if (CustomExtensionsTextBox != null && PlaceholderTextBlock != null)
            {
                CustomExtensionsTextBox.Tag = null;
                CustomExtensionsTextBox.ClearValue(TextBox.BorderBrushProperty);
                CustomExtensionsTextBox.ClearValue(TextBox.BorderThicknessProperty);

                PlaceholderTextBlock.Text = ".jpg, .png, .pdf (comma-separated)";
                PlaceholderTextBlock.Foreground = PlaceholderNormalBrush;
            }
        }

        private void ModeDeterminesDriveComboBox()
        {
            if (DriveSelection == null)
                return;

            var m = (RulesMode ?? string.Empty).Trim().ToLowerInvariant();

            if (m == "partial")
                DriveSelection.Visibility = Visibility.Collapsed;
            else
                DriveSelection.Visibility = Visibility.Visible;
        }
    }
}
