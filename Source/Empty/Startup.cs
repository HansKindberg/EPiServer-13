using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Data;
using EPiServer.DependencyInjection;
using EPiServer.Scheduler;
using EPiServer.Web.Routing;

namespace Application;

public class Startup(IWebHostEnvironment webHostingEnvironment)
{
	#region Fields

	private readonly IWebHostEnvironment _webHostingEnvironment = webHostingEnvironment ?? throw new ArgumentNullException(nameof(webHostingEnvironment));

	#endregion

	#region Methods

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		if(env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		app.UseStaticFiles();
		app.UseRouting();
		app.UseAuthentication();
		app.UseAuthorization();

		app.UseEndpoints(endpoints => { endpoints.MapContent(); });
	}

	public void ConfigureServices(IServiceCollection services)
	{
		if(this._webHostingEnvironment.IsDevelopment())
		{
			AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(this._webHostingEnvironment.ContentRootPath, "App_Data"));

			services.Configure<SchedulerOptions>(options => options.Enabled = false);
		}

		services.Configure<DataAccessOptions>(options => { options.UpdateDatabaseCompatibilityLevel = true; });

		services
			.AddCmsAspNetIdentity<ApplicationUser>()
			.AddCms()
			.AddAdminUserRegistration()
			.AddEmbeddedLocalization<Startup>();
	}

	#endregion
}