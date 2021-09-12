using System;
using System.Windows.Forms;
using jSM3.Properties;

namespace jSM3
{
    public partial class StreamerVsAudienceForm : Form
    {
        public StreamerVsAudienceForm()
        {
            InitializeComponent();
        }

        private void StreamerVsAudienceForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.etecoonicon; // set window icon from resources
        }
    }
}