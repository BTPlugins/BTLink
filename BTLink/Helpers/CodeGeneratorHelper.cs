using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLink.Helpers
{
    public class CodeGeneratorHelper
    {
        public static string GenerateCode()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            string code = "";

            for (int i = 0; i < 6; i++)
            {
                code += chars[random.Next(chars.Length)];
            }

            return code;
        }
    }
}
