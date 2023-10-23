using Fd.Core;

namespace Fd.Data.Domain {
	public class SgData : BaseEntity
	{
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public string SgWhetherRowData { get; set; }
		public string SgSolunarRowData { get; set; }
		public string SgTideRowData { get; set; }

		public long LocationId { get; set; }
	}
}
