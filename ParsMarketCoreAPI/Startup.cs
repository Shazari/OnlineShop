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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}