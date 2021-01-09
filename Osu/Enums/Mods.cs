using System;

namespace tgbot_final.Bot.Osu.Enums
{
        [Flags]
        public enum Mods
        {
            NoMod = 0,
            NoFail = 1 << 0,
            Easy = 1 << 1,
            TouchDevice = 1 << 2,
            Hidden = 1 << 3,
            Hardrock = 1 << 4,
            DoubleTime = 1 << 6,
            HalfTime = 1 << 8,
            Nightcore = 1 << 9,
            Flashlight = 1 << 10,
            SpunOut = 1 << 12,
            SpeedChanging = DoubleTime | HalfTime | Nightcore,
            MapChanging = Hardrock | Easy | SpeedChanging,
        }

}
