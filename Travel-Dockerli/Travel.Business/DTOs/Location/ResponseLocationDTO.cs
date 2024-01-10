using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel.Business.DTOs.Location
{
	public class ResponseLocationDTO
	{
		public long? Id { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
	}
}
