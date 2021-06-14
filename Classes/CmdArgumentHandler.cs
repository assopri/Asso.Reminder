using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Asso.Reminder
{
    public static class CmdArgumentHandler
    {
        public static bool listContainsStr(List<string> list, string str, bool ignoreCase = true)
        {
            if (!ignoreCase) return list.Contains(str);

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].ToLower();
            }

            str = str.ToLower();

            return list.Contains(str);
        }

        public static bool arContainsStr(string[] ar, string str, bool ignoreCase = true)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                if (String.Compare(str, ar[i], ignoreCase) == 0) return true;
            }
            return false;
        }
        //
        public static string getCmdArgValue(string[] ar, string arg)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                Match m = Regex.Match(ar[i], arg + "=(.*?)$");

                if (m.Groups[1].Value.Trim() == "") continue;

                return m.Groups[1].Value.Trim();
            }

            return "";
        }
    }
}
