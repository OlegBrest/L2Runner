using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace L2Runner
{
    public partial class FormMain : Form
    {
        ushort WM_SYSKEYDOWN = 0x0104;
        ushort WM_KEYDOWN = 0x0100;

        String ProcessName = "l2";

        bool GettingOtherTarget = false;
        string other_text = "";

        Rectangle theRectangle = new Rectangle(new Point(0, 0), new Size(0, 0));
        Point startPoint;


        Rectangle other_rect = new Rectangle(0, 0, 0, 0);
        DataSet targets_ds = new DataSet("other");
        DataTable targets_dt = new DataTable("other_targets");
        DataSet scripts_ds = new DataSet("scripts");
        DataTable scripts_dt = new DataTable("main_script");
        bool StartDrawRect = false;
        public DataSet clients_ds = new DataSet("Clients");
        public DataTable clients_dt = new DataTable("clients");
        IntPtr mainwinptr = IntPtr.Zero;
        Random random = new Random(DateTime.Now.Millisecond);
        DataTable ImageTypes = new DataTable();
        Bitmap pic1;

        double timeRefresh = 0.1;

        bool TrackingIsActive = false;
        bool CheckingConditions = false;

        int selectedWindow = 1;
        System.Timers.Timer savetimer = new System.Timers.Timer();
        bool timerDisposed = false;

        public FormMain()
        {
            InitializeComponent();
            targets_ds.Tables.Add(targets_dt);
            scripts_ds.Tables.Add(scripts_dt);
            clients_ds.Tables.Add(clients_dt);
            DataColumn dc = new DataColumn("Name");
            ImageTypes.Columns.Add(dc);
            ImageTypes.Rows.Add("Bar");
            ImageTypes.Rows.Add("Button");
            ImageTypes.Rows.Add("Image");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.RefreshTime > 0)
            {
                timeRefresh = Properties.Settings.Default.RefreshTime;
            }
            if (Properties.Settings.Default.LastWindow > 0)
            {
                selectedWindow = Properties.Settings.Default.LastWindow;
            }

            #region clients load
            if (File.Exists("clients.xml"))
            {
                try
                {
                    clients_dt.ReadXml("clients.xml");
                    foreach (DataGridViewColumn dgvc in clients_dgv.Columns)
                    {
                        if (!clients_dt.Columns.Contains(dgvc.Name))
                        {
                            DataColumn dc = new DataColumn(dgvc.Name);
                            dc.Caption = dgvc.HeaderText;
                            if (dgvc.Name == "winhdr_clients_dgv") dc.DataType = typeof(Int64);
                            clients_dt.Columns.Add(dc);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "198");
                }
            }
            else
            {
                foreach (DataGridViewColumn dgvc in clients_dgv.Columns)
                {
                    DataColumn dc = new DataColumn(dgvc.Name);
                    dc.Caption = dgvc.HeaderText;
                    if (dgvc.Name == "winhdr_clients_dgv") dc.DataType = typeof(Int64);
                    clients_dt.Columns.Add(dc);
                }
            }
            clients_dgv.DataSource = clients_dt;
            #endregion

            #region targets load
            if (File.Exists("l2runner.xml"))
            {
                try
                {
                    targets_dt.ReadXml("l2runner.xml");
                    foreach (DataGridViewColumn dgvc in targets_dgv.Columns)
                    {
                        if (!targets_dt.Columns.Contains(dgvc.Name))
                        {
                            DataColumn dc = new DataColumn(dgvc.Name);
                            dc.Caption = dgvc.HeaderText;
                            if (dgvc.GetType() == typeof(DataGridViewImageColumn)) dc.DataType = System.Type.GetType("System.Byte[]");
                            if (dgvc.Name == "correction_clmn") dc.DefaultValue = 10.0;
                            if (dgvc.Name == "last_change")
                            {
                                dc.DataType = typeof(DateTime);
                                dc.DefaultValue = DateTime.Now;
                            }
                            if (dgvc.Name == "idle")
                            {
                                dc.DataType = typeof(int);
                                dc.DefaultValue = 0;
                            }
                            targets_dt.Columns.Add(dc);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "125");
                }
            }
            else
            {
                foreach (DataGridViewColumn dgvc in targets_dgv.Columns)
                {
                    DataColumn dc = new DataColumn(dgvc.Name);
                    dc.Caption = dgvc.HeaderText;
                    if (dgvc.GetType() == typeof(DataGridViewImageColumn)) dc.DataType = System.Type.GetType("System.Byte[]");
                    if (dgvc.Name == "correction_clmn") dc.DefaultValue = 10.0;
                    if (dgvc.Name == "last_change")
                    {
                        dc.DataType = typeof(DateTime);
                        dc.DefaultValue = DateTime.Now;
                    }
                    targets_dt.Columns.Add(dc);
                }
                DataRow dr = targets_dt.NewRow();
                dr["name_clmn"] = "Self CP";
                targets_dt.Rows.Add(dr);
                dr = targets_dt.NewRow();
                dr["name_clmn"] = "Self HP";
                targets_dt.Rows.Add(dr);
                dr = targets_dt.NewRow();
                dr["name_clmn"] = "Self MP";
                targets_dt.Rows.Add(dr);
                dr = targets_dt.NewRow();
                dr["name_clmn"] = "Target HP";
                targets_dt.Rows.Add(dr);
            }
            DataGridViewComboBoxColumn type_cmbbx = (targets_dgv.Columns["type_clmn"] as DataGridViewComboBoxColumn);
            type_cmbbx.DataSource = ImageTypes;
            type_cmbbx.ValueMember = "Name";
            type_cmbbx.DisplayMember = "Name";
            targets_dgv.DataSource = targets_dt;
            
            //type_cmbbx.Items.AddRange( "Bar", "Button", "Image");
            #endregion

            #region script load
            if (File.Exists("l2runnerScript.xml"))
            {
                try
                {
                    scripts_dt.ReadXml("l2runnerScript.xml");
                    foreach (DataGridViewColumn dgvc in dgv_script.Columns)
                    {
                        if (dgvc.Name == "target_script_clmn")
                        {
                            DataGridViewComboBoxColumn dgvcbx = (DataGridViewComboBoxColumn)dgvc;
                            dgvcbx.DataSource = targets_dt;
                            dgvcbx.DisplayMember = "name_clmn";
                            dgvcbx.ValueMember = "name_clmn";
                        }
                        if (dgvc.Name == "window_script_clmn")
                        {
                            DataGridViewComboBoxColumn dgvcbx = (DataGridViewComboBoxColumn)dgvc;
                            dgvcbx.DataSource = clients_dt;
                            dgvcbx.DisplayMember = "winname_clients_dgv";
                            dgvcbx.ValueMember = "winname_clients_dgv";
                        }
                        if (dgvc.Name == "nextuse_script_clmn")
                        {
                            dgvc.ValueType = typeof(DateTime);
                        }
                        if (!scripts_dt.Columns.Contains(dgvc.Name))
                        {
                            DataColumn dc = new DataColumn(dgvc.Name);
                            dc.Caption = dgvc.HeaderText;
                            if (dgvc.Name == "id_script_clmn")
                            {
                                dc.AutoIncrement = true;
                                dc.AutoIncrementSeed = dgv_script.Rows.Count;
                                dc.AutoIncrementStep = 1;
                            }
                            if (dgvc.Name == "nextuse_script_clmn")
                            {
                                dc.DataType = typeof(DateTime);
                                dc.DefaultValue = DateTime.Now;
                            }
                            if (dgvc.Name == "delay_script_clmn") dc.DefaultValue = 100;
                            scripts_dt.Columns.Add(dc);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "145");
                }
            }
            else
            {
                foreach (DataGridViewColumn dgvc in dgv_script.Columns)
                {
                    if (dgvc.Name == "nextuse_script_clmn")
                    {
                        dgvc.ValueType = typeof(DateTime);
                    }
                    if (dgvc.Name == "target_script_clmn")
                    {
                        DataGridViewComboBoxColumn dgvcbx = (DataGridViewComboBoxColumn)dgvc;
                        dgvcbx.DataSource = targets_dt;
                        dgvcbx.DisplayMember = "name_clmn";
                        dgvcbx.ValueMember = "name_clmn";
                    }
                    if (dgvc.Name == "window_script_clmn")
                    {
                        DataGridViewComboBoxColumn dgvcbx = (DataGridViewComboBoxColumn)dgvc;
                        dgvcbx.DataSource = clients_dt;
                        dgvcbx.DisplayMember = "winname_clients_dgv";
                        dgvcbx.ValueMember = "winname_clients_dgv";
                    }
                    DataColumn dc = new DataColumn(dgvc.Name);
                    dc.Caption = dgvc.HeaderText;
                    if (dgvc.Name == "id_script_clmn")
                    {
                        dc.AutoIncrement = true;
                        dc.AutoIncrementSeed = dgv_script.Rows.Count;
                        dc.AutoIncrementStep = 1;
                    }
                    if (dgvc.Name == "delay_script_clmn") dc.DefaultValue = 100;
                    scripts_dt.Columns.Add(dc);
                }
            }
            dgv_script.DataSource = scripts_dt;
            #endregion

            CaptureWindows(mainwinptr);
            savetimer.AutoReset = true;
            savetimer.Interval = 10000;
            savetimer.Elapsed += Savetimer_Elapsed;
            savetimer.Disposed += Savetimer_Disposed;
            savetimer.Start();
        }

        private void Savetimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (targets_ds.GetXmlSchema() != "") targets_ds.WriteXml("l2runner.xml", XmlWriteMode.WriteSchema);
            if (scripts_ds.GetXmlSchema() != "") scripts_ds.WriteXml("l2runnerScript.xml", XmlWriteMode.WriteSchema);
            if (clients_ds.GetXmlSchema() != "") clients_ds.WriteXml("clients.xml", XmlWriteMode.WriteSchema);
        }

        public void CaptureWindows(IntPtr intPtr)
        {
            if (intPtr != IntPtr.Zero)
            {
                int i = 0;
                this.Hide();
                User32.SetForegroundWindow(intPtr);
                Thread.Sleep(500);
                i++;
                var rect = new User32.Rect();
                User32.GetWindowRect(intPtr, ref rect);
                int width = rect.right - rect.left;
                int height = rect.bottom - rect.top;
                if ((width > 0) && (height > 0))
                {
                    var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                    Graphics graphics = Graphics.FromImage(bmp);
                    graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
                    // bmp.Save("test_" + i.ToString() + ".png", ImageFormat.Png);
                    pictureBoxMain.Image = bmp;
                    switch (i)
                    {
                        case 1:
                            pic1 = bmp;
                            pictureBox1.Image = pic1;
                            break;
                    }
                    this.Show();
                    this.Activate();
                    showActiveWindow();
                }
            }
        }

        private void pictureBoxMain_Click(object sender, EventArgs e)
        {

        }

        private async void buttonTracking_Click(object sender, EventArgs e)
        {
            TrackingIsActive = !TrackingIsActive;
            if (TrackingIsActive)
            {
                toolStripStatusLabel.Text = "";
                buttonTracking.ForeColor = Color.Red;
                buttonTracking.Text = "Stop Boting";
                try
                {
                    await Tracking();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "310");
                }
            }
            else
            {
                buttonTracking.ForeColor = Color.Black;
                buttonTracking.Text = "Start Boting";
            }
        }

        private void showActiveWindow()
        {
            panel1.BackColor = Color.Gray;
            if (selectedWindow == 1)
            {
                panel1.BackColor = Color.Red;
                pictureBoxMain.Image = pic1;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            selectedWindow = 1;
            showActiveWindow();
            Properties.Settings.Default.LastWindow = 1;
            Properties.Settings.Default.Save();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            selectedWindow = 2;
            showActiveWindow();
            Properties.Settings.Default.LastWindow = 2;
            Properties.Settings.Default.Save();
        }

        private async Task Tracking()
        {
            var items = Process.GetProcessesByName(ProcessName);
            do
            {
                int i = 0;
                foreach (var proc in items)
                {
                    if (proc.ProcessName == ProcessName)
                    {
                        i++;
                        if (selectedWindow != i)
                        {
                            continue;
                        }
                        Bitmap bmp = null;
                        try
                        {
                            var rect = new User32.Rect();
                            User32.GetWindowRect(proc.MainWindowHandle, ref rect);

                            int width = rect.right - rect.left;
                            int height = rect.bottom - rect.top;

                            bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
                            Graphics graphics = Graphics.FromImage(bmp);
                            graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
                            graphics.Dispose();

                            // calculate cp/ho/mp bars

                            for (int rws = 0; rws < targets_dt.Rows.Count; rws++)
                            {
                                Rectangle rcngl = RectFromString(targets_dt.Rows[rws]["coord_clmn"].ToString());
                                //targets_dgv.Rows[rws].Cells["Current_value_clmn"].Value = getPartOfBMP(bmp, rcngl);
                                ImageConverter converter = new ImageConverter();
                                targets_dt.Rows[rws]["Current_value_clmn"] = (byte[])converter.ConvertTo(getPartOfBMP(bmp, rcngl), typeof(byte[]));
                                int[,] idealArr = null;
                                int[,] currArr = null;
                                ByteArray2darr((byte[])targets_dt.Rows[rws]["ideal_value_clmn"], rcngl, ref idealArr);
                                ByteArray2darr((byte[])targets_dt.Rows[rws]["Current_value_clmn"], rcngl, ref currArr);
                                int err = Convert.ToInt32(targets_dt.Rows[rws]["correction_clmn"].ToString());
                                int compresult = 0;
                                if(targets_dt.Rows[rws]["type_clmn"].ToString().Equals("Bar")) compresult = calcPercentBarComparisson(idealArr, currArr, err);
                                if (targets_dt.Rows[rws]["type_clmn"].ToString().Equals("Image")) compresult = calcPercentImageComparisson(idealArr, currArr, err);
                                //targets_dgv.Rows[rws].Cells["percentage_clmn"].Value = compresult;
                                if (!targets_dt.Rows[rws]["percentage_clmn"].ToString().Equals(compresult.ToString()))
                                {
                                    targets_dt.Rows[rws]["percentage_clmn"] = compresult;
                                    targets_dt.Rows[rws]["last_change"] = DateTime.Now;
                                }
                                targets_dt.Rows[rws]["idle"] = (DateTime.Now - Convert.ToDateTime(targets_dt.Rows[rws]["last_change"])).TotalMilliseconds;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        if (bmp == null)
                        {
                            continue;
                        }
                        bmp.Dispose();
                    }
                }
                if (!CheckingConditions) CheckConditions();
                await Task.Delay((int)(timeRefresh * 1000));
                // Thread.Sleep(1000);
            } while (TrackingIsActive);
        }

        private async void CheckConditions()
        {
          //  Logging(" Start Checking");
            DateTime starttime = DateTime.Now;
            CheckingConditions = true;
            int rowsCount = scripts_dt.Rows.Count;
            
            DataRow[] resultRows = scripts_dt.Select("result_script_clmn=true and nextuse_script_clmn <= '" + DateTime.Now + "'");
            #region conditions cheking
            //condition string format percent_cond;idle_cond;id....;id
            for (int row = 0; row < rowsCount; row++)
            {
                bool id_criteries = true;
                DataRow dr = scripts_dt.Rows[row];
                string[] criteries = dr["criteria_script_clmn"].ToString().Split(';');
                string perc_crit = "";
                string time_crit = "";
                if (criteries.Length > 0)
                {
                    if (criteries[0] != "") perc_crit = " and percentage_clmn " + criteries[0];
                }
                if (criteries.Length > 1)
                {
                    if (criteries[1] != "") time_crit = String.Format(" and idle {0}", criteries[1]);
                }
                #region check ID expressions
                if (criteries.Length > 2)
                {
                    if (resultRows.Length > 0)
                    {
                        for (int crit = 2; crit < criteries.Length; crit++)
                        {
                            bool finded = false;
                            foreach (DataRow dr1 in resultRows)
                            {
                                if (dr1["id_script_clmn"].ToString().Equals(criteries[crit].ToString()))
                                {
                                    finded = true;
                                    //Logging(DateTime.Now + " 351 find " + criteries[crit].ToString() + "---" + dr1["id_script_clmn"]);
                                }
                            }
                            if (!finded)
                            {
                                id_criteries = false;
                            }
                        }
                    }
                    else
                    {
                        id_criteries = false;
                    }
                }
                #endregion

                string expression = String.Format("name_clmn = '{0}' {1} {2}", dr["target_script_clmn"].ToString(), perc_crit, time_crit);
                DataRow[] targetRow = targets_dt.Select(expression);
                if ((targetRow.Length > 0) && (id_criteries))
                {
                    dr["result_script_clmn"] = true;
                }
                else dr["result_script_clmn"] = false;
                targets_dgv.Refresh();
            }
            #endregion
            resultRows = scripts_dt.Select("result_script_clmn=true and nextuse_script_clmn <= '" + DateTime.Now + "'");
            #region actions checking
            //condition string format action|button1,button2.....buttonN
            // action R = random from all buttons
            if (resultRows.Length > 0)
            {
                foreach (DataRow dr in resultRows)
                {
                    if (dr["action_script_clmn"] != null)
                    {
                        string fullactions = dr["action_script_clmn"].ToString();
                        if (fullactions != "")
                        {
                            string[] buttons = null;
                            string[] actions = null;
                            if (fullactions.Contains("|"))
                            {
                                actions = fullactions.Split('|');
                                buttons = actions[actions.Length - 1].Split(',');
                            }
                            else
                            {
                                buttons = fullactions.Split(',');
                                await DoIt(buttons, "", dr);
                            }
                            if (actions != null)
                            {
                                foreach (string act in actions)
                                {
                                    if (act == ("R"))
                                    {
                                        await DoIt(buttons, act, dr);
                                    }
                                }
                            }
                        }
                    }
                    dr["nextuse_script_clmn"] = DateTime.Now.AddMilliseconds(Convert.ToDouble(dr["delay_script_clmn"].ToString()));
                }
            }
            #endregion
            //Logging(" Ending checking in " + (DateTime.Now - starttime).TotalMilliseconds);
            if (toolStripStatusLabel.Text != "")
            {
                toolStripStatusLabel.Text = (((Convert.ToDouble(toolStripStatusLabel.Text) + (DateTime.Now - starttime).TotalMilliseconds)) / 2).ToString();
            }
            else
            {
                toolStripStatusLabel.Text = ((DateTime.Now - starttime).TotalMilliseconds).ToString();
            }
            CheckingConditions = false;
        }

        /// <summary>
        /// Async clicker
        /// </summary>
        /// <param name="buttons">Buttonts to click</param>
        /// <param name="act">Action (R-random click,"" - Serial click)</param>
        /// <param name="row">№ of row actions</param>
        /// <returns></returns>
        private async Task DoIt(string[] buttons, string act, DataRow row)
        {
            //Process l2proc = Process.GetProcessesByName(ProcessName)[0];
            //IntPtr l2ptr = l2proc.MainWindowHandle;
            string window = row["window_script_clmn"].ToString();
            DataRow drs = clients_dt.Select("winname_clients_dgv = '" + window + "'")[0];
            IntPtr l2ptr = new IntPtr(Convert.ToInt64(drs["winhdr_clients_dgv"].ToString()));
            ushort WM_KEYDOWN = 0x0100;
            ushort WM_KEYUP = 0x0101;
            uint downlparam = 0x00090001;
            uint uplparam = 0xC0090001;
            if (act == "R")
            {
                int value = random.Next(0, buttons.Length);
                getLparams(ref downlparam, ref uplparam, buttons[value]);
                ushort key = (ushort)((Keys)Enum.Parse(typeof(Keys), buttons[value]));
                User32.PostMessage(l2ptr, WM_KEYDOWN, key, downlparam);
                await Task.Delay(random.Next(110, 300));
                User32.PostMessage(l2ptr, WM_KEYUP, key, uplparam);
                //Logging(DateTime.Now + " sending " + buttons[value] + " to " + l2ptr);
            }
            if (act == "")
            {
                foreach (string bttn in buttons)
                {
                    getLparams(ref downlparam, ref uplparam, bttn);
                    ushort key = (ushort)((Keys)Enum.Parse(typeof(Keys), bttn));
                    User32.PostMessage(l2ptr, WM_KEYDOWN, key, downlparam);
                    await Task.Delay(random.Next(110, 210));
                    User32.PostMessage(l2ptr, WM_KEYUP, key, uplparam);
                    await Task.Delay(random.Next(120, 214));
                    //Thread.Sleep(r.Next(100, 250));
                    //Logging(DateTime.Now + " sending " + bttn + " to " + l2ptr);
                }
            }
            row["nextuse_script_clmn"] = DateTime.Now.AddMilliseconds(Convert.ToDouble(row["delay_script_clmn"].ToString()));
            Logging(" sending '" + row["name_script_clmn"].ToString() + "' to " + l2ptr);
        }

        public void getLparams(ref uint _down, ref uint _up, string _key)
        {
            _down = 0;
            _down += (KeyCodes.getCode(_key) << 16);
            _down += 0x01;
            _up = 0xC0;
            _up = _up << 24;
            _up += (KeyCodes.getCode(_key) << 16);
            _up += 0x01;
        }

        private Rectangle RectFromString(string _recStr)
        {
            Rectangle result = new Rectangle(0, 0, 0, 0);
            if (_recStr != "")
            {
                string strres = _recStr.Replace("{", "");
                strres = strres.Replace("}", "");
                string[] strarr = strres.Split(',');
                result.X = Convert.ToInt32(strarr[0].Split('=')[1]);
                result.Y = Convert.ToInt32(strarr[1].Split('=')[1]);
                result.Width = Convert.ToInt32(strarr[2].Split('=')[1]);
                result.Height = Convert.ToInt32(strarr[3].Split('=')[1]);
            }
            return result;
        }

        #region SettingUP for hp/cp/mp/mobHP BAR settings

        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {

            if (GettingOtherTarget)
            {
                other_rect.X = e.X;
                other_rect.Y = e.Y;
                toolStripStatusLabel.Text = other_text + other_rect.Location.ToString();
                StartDrawRect = true;
                Control control = (Control)sender;
                startPoint = control.PointToScreen(new Point(e.X, e.Y));
            }
        }

        private void pictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (GettingOtherTarget)
            {
                other_rect.Width = e.X - other_rect.X;
                other_rect.Height = e.Y - other_rect.Y;
                GettingOtherTarget = false;
                toolStripStatusLabel.Text = other_text + other_rect.ToString();
                try
                {
                    targets_dt.Rows[targets_dgv.CurrentRow.Index]["coord_clmn"] = other_rect.ToString();
                }
                catch
                { }
                finally
                {
                    targets_dgv.CurrentRow.Cells["coord_clmn"].Value = other_rect.ToString();
                }
                CaptureWindows(mainwinptr);
                Bitmap bmp;
                bmp = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
                bmp = (Bitmap)pictureBoxMain.Image;
                targets_dgv.CurrentRow.Cells["ideal_value_clmn"].Value = getPartOfBMP(bmp, other_rect);
                //targets_dt.Rows[targets_dgv.CurrentRow.Index]["ideal_value_clmn"] = getPartOfBMP(bmp, other_rect);

                ControlPaint.DrawReversibleFrame(theRectangle,
          this.BackColor, FrameStyle.Dashed);

                // Find out which controls intersect the rectangle and 
                // change their color. The method uses the RectangleToScreen  
                // method to convert the Control's client coordinates 
                // to screen coordinates.
                Rectangle controlRectangle;
                for (int i = 0; i < Controls.Count; i++)
                {
                    controlRectangle = Controls[i].RectangleToScreen
                  (Controls[i].ClientRectangle);
                    if (controlRectangle.IntersectsWith(theRectangle))
                    {
                        Controls[i].BackColor = Color.BurlyWood;
                    }
                }

                // Reset the rectangle.
                theRectangle = new Rectangle(0, 0, 0, 0);
            }
            StartDrawRect = false;
            CaptureWindows(mainwinptr);
            this.Activate();
        }

        private Bitmap getPartOfBMP(Bitmap _bmp, Rectangle _rect)
        {
            Bitmap result = new Bitmap(_rect.Width, _rect.Height);
            Graphics g = Graphics.FromImage(result);
            g.DrawImage(_bmp, 0, 0, _rect, GraphicsUnit.Pixel);

            return result;
        }

        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (StartDrawRect)
            {
                /* Bitmap bmp;
                 bmp = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
                 bmp = (Bitmap)pictureBoxMain.Image;
                 pictureBoxMain.Image = bmp;
                 Graphics g = Graphics.FromImage(pictureBoxMain.Image);
                 Rectangle rect = new Rectangle();
                 if (GettingOtherTarget) rect = other_rect;
                 rect.Width = e.X - rect.X;
                 rect.Height = e.Y - rect.Y;
                 g.DrawRectangle(new Pen(Color.FromArgb(128, 255, 0, 0), 1), rect);*/

                ControlPaint.DrawReversibleFrame(theRectangle,
            this.BackColor, FrameStyle.Dashed);

                // Calculate the endpoint and dimensions for the new 
                // rectangle, again using the PointToScreen method.
                Point endPoint = ((Control)sender).PointToScreen(new Point(e.X, e.Y));

                int width = endPoint.X - startPoint.X;
                int height = endPoint.Y - startPoint.Y;
                theRectangle = new Rectangle(startPoint.X,
              startPoint.Y, width, height);

                // Draw the new rectangle by calling DrawReversibleFrame
                // again.  
                ControlPaint.DrawReversibleFrame(theRectangle,
              this.BackColor, FrameStyle.Dashed);

            }
        }

        private void bttn_showZones_MouseDown(object sender, MouseEventArgs e)
        {
            Bitmap bmp;
            bmp = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            bmp = (Bitmap)pictureBoxMain.Image;
            pictureBoxMain.Image = bmp;
            Graphics g = Graphics.FromImage(pictureBoxMain.Image);
            Rectangle rect = new Rectangle();

        }

        private void bttn_showZones_MouseUp(object sender, MouseEventArgs e)
        {
            CaptureWindows(mainwinptr);
        }
        #endregion

        private void getArrayFromBMP(Bitmap _bmp, Rectangle _rect, ref int[,] _array)
        {
            byte[,,] bytearr = BitmapToByteRgb(_bmp);
            if (_bmp != null)
            {
                Bitmap b = _bmp;
                _array = new int[_rect.Width, _rect.Height];
                int arrayX = 0;
                for (int x = _rect.X; x < (_rect.X + _rect.Width); x++)
                {
                    int arrayY = 0;
                    for (int y = _rect.Y; y < (_rect.Y + _rect.Height); y++)
                    {
                        _array[arrayX, arrayY] = bytearr[0, y, x] << 8;
                        _array[arrayX, arrayY] = bytearr[1, y, x] << 8;
                        _array[arrayX, arrayY] = bytearr[2, y, x] << 8;
                        //_array[arrayX, arrayY] = b.GetPixel(x, y).ToArgb();
                        arrayY++;
                    }
                    arrayX++;
                }
                /*
                for (int x = _rect.X; x < (_rect.X + _rect.Width); x++)
                {
                    int arrayY = 0;
                    for (int y = _rect.Y; y < (_rect.Y + _rect.Height); y++)
                    {
                        _array[arrayX, arrayY] = b.GetPixel(x, y).ToArgb();
                        arrayY++;
                    }
                    arrayX++;
                }*/
            }
        }

        private void ByteArray2darr(byte[] _arr, Rectangle _rect, ref int[,] _array)
        {
            Bitmap bmp;
            using (var ms = new MemoryStream(_arr))
            {
                bmp = new Bitmap(Bitmap.FromStream(ms));
            };
            byte[,,] bytearr = BitmapToByteRgb(bmp);
            _array = new int[bmp.Width, bmp.Height];
            int arrayX = 0;
            for (int x = 0; x < _rect.Width; x++)
            {
                int arrayY = 0;
                for (int y = 0; y < _rect.Height; y++)
                {
                    try
                    {
                        _array[arrayX, arrayY] = bytearr[0, y, x] << 8; //bmp.GetPixel(x, y).ToArgb();
                        _array[arrayX, arrayY] = bytearr[1, y, x] << 8;
                        _array[arrayX, arrayY] = bytearr[2, y, x] << 8;
                        arrayY++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "550");
                    }
                }
                arrayX++;
            }

            /*for (int x = 0; x < _rect.Width; x++)
            {
                int arrayY = 0;
                for (int y = 0; y < _rect.Height; y++)
                {
                    try
                    {
                        _array[arrayX, arrayY] = bmp.GetPixel(x, y).ToArgb();
                        arrayY++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "550");
                    }
                }
                arrayX++;
            }*/
        }

        public static unsafe byte[,,] BitmapToByteRgb(Bitmap bmp)
        {
            int width = bmp.Width,
                height = bmp.Height;
            byte[,,] res = new byte[3, height, width];
            BitmapData bd = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);
            try
            {
                byte* curpos;
                fixed (byte* _res = res)
                {
                    byte* _r = _res, _g = _res + width * height, _b = _res + 2 * width * height;
                    for (int h = 0; h < height; h++)
                    {
                        curpos = ((byte*)bd.Scan0) + h * bd.Stride;
                        for (int w = 0; w < width; w++)
                        {
                            *_b = *(curpos++); ++_b;
                            *_g = *(curpos++); ++_g;
                            *_r = *(curpos++); ++_r;
                        }
                    }
                }
            }
            finally
            {
                bmp.UnlockBits(bd);
            }
            return res;
        }

        /// <summary>
        /// Calculation Percent of comparisson of Bar
        /// </summary>
        /// <param name="_ideal"></param>
        /// <param name="_current"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        private int calcPercentBarComparisson(int[,] _ideal, int[,] _current, int? errorValue = 10)
        {
            int result = -1;
            if ((_ideal != null) && (_current != null))
            {
                int startX = _ideal.GetLength(0) - 1;
                int startY = _ideal.GetLength(1) - 1;
                int x = startX;
                if (startX != 0)
                {

                    for (x = startX; x >= 0; x--)
                    {
                        int y = startY;
                        double res = 0;
                        int medcount = 0;
                        for (y = 0; y <= startY; y++)
                        {
                            Color fst = Color.FromArgb(_ideal[x, y]);
                            Color scnd = Color.FromArgb(_current[x, y]);
                            res += clrCompare(fst, scnd);
                            medcount++;
                        }
                        res /= medcount;
                        if (res < errorValue)
                        {
                            break;
                        }
                    }
                    result = (int)((x / (double)startX) * 100);
                }
            }
            return result;
        }

        /// <summary>
        /// Calculation Percent of comparisson of Image
        /// </summary>
        /// <param name="_ideal"></param>
        /// <param name="_current"></param>
        /// <param name="errorValue"></param>
        /// <returns></returns>
        private int calcPercentImageComparisson(int[,] _ideal, int[,] _current, int? errorValue = 10)
        {
            int result = -1;
            if ((_ideal != null) && (_current != null))
            {
                int startX = _ideal.GetLength(0) - 1;
                int startY = _ideal.GetLength(1) - 1;
                int x = startX;
                if (startX != 0)
                {
                    double SumPercents = 0;
                    double totalPixels = 0;
                    for (x = startX; x >= 0; x--)
                    {
                        int y = startY;
                        for (y = 0; y <= startY; y++)
                        {
                            Color fst = Color.FromArgb(_ideal[x, y]);
                            Color scnd = Color.FromArgb(_current[x, y]);
                            double r = ((255 - clrCompare(fst, scnd)) / 255)*100;
                            if (r > errorValue)
                            {
                                SumPercents += r;
                            }
                            totalPixels++;
                        }
                    }
                    result = (int)(SumPercents / totalPixels);
                }
            }
            return result;
        }


        private double clrCompare(Color _frst, Color _scnd)
        {
            double result = 0;
            result = Math.Sqrt(Math.Pow(_frst.R - _scnd.R, 2) + Math.Pow(_frst.G - _scnd.G, 2) + Math.Pow(_frst.B - _scnd.B, 2));
            return result;
        }

        private void targets_dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /* if (targets_dgv.DataSource != null)
             {
               if (targets_dgv.Columns[e.ColumnIndex].Name == "percentage_clmn")
               {
                   targets_dgv.Rows[e.RowIndex].Cells["last_change"].Value = DateTime.Now;
               }
             }*/
        }

        private void other_targets_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1)
            {
                if (targets_dgv.Columns[e.ColumnIndex].Name == "coord_clmn")
                {
                    GettingOtherTarget = true;
                    other_text = "Settings coords for " + targets_dgv.CurrentRow.Cells["name_clmn"].Value == null ? "" : targets_dgv.CurrentRow.Cells["name_clmn"].Value.ToString() + " ...";
                    //other_text = "Settings coords for " + targets_dt.Rows[targets_dgv.CurrentRow.Index]["name_clmn"] == null ? "" : targets_dt.Rows[targets_dgv.CurrentRow.Index]["name_clmn"].ToString() + " ...";
                    toolStripStatusLabel.Text = other_text;
                }
                if (targets_dgv.Columns[e.ColumnIndex].Name == "Current_value_clmn")
                {

                }
            }
        }

        private void updateIdealValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            CaptureWindows(mainwinptr);
            Bitmap bmp = ((Bitmap)pictureBoxMain.Image);
            if (targets_dgv.CurrentRow.Cells["type_clmn"].Value.ToString().Equals("Bar"))
            {
                string coords = targets_dgv.CurrentRow.Cells["coord_clmn"].Value.ToString();
                Rectangle rcngl = RectFromString(coords);
                if ((bmp != null) && (rcngl != new Rectangle(0, 0, 0, 0))) targets_dgv.CurrentRow.Cells["ideal_value_clmn"].Value = getPartOfBMP(bmp, rcngl);
                //targets_dt.Rows[rws]["ideal_value_clmn"] = getPartOfBMP(bmp, rcngl);
            }
        }

        private void find_windows_bttn_Click(object sender, EventArgs e)
        {
            var items = Process.GetProcessesByName(ProcessName);
            foreach (DataRow dr in clients_dt.Rows)
            {
                dr["winhdr_clients_dgv"] = 0;
            }
            foreach (Process prc in items)
            {
                DataRow[] dtrws = clients_dt.Select("winname_clients_dgv = '" + prc.MainWindowTitle + "'");
                if (dtrws.Length > 0)
                {
                    foreach (DataRow dr in clients_dt.Rows)
                    {
                        if (dr["winname_clients_dgv"] != null)
                        {
                            if (dr["winname_clients_dgv"].ToString().Equals(prc.MainWindowTitle.ToString()))
                            {
                                dr["winhdr_clients_dgv"] = prc.MainWindowHandle.ToInt32().ToString();
                            }
                        }
                    }
                }
                else
                {
                    DataRow dr = clients_dt.NewRow();
                    dr["winname_clients_dgv"] = prc.MainWindowTitle;
                    dr["winhdr_clients_dgv"] = prc.MainWindowHandle.ToString();
                    clients_dt.Rows.Add(dr);
                }
            }
            CaptureWindows(mainwinptr);
        }

        private void dgv_script_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /* if ((dgv_script.DataSource != null) && (other_dataloaded))
             {
                 scripts_ds.WriteXml("l2runnerScript.xml", XmlWriteMode.WriteSchema);
             }*/
        }

        private void dgv_script_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex>=0)
            { 
            DataGridViewColumn dgvc = dgv_script.Columns[e.ColumnIndex];
            DataGridViewCell dgvcell = dgv_script.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (dgvc.Name == "action_script_clmn")
                {
                    L2KeyBoardForm kb = new L2KeyBoardForm();
                    this.Hide();
                    DialogResult dlgres = kb.ShowDialog(this);
                    if (dlgres != DialogResult.Ignore)
                    {
                        if (dlgres == DialogResult.OK)
                        {
                            dgvcell.Value = kb.result_txtbx.Text;
                        }
                        this.Show();
                    }
                }
            }
        }

        private void Logging(string msg)
        {
            string log_msg = (String.Format("{0:HH:mm:ss.fff}", DateTime.Now) + msg);
            log.Items.Add(log_msg);
            log.SelectedIndex = log.Items.Count - 1;
            log.SelectedIndex = -1;
        }

        private void clients_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (clients_dgv.Rows[e.RowIndex].Cells["winhdr_clients_dgv"].Value != null)
            {
                try
                {
                    if (clients_dgv.Rows[e.RowIndex].Cells["winhdr_clients_dgv"].Value.ToString() != "")
                        mainwinptr = new IntPtr(Convert.ToInt64(clients_dgv.Rows[e.RowIndex].Cells["winhdr_clients_dgv"].Value.ToString()));
                }
                catch { };
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            savetimer.Stop();
            savetimer.Dispose();
            while (!timerDisposed) { };
        }

        private void Savetimer_Disposed(object sender, EventArgs e)
        {
            timerDisposed = true;
        }

        private void filter_txtbx_TextChanged(object sender, EventArgs e)
        {
            ProcessName = filter_txtbx.Text;
            Properties.Settings.Default.filte_string = filter_txtbx.Text;
            Properties.Settings.Default.Save();
        }

        private void targets_dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (e.Exception.Message.Equals("Недопустимое значение DataGridViewComboBoxCell."))
            {
                dgv.CurrentCell.Value = dgv.CurrentCell.DefaultNewRowValue;
            }
            else
            {
                MessageBox.Show(e.Exception.ToString());
            }
        }
    }
}
