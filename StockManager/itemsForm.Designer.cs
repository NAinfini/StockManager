﻿
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
            this.removeItemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFieldMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.undoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.redoMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGridSaveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsTopPanel = new System.Windows.Forms.TableLayoutPanel();
            this.addFieldBtn = new FontAwesome.Sharp.IconButton();
            this.addItemBtn = new FontAwesome.Sharp.IconButton();
            this.openFileBtn = new FontAwesome.Sharp.IconButton();
            this.saveAsBtn = new FontAwesome.Sharp.IconButton();
            this.saveBtn = new FontAwesome.Sharp.IconButton();
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
            this.ItemGrid.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ItemGrid_CellMouseUp);
            this.ItemGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ItemGrid_ColumnHeaderMouseClick);
            this.ItemGrid.Sorted += new System.EventHandler(this.ItemGrid_Sorted);
            this.ItemGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemGrid_KeyDown);
            this.ItemGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ItemGrid_MouseDown);
            this.ItemGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ItemGrid_MouseUp);
            // 
            // itemGridMenu
            // 
            this.itemGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemMenu,
            this.addFieldMemu,
            this.removeItemMenu,
            this.deleteFieldMenu,
            this.undoMenu,
            this.redoMenu,
            this.itemGridSaveMenu});
            this.itemGridMenu.Name = "contextMenuStrip1";
            this.itemGridMenu.Size = new System.Drawing.Size(144, 158);
            // 
            // addItemMenu
            // 
            this.addItemMenu.Name = "addItemMenu";
            this.addItemMenu.Size = new System.Drawing.Size(143, 22);
            this.addItemMenu.Text = "Add Item";
            this.addItemMenu.Click += new System.EventHandler(this.addItemBtn_Click);
            // 
            // addFieldMemu
            // 
            this.addFieldMemu.Name = "addFieldMemu";
            this.addFieldMemu.Size = new System.Drawing.Size(143, 22);
            this.addFieldMemu.Text = "Add field";
            this.addFieldMemu.Click += new System.EventHandler(this.addFieldBtn_Click);
            // 
            // removeItemMenu
            // 
            this.removeItemMenu.Name = "removeItemMenu";
            this.removeItemMenu.Size = new System.Drawing.Size(143, 22);
            this.removeItemMenu.Text = "Delete item";
            this.removeItemMenu.Click += new System.EventHandler(this.removeItemBtn_Click);
            // 
            // deleteFieldMenu
            // 
            this.deleteFieldMenu.Name = "deleteFieldMenu";
            this.deleteFieldMenu.Size = new System.Drawing.Size(143, 22);
            this.deleteFieldMenu.Text = "Delete field";
            this.deleteFieldMenu.Click += new System.EventHandler(this.removeFieldBtn_Click);
            // 
            // undoMenu
            // 
            this.undoMenu.Name = "undoMenu";
            this.undoMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoMenu.Size = new System.Drawing.Size(143, 22);
            this.undoMenu.Text = "undo";
            this.undoMenu.Click += new System.EventHandler(this.undoBtn_Click);
            // 
            // redoMenu
            // 
            this.redoMenu.Name = "redoMenu";
            this.redoMenu.Size = new System.Drawing.Size(143, 22);
            this.redoMenu.Text = "redo";
            this.redoMenu.Click += new System.EventHandler(this.redoBtn_Click);
            // 
            // itemGridSaveMenu
            // 
            this.itemGridSaveMenu.Name = "itemGridSaveMenu";
            this.itemGridSaveMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.itemGridSaveMenu.Size = new System.Drawing.Size(143, 22);
            this.itemGridSaveMenu.Text = "save";
            this.itemGridSaveMenu.Click += new System.EventHandler(this.saveBtn_Click);
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
            this.itemsTopPanel.Controls.Add(this.openFileBtn, 3, 0);
            this.itemsTopPanel.Controls.Add(this.saveAsBtn, 0, 1);
            this.itemsTopPanel.Controls.Add(this.saveBtn, 2, 0);
            this.itemsTopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemsTopPanel.Location = new System.Drawing.Point(0, 0);
            this.itemsTopPanel.Name = "itemsTopPanel";
            this.itemsTopPanel.RowCount = 2;
            this.itemsTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.itemsTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
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
            // saveAsBtn
            // 
            this.saveAsBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.saveAsBtn.IconColor = System.Drawing.Color.Black;
            this.saveAsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.saveAsBtn.Location = new System.Drawing.Point(3, 42);
            this.saveAsBtn.Name = "saveAsBtn";
            this.saveAsBtn.Size = new System.Drawing.Size(75, 23);
            this.saveAsBtn.TabIndex = 4;
            this.saveAsBtn.Text = "save as";
            this.saveAsBtn.UseVisualStyleBackColor = true;
            this.saveAsBtn.Click += new System.EventHandler(this.saveAsBtn_Click);
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
            this.saveBtn.Text = "save ";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
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
        private System.Windows.Forms.ToolStripMenuItem deleteFieldMenu;
        private System.Windows.Forms.ToolStripMenuItem removeItemMenu;
        private System.Windows.Forms.ToolStripMenuItem undoMenu;
        private System.Windows.Forms.ToolStripMenuItem redoMenu;
        private FontAwesome.Sharp.IconButton saveAsBtn;
        private System.Windows.Forms.ToolStripMenuItem itemGridSaveMenu;
    }
}