using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace L2Runner
{
    public partial class L2KeyBoardForm : Form
    {
        bool inTestMode = false;
        ushort WM_SYSKEYDOWN = 0x0104;
        ushort WM_SYSKEYUP = 0x0105;
        ushort WM_KEYDOWN = 0x0100;
        ushort WM_KEYUP = 0x0101;
        ushort WM_SETTEXT = 0x000C;
        ushort WM_CHAR = 0x0102;
        ushort WM_UNICHAR = 0x0109;

        public L2KeyBoardForm()
        {
            InitializeComponent();
        }

        private void L2KeyBoardForm_Load(object sender, EventArgs e)
        {
            FormMain mainform = this.Owner as FormMain;
            clients.DataSource = mainform.clients_dt;
            clients.DisplayMember = "winname_clients_dgv";
            clients.ValueMember = "winhdr_clients_dgv";
            clients.SelectedIndex = 0;
        }

        private void keybBttn_Click(object sender, EventArgs e)
        {
            Button bttn = sender as Button;
            if (inTestMode)
            {
                IntPtr l2ptr = new IntPtr(Convert.ToInt64(clients.SelectedValue.ToString()));
                uint downlparam = 0x00090001;
                uint uplparam = 0xC0090001;
                FormMain mainform = this.Owner as FormMain;
                mainform.getLparams(ref downlparam, ref uplparam, bttn.Tag.ToString());

                ushort key = (ushort)((Keys)Enum.Parse(typeof(Keys), bttn.Tag.ToString()));

                User32.PostMessage(l2ptr, WM_KEYDOWN, key, downlparam);
                Thread.Sleep(220);
                User32.PostMessage(l2ptr, WM_KEYUP, key, uplparam);
                /* User32.SendMessage(l2ptr, WM_KEYDOWN, key, startlparam);
                 Thread.Sleep(120);
                 User32.SendMessage(l2ptr, WM_KEYUP, key, endlparam);*/
                result_txtbx.Text = ((Keys)Enum.Parse(typeof(Keys), bttn.Tag.ToString())).ToString() + "---" + key;
            }
            else
            {
                string FullStringBttns = result_txtbx.Text;
                if (FullStringBttns.Contains("|")) FullStringBttns = FullStringBttns.Split('|')[1];
                if (bttn.ForeColor == Color.Black)
                {
                    bttn.ForeColor = Color.Red;
                    if (FullStringBttns == "")
                    {
                        result_txtbx.Text += bttn.Tag.ToString();
                    }
                    else
                    {
                        result_txtbx.Text +=(","+bttn.Tag.ToString());
                    }
                }
                else
                {
                    bttn.ForeColor = Color.Black;
                    result_txtbx.Text = result_txtbx.Text.Replace(bttn.Tag.ToString()+",", "");
                    result_txtbx.Text = result_txtbx.Text.Replace("," +bttn.Tag.ToString(), "");
                    if (!result_txtbx.Text.Contains(",")) result_txtbx.Text = result_txtbx.Text.Replace(bttn.Tag.ToString(), "");
                }
            }
        }

        private void testmode_bttn_Click(object sender, EventArgs e)
        {
            inTestMode = !inTestMode;
            if (inTestMode)
            {
                if (autotest_chkbx.CheckState == CheckState.Checked)
                {
                    AutoTest();
                }
                else testmode_bttn.ForeColor = Color.Red;
                
            }
            else
            {
                testmode_bttn.ForeColor = Color.Black;
            }
        }

        private void AutoTest()
        {
            IntPtr l2ptr = new IntPtr(Convert.ToInt64(clients.SelectedValue.ToString()));
            uint lparam = (0x01 << 28);
            User32.SetForegroundWindow(l2ptr);
            User32.BringWindowToTop(l2ptr);
            Thread.Sleep(1000);
            User32.SendMessage(l2ptr, WM_SYSKEYDOWN, (ushort)Keys.D1, lparam);
            Thread.Sleep(210);
            User32.SendMessage(l2ptr, WM_SYSKEYUP, (ushort)Keys.D1, lparam);
            Thread.Sleep(1000);
            User32.SendMessage(l2ptr, WM_KEYDOWN, 0x32, lparam);
            Thread.Sleep(210);
            User32.SendMessage(l2ptr, WM_KEYUP, 0x32, lparam);
            Thread.Sleep(1000);
            User32.PostMessage(l2ptr, WM_SYSKEYDOWN, (ushort)Keys.D3, lparam);
            Thread.Sleep(220);
            User32.PostMessage(l2ptr, WM_SYSKEYUP, (ushort)Keys.D3, lparam);
            Thread.Sleep(1000);
            User32.PostMessage(l2ptr, WM_KEYDOWN, 0x34, lparam);
            Thread.Sleep(220);
            User32.PostMessage(l2ptr, WM_KEYUP, 0x34, lparam);
            Thread.Sleep(1000);
            User32.SendMessage(l2ptr, WM_SYSKEYDOWN, 0x35, lparam);
            Thread.Sleep(210);
            User32.SendMessage(l2ptr, WM_SYSKEYUP, 0x35, lparam);
            Thread.Sleep(1000);
            User32.SendMessage(l2ptr, WM_KEYDOWN, (ushort)Keys.D6, lparam);
            Thread.Sleep(210);
            User32.SendMessage(l2ptr, WM_KEYUP, (ushort)Keys.D6, lparam);
            Thread.Sleep(1000);
            User32.PostMessage(l2ptr, WM_SYSKEYDOWN, 0x37, lparam);
            Thread.Sleep(220);
            User32.PostMessage(l2ptr, WM_SYSKEYDOWN, 0x37, lparam);
            Thread.Sleep(1000);
            User32.PostMessage(l2ptr, WM_KEYDOWN, (ushort)Keys.D8, lparam);
            Thread.Sleep(220);
            User32.PostMessage(l2ptr, WM_KEYUP, (ushort)Keys.D8, lparam);
        }

        private void bttn_ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
