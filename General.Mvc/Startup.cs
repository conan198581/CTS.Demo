using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using General.Core;
using General.Core.Data;
using General.Core.Librs;
using General.Entites;
using General.Services.Category;
using General.Services.Role;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace General.Mvc
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<GeneralDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            //services.AddScoped<ICategoryService, CategoryService>();
            //services.AddScoped<IRoleService, RoleService>();

            var provider = services.BuildServiceProvider();
            EngineContext.Initialize(new GeneralEngine(provider));

            //泛型注入
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            //services.BuildServiceProvider().GetService<ICategoryService>();


            //通过程序集 注入
            Assembly assembly = RuntimeHelper.GetAssemblyByName("General.Services");
            var types = assembly.GetTypes();
            var typelist = types.Where(x => x.IsClass && !x.IsAbstract && !x.IsGenericType);
            foreach (var type in typelist)
            {
                var interfaces = type.GetInterfaces();
                if (interfaces.Any())
                {
                    //接口取第一个
                    var interfaceItem = interfaces.First();
                    services.AddScoped(interfaceItem, type);
                }
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
