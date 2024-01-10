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
	public class HolidayRepository : IHolidayRepository
	{
		public async Task<long> CreateHolidayAsync(Holiday holiday)
		{
			using (AppContext db = new AppContext())
			{
				db.Holidays.Add(holiday);
				await db.SaveChangesAsync();
			}
			return holiday.Id;
		}

		public async Task<bool> DeleteHolidayAsync(long holidayId)
		{
			var holiday = await GetHolidayByIdAsync(holidayId);
			if (holiday != null)
			{
				using (AppContext db = new AppContext())
				{
					db.Holidays.Remove(holiday);
					await db.SaveChangesAsync();
				}
				return true;
			}
			return false;
		}

		public async Task<Holiday> GetHolidayByIdAsync(long holidayId)
		{
			using(AppContext db= new AppContext())
			{
				return await db.Holidays.FindAsync(holidayId);
			}

		}

		public async Task<IEnumerable<Holiday>> GetHolidaysAsync()
		{
			using (AppContext db = new AppContext())
			{
				return await db.Holidays.ToListAsync();
			}
		}

		public async Task<IEnumerable<Holiday>> GetHolidaysByFilter(string? location, DateTime startDate, int duration)
		{
			using (AppContext db = new AppContext())
			{
				var query = db.Holidays.Include(h => h.Location).AsQueryable();

				if (!string.IsNullOrEmpty(location))
				{
					query = query.Where(h => h.Location.City.ToLower() == location.ToLower());
				}

				if (!startDate.Equals(DateTime.MinValue))
				{
					query = query.Where(h => h.StartDate >= startDate);
				}

				if (duration != 0)
				{
					query = query.Where(h => h.Duration == duration);
				}

				var holidays = await query.ToListAsync();

				return holidays;
			}
		}

		public async Task<bool> UpdateHolidayAsync(Holiday holiday)
		{
			var existingHoliday = await GetHolidayByIdAsync(holiday.Id);
			if (existingHoliday != null)
			{
				using (AppContext db = new AppContext())
				{
					db.Holidays.Update(holiday);
					await db.SaveChangesAsync();
				}
				return true;
			}
			return false;
		}
	}
}
