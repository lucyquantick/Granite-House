using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Models
{
	public class ProductTypes
	{
		// This Id is a primary key so is [Required] by default, it will be generated automatically by the DB
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}
