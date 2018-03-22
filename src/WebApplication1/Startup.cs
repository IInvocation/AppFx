using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Localization;
using FluiTec.AppFx.Localization.LiteDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
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
            services.AddLocalization();

            services.AddSingleton<ILiteDbServiceOptions>(new LiteDbServiceOptions {ApplicationFolder = "FluiTec/AppFx", DbFileName = "loc.db", UseSingletonConnection = true});
            services.AddSingleton<ILocalizationDataService, LiteDbLocalizationDataService>();

            services.AddMvc()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization();

            services.AddDbLocalizationProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var loc = app.ApplicationServices.GetService<ILocalizationDataService>();
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseDbLocalizationProvider();
        }
    }
}
