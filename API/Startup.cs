using Microsoft.Extensions.Configuration;
using API.Core.Interfaces;
using API.Core.UseCases;
using API.Entities.Entities;
using API.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using API.App_Code.Middlewares;
using System.IO;
using API.App_Code;

namespace API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsJson = AppSettingsJson.GetAppSettings();
            services.AddDbContext<DataContext>(opts => opts.UseSqlServer(appSettingsJson["ConnectionString:ReceiptsDBAzure"]));
            services.AddScoped<IDataRepository<Receipt>, ReceiptManager>();
            services.AddScoped<IDataRepository<User>, UserManager>();

            services.BuildServiceProvider().GetService<DataContext>().Database.Migrate();
            services.AddOpenApiDocument(config => config.Title = "API");
            services.AddControllers();

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
