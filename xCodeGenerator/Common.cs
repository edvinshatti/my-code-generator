using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace xCodeGenerator
{
    public class Common
    {
        ////public const string PARENT_CLASS = "DataObject";
        public static readonly string Parent_Namespace = $"{ConfigurationManager.AppSettings["ParentNamespace"]}";
        public static readonly string Parent_Class = $"{ConfigurationManager.AppSettings["ParentClass"]}";
        ////public static readonly string Parent_Type = string.Format("{0}.{1}", ConfigurationManager.AppSettings["ParentNamespace"], ConfigurationManager.AppSettings["ParentClass"]);
        public static readonly string Parent_Type = $"{ConfigurationManager.AppSettings["ParentClass"]}";

        public static readonly string Library_Namespace = $"{ConfigurationManager.AppSettings["LibraryNamespace"]}";
        public static readonly string Library_Class = $"{ConfigurationManager.AppSettings["LibraryClass"]}";
        public static readonly string Library_Type =
            $"{ConfigurationManager.AppSettings["LibraryNamespace"]}.{ConfigurationManager.AppSettings["LibraryClass"]}";

        public static readonly string Default_Database = $"{ConfigurationManager.AppSettings["DefaultDatabase"]}";

    }
}
