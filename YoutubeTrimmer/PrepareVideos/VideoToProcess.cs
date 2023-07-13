using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PrepareVideos
{
    internal class VideoToProcess
    {
        [JsonProperty("youtubeLink")]
        public string YoutubeLink { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("length")]
        public string Length { get; set; }
    }
}
