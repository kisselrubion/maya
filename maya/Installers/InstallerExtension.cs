using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace maya.Installers
{
	public static class InstallerExtension
	{
		public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
		{
			var installers = typeof(Startup).Assembly.ExportedTypes.Where(c =>
				typeof(IInstaller).IsAssignableFrom(c) && !c.IsInterface && !c.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

			installers.ForEach(installer => installer.InstallServices(services, configuration));
		}
	}
}