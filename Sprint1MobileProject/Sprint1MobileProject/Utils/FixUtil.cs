using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint1MobileProject.Utils
{
    public static class FixUtil
    {
        public static string GenerateRandomTag55()
        {
            var charArray = new char[5];
            var rand = new Random();

            for (int i = 0; i < 4; i++)
            {
                charArray[i] = Convert.ToChar(rand.Next(26) + 65);
            }

            charArray[4] = Convert.ToChar(rand.Next(10).ToString());
            return new string(charArray);
        }

        public static decimal GenerateRandomTag44(decimal upperBound = 100m)
        {
            var rand = new Random();

            return Math.Round((decimal) rand.NextDouble() * upperBound, 2);
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
