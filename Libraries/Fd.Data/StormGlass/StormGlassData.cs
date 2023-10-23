using System.Net;
using Fd.Core;
using Fd.Data.Domain;
using Fd.Data.Domain.StormGlass;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Fd.Data.StormGlass
{
	public static class UnixDates
	{

		public static string SetDate(int dates) {
			var start = DateTime.UtcNow.Date;
			return  start.AddDays(dates).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
		}

	}

	public interface IStormGlassData
	{
	
		SolunarDeserialize? GetSolunar(string timeStart, string timeEnd, Location? location);
		DeserializeTide? GetTides(string timeStart, string timeEnd, Location? location);
		DeserializeWeather? GetWeather(string timeStart, string timeEnd, Location? location);
	}

	public class StormGlassData : IStormGlassData
	{
		// const string authorization = "97878a8e-2a46-11ec-bf3f-0242ac130002-97878b88-2a46-11ec-bf3f-0242ac130002";
		private const string
			AUTHORIZATION =
				"4e744e10-73f9-11ed-a654-0242ac130002-4e744e88-73f9-11ed-a654-0242ac130002"; //ftcalkias@gmail.com
		private const string SGURL = "https://api.stormglass.io/v2/";
		private ILogger<StormGlassData> _logger;

		public StormGlassData(ILogger<StormGlassData> logger) {
			_logger = logger;
		}

		public DeserializeWeather? GetWeather(string timeStart, string timeEnd, Location? location) {
			if(location == null) 
				return null;
			List<string> parameters = new List<string>() {
				"airTemperature",
				"airTemperature80m",
				"pressure",
				"cloudCover",
				"currentDirection",
				"currentSpeed",
				"gust",
				"seaLevel",
				"swellDirection",
				"swellHeight",
				"swellPeriod",
				"visibility",
				"waterTemperature",
				"waveDirection",
				"waveHeight",
				"wavePeriod",
				"windWaveDirection",
				"windSpeed",
			};
			var weatherToken =
				$"{SGURL}weather/point?lat={location.Lat.ToDotValue()}&lng={location.Lng.ToDotValue()}&params={string.Join(",",parameters)}&start={timeStart}&end={timeEnd}";
			//var weatherToken =
			//	$"{SGURL}weather/point?lat={location.Lat.ToDotValue()}&lng={location.Lng.ToDotValue()}&params=airTemperature,airTemperature80m,pressure,cloudCover,currentDirection,currentSpeed,gust,seaLevel,swellDirection,swellHeight,swellPeriod,visibility,waterTemperature,waveDirection,waveHeight,wavePeriod,windWaveDirection,windSpeed&start={timeStart}&end={timeEnd}";

			//return null;

			var response = GetFromStormGlass(weatherToken);
			if (response != string.Empty) {
				DeserializeWeather? weather = JsonConvert.DeserializeObject<DeserializeWeather>(response);

				return weather;
			}
			return null;
		}

		public SolunarDeserialize? GetSolunar(string timeStart, string timeEnd, Location? location) {

			if (location == null)
				return null;

			var astronomicalToken = $"{SGURL}astronomy/point?lat={location.Lat.ToDotValue()}&lng={location.Lng.ToDotValue()}&start={timeStart}&end{timeEnd}";

			var response = GetFromStormGlass(astronomicalToken);
			if (response != string.Empty) {
				SolunarDeserialize? solunar = JsonConvert.DeserializeObject<SolunarDeserialize>(response);

				return solunar;
			}
			return null;
		}

		public DeserializeTide? GetTides(string timeStart, string timeEnd, Location? location) {
			if (location == null)
				return null;

			var tidesToken = $"{SGURL}tide/extremes/point?lat={location.Lat.ToDotValue()}&lng={location.Lng.ToDotValue()}&start={timeStart}&end={timeEnd}";

			var response = GetFromStormGlass(tidesToken);

			if (response != string.Empty) {
				DeserializeTide? dataTide = JsonConvert.DeserializeObject<DeserializeTide>(response);

				return dataTide;
			}

			return null;
		}


		private string GetFromStormGlass(string token)
		{
			try {
				using var httpClient = new HttpClient();

				var request = new HttpRequestMessage(HttpMethod.Get, token);

				request.Headers.Add("Accept", "application/json");
				request.Headers.Add("Authorization", AUTHORIZATION);
				httpClient.Timeout = new TimeSpan(0, 0, 0, 24);

				var response = httpClient.Send(request);
				using var reader = new StreamReader(response.Content.ReadAsStream());
				var responseBody = reader.ReadToEnd();

				return responseBody;
			}
			catch (Exception ex) {
				_logger.LogError(ex.Message);
				return string.Empty;
			}
			
		}

		private static string GetFromStormGlassD(string token) {
			WebRequest request = WebRequest.Create(token);

			request.Method = "GET";
			request.Timeout = 24000;
			request.ContentType = "application/json";
			request.Headers.Add("Authorization", AUTHORIZATION);

			Stream sw = request.GetResponse().GetResponseStream();

			StreamReader swr = new StreamReader(sw);
			var response = swr.ReadToEnd();

			return response;
		}

	}
}