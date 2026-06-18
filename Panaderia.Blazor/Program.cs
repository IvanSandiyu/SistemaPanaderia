using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Panaderia.Blazor;
using Panaderia.Blazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5168/") });
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<VentaService>();


await builder.Build().RunAsync();
