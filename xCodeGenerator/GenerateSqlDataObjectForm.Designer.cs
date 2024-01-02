namespace xCodeGenerator
{
    partial class GenerateSqlDataObjectForm
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
            this.Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NamespaceText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveFilePath = new System.Windows.Forms.TextBox();
            this.BrowseForPath = new System.Windows.Forms.Button();
            this.OverwriteExisting = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.Location = new System.Drawing.Point(447, 121);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 8;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Namespace:";
            // 
            // NamespaceText
            // 
            this.NamespaceText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NamespaceText.Location = new System.Drawing.Point(94, 45);
            this.NamespaceText.Name = "NamespaceText";
            this.NamespaceText.Size = new System.Drawing.Size(428, 21);
            this.NamespaceText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Path:";
            // 
            // SaveFilePath
            // 
            this.SaveFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveFilePath.Location = new System.Drawing.Point(94, 72);
            this.SaveFilePath.Name = "SaveFilePath";
            this.SaveFilePath.Size = new System.Drawing.Size(390, 21);
            this.SaveFilePath.TabIndex = 5;
            // 
            // BrowseForPath
            // 
            this.BrowseForPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseForPath.Location = new System.Drawing.Point(490, 70);
            this.BrowseForPath.Name = "BrowseForPath";
            this.BrowseForPath.Size = new System.Drawing.Size(32, 23);
            this.BrowseForPath.TabIndex = 6;
            this.BrowseForPath.Text = "...";
            this.BrowseForPath.UseVisualStyleBackColor = true;
            this.BrowseForPath.Click += new System.EventHandler(this.BrowseForPath_Click);
            // 
            // OverwriteExisting
            // 
            this.OverwriteExisting.AutoSize = true;
            this.OverwriteExisting.Checked = true;
            this.OverwriteExisting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OverwriteExisting.Location = new System.Drawing.Point(308, 125);
            this.OverwriteExisting.Name = "OverwriteExisting";
            this.OverwriteExisting.Size = new System.Drawing.Size(133, 17);
            this.OverwriteExisting.TabIndex = 7;
            this.OverwriteExisting.Text = "Overwrite Existing File";
            this.OverwriteExisting.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "File Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "SqlDataObject.cs";
            // 
            // GenerateSqlDataObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 151);
            this.Controls.Add(this.OverwriteExisting);
            this.Controls.Add(this.BrowseForPath);
            this.Controls.Add(this.SaveFilePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NamespaceText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Save);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(550, 150);
            this.Name = "GenerateSqlDataObjectForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generate SqlDataObject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NamespaceText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SaveFilePath;
        private System.Windows.Forms.Button BrowseForPath;
        private System.Windows.Forms.CheckBox OverwriteExisting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}