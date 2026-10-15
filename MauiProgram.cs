// Comment out the next line to disable Prism and the bug goes away.
// With Prism registered, changing a toolbar item's icon on Windows (here via a theme swap) throws
// NullReferenceException in WindowNative.GetWindowHandle (GetDisplayDensity -> ImageConverter).
//#define USE_PRISM

using Microsoft.Extensions.Logging;

namespace ToolbarIconThemeRepro;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
#if USE_PRISM
            // Offending call: registering Prism is enough. The window is still created by App.CreateWindow.
            .UsePrism(prism => prism
                .RegisterTypes(registry => registry.RegisterForNavigation<MainPage>())
                .CreateWindow(navigationService => navigationService.NavigateAsync("NavigationPage/MainPage")))
#endif
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
