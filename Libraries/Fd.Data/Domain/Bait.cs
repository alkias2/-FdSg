using System.ComponentModel.DataAnnotations;
using Fd.Core;

namespace Fd.Data.Domain {
	public class Bait : BaseEntity {
		[Display(Name = "Id")]
		public int Id { get; set; }


		[Display(Name = "Name")]
		public string Name { get; set; }


		[Display(Name = "Preparation")]
		public string Preparation { get; set; }
	}
}
