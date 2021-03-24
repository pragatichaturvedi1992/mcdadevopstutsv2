using InventoryManagement.UI.Services.Repositories;
using InventoryManagment.UI.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.UI.Services
{
    public static class Bootstrapper
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddTransient<IStoreManagementRepository, InventoryManagementRepository>();
        }
    }
}