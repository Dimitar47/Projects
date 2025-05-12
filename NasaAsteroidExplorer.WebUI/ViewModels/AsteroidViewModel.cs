using NasaAsteroidExplorer.Application.DTOs;

namespace NasaAsteroidExplorer.WebUI.ViewModels
{
    public class AsteroidViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ErrorMessage { get; set; }
        public List<NeoAsteroidDto> Asteroids { get; set; } = new();
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public bool? OnlyHazardous { get; set; }
        public string Search { get; set; }
    }
}
