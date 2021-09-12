using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using BizHawk.Client.Common;
using jSM3.ItemTracker.Adapters;
using jSM3.ItemTracker.Models;
using jSM3.Services;
using SuperMetroidApi;
using SuperMetroidApi.Constants.Values.Samus;

namespace jSM3.ItemTracker
{
    public class Tracker
    {
        private readonly WatchlistService _watchlistService;

        private readonly SamusApi _samus;

        private List<SmItem> _smItems = new()
        {
            new SmItem {Name = "VariaSuit"},
            new SmItem {Name = "SpringBall"},
            new SmItem {Name = "MorphingBall"},
            new SmItem {Name = "ScrewAttack"},
            new SmItem {Name = "GravitySuit"},
            new SmItem {Name = "HiJumpBoots"},
            new SmItem {Name = "SpaceJump"},
            new SmItem {Name = "Bomb"},
            new SmItem {Name = "SpeedBooster"},
            new SmItem {Name = "GrapplingBeam"},
            new SmItem {Name = "XRayScope"},
            new SmItem {Name = "WaveBeam"},
            new SmItem {Name = "IceBeam"},
            new SmItem {Name = "SpazerBeam"},
            new SmItem {Name = "PlasmaBeam"},
            new SmItem {Name = "ChargeBeam"}
        };

        public Tracker(SamusApi samusApi, WatchlistService watchlistService)
        {
            _samus = samusApi ?? throw new ArgumentNullException(nameof(samusApi));
            _watchlistService = watchlistService;
        } 


        public void DrawTo(GraphicsAdapter adaptedSurface)
        {
            _watchlistService.UpdateWatchlist(_watchlistService.SmOwnedItemWatches);
            _watchlistService.UpdateWatchlist(_watchlistService.SmEquippedItemWatches);
            
            CheckItemsStatuses();

            TrackerGraphicsEngine trackerGraphicsEngine = new(adaptedSurface, _smItems);
            trackerGraphicsEngine.CalculateGrid(adaptedSurface.Width, adaptedSurface.Height); 


            // foreach (Watch watch in _watchlistService.SmOwnedItemWatches)
            // {
            //     if (watch.ChangeCount > 0)
            //     {
            //         CheckItemsStatuses();
            //         Draw();
            //     }
            // }
            //
            // foreach (Watch watch in _watchlistService.SmEquippedItemWatches)
            // {
            //     if (watch.ChangeCount > 0)
            //     {
            //         CheckItemsStatuses();
            //         Draw();
            //     }
            // }


            _watchlistService.SmOwnedItemWatches.ClearChangeCounts();
            _watchlistService.SmEquippedItemWatches.ClearChangeCounts();


            trackerGraphicsEngine.Render();
        }


        private void CheckItemsStatuses()
        {
            //suits & misc
            _smItems.First(i => i.Name == "VariaSuit").Owned = _samus.HasSuits(SuitsAndMisc.VariaSuit);
            _smItems.First(i => i.Name == "VariaSuit").Equipped = _samus.AreSuitsEquipped(SuitsAndMisc.VariaSuit);

            _smItems.First(i => i.Name == "SpringBall").Owned = _samus.HasSuits(SuitsAndMisc.SpringBall);
            _smItems.First(i => i.Name == "SpringBall").Equipped = _samus.AreSuitsEquipped(SuitsAndMisc.SpringBall);

            _smItems.First(i => i.Name == "MorphingBall").Owned = _samus.HasSuits(SuitsAndMisc.MorphingBall);
            _smItems.First(i => i.Name == "MorphingBall").Equipped = _samus.AreSuitsEquipped(SuitsAndMisc.MorphingBall);

            _smItems.First(i => i.Name == "ScrewAttack").Owned = _samus.HasSuits(SuitsAndMisc.ScrewAttack);
            _smItems.First(i => i.Name == "ScrewAttack").Equipped = _samus.AreSuitsEquipped(SuitsAndMisc.ScrewAttack);

            _smItems.First(i => i.Name == "GravitySuit").Owned = _samus.HasSuits(SuitsAndMisc.GravitySuit);
            _smItems.First(i => i.Name == "GravitySuit").Equipped = _samus.AreSuitsEquipped(SuitsAndMisc.GravitySuit);


            // boots & rest
            _smItems.First(i => i.Name == "HiJumpBoots").Owned = _samus.HasBoots(BootsAndRest.HiJumpBoots);
            _smItems.First(i => i.Name == "HiJumpBoots").Equipped = _samus.AreBootsEquipped(BootsAndRest.HiJumpBoots);

            _smItems.First(i => i.Name == "SpaceJump").Owned = _samus.HasBoots(BootsAndRest.SpaceJump);
            _smItems.First(i => i.Name == "SpaceJump").Equipped = _samus.AreBootsEquipped(BootsAndRest.SpaceJump);

            _smItems.First(i => i.Name == "Bomb").Owned = _samus.HasBoots(BootsAndRest.Bomb);
            _smItems.First(i => i.Name == "Bomb").Equipped = _samus.AreBootsEquipped(BootsAndRest.Bomb);

            _smItems.First(i => i.Name == "SpeedBooster").Owned = _samus.HasBoots(BootsAndRest.SpeedBooster);
            _smItems.First(i => i.Name == "SpeedBooster").Equipped = _samus.AreBootsEquipped(BootsAndRest.SpeedBooster);

            _smItems.First(i => i.Name == "GrapplingBeam").Owned = _samus.HasBoots(BootsAndRest.GrapplingBeam);
            _smItems.First(i => i.Name == "GrapplingBeam").Equipped =
                _samus.AreBootsEquipped(BootsAndRest.GrapplingBeam);

            _smItems.First(i => i.Name == "XRayScope").Owned = _samus.HasBoots(BootsAndRest.XRayScope);
            _smItems.First(i => i.Name == "XRayScope").Equipped = _samus.AreBootsEquipped(BootsAndRest.XRayScope);

            // beams
            _smItems.First(i => i.Name == "WaveBeam").Owned = _samus.HasBeams(Beams.Wave);
            _smItems.First(i => i.Name == "WaveBeam").Equipped = _samus.AreBeamsEquipped(Beams.Wave);

            _smItems.First(i => i.Name == "IceBeam").Owned = _samus.HasBeams(Beams.Ice);
            _smItems.First(i => i.Name == "IceBeam").Equipped = _samus.AreBeamsEquipped(Beams.Ice);

            _smItems.First(i => i.Name == "SpazerBeam").Owned = _samus.HasBeams(Beams.Spazer);
            _smItems.First(i => i.Name == "SpazerBeam").Equipped = _samus.AreBeamsEquipped(Beams.Spazer);

            _smItems.First(i => i.Name == "PlasmaBeam").Owned = _samus.HasBeams(Beams.Plasma);
            _smItems.First(i => i.Name == "PlasmaBeam").Equipped = _samus.AreBeamsEquipped(Beams.Plasma);


            //Charge Beam
            _smItems.First(i => i.Name == "ChargeBeam").Owned = _samus.HasChargeBeam();
            _smItems.First(i => i.Name == "ChargeBeam").Equipped = _samus.IsChargeBeamEquipped();
        }
    }
}