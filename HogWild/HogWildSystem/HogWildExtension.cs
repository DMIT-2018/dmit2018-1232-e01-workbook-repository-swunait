using HogWildSystem.BLL;
using HogWildSystem.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HogWildSystem
{
    public static class HogWildExtension
    {
        public static void AddBackendDependencies(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            // Register the HogWildContext class, which is the DbContext for your application,
            // with the service collection. This allows the DbContext to be injected into other
            // parts of your application as a dependency.

            // The 'options' parameter is an Action<DbContextOptionsBuilder> that typically
            // configures the options for the DbContext, including specifying the database
            // connection string.

            services.AddDbContext<HogWildContext>(options);
            //  adding any services that you create in the class library (BLL)
            //  using .AddTransient<t>(...)
            //  working versions
            services.AddTransient<WorkingVersionsService>((ServiceProvider) =>
            {
                //  Retrieve an instance of HogWildContext from the service provider.
                var context = ServiceProvider.GetService<HogWildContext>();

                // Create a new instance of WorkingVersionsService,
                //   passing the HogWildContext instance as a parameter.
                return new WorkingVersionsService(context);
            });

            services.AddTransient<CustomerService>((ServiceProvider) =>
            {
                //  Retrieve an instance of HogWildContext from the service provider.
                var context = ServiceProvider.GetService<HogWildContext>();

                // Create a new instance of WorkingVersionsService,
                //   passing the HogWildContext instance as a parameter.
                return new CustomerService(context);
            });

        }
    }
}
