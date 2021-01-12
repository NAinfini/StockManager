using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StockManager
{
    public partial class dialogForm : Form
    {
        public string nameGot { get; set; }
        public string valveGot { get; set; }

        public string valueGot { get; set; }
        public dialogForm()
        {
            InitializeComponent();
            setText();
        }
        private void setText()
        {
            dialogDescription.Text = defaultLanguage.dialogDescription;
            this.Controls.Find("confirmBtn", true).FirstOrDefault().Text = defaultLanguage.confirmBtn;
            dialogCombo.Items.Add(defaultLanguage.noValve);
            dialogCombo.Items.Add(defaultLanguage.lessThan);
            dialogCombo.Items.Add(defaultLanguage.greaterThan);
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            nameGot = dialogTextBox.Text.ToString();
            valveGot = dialogCombo.Text.ToString();
            valueGot = valueBox.Text.ToString();
        }


    }
}
