
namespace StockManager
{
    partial class itemsForm
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
            this.components = new System.ComponentModel.Container();
            this.ItemGrid = new System.Windows.Forms.DataGridView();
            this.itemGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addFieldMemu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsTopPanel = new System.Windows.Forms.TableLayoutPanel();
            this.addFieldBtn = new FontAwesome.Sharp.IconButton();
            this.addItemBtn = new FontAwesome.Sharp.IconButton();
            this.saveBtn = new FontAwesome.Sharp.IconButton();
            this.openFileBtn = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.ItemGrid)).BeginInit();
            this.itemGridMenu.SuspendLayout();
            this.itemsTopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemGrid
            // 
            this.ItemGrid.AllowUserToAddRows = false;
            this.ItemGrid.AllowUserToOrderColumns = true;
            this.ItemGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ItemGrid.BackgroundColor = System.Drawing.Color.White;
            this.ItemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemGrid.ContextMenuStrip = this.itemGridMenu;
            this.ItemGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemGrid.Location = new System.Drawing.Point(0, 82);
            this.ItemGrid.Name = "ItemGrid";
            this.ItemGrid.RowTemplate.Height = 25;
            this.ItemGrid.Size = new System.Drawing.Size(725, 410);
            this.ItemGrid.TabIndex = 0;
            this.ItemGrid.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ItemGrid_CellBeginEdit);
            this.ItemGrid.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemGrid_CellEndEdit);
            this.ItemGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemGrid_KeyDown);
            // 
            // itemGridMenu
            // 
            this.itemGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemMenu,
            this.addFieldMemu,
            this.deleteItemMenu});
            this.itemGridMenu.Name = "contextMenuStrip1";
            this.itemGridMenu.Size = new System.Drawing.Size(135, 70);
            this.itemGridMenu.Opening += new System.ComponentModel.CancelEventHandler(this.itemGridMenu_Opening);
            // 
            // addItemMenu
            // 
            this.addItemMenu.Name = "addItemMenu";
            this.addItemMenu.Size = new System.Drawing.Size(134, 22);
            this.addItemMenu.Text = "Add Item";
            this.addItemMenu.Click += new System.EventHandler(this.addItemBtn_Click);
            // 
            // addFieldMemu
            // 
            this.addFieldMemu.Name = "addFieldMemu";
            this.addFieldMemu.Size = new System.Drawing.Size(134, 22);
            this.addFieldMemu.Text = "Add Field";
            this.addFieldMemu.Click += new System.EventHandler(this.addFieldBtn_Click);
            // 
            // deleteItemMenu
            // 
            this.deleteItemMenu.Name = "deleteItemMenu";
            this.deleteItemMenu.Size = new System.Drawing.Size(134, 22);
            this.deleteItemMenu.Text = "Delete Item";
            // 
            // itemsTopPanel
            // 
            this.itemsTopPanel.ColumnCount = 4;
            this.itemsTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.itemsTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.itemsTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.itemsTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.itemsTopPanel.Controls.Add(this.addFieldBtn, 1, 0);
            this.itemsTopPanel.Controls.Add(this.addItemBtn, 0, 0);
            this.itemsTopPanel.Controls.Add(this.saveBtn, 2, 0);
            this.itemsTopPanel.Controls.Add(this.openFileBtn, 3, 0);
            this.itemsTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemsTopPanel.Location = new System.Drawing.Point(0, 0);
            this.itemsTopPanel.Name = "itemsTopPanel";
            this.itemsTopPanel.RowCount = 1;
            this.itemsTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.itemsTopPanel.Size = new System.Drawing.Size(725, 82);
            this.itemsTopPanel.TabIndex = 1;
            // 
            // addFieldBtn
            // 
            this.addFieldBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.addFieldBtn.IconColor = System.Drawing.Color.Black;
            this.addFieldBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.addFieldBtn.Location = new System.Drawing.Point(184, 3);
            this.addFieldBtn.Name = "addFieldBtn";
            this.addFieldBtn.Size = new System.Drawing.Size(75, 23);
            this.addFieldBtn.TabIndex = 1;
            this.addFieldBtn.Text = "addField";
            this.addFieldBtn.UseVisualStyleBackColor = true;
            this.addFieldBtn.Click += new System.EventHandler(this.addFieldBtn_Click);
            // 
            // addItemBtn
            // 
            this.addItemBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.addItemBtn.IconColor = System.Drawing.Color.Black;
            this.addItemBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.addItemBtn.Location = new System.Drawing.Point(3, 3);
            this.addItemBtn.Name = "addItemBtn";
            this.addItemBtn.Size = new System.Drawing.Size(75, 23);
            this.addItemBtn.TabIndex = 0;
            this.addItemBtn.Text = "addItem";
            this.addItemBtn.UseVisualStyleBackColor = true;
            this.addItemBtn.Click += new System.EventHandler(this.addItemBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.saveBtn.IconColor = System.Drawing.Color.Black;
            this.saveBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.saveBtn.Location = new System.Drawing.Point(365, 3);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // openFileBtn
            // 
            this.openFileBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.openFileBtn.IconColor = System.Drawing.Color.Black;
            this.openFileBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.openFileBtn.Location = new System.Drawing.Point(546, 3);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(75, 23);
            this.openFileBtn.TabIndex = 3;
            this.openFileBtn.Text = "open";
            this.openFileBtn.UseVisualStyleBackColor = true;
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // itemsForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(725, 492);
            this.Controls.Add(this.ItemGrid);
            this.Controls.Add(this.itemsTopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "itemsForm";
            this.Text = "itemsForm";
            this.Load += new System.EventHandler(this.itemsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItemGrid)).EndInit();
            this.itemGridMenu.ResumeLayout(false);
            this.itemsTopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ItemGrid;
        private System.Windows.Forms.TableLayoutPanel itemsTopPanel;
        private FontAwesome.Sharp.IconButton addItemBtn;
        private FontAwesome.Sharp.IconButton addFieldBtn;
        private FontAwesome.Sharp.IconButton saveBtn;
        private FontAwesome.Sharp.IconButton openFileBtn;
        private System.Windows.Forms.ContextMenuStrip itemGridMenu;
        private System.Windows.Forms.ToolStripMenuItem addItemMenu;
        private System.Windows.Forms.ToolStripMenuItem addFieldMemu;
        private System.Windows.Forms.ToolStripMenuItem deleteItemMenu;
    }
}