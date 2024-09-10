using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencySystemNotification.Data.DatabaseService.DataContextFactory
{
	internal class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
	{
		public DataContextFactory() { }

		public DataContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
			optionsBuilder.UseSqlServer( "YOUR_CONNECTION_STRING_OR_CONFIG_FROM_JSON" );

			return new DataContext( optionsBuilder.Options );
		}
	}	
}
