using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace xCodeGenerator
{
    public static class Helper
    {
        public static string[] GetClassAttributes()
        {
            string filePath = string.Format("{0}\\ClassAttributes.txt", Environment.CurrentDirectory);

            string[] attributes = File.ReadAllLines(filePath);

            return attributes;
        }

        public static string[] GetPropertyAttributes()
        {
            string filePath = string.Format("{0}\\PropertyAttributes.txt", Environment.CurrentDirectory);

            string[] attributes = File.ReadAllLines(filePath);

            return attributes;
        }

        public static string ReplaceSpecials(this string srcScript)
        {
            var res = srcScript;

            res = res.Replace("[TAB]", "    ");
            res = res.Replace("[NEWLINE]", Environment.NewLine);

            return res;
        }
    }
}
