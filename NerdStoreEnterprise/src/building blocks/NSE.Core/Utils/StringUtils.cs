using System.Linq;

namespace NSE.Core.Utils
{
    public static class StringUtils
    {
        public static string ApensaNumeros(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }
    }
}
