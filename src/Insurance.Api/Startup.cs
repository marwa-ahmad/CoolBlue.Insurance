using Insurance.Common;
using Insurance.Operations;
using Insurance.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Insurance.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<Common.ILogger, SerilogLogger>();

            services.AddSingleton(typeof(Serilog.ILogger), Log.Logger);

            services.AddTransient<IBasicInsuranceOperation, BasicInsuranceOperation>();
            services.AddTransient<IExtraInsuranceOperation, ExtraInsuranceOperation>();
            services.AddTransient<IProductInsuranceManager, ProductInsuranceManager>();

            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();
            services.AddTransient<IInsuranceService, InsuranceService>();
            AddSwagger(services);
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddApiVersioning();
            services
                .AddSwaggerGen(s=> 
                {
                    s.EnableAnnotations();
                    s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Insurance APIs", Version = "v1"});
                })
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(s => 
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Insurance API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
