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
                ushort WM_SYSKEYDOWN = 0x0104;
                ushort WM_SYSKEYUP = 0x0105;
                ushort WM_KEYDOWN = 0x0100;
                ushort WM_KEYUP = 0x0101;
                ushort WM_SETTEXT = 0x000C;
                ushort WM_CHAR = 0x0102;
                ushort WM_UNICHAR = 0x0109;
                IntPtr l2ptr = new IntPtr(Convert.ToInt64(clients.SelectedValue.ToString()));
                uint lparam = (0x01 << 28);
                ushort key = (ushort)((Keys)Enum.Parse(typeof(Keys), bttn.Tag.ToString()));


                //User32.SendMessage(l2ptr, WM_SYSKEYDOWN, key, lparam);
                //User32.SendMessage(l2ptr, WM_KEYDOWN, 0x38, 0);
                //User32.SendMessage(l2ptr, WM_SYSKEYUP, key, lparam);
                //User32.SendMessage(l2ptr, WM_KEYUP, 0x38, 0);
                User32.PostMessage(l2ptr, WM_UNICHAR, '8', 2);
                Thread.Sleep(220);
                User32.PostMessage(l2ptr, WM_UNICHAR, '8', 2);
                //User32.SendMessage(l2ptr, WM_SETTEXT, 0, "8");
                result_txtbx.Text = key.ToString();
            }
        }

        private void testmode_bttn_Click(object sender, EventArgs e)
        {
            inTestMode = !inTestMode;
            if (inTestMode)
            {
                testmode_bttn.ForeColor = Color.Red;
            }
            else
            {
                testmode_bttn.ForeColor = Color.Black;
            }
        }


    }
}
