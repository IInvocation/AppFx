using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluiTec.AspNetCore.Examples.AuthExampleClient
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
            services.AddMvc();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    // defines what will be used after we completed the challenge
                    options.SignInScheme = "Cookies";

                    // setup endpoint
                    options.Authority = "http://localhost:54742";
                    options.RequireHttpsMetadata = false;

                    // init credentials
                    options.ClientId = "IzziNn9qkWFvYqcJJHilVQdnual7RrVUm6dZvV84R8Bb8IZJLQaM2r8/1gBoIDs8zhrWELHEGSWeox2rEeLxBw==";
                    options.ClientSecret = "IO0I4lxLsc6jPO9e5Lg9seKmVKKlxNl5RMjbHwOtLsJixWQGGZafBX6dK7WN8+TCSlqyTUpNq4AphbvASMfoIg==";
                    options.ResponseType = "code id_token";

                    // define behavior
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    // add scopes
                    options.Scope.Add("offline_access");
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
            app.UseAuthentication(); // this actually handles callbacks like signin-oidc
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
