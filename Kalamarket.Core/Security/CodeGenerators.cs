

using System;

namespace _98market.Core.Security
{
   public class CodeGenerators
    {
        public static string ActiveCode()
        {
            Random random = new Random();
            string activeCode = random.Next(100000, 999990).ToString();
            return activeCode;
        }     
    }
}
