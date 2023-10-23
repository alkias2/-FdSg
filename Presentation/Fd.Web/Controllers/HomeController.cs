using System.Diagnostics;
using Fd.Core;
using Fd.Core.Infrastructure;
using Fd.Data;
using Fd.Data.Domain;
using Fd.Data.Domain.StormGlass;
using Fd.Data.StormGlass;
using Fd.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fd.Web.Controllers {
	public class HomeController : Controller {
		private readonly ILogger<HomeController> _logger;
		private readonly IStormGlassData _stormGlassData;
		private readonly DataContext _dataContext;

		public HomeController(ILogger<HomeController> logger, IStormGlassData stormGlassData, DataContext dataContext) {
			_logger = logger;
			_stormGlassData = stormGlassData;
			_dataContext = dataContext;
		}

		public IActionResult Index() {

			var locs = _dataContext.Location.ToList();

			//var mapperConfigurations = typeFinder.FindClassesOfType<BaseEntity>();

			var weather = _stormGlassData.GetWeather(UnixDates.SetDate(-2), UnixDates.SetDate(-1), locs.First());
			if (weather != null && weather.hours.Any()) {
				foreach (var hour in weather.hours) {
					var w = new Whether {
						Date = hour.time,
						AirTemperature = hour?.airTemperature?.sg,
						Pressure = hour?.pressure?.sg,
						CloudCover = hour?.cloudCover?.sg,
						CurrentDirection = hour?.currentDirection?.sg,
						CurrentSpeed = hour?.currentSpeed?.sg,
						Gust = hour?.gust?.sg,
						Humidity = hour?.humidity?.sg,
						SeaLevel = hour?.seaLevel?.sg,
						SwellDirection = hour?.swellDirection?.sg,
						SwellHeight = hour?.swellHeight?.sg,
						SwellPeriod = hour?.swellPeriod?.sg,
						waterTemperature = hour?.waterTemperature?.sg,
						waveDirection = hour?.waveDirection?.sg,
						waveHeight = hour?.waveHeight?.sg,
						wavePeriod = hour?.wavePeriod?.sg,
						windDirection = hour?.windDirection?.sg,
						windSpeed = hour?.windSpeed?.sg,
						LocationId = locs.First().Id,
					};
					_dataContext.Whether.Add(w);
				}

				_dataContext.SaveChanges();

			}


			//var tides = _stormGlassData.GetTides();
			//var solunar = _stormGlassData.GetSolunar();

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}