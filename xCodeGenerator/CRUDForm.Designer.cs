namespace xCodeGenerator
{
    partial class CRUDForm
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
            this.OptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.ProcedureType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Generate = new System.Windows.Forms.Button();
            this.GeneratedScript = new System.Windows.Forms.RichTextBox();
            this.TablesListBox = new System.Windows.Forms.CheckedListBox();
            this.LoadTables = new System.Windows.Forms.Button();
            this.SelectUnselectAll = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.OptionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OptionsGroupBox
            // 
            this.OptionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionsGroupBox.Controls.Add(this.ProcedureType);
            this.OptionsGroupBox.Controls.Add(this.label2);
            this.OptionsGroupBox.Location = new System.Drawing.Point(3, 3);
            this.OptionsGroupBox.Name = "OptionsGroupBox";
            this.OptionsGroupBox.Size = new System.Drawing.Size(223, 72);
            this.OptionsGroupBox.TabIndex = 0;
            this.OptionsGroupBox.TabStop = false;
            this.OptionsGroupBox.Text = "Options";
            // 
            // ProcedureType
            // 
            this.ProcedureType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcedureType.FormattingEnabled = true;
            this.ProcedureType.Items.AddRange(new object[] {
            "Create",
            "Alter",
            "Drop"});
            this.ProcedureType.Location = new System.Drawing.Point(9, 40);
            this.ProcedureType.Name = "ProcedureType";
            this.ProcedureType.Size = new System.Drawing.Size(208, 21);
            this.ProcedureType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Generate Type:";
            // 
            // Generate
            // 
            this.Generate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Generate.Location = new System.Drawing.Point(3, 500);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(223, 23);
            this.Generate.TabIndex = 4;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // GeneratedScript
            // 
            this.GeneratedScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneratedScript.Location = new System.Drawing.Point(0, 0);
            this.GeneratedScript.Name = "GeneratedScript";
            this.GeneratedScript.Size = new System.Drawing.Size(517, 532);
            this.GeneratedScript.TabIndex = 0;
            this.GeneratedScript.Text = "";
            this.GeneratedScript.WordWrap = false;
            // 
            // TablesListBox
            // 
            this.TablesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TablesListBox.CheckOnClick = true;
            this.TablesListBox.FormattingEnabled = true;
            this.TablesListBox.Location = new System.Drawing.Point(3, 98);
            this.TablesListBox.Name = "TablesListBox";
            this.TablesListBox.Size = new System.Drawing.Size(223, 388);
            this.TablesListBox.TabIndex = 3;
            // 
            // LoadTables
            // 
            this.LoadTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadTables.Location = new System.Drawing.Point(149, 74);
            this.LoadTables.Name = "LoadTables";
            this.LoadTables.Size = new System.Drawing.Size(77, 23);
            this.LoadTables.TabIndex = 1;
            this.LoadTables.Text = "Load Tables";
            this.LoadTables.UseVisualStyleBackColor = true;
            this.LoadTables.Click += new System.EventHandler(this.LoadTables_Click);
            // 
            // SelectUnselectAll
            // 
            this.SelectUnselectAll.AutoSize = true;
            this.SelectUnselectAll.Location = new System.Drawing.Point(6, 79);
            this.SelectUnselectAll.Name = "SelectUnselectAll";
            this.SelectUnselectAll.Size = new System.Drawing.Size(69, 17);
            this.SelectUnselectAll.TabIndex = 2;
            this.SelectUnselectAll.Text = "Select All";
            this.SelectUnselectAll.UseVisualStyleBackColor = true;
            this.SelectUnselectAll.CheckedChanged += new System.EventHandler(this.SelectUnselectAll_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.OptionsGroupBox);
            this.splitContainer1.Panel1.Controls.Add(this.SelectUnselectAll);
            this.splitContainer1.Panel1.Controls.Add(this.TablesListBox);
            this.splitContainer1.Panel1.Controls.Add(this.LoadTables);
            this.splitContainer1.Panel1.Controls.Add(this.Generate);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GeneratedScript);
            this.splitContainer1.Size = new System.Drawing.Size(750, 532);
            this.splitContainer1.SplitterDistance = 229;
            this.splitContainer1.TabIndex = 0;
            // 
            // CRUDForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 532);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CRUDForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRUD";
            this.Load += new System.EventHandler(this.CRUDForm_Load);
            this.OptionsGroupBox.ResumeLayout(false);
            this.OptionsGroupBox.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox OptionsGroupBox;
        private System.Windows.Forms.ComboBox ProcedureType;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox GeneratedScript;
        private System.Windows.Forms.CheckedListBox TablesListBox;
        private System.Windows.Forms.Button LoadTables;
        private System.Windows.Forms.CheckBox SelectUnselectAll;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}