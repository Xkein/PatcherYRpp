﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatcherYRpp
{
    public enum DamageAreaResult
    {
        Hit = 0,
        Missed = 1,
        Nullified = 2
    };

    public enum SpotlightFlags
    {
        None = 0x0,
        NoColor = 0x1,
        NoRed = 0x2,
        NoGreen = 0x4,
        NoBlue = 0x8
    };
    public enum LandType
    {
        Clear = 0,
        Road = 1,
        Water = 2,
        Rock = 3,
        Wall = 4,
        Tiberium = 5,
        Beach = 6,
        Rough = 7,
        Ice = 8,
        Railroad = 9,
        Tunnel = 10,
        Weeds = 11
    };

    public enum Layer
    {
        None = -1,
        Underground = 0,
        Surface = 1,
        Ground = 2,
        Air = 3,
        Top = 4
    };
}
