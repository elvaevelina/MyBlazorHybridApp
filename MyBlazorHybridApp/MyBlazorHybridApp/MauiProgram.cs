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

            // Dapatkan IP host: Buka CMD di Windows, ipconfig > IPv4 Address (misal 192.168.1.100)
            // Ganti "192.168.1.100" dengan IP Anda
            var hostIp = "10.10.10.25";  
            var port = "5173";  // Gunakan 5173 untuk HTTP, atau 7173 untuk HTTPS
            var baseUri = DeviceInfo.Platform == DevicePlatform.Android
                ? $"http://10.0.2.2:{port}/"  // Emulator Android: 10.0.2.2 alias localhost host
                : DeviceInfo.Platform == DevicePlatform.iOS
                    ? $"http://localhost:{port}/"  // iOS simulator
                    : $"http://{hostIp}:{port}/";  // Windows/Desktop atau device fisik (sama WiFi)
            builder.Services.AddScoped(sp => new HttpClient
            {
                BaseAddress = new Uri(baseUri),
                Timeout = TimeSpan.FromSeconds(30)  // Tambah timeout jika lambat
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
