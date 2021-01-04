using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        private int rowIndex=0;
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
            itemGridMenu.Items[0].Text = defaultLanguage.addItemBtn;
            itemGridMenu.Items[1].Text = defaultLanguage.addFieldBtn;
            itemGridMenu.Items[2].Text = defaultLanguage.removeItemBtn;
            itemGridMenu.Items[3].Text = defaultLanguage.removeFieldBtn;
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
                try
                {
                    items.loadFile(filePath);
                }
                catch(IndexOutOfRangeException ex)
                {
                    DialogResult res = MessageBox.Show(ex.ToString(), defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                //get all names set up in datagrid
                ItemGrid.ColumnDisplayIndexChanged -= ItemGrid_ColumnDisplayIndexChanged;
                foreach (string field in items.getName())
                {
                    dt.Columns.Add(field);
                }
                ItemGrid.ColumnDisplayIndexChanged += ItemGrid_ColumnDisplayIndexChanged;
                //making emty grid for items
                foreach (item tempItem in items.getItems())
                {
                    List<string> toAdd = new List<string>();
                    foreach(object field in tempItem.getAllFields())
                    {
                        toAdd.Add(string.Empty);
                    }
                    dt.Rows.Add(toAdd.ToArray());
                }
                updateGrid();
            }
            currentFile = ofd.FileName.ToString();
        }
        private void updateGrid()
        {
            ItemGrid.Refresh();
            // add all items to the list
            List<Entry> indexToSetColor = new List<Entry>();
            List<Entry> indexToResetColor = new List<Entry>();
            for (int i=0;i< items.getItems().Count;i++)
            {
                for (int j = 0; j < items.getName().Count; j++)
                {
                    if (items.getValve()[j].Equals("="))
                    {
                        ItemGrid.Rows[i].Cells[j].Value = items.getItems()[i].getAllFields()[j].ToString();
                    }
                    else
                    {
                        double tempDouble = 0;
                        try
                        {
                            tempDouble = Convert.ToDouble(items.getItems()[i].getAllFields()[j]);
                            if ((items.getValve()[j].Equals("<")&& items.getValue()[j] > tempDouble) ||(items.getValve()[j].Equals(">")&& items.getValue()[j] < tempDouble))
                            {
                                ItemGrid.Rows[i].Cells[j].Value = tempDouble;
                                Entry tempEntry = new Entry(i, j);
                                indexToSetColor.Add(tempEntry);
                            }
                            else
                            {
                                
                                    Entry tempEntry = new Entry(i, j);
                                    indexToResetColor.Add(tempEntry);
                            }
                        }
                        catch (FormatException ex)
                        {
                            ItemGrid.Rows[i].Cells[j].Value = items.getItems()[i].getAllFields()[j].ToString();
                        }
                    }


                }
                
            }
            foreach(Entry tempEntry in indexToSetColor)
            {
                ItemGrid.Rows[tempEntry.value1].Cells[tempEntry.value2].Style = new DataGridViewCellStyle { ForeColor = Color.Red, BackColor = Color.White };
            }

            foreach (Entry tempEntry in indexToResetColor)
            {
                ItemGrid.Rows[tempEntry.value1].Cells[tempEntry.value2].Style = new DataGridViewCellStyle { ForeColor = Color.Black, BackColor = Color.White };
            }
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
            foreach (string name in items.getName())
            {
                newItem.addField(0);
            }
            //add item to list and datagrid
            items.addItem(newItem);
            dt.Rows.Add(newItem.getAllFields().ToArray());
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
                        else if (tempForm.valveGot.Equals(defaultLanguage.valveDialog))
                        {
                            DialogResult res = MessageBox.Show(defaultLanguage.selectFromList, defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else 
                        {
                            try
                            {
                                double value3 = Convert.ToDouble(tempForm.valueGot);
                                flag = true;
                            }
                            catch (FormatException ex)
                            {
                                DialogResult res = MessageBox.Show(defaultLanguage.invalidValue, defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                    }else if(temp == System.Windows.Forms.DialogResult.Cancel)
                    {
                        flag = true;
                        return;
                    }
                }
                //assign varibles and adding field to the list, datagrid
                string nameToAdd = tempForm.nameGot;
                string valveToAdd = "=";
                if (tempForm.valveGot.Equals(defaultLanguage.lessThan)){
                    valveToAdd = "<";
                }
                else if (tempForm.valveGot.Equals(defaultLanguage.greaterThan))
                {
                    valveToAdd = ">";
                }
                else if (tempForm.valveGot.Equals(defaultLanguage.noValve))
                {
                    valveToAdd = "=";
                }
                double valueToAdd = Convert.ToDouble(tempForm.valueGot);
                //make sure no dupe names
                // assign type to the drop list inputs

                try
                {
                    //add to list
                    items.addName(valveToAdd, valueToAdd, nameToAdd);
                }
                catch (DuplicateNameException exc)
                {
                    DialogResult res = MessageBox.Show(exc.ToString(), defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ItemGrid.ColumnDisplayIndexChanged -= ItemGrid_ColumnDisplayIndexChanged;
                dt.Columns.Add(nameToAdd);
                ItemGrid.ColumnDisplayIndexChanged += ItemGrid_ColumnDisplayIndexChanged;
                //add to datagrid
                for (int i = 0; i < items.getItems().Count; i++)
                {
                    int lastColumnIndex = dt.Columns.Count-1;
                    
                    items.getItems()[i].addField(0);
                    dt.Rows[i][lastColumnIndex] = 0;
                }
                updateGrid();
            }
            
        }
        //remove an item from list(row)
        private void removeItemBtn_Click(object sender, EventArgs e)
        {
            
            if (!this.ItemGrid.Rows[this.rowIndex].IsNewRow)
            {
                List<int> order = new List<int>();
                item tempItem = new item();
                foreach (DataGridViewColumn column in ItemGrid.Columns.OfType<DataGridViewColumn>().OrderBy(x => x.DisplayIndex))
                {
                    order.Add(column.Index);
                }
                foreach (int num in order)
                {
                    tempItem.addField(ItemGrid.Rows[rowIndex].Cells[num].Value.ToString());
                }
                this.ItemGrid.Rows.RemoveAt(this.rowIndex);
                items.removeItem(tempItem);
                ItemGrid.Refresh();
            }
            
            
        }

        //remove a field from list(column)
        private void removeFieldBtn_Click(object sender, EventArgs e)
        {

        }

        //go to next cell when enter is pressed
        private void ItemGrid_KeyDown(object sender, KeyEventArgs e)
        {
            
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
            try
            {
                double tempValue = Convert.ToDouble(cellValue);
                items.getItems()[row].set(col, tempValue);
                if ((items.getValve()[col].Equals("<") && items.getValue()[col] > tempValue) || (items.getValve()[col].Equals(">") && items.getValue()[col] < tempValue))
                {
                    ItemGrid.Rows[row].Cells[col].Style = new DataGridViewCellStyle { ForeColor = Color.Red, BackColor = Color.White };
                }
                else
                {
                    ItemGrid.Rows[row].Cells[col].Style = new DataGridViewCellStyle { ForeColor = Color.Black, BackColor = Color.White };
                }
            }
            catch (FormatException e)
            {
                items.getItems()[row].set(col, cellValue.ToString());
                ItemGrid.Rows[row].Cells[col].Style = new DataGridViewCellStyle { ForeColor = Color.Black, BackColor = Color.White };
            }
            
        }

        //simple function to update itemlist after cell is edited

        private void ItemGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int col = ItemGrid.CurrentCell.ColumnIndex;
            int row = ItemGrid.CurrentCell.RowIndex;
            
            object cellValue = ItemGrid.CurrentCell.Value;
            updateItem(col, row, cellValue);
 
            
        }

        //simple method to keep track of value before a cell is edited

        private void ItemGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            beforeEdit = ItemGrid.CurrentCell.Value;
        }

        
        
        
        //make sure Items is in right order when column display index is changed
        //need ItemGrid.ColumnDisplayIndexChanged +=(-=) method before/after adding column to list
        private void ItemGrid_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
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
        }


        //set current cell to cell right clcked on
        private void ItemGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.ItemGrid.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.ItemGrid.CurrentCell = this.ItemGrid.Rows[e.RowIndex].Cells[1];
            }
        }
    }
}
