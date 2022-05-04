using _98market.Core.Service;
using _98market.Core.Service.Interface;
using _98market.DataLayer.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _98market.Core.Sms;
using _98market.Core.Sms.Sms;
using _98market.Core.ZarinPal;
using static _98market.Core.ExtentionMethod.RenderEmail;

namespace _98market
{
    public class Startup
    {
        public const string Schema = "98market";
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddDbContext<_98marketContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("98market"));
            });

            services.AddAuthentication(Schema)
                .AddCookie(Schema, option =>
                {
                    option.LoginPath = "/Account/Login";
                    option.AccessDeniedPath = "/Account/Login";
                    option.ExpireTimeSpan = TimeSpan.FromDays(30);

                });

            #region IOC

            services.AddHttpContextAccessor();
            services.AddTransient<ISliderService, SliderService>();
            services.AddTransient<Iproductservice, productservice>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IguranteeService, guranteeService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IUserservice, Userservice>();
            services.AddTransient<IViewRenderService, RenderViewToString>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<ICartService, CartService>();
            services.AddTransient<IDiscountService, DiscountService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IIndexService, IndexService>();
            services.AddTransient<IZarinPalFactory, ZarinPalFactory>();
            services.AddTransient<ISmsService, SmsService>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            //if (env.IsDevelopment())
            //{
                //app.UseDeveloperExceptionPage();
            //}


            app.UseAuthentication();
            app.UseRouting();
            app.UseStatusCodePagesWithRedirects("/Home/Error");
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Area", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
