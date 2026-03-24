namespace Application;

public class Program
{
	#region Methods

	public static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
			.ConfigureCmsDefaults()
			.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());

	public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

	#endregion
}