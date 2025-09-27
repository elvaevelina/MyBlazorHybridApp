using Microsoft.Extensions.Logging;
using MyBlazorHybridApp.Services;
using MyBlazorHybridApp.Shared.Services;
using Microsoft.Maui.Devices;


namespace MyBlazorHybridApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(DeviceInfo.Platform == DevicePlatform.Android
                    ? "http://10.0.2.2:5173/"
                    : "http://10.10.10.30:5173/") 
            });

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add device-specific services used by the MyBlazorHybridApp.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            builder.Services.AddMauiBlazorWebView();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
