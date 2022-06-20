using DevExpress.XtraGrid;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace NgenPerformanceTest
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            var stopwatch = Stopwatch.StartNew();
            Controls.Add(new GridControl() { Width = 0, Height = 0 });
            MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            Ngen("install");
        }

        private void UninstallButton_Click(object sender, EventArgs e)
        {
            Ngen("uninstall");
        }

        static void Ngen(string action)
        {
            string runtimeStr = RuntimeEnvironment.GetRuntimeDirectory();
            string ngenStr = Path.Combine(runtimeStr, "ngen.exe");
            string dir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(dir);
            var file = Path.Combine(dir, "run.bat");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($@"""{ngenStr}"" ""{action}"" ""{Assembly.GetExecutingAssembly().Location}"" /nologo");
            File.WriteAllText(file, sb.ToString());
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $@"/C {file}",
                    UseShellExecute = true,
                    CreateNoWindow = true,
                    Verb = "runas"
                }
            };
            process.Start();
            process.WaitForExit();
            process.Dispose();
        }
    }
}
