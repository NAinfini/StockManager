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
        private string currentFile = "";
        private DataTable dt = new DataTable();
        private itemList items = new itemList();
        private object beforeEdit;

        public itemsForm()
        {
            InitializeComponent();
            setText();
        }


        // simple method to set all text to desired language
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

        //save list to prefered file
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (currentFile == string.Empty)
            {
                DialogResult res = MessageBox.Show(defaultLanguage.noFileOpened, defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //get a list of current order of colmns for easier access next time
            List<string> movedNames = new List<string>();
            foreach (DataGridViewColumn column in ItemGrid.Columns.OfType<DataGridViewColumn>().OrderBy(x => x.DisplayIndex))
            {
                movedNames.Add(column.Name.ToString());
            }
            //sort the order in items
            Boolean sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < movedNames.Count; i++)
                {
                    for (int j = 0; j < items.getName().Count; j++)
                    {
                        if (movedNames[i] == items.getName()[j] && i != j)
                        {
                          sorted = false;
                          items.swap(i, j);
                        }
                    }
                }
            }
            SaveFileDialog sfdlg = new SaveFileDialog();
            //open dialog to find save directory
            sfdlg.FileName = "unknown.txt";
            sfdlg.Filter = "Text Files (*.txt) | *.txt";
            sfdlg.FilterIndex = 2;
            sfdlg.RestoreDirectory = true;
            if (sfdlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfdlg.FileName, items.toString());

            }
        }


        //open file from directory
        private void openFileBtn_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            items = new itemList();
            ItemGrid.DataSource = dt;
            
            //open dialog to find directory to file
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
                //use method from itemlist to initialize items 
                items.loadFile(filePath);
                //get all names set up in datagrid
                foreach (string field in items.getName())
                {
                    dt.Columns.Add(field);
                }
                // add all items to the list
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
            currentFile = ofd.FileName.ToString();
        }
        // add an item to the list
        private void addItemBtn_Click(object sender, EventArgs e)
        {
            if (currentFile==string.Empty)
            {
                DialogResult res = MessageBox.Show(defaultLanguage.noFileOpened, defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //create item with correct types initialized
            item newItem = new item();
            foreach (Type type in items.getType())
            {
                int temp = 0;
                dynamic value3 = Convert.ChangeType(temp, type);
                newItem.addField(value3);
            }
            //add item to list and datagrid
            items.addItem(newItem);
            dt.Rows.Add(newItem.getAllFields().ToArray());
            ItemGrid.Refresh();
        }
        //add a field to the list
        private void addFieldBtn_Click(object sender, EventArgs e)
        {
            if (currentFile == string.Empty)
            {
                DialogResult res = MessageBox.Show(defaultLanguage.noFileOpened, defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Boolean flag = false;
            //open dialog to gather intel
            using (dialogForm tempForm= new dialogForm()){
            //check if the inputs are correct
                while (!flag)
                {
                    DialogResult temp = tempForm.ShowDialog();
                    if (temp == System.Windows.Forms.DialogResult.OK)
                    {
                        if (tempForm.nameGot.Equals(string.Empty))
                        {
                            DialogResult res = MessageBox.Show(defaultLanguage.emptyString, defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (tempForm.typeGot.Equals(defaultLanguage.typeDialog))
                        {
                            DialogResult res = MessageBox.Show(defaultLanguage.selectFromList, defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            flag = true;
                        }
                    }else if(temp == System.Windows.Forms.DialogResult.Cancel)
                    {
                        flag = true;
                        return;
                    }
                }
                //assign varibles and adding field to the list, datagrid
                string nameToAdd = tempForm.nameGot;
                string typeToAdd = "System.String";
                //make sure no dupe names
                // assign type to the drop list inputs
                if (tempForm.typeGot.Equals(defaultLanguage.intDialog))
                {
                    typeToAdd = "System.Int32";
                }
                else if (tempForm.typeGot.Equals(defaultLanguage.doubleDialog))
                {
                    typeToAdd = "System.Double";
                }
                else if (tempForm.typeGot.Equals(defaultLanguage.stringDialog))
                {
                    typeToAdd = "System.String";
                }
                try
                {
                    //add to list
                    items.addName(Type.GetType(typeToAdd), nameToAdd);
                }
                catch (DuplicateNameException exc)
                {
                    DialogResult res = MessageBox.Show(exc.ToString(), defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dt.Columns.Add(nameToAdd);
                //add to datagrid
                for(int i = 0; i < items.getItems().Count; i++)
                {
                    int temp = 0;
                    int lastColumnIndex = dt.Columns.Count-1;
                    dynamic value3 = Convert.ChangeType(temp, Type.GetType(typeToAdd));
                    items.getItems()[i].addField(value3);
                    dt.Rows[i][lastColumnIndex] = value3;
                }
                ItemGrid.Refresh();
            }
            
        }

        private void ItemGrid_KeyDown(object sender, KeyEventArgs e)
        {
            //go to next cell when enter is pressed
            if(e.KeyCode == Keys.Enter)
            {
                int col = ItemGrid.CurrentCell.ColumnIndex;
                int row = ItemGrid.CurrentCell.RowIndex;
                if (col < ItemGrid.Columns.Count-1)
                {
                    ItemGrid.CurrentCell = ItemGrid.Rows[row].Cells[col + 1];
                    ItemGrid.Focus();
                }
            }
            
        }

        //simple method to update itemlist 
        private void updateItem(int col,int row,object cellValue)
        {
            dynamic value3 = Convert.ChangeType(cellValue, items.getType()[col]);
            items.getItems()[row].set(col, value3);
        }

        //simple function to update itemlist after cell is edited

        private void ItemGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int col = ItemGrid.CurrentCell.ColumnIndex;
            int row = ItemGrid.CurrentCell.RowIndex;
            
            object cellValue = ItemGrid.CurrentCell.Value;
            if (items.getType()[col] == "string".GetType())
            {
                updateItem(col,row,cellValue);
            }
            else
            {
                Type castToType = items.getType()[col];
                try{
                    dynamic value3 = Convert.ChangeType(cellValue, castToType);
                    updateItem(col, row, value3);
                }
                catch (FormatException exc)
                {
                    ItemGrid.Rows[row].Cells[col].Value = beforeEdit;
                    DialogResult res = MessageBox.Show(defaultLanguage.youEntered + cellValue.ToString() + defaultLanguage.asDialog
                        + cellValue.GetType() + defaultLanguage.intoDialog + items.getType()[col].ToString()
                        , defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception eexc)
                {
                    DialogResult res = MessageBox.Show("Seomthing went wrong"+e, "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                     
            }
            
        }

        //simple method to keep track of value before a cell is edited

        private void ItemGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            beforeEdit = ItemGrid.CurrentCell.Value;
        }

        private void itemGridMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
        private void addItemMenu_Click(object sender, EventArgs e)
        {
            addItemBtn_Click(sender, e);
        }

    }
}
