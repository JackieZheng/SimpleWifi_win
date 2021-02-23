using SimpleWifi;
using SimpleWifi.Win32;
using SimpleWifi.Win32.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;


namespace SimpleWifiExampleWinForm
{
    public partial class MainWin : Form
    {

        private const int SB_HORZ = 0;
        private const int SB_VERT = 1;
        private const int SB_CTL = 2;
        private const int SB_BOTH = 3;

        private bool wlanIsEnable = true;

        [DllImport("user32.dll")]
        private static extern int ShowScrollBar(int hwnd, int wBar, int bShow);




        private static Wifi wifi;
        private IEnumerable<AccessPoint> accessPoints;
        public MainWin()
        {

            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            wifi = new Wifi();
            wifi.ConnectionStatusChanged += Wifi_ConnectionStatusChanged;
            List();

        }
        /// <summary>
        /// 
        /// </summary>
        private void List()
        {


            lvAccessPoint.HeaderStyle = ColumnHeaderStyle.Clickable;
            lvAccessPoint.View = View.Details;
            lvAccessPoint.Scrollable = true;

            lvAccessPoint.ContextMenuStrip = contextMenuStripView;


            WlanClient client = new WlanClient();
            if (client.Interfaces != null && client.Interfaces.Length > 0)
            {
                foreach (WlanInterface wlanIface in client.Interfaces)
                {
                    if (wlanIface.InterfaceState == WlanInterfaceState.Connected && wlanIface.CurrentConnection.isState == WlanInterfaceState.Connected)
                    {
                        wlanIface.Scan();
                    }

                }
                tssl.Text = "Wlan is enable";
                wlanIsEnable = true;
                BtnEnableWlan.Text = "Disnable";
            }
            else
            {
                wlanIsEnable = false;
                BtnEnableWlan.Text = "Enable";
                tssl.Text = "Wlan is disnable";
            }
            if (wifi.ConnectionStatus != WifiStatus.Connected)
            {
                //return;
            }

            accessPoints = wifi.GetAccessPoints().OrderByDescending(ap => ap.HasProfile).ThenByDescending(ap => ap.SignalStrength);


            lvAccessPoint?.Items?.Clear();
            lvAccessPoint?.Columns?.Clear();




            lvAccessPoint.SmallImageList = new ImageList
            {
                ImageSize = new Size(1, 25)
            };

            int c1 = int.Parse(Math.Floor(0.5 * lvAccessPoint.Width).ToString()),
                c2 = int.Parse(Math.Floor(0.25 * lvAccessPoint.Width).ToString()),
                c3 = lvAccessPoint.Width - c1 - c2;
            lvAccessPoint.Columns.Add("WifiName", c1, HorizontalAlignment.Left);
            lvAccessPoint.Columns.Add("Singnalr", c2, HorizontalAlignment.Center);
            lvAccessPoint.Columns.Add("IsConnected", c3, HorizontalAlignment.Center);

            lvAccessPoint.BeginUpdate();
            foreach (AccessPoint ap in accessPoints)
            {
                if (ap.Name.Trim() != string.Empty)
                {
                    var lvi = new ListViewItem(ap.Name)
                    {
                        Tag = ap
                    };


                    lvi.SubItems.AddRange(new string[] { ap.SignalStrength.ToString(), ap.IsConnected.ToString() });
                    lvi.Selected = ap.IsConnected;
                    if (lvi.Selected)
                    {
                        lvi.UseItemStyleForSubItems = true;
                        lvi.ForeColor = Color.DarkGreen;
                        lvi.Font = new Font(lvi.Font, FontStyle.Bold);
                    }
                    else if (!ap.HasProfile)
                    {
                        lvi.ForeColor = Color.Gray;
                    }
                    lvAccessPoint.Items.Add(lvi);
                }
            }
            lvAccessPoint.EndUpdate();

            //this.lvAccessPoint.Scrollable = false;
            //ShowScrollBar((int)this.lvAccessPoint.Handle, SB_VERT, 1);
        }

        private void Wifi_ConnectionStatusChanged(object sender, WifiStatusEventArgs e)
        {
            tssl.Text = wifi.ConnectionStatus.ToString();
            List();
        }

        private void OnConnectedComplete(bool success)
        {
            tssl.Text = string.Format("OnConnectedComplete, {0}", success);
        }

