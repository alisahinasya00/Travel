using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Business.DTOs.Holiday
{
	public class UpdateHolidayDTO
	{
		public long? Id { get; set; }
		public string Title { get; set; }
		public DateTime? StartDate { get; set; }
		public int Price { get; set; }

		public long Location { get; set; }
	}
}
