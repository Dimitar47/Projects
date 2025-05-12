using Newtonsoft.Json;

namespace NasaAsteroidExplorer.Domain.Entities
{
    public class Apod
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("explanation")]
        public string Explanation { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("hdurl")]
        public string HdUrl { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }
}
