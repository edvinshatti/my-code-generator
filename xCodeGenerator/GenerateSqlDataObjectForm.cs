using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace xCodeGenerator
{
    public partial class GenerateSqlDataObjectForm : Form
    {
        string content
        {
            get
            {
                string path = string.Format(@"{0}\ClassTemplates\SqlDataObject.cs.template", Environment.CurrentDirectory);
                string c = File.ReadAllText(path);

                return c;
            }
        }
        public GenerateSqlDataObjectForm()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {

                string ns = this.NamespaceText.Text.Trim();

                if (ns == string.Empty)
                {
                    MessageBox.Show("Select a namespace", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string folderPath = this.SaveFilePath.Text.Trim();
                string path = string.Format(@"{0}\SqlDataObject.cs", folderPath);

                string cnt = this.MakeFile(this.content, ns);

                if (folderPath != string.Empty && Directory.Exists(folderPath))
                {
                    if (File.Exists(path))
                    {
                        if (this.OverwriteExisting.Checked)
                        {
                            File.WriteAllText(path, cnt);
                        }
                        else
                        {
                            MessageBox.Show("File with the same name is already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        File.WriteAllText(path, cnt);
                    }

                    MessageBox.Show("File saved successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Select a folder", "Alert!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string MakeFile(string content, string namespc)
        {
            string cnt = content.Replace("NAMESPACE_NAME", namespc);

            return cnt;
        }

        private void BrowseForPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.SaveFilePath.Text = dialog.SelectedPath;
            }
        }
    }
}