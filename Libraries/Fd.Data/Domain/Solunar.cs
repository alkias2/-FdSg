using System.ComponentModel.DataAnnotations;
using Fd.Core;

namespace Fd.Data.Domain {
	public class Solunar : BaseEntity {

		[Display(Name = "Date")]
		public DateTime? Date { get; set; }
		
		/// <summary>
		/// Timestamp for sunrise in UTC.Will return null if no sunsrise occurs on the given day
		/// </summary>
		[Display(Name = "SunRise")]
		public DateTime? SunRise { get; set; }

		/// <summary>
		/// Timestamp for sunset in UTC. Will return null if no sunset occurs on the given day
		/// </summary>
		[Display(Name = "SunSet")]
		public DateTime? SunSet { get; set; }

		/// <summary>
		/// Timestamp for moonrise in UTC. Will return null if no moonrise occurs on the given day
		/// </summary>
		[Display(Name = "MoonRise")]
		public DateTime? MoonRise { get; set; }
		
		[Display(Name = "MoonSet")]
		public DateTime? MoonSet { get; set; }

		/// <summary>
		/// A float number between 0 and 1 indicating how much of the moon is illuminated
		/// </summary>
		public double? MoonFraction { get; set; }

		public DateTime? CivilDawn { get; set; }

		public DateTime? CivilDusk { get; set; }
		
		public string? MoonClosestName { get; set; } 
		public DateTime? MoonClosestTime { get; set; } 
		public double? MoonClosestValue { get; set; }

		public string? MoonCurrentName { get; set; }
		public DateTime? MoonCurrentTime { get; set; }
		public double? MoonCurrenttValue { get; set; }

		public long LocationId { get; set; }

	}
}
