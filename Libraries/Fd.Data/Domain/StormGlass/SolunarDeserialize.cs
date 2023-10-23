namespace Fd.Data.Domain.StormGlass
{
	public class SolunarDeserialize
	{
		public SgSolunar[] data { get; set; }

		public SolunarMeta meta { get; set; }
	}



	public class SgSolunar {
		public DateTime? time { get; set; }
		public DateTime? astronomicalDawn { get; set; }
		public DateTime? astronomicalDusk { get; set; }
		public DateTime? civilDawn { get; set; }
		public DateTime? civilDusk { get; set; }
		public double? moonFraction { get; set; }
		public MoonFaceData moonPhase { get; set; }
		public DateTime? moonrise { get; set; }
		public DateTime? moonset { get; set; }
		public DateTime? nauticalDawn { get; set; }
		public DateTime? nauticalDusk { get; set; }
		public DateTime? sunrise { get; set; }
		public DateTime? sunset { get; set; }

	}

	public class MoonFaceData {
		public MoonPosition closest { get; set; }
		public MoonPosition current { get; set; }
	}

	public class MoonPosition {
		public string text { get; set; }
		public DateTime? time { get; set; }
		public double? value { get; set; }
	}
	public class SolunarMeta {
		public int? cost { get; set; }
		public int? dailyQuota { get; set; }
		public DateTime? end { get; set; }
		public double? lat { get; set; }
		public double? lng { get; set; }
		public int? requestCount { get; set; }
		public DateTime? start { get; set; }

	}
}