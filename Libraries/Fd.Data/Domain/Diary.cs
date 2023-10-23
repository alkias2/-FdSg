using System.ComponentModel.DataAnnotations;
using Fd.Core;

namespace Fd.Data.Domain {
	public class Diary : BaseEntity {

		[Display(Name = "LocationId")]
		public int? LocationId { get; set; }


		[Display(Name = "StartDate")]
		public DateTime? StartDate { get; set; }


		[Display(Name = "EndDate")]
		public DateTime? EndDate { get; set; }


		[Display(Name = "Notes")]
		public string Notes { get; set; }


		[Display(Name = "Bottomorph")]
		public string Bottomorph { get; set; }


		[Display(Name = "Success")]
		public bool? Success { get; set; }

		public IEnumerable<TripResult> TripResults { get; set; }
	}
}
