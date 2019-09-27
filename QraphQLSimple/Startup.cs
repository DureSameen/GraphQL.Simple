using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QraphQLSimple.Data.Service;
using QraphQLSimple.QraphQL.Query;
using QraphQLSimple.QraphQL.WeatherSchema;
 
namespace QraphQLSimple
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
            services.AddControllers();
            services.AddSingleton<IWeatherForecastService,WeatherForecastService>();
            services.AddScoped<IDependencyResolver>(s=> new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<WeatherForecastSchema>();
        
            services.AddGraphQL(QraphQL => { QraphQL.ExposeExceptions = true; }) 
                    .AddGraphTypes(typeof(WeatherForecastQuery).Assembly, ServiceLifetime.Scoped);
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
             
            app.UseGraphQL<WeatherForecastSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
        }
    }
}
