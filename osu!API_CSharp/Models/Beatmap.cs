using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using JsonConverter = Newtonsoft.Json.JsonConverter;
using JsonConverterAttribute = Newtonsoft.Json.JsonConverterAttribute;

namespace osu_API_CSharp.Types
{
    public partial class Beatmap
    {
        [JsonProperty("approved")]
        public long Approved { get; set; }

        [JsonProperty("submit_date")]
        public DateTimeOffset SubmitDate { get; set; }

        [JsonProperty("approved_date")]
        public DateTimeOffset ApprovedDate { get; set; }

        [JsonProperty("last_update")]
        public DateTimeOffset LastUpdate { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("beatmap_id")]
        public long BeatmapId { get; set; }

        [JsonProperty("beatmapset_id")]
        public long BeatmapsetId { get; set; }

        [JsonProperty("bpm")]
        public long Bpm { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }

        [JsonProperty("difficultyrating")]
        public string Difficultyrating { get; set; }

        [JsonProperty("diff_aim")]
        public double DiffAim { get; set; }

        [JsonProperty("diff_speed")]
        public double DiffSpeed { get; set; }

        [JsonProperty("diff_size")]
        public double DiffSize { get; set; }

        [JsonProperty("diff_overall")]
        public double DiffOverall { get; set; }

        [JsonProperty("diff_approach")]
        public double DiffApproach { get; set; }

        [JsonProperty("diff_drain")]
        public double DiffDrain { get; set; }

        [JsonProperty("hit_length")]
        public long HitLength { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("genre_id")]
        public long GenreId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("total_length")]
        public long TotalLength { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("file_md5")]
        public string FileMd5 { get; set; }

        [JsonProperty("mode")]
        public long Mode { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("favourite_count")]
        public long FavouriteCount { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("playcount")]
        public long Playcount { get; set; }

        [JsonProperty("passcount")]
        public long Passcount { get; set; }

        [JsonProperty("count_normal")]
        public long CountNormal { get; set; }

        [JsonProperty("count_slider")]
        public long CountSlider { get; set; }

        [JsonProperty("count_spinner")]
        public long CountSpinner { get; set; }

        [JsonProperty("max_combo")]
        public long MaxCombo { get; set; }

        [JsonProperty("storyboard")]
        public long Storyboard { get; set; }

        [JsonProperty("video")]
        public long Video { get; set; }

        [JsonProperty("download_unavailable")]
        public long DownloadUnavailable { get; set; }

        [JsonProperty("audio_unavailable")]
        public long AudioUnavailable { get; set; }
    }
}
