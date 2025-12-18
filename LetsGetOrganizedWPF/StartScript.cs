using System.IO;
using System.Diagnostics;
using System.Windows;

namespace LetsGetOrganizedWPF
{
    internal class StartScript
    {
        public void RunLogic(String? mode, String? path)
        {
            var exeDir = AppContext.BaseDirectory;
            var repoRoot = Path.GetFullPath(Path.Combine(exeDir, @"..\..\..\..\"));

            var batPath = Path.Combine(
                repoRoot,
                @"LetsGetOrganizedLogic\app\build\install\LetsGetOrganized\bin\LetsGetOrganized.bat"
            );

            if (!File.Exists(batPath))
            {
                MessageBox.Show($"couldn't find logic launcher:\n{batPath}");
                return;
            }

            var psi = new ProcessStartInfo
            {
                FileName = batPath,
                Arguments = $"{mode} \"{path}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                WorkingDirectory = Path.GetDirectoryName(batPath)
            };

            using var p = Process.Start(psi);
            var output = p.StandardOutput.ReadToEnd();
            var error = p.StandardError.ReadToEnd();
            p.WaitForExit();

            MessageBox.Show(p.ExitCode == 0 ? output : error);
        }
    }
}
