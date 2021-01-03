using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;
using Blazored.LocalStorage;
using Tewr.Blazor.FileReader;

namespace ParsMarkt
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            //builder.RootComponents.Add<App>("app");
            builder.Services.AddFileReaderService(options=>
            {
                options.UseWasmSharedBuffer = true;
            });
            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IMenuServices,MenuServices>();
            builder.Services.AddScoped<IBasketServices,BasketServices>();
            builder.Services.AddScoped<IProductServices, ProductServices>();
            builder.Services.AddScoped<IContactServices, ContactServices>();
            builder.Services.AddScoped<IAboutServices, AboutServices>();
            builder.Services.AddScoped<IPersonServices, PersonServices>();
            builder.Services.AddScoped<ICategoryServices, CategoryServices>();
            builder.Services.AddScoped<IOffCodeServices, OffCodeServices>();
            builder.Services.AddScoped<IWeekDayServices , WeekDayServices>();
            builder.Services.AddScoped<IOrderServices, OrderServices>();
            builder.Services.AddScoped<IRoleServices, RoleServices>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredLocalStorage(config=>
            config.JsonSerializerOptions.WriteIndented=false);

            
            

            await builder.Build().RunAsync();
        }
    }
}