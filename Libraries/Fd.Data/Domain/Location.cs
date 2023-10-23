using System.ComponentModel.DataAnnotations;
using Fd.Core;

namespace Fd.Data.Domain {
	public class Location : BaseEntity {

		[Display(Name = "Name")]
		public string? Name { get; set; }

		[Display(Name = "District")]
		public string? District { get; set; }

		[Display(Name = "Lat")]
		public double? Lat { get; set; }

		[Display(Name = "Lng")]
		public double? Lng { get; set; }

		public IEnumerable<Solunar> Solunars { get; set; }
		public IEnumerable<Whether> Whethers { get; set; }
		public IEnumerable<Tide> Tides { get; set; }
		public IEnumerable<SgData> SgDatas { get; set; }

	}
}
