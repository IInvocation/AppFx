using FluiTec.AppFx.Localization;
using FluiTec.AppFx.Localization.Entities;
using FluiTec.AppFx.Localization.LiteDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluiTec.AppFx.AspNetCore.Examples.LocalizationExample
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // wire up a dataService for the localization
            // (Singleton required - don't try Scoped/Transient, since by the time creating this service - there is no scope)
            services.AddSingleton<ILocalizationDataService>(provider => new LiteDbLocalizationDataService(true, "loc.db", "FluiTec/Appfx"));

            // make aspnetcore handle localization
            services.AddLocalization();
            services.ConfigureLocalization(Configuration);

            // configure MVC for localization
            services.AddMvc()
                .AddViewLocalization() // make MVC handle ViewLocalization
                .AddDataAnnotationsLocalization() // make MVC handle DataAnnotationsLocalization
                ;

            // register database-driven LocalizationHandler
            services.AddDbLocalizationProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //using (var uow = app.ApplicationServices.GetService<ILocalizationDataService>().StartUnitOfWork())
            //{
            //    uow.TranslationRepository.Add(new TranslationEntity { Language = "de-DE", ResourceId = 8, Value = "Deutsch"});
            //    uow.Commit();
            //}
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

            // use the LocalizationProvider
            app.UseDbLocalizationProvider();
            app.UseLocalization(Configuration);
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
