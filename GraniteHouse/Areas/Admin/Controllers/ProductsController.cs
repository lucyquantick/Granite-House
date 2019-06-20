﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using GraniteHouse.Models.ViewModel;
using GraniteHouse.Utility;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GraniteHouse.Controllers
{

	[Area("Admin")]
	public class ProductsController : Controller
	{

		private readonly ApplicationDbContext _db;
		private readonly HostingEnvironment _hostingEnvironment;

		[BindProperty]
		public ProductsViewModel ProductsVM { get; set; }

		public ProductsController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
		{
			_db = db;
			_hostingEnvironment = hostingEnvironment;
			ProductsVM = new ProductsViewModel()
			{
				ProductTypes = _db.ProductTypes.ToList(),
				SpecialTags = _db.SpecialTags.ToList(),
				Products = new Models.Products()
			};
		}

		// Index
		public async Task<IActionResult> Index()
		{
			var products = _db.Products.Include(mbox => mbox.ProductTypes).Include(mbox => mbox.SpecialTags);

			return View(await products.ToListAsync());
		}

		// Get : Products Create
		public IActionResult Create()
		{
			return View(ProductsVM);
		}

		// Post : Products Create
		[HttpPost,ActionName("Create")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreatePOST()
		{
			if (!ModelState.IsValid)
			{
				return View(ProductsVM);
			}

			_db.Products.Add(ProductsVM.Products);
			await _db.SaveChangesAsync();

			// Image being saved

			string webRootPath = _hostingEnvironment.WebRootPath;
			var files = HttpContext.Request.Form.Files;

			var productsFromDb = _db.Products.Find(ProductsVM.Products.Id);

			if (files.Count != 0)
			{
				// Image has been uploaded
				var uploads = Path.Combine(webRootPath, SD.ImageFolder);
				var extension = Path.GetExtension(files[0].FileName);

				// copy file uploaded to the server
				using (var filestream = new FileStream(Path.Combine(uploads, ProductsVM.Products.Id + extension), FileMode.Create))
				{
					files[0].CopyTo(filestream);
				}
				productsFromDb.Image = @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + extension;

			}
			else
			{
				// When user does not upload image
				var uploads = Path.Combine(webRootPath, SD.ImageFolder + @"\" + SD.DefaultProductImage);

				System.IO.File.Copy(uploads, webRootPath + @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + ".jpg");

				productsFromDb.Image = @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + ".jpg";
			}

			await _db.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}


		// GET : Edit
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			ProductsVM.Products = await _db.Products.Include(m => m.SpecialTags).Include(m => m.ProductTypes).SingleOrDefaultAsync(m => m.Id == id);

			if (ProductsVM.Products== null)
			{
				return NotFound();
			}
			return View(ProductsVM);
		}

		// POST : Edit
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id)
		{
			if (ModelState.IsValid)
			{
				string webRootPath = _hostingEnvironment.WebRootPath;
				var files = HttpContext.Request.Form.Files;

				var productFromDb = _db.Products.Where(m => m.Id == ProductsVM.Products.Id).FirstOrDefault();

				if (files.Count > 0 && files[0] != null)
				{
					// if user uploads a new image
					var uploads = Path.Combine(webRootPath, SD.ImageFolder);
					var extension_new = Path.GetExtension(files[0].FileName);
					var extension_old = Path.GetExtension(productFromDb.Image);

					if (System.IO.File.Exists(Path.Combine(uploads, ProductsVM.Products.Id + extension_old)))
					{
						System.IO.File.Delete(Path.Combine(uploads, ProductsVM.Products.Id + extension_old));
					}

					using (var filestream = new FileStream(Path.Combine(uploads, ProductsVM.Products.Id + extension_new), FileMode.Create))
					{
						files[0].CopyTo(filestream);
					}
					ProductsVM.Products.Image = @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + extension_new;

				}

				if(ProductsVM.Products.Image != null)
				{
					productFromDb.Image = ProductsVM.Products.Image;
				}

				productFromDb.Name = ProductsVM.Products.Name;
				productFromDb.Price = ProductsVM.Products.Price;
				productFromDb.Available = ProductsVM.Products.Available;
				productFromDb.ProductTypeId = ProductsVM.Products.ProductTypeId;
				productFromDb.SpecialTagId = ProductsVM.Products.SpecialTagId;
				productFromDb.ShadeColour = ProductsVM.Products.ShadeColour;

				await _db.SaveChangesAsync();

				return RedirectToAction(nameof(Index));

			}

			return View(ProductsVM);
		}

		// GET : Details
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			ProductsVM.Products = await _db.Products.Include(m => m.SpecialTags).Include(m => m.ProductTypes).SingleOrDefaultAsync(m => m.Id == id);

			if (ProductsVM.Products == null)
			{
				return NotFound();
			}
			return View(ProductsVM);
		}

	}
}