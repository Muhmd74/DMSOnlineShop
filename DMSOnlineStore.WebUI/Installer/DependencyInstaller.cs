using System;
using DMSOnlineStore.Core.Interfaces;
using DMSOnlineStore.WebUI.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DMSOnlineStore.WebUI.Installer
{
    public class DependencyInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));



        }
    }
}
