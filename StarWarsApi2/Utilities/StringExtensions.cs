public static class StringExtensions
{
    public static int? ToIntOrNull(this string? field)
    {

        return int.TryParse(field, out int surfaceWaterParsed) ?
            surfaceWaterParsed : null;
    }
}