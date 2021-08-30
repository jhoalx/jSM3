using System;
using System.Collections.Generic;
using BizHawk.Client.Common;
using BizHawk.Emulation.Common;
using SuperMetroidApi.Constants.Addresses.Samus;

namespace jSM3.Services
{
    public class WatchlistService
    {
        private readonly IMemoryDomains _memoryDomains;
        private readonly Config _globalConfig;

        public readonly WatchList SmOwnedItemWatches;
        public readonly WatchList SmEquippedItemWatches;

        
        public WatchlistService(string systemId, IMemoryDomains memoryDomains, Config globalConfig)
        {
            _memoryDomains = memoryDomains ?? throw new ArgumentNullException(nameof(memoryDomains));
            _globalConfig = globalConfig ?? throw new ArgumentNullException(nameof(globalConfig));
            
            SmOwnedItemWatches = new WatchList(memoryDomains, systemId);
            SmEquippedItemWatches = new WatchList(memoryDomains, systemId);

            _loadOwnedItemsWatches();
            _loadEquippedItemsWatches();
        }

        public void UpdateWatchlist(WatchList watches)
        {
            watches.UpdateValues(_globalConfig.RamWatchDefinePrevious);
        }

        public void ClearAllChangeCounts()
        {
            SmOwnedItemWatches.ClearChangeCounts();
            SmEquippedItemWatches.ClearChangeCounts();
        }
        
        private void _loadOwnedItemsWatches()
        {
            SmOwnedItemWatches.AddRange(
                new List<Watch>
                {
                    Watch.GenerateWatch(
                        _memoryDomains.SystemBus,
                        HaveInventory.SuitAndMisc,
                        WatchSize.Byte,
                        WatchDisplayType.Hex,
                        false,
                        "SuitAndMisc"
                    ),
                    Watch.GenerateWatch(
                        _memoryDomains.SystemBus,
                        HaveInventory.BootsAndRest,
                        WatchSize.Byte,
                        WatchDisplayType.Hex,
                        false,
                        "BootsAndRest"
                    ),
                    Watch.GenerateWatch(
                        _memoryDomains.SystemBus,
                        HaveInventory.Beams,
                        WatchSize.Byte,
                        WatchDisplayType.Hex,
                        false,
                        "Beams"
                    ),
                    Watch.GenerateWatch(
                        _memoryDomains.SystemBus,
                        HaveInventory.ChargeBeam,
                        WatchSize.Byte,
                        WatchDisplayType.Hex,
                        false,
                        "ChargeBeam"
                    )
                }
            );
        }
        
        private void _loadEquippedItemsWatches()
        {
            SmEquippedItemWatches.AddRange(
                new List<Watch>
                {
                    Watch.GenerateWatch(
                        _memoryDomains.SystemBus,
                        EquippedInventory.SuitAndMisc,
                        WatchSize.Byte,
                        WatchDisplayType.Hex,
                        false,
                        "SuitAndMisc"
                    ),
                    Watch.GenerateWatch(
                        _memoryDomains.SystemBus,
                        EquippedInventory.BootsAndRest,
                        WatchSize.Byte,
                        WatchDisplayType.Hex,
                        false,
                        "BootsAndRest"
                    ),
                    Watch.GenerateWatch(
                        _memoryDomains.SystemBus,
                        EquippedInventory.Beams,
                        WatchSize.Byte,
                        WatchDisplayType.Hex,
                        false,
                        "Beams"
                    ),
                    Watch.GenerateWatch(
                        _memoryDomains.SystemBus,
                        EquippedInventory.ChargeBeam,
                        WatchSize.Byte,
                        WatchDisplayType.Hex,
                        false,
                        "ChargeBeam"
                    )
                }
            );
        }
    }
}