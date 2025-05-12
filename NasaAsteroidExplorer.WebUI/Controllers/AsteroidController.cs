using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using NasaAsteroidExplorer.Application.Services;
using NasaAsteroidExplorer.Common;
using NasaAsteroidExplorer.Helpers;
using NasaAsteroidExplorer.WebUI.ViewModels;

namespace NasaAsteroidExplorer.Controllers
{
    public class AsteroidController : Controller
    {
        private readonly AsteroidManager _asteroidManager;

        public AsteroidController(AsteroidManager asteroidManager)
        {
            _asteroidManager = asteroidManager;
        }

        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, int page = 1, int pageSize = 10, bool? onlyHazardous = null, string search = null)
        {
            var start = startDate ?? DateTime.Today;
            var end = endDate ?? DateTime.Today.AddDays(7);

            var viewModel = new AsteroidViewModel
            {
                StartDate = start,
                EndDate = end
            };

            if ((end - start).TotalDays > 7)
            {
                viewModel.ErrorMessage = ErrorMessages.InvalidRange;
                return View(viewModel);
            }

            if (end < start)
            {
                viewModel.ErrorMessage = ErrorMessages.EndBeforeStart;
                return View(viewModel);
            }

            var asteroids = await _asteroidManager.GetAsteroidsAsync(start, end);
            if (asteroids.Count == 0)
            {
                viewModel.ErrorMessage = ErrorMessages.NoAsteroidsFound;
                return View(viewModel);
            }

            // Apply filtering if necessary
            if (onlyHazardous == true)
            {
                asteroids = asteroids.Where(a => a.IsHazardous).ToList();
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                asteroids = asteroids.Where(a => a.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Pagination logic
            var pagedAsteroids = asteroids
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            viewModel.Asteroids = pagedAsteroids;
            viewModel.Page = page;
            viewModel.TotalPages = (int)Math.Ceiling((double)asteroids.Count / pageSize);
            viewModel.OnlyHazardous = onlyHazardous;
            viewModel.Search = search;

            return View(viewModel);
        }

        public async Task<IActionResult> ExportToExcel(DateTime? startDate, DateTime? endDate, bool? onlyHazardous, string search)
        {
            var start = startDate ?? DateTime.Today;
            var end = endDate ?? DateTime.Today.AddDays(7);

            if ((end - start).TotalDays > 7 || end < start)
            {
                return BadRequest(ErrorMessages.InvalidExportRange);
            }

            var asteroids = await _asteroidManager.GetAsteroidsAsync(start, end);

            // Apply filtering
            if (onlyHazardous == true)
            {
                asteroids = asteroids.Where(a => a.IsHazardous).ToList();
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                asteroids = asteroids.Where(a => a.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            using var workbook = new XLWorkbook();
            var stream = ExcelExporter.ExportToExcel(asteroids);

            var fileName = $"asteroids_{start:yyyyMMdd}_{end:yyyyMMdd}.xlsx";

            return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileName);
        }
    }
}
