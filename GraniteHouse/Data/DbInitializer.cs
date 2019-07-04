﻿using GraniteHouse.Models;
using GraniteHouse.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraniteHouse.Data
{
	public class DbInitializer : IDbInitializer
	{

		private readonly ApplicationDbContext _db;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_db = db;
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public async void Initialize()
		{
			_db.Database.Migrate();

			if (_db.Roles.Any(r => r.Name == SD.SuperAdminEndUser)) return;

			_roleManager.CreateAsync(new IdentityRole(SD.AdminEndUser)).GetAwaiter().GetResult();
			_roleManager.CreateAsync(new IdentityRole(SD.SuperAdminEndUser)).GetAwaiter().GetResult();

			_userManager.CreateAsync(new ApplicationUser
			{
				UserName = "admin@gmail.com",
				Email = "lucy@gmail.com",
				Name = "Lucy",
				EmailConfirmed = true
			}, "Admin123*").GetAwaiter().GetResult();

			await _userManager.AddToRoleAsync(await _userManager.FindByEmailAsync("admin@gmail.com"), SD.SuperAdminEndUser);
		}
	}
}
