using System;
using System.Windows.Forms;

namespace jSM3.Panels
{
    public partial class StreamerVsAudienceSettingsPanel : UserControl
    {
        public event EventHandler? LaunchStreamerVsAudience;
        
        public StreamerVsAudienceSettingsPanel()
        {
            InitializeComponent();
        }

        private void StreamerVsAudiencePanel_Load(object sender, EventArgs e)
        {
            BorderStyle = BorderStyle.None;
        }

        private void btnLaunchStreamerVsAudience_Click(object sender, EventArgs e)
        {
            LaunchStreamerVsAudience?.Invoke(sender, e);
        }
    }
}