using Newtonsoft.Json;

namespace NasaAsteroidExplorer.Domain.Entities
{
    public class NeoFeed
    {
        [JsonProperty("near_earth_objects")]
        public Dictionary<string, List<NeoAsteroid>> NearEarthObjects { get; set; }
    }
}
