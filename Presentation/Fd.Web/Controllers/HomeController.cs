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




		public async Task<IActionResult>  Index()
		{

			//return View();

			var locs = await  _dataContext.Location.FindAsync((long)2);


			//assigns year, month, day
			var startDate = new DateTime(2023, 11, 9);
			var endDate = new DateTime(2023, 11,12);
			GetWetherData(startDate, endDate, locs);
			GetTidesData(startDate, endDate, locs);
			GetSolunarData(startDate, endDate, locs);

			var catcheDates = new List<DateTime> {
				new DateTime(2021, 10, 3, 9, 9, 44),
				new DateTime(2021, 10, 17, 20, 33, 53),
				new DateTime(2021, 10, 30, 14, 10, 48),
				new DateTime(2021, 11, 14, 12, 5, 55),
				new DateTime(2021, 11, 14, 12, 5, 55),
				new DateTime(2021, 11, 21, 9, 52, 31),
				new DateTime(2022, 11, 20, 15, 54, 29),
				new DateTime(2023, 10, 6, 8, 26, 36),
				new DateTime(2023, 10, 6, 9, 18, 1),
				new DateTime(2023, 10, 13, 18, 38, 54),
				new DateTime(2023, 10, 21, 7, 26, 13),
			};

			var cImg = new List<string>() {
				"20211003_090944.jpg",
				"20211017_203353.jpg",
				"20211030_141048.jpg",
				"20211114_120156.jpg",
				"20211121_095232.jpg",
				"20221120_155429.jpg",
				"20230618_173411.jpg",
				"20231006_082636.jpg",
				"20231006_091801.jpg",
				"20231013_183854.jpg",
				"20231021_072613.jpg",
			};

			var catches = new List<CatcheModel>();

			foreach (var catche in catcheDates) {
				catches.Add(new CatcheModel {
					FishTime = catche,
					Solunar = SolunarByDay(catche),
					Tide = TideByDay(catche),
					Whether = WhetherByDay(catche),
				});
			}

			for (var i = 0; i < catches.Count; i++) {
				catches[i].Image = cImg[i];
			}

			//var fishingDate = new DateTime(2021, 10, 17, 20, 33, 53);
			//var catchWhether = WhetherByDay(fishingDate);
			//var catchTide = TideByDay(fishingDate);
			//var catchSolunar = SolunarByDay(fishingDate);

			return View(catches);
		}

		private Solunar? SolunarByDay(DateTime fishingDate)
		{
			var solDates = _dataContext.Solunar.Select(x => x.Date!.Value).ToList();
			var solClosest = solDates.ArgMin(iTime => Math.Abs((iTime - fishingDate).Ticks));
			var fishinSolunar = _dataContext.Solunar.FirstOrDefault(x => x.Date == solClosest);

			return fishinSolunar;
		}

		private Tide? TideByDay(DateTime fishingDate)
		{
			var tideDates = _dataContext.Tide.Select(x => x.Date!.Value).ToList();
			var closestTimeDate = tideDates.ArgMin(iTime => Math.Abs((iTime - fishingDate).Ticks));
			var fishinTide = _dataContext.Tide.FirstOrDefault(x => x.Date == closestTimeDate);
			return fishinTide;
		}

		private Whether? WhetherByDay(DateTime fishingDate) {
			var weatherDates = _dataContext.Whether.Select(x => x.Date).ToList();
			var closestWeatherDate = weatherDates.ArgMin(iTime => Math.Abs((iTime - fishingDate).Ticks));
			var fishingWether = _dataContext.Whether.FirstOrDefault(x => x.Date == closestWeatherDate);
			return fishingWether;
		}

		private SolunarDeserialize? GetSolunarData(DateTime startDate, DateTime endDate, Location? location) {
            if (location == null) return null;

            var solunar = _stormGlassData.GetSolunar(startDate.Floor().ToUniversalTime().ToUnix(), endDate.Ceil().ToUniversalTime().ToUnix(), location);
			if (solunar != null) {
				foreach (var sol in solunar.data) {
					var s = new Solunar {
						Date = sol?.time,
						SunRise = sol?.sunrise,
						SunSet = sol?.sunset,
						MoonRise = sol?.moonrise,
						MoonSet = sol?.moonset,
						MoonFraction = sol?.moonFraction,
						CivilDawn = sol?.civilDawn,
						CivilDusk = sol?.civilDusk,
						MoonClosestName = sol?.moonPhase?.closest?.text,
						MoonClosestTime = sol?.moonPhase?.closest?.time,
						MoonClosestValue = sol?.moonPhase?.closest?.value,
						MoonCurrentName = sol?.moonPhase?.current?.text,
						MoonCurrentTime = sol?.moonPhase?.current?.time,
						MoonCurrenttValue = sol?.moonPhase?.current?.value,
						LocationId = location.Id
					};
					var exists =
						_dataContext.Solunar.FirstOrDefault(s =>
							s.Date == sol!.time && s.LocationId == location.Id);

					if (exists != null) {
						exists.Date = sol?.time;
						exists.SunRise = sol?.sunrise;
						exists.SunSet = sol?.sunset;
						exists.MoonRise = sol?.moonrise;
						exists.MoonSet = sol?.moonset;
						exists.MoonFraction = sol?.moonFraction;
						exists.CivilDawn = sol?.civilDawn;
						exists.CivilDusk = sol?.civilDusk;
						exists.MoonClosestName = sol?.moonPhase?.closest?.text;
						exists.MoonClosestTime = sol?.moonPhase?.closest?.time;
						exists.MoonClosestValue = sol?.moonPhase?.closest?.value;
						exists.MoonCurrentName = sol?.moonPhase?.current?.text;
						exists.MoonCurrentTime = sol?.moonPhase?.current?.time;
						exists.MoonCurrenttValue = sol?.moonPhase?.current?.value;
						exists.LocationId = location.Id;
						//_dataContext.Update(exists);
					}
					else {
						_dataContext.Solunar.Add(s);
					}
					
				}

				_dataContext.SaveChanges();
			}

			return solunar;
		}

		private DeserializeTide? GetTidesData(DateTime startDate, DateTime endDate, Location? location) {
            if (location == null) return null;
            
            var tides = _stormGlassData.GetTides(startDate.Floor().ToUniversalTime().ToUnix(), endDate.Ceil().ToUniversalTime().ToUnix(), location);
			if (tides != null && tides.data.Any()) {
				foreach (var tide in tides.data) {
					var t = new Tide {
						Height = tide?.height,
						Date = tide?.time,
						Type = tide?.type,
						LocationId = location.Id
					};
					//var exists = _dataContext.Tide.FirstOrDefault(x => x.Date == tide!.time && x.LocationId == location.Id);
					var exists = _dataContext.Tide.Where(x => x.Date == tide!.time && x.LocationId == location.Id).OrderBy(x=>x.Id).LastOrDefault();
					if (exists != null) {
                        exists.Height = 20;//tide?.height;
						exists.Date = tide?.time;
						exists.Type = tide?.type;
						exists.LocationId = location.Id;
						//_dataContext.Update(exists);
					}
                    else {
                        _dataContext.Tide.Add(t);
                    }
					
				}

				_dataContext.SaveChanges();
			}

			return tides;
		}

		private DeserializeWeather? GetWetherData(DateTime startDate, DateTime endDate, Location? location) {

			if(location==null) return null;

			var weather = _stormGlassData.GetWeather(startDate.Floor().ToUniversalTime().ToUnix(), endDate.Ceil().ToUniversalTime().ToUnix(), location);
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
						LocationId = location.Id,
					};
					// for ! (null-forgiving) operator see https://stackoverflow.com/questions/59230542/what-does-exclamation-mark-mean-before-invoking-a-method-in-c-sharp-8-0
					var exists = _dataContext.Whether.FirstOrDefault(x => x.Date == hour!.time && x.LocationId == location.Id);
					if (exists!=null) {
						exists.Date = hour.time;
						exists.AirTemperature = hour?.airTemperature?.sg;
						exists.Pressure = hour?.pressure?.sg;
						exists.CloudCover = hour?.cloudCover?.sg;
						exists.CurrentDirection = hour?.currentDirection?.sg;
						exists.CurrentSpeed = hour?.currentSpeed?.sg;
						exists.Gust = hour?.gust?.sg;
						exists.Humidity = hour?.humidity?.sg;
						exists.SeaLevel = hour?.seaLevel?.sg;
						exists.SwellDirection = hour?.swellDirection?.sg;
						exists.SwellHeight = hour?.swellHeight?.sg;
						exists.SwellPeriod = hour?.swellPeriod?.sg;
						exists.waterTemperature = hour?.waterTemperature?.sg;
						exists.waveDirection = hour?.waveDirection?.sg;
						exists.waveHeight = hour?.waveHeight?.sg;
						exists.wavePeriod = hour?.wavePeriod?.sg;
						exists.windDirection = hour?.windDirection?.sg;
						exists.windSpeed = hour?.windSpeed?.sg;
						exists.LocationId = location.Id;
						//_dataContext.Update(exists);
					}
					else {
						_dataContext.Whether.Add(w);
					}

				}

				_dataContext.SaveChanges();
			}

			return weather;
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