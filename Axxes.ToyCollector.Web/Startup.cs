using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Axxes.ToyCollector.Core.Contracts.Database;
using Axxes.ToyCollector.Core.Contracts.DependencyResolution.Options;
using Axxes.ToyCollector.DependencyResolution;
using Axxes.ToyCollector.Web.ModelBinding;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Axxes.ToyCollector.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var mvcBuilder = services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .ConfigureApplicationPartManager(LoadAspnetApplicationPlugins);

            var inheritedTypesRegistry = new InheritedTypesRegistry();

            LoadAllPlugins(services, inheritedTypesRegistry);

            // Allows the passing of JSON $type parameters (required for inherited types)
            mvcBuilder.AddJsonOptions(jsonOptions =>
            {
                jsonOptions.SerializerSettings.Converters.Add(new InheritedTypesJsonConverter(inheritedTypesRegistry));
            });

            services.Configure<DatabaseConnectionStrings>(Configuration.GetSection("ConnectionStrings"));

            services.AddSwaggerGen(c => 
                { c.SwaggerDoc("v1", new Info{Title = "Toy Collector API", Version = "v1"}); }
            );

            return CreateApplicationServiceProvider(services);
        }

        private void LoadAspnetApplicationPlugins(ApplicationPartManager apm)
        {
            var allPluginDlls = Directory.GetFiles(
                Path.Combine(Environment.ContentRootPath, "bin"), "Axxes.ToyCollector.Plugins.*.dll", 
                SearchOption.AllDirectories);

            var allControllerDlls = allPluginDlls.Where(p => !p.EndsWith("Views.dll"));
            var allRazorViewsDlls = allPluginDlls.Where(p => p.EndsWith("Views.dll"));

            // Add MVC/API controllers from Plugins
            foreach (string controllerDll in allControllerDlls)
            {
                apm.ApplicationParts.Add(
                    new AssemblyPart(Assembly.LoadFrom(controllerDll)));
            }

            // Add Razor views from Plugins
            foreach (string razorViewsDll in allRazorViewsDlls)
            {
                apm.ApplicationParts.Add(
                    new CompiledRazorAssemblyPart(Assembly.LoadFrom(razorViewsDll)));
            }
        }

        private void LoadAllPlugins(IServiceCollection services, InheritedTypesRegistry inheritedTypesRegistry)
        {
            // Scan the startup path for DLL's and register their types
            var allDeployedDllFiles = Directory.GetFiles(
                Path.Combine(Environment.ContentRootPath, "bin"),"Axxes.ToyCollector.*.dll", 
                SearchOption.AllDirectories);

            services.LoadConfiguredTypesFromFiles(inheritedTypesRegistry, allDeployedDllFiles);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IDatabaseInitializer databaseInit)
        {
            if (env.IsDevelopment())
            {
                var pluginDlls = Directory.GetFiles(
                    Path.Combine(Environment.ContentRootPath, "bin"), "Axxes.ToyCollector.Plugins.*.dll",
                    SearchOption.AllDirectories)
                    .Where(p => !p.EndsWith(".Views.dll"))
                    .ToArray();

                databaseInit.Initialize(pluginDlls);
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSwagger();

            app.UseSwaggerUI(
                c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Toy Collector API v1"); });

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
