using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Axxes.ToyCollector.Core.Contracts.Database;
using Axxes.ToyCollector.Core.Contracts.DependencyResolution.Options;
using Axxes.ToyCollector.DependencyResolution;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Axxes.ToyCollector.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var mvcBuilder = services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            mvcBuilder.AddJsonOptions(jsonOptions => jsonOptions.SerializerSettings.TypeNameHandling = TypeNameHandling.Auto);

            LoadAllPlugins(services, mvcBuilder);

            services.Configure<DatabaseConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info{Title = "Toy Collector API", Version = "v1"}); });

            return CreateApplicationServiceProvider(services);
        }

        private void LoadAllPlugins(IServiceCollection services, IMvcBuilder mvcBuilder)
        {
            var allDeployedDllFiles = Directory.GetFiles(Path.Combine(Environment.ContentRootPath, "bin"), "Axxes.ToyCollector.*.dll", SearchOption.AllDirectories);

            // Scan the startup path for DLL's and register their types
            services.LoadConfiguredTypesFromDir(allDeployedDllFiles);

            var mvcPlugins = allDeployedDllFiles.Where(f => f.Contains("Axxes.ToyCollector.Plugins") && !f.EndsWith("Views.dll"));
            
            // Setup MVC controllers
            LoadControllersFromPlugins(mvcBuilder, mvcPlugins);

            // Setup MVC Views
            LoadViewsFromPlugins(services, mvcPlugins);
        }

        

        private void LoadControllersFromPlugins(IMvcBuilder builder, IEnumerable<string> pluginFiles)
        {
            foreach (var dllFile in pluginFiles)
            {
                var assembly = Assembly.LoadFrom(dllFile);
                builder.AddApplicationPart(assembly);
            }
        }

        private void LoadViewsFromPlugins(IServiceCollection services, IEnumerable<string> mvcViews)
        {
            services.Configure<RazorViewEngineOptions>(options =>
            {
                foreach (var mvcView in mvcViews)
                {
                    var assembly = Assembly.LoadFrom(mvcView);
                    options.FileProviders.Add(new EmbeddedFileProvider(assembly));
                }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IDatabaseInitializer databaseInit)
        {
            if (env.IsDevelopment())
            {
                databaseInit.Initialize();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Toy Collector API v1"); });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        #region Autofac

        public IContainer ApplicationContainer { get; private set; }
        private IServiceProvider CreateApplicationServiceProvider(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);

            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        #endregion
    }
}
