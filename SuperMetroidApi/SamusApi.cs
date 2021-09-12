using System;
using System.Linq;
using BizHawk.Client.Common;
using BizHawk.Emulation.Common;
using SuperMetroidApi.Constants.Addresses.Samus;
using SuperMetroidApi.Constants.Values.Samus;
using SuperMetroidApi.Services.Adapters;

namespace SuperMetroidApi
{
    public class SamusApi
    {
        private readonly IMemoryApi _memApi;
        
        private SmCheatsAdapter _smCheats { get; }

        public SamusApi(IMemoryApi? memApi, IMemoryDomains? memoryDomains, CheatCollection cheats)
        {
            /*
             * Create a new cheat list in memory (and never .Save() it) to avoid
             * overwriting the user's cheat list file for the game (if any) 
             */
            cheats.NewList("./SNES/Cheats/DeleteMe.cht", false);
            
            _memApi = memApi ?? throw new ArgumentNullException(nameof(memApi));
            _smCheats = new SmCheatsAdapter(cheats, memoryDomains ?? throw  new ArgumentException(nameof(memoryDomains)));
        }
        

        #region ############### Selected Item ###############

        private uint SelectedItem
        {
            get => _memApi.ReadByte(Stats.SelectedItem);
            set => _memApi.WriteByte(Stats.SelectedItem, value);
        }

        #endregion #############################################


        #region ############### Energy (Health) ###############

        /// <summary>
        ///     Samus Current Energy, Normal ingame Max is 1499
        ///     this value can be set to Max 32767 (0x7FFF) and if exceeded, causes Samus death
        /// </summary>
        private uint CurrentEnergy
        {
            get => _memApi.ReadU16(Stats.CurrentEnergy);
            set => _memApi.WriteU16(Stats.CurrentEnergy, value);
        }

        private uint CurrentEnergyMax
        {
            get => _memApi.ReadU16(Stats.CurrentEnergyMax);
            set => _memApi.WriteU16(Stats.CurrentEnergyMax, value);
        }

        private uint CurrentReserveEnergy
        {
            get => _memApi.ReadU16(Stats.CurrentReserveEnergy);
            set => _memApi.WriteU16(Stats.CurrentReserveEnergy, value);
        }

        private uint CurrentReserveEnergyMax
        {
            get => _memApi.ReadU16(Stats.CurrentReserveEnergyMax);
            set => _memApi.WriteU16(Stats.CurrentReserveEnergyMax, value);
        }

        private uint CurrentReserveSupplyMode
        {
            get => _memApi.ReadByte(Stats.ReserveSupplyMode);
            set => _memApi.WriteByte(Stats.ReserveSupplyMode, value);
        }

        #endregion #############################################

        #region ############### Have Inventory ###############

        private uint HaveSuitsAndMisc
        {
            get => _memApi.ReadByte(HaveInventory.SuitAndMisc);
            set => _memApi.WriteByte(HaveInventory.SuitAndMisc, value);
        }

        private uint HaveBootsAndRest
        {
            get => _memApi.ReadByte(HaveInventory.BootsAndRest);
            set => _memApi.WriteByte(HaveInventory.BootsAndRest, value);
        }

        private uint HaveBeams
        {
            get => _memApi.ReadByte(HaveInventory.Beams);
            set => _memApi.WriteByte(HaveInventory.Beams, value);
        }

        private uint HaveChargeBeam
        {
            get => _memApi.ReadByte(HaveInventory.ChargeBeam);
            set => _memApi.WriteByte(HaveInventory.ChargeBeam, value);
        }

        private uint HaveHyperBeam
        {
            get => _memApi.ReadByte(HaveInventory.HyperBeam);
            set => _memApi.WriteByte(HaveInventory.HyperBeam, value);
        }

        #endregion #############################################

        #region ############### Equipped Inventory ###############

        private uint EquippedSuitsAndMisc
        {
            get => _memApi.ReadByte(EquippedInventory.SuitAndMisc);
            set => _memApi.WriteByte(EquippedInventory.SuitAndMisc, value);
        }

        private uint EquippedBootsAndRest
        {
            get => _memApi.ReadByte(EquippedInventory.BootsAndRest);
            set => _memApi.WriteByte(EquippedInventory.BootsAndRest, value);
        }

