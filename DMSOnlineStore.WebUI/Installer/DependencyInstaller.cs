using System;
using DMSOnlineStore.WebUI.FileService;
 using DMSOnlineStore.WebUI.Repositories.CardHome;
using DMSOnlineStore.WebUI.Repositories.CartShipping;
using DMSOnlineStore.WebUI.Repositories.Items;
using DMSOnlineStore.WebUI.Repositories.Order;
using DMSOnlineStore.WebUI.Repositories.OrderDetails;
using DMSOnlineStore.WebUI.Repositories.Uom;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DMSOnlineStore.WebUI.Installer
{
    public class DependencyInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUom, UomServices>();
            services.AddScoped<IItem, ItemServices>();
            services.AddScoped<ICard, CardServices>();
             services.AddScoped<IOrderDetails, OrderDetailsServices>();
            services.AddScoped<ICartShipping, CartShippingServices>();
            services.AddScoped<IOrder, OrderServices>();
            //File
            services.AddScoped<FileService.FileService>();
            services.AddScoped<UploadCore>();
        }
    }
}
