using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace xCodeGenerator
{
    public partial class ASMXGeneratorForm : Form
    {
        private string _ConnectionString;
        private Dictionary<string, string> _GeneratedMethods;

        public void InitForm()
        {
            this.ClassName.Text = Common.Library_Namespace;
        }

        public ASMXGeneratorForm(string connectionString)
        {
            InitializeComponent();

            this._ConnectionString = connectionString;

            this.InitForm();
        }

        private void LoadTables_Click(object sender, EventArgs e)
        {
            SqlGenerator generator = new SqlGenerator(this._ConnectionString);

            List<string> tables = generator.GetTables();

            this.TablesListBox.DataSource = tables;
        }

        private void SelectUnselectAll_CheckedChanged(object sender, EventArgs e)
        {
            bool selected = this.SelectUnselectAll.Checked;

            for (int i = 0; i < this.TablesListBox.Items.Count; i++)
            {
                this.TablesListBox.SetItemChecked(i, selected);
            }
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            try
            {
                string className = this.ClassName.Text.Trim();
                string tablePrefix = this.TablePrefix.Text.Trim();
                bool removePrefix = this.RemoveTablePrefixFromType.Checked;

                List<string> selectedTables = new List<string>();

                foreach (var item in this.TablesListBox.CheckedItems)
                {
                    selectedTables.Add(item.ToString());
                }

                SqlGenerator generator = new SqlGenerator(this._ConnectionString);

                this._GeneratedMethods = generator.GenerateASMXMethods(selectedTables, className, tablePrefix, removePrefix);

                List<ListViewItem> items = new List<ListViewItem>();

                foreach (var key in this._GeneratedMethods.Keys)
                {
                    //string name = removePrefix ? key.Replace(tablePrefix, "") : key;

                    items.Add(new ListViewItem()
                    {
                        ImageIndex = 0,
                        Name = key,
                        Text = key
                    });
                }

                this.GeneratedItems.Items.Clear();

                this.GeneratedItems.Items.AddRange(items.ToArray());

                this.GeneratedMethods.Text = string.Empty;

            }
            catch
            {
            }
        }

        private void GeneratedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectAllMethods.Checked = false;

            if (this.GeneratedItems.SelectedItems.Count > 0)
            {
                string name = this.GeneratedItems.FocusedItem.Name;

                this.GeneratedMethods.Text = this._GeneratedMethods[name];
            }
        }

        private void SelectAllMethods_CheckedChanged(object sender, EventArgs e)
        {
            switch (this.SelectAllMethods.Checked)
            {
                case true:
                    StringBuilder sb = new StringBuilder();

                    foreach (var item in this._GeneratedMethods)
                    {
                        sb.AppendLine(item.Value);
                        sb.AppendLine();
                    }

                    this.GeneratedMethods.Text = sb.ToString();
                    
                    break;
                case false:
                    
                    this.GeneratedMethods.Text = string.Empty;
                    
                    break;
                default:

                    this.GeneratedMethods.Text = string.Empty;

                    break;
            }
        }


    }
}
