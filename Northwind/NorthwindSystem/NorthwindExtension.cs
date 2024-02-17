using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NorthwindSystem.BLL;
using NorthwindSystem.DAL;

namespace NorthwindSystem
{
    public static class NorthwindExtension
    {
        public static void AddBackendDependencies(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<NorthwindContext>(options);

            services.AddTransient<CategoryService>((ServiceProvider) =>
            {
                var dbContext = ServiceProvider.GetRequiredService<NorthwindContext>();
                return new CategoryService(dbContext);
            });

            services.AddTransient<ProductService>((ServiceProvider) =>
            {
                var dbContext = ServiceProvider.GetRequiredService<NorthwindContext>();
                return new ProductService(dbContext);
            });

        }
    }
}
