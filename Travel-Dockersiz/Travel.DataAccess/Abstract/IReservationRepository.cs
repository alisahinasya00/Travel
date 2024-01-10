using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Entities.Entities;

namespace Travel.DataAccess.Abstract
{
	public interface IReservationRepository
	{
		Task<long> CreateReservationAsync(Reservation reservation);
		Task<bool> DeleteReservationAsync(long reservationId);
		Task<IEnumerable<Reservation>> GetReservationsAsync();
		Task<Reservation> GetReservationByIdAsync(long reservationId);
		Task<bool> UpdateReservationAsync(Reservation reservation);
	}
}
