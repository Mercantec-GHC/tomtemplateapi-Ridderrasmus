using System.Globalization;

namespace PokemonBlazor
{
    public static class StringHelper
    {
        public static string ToTitleCase(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public static string ToSentenceCase(this string str)
        {
            return (str.Length > 0) ? str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower() : "";
        }
    }
}
