using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace StockManager
{
    public partial class Form1 : Form
    {

        private IconButton currentBtn;
        private Panel leftBorderBtn;
        public Form1()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 50);
            MainFormSidePanel.Controls.Add(leftBorderBtn);
            setTexts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        //manage language of software

        private void setTexts()
        {
            this.Controls.Find("ItemsBtn", true).FirstOrDefault().Text = defaultLanguage.ItemsBtn;
            this.Controls.Find("searchItemBtn", true).FirstOrDefault().Text = defaultLanguage.searchItemBtn;

            this.Controls.Find("settingsBtn", true).FirstOrDefault().Text = defaultLanguage.settingsBtn;

            this.Controls.Find("helpBtn", true).FirstOrDefault().Text = defaultLanguage.helpBtn;

        }

        #region button settings
        private void ItemsBtn_Click_1(object sender, EventArgs e)
        {
            activateButton(sender, Color.FromArgb(51, 255, 0));
            openChildForm(new itemsForm());
        }

        private void searchItemBtn_Click_1(object sender, EventArgs e)
        {
            activateButton(sender, Color.FromArgb(255, 0, 0));
        }


        private void settingsBtn_Click_1(object sender, EventArgs e)
        {
            activateButton(sender, Color.FromArgb(255, 242, 0));
        }

        private void helpBtn_Click_1(object sender, EventArgs e)
        {
            activateButton(sender, Color.FromArgb(255, 0, 255));
        }

        #endregion

        private Form activeForm = null;

        // open side panel 

        private void openChildForm(Form childform)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childform);
            panelChildForm.Tag = childform;
            childform.BringToFront();
            childform.Show();

        }


        // set button color


        private void activateButton(object sender, Color customcolor)
        {
            disableButton();
            if (sender != null)
            {
                currentBtn = (IconButton)sender;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = customcolor;
                currentBtn.IconColor = customcolor;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                leftBorderBtn.BackColor = customcolor;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

            }
        }

        // reset button color

        private void disableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.White;
                currentBtn.IconColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            }

        }

        #region window property settings


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);



        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maxmazeButton_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion
    }
}
