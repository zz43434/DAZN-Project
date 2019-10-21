using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoStreamAPI.Services;
using NLog.Extensions.Logging;
using VideoStreamAPI.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace VideoStreamAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IVideoService, VideoService>();
            services.AddSingleton<IAuthorizationService, AuthorizationService>();
            services.AddSingleton<IStreamManagementService, StreamManagementService>();
            services.AddLogging(logger => logger.AddNLog("NLog.config"));

            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("v1", new Info { Title = "Stream API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(a =>
            {
                a.SwaggerEndpoint("/swagger/v1/swagger.json", "Stream API V1");
                a.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
