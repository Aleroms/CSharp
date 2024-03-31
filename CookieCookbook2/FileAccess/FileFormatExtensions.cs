namespace CookieCookbook2.FileAccess;

public static class FileFormatExtensions
{
    public static string AsFileExtension(this FileFormat fileFormat) =>
        fileFormat == FileFormat.JSON ? "json" : "txt";
}
