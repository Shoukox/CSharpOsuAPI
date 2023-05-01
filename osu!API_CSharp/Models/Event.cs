using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_API_CSharp.Types
{
    public partial class Event
    {
        [JsonProperty("display_html")]
        public string DisplayHtml { get; set; }

        [JsonProperty("beatmap_id")]
        public long BeatmapId { get; set; }

        [JsonProperty("beatmapset_id")]
        public long BeatmapsetId { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("epicfactor")]
        public long Epicfactor { get; set; }
    }
}