        private uint EquippedBeams
        {
            get => _memApi.ReadByte(EquippedInventory.Beams);
            set => _memApi.WriteByte(EquippedInventory.Beams, value);
        }

        private uint EquippedChargeBeam
        {
            get => _memApi.ReadByte(EquippedInventory.ChargeBeam);
            set => _memApi.WriteByte(EquippedInventory.ChargeBeam, value);
        }

        #endregion #############################################

        #region ############### Missiles ###############

        private uint CurrentMissiles
        {
            get => _memApi.ReadU16(Stats.CurrentMissiles);
            set => _memApi.WriteU16(Stats.CurrentMissiles, value);
        }

        private uint CurrentMissilesMax
        {
            get => _memApi.ReadU16(Stats.CurrentMissilesMax);
            set => _memApi.WriteU16(Stats.CurrentMissilesMax, value);
        }

        #endregion #############################################

        #region ############### Super Missiles ###############

        private uint CurrentSuperMissiles
        {
            get => _memApi.ReadU16(Stats.CurrentSuperMissiles);
            set => _memApi.WriteU16(Stats.CurrentSuperMissiles, value);
        }

        private uint CurrentSuperMissilesMax
        {
            get => _memApi.ReadU16(Stats.CurrentSuperMissilesMax);
            set => _memApi.WriteU16(Stats.CurrentSuperMissilesMax, value);
        }

        #endregion #############################################

        #region ############### Power Bombs ###############

        private uint CurrentPowerBombs
        {
            get => _memApi.ReadU16(Stats.CurrentPowerBombs);
            set => _memApi.WriteU16(Stats.CurrentPowerBombs, value);
        }

        private uint CurrentPowerBombsMax
        {
            get => _memApi.ReadU16(Stats.CurrentPowerBombsMax);
            set => _memApi.WriteU16(Stats.CurrentPowerBombsMax, value);
        }

        #endregion #############################################


        #region ############### Energy Methods ###############

        /// <summary>
        ///     Returns a normalized value, Min 1, Max 1499:
        ///     In a normal playthrough with all tanks collected the max amount is 1499,
        ///     Min before death is 1
        /// </summary>
        /// <param name="quantity">The Energy value to check</param>
        /// <returns></returns>
        private static uint NormalizeEnergyValue(uint quantity)
        {
            return quantity switch
            {
                > 1499 => 1499,
                0 => 1,
                _ => quantity
            };
        }


        public uint GetEnergy()
        {
            return CurrentEnergy;
        }

        /// <summary>
        ///     Sets Samus energy to the supplied value.
        /// </summary>
        /// <param name="quantity">The value to set samus energy to, min: 1, max: 1499</param>
        public void SetEnergy(uint quantity)
        {
            CurrentEnergy = NormalizeEnergyValue(quantity);
        }

        public void AddEnergy(uint quantity)
        {
            CurrentEnergy = NormalizeEnergyValue(CurrentEnergy += quantity);
        }

        public void SubtractEnergy(uint quantity)
        {
            CurrentEnergy = NormalizeEnergyValue(CurrentEnergy -= quantity);
        }

        public void Die()
        {
            CurrentEnergy = 0;
        }

        public uint GetMaxEnergy()
        {
            return CurrentEnergyMax;
        }

        public uint GetCurrentReserveEnergy()
        {
            return CurrentReserveEnergy;
        }

        public uint GetCurrentMaxReserveEnergy()
        {
            return CurrentReserveEnergyMax;
        }

        public ReserveSupplyMode GetCurrentReserveSupplyMode()
        {
            return (ReserveSupplyMode)CurrentReserveSupplyMode;
        }

        private void HideReserveAutoIcon()
        {
            _memApi.WriteByte(0x7E3A8E, 0x46);
            _memApi.WriteByte(0x7E3A90, 0x47);
            _memApi.WriteByte(0x7E3A92, 0x48);
            _memApi.WriteByte(0x7E3A94, 0x49);
            _memApi.WriteByte(0x7EC618, 0x0F);
            _memApi.WriteByte(0x7EC61A, 0x0F);
            _memApi.WriteByte(0x7EC658, 0x0F);
            _memApi.WriteByte(0x7EC65A, 0x0F);
            _memApi.WriteByte(0x7EC698, 0x0F);
            _memApi.WriteByte(0x7EC699, 0x2C);
            _memApi.WriteByte(0x7EC69A, 0x0F);
            _memApi.WriteByte(0x7EC69B, 0x2C);
        }

