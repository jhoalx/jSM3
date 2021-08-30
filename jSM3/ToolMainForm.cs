using System;
using System.Windows.Forms;
using BizHawk.Client.Common;
using BizHawk.Client.EmuHawk;
using BizHawk.Emulation.Common;
using jSM3.Constants;
using jSM3.Properties;
using jSM3.Services;
using SuperMetroidApi;
using SuperMetroidApi.Constants.Values.Samus;

namespace jSM3
{
    //  Super Metroid(Japan, USA) (En, Ja) - SHA1:DA957F0D63D14CB441D215462904C4FA8519C613
    // TODO: change name and description
    [ExternalTool("jSM3 Tool", Description = "hobby project", LoadAssemblyFiles = new[] {"./SuperMetroidApi.dll"})]
    [ExternalToolEmbeddedIcon("jSM3.etecoonicon.ico")]
    [ExternalToolApplicability.SingleRom(CoreSystem.SNES, "DA957F0D63D14CB441D215462904C4FA8519C613")]
    public partial class ToolMainForm : ToolFormBase, IExternalToolForm
    {
        // ReSharper disable once MemberCanBePrivate.Global
        [RequiredApi] public ApiContainer? _maybeApiContainer { get; set; }
        [RequiredService] private IMemoryDomains? _maybeMemoryDomains { get; set; }
        [RequiredService] private IEmulator? _emu { get; set; }

        private ApiContainer _apis =>
            _maybeApiContainer ?? throw new NullReferenceException(nameof(_maybeApiContainer));


        protected override string WindowTitleStatic => "jSM3 Tool - etecoon";

        private SamusApi _samus = null!;
        private int _cooldown;

        private TrackerForm? _trackerForm;
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

            txtEnergy.Text = _samus.GetEnergy().ToString();
            lblReserveSupplyMode.Text = _samus.GetCurrentReserveSupplyMode().ToString();
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

            /////// auto open tracker on startup, remove
            _trackerForm?.Close();
            _trackerForm = new TrackerForm(_samus, _watchlistService);
            _trackerForm.Show();
            /////// auto open tracker on startup, remove
        }
        
        private void ToolMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _trackerForm?.Close();
            _trackerForm?.Dispose();
        }

        private void btnLaunchTracker_Click(object sender, EventArgs e)
        {
            _trackerForm?.Close();

            _trackerForm = new TrackerForm(_samus, _watchlistService!);
            _trackerForm.Show();
        }

        private void btnGrant_Click(object sender, EventArgs e)
        {
            _samus.GiveSuits(SuitsAndMisc.VariaSuit | SuitsAndMisc.ScrewAttack);
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            _samus.TakeSuits(SuitsAndMisc.VariaSuit);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _samus.TakeSuits(SuitsAndMisc.ScrewAttack);
        }


    }
}