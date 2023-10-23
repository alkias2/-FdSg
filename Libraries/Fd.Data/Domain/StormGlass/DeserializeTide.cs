namespace Fd.Data.Domain.StormGlass
{
	public class DeserializeTide
    {
	    public TideData[] data { get; set; }
        public TideMeta meta { get; set; }
    }
    public class TideData
    {
        public double? height { get; set; }
        public DateTime? time { get; set; }
        public string type { get; set; }
    }

    public class TideMeta
    {
	    public int? cost { get; set; }
	    public int? dailyQuota { get; set; }
	    public DateTime? end { get; set; }
	    public double? lat { get; set; }
	    public double? lng { get; set; }
	    public int? requestCount { get; set; }
	    public DateTime? start { get; set; }

        public TideStation station { get; set; }
	}

    public class TideStation
    {
	    public string? distance { get; set; }
	    public string? lat { get; set; }
	    public string? lng { get; set; }
	    public string? name { get; set; }
	    public string? source { get; set; }

	}
}
