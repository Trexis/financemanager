using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trexis.Finance.Manager
{
    public static class Utilities
    {
        public static String Directory
        {
            get
            {
                String assemblylocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
                String assemblyfilename = assemblylocation.Substring(assemblylocation.LastIndexOf(@"\") + 1);
                return assemblylocation.Substring(0, assemblylocation.Length - assemblyfilename.Length);
            }
        }

        public static string CapitalizeWord(string word)
        {
            return char.ToUpper(word[0]) + word.Substring(1);
        }

        public static String MakeMoneyValue(Double amount)
        {
            String money = System.Math.Round(amount,2).ToString();
            if (money.Contains("."))
            {
                String[] moneyarray = money.Split(Convert.ToChar("."));
                if (moneyarray[1].Length == 1) money += "0";
            }
            else
            {
                money += ".00";
            }
            return money;
        }

    }
}
