
namespace StockManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MainFormSidePanel = new System.Windows.Forms.Panel();
            this.helpBtn = new FontAwesome.Sharp.IconButton();
            this.settingsBtn = new FontAwesome.Sharp.IconButton();
            this.searchItemBtn = new FontAwesome.Sharp.IconButton();
            this.ItemsBtn = new FontAwesome.Sharp.IconButton();
            this.LogoPanel = new System.Windows.Forms.Panel();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.minimize = new FontAwesome.Sharp.IconButton();
            this.maximizeButton = new FontAwesome.Sharp.IconButton();
            this.exitButton = new FontAwesome.Sharp.IconButton();
            this.MainFormSidePanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainFormSidePanel
            // 
            this.MainFormSidePanel.AutoScroll = true;
            this.MainFormSidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(0)))), ((int)(((byte)(107)))));
            this.MainFormSidePanel.Controls.Add(this.helpBtn);
            this.MainFormSidePanel.Controls.Add(this.settingsBtn);
            this.MainFormSidePanel.Controls.Add(this.searchItemBtn);
            this.MainFormSidePanel.Controls.Add(this.ItemsBtn);
            this.MainFormSidePanel.Controls.Add(this.LogoPanel);
            this.MainFormSidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainFormSidePanel.ForeColor = System.Drawing.Color.Black;
            this.MainFormSidePanel.Location = new System.Drawing.Point(0, 34);
            this.MainFormSidePanel.Name = "MainFormSidePanel";
            this.MainFormSidePanel.Size = new System.Drawing.Size(250, 484);
            this.MainFormSidePanel.TabIndex = 0;
            // 
            // helpBtn
            // 
            this.helpBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.helpBtn.FlatAppearance.BorderSize = 0;
            this.helpBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.helpBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(0)))), ((int)(((byte)(105)))));
            this.helpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpBtn.ForeColor = System.Drawing.Color.White;
            this.helpBtn.IconChar = FontAwesome.Sharp.IconChar.Question;
            this.helpBtn.IconColor = System.Drawing.Color.White;
            this.helpBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.helpBtn.IconSize = 32;
            this.helpBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpBtn.Location = new System.Drawing.Point(0, 220);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.helpBtn.Size = new System.Drawing.Size(250, 50);
            this.helpBtn.TabIndex = 11;
            this.helpBtn.Text = "Help";
            this.helpBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.helpBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.helpBtn.UseVisualStyleBackColor = true;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click_1);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsBtn.FlatAppearance.BorderSize = 0;
            this.settingsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.settingsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(0)))), ((int)(((byte)(105)))));
            this.settingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsBtn.ForeColor = System.Drawing.Color.White;
            this.settingsBtn.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.settingsBtn.IconColor = System.Drawing.Color.White;
            this.settingsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.settingsBtn.IconSize = 32;
            this.settingsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsBtn.Location = new System.Drawing.Point(0, 170);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.settingsBtn.Size = new System.Drawing.Size(250, 50);
            this.settingsBtn.TabIndex = 10;
            this.settingsBtn.Text = "Settings";
            this.settingsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click_1);
            // 
            // searchItemBtn
            // 
            this.searchItemBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(0)))), ((int)(((byte)(107)))));
            this.searchItemBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchItemBtn.FlatAppearance.BorderSize = 0;
            this.searchItemBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.searchItemBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(0)))), ((int)(((byte)(105)))));
            this.searchItemBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchItemBtn.ForeColor = System.Drawing.Color.White;
            this.searchItemBtn.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.searchItemBtn.IconColor = System.Drawing.Color.White;
            this.searchItemBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.searchItemBtn.IconSize = 32;
            this.searchItemBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchItemBtn.Location = new System.Drawing.Point(0, 120);
            this.searchItemBtn.Name = "searchItemBtn";
            this.searchItemBtn.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.searchItemBtn.Size = new System.Drawing.Size(250, 50);
            this.searchItemBtn.TabIndex = 8;
            this.searchItemBtn.Text = "Search";
            this.searchItemBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.searchItemBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.searchItemBtn.UseVisualStyleBackColor = false;
            this.searchItemBtn.Click += new System.EventHandler(this.searchItemBtn_Click_1);
            // 
            // ItemsBtn
            // 
            this.ItemsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ItemsBtn.FlatAppearance.BorderSize = 0;
            this.ItemsBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.ItemsBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(0)))), ((int)(((byte)(105)))));
            this.ItemsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ItemsBtn.ForeColor = System.Drawing.Color.White;
            this.ItemsBtn.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.ItemsBtn.IconColor = System.Drawing.Color.White;
            this.ItemsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ItemsBtn.IconSize = 32;
            this.ItemsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ItemsBtn.Location = new System.Drawing.Point(0, 70);
            this.ItemsBtn.Name = "ItemsBtn";
            this.ItemsBtn.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.ItemsBtn.Size = new System.Drawing.Size(250, 50);
            this.ItemsBtn.TabIndex = 7;
            this.ItemsBtn.Text = "Items";
            this.ItemsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ItemsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ItemsBtn.UseVisualStyleBackColor = true;
            this.ItemsBtn.Click += new System.EventHandler(this.ItemsBtn_Click_1);
            // 
            // LogoPanel
            // 
            this.LogoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(1)))), ((int)(((byte)(64)))));
            this.LogoPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LogoPanel.BackgroundImage")));
            this.LogoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LogoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LogoPanel.Location = new System.Drawing.Point(0, 0);
            this.LogoPanel.Name = "LogoPanel";
            this.LogoPanel.Size = new System.Drawing.Size(250, 70);
            this.LogoPanel.TabIndex = 0;
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(2)))), ((int)(((byte)(110)))));
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(250, 34);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(741, 484);
            this.panelChildForm.TabIndex = 1;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(1)))), ((int)(((byte)(64)))));
            this.topPanel.Controls.Add(this.minimize);
            this.topPanel.Controls.Add(this.maximizeButton);
            this.topPanel.Controls.Add(this.exitButton);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(991, 34);
            this.topPanel.TabIndex = 2;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // minimize
            // 
            this.minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.minimize.FlatAppearance.BorderSize = 0;
            this.minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.minimize.IconColor = System.Drawing.Color.Gray;
            this.minimize.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.minimize.IconSize = 20;
            this.minimize.Location = new System.Drawing.Point(923, 0);
            this.minimize.Name = "minimize";
            this.minimize.Size = new System.Drawing.Size(25, 25);
            this.minimize.TabIndex = 2;
            this.minimize.Text = "iconButton3";
            this.minimize.UseVisualStyleBackColor = true;
            this.minimize.Click += new System.EventHandler(this.minimize_Click);
            // 
            // maximizeButton
            // 
            this.maximizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maximizeButton.FlatAppearance.BorderSize = 0;
            this.maximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeButton.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.maximizeButton.IconColor = System.Drawing.Color.Gray;
            this.maximizeButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.maximizeButton.IconSize = 20;
            this.maximizeButton.Location = new System.Drawing.Point(945, 0);
            this.maximizeButton.Name = "maximizeButton";
            this.maximizeButton.Size = new System.Drawing.Size(25, 25);
            this.maximizeButton.TabIndex = 1;
            this.maximizeButton.UseVisualStyleBackColor = true;
            this.maximizeButton.Click += new System.EventHandler(this.maxmazeButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.exitButton.IconColor = System.Drawing.Color.Gray;
            this.exitButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.exitButton.IconSize = 25;
            this.exitButton.Location = new System.Drawing.Point(966, 0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(25, 25);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "iconButton1";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(1)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(991, 518);
            this.ControlBox = false;
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.MainFormSidePanel);
            this.Controls.Add(this.topPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.MainFormSidePanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainFormSidePanel;
        private System.Windows.Forms.Panel LogoPanel;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Panel topPanel;
        private FontAwesome.Sharp.IconButton helpBtn;
        private FontAwesome.Sharp.IconButton settingsBtn;
        private FontAwesome.Sharp.IconButton searchItemBtn;
        private FontAwesome.Sharp.IconButton ItemsBtn;
        private FontAwesome.Sharp.IconButton minimize;
        private FontAwesome.Sharp.IconButton maximizeButton;
        private FontAwesome.Sharp.IconButton exitButton;
    }
}

