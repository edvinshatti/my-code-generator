namespace xCodeGenerator
{
    partial class ClassForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassForm));
            this.SelectUnselectAll = new System.Windows.Forms.CheckBox();
            this.LoadTables = new System.Windows.Forms.Button();
            this.TablesListBox = new System.Windows.Forms.CheckedListBox();
            this.GeneratedScript = new System.Windows.Forms.RichTextBox();
            this.Generate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NamespaceText = new System.Windows.Forms.TextBox();
            this.NamespacesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GeneratedClassList = new System.Windows.Forms.ListView();
            this.GeneratedFilesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IconImageList = new System.Windows.Forms.ImageList(this.components);
            this.SaveClassFiles = new System.Windows.Forms.Button();
            this.ClassAttributes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PropertiesAttributes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AttributesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TablePrefix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RemoveTablePrefixFromType = new System.Windows.Forms.CheckBox();
            this.OverwriteExistingFiles = new System.Windows.Forms.CheckBox();
            this.SaveBrowseLocation = new System.Windows.Forms.Button();
            this.SaveLocation = new System.Windows.Forms.TextBox();
            this.SaveLocationContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteSaveLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataNamespacePart = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NamespacesContextMenuStrip.SuspendLayout();
            this.GeneratedFilesContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SaveLocationContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectUnselectAll
            // 
            this.SelectUnselectAll.AutoSize = true;
            this.SelectUnselectAll.Location = new System.Drawing.Point(6, 255);
            this.SelectUnselectAll.Name = "SelectUnselectAll";
            this.SelectUnselectAll.Size = new System.Drawing.Size(69, 17);
            this.SelectUnselectAll.TabIndex = 10;
            this.SelectUnselectAll.Text = "Select All";
            this.SelectUnselectAll.UseVisualStyleBackColor = true;
            this.SelectUnselectAll.CheckedChanged += new System.EventHandler(this.SelectUnselectAll_CheckedChanged);
            // 
            // LoadTables
            // 
            this.LoadTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadTables.Location = new System.Drawing.Point(130, 250);
            this.LoadTables.Name = "LoadTables";
            this.LoadTables.Size = new System.Drawing.Size(77, 23);
            this.LoadTables.TabIndex = 9;
            this.LoadTables.Text = "Load Tables";
            this.LoadTables.UseVisualStyleBackColor = true;
            this.LoadTables.Click += new System.EventHandler(this.LoadTables_Click);
            // 
            // TablesListBox
            // 
            this.TablesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TablesListBox.CheckOnClick = true;
            this.TablesListBox.FormattingEnabled = true;
            this.TablesListBox.Location = new System.Drawing.Point(3, 277);
            this.TablesListBox.Name = "TablesListBox";
            this.TablesListBox.Size = new System.Drawing.Size(204, 356);
            this.TablesListBox.TabIndex = 11;
            // 
            // GeneratedScript
            // 
            this.GeneratedScript.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GeneratedScript.Location = new System.Drawing.Point(3, 144);
            this.GeneratedScript.Name = "GeneratedScript";
            this.GeneratedScript.Size = new System.Drawing.Size(512, 531);
            this.GeneratedScript.TabIndex = 2;
            this.GeneratedScript.Text = "";
            this.GeneratedScript.WordWrap = false;
            // 
            // Generate
            // 
            this.Generate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Generate.Location = new System.Drawing.Point(3, 652);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(204, 23);
            this.Generate.TabIndex = 12;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Namespace";
            // 
            // NamespaceText
            // 
            this.NamespaceText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NamespaceText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.NamespaceText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.NamespaceText.ContextMenuStrip = this.NamespacesContextMenuStrip;
            this.NamespaceText.Location = new System.Drawing.Point(6, 20);
            this.NamespaceText.Name = "NamespaceText";
            this.NamespaceText.Size = new System.Drawing.Size(123, 21);
            this.NamespaceText.TabIndex = 1;
            // 
            // NamespacesContextMenuStrip
            // 
            this.NamespacesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteItemToolStripMenuItem});
            this.NamespacesContextMenuStrip.Name = "NamespacesContextMenuStrip";
            this.NamespacesContextMenuStrip.Size = new System.Drawing.Size(135, 26);
            // 
            // DeleteItemToolStripMenuItem
            // 
            this.DeleteItemToolStripMenuItem.Name = "DeleteItemToolStripMenuItem";
            this.DeleteItemToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.DeleteItemToolStripMenuItem.Text = "Delete Item";
            this.DeleteItemToolStripMenuItem.Click += new System.EventHandler(this.DeleteItemToolStripMenuItem_Click);
            // 
            // GeneratedClassList
            // 
            this.GeneratedClassList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GeneratedClassList.CheckBoxes = true;
            this.GeneratedClassList.ContextMenuStrip = this.GeneratedFilesContextMenuStrip;
            this.GeneratedClassList.LargeImageList = this.IconImageList;
            this.GeneratedClassList.Location = new System.Drawing.Point(3, 3);
            this.GeneratedClassList.MultiSelect = false;
            this.GeneratedClassList.Name = "GeneratedClassList";
            this.GeneratedClassList.Size = new System.Drawing.Size(512, 78);
            this.GeneratedClassList.SmallImageList = this.IconImageList;
            this.GeneratedClassList.TabIndex = 0;
            this.GeneratedClassList.UseCompatibleStateImageBehavior = false;
            this.GeneratedClassList.SelectedIndexChanged += new System.EventHandler(this.GeneratedClassList_SelectedIndexChanged);
            // 
            // GeneratedFilesContextMenuStrip
            // 
            this.GeneratedFilesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.selectNoneToolStripMenuItem});
            this.GeneratedFilesContextMenuStrip.Name = "GeneratedFilesContextMenuStrip";
            this.GeneratedFilesContextMenuStrip.Size = new System.Drawing.Size(138, 48);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // selectNoneToolStripMenuItem
            // 
            this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
            this.selectNoneToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.selectNoneToolStripMenuItem.Text = "Select &None";
            this.selectNoneToolStripMenuItem.Click += new System.EventHandler(this.selectNoneToolStripMenuItem_Click);
            // 
            // IconImageList
            // 
            this.IconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconImageList.ImageStream")));
            this.IconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconImageList.Images.SetKeyName(0, "cs-icon.png");
            // 
            // SaveClassFiles
            // 
            this.SaveClassFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveClassFiles.Location = new System.Drawing.Point(453, 115);
            this.SaveClassFiles.Name = "SaveClassFiles";
            this.SaveClassFiles.Size = new System.Drawing.Size(62, 23);
            this.SaveClassFiles.TabIndex = 1;
            this.SaveClassFiles.Text = "Save";
            this.SaveClassFiles.UseVisualStyleBackColor = true;
            this.SaveClassFiles.Click += new System.EventHandler(this.SaveClassFiles_Click);
            // 
            // ClassAttributes
            // 
            this.ClassAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClassAttributes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ClassAttributes.Location = new System.Drawing.Point(6, 60);
            this.ClassAttributes.Multiline = true;
            this.ClassAttributes.Name = "ClassAttributes";
            this.ClassAttributes.Size = new System.Drawing.Size(201, 48);
            this.ClassAttributes.TabIndex = 3;
            this.ClassAttributes.Text = "[TAB][Serializable]\r\n[TAB][DataContract]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Class Attributes:";
            // 
            // PropertiesAttributes
            // 
            this.PropertiesAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertiesAttributes.Location = new System.Drawing.Point(6, 127);
            this.PropertiesAttributes.Multiline = true;
            this.PropertiesAttributes.Name = "PropertiesAttributes";
            this.PropertiesAttributes.Size = new System.Drawing.Size(201, 55);
            this.PropertiesAttributes.TabIndex = 5;
            this.PropertiesAttributes.Text = "[TAB][TAB][DataMember]\r\n[TAB][TAB][TableField]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Properties Attributes:";
            // 
            // AttributesContextMenuStrip
            // 
            this.AttributesContextMenuStrip.Name = "AttributesContextMenuStrip";
            this.AttributesContextMenuStrip.Size = new System.Drawing.Size(61, 4);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DataNamespacePart);
            this.splitContainer1.Panel1.Controls.Add(this.NamespaceText);
            this.splitContainer1.Panel1.Controls.Add(this.Generate);
            this.splitContainer1.Panel1.Controls.Add(this.TablesListBox);
            this.splitContainer1.Panel1.Controls.Add(this.TablePrefix);
            this.splitContainer1.Panel1.Controls.Add(this.PropertiesAttributes);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.LoadTables);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.RemoveTablePrefixFromType);
            this.splitContainer1.Panel1.Controls.Add(this.SelectUnselectAll);
            this.splitContainer1.Panel1.Controls.Add(this.ClassAttributes);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.OverwriteExistingFiles);
            this.splitContainer1.Panel2.Controls.Add(this.SaveBrowseLocation);
            this.splitContainer1.Panel2.Controls.Add(this.SaveLocation);
            this.splitContainer1.Panel2.Controls.Add(this.GeneratedClassList);
            this.splitContainer1.Panel2.Controls.Add(this.GeneratedScript);
            this.splitContainer1.Panel2.Controls.Add(this.SaveClassFiles);
            this.splitContainer1.Size = new System.Drawing.Size(734, 678);
            this.splitContainer1.SplitterDistance = 212;
            this.splitContainer1.TabIndex = 0;
            // 
            // TablePrefix
            // 
            this.TablePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TablePrefix.Location = new System.Drawing.Point(6, 201);
            this.TablePrefix.Name = "TablePrefix";
            this.TablePrefix.Size = new System.Drawing.Size(201, 21);
            this.TablePrefix.TabIndex = 7;
            this.TablePrefix.Text = "dbo_";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Table Prefix:";
            // 
            // RemoveTablePrefixFromType
            // 
            this.RemoveTablePrefixFromType.AutoSize = true;
            this.RemoveTablePrefixFromType.Checked = true;
            this.RemoveTablePrefixFromType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RemoveTablePrefixFromType.Location = new System.Drawing.Point(6, 227);
            this.RemoveTablePrefixFromType.Name = "RemoveTablePrefixFromType";
            this.RemoveTablePrefixFromType.Size = new System.Drawing.Size(150, 17);
            this.RemoveTablePrefixFromType.TabIndex = 8;
            this.RemoveTablePrefixFromType.Text = "Remove Prefix From Type";
            this.RemoveTablePrefixFromType.UseVisualStyleBackColor = true;
            this.RemoveTablePrefixFromType.CheckedChanged += new System.EventHandler(this.SelectUnselectAll_CheckedChanged);
            // 
            // OverwriteExistingFiles
            // 
            this.OverwriteExistingFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OverwriteExistingFiles.AutoSize = true;
            this.OverwriteExistingFiles.Checked = true;
            this.OverwriteExistingFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OverwriteExistingFiles.Location = new System.Drawing.Point(309, 119);
            this.OverwriteExistingFiles.Name = "OverwriteExistingFiles";
            this.OverwriteExistingFiles.Size = new System.Drawing.Size(138, 17);
            this.OverwriteExistingFiles.TabIndex = 5;
            this.OverwriteExistingFiles.Text = "Overwrite Existing Files";
            this.OverwriteExistingFiles.UseVisualStyleBackColor = true;
            // 
            // SaveBrowseLocation
            // 
            this.SaveBrowseLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveBrowseLocation.Location = new System.Drawing.Point(453, 86);
            this.SaveBrowseLocation.Name = "SaveBrowseLocation";
            this.SaveBrowseLocation.Size = new System.Drawing.Size(62, 23);
            this.SaveBrowseLocation.TabIndex = 4;
            this.SaveBrowseLocation.Text = "Browse";
            this.SaveBrowseLocation.UseVisualStyleBackColor = true;
            this.SaveBrowseLocation.Click += new System.EventHandler(this.SaveBrowseLocation_Click);
            // 
            // SaveLocation
            // 
            this.SaveLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveLocation.ContextMenuStrip = this.SaveLocationContextMenuStrip;
            this.SaveLocation.Location = new System.Drawing.Point(3, 87);
            this.SaveLocation.Name = "SaveLocation";
            this.SaveLocation.Size = new System.Drawing.Size(444, 21);
            this.SaveLocation.TabIndex = 3;
            // 
            // SaveLocationContextMenuStrip
            // 
            this.SaveLocationContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteSaveLocationToolStripMenuItem});
            this.SaveLocationContextMenuStrip.Name = "SaveLocationContextMenuStrip";
            this.SaveLocationContextMenuStrip.Size = new System.Drawing.Size(135, 26);
            // 
            // DeleteSaveLocationToolStripMenuItem
            // 
            this.DeleteSaveLocationToolStripMenuItem.Name = "DeleteSaveLocationToolStripMenuItem";
            this.DeleteSaveLocationToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.DeleteSaveLocationToolStripMenuItem.Text = "Delete Item";
            this.DeleteSaveLocationToolStripMenuItem.Click += new System.EventHandler(this.DeleteSaveLocationToolStripMenuItem_Click);
            // 
            // DataNamespacePart
            // 
            this.DataNamespacePart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DataNamespacePart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.DataNamespacePart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.DataNamespacePart.ContextMenuStrip = this.NamespacesContextMenuStrip;
            this.DataNamespacePart.Location = new System.Drawing.Point(142, 20);
            this.DataNamespacePart.Name = "DataNamespacePart";
            this.DataNamespacePart.Size = new System.Drawing.Size(65, 21);
            this.DataNamespacePart.TabIndex = 13;
            this.DataNamespacePart.Text = "Models";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(132, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = ".";
            // 
            // ClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 678);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ClassForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Class";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClassForm_FormClosing);
            this.Load += new System.EventHandler(this.ClassForm_Load);
            this.NamespacesContextMenuStrip.ResumeLayout(false);
            this.GeneratedFilesContextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.SaveLocationContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox SelectUnselectAll;
        private System.Windows.Forms.Button LoadTables;
        private System.Windows.Forms.CheckedListBox TablesListBox;
        private System.Windows.Forms.RichTextBox GeneratedScript;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NamespaceText;
        private System.Windows.Forms.ListView GeneratedClassList;
        private System.Windows.Forms.ImageList IconImageList;
        private System.Windows.Forms.Button SaveClassFiles;
        private System.Windows.Forms.ContextMenuStrip GeneratedFilesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        private System.Windows.Forms.TextBox ClassAttributes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PropertiesAttributes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip AttributesContextMenuStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox TablePrefix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox RemoveTablePrefixFromType;
        private System.Windows.Forms.Button SaveBrowseLocation;
        private System.Windows.Forms.TextBox SaveLocation;
        private System.Windows.Forms.CheckBox OverwriteExistingFiles;
        private System.Windows.Forms.ContextMenuStrip NamespacesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteItemToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip SaveLocationContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DeleteSaveLocationToolStripMenuItem;
        private System.Windows.Forms.TextBox DataNamespacePart;
        private System.Windows.Forms.Label label5;
    }
}