using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.BLL.Abstract;
using Eticaret.BLL.Concrete;
using Eticaret.DAL.Abstract;
using Eticaret.DAL.Concrete.EntityFramework;
using Eticaret.MvcWEBUI.Entities;
using Eticaret.MvcWEBUI.Middlewares;
using Eticaret.MvcWEBUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Eticaret.MvcWEBUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EFProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EFCategoryDal>();
            services.AddSingleton<ICartSessionService, CartSessionService>();
            services.AddSingleton<ICartService, CartService>();
            services.AddDbContext<CustomIdentityDbContext>
                (options => options.UseSqlServer(@"Server=CASPER\SQLEXPRESS;Database=Northwind;Trusted_Connection=true"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>()
                .AddDefaultTokenProviders();
            //AddDefaultTokenProviders() kullanıcı bilgilerinin sayfalar arası geçiş yaparken bilgilerin taşınması için.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddDistributedMemoryCache();//session aktifleştirmek için.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //klasik Asp.Nette tüm yaşam döngülerinde geçmem gerekiyordu.
            //Core da ise ortakatmanda neyi istiyorsam onu burda aktifleştiriyorum.
            //ortakatman.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //hatalarımızı takip ediyoruz.

            app.UseFileServer(); //wwwroot un altını tutuyor.
            app.UseNodeModules(env.ContentRootPath);
            app.UseIdentity();
            app.UseSession();
            app.UseMvc(ConfigureRoutes);
            /*app.UseMvcWithDefaultRoute(); *///Home/Index sayfasına git.

        }

            private void ConfigureRoutes(IRouteBuilder routeBuilder)
            {
                //Home/Index
                routeBuilder.MapRoute("Default", "{controller=Products}/{action=Index}/{id?}");
            }

        
    }
}
