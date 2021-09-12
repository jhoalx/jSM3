using System;
using System.Drawing;
using System.Windows.Forms;
using jSM3.ItemTracker;
using jSM3.ItemTracker.Adapters;
using jSM3.Properties;
using jSM3.Services;
using SuperMetroidApi;

namespace jSM3
{
    public partial class TrackerForm : Form
    {
        private Tracker? _tracker;
        private readonly SamusApi _samus;
        private readonly WatchlistService _watchlistService;

        private readonly Size _minimumClientSize = new(160, 160);

        // public Size MinimumClientSize {
        //     get => _minimumClientSize;
        //     set { 
        //         _minimumClientSize = value;
        //         PerformLayout();
        //     }
        // }

        protected override void OnLayout(LayoutEventArgs e) {
            base.OnLayout(e); 
            MinimumSize = _minimumClientSize + (Size - ClientSize);
        } 
         
        public TrackerForm(SamusApi? samusApi, WatchlistService watchlistService)
        {
            _samus = samusApi ?? throw new ArgumentNullException(nameof(samusApi));
            _watchlistService = watchlistService ?? throw new ArgumentNullException(nameof(watchlistService));
            
            InitializeComponent();
        }


        private void TrackerForm_Load(object sender, EventArgs e)
        {
            Icon = Resources.etecoonicon; // set window icon from resources
            _tracker = new Tracker(_samus, _watchlistService);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsAdapter newAdaptedSurface = new(e.Graphics, ClientSize);
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