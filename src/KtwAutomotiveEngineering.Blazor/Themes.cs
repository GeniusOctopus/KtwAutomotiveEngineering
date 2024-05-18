using MudBlazor;

namespace KtwAutomotiveEngineering.Blazor
{
    internal static class Themes
    {
        internal static MudTheme StandardTheme = new()
        {
            Palette = new PaletteLight
            {
                AppbarBackground = "#20ad3c",
                AppbarText = "#041608",
                TextPrimary = "#041608",
                Primary = "#20ad3c",
                PrimaryLighten = "#4cb95b",
                PrimaryDarken = "#007b1d",
                Secondary = "#2091ad",
                SecondaryLighten = "#2fb5db",
                SecondaryDarken = "#0c5b68",
                Tertiary = "#3c20ad",
                TertiaryLighten = "#6333c3",
                TertiaryDarken = "#2012a1",
            }
        };
    }
}