        /// <summary>
        ///     Sets the current Reserve Supply Mode.
        ///     has no effect if samus doesn't have Reserve Tanks yet
        /// </summary>
        /// <param name="mode">
        ///     has no effect setting it to ReserveSupplyMode.NoReserve,
        /// </param>
        public void SetCurrentReserveSupplyMode(ReserveSupplyMode mode)
        {
            if (CurrentReserveEnergyMax == 0) return;
            if (mode == ReserveSupplyMode.NoReserve) return;
            /* When setting the Reserve supply mode to Manual from memory,
             * the onscreen 'Auto' icon doesn't hide, we do it manually */
            if (mode == ReserveSupplyMode.Manual) HideReserveAutoIcon();

            CurrentReserveSupplyMode = (uint)mode;
        }
        
        public void StartInvulnerability()
        {
            Cheat energyCheat = _smCheats.GetCheatByName(SmCheatsAdapter.CheatName.Energy);
            energyCheat.PokeValue((int)CurrentEnergy);
            energyCheat.Enable();
        }

        public void StopInvulnerability()
        {
            _smCheats.GetCheatByName(SmCheatsAdapter.CheatName.Energy).Disable();
        }

        #endregion

        #region ############### SuitAndMisc Methods ###############

        public bool HasSuits(SuitsAndMisc suits)
        {
            return (HaveSuitsAndMisc & (byte)suits) == (byte)suits;
        }

        public bool AreSuitsEquipped(SuitsAndMisc suits)
        {
            return (EquippedSuitsAndMisc & (byte)suits) == (byte)suits; 
        }

        public void GiveSuits(SuitsAndMisc suitsAndMisc)
        {
            HaveSuitsAndMisc |= (uint)suitsAndMisc;
        }

        public void TakeSuits(SuitsAndMisc suitsAndMisc)
        {
            HaveSuitsAndMisc &= ~(uint)suitsAndMisc;
        }

        public void EquipSuits(SuitsAndMisc suitsAndMisc)
        {
            EquippedSuitsAndMisc |= (uint)suitsAndMisc;
        }

        public void UnequipSuits(SuitsAndMisc suitsAndMisc)
        {
            EquippedSuitsAndMisc &= ~(uint)suitsAndMisc;
        }

        #endregion #############################################

        #region ############### BootsAndRest Methods ###############

        public bool HasBoots(BootsAndRest bootsAndRest)
        {
            return (HaveBootsAndRest & (byte)bootsAndRest) == (byte)bootsAndRest;
        }
        
        public bool AreBootsEquipped(BootsAndRest bootsAndRest)
        {
            return (EquippedBootsAndRest & (byte)bootsAndRest) == (byte)bootsAndRest;
        }

        public void GiveBoots(BootsAndRest bootsAndRest)
        {
            HaveBootsAndRest |= (uint)bootsAndRest;
        }

        public void TakeBoots(BootsAndRest bootsAndRest)
        {
            HaveBootsAndRest &= ~(uint)bootsAndRest;
        }

        public void EquipBoots(BootsAndRest bootsAndRest)
        {
            EquippedBootsAndRest |= (uint)bootsAndRest;
        }

        public void UnequipBoots(BootsAndRest bootsAndRest)
        {
            EquippedBootsAndRest &= ~(uint)bootsAndRest;
        }

        #endregion #############################################

        #region ############### Beams Methods ###############

        public bool HasBeams(Beams beams)
        {
            return (HaveBeams & (byte)beams) == (byte)beams;
        }
        
        public bool AreBeamsEquipped(Beams beams)
        {
            return (EquippedBeams & (byte)beams) == (byte)beams;
        }

        public void GiveBeams(Beams beams)
        {
            HaveBeams |= (uint)beams;
        }

        public void TakeBeams(Beams beams)
        {
            HaveBeams &= ~(uint)beams;
        }

        public void EquipBeams(Beams beams)
        {
            EquippedBeams |= (uint)beams;
        }

