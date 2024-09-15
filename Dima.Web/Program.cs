using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace Dima.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            
            builder.Services.AddMudServices();

            builder.Services.AddHttpClient(Configuration.HttpClientName, opt =>
            {
                opt.BaseAddress = new Uri(Configuration.BackEndUrl);
            }).AddHttpMessageHandler<CookieHandler>();

            await builder.Build().RunAsync();
        }
    }
}
