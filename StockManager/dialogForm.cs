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
        public string typeGot { get; set; }
        public dialogForm()
        {
            InitializeComponent();
            setText();
        }
        private void setText()
        {
            dialogDescription.Text = defaultLanguage.dialogDescription;
            this.Controls.Find("confirmBtn", true).FirstOrDefault().Text = defaultLanguage.confirmBtn;
            dialogCombo.Items.Add(defaultLanguage.stringDialog);
            dialogCombo.Items.Add(defaultLanguage.doubleDialog);
            dialogCombo.Items.Add(defaultLanguage.intDialog);
        }



        private void confirmBtn_Click(object sender, EventArgs e)
        {
            nameGot = dialogTextBox.Text.ToString();
            typeGot = dialogCombo.Text.ToString();
            


        }

    }
}
