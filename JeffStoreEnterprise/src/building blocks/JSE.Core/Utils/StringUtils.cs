namespace JSE.Core.Utils
{
    public static class StringUtils
    {
        public static string NumberOnly(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
