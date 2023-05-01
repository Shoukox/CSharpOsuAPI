using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace osu_API_CSharp.Models
{
    public partial class Replay
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("encoding")]
        public string Encoding { get; set; }
    }
}
