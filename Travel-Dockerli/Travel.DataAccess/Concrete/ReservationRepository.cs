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
	public class ReservationRepository : IReservationRepository
	{
		public async Task<long> CreateReservationAsync(Reservation reservation)
		{
			using (AppContext db = new AppContext())
			{
				db.Reservations.Add(reservation);
				await db.SaveChangesAsync();
			}
			return reservation.Id;
		}

		public async Task<bool> DeleteReservationAsync(long reservationId)
		{
			var reservation = await GetReservationByIdAsync(reservationId);
			if (reservation != null)
			{
				using (AppContext db = new AppContext())
				{
					db.Reservations.Remove(reservation);
					await db.SaveChangesAsync();
				}
				return true;
			}
			return false;
		}

		public async Task<Reservation> GetReservationByIdAsync(long reservationId)
		{
			using (AppContext db = new AppContext())
			{
				return await db.Reservations.FindAsync(reservationId);
			}
		}

		public async Task<IEnumerable<Reservation>> GetReservationsAsync()
		{
			using (AppContext db = new AppContext())
			{
				return await db.Reservations.ToListAsync();
			}
		}

		public async Task<bool> UpdateReservationAsync(Reservation reservation)
		{
			var existingReservation = await GetReservationByIdAsync(reservation.Id);
			if (existingReservation != null)
			{
				using (AppContext db = new AppContext())
				{
					db.Reservations.Update(reservation);
					await db.SaveChangesAsync();
				}
				return true;
			}
			return false;
		}
	}
}
