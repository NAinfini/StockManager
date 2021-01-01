using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StockManager
{
    public partial class itemsForm : Form
    {
        DataTable dt = new DataTable();
        private itemList items = new itemList();
        public itemsForm()
        {
            InitializeComponent();
            setText();
        }



        private void setText()
        {
            this.Controls.Find("addItemBtn", true).FirstOrDefault().Text = defaultLanguage.addItemBtn;
            this.Controls.Find("addFieldBtn", true).FirstOrDefault().Text = defaultLanguage.addFieldBtn;
            this.Controls.Find("saveBtn", true).FirstOrDefault().Text = defaultLanguage.saveBtn;
            this.Controls.Find("openFileBtn", true).FirstOrDefault().Text = defaultLanguage.openFileBtn;
        }

        private void itemsForm_Load(object sender, EventArgs e)
        {
            

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            List<string> movedNames = new List<string>();
            foreach (DataGridViewColumn column in ItemGrid.Columns.OfType<DataGridViewColumn>().OrderBy(x => x.DisplayIndex))
            {
                movedNames.Add(column.Name.ToString());
            }
            Boolean sorted = false;
            while (!sorted)
            {
                sorted = true;
                for(int i = 0; i < movedNames.Count; i++)
                {
                    for(int j = 0; j < items.getName().Count; j++)
                    {
                        if(movedNames[i] == items.getName()[j])
                        {
                            if (i != j)
                            {
                                sorted=false;
                                items.swap(i, j);
                            }
                        }
                    }
                }
            }
            SaveFileDialog sfdlg = new SaveFileDialog();
            
            sfdlg.FileName = "unknown.txt";
            sfdlg.Filter = "Text Files (*.txt) | *.txt";
            sfdlg.FilterIndex = 2;
            sfdlg.RestoreDirectory = true;
            if (sfdlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfdlg.FileName, items.toString());
                
            }
        }

        private void addItemBtn_Click(object sender, EventArgs e)
        {

            item newItem = new item();
        }



        private void openFileBtn_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            items = new itemList();
            ItemGrid.DataSource = dt;
            
            
            var filePath = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open a Text File";
            ofd.Filter = "Text Files (*.txt) | *.txt | All Files(*.*) | *.*";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                filePath = ofd.FileName;
                items.loadFile(filePath);
                foreach (string field in items.getName())
                {
                    dt.Columns.Add(field);
                }
                foreach (item value in items.getItems())
                {
                    List<string> toAdd = new List<string>();
                    foreach (object stuff in value.getAllFields())
                    {
                        toAdd.Add(stuff.ToString());
                    }
                    dt.Rows.Add(toAdd.ToArray());
                }
                ItemGrid.Refresh();
            }
            
        }

        private void addFieldBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
