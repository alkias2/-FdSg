using System.ComponentModel.DataAnnotations;
using Fd.Core;

namespace Fd.Data.Domain {
	public class Whether: BaseEntity
	{
		[Display(Name = "Date")]
		public DateTime Date { get; set; }
		/// <summary>
		/// Air temperature in degrees celsius
		/// </summary>
		public double? AirTemperature { get; set; }
		/// <summary>
		/// Air pressure in hPa
		/// </summary>
		public double? Pressure { get; set; }
		/// <summary>
		/// Total cloud coverage in percent
		/// </summary>
		public double? CloudCover { get; set; }
		/// <summary>
		/// Direction of current. 0° indicates current coming from north
		/// </summary>
		public double? CurrentDirection { get; set; }
		/// <summary>
		/// Speed of current in meters per second
		/// </summary>
		public double? CurrentSpeed { get; set; }
		/// <summary>
		/// Wind gust in meters per second
		/// </summary>
		public double? Gust { get; set; }
		/// <summary>
		/// Relative humidity in percent
		/// </summary>
		public double? Humidity { get; set; }
		/// <summary>
		/// Sea level relative to MSL
		/// </summary>
		public double? SeaLevel { get; set; }

		/// <summary>
		/// Direction of swell waves. 0° indicates swell coming from north
		/// </summary>
		public double? SwellDirection { get; set; }

		/// <summary>
		/// Height of swell waves in meters
		/// </summary>
		public double? SwellHeight { get; set; }

		/// <summary>
		/// Period of swell waves in seconds
		/// </summary>
		public double? SwellPeriod { get; set; }

		/// <summary>
		/// Water temperature in degrees celsius
		/// </summary>
		public double? waterTemperature { get; set; }

		/// <summary>
		/// Direction of combined wind and swell waves. 0° indicates waves coming from north
		/// </summary>
		public double? waveDirection { get; set; }

		/// <summary>
		/// Significant Height of combined wind and swell waves in meters
		/// </summary>
		public double? waveHeight { get; set; }

		/// <summary>
		/// Period of combined wind and swell waves in seconds
		/// </summary>
		public double? wavePeriod { get; set; }

		/// <summary>
		/// Direction of wind at 10m above sea level. 0° indicates wind coming from north
		/// </summary>
		public double? windDirection { get; set; }

		/// <summary>
		/// Speed of wind at 10m above sea level in meters per second.
		/// </summary>
		public double? windSpeed { get; set; }

		public long LocationId { get; set; }

	}
}
