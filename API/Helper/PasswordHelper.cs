using System.Text.RegularExpressions;

namespace API.Helper
{
    public static class PasswordHelper
    {
        public static bool ValidatePassword(string password)
        {
            var rg = new Regex(@"^[A-Za-z0-9]");
            return rg.IsMatch(password);
        }
    }
}