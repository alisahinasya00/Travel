using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Business.DTOs.Holiday;

namespace Travel.Business.DTOs.Reservation
{
	public class ResponseReservationDTO
	{
		public long? Id { get; set; }
		public string? ContactName { get; set; }
		public string? PhoneNumber { get; set; }
		public ResponseHolidayDTO Holiday { get; set; }
	}
}
