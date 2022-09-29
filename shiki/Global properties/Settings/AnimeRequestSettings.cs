#nullable enable
using shiki.Global_properties.Enums;

namespace shiki.Global_properties.Settings
{
    public class AnimeRequestSettings : MangaAnimeRequestSettingsBase
    {
        public Duration? duration;
        public int[]? studio;
    }
}