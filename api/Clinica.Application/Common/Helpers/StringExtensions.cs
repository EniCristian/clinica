namespace Clinica.Application.Common.Helpers
{
    public static class StringExtensions
    {
        public static string ToPascalCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            char[] letters = input.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        }
    }
}