using Fd.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fd.Data {
	public class SeedData {
		public static void SeedDatabase(DataContext context)
		{
			context.Database.Migrate();

			if (!context.Location.Any())
			{

				context.AddRange(
					new Location
					{
						Name = "Φανερωμένη",
						District = "Σαλαμίνα",
						Lat = 37.984731,
						Lng = 23.427820
					},
					new Location
					{
						Name = "Λιβανάτες",
						District = "Φθιώτιδας",
						Lat = 38.711662,
						Lng = 23.065883
					},
					new Location
					{
						Name = "Ψαχνά",
						District = "Ευβοίας",
						Lat = 38.573562,
						Lng = 23.592069
					},
					new Location
					{
						Name = "Στυλίδα",
						District = "Φθιώτιδας",
						Lat = 38.910136,
						Lng = 22.616453
					}
				);

				context.SaveChanges();
			}
		}
	}
}
