using DemoGame.ViewModels;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;
using Mopups.Interfaces;
using Mopups.Services;

namespace DemoGame
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureMopups()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fontello.ttf", "Icons");
                    fonts.AddFont("Roboto-Light.ttf", "RobotoL");
                    fonts.AddFont("Roboto-Regular.ttf", "RobotoR");
                    fonts.AddFont("SpaceGrotesk-Bold.ttf", "SpaceGroteskB");
                    fonts.AddFont("SpaceGrotesk-Medium.ttf", "SpaceGroteskM");
                    fonts.AddFont("SpaceGrotesk-Regular.ttf", "SpaceGroteskR");
                    fonts.AddFont("SpaceGrotesk-SemiBold.ttf", "SpaceGroteskSB");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);
            builder.Services.AddTransient<App>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            return builder.Build();
        }
    }
}