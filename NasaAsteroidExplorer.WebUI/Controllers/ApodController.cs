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

        public async Task<IActionResult> Index(DateTime? date)
        {
            if (date.HasValue && date.Value > DateTime.Today)
            {
                ViewBag.ErrorMessage = ErrorMessages.FutureDate;
                return View("Error");
            }
            try
            {
                var dto = await apodService.GetApodAsync(date);
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
