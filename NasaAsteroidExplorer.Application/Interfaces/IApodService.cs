using NasaAsteroidExplorer.Application.DTOs;

namespace NasaAsteroidExplorer.Application.Interfaces
{
    public interface IApodService
    {
        Task<ApodDto> GetApodAsync(DateTime? date = null);
    }
}
