using System;
using System.Windows.Forms;

namespace jSM3.Panels
{
    public partial class AutotrackerSettingsPanel : UserControl
    {
        public event EventHandler? LaunchTracker;

        public AutotrackerSettingsPanel()
        {
            InitializeComponent();
        }

        private void AutotrackerSettingsPanel_Load(object sender, EventArgs e)
        {
            BorderStyle = BorderStyle.None;
        }

        private void btnLaunchAutotracker_Click(object sender, EventArgs e)
        {
            LaunchTracker?.Invoke(sender, e);
        }
    }
}
