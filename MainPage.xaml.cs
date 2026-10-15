namespace ToolbarIconThemeRepro;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnToggleThemeClicked(object? sender, EventArgs e)
    {
        Themes.Apply(!Themes.IsDark);
    }
}
