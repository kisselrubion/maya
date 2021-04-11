using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace maya.Installers
{
	public class MvcInstaller : IInstaller
	{
		public void InstallServices(IServiceCollection services, IConfiguration configuration)
		{
			services.AddControllersWithViews();
			services.AddSwaggerGen(x => { x.SwaggerDoc("v1", new OpenApiInfo {Title = "Maya API", Version = "v1"}); });
		}
	}
}