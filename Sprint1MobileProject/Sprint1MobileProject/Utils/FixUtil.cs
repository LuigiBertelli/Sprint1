using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace Sprint1MobileProject.Utils
{
    public static class FixUtil
    {
        public static string GenerateRandomTag55(int len = 20)
        {
            var charArray = new char[len];
            var rand = new Random();

            for (int i = 0; i < charArray.Length; i++)
            {
                charArray[i] = Convert.ToChar(rand.Next(94) + 32);
            }
            

            return new string(charArray);
        }

        public static decimal GenerateRandomTag44(decimal upperBound = 100L)
        {
            var rand = new Random();

            return rand.Next((int) Math.Round(upperBound, 2) * 100) / 100L;
        }

        public static string GenerateFIX(Dictionary<int, string> dict)
        {
            StringBuilder fix = new StringBuilder();
            const string version = "FIX.4.4";

            foreach(var kvp in dict ) 
            {
                fix.Append($"{kvp.Key}={kvp.Value}\u0001");
            }

            fix.Insert(0, $"9={fix.Length}\u0001");
            fix.Insert(0, $"8={version}\u0001");

            var tag10 = $"10={GenerateTag10(fix.ToString())}\u0001";

            return fix.ToString() + tag10;
        }

        public static string GenerateTag10(string fix)
        {
            var sum = 0;
            foreach( var c in fix ) 
            {
                sum += c;
            }

            var mod = sum % 256;

            return mod.ToString().PadLeft(3, '0');
        }
    }
}
