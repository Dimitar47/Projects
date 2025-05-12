using Microsoft.Extensions.Options;
using NasaAsteroidExplorer.Application.Configurations;
using NasaAsteroidExplorer.Application.DTOs;
using NasaAsteroidExplorer.Application.Interfaces;
using NasaAsteroidExplorer.Domain.Entities;
using Newtonsoft.Json;

namespace NasaAsteroidExplorer.Infrastructure.Services
{
    public class ApodService : IApodService
    {
        private readonly HttpClient _httpClient;
        private readonly NasaSettings _settings;


        public ApodService(HttpClient httpClient, IOptions<NasaSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<ApodDto> GetApodAsync(DateTime? date = null)
        {
            string url = $"{_settings.ApodUrl}?api_key={_settings.ApiKey}";
            if (date.HasValue)
                url += $"&date={date.Value:yyyy-MM-dd}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"NASA APOD API returned {(int)response.StatusCode} ({response.ReasonPhrase})");
            }

            var content = await response.Content.ReadAsStringAsync();
            
            var apod = JsonConvert.DeserializeObject<Apod>(content);

            if (apod is null)
            {
                throw new InvalidOperationException("Failed to deserialize APOD response.");
            }
            return new ApodDto
            {
                Title = apod.Title,
                Explanation = apod.Explanation,
                Url = apod.Url,
                HdUrl = apod.HdUrl,
                MediaType = apod.MediaType,
                Date = apod.Date
            };
        }
    }
                
}
