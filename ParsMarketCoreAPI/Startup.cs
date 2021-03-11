using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ParsMarketCoreAPI
{
    public class Startup
    {

        public const string ADMIN_CORS_POLICY = "ADMIN_CORS_POLICY";
        public const string OTHERS_CORS_POLICY = "OTHERS_CORS_POLICY";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });




            services.AddControllers();

            services.AddControllersWithViews()
                 .AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                 );


            services.AddDbContext<Data.ParsMarketDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("parsdbcontext")));

            services.AddTransient<IUnitOfWork, UnitOfWork>
            (sp =>
                     {
                         Data.Options options =
                             new Data.Options
                             {
                                 Provider =
                                     (Data.Provider)
                                     System.Convert.ToInt32(Configuration.GetSection(key: "databaseProvider").Value),

                                 //using Microsoft.EntityFrameworkCore;
                                 //ConnectionString =
                                 //	Configuration.GetConnectionString().GetSection(key: "MyConnectionString").Value,

                                 ConnectionString =
                                     Configuration.GetSection(key: "ConnectionStrings").GetSection(key: "ParsDbContext").Value,
                             };

                         return new UnitOfWork(options: options);
                     });
            services.AddIdentity<User, Role>(options =>
             {
                 options.SignIn.RequireConfirmedEmail = true;
                 options.User.RequireUniqueEmail = true;

                 //options.Password.RequiredLength = 8;
                 //options.Password.RequireNonAlphanumeric = true;
                 //options.Password.RequireUppercase = true;
                 //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1d);
                 //options.Lockout.MaxFailedAccessAttempts = 5;

             })
                .AddEntityFrameworkStores<ParsMarketDbContext>()
                .AddDefaultTokenProviders();

            //services.AddDefaultIdentity<Models.Person>
            //    (
            //    options=>options.SignIn.RequireConfirmedAccount=true
            //    ).AddEntityFrameworkStores<ParsMarketDbContext>();



            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration.GetSection(key: "JWT").GetSection(key: "ValidAudience").Value,
                    ValidIssuer = Configuration.GetSection(key: "JWT").GetSection(key: "ValidIssuer").Value,
                    IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection(key: "JWT").GetSection(key: "SecurityKey").Value))
                };
            });

        }






        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAllOrigins");

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}