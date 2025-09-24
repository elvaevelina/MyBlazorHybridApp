using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBlazorHybridApp.Shared.Services;
using MyBlazorHybridApp.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the MyBlazorHybridApp.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

await builder.Build().RunAsync();
