using DevExpress.XtraGrid;
using System.Diagnostics;

namespace ReadyToRunPerformanceTest
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
    }
}