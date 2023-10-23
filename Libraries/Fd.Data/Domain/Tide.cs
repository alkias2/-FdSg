using Fd.Core;

namespace Fd.Data.Domain {
	public class Tide:BaseEntity {
		public double? Height { get; set; }
		public DateTime? Date { get; set; }
		public string Type { get; set; }

		public long LocationId { get; set; }
	}
}
