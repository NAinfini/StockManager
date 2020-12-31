using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StockManager
{
    public partial class itemsForm : Form
    {
        public itemsForm()
        {
            InitializeComponent();
            setText();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void setText()
        {
            this.Controls.Find("addItemBtn", true).FirstOrDefault().Text = defaultLanguage.addItemBtn;
            this.Controls.Find("addFieldBtn", true).FirstOrDefault().Text = defaultLanguage.addFieldBtn;
        }

        private void itemsForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            itemList items = new itemList();
            items.loadFile("test.txt");
            foreach (string field in items.getName())
            {
                dt.Columns.Add(field);
            }
            foreach(item value in items.getItems())
            {
                List<string> toAdd = new List<string>();
                foreach(object stuff in value.getAllFields())
                {
                    toAdd.Add(stuff.ToString());
                }
                dt.Rows.Add(toAdd.ToArray());
            }
            
            ItemGrid.DataSource = dt;
        }
    }
}
