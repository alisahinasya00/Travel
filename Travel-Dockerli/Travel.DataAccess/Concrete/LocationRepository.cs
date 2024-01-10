using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.DataAccess.Abstract;
using Travel.Entities.Entities;

namespace Travel.DataAccess.Concrete
{
	public class LocationRepository : ILocationRepository
	{
		public async Task<long> CreateLocationAsync(Location location)
		{
			using (AppContext db = new AppContext())
			{

				db.Locations.Add(location);
				await db.SaveChangesAsync();
			}
			return location.Id;
		}

		public async Task<bool> DeleteLocationAsync(long locationId)
		{
			var location = await GetLocationByIdAsync(locationId);
			if (location != null)
			{
				using (AppContext db = new AppContext())
				{
					db.Locations.Remove(location);
					await db.SaveChangesAsync();
				}
				return true;
			}
			return false;
		}

		public async Task<Location> GetLocationByIdAsync(long locationId)
		{
			using (AppContext db = new AppContext())
			{
				return await db.Locations.FindAsync(locationId);
			}
		}

		public async Task<IEnumerable<Location>> GetLocationsAsync()
		{
			using (AppContext db = new AppContext())
			{
				return await db.Locations.ToListAsync();
			}
		}

		public async Task<long> UpdateLocationAsync(Location location)
		{
			using (AppContext db = new AppContext())
			{
				db.Locations.Entry(location).State = EntityState.Modified;
				await db.SaveChangesAsync();
			}
			return location.Id;
		}
	}
}
