using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;


namespace PaymentApp.API.Extension
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Version = "v1.0", Title = "API Version", });
            //    c.AddSecurityDefinition("Bearer", new ApiKeyScheme
            //    {
            //        In = "header",
            //        Description = "Please enter JWT with Bearer into field",
            //        Name = "Authorization",
            //        Type = "apiKey"
            //    });
            //    c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> { { "Bearer", Enumerable.Empty<string>() }, });
            //});

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "KP New Form Module API V1");
                c.DocExpansion(DocExpansion.None);
            });

            return app;
        }

    }
}
