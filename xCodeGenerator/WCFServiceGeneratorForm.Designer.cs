namespace xCodeGenerator
{
    partial class WCFServiceGeneratorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WCFServiceGeneratorForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ClassName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TablePrefix = new System.Windows.Forms.TextBox();
            this.Generate = new System.Windows.Forms.Button();
            this.TablesListBox = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RemoveTablePrefixFromType = new System.Windows.Forms.CheckBox();
            this.LoadTables = new System.Windows.Forms.Button();
            this.SelectUnselectAll = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.GeneratedItems = new System.Windows.Forms.ListView();
            this.IconImageList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.GeneratedInterfaceScript = new System.Windows.Forms.RichTextBox();
            this.GeneratedImplementationScript = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ClassName);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.TablePrefix);
            this.splitContainer1.Panel1.Controls.Add(this.Generate);
            this.splitContainer1.Panel1.Controls.Add(this.TablesListBox);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.RemoveTablePrefixFromType);
            this.splitContainer1.Panel1.Controls.Add(this.LoadTables);
            this.splitContainer1.Panel1.Controls.Add(this.SelectUnselectAll);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(959, 612);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 0;
            // 
            // ClassName
            // 
            this.ClassName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClassName.Location = new System.Drawing.Point(6, 26);
            this.ClassName.Name = "ClassName";
            this.ClassName.Size = new System.Drawing.Size(202, 21);
            this.ClassName.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Class:";
            // 
            // TablePrefix
            // 
            this.TablePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TablePrefix.Location = new System.Drawing.Point(6, 66);
            this.TablePrefix.Name = "TablePrefix";
            this.TablePrefix.Size = new System.Drawing.Size(202, 21);
            this.TablePrefix.TabIndex = 18;
            // 
            // Generate
            // 
            this.Generate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Generate.Location = new System.Drawing.Point(3, 586);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(210, 23);
            this.Generate.TabIndex = 16;
            this.Generate.Text = "Generate";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // TablesListBox
            // 
            this.TablesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TablesListBox.CheckOnClick = true;
            this.TablesListBox.FormattingEnabled = true;
            this.TablesListBox.Location = new System.Drawing.Point(3, 150);
            this.TablesListBox.Name = "TablesListBox";
            this.TablesListBox.Size = new System.Drawing.Size(210, 404);
            this.TablesListBox.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Table Prefix:";
            // 
            // RemoveTablePrefixFromType
            // 
            this.RemoveTablePrefixFromType.AutoSize = true;
            this.RemoveTablePrefixFromType.Location = new System.Drawing.Point(6, 99);
            this.RemoveTablePrefixFromType.Name = "RemoveTablePrefixFromType";
            this.RemoveTablePrefixFromType.Size = new System.Drawing.Size(150, 17);
            this.RemoveTablePrefixFromType.TabIndex = 19;
            this.RemoveTablePrefixFromType.Text = "Remove Prefix From Type";
            this.RemoveTablePrefixFromType.UseVisualStyleBackColor = true;
            // 
            // LoadTables
            // 
            this.LoadTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadTables.Location = new System.Drawing.Point(136, 122);
            this.LoadTables.Name = "LoadTables";
            this.LoadTables.Size = new System.Drawing.Size(77, 23);
            this.LoadTables.TabIndex = 13;
            this.LoadTables.Text = "Load Tables";
            this.LoadTables.UseVisualStyleBackColor = true;
            this.LoadTables.Click += new System.EventHandler(this.LoadTables_Click);
            // 
            // SelectUnselectAll
            // 
            this.SelectUnselectAll.AutoSize = true;
            this.SelectUnselectAll.Location = new System.Drawing.Point(6, 127);
            this.SelectUnselectAll.Name = "SelectUnselectAll";
            this.SelectUnselectAll.Size = new System.Drawing.Size(69, 17);
            this.SelectUnselectAll.TabIndex = 14;
            this.SelectUnselectAll.Text = "Select All";
            this.SelectUnselectAll.UseVisualStyleBackColor = true;
            this.SelectUnselectAll.CheckedChanged += new System.EventHandler(this.SelectUnselectAll_CheckedChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.GeneratedItems);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(733, 612);
            this.splitContainer2.SplitterDistance = 93;
            this.splitContainer2.TabIndex = 4;
            // 
            // GeneratedItems
            // 
            this.GeneratedItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneratedItems.LargeImageList = this.IconImageList;
            this.GeneratedItems.Location = new System.Drawing.Point(0, 0);
            this.GeneratedItems.Name = "GeneratedItems";
            this.GeneratedItems.Size = new System.Drawing.Size(93, 612);
            this.GeneratedItems.SmallImageList = this.IconImageList;
            this.GeneratedItems.TabIndex = 0;
            this.GeneratedItems.UseCompatibleStateImageBehavior = false;
            this.GeneratedItems.SelectedIndexChanged += new System.EventHandler(this.GeneratedItems_SelectedIndexChanged);
            // 
            // IconImageList
            // 
            this.IconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconImageList.ImageStream")));
            this.IconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconImageList.Images.SetKeyName(0, "1373118710_gnome-mime-text-xml.png");
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.GeneratedInterfaceScript);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.GeneratedImplementationScript);
            this.splitContainer3.Size = new System.Drawing.Size(636, 612);
            this.splitContainer3.SplitterDistance = 305;
            this.splitContainer3.TabIndex = 4;
            // 
            // GeneratedInterfaceScript
            // 
            this.GeneratedInterfaceScript.AcceptsTab = true;
            this.GeneratedInterfaceScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneratedInterfaceScript.Location = new System.Drawing.Point(0, 0);
            this.GeneratedInterfaceScript.Name = "GeneratedInterfaceScript";
            this.GeneratedInterfaceScript.Size = new System.Drawing.Size(636, 305);
            this.GeneratedInterfaceScript.TabIndex = 3;
            this.GeneratedInterfaceScript.Text = "";
            this.GeneratedInterfaceScript.WordWrap = false;
            // 
            // GeneratedImplementationScript
            // 
            this.GeneratedImplementationScript.AcceptsTab = true;
            this.GeneratedImplementationScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GeneratedImplementationScript.Location = new System.Drawing.Point(0, 0);
            this.GeneratedImplementationScript.Name = "GeneratedImplementationScript";
            this.GeneratedImplementationScript.Size = new System.Drawing.Size(636, 303);
            this.GeneratedImplementationScript.TabIndex = 4;
            this.GeneratedImplementationScript.Text = "";
            this.GeneratedImplementationScript.WordWrap = false;
            // 
            // WCFServiceGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 612);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "WCFServiceGeneratorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WCFServiceGeneratorForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.CheckedListBox TablesListBox;
        private System.Windows.Forms.Button LoadTables;
        private System.Windows.Forms.CheckBox SelectUnselectAll;
        private System.Windows.Forms.ListView GeneratedItems;
        private System.Windows.Forms.ImageList IconImageList;
        private System.Windows.Forms.TextBox TablePrefix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox RemoveTablePrefixFromType;
        private System.Windows.Forms.RichTextBox GeneratedInterfaceScript;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.RichTextBox GeneratedImplementationScript;
        private System.Windows.Forms.TextBox ClassName;
        private System.Windows.Forms.Label label1;
    }
}