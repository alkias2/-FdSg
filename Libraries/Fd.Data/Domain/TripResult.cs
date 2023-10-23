using System.ComponentModel.DataAnnotations;
using Fd.Core;

namespace Fd.Data.Domain {
	public class TripResult : BaseEntity {
		[Display(Name = "DiraryId")]
		public long DiraryId { get; set; }


		[Display(Name = "FishId")]
		public long FishId { get; set; }


		[Display(Name = "BaitId")]
		public long? BaitId { get; set; }


		[Display(Name = "Techinique")]
		public int Techinique { get; set; }


		[Display(Name = "Weight")]
		public double? Weight { get; set; }


		[Display(Name = "FightTime")]
		public double? FightTime { get; set; }


		[Display(Name = "Release")]
		public bool Release { get; set; }


		[Display(Name = "CatchTime")]
		public DateTime CatchTime { get; set; }
	}
}
