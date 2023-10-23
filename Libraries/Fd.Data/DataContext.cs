using System.Reflection;
using Fd.Core;
using Fd.Core.Infrastructure;
using Fd.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fd.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options)
			: base(options) { }

		public DbSet<Bait> Bait { get; set; }
		public DbSet<Diary> Diary { get; set; }
		public DbSet<Location> Location { get; set; }
		public DbSet<SgData> SgData { get; set; }
		public DbSet<Solunar> Solunar { get; set; }
		public DbSet<Tide> Tide { get; set; }
		public DbSet<TripResult> TripResult { get; set; }
		public DbSet<Whether> Whether { get; set; }
	}
}