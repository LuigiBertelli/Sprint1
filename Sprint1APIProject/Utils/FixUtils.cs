namespace Sprint1ApiProject.Utils
{
    public static class FixUtils
    {
        public static Dictionary<int, string> Converter(string fixTxt)
        {
            var dict = new Dictionary<int, string>();

            var splittedFix = fixTxt.Split('\u0001');
            foreach (var split in splittedFix) 
            { 
                var field = split.Split('=', 2);

                if (field.Length == 2) 
                {
                    dict.Add(Convert.ToInt32(field[0]), field[1]);
                }
            }

            return dict;
        }
    }
}
