using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fd.Data {
	//https://stackoverflow.com/questions/38705694/add-migration-with-different-assembly
	//https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
	/// <summary>
	/// Run commants in PS terminal
	/// dotnet ef migrations add InitialCreate
	/// dotnet ef database update
	/// </summary>
	public class DbContextFactory: IDesignTimeDbContextFactory<DataContext> {
		#region Implementation of IDesignTimeDbContextFactory<out DataContext>

		public DataContext CreateDbContext(string[] args) {
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var dbContextBuilder = new DbContextOptionsBuilder<DataContext>();

			var connectionString = configuration.GetConnectionString("DbConnection");

			dbContextBuilder.UseSqlServer(connectionString);

			return new DataContext(dbContextBuilder.Options);
		}

		#endregion
	}
}
