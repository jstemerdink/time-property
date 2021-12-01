using System;
using System.Linq;
using EPiServer.Shell.Json;
using EPiServer.Shell.Modules;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;

namespace Advanced.CMS.TimeProperty
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTimeProperty(this IServiceCollection services)
        {
            services.Configure<ProtectedModuleOptions>(
                pm =>
                {
                    if (!pm.Items.Any(i =>
                        i.Name.Equals("advanced-cms-time-property", StringComparison.OrdinalIgnoreCase)))
                    {
                        pm.Items.Add(new ModuleDetails { Name = "advanced-cms-time-property" });
                    }
                });

            services.TryAddEnumerable(ServiceDescriptor.Singleton<IJsonConverter, SystemTextTimeSpanConverter>());

            services.AddMvc().AddRazorRuntimeCompilation(options =>
            {
                options.FileProviders.Add(new EmbeddedFileProvider(
                    typeof(ServiceCollectionExtensions).Assembly
                ));
            });

            return services;
        }
    }
}
