namespace ToolbarIconThemeRepro;

public static class Themes
{
    public static readonly ResourceDictionary Dark = new()
    {
        { "ToolbarIcon", new FileImageSource { File = "icon_dark.png" } },
        { "PageBackground", Colors.Black },
        { "TextColor", Colors.White },
    };

    public static readonly ResourceDictionary Light = new()
    {
        { "ToolbarIcon", new FileImageSource { File = "icon_light.png" } },
        { "PageBackground", Colors.White },
        { "TextColor", Colors.Black },
    };

    public static bool IsDark { get; private set; } = true;

    public static void Apply(bool dark)
    {
        var merged = Application.Current!.Resources.MergedDictionaries;
        merged.Remove(Dark);
        merged.Remove(Light);
        merged.Add(dark ? Dark : Light);
        IsDark = dark;
    }
}
