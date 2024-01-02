using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace xCodeGenerator
{
    public partial class ClassForm : Form
    {
        private string _ConnectionString;
        private NameValueCollection generatedClassItems;
        private AutoCompleteStringCollection namespaces;
        private AutoCompleteStringCollection saveLocations;

        #region Methods

        private void Config()
        {

            if (Properties.Settings.Default.NamespaceAutoComplete != null && Properties.Settings.Default.NamespaceAutoComplete.Count > 0)
            {
                namespaces = Properties.Settings.Default.NamespaceAutoComplete;
            }
            else
            {
                namespaces = new AutoCompleteStringCollection();
            }
            this.NamespaceText.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.NamespaceText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.NamespaceText.AutoCompleteCustomSource = Properties.Settings.Default.NamespaceAutoComplete;

            if (Properties.Settings.Default.SaveLocationAutoComplete != null && Properties.Settings.Default.SaveLocationAutoComplete.Count > 0)
            {
                saveLocations = Properties.Settings.Default.SaveLocationAutoComplete;
            }
            else
            {
                saveLocations = new AutoCompleteStringCollection();
            }
            this.SaveLocation.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.SaveLocation.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.SaveLocation.AutoCompleteCustomSource = Properties.Settings.Default.SaveLocationAutoComplete;

            AutoCompleteStringCollection classAttrSrc = new AutoCompleteStringCollection();
            classAttrSrc.AddRange(Helper.GetClassAttributes());
            this.ClassAttributes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.ClassAttributes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.ClassAttributes.AutoCompleteCustomSource = classAttrSrc;

            AutoCompleteStringCollection propAttrSrc = new AutoCompleteStringCollection();
            propAttrSrc.AddRange(Helper.GetPropertyAttributes());
            this.PropertiesAttributes.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.PropertiesAttributes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.PropertiesAttributes.AutoCompleteCustomSource = propAttrSrc;

            this.NamespaceText.Text = Common.Library_Namespace;
        }

        #endregion

        public ClassForm(string connectionString)
        {
            InitializeComponent();

            this._ConnectionString = connectionString;

            //this.Config();
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
            if (Form.ModifierKeys == Keys.Shift)
            {
                string generateNamespace = this.NamespaceText.Text.Trim();
                string dataNamespacePart = this.DataNamespacePart.Text.Trim();
                string classAttributes = this.ClassAttributes.Text.Trim();
                string propertirsAttributes = this.PropertiesAttributes.Text.Trim();
                string tablePrefix = this.TablePrefix.Text.Trim();
                bool removePrefix = this.RemoveTablePrefixFromType.Checked;

                List<string> selectedTables = new List<string>();

                foreach (var item in this.TablesListBox.CheckedItems)
                {
                    selectedTables.Add(item.ToString());
                }

                SqlGenerator generator = new SqlGenerator(this._ConnectionString);

                string script = generator.GetClassScript(selectedTables, generateNamespace, dataNamespacePart, classAttributes, propertirsAttributes, tablePrefix, removePrefix);

                ResultForm form = new ResultForm(script);

                form.ShowDialog();
            }
            else
            {
                try
                {
                    string generateNamespace = this.NamespaceText.Text.Trim();
                    string dataNamespacePart = this.DataNamespacePart.Text.Trim();
                    string classAttributes = this.ClassAttributes.Text.Trim();
                    string propertirsAttributes = this.PropertiesAttributes.Text.Trim();
                    string tablePrefix = this.TablePrefix.Text.Trim();
                    bool removePrefix = this.RemoveTablePrefixFromType.Checked;

                    List<string> selectedTables = new List<string>();

                    foreach (var item in this.TablesListBox.CheckedItems)
                    {
                        selectedTables.Add(item.ToString());
                    }

                    SqlGenerator generator = new SqlGenerator(this._ConnectionString);

                    this.generatedClassItems = generator.GenerateClass(selectedTables, generateNamespace, dataNamespacePart, classAttributes, propertirsAttributes, tablePrefix, removePrefix);

                    List<ListViewItem> items = new List<ListViewItem>();

                    foreach (var key in this.generatedClassItems.AllKeys)
                    {
                        //string name = removePrefix ? key.Replace(tablePrefix, "") : key;

                        items.Add(new ListViewItem()
                        {
                            ImageIndex = 0,
                            Name = key,
                            Text = key + ".cs"
                        });
                    }

                    this.GeneratedClassList.Items.Clear();

                    this.GeneratedClassList.Items.AddRange(items.ToArray());

                    this.GeneratedScript.Text = string.Empty;

                    //AutoCompleteStringCollection collection = Properties.Settings.Default.NamespaceAutoComplete;
                    //if(collection == null)
                    //{
                    //    collection = new AutoCompleteStringCollection();
                    //}

                    if (namespaces.IndexOf(generateNamespace) < 0)
                    {
                        namespaces.Add(generateNamespace);
                        //Properties.Settings.Default.NamespaceAutoComplete = namespaces;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void GeneratedClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.GeneratedClassList.SelectedItems.Count > 0)
            {
                string className = this.GeneratedClassList.FocusedItem.Name;

                this.GeneratedScript.Text = this.generatedClassItems.Get(className);
            }
        }

        private void SaveBrowseLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string savePath = dialog.SelectedPath;

                this.SaveLocation.Text = savePath;
            }
        }

        private void SaveClassFiles_Click(object sender, EventArgs e)
        {
            try
            {
                string savePath = this.SaveLocation.Text.Trim();

                if (!Directory.Exists(savePath))
                {
                    if (MessageBox.Show("Directory not exists. Do you want to create it?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Directory.CreateDirectory(savePath);
                    }
                    else
                    {
                        return;
                    }
                }

                foreach (ListViewItem item in GeneratedClassList.CheckedItems)
                {
                    string filePath = string.Format("{0}\\{1}.cs", savePath, item.Name);

                    bool overwrite = this.OverwriteExistingFiles.Checked;

                    if (!overwrite)
                    {
                        if (File.Exists(filePath))
                        {
                            //MessageBox.Show(string.Format("File '{0}.cs' already exists.", item.Name), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue;
                        }
                    }

                    File.WriteAllText(filePath, this.generatedClassItems.Get(item.Name));
                }

                if (saveLocations.IndexOf(savePath) < 0)
                {
                    saveLocations.Add(savePath);
                    //Properties.Settings.Default.NamespaceAutoComplete = namespaces;
                }

                MessageBox.Show("Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.GeneratedClassList.Items)
            {
                item.Checked = true;
            }
        }

        private void selectNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.GeneratedClassList.Items)
            {
                item.Checked = false;
            }
        }

        private void ClassForm_Load(object sender, EventArgs e)
        {
            this.Config();
        }

        private void ClassForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.NamespaceAutoComplete = namespaces;
            Properties.Settings.Default.SaveLocationAutoComplete = saveLocations;
            Properties.Settings.Default.Save();
        }

        private void DeleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedItem = this.NamespaceText.Text.Trim();

            if (this.namespaces.Contains(selectedItem))
            {
                namespaces.Remove(selectedItem);
            }
        }

        private void DeleteSaveLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedItem = this.SaveLocation.Text.Trim();

            if (this.saveLocations.Contains(selectedItem))
            {
                saveLocations.Remove(selectedItem);
            }
        }
    }
}
