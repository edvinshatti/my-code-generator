namespace xCodeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    using Microsoft.Data.ConnectionUI;

    public partial class MainForm : Form
    {
        public string ConnectionString
        {
            get
            {
                return this.ConnectionStringText.Text.Trim();
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void CreateConnectionString_Click(object sender, EventArgs e)
        {
            DataConnectionDialog dialog = new DataConnectionDialog();
            dialog.DataSources.Add(DataSource.SqlDataSource);

            if (DataConnectionDialog.Show(dialog) == DialogResult.OK)
            {
                this.ConnectionStringText.Text = dialog.ConnectionString;
            }
        }

        private void GenerateCRUD_Click(object sender, EventArgs e)
        {
            if (this.ConnectionString == string.Empty)
                return;

            CRUDForm form = new CRUDForm(this.ConnectionString);
            form.MdiParent = this;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void GenerateClass_Click(object sender, EventArgs e)
        {
            if (this.ConnectionString == string.Empty)
                return;

            ClassForm form = new ClassForm(this.ConnectionString);
            form.MdiParent = this;

            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void GenerateWCFInterfaces_Click(object sender, EventArgs e)
        {
            if (this.ConnectionString == string.Empty)
                return;

            WCFServiceGeneratorForm form = new WCFServiceGeneratorForm(this.ConnectionString);
            form.MdiParent = this;

            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void GenerateWCF_Click(object sender, EventArgs e)
        {
            if (this.ConnectionString == string.Empty)
                return;

            WCFServiceGeneratorForm form = new WCFServiceGeneratorForm(this.ConnectionString);
            form.MdiParent = this;

            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void GenerateASMXButton_Click(object sender, EventArgs e)
        {
            if (this.ConnectionString == string.Empty)
                return;

            ASMXGeneratorForm form = new ASMXGeneratorForm(this.ConnectionString);
            form.MdiParent = this;

            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void GenerateResultClass_Click(object sender, EventArgs e)
        {
            try
            {

                SaveFileDialog saveDialog = new SaveFileDialog();
                string className = string.Format("{0}Result", Common.Library_Class);
                
                saveDialog.FileName = string.Format("{0}.cs", className);

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string path = saveDialog.FileName;

                    Dictionary<string, string> values = new Dictionary<string, string>();
                    values.Add("$LibraryNamespace$", Common.Library_Namespace);
                    values.Add("$Result$", string.Format("{0}", className));

                    string fileText = File.ReadAllText(@"ClassTemplates\Result_Class.txt");
                    string text = new ClassGenerator().Generate(fileText, values);

                    if (File.Exists(path))
                    {
                        if (MessageBox.Show("File Exists. Overwrite?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                        {
                            return;
                        }
                    }

                    File.WriteAllText(path, text, Encoding.UTF8);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateSQLDataObjectClass_Click(object sender, EventArgs e)
        {
            GenerateSqlDataObjectForm form = new GenerateSqlDataObjectForm();
            form.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.ConnectionStringText.Text = $@"Data Source=localhost\SQL;Initial Catalog={Common.Default_Database};Integrated Security=True";
        }
    }
}
