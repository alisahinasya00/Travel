using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Entities.Entities;

namespace Travel.DataAccess
{
	public  class AppContext :DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer(@"Server=alisahinasya\SQLEXPRESS;Database=Travel;Integrated Security=True;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;");
		}


		public DbSet<Location> Locations { get; set; }
		public DbSet<Holiday> Holidays { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
	}
}
