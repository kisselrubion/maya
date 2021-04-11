using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace maya.Installers
{
	public interface IInstaller
	{
		void InstallServices(IServiceCollection services ,IConfiguration configuration);
	}
}