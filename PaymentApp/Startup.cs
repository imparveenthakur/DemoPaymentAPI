using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PaymentApp.API.CustomMiddlewares;
using Microsoft.AspNetCore.Http.Features;
using AutoMapper;
using PaymentApp.API.Extension;
using PaymentApp.Service.Configuration;
using Microsoft.OpenApi.Models;

namespace PaymentApp
{
    /// <summary>
    /// Startup File
    /// </summary>
    public class Startup
    {
        #region Properties/Fields Initializations
        public IConfiguration Configuration { get; }
        #endregion

        #region Ctor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Add/Configure Services

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            
                //.SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                //.AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddJwtConfiguration();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddTransientDependencyInjection();
            IMapper mapper = MapperConfig.Configure().CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton(Configuration);
            //services.AddMvc();
            services.Configure<FormOptions>(x =>
            {
                x.ValueLengthLimit = int.MaxValue;
                x.MultipartBodyLengthLimit = int.MaxValue; // In case of multipart
            });
            services.AddMvcCore().AddApiExplorer();


        }

        #endregion

        #region Use The Services
        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app)
        {
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseMiddleware<CustomExceptionMiddleware>();
            app.UseCors();
            //app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            //app.UseSwaggerDocumentation();
            //app.UseMvc();
        }
        #endregion
    }
}
