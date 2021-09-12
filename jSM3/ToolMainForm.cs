using System;
using System.Drawing;
using System.Windows.Forms;
using BizHawk.Client.Common;
using BizHawk.Client.EmuHawk;
using BizHawk.Emulation.Common;
using jSM3.Panels;
using jSM3.Constants;
using jSM3.Properties;
using jSM3.Services;
using SuperMetroidApi;
using SuperMetroidApi.Constants.Values.Samus;
using System.Runtime.InteropServices;


namespace jSM3
{
    //  Super Metroid(Japan, USA) (En, Ja) - SHA1:DA957F0D63D14CB441D215462904C4FA8519C613
    // TODO: change name and description
    [ExternalTool("jSM3 Tool", Description = "hobby project", LoadAssemblyFiles = new[] {"./SuperMetroidApi.dll"})]
    [ExternalToolEmbeddedIcon("jSM3.etecoonicon.ico")]
    // [ExternalToolApplicability.SingleRom(CoreSystem.SNES, "DA957F0D63D14CB441D215462904C4FA8519C613")]
    // ReSharper disable once UnusedType.Global
    public partial class ToolMainForm : ToolFormBase, IExternalToolForm
    {
        #region Move Borderless window

        // Resharper disable All
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        private static extern bool ReleaseCapture();
        // ReSharper restore All

        #endregion


        // ReSharper disable once MemberCanBePrivate.Global
        [RequiredApi] public ApiContainer? _maybeApiContainer { get; set; }
        [RequiredService] private IMemoryDomains? _maybeMemoryDomains { get; set; }
        [RequiredService] private IEmulator? _emu { get; set; }

        private ApiContainer _apis =>
            _maybeApiContainer ?? throw new NullReferenceException(nameof(_maybeApiContainer));


        protected override string WindowTitleStatic => "jSM3 Tool";


        private SamusApi _samus = null!;
        private int _cooldown;

        private TrackerForm? _trackerForm;
        private StreamerVsAudienceForm? _streamerVsAudienceForm;
        
        private AutotrackerSettingsPanel? _autotrackerPanel;
        private StreamerVsAudienceSettingsPanel? _streamerVsAudiencePanel;
        private const int _clientPadding = 16;

        private WatchlistService? _watchlistService;

        public ToolMainForm()
        {
            InitializeComponent();
        }


        // executed once after the constructor, and again every time a rom is loaded or reloaded
        public override void Restart()
        {
            //
        }

        // executed after every frame (except while turboing, use FastUpdateAfter for that)
        protected override void UpdateAfter()
        {
            _cooldown++;
            if (_cooldown == Globals.UpdateCooldownFrames)
            {
                _cooldown = 0;
                _trackerForm?.UpdateTracker();
            }
        }

        // executed after every frame while turboing
        protected override void FastUpdateAfter()
        {
            //
        }


        private void ToolMainForm_Load(object sender, EventArgs e)
        {
            
            _samus = new SamusApi(_apis.Memory, _maybeMemoryDomains, MainForm.CheatList);

            _watchlistService = new WatchlistService(
                _emu?.SystemId ?? throw new InvalidOperationException(),
                _maybeMemoryDomains ?? throw new InvalidOperationException(),
                new Config()
            );

            Icon = Resources.etecoonicon; // set window icon from resources
            MinimumSize = new Size(640, 480) + (Size - ClientSize); // set client size to 640 x 480

            _autotrackerPanel = new AutotrackerSettingsPanel();
            _autotrackerPanel.Location = new Point(panelMenu.Left + panelMenu.Width, panelMenu.Top);
            _autotrackerPanel.Width = Width - panelMenu.Width - _clientPadding * 2;
            _autotrackerPanel.Height = Height - _clientPadding * 2;
            _autotrackerPanel.LaunchTracker += LaunchTracker;

            _streamerVsAudiencePanel = new StreamerVsAudienceSettingsPanel();
            _streamerVsAudiencePanel.Location = new Point(panelMenu.Left + panelMenu.Width, panelMenu.Top);
            _streamerVsAudiencePanel.Width = Width - panelMenu.Width - _clientPadding * 2;
            _streamerVsAudiencePanel.Height = Height - _clientPadding * 2;
            _streamerVsAudiencePanel.LaunchStreamerVsAudience += LaunchStreamerVsAudience; // TODO: temporary, implement


            Controls.Add(_autotrackerPanel);
            Controls.Add(_streamerVsAudiencePanel);
        }

        private void ToolMainForm_MouseDown(object sender, MouseEventArgs e)
        {
            // allows moving the form from its client area
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ToolMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _trackerForm?.Close();
            _trackerForm?.Dispose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void LaunchTracker(object sender, EventArgs e)
        {
            _trackerForm?.Close();
            _trackerForm = new TrackerForm(_samus, _watchlistService!);
            _trackerForm.Show();
        }
        
        private void LaunchStreamerVsAudience(object sender, EventArgs e)
        {
            _streamerVsAudienceForm?.Close();
            _streamerVsAudienceForm = new StreamerVsAudienceForm();
            _streamerVsAudienceForm.Show();
        }

        private void btnAutotracker_Click(object sender, EventArgs e)
        {
            if (_autotrackerPanel != null)
            {
                _autotrackerPanel.Visible = true;
                _autotrackerPanel.Enabled = true;
            }

            if (_streamerVsAudiencePanel != null)
            {
                _streamerVsAudiencePanel.Visible = false;
                _streamerVsAudiencePanel.Enabled = false;
            }
        }

        private void btnStreamerVsAudience_Click(object sender, EventArgs e)
        {
            if (_streamerVsAudiencePanel != null)
            {
                _streamerVsAudiencePanel.Visible = true;
                _streamerVsAudiencePanel.Enabled = true;
            }
            
            if (_autotrackerPanel != null)
            {
                _autotrackerPanel.Visible = false;
                _autotrackerPanel.Enabled = false;
            }
        }
    }
}