using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_API_CSharp.Types
{
    public partial class User
    {
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("join_date")]
        public DateTimeOffset JoinDate { get; set; }

        [JsonProperty("count300")]
        public long Count300 { get; set; }

        [JsonProperty("count100")]
        public long Count100 { get; set; }

        [JsonProperty("count50")]
        public long Count50 { get; set; }

        [JsonProperty("playcount")]
        public long Playcount { get; set; }

        [JsonProperty("ranked_score")]
        public long RankedScore { get; set; }

        [JsonProperty("total_score")]
        public long TotalScore { get; set; }

        [JsonProperty("pp_rank")]
        public long PPRank { get; set; }

        [JsonProperty("level")]
        public double Level { get; set; }

        [JsonProperty("pp_raw")]
        public double PPRaw { get; set; }

        [JsonProperty("accuracy")]
        public string Accuracy { get; set; }

        [JsonProperty("count_rank_ss")]
        public long CountRankSs { get; set; }

        [JsonProperty("count_rank_ssh")]
        public long CountRankSsh { get; set; }

        [JsonProperty("count_rank_s")]
        public long CountRankS { get; set; }

        [JsonProperty("count_rank_sh")]
        public long CountRankSh { get; set; }

        [JsonProperty("count_rank_a")]
        public long CountRankA { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("total_seconds_played")]
        public long TotalSecondsPlayed { get; set; }

        [JsonProperty("pp_country_rank")]
        public long PPCountryRank { get; set; }

        [JsonProperty("events")]
        public Event[] Events { get; set; }
    }
}
