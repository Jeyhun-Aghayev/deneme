using hacaton.DataAccess;
using hacaton.Hubs;
using hacaton.Models;
using hacaton.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace hacaton
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddIdentity<Employees, IdentityRole>(opt =>
			{
				opt.Password.RequireNonAlphanumeric = true;
				opt.Password.RequiredLength = 8;
				opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(3);
				opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
				opt.Lockout.MaxFailedAccessAttempts = 3;
			}).AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();


			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<AppDBContext>(opt =>
			{
				opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
			});

		
			
			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddSignalR();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication(); // İstifadəçi doğrulama prosesini aktivləşdiririk
			app.UseAuthorization();  // İstifadəçinin rolu və icazələrini idarə edirik
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Account}/{action=Login}/{id?}");
			app.MapControllerRoute(
			name: "areas",
			pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
		  );
			app.MapHub<ChatHub>("/chatHub");
			app.Run();
		}
	}
}
