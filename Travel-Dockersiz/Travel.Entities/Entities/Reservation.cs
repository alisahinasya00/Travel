﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Entities.Abstract;

namespace Travel.Entities.Entities
{
	public class Reservation :IEntity
	{
		[Key]
		public long Id { get; set; }
		[StringLength(50)]
		public string ContactName { get; set; }
		[StringLength(50)]
		public string PhoneNumber { get; set; }

		[ForeignKey("Holiday")]
		public long? HolidayId { get; set; }
		public Holiday Holiday { get; set; }
	}
}
