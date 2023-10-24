using Fd.Core;

namespace Fd.Data.Domain {
	public class SgData : BaseEntity
	{
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public string? Name { get; set; }

		public string? RowData { get; set; }

		public long LocationId { get; set; }
	}
}
