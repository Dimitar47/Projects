using Newtonsoft.Json;

namespace NasaAsteroidExplorer.Domain.Entities
{
    public class NeoAsteroid
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nasa_jpl_url")]
        public string Url { get; set; }

        [JsonProperty("absolute_magnitude_h")]
        public double Magnitude { get; set; }

        [JsonProperty("is_potentially_hazardous_asteroid")]
        public bool IsHazardous { get; set; }

    }
}
