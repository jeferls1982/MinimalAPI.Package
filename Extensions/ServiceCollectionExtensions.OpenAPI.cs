using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace MinimalAPI.Package.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddOpenAPI(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwagger();

            return builder;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Description = "MAPI - Packeges",
                    Title = "MAPI - Packeges",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Developers",
                        Email = "teste@api.com",
                    }

                });
            });
            return services;
        }

        public static IApplicationBuilder UseOpenAPI(this IApplicationBuilder app, string routePrefix)
        {
            app.UseSwagger();
            app.UseSwaggerUI( c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                c.RoutePrefix = routePrefix;
            });

            return app;
        }
    }
}
