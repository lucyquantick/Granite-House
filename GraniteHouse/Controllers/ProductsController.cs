using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using GraniteHouse.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraniteHouse.Controllers
{

	[Area("Admin")]
	public class ProductsController : Controller
	{

		private readonly ApplicationDbContext _db;

		[BindProperty]
		public ProductsViewModel ProductsVm { get; set; }

		public ProductsController(ApplicationDbContext db)
		{
			_db = db;
			ProductsVm = new ProductsViewModel()
			{
				ProductTypes = _db.ProductTypes.ToList(),
				SpecialTags = _db.SpecialTags.ToList(),
				Products = new Models.Products()
			};
		}

		// GET index
		public async Task<IActionResult> Index()
		{
			var products = _db.Products.Include(mbox => mbox.ProductTypes).Include(mbox => mbox.SpecialTags);

			return View(await products.ToListAsync());
		}

	}
}