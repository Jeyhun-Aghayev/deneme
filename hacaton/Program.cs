using hacaton.DataAccess;
using hacaton.Hubs;
using Microsoft.EntityFrameworkCore;

namespace hacaton
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDBContext>(opt => { opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")); });

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

			app.UseAuthorization();
			app.MapControllerRoute(
			name: "areas",
			pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
		  );
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapHub<ChatHub>("/chatHub");
			app.Run();
		}
	}
}
