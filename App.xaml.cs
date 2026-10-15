namespace ToolbarIconThemeRepro;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        Themes.Apply(dark: true);
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new NavigationPage(new MainPage()));
    }
}
