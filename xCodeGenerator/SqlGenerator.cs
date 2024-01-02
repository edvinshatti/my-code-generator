namespace xCodeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data;
    using System.IO;
    using System.Text;

    public class SqlGenerator : SqlDataObject
    {
        string connectionString = string.Empty;

        public SqlGenerator(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override string GetConnectionString()
        {
            return this.connectionString;
        }

        private string CorrectScript(string script, NameValueCollection values)
        {
            string res = script.Replace("TBLNAME", values.Get("TBLNAME"));
            res = res.Replace("SCHMNAME", values.Get("SCHMNAME"));
            res = res.Replace("TYPENAME", values.Get("TYPENAME"));
            res = res.Replace("PROCTYPE", values.Get("PROCTYPE"));

            res = res.Replace("NAMESPACE", values.Get("NAMESPACE"));
            res = res.Replace("NSPACEDATAPART", values.Get("NSPACEDATAPART"));
            res = res.Replace("CLASSATTR", values.Get("CLASSATTR"));
            res = res.Replace("PROPATTR", values.Get("PROPATTR"));

            res = res.Replace("CLASSNAME", values.Get("CLASSNAME"));

            res = res.Replace("PARENTCLASS", Common.Parent_Type);
            res = res.Replace("PARENTTYPE", Common.Parent_Type);

            if (Common.Parent_Namespace != string.Empty)
            {
                res = res.Replace("PARENTNAMESPC", Common.Parent_Namespace);
            }

            return res;
        }

        public List<string> GetTables()
        {
            string scriptPath = string.Format("{0}\\SqlScripts\\Code Generator List Tables.sql", Environment.CurrentDirectory);

            string script = File.ReadAllText(scriptPath);

            DataSet ds = this.ExecuteScript(script);

            DataTable dt = ds.Tables[0];

            List<string> tables = new List<string>();

            foreach (DataRow item in dt.Rows)
            {
                tables.Add(item[0].ToString());
            }

            return tables;
        }

        public string GetClassScript(List<string> selectedTables, string generateNamespace, string dataNamespacePart, string classAttr, string propAttr, string tablePrefix, bool removePrefix)
        {
            string scriptPath = $"{Environment.CurrentDirectory}\\SqlScripts\\Code Generator ClassGenerator.sql";

            string srcScript = File.ReadAllText(scriptPath);

            List<DatabaseTable> dbTables = new List<DatabaseTable>();
            foreach (var s in selectedTables)
            {
                string[] st = s.Split('.');

                string tableName = st[st.Length - 1];
                string schema = string.Empty;
                for (int i = 0; i < st.Length - 1; i++)
                {
                    schema += st[i];
                }

                dbTables.Add(new DatabaseTable() { SchemaName = schema, TableName = tableName });
            }

            foreach (var s in dbTables)
            {
                StringBuilder sb = new StringBuilder();

                string typeName = $"{s.SchemaName}_{s.TableName}";

                if (removePrefix)
                {
                    typeName = typeName.Replace(tablePrefix, string.Empty);
                }

                NameValueCollection values = new NameValueCollection();
                values.Add("SCHMNAME", s.SchemaName);
                values.Add("TBLNAME", s.TableName);
                values.Add("TYPENAME", typeName);
                values.Add("NAMESPACE", generateNamespace);
                values.Add("NSPACEDATAPART", dataNamespacePart);
                values.Add("CLASSATTR", classAttr);
                values.Add("PROPATTR", propAttr);

                string script = this.CorrectScript(srcScript, values);

                return script;
            }

            return string.Empty;
        }

        public string GenerateCRUD(List<string> selectedTables, string procType)
        {
            string scriptPath = string.Format("{0}\\SqlScripts\\Code Generator CRUD Single.sql", Environment.CurrentDirectory);

            string srcScript = File.ReadAllText(scriptPath);

            StringBuilder sb = new StringBuilder();

            List<DatabaseTable> dbTables = new List<DatabaseTable>();
            foreach (var s in selectedTables)
            {
                string[] st = s.Split('.');

                string tableName = st[st.Length - 1];
                string schema = string.Empty;
                for (int i = 0; i < st.Length - 1; i++)
                {
                    schema += st[i];
                }

                dbTables.Add(new DatabaseTable() { SchemaName = schema, TableName = tableName });
            }

            //foreach (var table in selectedTables)
            foreach (var tb in dbTables)
            {
                //string script = srcScript.Replace("TBLNAME", table);

                //script = script.Replace("PROCTYPE", procType);

                NameValueCollection values = new NameValueCollection();
                values.Add("SCHMNAME", tb.SchemaName);
                values.Add("TBLNAME", tb.TableName);
                values.Add("PROCTYPE", procType);

                string script = this.CorrectScript(srcScript, values);

                DataSet ds = this.ExecuteScript(script);

                //script = this.ReplaceSpecials(srcScript);

                DataTable dt = ds.Tables[0];

                foreach (DataRow item in dt.Rows)
                {
                    sb.Append(item[0].ToString().ReplaceSpecials());
                }
            }

            return sb.ToString();
        }

        public NameValueCollection GenerateClass(List<string> selectedTables, string generateNamespace, string dataNamespacePart, string classAttr, string propAttr, string tablePrefix, bool removePrefix)
        {
            string scriptPath = string.Format("{0}\\SqlScripts\\Code Generator ClassGenerator.sql", Environment.CurrentDirectory);

            string srcScript = File.ReadAllText(scriptPath);

            NameValueCollection nvc = new NameValueCollection();

            List<DatabaseTable> dbTables = new List<DatabaseTable>();
            foreach (var s in selectedTables)
            {
                string[] st = s.Split('.');

                string tableName = st[st.Length - 1];
                string schema = string.Empty;
                for (int i = 0; i < st.Length - 1; i++)
                {
                    schema += st[i];
                }

                dbTables.Add(new DatabaseTable() { SchemaName = schema, TableName = tableName });
            }

            foreach (var s in dbTables)
            {
                StringBuilder sb = new StringBuilder();

                string typeName = string.Format("{0}_{1}", s.SchemaName, s.TableName);

                if (removePrefix)
                {
                    typeName = typeName.Replace(tablePrefix, string.Empty);
                }

                NameValueCollection values = new NameValueCollection();
                values.Add("SCHMNAME", s.SchemaName);
                values.Add("TBLNAME", s.TableName);
                values.Add("TYPENAME", typeName);
                values.Add("NAMESPACE", generateNamespace);
                values.Add("NSPACEDATAPART", dataNamespacePart);
                values.Add("CLASSATTR", classAttr);
                values.Add("PROPATTR", propAttr);

                string script = this.CorrectScript(srcScript, values);

                DataSet ds = this.ExecuteScript(script);

                //script = this.ReplaceSpecials(srcScript);
                
                DataTable dt = ds.Tables[0];

                foreach (DataRow item in dt.Rows)
                {
                    sb.Append(item[0].ToString().ReplaceSpecials());
                }

                string classCode = sb.ToString();

                nvc.Add(typeName, classCode);
            }

            return nvc;
        }

        

        public NameValueCollection GenerateWCFInterfaces(List<string> selectedTables, string tablePrefix, bool removePrefix)
        {
            string scriptPath = string.Format("{0}\\SqlScripts\\Code Generator WCF Interface.sql", Environment.CurrentDirectory);

            string srcScript = File.ReadAllText(scriptPath);

            NameValueCollection nvc = new NameValueCollection();

            foreach (var table in selectedTables)
            {
                StringBuilder sb = new StringBuilder();

                string typeName = table;

                if (removePrefix)
                {
                    typeName = typeName.Replace(tablePrefix, string.Empty);
                }

                NameValueCollection values = new NameValueCollection();
                values.Add("TBLNAME", table);
                values.Add("TYPENAME", typeName);

                string script = this.CorrectScript(srcScript, values);

                DataSet ds = this.ExecuteScript(script);

                DataTable dt = ds.Tables[0];

                foreach (DataRow item in dt.Rows)
                {
                    sb.Append(item[0].ToString());
                }

                string code = sb.ToString();

                nvc.Add(typeName, code);
            }

            return nvc;
        }

        public NameValueCollection GenerateWCFImplementations(List<string> selectedTables, string className, string tablePrefix, bool removePrefix)
        {
            string scriptPath = string.Format("{0}\\SqlScripts\\Code Generator WCF Implementation.sql", Environment.CurrentDirectory);

            string srcScript = File.ReadAllText(scriptPath);

            NameValueCollection nvc = new NameValueCollection();

            foreach (var table in selectedTables)
            {
                StringBuilder sb = new StringBuilder();

                string typeName = table;

                if (removePrefix)
                {
                    typeName = typeName.Replace(tablePrefix, string.Empty);
                }

                NameValueCollection values = new NameValueCollection();
                values.Add("TBLNAME", table);
                values.Add("TYPENAME", typeName);
                values.Add("CLASSNAME", className);

                string script = this.CorrectScript(srcScript, values);

                DataSet ds = this.ExecuteScript(script);

                DataTable dt = ds.Tables[0];

                foreach (DataRow item in dt.Rows)
                {
                    sb.Append(item[0].ToString());
                }

                string code = sb.ToString();

                nvc.Add(typeName, code);
            }

            return nvc;
        }

        public Dictionary<string, string> GenerateASMXMethods(List<string> selectedTables, string className, string tablePrefix, bool removePrefix)
        {
            string scriptPath = string.Format("{0}\\SqlScripts\\Code_Generator_ASMX_Methods.sql", Environment.CurrentDirectory);

            string srcScript = File.ReadAllText(scriptPath);

            Dictionary<string, string> nvc = new Dictionary<string, string>();

            foreach (var table in selectedTables)
            {
                StringBuilder sb = new StringBuilder();

                string typeName = table;

                if (removePrefix)
                {
                    typeName = typeName.Replace(tablePrefix, string.Empty);
                }

                NameValueCollection values = new NameValueCollection();
                values.Add("TBLNAME", table);
                values.Add("TYPENAME", typeName);
                values.Add("CLASSNAME", className);

                string script = this.CorrectScript(srcScript, values);

                DataSet ds = this.ExecuteScript(script);

                DataTable dt = ds.Tables[0];

                foreach (DataRow item in dt.Rows)
                {
                    sb.Append(item[0].ToString());
                }

                string code = sb.ToString();

                nvc.Add(typeName, code);
            }

            return nvc;
        }
    }
}
