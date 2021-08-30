using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using jSM3.ItemTracker;
using jSM3.ItemTracker.Adapters;
using jSM3.Services;
using SuperMetroidApi;

namespace jSM3
{
    public partial class TrackerForm : Form
    {
        private Tracker? _tracker;
        private readonly SamusApi _samus;
        private readonly WatchlistService _watchlistService;
        
        public TrackerForm(SamusApi? samusApi, WatchlistService watchlistService)
        {
            _samus = samusApi ?? throw new ArgumentNullException(nameof(samusApi));
            _watchlistService = watchlistService ?? throw new ArgumentNullException(nameof(watchlistService));
            
            InitializeComponent();
        }

        private void TrackerForm_Load(object sender, EventArgs e)
        {
            _tracker = new Tracker(_samus, _watchlistService);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsAdapter newAdaptedSurface = new(e.Graphics, Width, Height);
            _tracker?.DrawTo(newAdaptedSurface);
        }
         

        private void TrackerForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
        
        public void UpdateTracker()
        {
            Invalidate(); // causes a paint message to be sent to the form
        }

    }
}