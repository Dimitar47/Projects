using NasaAsteroidExplorer.Application.DTOs;
using NasaAsteroidExplorer.Application.Interfaces;

namespace NasaAsteroidExplorer.Application.Services
{
    public class AsteroidManager
    {
        private readonly INeoAsteroidService _asteroidService;

        public AsteroidManager(INeoAsteroidService asteroidService)
        {
            _asteroidService = asteroidService;
        }

        public async Task<List<NeoAsteroidDto>> GetAsteroidsAsync(DateTime start, DateTime end)
        {
            var rawAsteroids = await _asteroidService.GetAsteroidsAsync(start, end);
            return rawAsteroids.Select(a => new NeoAsteroidDto
            {
                Name = a.Name,
                Url = a.Url,
                Magnitude = a.Magnitude,
                IsHazardous = a.IsHazardous
            }).ToList();
        }
    }
}
