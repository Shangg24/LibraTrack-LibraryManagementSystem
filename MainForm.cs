using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace LibraTrack
{
    public partial class MainForm : Form
    {
        private Dashboard dashboard;
        private AddBooks addBooks;
        private IssueBooks issueBooks;
        private ReturnBooks returnBooks;
        private AnalyticsUserControl analyticsUserControl;
        private BookRequests bookRequests;

        public Dashboard DashboardInstance => dashboard;
        public MainForm()
        {
            InitializeComponent();


        }


        public void AddDashboardActivity(string message)
        {
            if (dashboard == null) return;

            dashboard.AddActivity(message);
        }


        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(check == DialogResult.Yes)
            {
                LoginForm lForm = new LoginForm();
                lForm.Show();
                this.Hide();
            }
        }

        private void dashboard_btn_Click(object sender, EventArgs e)
        {

            dashboard.Visible = true;
            addBooks.Visible = false;
            issueBooks.Visible = false;
            returnBooks.Visible = false;

            dashboard.refreshData();
        }

        private void addBooks_btn_Click(object sender, EventArgs e)
        {

            dashboard.Visible = false;
            addBooks.Visible = true;
            issueBooks.Visible = false;
            returnBooks.Visible = false;

            addBooks.refreshData();
        }

        private void issueBooks_btn_Click(object sender, EventArgs e)
        {

            dashboard.Visible = false;
            addBooks.Visible = false;
            issueBooks.Visible = true;
            returnBooks.Visible = false;

            issueBooks.refreshData();
        }

        private void returnBooks_btn_Click(object sender, EventArgs e)
        {

            dashboard.Visible = false;
            addBooks.Visible = false;
            issueBooks.Visible = false;
            returnBooks.Visible = true;

            returnBooks.refreshData();
        }


        private void analytics_btn_Click(object sender, EventArgs e)
        {
            dashboard.Visible = false;
            addBooks.Visible = false;
            issueBooks.Visible = false;
            returnBooks.Visible = false;
            analyticsUserControl.Visible = true;

            analyticsUserControl.refreshData();
        }


        private void mainForm_exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mainForm_maximizeBtn_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                // Maximize but respect taskbar
                this.MaximumSize = Screen.FromHandle(this.Handle).WorkingArea.Size;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void mainForm_minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }


        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x84;
            const int HTLEFT = 10, HTRIGHT = 11, HTTOP = 12, HTTOPLEFT = 13,
                      HTTOPRIGHT = 14, HTBOTTOM = 15, HTBOTTOMLEFT = 16, HTBOTTOMRIGHT = 17;

            if (m.Msg == WM_NCHITTEST && WindowState == FormWindowState.Normal)
            {
                int border = 6;
                Point p = PointToClient(Cursor.Position);

                if (p.X <= border && p.Y <= border) m.Result = (IntPtr)HTTOPLEFT;
                else if (p.X >= Width - border && p.Y <= border) m.Result = (IntPtr)HTTOPRIGHT;
                else if (p.X <= border && p.Y >= Height - border) m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (p.X >= Width - border && p.Y >= Height - border) m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (p.X <= border) m.Result = (IntPtr)HTLEFT;
                else if (p.X >= Width - border) m.Result = (IntPtr)HTRIGHT;
                else if (p.Y <= border) m.Result = (IntPtr)HTTOP;
                else if (p.Y >= Height - border) m.Result = (IntPtr)HTBOTTOM;
                else base.WndProc(ref m);

                return;
            }

            base.WndProc(ref m);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dashboard = new Dashboard();
            addBooks = new AddBooks();
            issueBooks = new IssueBooks();
            returnBooks = new ReturnBooks();
            analyticsUserControl = new AnalyticsUserControl();
            bookRequests = new BookRequests();

            panelMain.Controls.Add(dashboard);
            panelMain.Controls.Add(addBooks);
            panelMain.Controls.Add(issueBooks);
            panelMain.Controls.Add(returnBooks);
            panelMain.Controls.Add(analyticsUserControl);
            panelMain.Controls.Add(bookRequests);

            dashboard.Dock = DockStyle.Fill;
            addBooks.Dock = DockStyle.Fill;
            issueBooks.Dock = DockStyle.Fill;
            returnBooks.Dock = DockStyle.Fill;
            analyticsUserControl.Dock = DockStyle.Fill;
            bookRequests.Dock = DockStyle.Fill;

            addBooks.Visible = false;
            issueBooks.Visible = false;
            returnBooks.Visible = false;
            dashboard.Visible = true;
            analyticsUserControl.Visible = false;
            bookRequests.Visible = false;
            //LoadUserControl(dashboard);

            dashboard.refreshData();
            dashboard.LoadActivityFromDatabase();
        }

        private void LoadUserControl(UserControl uc)
        {
            panelMain.SuspendLayout();
            panelMain.Controls.Clear();

            uc.Dock = DockStyle.Fill;

            panelMain.Controls.Add(uc);
            panelMain.ResumeLayout();
        }

        

        public void RefreshAllData()
        {
            dashboard?.refreshData();
            addBooks?.refreshData();
            issueBooks?.refreshData();
            returnBooks?.refreshData();
        }


        public void RefreshAfterReturn()
        {
            issueBooks?.refreshData();
            dashboard?.refreshData();
            addBooks?.refreshData();
        }

        public void RefreshIssueBooks()
        {
            if (issueBooks != null)
            {
                issueBooks.refreshData();
            }
        }

        private void request_btn_Click(object sender, EventArgs e)
        {
            dashboard.Visible = false;
            addBooks.Visible = false;
            issueBooks.Visible = false;
            returnBooks.Visible = false;
            analyticsUserControl.Visible = false;

            bookRequests.Visible = true;

            bookRequests.refreshData();
        }
    }
}