        private void MainWin_SizeChanged(object sender, EventArgs e)
        {

            int c1 = int.Parse(Math.Floor(0.5 * lvAccessPoint.Width).ToString()),
               c2 = int.Parse(Math.Floor(0.25 * lvAccessPoint.Width).ToString()),
               c3 = lvAccessPoint.Width - c1 - c2;
            if (lvAccessPoint.Columns.Count > 0)
            {
                lvAccessPoint.Columns[0].Width = c1;
                lvAccessPoint.Columns[1].Width = c2;
                lvAccessPoint.Columns[2].Width = c3;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LvAccessPoint_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem lvi = lvAccessPoint.SelectedItems[0] ?? null;
            if (lvi != null)
            {
                AccessPoint selectedAP = (AccessPoint)lvAccessPoint.SelectedItems[0].Tag;
                ConnectAccessPoint(selectedAP);

            }
        }

        private void ConnectAccessPoint(AccessPoint ap)
        {

            AuthRequest authRequest = new AuthRequest(ap);
            bool overwrite = false;
            if (authRequest.IsPasswordRequired)
            {
                if (!ap.HasProfile)
                {
                    //= Interaction.InputBox("", "Input PassWord");
                    InputDialog.Show(out string pwd, "Input the password");
                    if (pwd.Length >= 8 && !string.IsNullOrWhiteSpace(pwd.Trim()) && ap.IsValidPassword(pwd))
                    {
                        authRequest.Password = pwd;
                    }
                }
            }
            ap.ConnectAsync(authRequest, overwrite, OnConnectedComplete);
        }

        private void WifiInfoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            StartCMD();
        }
        private void StartCMD()
        {
            if (lvAccessPoint.SelectedItems.Count == 0) return;
            AccessPoint selectedAP = (AccessPoint)lvAccessPoint.SelectedItems[0].Tag;
            string strInput = "netsh wlan show profile name=\"" + selectedAP.Name + "\" key=clear";
            var p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            p.StandardInput.WriteLine(strInput + "&exit");
            p.StandardInput.AutoFlush = true;
            string strOuput = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
            //MessageBox.Show(strOuput);


            var result = Regex.Match(strOuput, "关键内容[ ]+:(.*)\r");
            if (result.Success)
            {
                MessageBox.Show(result.Groups[1].Value, "WifiInfo");
                Clipboard.SetText(result.Groups[1].Value);
                tssl.Text = result.Groups[1].Value;

            }
            else
            {
                MessageBox.Show("No result！", "WifiInfo");
            }
        }


        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List();
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Activate();
            List();

        }

        private void MainWin_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.ShowInTaskbar = false;
                this.notifyIcon.Visible = true;
            }
        }


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }
        private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
            this.ShowInTaskbar = false;
            this.notifyIcon.Visible = true;


        }

        private void LvAccessPoint_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ListView lv = (ListView)sender;
            if (lv.Columns[e.Column].Tag == null)
            {
                lv.Columns[e.Column].Tag = true;
            }
            bool tabK = (bool)lv.Columns[e.Column].Tag;
            if (tabK)
            {
                lv.Columns[e.Column].Tag = false;
            }
            else
            {
                lv.Columns[e.Column].Tag = true;
            }
            lv.ListViewItemSorter = new ListViewSort(e.Column, lv.Columns[e.Column].Tag);

            lv.Sort();
        }

        private void BtnEnableWlan_Click(object sender, EventArgs e)
        {
            var cmdver = "interface set interface \"WLAN\" " + (wlanIsEnable ? "disabled" : "enabled");
            var res = Command.RunCommand("netsh.exe", cmdver);

            SetTimeout(1000, delegate
            {
                List();
            });


        }

        public static void SetTimeout(double interval, Action action)
        {
            System.Timers.Timer timer = new System.Timers.Timer(interval);
            timer.Elapsed += delegate (object sender, System.Timers.ElapsedEventArgs e)
             {
                 timer.Enabled = false;
                 action();
             };
            timer.Enabled = true;
        }

        private void BtnSet_Click(object sender, EventArgs e)
        {
            Process.Start("ncpa.cpl");
        }

        private void BtnAirplane_Click(object sender, EventArgs e)
        {
            Process.Start("ms-settings:network-airplanemode");
        }


    }
}
