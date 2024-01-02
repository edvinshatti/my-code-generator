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
    public partial class ResultForm : Form
    {
        public ResultForm(string message)
        {
            InitializeComponent();

            this.ResultRichTextBox.Text = message;
        }

        private void WordWrapCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.ResultRichTextBox.WordWrap = !this.ResultRichTextBox.WordWrap;
        }
    }
}
