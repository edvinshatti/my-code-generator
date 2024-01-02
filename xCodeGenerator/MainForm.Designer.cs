namespace xCodeGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectionStringText = new System.Windows.Forms.TextBox();
            this.CreateConnectionString = new System.Windows.Forms.Button();
            this.GenerateCRUD = new System.Windows.Forms.Button();
            this.GenerateClass = new System.Windows.Forms.Button();
            this.GenerateWCF = new System.Windows.Forms.Button();
            this.GenerateASMXButton = new System.Windows.Forms.Button();
            this.GenerateResultClass = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GenerateSQLDataObjectClass = new System.Windows.Forms.Button();
            this.MainMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection String:";
            // 
            // ConnectionStringText
            // 
            this.ConnectionStringText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionStringText.Location = new System.Drawing.Point(105, 8);
            this.ConnectionStringText.Multiline = true;
            this.ConnectionStringText.Name = "ConnectionStringText";
            this.ConnectionStringText.Size = new System.Drawing.Size(599, 21);
            this.ConnectionStringText.TabIndex = 1;
            this.ConnectionStringText.Text = "Data Source=localhost\\SQL;Initial Catalog=A;Integrated Security=True";
            // 
            // CreateConnectionString
            // 
            this.CreateConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateConnectionString.Location = new System.Drawing.Point(710, 7);
            this.CreateConnectionString.Name = "CreateConnectionString";
            this.CreateConnectionString.Size = new System.Drawing.Size(34, 23);
            this.CreateConnectionString.TabIndex = 2;
            this.CreateConnectionString.Text = "...";
            this.CreateConnectionString.UseVisualStyleBackColor = true;
            this.CreateConnectionString.Click += new System.EventHandler(this.CreateConnectionString_Click);
            // 
            // GenerateCRUD
            // 
            this.GenerateCRUD.Location = new System.Drawing.Point(6, 6);
            this.GenerateCRUD.Name = "GenerateCRUD";
            this.GenerateCRUD.Size = new System.Drawing.Size(102, 36);
            this.GenerateCRUD.TabIndex = 4;
            this.GenerateCRUD.Text = "Generate CRUD";
            this.GenerateCRUD.UseVisualStyleBackColor = true;
            this.GenerateCRUD.Click += new System.EventHandler(this.GenerateCRUD_Click);
            // 
            // GenerateClass
            // 
            this.GenerateClass.Location = new System.Drawing.Point(6, 48);
            this.GenerateClass.Name = "GenerateClass";
            this.GenerateClass.Size = new System.Drawing.Size(102, 36);
            this.GenerateClass.TabIndex = 4;
            this.GenerateClass.Text = "Generate Class";
            this.GenerateClass.UseVisualStyleBackColor = true;
            this.GenerateClass.Click += new System.EventHandler(this.GenerateClass_Click);
            // 
            // GenerateWCF
            // 
            this.GenerateWCF.Location = new System.Drawing.Point(6, 90);
            this.GenerateWCF.Name = "GenerateWCF";
            this.GenerateWCF.Size = new System.Drawing.Size(102, 36);
            this.GenerateWCF.TabIndex = 4;
            this.GenerateWCF.Text = "Generate WCF";
            this.GenerateWCF.UseVisualStyleBackColor = true;
            this.GenerateWCF.Click += new System.EventHandler(this.GenerateWCF_Click);
            // 
            // GenerateASMXButton
            // 
            this.GenerateASMXButton.Location = new System.Drawing.Point(6, 132);
            this.GenerateASMXButton.Name = "GenerateASMXButton";
            this.GenerateASMXButton.Size = new System.Drawing.Size(102, 36);
            this.GenerateASMXButton.TabIndex = 4;
            this.GenerateASMXButton.Text = "Generate ASMX";
            this.GenerateASMXButton.UseVisualStyleBackColor = true;
            this.GenerateASMXButton.Click += new System.EventHandler(this.GenerateASMXButton_Click);
            // 
            // GenerateResultClass
            // 
            this.GenerateResultClass.Location = new System.Drawing.Point(6, 174);
            this.GenerateResultClass.Name = "GenerateResultClass";
            this.GenerateResultClass.Size = new System.Drawing.Size(102, 36);
            this.GenerateResultClass.TabIndex = 5;
            this.GenerateResultClass.Text = "Generate Result Class";
            this.GenerateResultClass.UseVisualStyleBackColor = true;
            this.GenerateResultClass.Click += new System.EventHandler(this.GenerateResultClass_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(747, 24);
            this.MainMenu.TabIndex = 7;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CreateConnectionString);
            this.panel1.Controls.Add(this.ConnectionStringText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(747, 36);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Controls.Add(this.GenerateCRUD);
            this.panel2.Controls.Add(this.GenerateClass);
            this.panel2.Controls.Add(this.GenerateSQLDataObjectClass);
            this.panel2.Controls.Add(this.GenerateResultClass);
            this.panel2.Controls.Add(this.GenerateWCF);
            this.panel2.Controls.Add(this.GenerateASMXButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(115, 420);
            this.panel2.TabIndex = 9;
            // 
            // GenerateSQLDataObjectClass
            // 
            this.GenerateSQLDataObjectClass.Location = new System.Drawing.Point(6, 216);
            this.GenerateSQLDataObjectClass.Name = "GenerateSQLDataObjectClass";
            this.GenerateSQLDataObjectClass.Size = new System.Drawing.Size(102, 53);
            this.GenerateSQLDataObjectClass.TabIndex = 5;
            this.GenerateSQLDataObjectClass.Text = "Generate SqlDataObject Class";
            this.GenerateSQLDataObjectClass.UseVisualStyleBackColor = true;
            this.GenerateSQLDataObjectClass.Click += new System.EventHandler(this.GenerateSQLDataObjectClass_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 480);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainMenu);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "xCode Generator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ConnectionStringText;
        private System.Windows.Forms.Button CreateConnectionString;
        private System.Windows.Forms.Button GenerateCRUD;
        private System.Windows.Forms.Button GenerateClass;
        private System.Windows.Forms.Button GenerateWCF;
        private System.Windows.Forms.Button GenerateASMXButton;
        private System.Windows.Forms.Button GenerateResultClass;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button GenerateSQLDataObjectClass;
    }
}

