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
    public partial class WCFServiceGeneratorForm : Form
    {
        private string _ConnectionString;
        private NameValueCollection _GeneratedInterfaces;
        private NameValueCollection _GeneratedImplementations;

        public WCFServiceGeneratorForm(string connectionString)
        {
            InitializeComponent();

            this._ConnectionString = connectionString;
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

                this._GeneratedInterfaces = generator.GenerateWCFInterfaces(selectedTables, tablePrefix, removePrefix);
                this._GeneratedImplementations = generator.GenerateWCFImplementations(selectedTables, className, tablePrefix, removePrefix);

                List<ListViewItem> items = new List<ListViewItem>();

                foreach (var key in this._GeneratedInterfaces.AllKeys)
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

                this.GeneratedInterfaceScript.Text = string.Empty;
                this.GeneratedImplementationScript.Text = string.Empty;

            }
            catch
            {
            }
        }

        private void GeneratedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.GeneratedItems.SelectedItems.Count > 0)
            {
                string name = this.GeneratedItems.FocusedItem.Name;

                this.GeneratedInterfaceScript.Text = this._GeneratedInterfaces.Get(name);
                this.GeneratedImplementationScript.Text = this._GeneratedImplementations.Get(name);
            }
        }


    }
}
