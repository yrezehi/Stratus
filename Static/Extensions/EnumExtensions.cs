namespace Static.Extensions
{
    public static class EnumExtensions
    {
        public static string AsString(this Enum @enum) =>
            Enum.GetName(@enum.GetType(), @enum)!;
    }
}
