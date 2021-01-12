using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StockManager
{
    public partial class itemsForm : Form
    {
        #region instances


        public string currentFile = "";
        public string currentFileName = "";
        private DataTable dt = new DataTable();
        private itemList items = new itemList();
        private object beforeEdit;
        private int rowIndex=0;
        private List<string> undoStack = new List<string>();
        private List<string> redoStack = new List<string>();
        private Boolean changesToFile = false;


        #endregion


        #region DataGrid load


        public itemsForm()
        {
            
            InitializeComponent();
            ItemGrid.ColumnDisplayIndexChanged -= ItemGrid_ColumnDisplayIndexChanged;
            startUp();
            setText();

        }
        private void itemsForm_Load(object sender, EventArgs e)
        {
            InitTimer();
        }


        #endregion


        #region custome methods


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

        //code that runs on start up
        private void startUp()
        {
            dt = new DataTable();
            items = new itemList();
            saveLoadFunctions temp = new saveLoadFunctions();
            //AppDomain.CurrentDomain.BaseDirectory
            string Dirc = @"C:\Users\NA infini\source\repos\StockManager\" + "log\\";
            string lastDirc = temp.findLatestDirc(Dirc);
            string lastTxt = temp.findLastTxt(Dirc + lastDirc);
            currentFile = Dirc + lastDirc + lastTxt;
            currentFileName = Regex.Replace(lastTxt.Replace(".txt", "").Replace("-", ""), @"[\d-]", string.Empty);
            if (currentFile != "")
            {
                undoStack.Add(currentFile);
                items.loadFile(currentFile);
                loadFromItems();
            }
        }

        //saves all progress on application close
        public void saveFileOnClose()
        {
            ItemGrid.EndEdit();
            DateTime localDate = DateTime.Now;
            saveLoadFunctions temp = new saveLoadFunctions();
            //AppDomain.CurrentDomain.BaseDirectory
            temp.writeToFile(@"C:\Users\NA infini\source\repos\StockManager\" + "log\\" +
                DateTime.UtcNow.ToString("yyyy-MM-dd"), localDate.ToString("HH-mm-ss"), currentFileName, items.toString());
            temp.sortFiles(@"C:\Users\NA infini\source\repos\StockManager\" + "log\\" +
                DateTime.UtcNow.ToString("yyyy-MM-dd"));
            temp.sortDirectory(@"C:\Users\NA infini\source\repos\StockManager\" + "log\\");
            File.WriteAllText(currentFile, items.toString());
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
            dt.Columns.Add("id");
            //ItemGrid.Columns["id"].Visible = false;
            //making emty grid for items
            foreach (ArrayList tempItem in items.getItems())
            {
                List<string> toAdd = new List<string>();
                foreach (object field in tempItem)
                {
                    toAdd.Add(field.ToString());
                }
                dt.Rows.Add(toAdd.ToArray());
            }
            setCellColor();
        }

        // set color of all cells based on valve
        private void setCellColor()
        {
            foreach (DataGridViewColumn column in ItemGrid.Columns.OfType<DataGridViewColumn>().OrderBy(x => x.DisplayIndex))
            {
                if (column.Name.Equals("id"))
                {

                }
                else if (!items.getValve()[items.getName().IndexOf(column.Name)].Equals("="))
                {
                    foreach (DataGridViewRow row in ItemGrid.Rows)
                    {
                        double tempDouble = 0;
                        try
                        {
                            tempDouble = Convert.ToDouble(row.Cells[column.Index].Value.ToString());
                        }
                        catch (FormatException)
                        {
                            row.Cells[column.Index].Style = new DataGridViewCellStyle { ForeColor = Color.Black, BackColor = Color.White };
                        }
                        if ((items.getValve()[column.DisplayIndex].Equals("<") && Convert.ToDouble(row.Cells[column.Index].Value.ToString()) < items.getValue()[column.DisplayIndex])
                                || (items.getValve()[column.DisplayIndex].Equals(">") && Convert.ToDouble(row.Cells[column.Index].Value.ToString()) > items.getValue()[column.DisplayIndex]))
                        {
                            row.Cells[column.Index].Style = new DataGridViewCellStyle { ForeColor = Color.Red, BackColor = Color.White };
                        }
                        else
                        {
                            row.Cells[column.Index].Style = new DataGridViewCellStyle { ForeColor = Color.Black, BackColor = Color.White };
                        }
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
                    cell.Value = items.getItems()[row.Index][cell.ColumnIndex];
                }
            }
        }

        //simple method to update itemlist 
        private void updateItem(int col, int row, int itemIndex, object cellValue)
        {
            try
            {
                double tempValue = Convert.ToDouble(cellValue);
                items.set(col, itemIndex, tempValue);

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
                items.set(col, itemIndex, cellValue.ToString());
            }

        }


        #endregion


        #region ContextMenu and button actions


        //save list to prefered file
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (changesToFile)
            {
                saveLoadFunctions temp = new saveLoadFunctions();
                redoStack.Clear();
                ItemGrid.EndEdit();
                DateTime localDate = DateTime.Now;
                //AppDomain.CurrentDomain.BaseDirectory
                undoStack.Add(@"C:\Users\NA infini\source\repos\StockManager\" + "log\\" +
                    DateTime.UtcNow.ToString("yyyy-MM-dd") + "\\" + localDate.ToString("HH-mm-ss")+currentFileName + ".txt");
                if (undoStack.Count > 50)
                {
                    undoStack.RemoveAt(0);
                }
                temp.writeToFile(@"C:\Users\NA infini\source\repos\StockManager\" + "log\\" +
                    DateTime.UtcNow.ToString("yyyy-MM-dd"), localDate.ToString("HH-mm-ss"),currentFileName, items.toString());
                temp.sortSavedTxt(@"C:\Users\NA infini\source\repos\StockManager\" + "log\\" + DateTime.UtcNow.ToString("yyyy-MM-dd"));
                File.WriteAllText(currentFile, items.toString());
                changesToFile = false;
            }
        }

        //set up grid when form is opened
        
        private void saveAsBtn_Click(object sender, EventArgs e)
        {
            ItemGrid.EndEdit();
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
            undoStack.Clear();
            redoStack.Clear();
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
                    undoStack.Add(filePath);
                    currentFile = filePath;
                    currentFileName = ofd.SafeFileName.Replace(".txt","");
                }
                catch(IndexOutOfRangeException ex)
                {
                    DialogResult res = MessageBox.Show(ex.ToString(), defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                loadFromItems();
            }

        }
        
        // add an item to the list
        private void addItemBtn_Click(object sender, EventArgs e)
        {
            changesToFile = true;
            if (currentFile==string.Empty)
            {
                DialogResult res = MessageBox.Show(defaultLanguage.noFileOpened, defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //create item with correct types initialized
            ArrayList newItem = new ArrayList();
            foreach (string name in items.getName())
            {
                newItem.Add(0);
            }
            newItem.Add(items.getItems().Count);
            //add item to list and datagrid
            items.addItem(newItem);
            dt.Rows.Add(newItem.ToArray());
        }

        //add a field to the list
        private void addFieldBtn_Click(object sender, EventArgs e)
        {
            changesToFile = true;
            if (currentFile == string.Empty)
            {
                DialogResult res = MessageBox.Show(defaultLanguage.noFileOpened, defaultLanguage.confirmationDialog, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Boolean flag = false;
            double valueToAdd = 0;
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
                        else if (tempForm.valveGot.Equals(defaultLanguage.noValve))
                        {
                            flag = true;
                        }
                        else
                        {
                            try
                            {
                                valueToAdd = Convert.ToDouble(tempForm.valueGot);
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
                DataGridViewColumn columnToAdd = new DataGridViewColumn();
                columnToAdd.Name = nameToAdd;
                columnToAdd.CellTemplate = new DataGridViewTextBoxCell();
                ItemGrid.Columns.Insert(ItemGrid.Columns.Count-1, columnToAdd);
                //add to datagrid
                for (int i = 0; i < items.getItems().Count; i++)
                {
                    items.getItems()[i].Add(0);
                    ItemGrid.Rows[i].Cells[dt.Columns.Count - 1].Value = 0;
                }
            }
            setCellColor();
            
        }

        //remove an item from list(row)
        private void removeItemBtn_Click(object sender, EventArgs e)
        {
            changesToFile = true;
            if (!this.ItemGrid.Rows[this.rowIndex].IsNewRow)
                foreach (DataGridViewRow row in ItemGrid.SelectedRows)
                {
                    int rowToRemove = Int32.Parse(row.Cells["id"].Value.ToString());
                    this.ItemGrid.Rows.Remove(row);
                    items.removeItemAt(rowToRemove);
                }
            ItemGrid.Refresh();
        }

        //remove a field from list(column)
        private void removeFieldBtn_Click(object sender, EventArgs e)
        {
            changesToFile = true;
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

        private void undoBtn_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
                string tempStr = undoStack.Last();
                undoStack.RemoveAt(undoStack.Count - 1);
                dt = new DataTable();
                items = new itemList();
                redoStack.Add(tempStr);
                if (redoStack.Count > 50)
                {
                    redoStack.RemoveAt(0);
                }
                items.loadFile(tempStr);
                loadFromItems();
            }
            
        }
        private void redoBtn_Click(object sender, EventArgs e)
        {
            
            if (redoStack.Count > 0)
            {
                string tempStr = redoStack.Last();
                redoStack.RemoveAt(redoStack.Count - 1);
                dt = new DataTable();
                items = new itemList();
                undoStack.Add(tempStr);
                if (undoStack.Count > 50)
                {
                    undoStack.RemoveAt(0);
                }
                items.loadFile(tempStr);
                loadFromItems();
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


        #endregion


        #region dataGrid interactions
        //go to next cell when enter is pressed
        private void ItemGrid_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                int col = ItemGrid.CurrentCell.ColumnIndex;
                int row = ItemGrid.CurrentCell.RowIndex;
                if (col < ItemGrid.Columns.Count - 1)
                {
                    ItemGrid.CurrentCell = ItemGrid.Rows[row].Cells[col + 1];
                    ItemGrid.Focus();
                }
            }

        }


        //simple method to keep track of value before a cell is edited
        private void ItemGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            ItemGrid.Columns[e.ColumnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
            beforeEdit = ItemGrid.CurrentCell.Value;
        }


        //simple function to update itemlist after cell is edited
        private void ItemGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            changesToFile = true;
            int col = ItemGrid.CurrentCell.ColumnIndex;
            int row = ItemGrid.CurrentCell.RowIndex;
            object cellValue = ItemGrid.CurrentCell.Value;
            try
            {
                int tempValue = Convert.ToInt32(ItemGrid.Rows[row].Cells[ItemGrid.Columns["id"].Index].Value.ToString());
                updateItem(col, row, tempValue, cellValue);
            }
            catch (FormatException)
            {
            }
            ItemGrid.Columns[col].SortMode = DataGridViewColumnSortMode.Automatic;
        }

        
        
        //make sure Items is in right order when column display index is changed
        //need ItemGrid.ColumnDisplayIndexChanged +=(-=) method before/after adding column to list
        private void ItemGrid_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            changesToFile = true;
            //get a list of current order of colmns for easier access next time
            List<string> movedNames = new List<string>();
            foreach (DataGridViewColumn column in ItemGrid.Columns.OfType<DataGridViewColumn>().OrderBy(x => x.DisplayIndex))
            {
                if (column.Name != "id")
                {
                    movedNames.Add(column.Name.ToString());
                }
                
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
            }else if(e.Button == MouseButtons.Right && ItemGrid.SelectedRows.Count >=1)
            {
                itemGridMenu.Items.Remove(deleteFieldMenu);
            }else if(e.Button == MouseButtons.Right && e.ColumnIndex < 0)
            {
                itemGridMenu.Items.Remove(deleteFieldMenu);
                itemGridMenu.Items.Remove(removeItemMenu);
            }else if (e.Button == MouseButtons.Right && e.RowIndex < 0)
            {
                itemGridMenu.Items.Remove(deleteFieldMenu);
                itemGridMenu.Items.Remove(removeItemMenu);
            }
        }


        //set cell color after reordering rows
        private void ItemGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            
        }

       
        // set column display index changes
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


        #endregion


        #region timer 
        //timer to call save every 1 minute
        private Timer timer1;
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 60000; // in miliseconds
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            saveBtn_Click(sender, e);
        }


        #endregion
    }
}
