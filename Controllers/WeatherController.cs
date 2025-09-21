using Microsoft.AspNetCore.Mvc;
using StreamlitLikeApp.Repositories;
using StreamlitLikeApp.Models;

namespace StreamlitLikeApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(IWeatherRepository weatherRepository, ILogger<WeatherController> logger)
        {
            _weatherRepository = weatherRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var forecasts = await _weatherRepository.GetWeatherForecastAsync();
                var model = new WeatherViewModel
                {
                    Forecasts = forecasts
                };
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading weather data");
                return View(new WeatherViewModel());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherData()
        {
            try
            {
                var forecasts = await _weatherRepository.GetWeatherForecastAsync();
                return Json(forecasts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching weather data via API");
                return Json(new { error = "Failed to fetch weather data" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherByDate(DateTime date)
        {
            try
            {
                var weather = await _weatherRepository.GetWeatherByDateAsync(date);
                if (weather == null)
                {
                    return NotFound();
                }
                return Json(weather);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching weather for date {Date}", date);
                return Json(new { error = "Failed to fetch weather data" });
            }
        }
    }
}