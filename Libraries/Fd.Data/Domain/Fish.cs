using System.ComponentModel.DataAnnotations;
using Fd.Core;

namespace Fd.Data.Domain {
	public class Fish: BaseEntity {

		[Display(Name = "Popular Name")]
		public string PopularName { get; set; }
		
		[Display(Name = "Scientific Name")]
		public string ScientificName { get; set; }

		[Display(Name = "Notes")]
		public string Notes { get; set; }

		[Display(Name = "Reference")]
		public string Url { get; set; }
	}
}
