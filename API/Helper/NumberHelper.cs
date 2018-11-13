using System.Text.RegularExpressions;

namespace API.Helper
{
    public static class NumberHelper
    {
        public static string SomenteNumeros(string texto)
        {
            if (texto == null)
            {
                return string.Empty;
            }

            var regexObj = new Regex(@"[^\d]");
            return regexObj.Replace(texto.Trim(), string.Empty);
        }
    }
}