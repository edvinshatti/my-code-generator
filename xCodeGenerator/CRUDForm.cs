using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace xCodeGenerator
{
    public partial class CRUDForm : Form
    {
        private string _ConnectionString;

        public CRUDForm(string connectionString)
        {
            InitializeComponent();

            this._ConnectionString = connectionString;
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            List<string> selectedTables = new List<string>();

            foreach (var item in this.TablesListBox.CheckedItems)
            {
                selectedTables.Add(item.ToString());
            }

            string procType = this.ProcedureType.Text.Trim();

            SqlGenerator generator = new SqlGenerator(this._ConnectionString);

            string generatedCode = generator.GenerateCRUD(selectedTables, procType);

            this.GeneratedScript.Text = generatedCode;
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

        private void CRUDForm_Load(object sender, EventArgs e)
        {

        }
    }
}
