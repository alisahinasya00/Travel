using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travel.Entities.Abstract;

namespace Travel.Entities.Entities
{
	public class Location: IEntity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }

		[StringLength(50)]
		public string City { get; set; }
		
		[StringLength(50)] 
		public string Country { get; set; }


	}
}
