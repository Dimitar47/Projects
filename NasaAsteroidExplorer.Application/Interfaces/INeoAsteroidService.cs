using NasaAsteroidExplorer.Domain.Entities;

namespace NasaAsteroidExplorer.Application.Interfaces
{
    public interface INeoAsteroidService
    {
        Task<List<NeoAsteroid>> GetAsteroidsAsync(DateTime start, DateTime end);
    }
}
