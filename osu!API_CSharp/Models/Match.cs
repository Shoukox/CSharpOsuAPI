using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using osu_API_CSharp.Types;

namespace osu_API_CSharp.Models
{
    public partial class MultiplayerMatch
    {
        [JsonProperty("match")]
        public Match? Match { get; set; }

        [JsonProperty("games")]
        public Game[]? Games { get; set; }
    }

    public partial class Game
    {
        [JsonProperty("game_id")]
        public long GameId { get; set; }

        [JsonProperty("start_time")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }

        [JsonProperty("beatmap_id")]
        public long BeatmapId { get; set; }

        [JsonProperty("play_mode")]
        public long PlayMode { get; set; }

        [JsonProperty("match_type")]
        public long MatchType { get; set; }

        [JsonProperty("scoring_type")]
        public long ScoringType { get; set; }

        [JsonProperty("team_type")]
        public long TeamType { get; set; }

        [JsonProperty("mods")]
        public long Mods { get; set; }

        [JsonProperty("scores")]
        public Score[] Scores { get; set; }
    }

    public partial class Match
    {
        [JsonProperty("match_id")]
        public long MatchId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("start_time")]
        public DateTime? StartTime { get; set; }

        [JsonProperty("end_time")]
        public DateTime? EndTime { get; set; }
    }
}
