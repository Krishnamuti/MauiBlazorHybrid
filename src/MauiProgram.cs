using MauiHybridAuthentication.Authentication;
using MauiHybridAuthentication.Repositories;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using SQLite;

namespace MauiHybridAuthentication
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<AuthenticationService>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddSingleton(serviceProvider =>
            {
                var dbPath = Path.Combine(FileSystem.AppDataDirectory, "demo_local_db.db3");
                return new SQLiteAsyncConnection(dbPath);
            });
            builder.Services.AddSingleton<UserAccountRepository>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
