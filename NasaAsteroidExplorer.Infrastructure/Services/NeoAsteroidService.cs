
using Microsoft.Extensions.Options;
using NasaAsteroidExplorer.Application.Configurations;
using NasaAsteroidExplorer.Application.Interfaces;
using NasaAsteroidExplorer.Domain.Entities;
using Newtonsoft.Json;

namespace NasaAsteroidExplorer.Infrastructure.Services
{
    public class NeoAsteroidService : INeoAsteroidService
    {
        private readonly HttpClient _httpClient;
        private readonly NasaSettings _settings;




        public NeoAsteroidService(HttpClient httpClient, IOptions<NasaSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<List<NeoAsteroid>> GetAsteroidsAsync(DateTime startDate, DateTime endDate)
        {

            string url = $"{_settings.NeoUrl}?start_date={startDate:yyyy-MM-dd}&end_date={endDate:yyyy-MM-dd}&api_key={_settings.ApiKey}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"NASA NEO API returned {(int)response.StatusCode} ({response.ReasonPhrase})");
            }

            var content = await response.Content.ReadAsStringAsync();
            var feed = JsonConvert.DeserializeObject<NeoFeed>(content);

            var allAsteroids = feed?.NearEarthObjects?.Values.SelectMany(list => list).ToList() ?? new();
            return allAsteroids;
            
          
        }
    }
}
