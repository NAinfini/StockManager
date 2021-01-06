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
        public string currentFile = "";
        private DataTable dt = new DataTable();
        private itemList items = new itemList();
        private object beforeEdit;
        private int rowIndex=0;
        public itemsForm()
        {
            
            InitializeComponent();
            ItemGrid.ColumnDisplayIndexChanged -= ItemGrid_ColumnDisplayIndexChanged;
            startUp();
            setText();

        }


        // simple method to set all text to desired language
        private void setText()
        {
            this.Controls.Find("addItemBtn", true).FirstOrDefault().Text = defaultLanguage.addItemBtn;
            this.Controls.Find("addFieldBtn", true).FirstOrDefault().Text = defaultLanguage.addFieldBtn;
            this.Controls.Find("saveAsBtn", true).FirstOrDefault().Text = defaultLanguage.saveAsBtn;
            this.Controls.Find("saveBtn", true).FirstOrDefault().Text = defaultLanguage.saveBtn;
            this.Controls.Find("openFileBtn", true).FirstOrDefault().Text = defaultLanguage.openFileBtn;
            itemGridMenu.Items[0].Text = defaultLanguage.addItemBtn;
            itemGridMenu.Items[1].Text = defaultLanguage.addFieldBtn;
            itemGridMenu.Items[2].Text = defaultLanguage.removeItemBtn;
            itemGridMenu.Items[3].Text = defaultLanguage.removeFieldBtn;
            itemGridMenu.Items[4].Text = defaultLanguage.undoBtn;
            itemGridMenu.Items[5].Text = defaultLanguage.redoBtn;
            itemGridMenu.Items[6].Text = defaultLanguage.saveBtn;
        }

        private void itemsForm_Load(object sender, EventArgs e)
        {
            
        }

        //save list to prefered file
        private void saveBtn_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            saveLoadFunctions temp = new saveLoadFunctions();
            //AppDomain.CurrentDomain.BaseDirectory
            temp.writeToFile(@"C:\Users\NA infini\source\repos\StockManager\" +"log\\"+ DateTime.UtcNow.ToString("yyyy-MM-dd"), localDate.ToString("HH-mm-ss") + ".txt", items.toString());
            temp.sortSavedTxt(@"C:\Users\NA infini\source\repos\StockManager\" + "log\\" + DateTime.UtcNow.ToString("yyyy-MM-dd"));
        }

        private void saveAsBtn_Click(object sender, EventArgs e)
        {
            if (currentFile == string.Empty)
            {
                MessageBox.Show(defaultLanguage.noFileOpened, defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    currentFile = ofd.FileName.ToString();
                }
                catch(IndexOutOfRangeException ex)
                {
                    DialogResult res = MessageBox.Show(ex.ToString(), defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                loadFromItems();
            }

        }

        //set up grid when form is opened
        private void startUp()
        {
            
            dt = new DataTable();
            items = new itemList();
            saveLoadFunctions temp = new saveLoadFunctions();
            //AppDomain.CurrentDomain.BaseDirectory
            currentFile = temp.findLastTxt(temp.findLatestDirc(@"C:\Users\NA infini\source\repos\StockManager\" + "log\\"));
            if (currentFile != "")
            {
                items.loadFile(currentFile);
                loadFromItems();
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
                            catch (FormatException)
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
                dt.Columns.Add(nameToAdd);
                //add to datagrid
                for (int i = 0; i < items.getItems().Count; i++)
                {
                    int lastColumnIndex = dt.Columns.Count-1;
                    items.getItems()[i].addField(0);
                    dt.Rows[i][lastColumnIndex] = 0;
                }
                setCellColor();
            }
            
        }
        //remove an item from list(row)
        private void removeItemBtn_Click(object sender, EventArgs e)
        {
            
            if (!this.ItemGrid.Rows[this.rowIndex].IsNewRow)
            {
                
                foreach (DataGridViewRow row in ItemGrid.SelectedRows)
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
                }
                
                ItemGrid.Refresh();
            }


        }

        //remove a field from list(column)
        private void removeFieldBtn_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewCell cell in ItemGrid.SelectedCells)
            {
                if(MessageBox.Show(defaultLanguage.removeFields+ItemGrid.Columns[cell.ColumnIndex].Name, defaultLanguage.confirmationDialog
                    , MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    ItemGrid.ColumnDisplayIndexChanged -= ItemGrid_ColumnDisplayIndexChanged;
                    this.ItemGrid.Columns.Remove(cell.OwningColumn);
                    items.removeName(cell.OwningColumn.Name);
                    ItemGrid.ColumnDisplayIndexChanged += ItemGrid_ColumnDisplayIndexChanged;
                }
            }
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
            catch (FormatException)
            {
                items.getItems()[row].set(col, cellValue.ToString());
                ItemGrid.Rows[row].Cells[col].Style = new DataGridViewCellStyle { ForeColor = Color.Black, BackColor = Color.White };
            }
            
        }
        // set color of all cells based on valve
        private void setCellColor()
        {
            foreach (DataGridViewRow row in ItemGrid.Rows)
            {
                foreach (DataGridViewColumn column in ItemGrid.Columns.OfType<DataGridViewColumn>().OrderBy(x => x.DisplayIndex))
                {
                    try
                    {
                        double tempDouble = Convert.ToDouble(row.Cells[column.Index].Value.ToString());
                        if ((items.getValve()[column.DisplayIndex].Equals("<") && tempDouble < items.getValue()[column.DisplayIndex])
                            || (items.getValve()[column.DisplayIndex].Equals(">") && tempDouble > items.getValue()[column.DisplayIndex]))
                        {
                            row.Cells[column.Index].Style = new DataGridViewCellStyle { ForeColor = Color.Red, BackColor = Color.White };
                        }else
                        {
                            row.Cells[column.Index].Style = new DataGridViewCellStyle { ForeColor = Color.Black, BackColor = Color.White };
                        }
                    }
                    catch (FormatException)
                    {
                        row.Cells[column.Index].Style = new DataGridViewCellStyle { ForeColor = Color.Black, BackColor = Color.White };
                    }
                }
                
            }
        }

        //set cell values based on items
        private void setCellValue()
        {
            foreach (DataGridViewRow row in ItemGrid.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = items.getItems()[row.Index].getAllFields()[cell.ColumnIndex];
                }
            }
        }


        //reset context menu strip
        private void resetGridMenu()
        {
            itemGridMenu.Items.Add(addItemMenu);
            itemGridMenu.Items.Add(addFieldMemu);
            itemGridMenu.Items.Add(deleteFieldMenu);
            itemGridMenu.Items.Add(removeItemMenu);
            itemGridMenu.Items.Add(undoMenu);
            itemGridMenu.Items.Add(redoMenu);
        }

        //saves all progress on application close
        public void saveFileOnClose()
        {
            DateTime localDate = DateTime.Now;
            saveLoadFunctions temp = new saveLoadFunctions();
            //AppDomain.CurrentDomain.BaseDirectory
            temp.writeToFile(@"C:\Users\NA infini\source\repos\StockManager\" + "log\\" + DateTime.UtcNow.ToString("yyyy-MM-dd"), localDate.ToString("HH-mm-ss") + ".txt", items.toString());
            temp.sortFiles(@"C:\Users\NA infini\source\repos\StockManager\" + "log\\" + DateTime.UtcNow.ToString("yyyy-MM-dd"));
            temp.sortDirectory(@"C:\Users\NA infini\source\repos\StockManager\" + "log\\");
        }

        //Load grid with items
        private void loadFromItems()
        {
            //get all names set up in datagrid
            ItemGrid.DataSource = dt;
            foreach (string field in items.getName())
            {
                dt.Columns.Add(field);
            }
            //making emty grid for items
            foreach (item tempItem in items.getItems())
            {
                List<string> toAdd = new List<string>();
                foreach (object field in tempItem.getAllFields())
                {
                    toAdd.Add(field.ToString());
                }
                dt.Rows.Add(toAdd.ToArray());
            }
            setCellColor();
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
            resetGridMenu();
            if (e.Button == MouseButtons.Right && ItemGrid.SelectedRows.Count <=0  && e.RowIndex>=0 && e.ColumnIndex>=0)
            {
                this.ItemGrid.CurrentCell = this.ItemGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
                itemGridMenu.Items.Remove(removeItemMenu);
            }else if(ItemGrid.SelectedRows.Count >=1)
            {
                itemGridMenu.Items.Remove(deleteFieldMenu);
            }
        }


        //set cell color after reordering rows
        private void ItemGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            
        }

       

        private void ItemGrid_MouseDown(object sender, MouseEventArgs e)
        {
            ItemGrid.ColumnDisplayIndexChanged += ItemGrid_ColumnDisplayIndexChanged;
        }

        private void ItemGrid_MouseUp(object sender, MouseEventArgs e)
        {
            ItemGrid.ColumnDisplayIndexChanged -= ItemGrid_ColumnDisplayIndexChanged;
        }

        //setcolor again once grid is sorted
        private void ItemGrid_Sorted(object sender, EventArgs e)
        {
            setCellColor();
        }
    }
}
