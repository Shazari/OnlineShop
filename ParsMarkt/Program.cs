using System;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
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
using ParsMarkt.Auth;
using Microsoft.AspNetCore.Components.Authorization;

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
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient("Identity.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
               .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
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
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Identity.ServerAPI"));

            builder.Services.AddAuthorizationCore();
           
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

            await builder.Build().RunAsync();
        }
    }
}
