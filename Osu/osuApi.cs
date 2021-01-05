using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using tgbot_final.Bot.Osu.Enums;
using tgbot_final.Bot.Osu.Types;

namespace tgbot_final.Bot.Osu
{
    class osuApi
    {
        string token { get; set; }

        string[,] modsValues = new string[,]
{
                {"0","None"},
                {"1","NF"},
                {"2","EZ"},
                {"4","TD"},
                {"8","HD"},
                {"16","HR"},
                {"32","SD"},
                {"64","DT"},
                {"128","RX"},
                {"256","HT"},
                {"576","NC"},
                {"1024","FL"},
};
        public osuApi(string token)
        {
            this.token = token;
        }
        ModsClass.Mods getMod(ModsClass.Mods mods, ref string mod)
        {
            if (mod == "NF") mods = mods | ModsClass.Mods.NoFail;
            else if (mod == "EZ") mods = mods | ModsClass.Mods.Easy;
            else if (mod == "TD") mods = mods | ModsClass.Mods.TouchDevice;
            else if (mod == "HD") mods = mods | ModsClass.Mods.Hidden;
            else if (mod == "HR") mods = mods | ModsClass.Mods.Hardrock;
            else if (mod == "NC") mods = mods | ModsClass.Mods.Nightcore;
            else if (mod == "DT") mods = mods | ModsClass.Mods.DoubleTime;
            else if (mod == "HT") mods = mods | ModsClass.Mods.HalfTime;
            else if (mod == "FL") mods = mods | ModsClass.Mods.Flashlight;
            else mods = mods & ModsClass.Mods.NoMod;
            return mods;
        }
        public ModsClass.Mods CalculateModsMods(int enabled_mods)
        {
            ModsClass.Mods mods = new ModsClass.Mods();
            string curmods = "";
            for (int i = modsValues.Length / 2 - 1; i >= 0; i--)
            {
                if (enabled_mods == 0) break;
                if (int.Parse(modsValues[i, 0]) <= enabled_mods)
                {
                    curmods += modsValues[i, 1];
                    string mod = curmods.Substring(curmods.Length - 2, 2);
                    mods = getMod(mods, ref mod);
                    enabled_mods -= int.Parse(modsValues[i, 0]);
                }
            }
            return mods;
        }
        string CalculateMods(int enabled_mods)
        {
            if (enabled_mods == 0) return "+NoMod";
            else
            {
                string curmods = "";
                for (int i = modsValues.Length / 2 - 1; i >= 0; i--)
                {
                    if (enabled_mods == 0) break;
                    if (int.Parse(modsValues[i, 0]) <= enabled_mods)
                    {
                        curmods += modsValues[i, 1];
                        enabled_mods -= int.Parse(modsValues[i, 0]);
                    }
                }
                return "+" + curmods;
            }
        }
        public async Task<User> GetUserInfoByNameAsync(string name)
        {
            return await Task.Run(() =>
            {
                using (WebClient wc = new WebClient())
                {
                    string doc = wc.DownloadString($"https://osu.ppy.sh/api/get_user?k={token}&u={name}");
                    if (doc.Length == 2) return null;
                    doc = doc.Remove(0, 1).Remove(doc.IndexOf(",\"events\"") - 1, doc.Length - doc.IndexOf(",\"events\"")).Replace("\"", "'") + "}";
                    return JsonConvert.DeserializeObject<User>(doc);
                }
            });
        }
        public async Task<Score[]> GetTopPlaysByNameAsync(string name, int count = 5)
        {
            return await Task.Run(() =>
            {
                Score[] returndata;
                using (WebClient wc = new WebClient())
                {
                    string doc = wc.DownloadString($"https://osu.ppy.sh/api/get_user_best?k={token}&u={name}&limit={count}");
                    if (doc.Length == 2) return null;
                    returndata = JsonConvert.DeserializeObject<Score[]>(doc);
                }
                return returndata;
            });
        }
        public async Task<Score[]> GetRecentScoresByNameAsync(string name, int count = 1)
        {
            return await Task.Run(() =>
            {
                Score[] returndata;
                using (WebClient wc = new WebClient())
                { 
                    string doc = wc.DownloadString($"https://osu.ppy.sh/api/get_user_recent?k={token}&u={name}&limit={count}");
                    if (doc.Length == 2) return null;
                    returndata = JsonConvert.DeserializeObject<Score[]>(doc);
                }
                return returndata;
            });
        }
        public async Task<Beatmap> GetBeatmapByBeatmapIdAsync(long beatmap_id)
        {
            return await Task.Run(() =>
            {
                using (WebClient wc = new WebClient())
                {
                    string doc = wc.DownloadString($"https://osu.ppy.sh/api/get_beatmaps?k={token}&b={beatmap_id}");
                    if (doc.Length == 2) return null;
                    return JsonConvert.DeserializeObject<Beatmap[]>(doc)[0];
                }
            });
        }
        public async Task<Score[]> GetScoresOnMapByName(string name, long beatmap_id)
        {
            return await Task.Run(() =>
            {
                Score[] returndata;
                using (WebClient wc = new WebClient())
                {
                    string doc = wc.DownloadString($"https://osu.ppy.sh/api/get_scores?k={token}&u={name}&b={beatmap_id}");
                    if (doc.Length == 2) return null;
                    returndata = JsonConvert.DeserializeObject<Score[]>(doc);
                }
                return returndata;
            });
        }
    }

}
