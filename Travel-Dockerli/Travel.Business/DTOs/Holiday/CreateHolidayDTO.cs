using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Business.DTOs.Holiday
{
	public class CreateHolidayDTO
	{
		public string Title { get; set; }
		public DateTime? StartDate { get; set; }
		public int Price { get; set; }
		public int Location { get; set; }
	}
}
