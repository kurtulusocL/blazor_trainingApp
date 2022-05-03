using Blazor.FileReader;
using Blazored.LocalStorage;
using BlazorTraining.Server.Business.Services;
using BlazorTraining.Server.Core.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTraining.Client
{
    public class Program
    {
        private const string URL = "https://plannerappserver20200228091432.azurewebsites.net/";
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();

            builder.Services.AddScoped<AuthenticationService>(i =>
            {
                return new AuthenticationService(URL);
            });            
            builder.Services.AddScoped<PlanService>(i =>
            {
                return new PlanService(URL);
            });
            builder.Services.AddScoped<ToDoItemService>(i =>
            {
                return new ToDoItemService(URL);
            });

            builder.Services.AddFileReaderService(opt =>
            {
                opt.UseWasmSharedBuffer = true;
            });

            builder.RootComponents.Add<App>("#app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
