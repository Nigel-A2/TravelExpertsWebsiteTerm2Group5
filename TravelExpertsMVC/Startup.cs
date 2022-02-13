using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelExpertsData;
using TravelExpertsMVC.Data;
using Microsoft.AspNetCore.Authentication.Cookies; // cookies authentication

namespace TravelExpertsMVC
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddDbContext<TravelExpertsContext>(options =>
			//	options.UseSqlServer(
			//		Configuration.GetConnectionString("DefaultConnection")));
			//services.AddDatabaseDeveloperPageExceptionFilter();
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme). //"Cookies"
			   AddCookie(opt => opt.LoginPath = "/Home/Login"); // what's the login page
			services.AddSession(); // need to use Session
			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStatusCodePages(); // more user friendly error pages for 404, 403 errors
			app.UseStaticFiles();
			app.UseRouting();
			app.UseAuthentication(); // needed
			app.UseAuthorization();
			app.UseSession(); // to use Session object
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
				//endpoints.MapRazorPages();
			});
		}
	}
}
