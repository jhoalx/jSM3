using System;

namespace SuperMetroidApi.Constants.Values.Samus
{
    [Flags]
    public enum SuitsAndMisc : byte
    {
        None = 0x00,
        VariaSuit = 0x01,
        SpringBall = 0x02,
        MorphingBall = 0x04,
        ScrewAttack = 0x08,
        GravitySuit = 0x20,
        All = 0x2F
    }

    [Flags]
    public enum BootsAndRest : byte
    {
        None = 0x00,
        HiJumpBoots = 0x01,
        SpaceJump = 0x02,
        Bomb = 0x10,
        SpeedBooster = 0x20,
        GrapplingBeam = 0x40,
        XRayScope = 0x80,
        All = 0xF3
    }

    [Flags]
    public enum Beams : byte
    {
        None = 0x00,
        Wave = 0x01,
        Ice = 0x02,
        Spazer = 0x04,
        Plasma = 0x08,
        All = 0x0F
    }

    [Flags]
    public enum ChargeBeam : byte
    {
        No = 0x00,
        Yes = 0x10
    }


    [Flags]
    public enum HyperBeam : byte
    {
        No = 0x00,
        Yes = 0x01
    }
}