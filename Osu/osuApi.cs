using Newtonsoft.Json;
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
        Mods getMod(Mods mods, ref string mod)
        {
            if (mod == "NF") mods = mods | Mods.NoFail;
            else if (mod == "EZ") mods = mods | Mods.Easy;
            else if (mod == "TD") mods = mods | Mods.TouchDevice;
            else if (mod == "HD") mods = mods | Mods.Hidden;
            else if (mod == "HR") mods = mods | Mods.Hardrock;
            else if (mod == "NC") mods = mods | Mods.Nightcore;
            else if (mod == "DT") mods = mods | Mods.DoubleTime;
            else if (mod == "HT") mods = mods | Mods.HalfTime;
            else if (mod == "FL") mods = mods | Mods.Flashlight;
            else mods = mods & Mods.NoMod;
            return mods;
        }
        public Mods CalculateModsMods(int enabled_mods)
        {
            Mods mods = new Mods();
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
        int CalculateMods(int enabled_mods)
        {
            int curmods = 0;
            for (int i = modsValues.Length / 2 - 1; i >= 0; i--)
            {
                if (enabled_mods == 0) break;
                if (int.Parse(modsValues[i, 0]) <= enabled_mods)
                {
                    if (modsValues[i, 1] == "HR" || modsValues[i, 1] == "DT" || modsValues[i, 1] == "NC")
                        curmods += int.Parse(modsValues[i, 0]);
                    enabled_mods -= int.Parse(modsValues[i, 0]);
                }
            }
            return curmods;
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
        public async Task<Beatmap> GetBeatmapByBeatmapIdAsync(long beatmap_id, int mods = 0)
        {
            return await Task.Run(() =>
            {
                using (WebClient wc = new WebClient())
                {
                    mods = CalculateMods(mods);
                    string doc = wc.DownloadString($"https://osu.ppy.sh/api/get_beatmaps?k={token}&b={beatmap_id}&mods={mods}");
                    if (doc.Length == 2) return null;
                    var data = JsonConvert.DeserializeObject<Beatmap[]>(doc)[0];
                    if (mods >= 576 || mods >= 64) data.bpm = (double.Parse(data.bpm) * 1.5).ToString(); 
                    return data;
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
