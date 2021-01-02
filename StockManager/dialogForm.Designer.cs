
namespace StockManager
{
    partial class dialogForm
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
            this.dialogTextBox = new System.Windows.Forms.TextBox();
            this.dialogDescription = new System.Windows.Forms.Label();
            this.dialogCombo = new System.Windows.Forms.ComboBox();
            this.confirmBtn = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dialogTextBox
            // 
            this.dialogTextBox.Location = new System.Drawing.Point(133, 124);
            this.dialogTextBox.Name = "dialogTextBox";
            this.dialogTextBox.Size = new System.Drawing.Size(121, 23);
            this.dialogTextBox.TabIndex = 0;
            // 
            // dialogDescription
            // 
            this.dialogDescription.AutoSize = true;
            this.dialogDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.dialogDescription.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dialogDescription.ForeColor = System.Drawing.Color.White;
            this.dialogDescription.Location = new System.Drawing.Point(0, 0);
            this.dialogDescription.Name = "dialogDescription";
            this.dialogDescription.Size = new System.Drawing.Size(65, 28);
            this.dialogDescription.TabIndex = 4;
            this.dialogDescription.Text = "label1";
            // 
            // dialogCombo
            // 
            this.dialogCombo.FormattingEnabled = true;
            this.dialogCombo.Location = new System.Drawing.Point(133, 153);
            this.dialogCombo.Name = "dialogCombo";
            this.dialogCombo.Size = new System.Drawing.Size(121, 23);
            this.dialogCombo.TabIndex = 6;
            this.dialogCombo.Text = "Select data type";
            // 
            // confirmBtn
            // 
            this.confirmBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.confirmBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.confirmBtn.IconColor = System.Drawing.Color.Black;
            this.confirmBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.confirmBtn.Location = new System.Drawing.Point(179, 193);
            this.confirmBtn.Name = "confirmBtn";
            this.confirmBtn.Size = new System.Drawing.Size(75, 23);
            this.confirmBtn.TabIndex = 7;
            this.confirmBtn.Text = "iconButton1";
            this.confirmBtn.UseVisualStyleBackColor = true;
            this.confirmBtn.Click += new System.EventHandler(this.confirmBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dialogDescription);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 100);
            this.panel1.TabIndex = 8;
            // 
            // dialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(0)))), ((int)(((byte)(145)))));
            this.ClientSize = new System.Drawing.Size(270, 248);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.confirmBtn);
            this.Controls.Add(this.dialogCombo);
            this.Controls.Add(this.dialogTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "dialogForm";
            this.Text = "dialogForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dialogTextBox;
        private System.Windows.Forms.Label dialogDescription;
        private System.Windows.Forms.ComboBox dialogCombo;
        private FontAwesome.Sharp.IconButton confirmBtn;
        private System.Windows.Forms.Panel panel1;
    }
}