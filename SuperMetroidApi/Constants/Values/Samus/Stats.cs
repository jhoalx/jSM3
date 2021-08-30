namespace SuperMetroidApi.Constants.Values.Samus
{
    // not flags but actual values
    public enum SelectableItem : byte
    {
        None = 0,
        Missiles = 1,
        SuperMissiles = 2,
        PowerBomb = 3,
        GrapplingBeam = 4,
        XRayScope = 5
    }

    // not flags
    public enum ReserveSupplyMode : byte
    {
        NoReserve = 0,
        Auto = 1,
        Manual = 2
    }
}