        public void UnequipBeams(Beams beams)
        {
            EquippedBeams &= ~(uint)beams;
        }

        #endregion #############################################

        #region ############### ChargeBeam Methods ###############

        public bool HasChargeBeam()
        {
            return (HaveChargeBeam & (byte)ChargeBeam.Yes) == (byte)ChargeBeam.Yes;
        }
        
        public bool IsChargeBeamEquipped()
        {
            return (EquippedChargeBeam & (byte)ChargeBeam.Yes) == (byte)ChargeBeam.Yes;
        }

        public void GiveChargeBeam()
        {
            HaveChargeBeam |= (uint)ChargeBeam.Yes;
        }

        public void TakeChargeBeam()
        {
            HaveChargeBeam &= (uint)ChargeBeam.No;
        }

        public void EquipChargeBeam()
        {
            EquippedChargeBeam |= (uint)ChargeBeam.Yes;
        }

        public void UnequipChargeBeam()
        {
            EquippedChargeBeam &= (uint)ChargeBeam.No;
        }

        #endregion

        #region ############### HyperBeam Methods ###############

        public bool HasHyperBeam()
        {
            return (HaveHyperBeam & (byte)HyperBeam.Yes) == (byte)HyperBeam.Yes;
        }

        /// <summary>
        ///     Gives Samus the Hyper Beam.
        ///     Note: The Hyper Beam overrules all other beams.
        /// </summary>
        public void GiveHyperBeam()
        {
            HaveHyperBeam |= (uint)HyperBeam.Yes;
        }

        public void TakeHyperBeam()
        {
            HaveHyperBeam &= (uint)HyperBeam.No;
        }

        #endregion

        #region ############### Missiles Methods ###############

        private uint NormalizeMissileQuantity(uint quantity)
        {
            return quantity > CurrentMissilesMax ? CurrentMissilesMax : quantity;
        }

        public uint GetMissileCount()
        {
            return CurrentMissiles;
        }

        public void SetMissileCount(uint quantity)
        {
            CurrentMissiles = NormalizeMissileQuantity(quantity);
        }

        public void AddMissiles(uint quantity)
        {
            CurrentMissiles += NormalizeMissileQuantity(quantity);
        }

        public void SubtractMissiles(uint quantity)
        {
            CurrentMissiles -= NormalizeMissileQuantity(quantity);
        }

        #endregion

        #region ############### SuperMissiles Methods ###############

        private uint NormalizeSuperMissileQuantity(uint quantity)
        {
            return quantity > CurrentSuperMissilesMax ? CurrentSuperMissilesMax : quantity;
        }

        public uint GetSuperMissileCount()
        {
            return CurrentSuperMissiles;
        }

        public void SetSuperMissileCount(uint quantity)
        {
            CurrentSuperMissiles = NormalizeSuperMissileQuantity(quantity);
        }

        public void AddSuperMissiles(uint quantity)
        {
            CurrentSuperMissiles += NormalizeSuperMissileQuantity(quantity);
        }

        public void SubtractSuperMissiles(uint quantity)
        {
            CurrentSuperMissiles -= NormalizeSuperMissileQuantity(quantity);
        }

        #endregion

        #region ############### PowerBombs Methods ###############

        private uint NormalizePowerBombQuantity(uint quantity)
        {
            return quantity > CurrentPowerBombsMax ? CurrentPowerBombsMax : quantity;
        }

        public uint GetPowerBombCount()
        {
            return CurrentPowerBombs;
        }

        public void SetPowerBombCount(uint quantity)
        {
            CurrentPowerBombs = NormalizePowerBombQuantity(quantity);
        }

        public void AddPowerBombs(uint quantity)
        {
            CurrentPowerBombs += NormalizePowerBombQuantity(quantity);
        }

        public void SubtractPowerBombs(uint quantity)
        {
            CurrentPowerBombs -= NormalizePowerBombQuantity(quantity);
        }

        #endregion

        #region ############### Selected Item Methods ###############

        public SelectableItem GetSelectedItem()
        {
            return (SelectableItem)SelectedItem;
        }

        public void SetSelectedItem(SelectableItem item)
        {
            SelectedItem = (uint)item;
        }

        #endregion
    }
}