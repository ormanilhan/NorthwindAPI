using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace NorhwindAPI
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
            services.AddDbContext<NorthwindAPIDBContext>(options =>
            {
                options.UseSqlServer("server=.;database=Northwind;trusted_connection=true;");
            });
            services.AddScoped<RAML.WebApiExplorer.ApiExplorerDataFilter>();
            services.AddMvc(options =>
                {
                    options.Filters.AddService(typeof(RAML.WebApiExplorer.ApiExplorerDataFilter));
                    options.Conventions.Add(new RAML.WebApiExplorer.ApiExplorerVisibilityEnabledConvention());
                    options.Conventions.Add(new RAML.WebApiExplorer.ApiExplorerVisibilityDisabledConvention(typeof(RAML.WebApiExplorer.RamlController)));
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}