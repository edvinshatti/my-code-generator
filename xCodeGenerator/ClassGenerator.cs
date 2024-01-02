using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xCodeGenerator
{
    public class ClassGenerator
    {
        public string ReplaceClassParameters(string classText, Dictionary<string, string> values)
        {
            string res = classText;

            foreach (var v in values)
            {
                res = res.Replace(v.Key, v.Value);
            }

            return res;
        }

        public string Generate(string classText, Dictionary<string, string> values)
        {
            string text = this.ReplaceClassParameters(classText, values);

            return text;
        }
    }
}
