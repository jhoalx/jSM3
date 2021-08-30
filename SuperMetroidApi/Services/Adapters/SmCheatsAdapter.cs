using System;
using System.Collections.Generic;
using System.Linq;
using BizHawk.Client.Common;
using BizHawk.Emulation.Common;
using SuperMetroidApi.Constants.Addresses.Samus;

namespace SuperMetroidApi.Services.Adapters
{
    public class SmCheatsAdapter
    {
        private readonly CheatCollection _cheats;
        private readonly IMemoryDomains _memoryDomains;

        public SmCheatsAdapter( CheatCollection cheats,  IMemoryDomains memoryDomains)
        {
            _cheats = cheats ?? throw new ArgumentNullException(nameof(cheats));
            _memoryDomains = memoryDomains ?? throw new ArgumentNullException(nameof(memoryDomains));
            Load();
        }


        public enum CheatName
        {
            Energy,
            EnergyReserve
        }


        public void DisableAll()
        {
            _cheats.DisableAll();
        }

        public Cheat GetCheatByName(CheatName cheatName)
        {
            return _cheats.First(c => c.Name == cheatName.ToString());
        }

        private void Load()
        {
            // in case i would like to load cheats from storage
            //   cheats.Load(memoryDomains, "./ExternalTools/jSM3/Cheats/SMCheats.cht", false);

            _cheats.AddRange(
                new List<Cheat>
                {
                    new(
                        Watch.GenerateWatch(
                            _memoryDomains.SystemBus,
                            Stats.CurrentEnergy,
                            WatchSize.Word,
                            WatchDisplayType.Unsigned,
                            false,
                            CheatName.Energy.ToString()
                        ),
                        99,
                        null,
                        false
                    ),
                    new(
                        Watch.GenerateWatch(
                            _memoryDomains.SystemBus,
                            Stats.CurrentReserveEnergy,
                            WatchSize.Word,
                            WatchDisplayType.Unsigned,
                            false,
                            CheatName.EnergyReserve.ToString()
                        ),
                        99,
                        null,
                        false
                    )
                }
            );
        }
    }
}