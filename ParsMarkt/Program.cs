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
            builder.Services.AddScoped<IAccountsServices,AccountsServices>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredLocalStorage(config=>
            config.JsonSerializerOptions.WriteIndented=false);
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Identity.ServerAPI"));
            builder.Services.AddApiAuthorization();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddHttpClient("Identity.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
               /*.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>()*/;
           builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
           

            builder.Services.AddScoped<JWTAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider, JWTAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
                );

            builder.Services.AddScoped<ILoginServices, JWTAuthenticationStateProvider>(
                provider => provider.GetRequiredService<JWTAuthenticationStateProvider>()
                );
            await builder.Build().RunAsync();
        }
    }
}
