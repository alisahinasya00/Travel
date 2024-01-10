using Azure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Entities.Abstract;

namespace Travel.Entities.Entities
{
	public class Holiday: IEntity
	{
		[Key]
		public long Id { get; set; }

		[ForeignKey("Location")]
		public long? LocationId { get; set;}
        public Location Location { get; set; }

		[StringLength(100)]
		public string title { get; set; }
		public DateTime StartDate { get; set; }
		public int Price { get; set; }
		public int Duration { get; set; }


	}
}
