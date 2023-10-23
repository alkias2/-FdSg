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

			if (!context.Location.Any()) {

				context.AddRange(
					new Location {
						Name = "Φανερωμένη",
						District = "Σαλαμίνα",
						Lat = 37.9852045790758,
						Lng = 23.431340317510962
					},
					new Location {
						Name = "Λιβανάτες",
						District = "Φθιώτιδας",
						Lat = 38.711662,
						Lng = 23.065883
					}
				);

				context.SaveChanges();
			}
		}
	}
}
