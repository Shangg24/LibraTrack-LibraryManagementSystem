using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace LibraTrack
{
    public partial class AdminPanel : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=acer-extenza\SQLEXPRESS;Initial Catalog=LibraTrack;Integrated Security=True;TrustServerCertificate=True");


        public AdminPanel()
        {
            InitializeComponent();

            // Dock BOTH usercontrols
            adminPanelAccounts1.Dock = DockStyle.Fill;
            adminPanelGradeSection1.Dock = DockStyle.Fill;

            // Show Accounts by default
            adminPanelAccounts1.Visible = true;
            adminPanelGradeSection1.Visible = false;
           
            adminPanelAccounts1.BringToFront();
            this.Shown += AdminPanel_Shown;

            this.UseWaitCursor = false;
            Application.UseWaitCursor = false;
            Cursor.Current = Cursors.Default;

        }

        private void AdminPanel_Shown(object sender, EventArgs e)
        {
            adminPanelAccounts1.refreshData();
        }

        private void RegisteredAccounts_btn_Click(object sender, EventArgs e)
        {
            adminPanelGradeSection1.Visible = false;
            adminPanelAccounts1.Visible = true;

            adminPanelAccounts1.BringToFront();
            adminPanelAccounts1.refreshData();
        }

        private void GradeSection_btn_Click(object sender, EventArgs e)
        {
            adminPanelAccounts1.Visible = false;
            adminPanelGradeSection1.Visible = true;

            adminPanelGradeSection1.BringToFront();
            adminPanelGradeSection1.refreshData();
        }


        // ✅ Logout button
        private void logout_btn_Click(object sender, EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure you want to logout?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                LoginForm lForm = new LoginForm();
                lForm.Show();
                this.Hide();
            }
        }


        private void adminPanel_exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void adminPanel_maximizeBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void adminPanel_minimizeBtn_Click(object sender, EventArgs e)
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

    }
}
