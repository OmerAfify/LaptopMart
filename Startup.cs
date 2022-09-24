using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using LaptopMart.Business_Services;
using LaptopMart.BusinessServices;
using LaptopMart.Helpers;
using LaptopMart.Interfaces.IBusinessServices;

using LaptopMart.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace LaptopMart
{
    public class Startup
    {
       public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {


            //Add Controllers with views + ignore self referencing loops 
            services.AddControllersWithViews().AddNewtonsoftJson(opt => {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            //EF core 6 DbCOntext config
            services.AddDbContext<LapShopContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("LapShop_DB_ConnString")
                ));

      


            //session config
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddDistributedMemoryCache();


            //Identity 
            services.AddIdentity<MyApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<LapShopContext>();


            //Auth Service
            services.AddAuthentication()
            .AddCookie(options =>
            {
                options.LoginPath = "/User/AccessDenied";
                options.AccessDeniedPath = "/User/AccessDenied";
            })
           .AddJwtBearer(options =>         // Adding Jwt Bearer config
            {
               options.SaveToken = true;
               options.RequireHttpsMetadata = false;
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateIssuerSigningKey = true, 
                   ValidateLifetime = true, 
                   ValidIssuer = Configuration["JWT:ValidIssuer"],
                   ValidAudience = Configuration["JWT:ValidAudience"],

                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
               };
           });


        


            //DI registeration
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IOsService, OsService>();
            services.AddScoped<IItemTypeService, ItemTypeService>();

            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IShippingInfoService, ShippingInfoService>();
            services.AddScoped<IPayementService, PayementService>();

            services.AddScoped<IUserService, UserService>();


            // Cookie config
            services.ConfigureApplicationCookie(options => {

                options.AccessDeniedPath = "/User/AccessDenied";
                options.Cookie.Name = "LaptopMartCookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = "/User/Login";
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;

            });

            //AutoMapper config
            services.AddAutoMapper(typeof(ApplicationMapper));


            // Adding Cors Policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder => { builder.AllowAnyOrigin(); builder.AllowAnyMethod();
                    builder.AllowAnyHeader(); });

            });


            //HangFire config
            services.AddHangfire(x =>
            {
                x.UseSqlServerStorage(Configuration.GetConnectionString("LapShop_DB_ConnString"));
                x.UseSerializerSettings(new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            });

            services.AddHangfireServer();

            }

         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseHangfireDashboard();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseCors("AllowAll");
          
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
