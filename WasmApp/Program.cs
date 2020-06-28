using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WasmApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            // Get an instance of the attribute applied to the assembly
            var apiConfig = Assembly.GetAssembly(typeof(Program)).GetCustomAttribute<BuildConfigurationAttribute>();

            // Build a config options and register it with DI
            var baseUrl = new Uri(apiConfig.BaseUrl ?? builder.HostEnvironment.BaseAddress);
            builder.Services.Configure<AppOptions>(o =>
            {
                o.BaseUrl = baseUrl;
                o.BuildDate = apiConfig.BuildDate;
            });

            // Set the BaseUrl on the HttpClient
            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = baseUrl });

            await builder.Build().RunAsync();
        }
    }
}
