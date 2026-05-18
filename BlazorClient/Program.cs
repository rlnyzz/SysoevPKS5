using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorClient.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:5001")
});

builder.Services.AddScoped<ProductService>();

await builder.Build().RunAsync();