using Microsoft.AspNetCore.Mvc;
using NasaAsteroidExplorer.Application.Interfaces;
using NasaAsteroidExplorer.Common;
using NasaAsteroidExplorer.WebUI.ViewModels;

namespace NasaAsteroidExplorer.Controllers
{
    public class ApodController : Controller
    {
        private readonly IApodService apodService;

        public ApodController(IApodService _apodService)
        {
            apodService = _apodService;
        }

        public async Task<IActionResult> Index(string? routeDate, string? date)
        {
            var rawDate = date ?? routeDate;

            if (string.IsNullOrWhiteSpace(rawDate))
            {
                rawDate = DateTime.Today.ToString("yyyy-MM-dd");
            }

            if (!DateTime.TryParse(rawDate, out var parsedDate))
            {
                ViewBag.ErrorMessage = "Invalid date format.";
                return View("Error");
            }

            if (parsedDate > DateTime.Today)
            {
                ViewBag.ErrorMessage = ErrorMessages.FutureDate;
                return View("Error");
            }

            try
            {
                var dto = await apodService.GetApodAsync(parsedDate);
                var viewModel = new ApodViewModel
                {
                    Title = dto.Title,
                    Explanation = dto.Explanation,
                    Url = dto.Url,
                    HdUrl = dto.HdUrl,
                    MediaType = dto.MediaType,
                    Date = dto.Date
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ErrorMessages.ApiFailed + ex.Message;
                return View("Error");
            }
        }

    }
}
