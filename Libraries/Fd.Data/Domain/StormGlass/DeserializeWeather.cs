namespace Fd.Data.Domain.StormGlass
{
	public class DeserializeWeather
    {
        public SgWeather[] hours { get; set; }
        public WhetherMeta meta { get; set; }
    }

    public class SgWeather
    {
	    public DateTime time { get; set; }

        /// <summary>
        /// Air temperature in degrees celsius
        /// </summary>
        public Station airTemperature { get; set; }

        /// <summary>
        /// Air temperature at 80m above sea level in degrees celsius
        /// </summary>
        public Station airTemperature80m { get; set; }

        /// <summary>
        /// Air temperature at 100m above sea level in degrees celsius
        /// </summary>
        public Station airTemperature100m { get; set; }

        /// <summary>
        /// Air temperature at 1000hpa in degrees celsius
        /// </summary>
        public Station airTemperature1000hpa { get; set; }

        /// <summary>
        /// Air temperature at 800hpa in degrees celsius
        /// </summary>
        public Station airTemperature800hpa { get; set; }

        /// <summary>
        /// Air temperature at 500hpa in degrees celsius
        /// </summary>
        public Station airTemperature500hpa { get; set; }

        /// <summary>
        /// Air temperature at 200hpa in degrees celsius
        /// </summary>
        public Station airTemperature200hpa { get; set; }

        /// <summary>
        /// Air pressure in hPa
        /// </summary>
        public Station pressure { get; set; }

        /// <summary>
        /// Total cloud coverage in percent
        /// </summary>
        public Station cloudCover { get; set; }

        /// <summary>
        /// Direction of current. 0° indicates current coming from north
        /// </summary>
        public Station currentDirection { get; set; }

        /// <summary>
        /// Speed of current in meters per second
        /// </summary>
        public Station currentSpeed { get; set; }

        /// <summary>
        /// Wind gust in meters per second
        /// </summary>
        public Station gust { get; set; }

        /// <summary>
        /// Relative humidity in percent
        /// </summary>
        public Station humidity { get; set; }
        // Proportion, 0-1
        public Station iceCover { get; set; }

        /// <summary>
        /// Mean precipitation in kg/m²/h = mm/h
        /// </summary>
        public Station precipitation { get; set; }

        /// <summary>
        /// Depth of snow in meters
        /// </summary>
        public Station snowDepth { get; set; }

        /// <summary>
        /// Sea level relative to MSL
        /// </summary>
        public Station seaLevel { get; set; }

        /// <summary>
        /// Direction of swell waves. 0° indicates swell coming from north
        /// </summary>
        public Station swellDirection { get; set; }

        /// <summary>
        /// Height of swell waves in meters
        /// </summary>
        public Station swellHeight { get; set; }

        /// <summary>
        /// Period of swell waves in seconds
        /// </summary>
        public Station swellPeriod { get; set; }

        /// <summary>
        /// Direction of secondary swell waves. 0° indicates swell coming from north
        /// </summary>
        public Station secondarySwellPeriod { get; set; }

        /// <summary>
        /// Height of secondary swell waves in meters
        /// </summary>
        public Station secondarySwellDirection { get; set; }

        /// <summary>
        /// Period of secondary swell waves in seconds
        /// </summary>
        public Station secondarySwellHeight { get; set; }

        /// <summary>
        /// Horizontal visibility in km
        /// </summary>
        public Station visibility { get; set; }

        /// <summary>
        /// Water temperature in degrees celsius
        /// </summary>
        public Station waterTemperature { get; set; }

        /// <summary>
        /// Direction of combined wind and swell waves. 0° indicates waves coming from north
        /// </summary>
        public Station waveDirection { get; set; }

        /// <summary>
        /// Significant Height of combined wind and swell waves in meters
        /// </summary>
        public Station waveHeight { get; set; }

        /// <summary>
        /// Period of combined wind and swell waves in seconds
        /// </summary>
        public Station wavePeriod { get; set; }

        /// <summary>
        /// Direction of wind waves. 0° indicates waves coming from north
        /// </summary>
        public Station windWaveDirection { get; set; }

        /// <summary>
        /// Height of wind waves in meters
        /// </summary>
        public Station windWaveHeight { get; set; }

        /// <summary>
        /// Period of wind waves in seconds
        /// </summary>
        public Station windWavePeriod { get; set; }

        /// <summary>
        /// Direction of wind at 10m above sea level. 0° indicates wind coming from north
        /// </summary>
        public Station windDirection { get; set; }

        /// <summary>
        /// Direction of wind at 20m above sea level. 0° indicates wind coming from north
        /// </summary>
        public Station windDirection20m { get; set; }

        /// <summary>
        /// Direction of wind at 30m above sea level. 0° indicates wind coming from north
        /// </summary>
        public Station windDirection30m { get; set; }

        /// <summary>
        /// Direction of wind at 40m above sea level. 0° indicates wind coming from north
        /// </summary>
        public Station windDirection40m { get; set; }

        /// <summary>
        /// Direction of wind at 50m above sea level. 0° indicates wind coming from north
        /// </summary>
        public Station windDirection50m { get; set; }

        /// <summary>
        /// Direction of wind at 80m above sea level. 0° indicates wind coming from north
        /// </summary>
        public Station windDirection80m { get; set; }

        /// <summary>
        /// Direction of wind at 100m above sea level. 0° indicates wind coming from north
        /// </summary>
        public Station windDirection100m { get; set; }

        /// <summary>
        /// Direction of wind at 1000hpa. 0° indicates wind coming from north
        /// </summary>
        public Station windDirection1000hpa { get; set; }

        /// <summary>
        /// Direction of wind at 800hpa. 0° indicates wind coming from north
        /// </summary>
        public Station windDirection800hpa { get; set; }

        /// <summary>
        /// Direction of wind at 500hpa. 0° indicates wind coming from north
        /// </summary>
        public Station windDirection500hpa { get; set; }

        /// <summary>
        /// Direction of wind at 200hpa. 0° indicates wind coming from north
        /// </summary>
        public Station windDirection200hpa { get; set; }

        /// <summary>
        /// Speed of wind at 10m above sea level in meters per second.
        /// </summary>
        public Station windSpeed { get; set; }

        /// <summary>
        /// Speed of wind at 20m above sea level in meters per second.
        /// </summary>
        public Station windSpeed20m { get; set; }

        /// <summary>
        /// Speed of wind at 30m above sea level in meters per second.
        /// </summary>
        public Station windSpeed30m { get; set; }

        /// <summary>
        /// Speed of wind at 40m above sea level in meters per second.
        /// </summary>
        public Station windSpeed40m { get; set; }

        /// <summary>
        /// Speed of wind at 50m above sea level in meters per second.
        /// </summary>
        public Station windSpeed50m { get; set; }

        /// <summary>
        /// Speed of wind at 80m above sea level in meters per second.
        /// </summary>
        public Station windSpeed80m { get; set; }

        /// <summary>
        /// Speed of wind at 100m above sea level in meters per second.
        /// </summary>
        public Station windSpeed100m { get; set; }

        /// <summary>
        /// Speed of wind at 1000hpa in meters per second.
        /// </summary>
        public Station windSpeed1000hpa { get; set; }

        /// <summary>
        /// Speed of wind at 800hpa in meters per second.
        /// </summary>
        public Station windSpeed800hpa { get; set; }

        /// <summary>
        /// Speed of wind at 500hpa in meters per second.
        /// </summary>
        public Station windSpeed500hpa { get; set; }

        /// <summary>
        /// Speed of wind at 200hpa in meters per second.
        /// </summary>
        public Station windSpeed200hpa { get; set; }

    }

    public class Station {
		/// <summary>
		/// Germany’s National Meteorological Service, the Deutscher Wetterdienst
		/// </summary>
		public double? icon { get; set; }

		/// <summary>
		/// The National Oceanic and Atmospheric Administration
		/// </summary>
		public double? noaa { get; set; }

	    /// <summary>
	    /// Météo-France (meteo) French National Meteorological service
	    /// </summary>
		public double? meteo { get; set; }

		/// <summary>
		/// Germany’s National Meteorological Service, the Deutscher Wetterdienst
		/// </summary>
		public double? dwd { get; set; }

		/// <summary>
		/// Danish Defence Centre for Operational Oceanography
		/// </summary>
		public double? fcoo { get; set; }

		/// <summary>
		/// The Finnish Meteorological Institution
		/// </summary>
		public double? fmi { get; set; }

		/// <summary>
		/// Norwegian Meteorological Institute and NRK
		/// </summary>
		public double? yr { get; set; }

		/// <summary>
		/// Swedish Meteorological and Hydrological Institute
		/// </summary>
		public double? smhi { get; set; }
		/// <summary>
		/// Storm Glass AI is an intelligent global grid that automatically chooses the best SgWeather source depending on location.
		/// </summary>
		public double? sg { get; set; }
    }

    public class WhetherMeta
    {
	    public int? cost { get; set; }
	    public int? dailyQuota { get; set; }
	    public DateTime? end { get; set; }
	    public double? lat { get; set; }
	    public double? lng { get; set; }
	    public int? requestCount { get; set; }
	    public DateTime? start { get; set; }

	}
}


