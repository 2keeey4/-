using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BarberShop.Code
{
    public class MyDataException:Exception
    {
        public const string ErrorConnectServer = "Невозможно подключиться к серверу";
        public static Dictionary<string, string> ErrorMessages = new Dictionary<string, string>()
        {
            ["P0001"] = "Email уже занят другим пользователем."
        };
        public MyDataException() : base() { }
        public MyDataException(string Message) : base(Message) { }
        public static string ExtractErrorCode(string errorMessage)
        {
            var match = Regex.Match(errorMessage, @"\[(P\d+)\]");
            return match.Success ? match.Groups[1].Value : null;
        }
    }
}
