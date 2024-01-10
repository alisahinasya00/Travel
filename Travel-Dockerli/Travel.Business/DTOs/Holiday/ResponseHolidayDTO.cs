using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Business.DTOs.Location;

namespace Travel.Business.DTOs.Holiday
{
	public class ResponseHolidayDTO
	{
		public long? Id { get; set; }
		public string? Title { get; set; }
		public DateTime? StartDate { get; set; }
		public int? Price { get; set; }
		public ResponseLocationDTO Location { get; set; }
	}
}
