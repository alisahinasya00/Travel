using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Entities.Entities;

namespace Travel.DataAccess
{
	public class AppContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);

			// Docker Compose'daki MySQL servisinin adını (mysql) ve port numarasını (3306) kullanarak bağlantı dizesini oluşturun.
			optionsBuilder.UseSqlServer("Server=mysql,3306;Database=Travel;User=alisahinasya;Password=123456;");
		}

		public DbSet<Location> Locations { get; set; }
		public DbSet<Holiday> Holidays { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
	}
}
