using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DynamicPatcher;

namespace PatcherYRpp
{
    [StructLayout(LayoutKind.Explicit, Size = 111)]
    public struct EventClass
    {

    }

    public enum EventType
    {
        EMPTY = 0,
        POWERON = 1,
        POWEROFF = 2,
        ALLY = 3,
        MEGAMISSION = 4,
        MEGAMISSION_F = 5,
        IDLE = 6,
        SCATTER = 7,
        DESTRUCT = 8,
        DEPLOY = 9,
        DETONATE = 10,
        PLACE = 11,
        OPTIONS = 12,
        GAMESPEED = 13,
        PRODUCE = 14,
        SUSPEND = 15,
        ABANDON = 16,
        PRIMARY = 17,
        SPECIAL_PLACE = 18,
        EXIT = 19,
        ANIMATION = 20,
        REPAIR = 21,
        SELL = 22,
        SELLCELL = 23,
        SPECIAL = 24,
        FRAMESYNC = 25,
        MESSAGE = 26,
        RESPONSTIME = 27,
        FRAMEINFO = 28,
        SAVEGAME = 29,
        ARCHIVE = 30,
        ADDPLAYER = 31,
        TIMING = 32,
        PROCESS_TIME = 33,
        PAGEUSER = 34,
        REMOVEPLAYER = 35,
        LATENCYFUDGE = 36,
        MEGAFRAMEINFO = 37,
        PACKETTIMING = 38,
        ABOUTTOEXIT = 39,
        FALLBACKHOST = 40,
        ADDRESSCHANGE = 41,
        PLANCONNECT = 42,
        PLANCOMMIT = 43,
        PLANNODEDELETE = 44,
        ALLCHEER = 45,
        ABANDON_ALL = 46,
        LAST_EVENT = 47
    }
}
