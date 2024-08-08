using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VisualizeApiData;
using VisualizeApiData.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<CircleK>(sp => sp.BaseAddress = new Uri("https://magsapi.onrender.com/api/"));

await builder.Build().RunAsync();
