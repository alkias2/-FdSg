using System.Net;
using Fd.Data.Domain;
using Fd.Data.Domain.StormGlass;
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
	
		SolunarDeserialize? GetSolunar();
		DeserializeTide? GetTides();
		DeserializeWeather? GetWeather(string timeStart, string timeEnd, Location? location);
	}

	public class StormGlassData : IStormGlassData
	{
		// const string authorization = "97878a8e-2a46-11ec-bf3f-0242ac130002-97878b88-2a46-11ec-bf3f-0242ac130002";
		private const string
			AUTHORIZATION =
				"4e744e10-73f9-11ed-a654-0242ac130002-4e744e88-73f9-11ed-a654-0242ac130002"; //ftcalkias@gmail.com
		private const string SGURL = "https://api.stormglass.io/v2/";

		const string lat = "lat=" + "37.9852045790758";
		const string lng = "lng=" + "23.431340317510962";

		public DeserializeWeather? GetWeather(string timeStart, string timeEnd, Location? location) {
			if(location == null) 
				return null;


			//var start = DateTime.UtcNow;
			var pStart = timeStart;// UnixDates.SetDate(-2);
			
			//var end = start.AddDays(7);
			var pEnd = timeEnd;// UnixDates.SetDate(7);

			

			var weatherToken =
				$"{SGURL}weather/point?lat={location.Lat.ToString()?.Replace(",", ".")}&lng={location.Lng.ToString()?.Replace(",", ".")}&params=airTemperature,airTemperature80m,pressure,cloudCover,currentDirection,currentSpeed,gust,seaLevel,swellDirection,swellHeight,swellPeriod,visibility,waterTemperature,waveDirection,waveHeight,wavePeriod,windWaveDirection,windSpeed&start={pStart}&end={pEnd}";

			//return null;

			var response = GetFromStormGlass(weatherToken);

			DeserializeWeather? weather = JsonConvert.DeserializeObject<DeserializeWeather>(response);

			return weather;
		}

		public SolunarDeserialize? GetSolunar() {

			//var start = DateTime.UtcNow;
			var pStart = UnixDates.SetDate(-2);//  start.AddDays(-2).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

			//var end = start.AddDays(7);
			var pEnd = UnixDates.SetDate(7); //end.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

			var astronomicalToken = $"{SGURL}astronomy/point?{lat}&{lng}&start={pStart}&end{pEnd}";

			var response = GetFromStormGlass(astronomicalToken);
			SolunarDeserialize? solunar = JsonConvert.DeserializeObject<SolunarDeserialize>(response);

			return solunar;
		}

		public DeserializeTide? GetTides() {

			//var start = DateTime.UtcNow;
			var pStart = UnixDates.SetDate(-2);//  start.AddDays(-2).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

			//var end = start.AddDays(7);
			var pEnd = UnixDates.SetDate(7); //end.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

			var tidesToken = $"{SGURL}tide/extremes/point?{lat}&{lng}&start={pStart}&end={pEnd}";

			var response = GetFromStormGlass(tidesToken);
			DeserializeTide? dataTide = JsonConvert.DeserializeObject<DeserializeTide>(response);

			return dataTide;
		}


		private static string GetFromStormGlass(string token)
		{
			using var httpClient = new HttpClient();

			var request = new HttpRequestMessage(HttpMethod.Get, token);

			request.Headers.Add("Accept", "application/json");
			request.Headers.Add("Authorization", AUTHORIZATION);
			httpClient.Timeout = new TimeSpan(0, 0, 0, 60);

			var response = httpClient.Send(request);

			using var reader = new StreamReader(response.Content.ReadAsStream());
			var responseBody = reader.ReadToEnd();

			return responseBody;
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