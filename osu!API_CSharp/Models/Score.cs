using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_API_CSharp.Types
{
    public partial class Score
    {
        [JsonProperty("score_id")]
        public long ScoreId { get; set; }

        [JsonProperty("score")]
        public long ScoreCount { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("count300")]
        public long Count300 { get; set; }

        [JsonProperty("count100")]
        public long Count100 { get; set; }

        [JsonProperty("count50")]
        public long Count50 { get; set; }

        [JsonProperty("countmiss")]
        public long Countmiss { get; set; }

        [JsonProperty("maxcombo")]
        public long Maxcombo { get; set; }

        [JsonProperty("countkatu")]
        public long Countkatu { get; set; }

        [JsonProperty("countgeki")]
        public long Countgeki { get; set; }

        [JsonProperty("perfect")]
        public long? Perfect { get; set; }

        [JsonProperty("enabled_mods")]
        public long? EnabledMods { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("date")]
        public string? Date { get; set; }

        [JsonProperty("rank")]
        public string? Rank { get; set; }

        [JsonProperty("pp")]
        public string? PP { get; set; }

        [JsonProperty("replay_available")]
        public long? ReplayAvailable { get; set; }
    }
}
