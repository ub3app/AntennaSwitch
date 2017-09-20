using System;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Reflection;

namespace AntennaSwitchGUI
{
    public partial class frmMain : Form
    {
        private string magicString = "AS_STATE";
        public string txtSerialTx = "";

        static frmMain instance;
        public static frmMain Instance { get { return instance; } }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            instance = this;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            instance = null;
        }


        public frmMain()
        {
            this.Visible = false;
            this.ShowInTaskbar = false;

            InitializeComponent();

            this.WindowState = FormWindowState.Minimized;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cboPort.Items.AddRange(ports);
            cboPort.SelectedIndex = 0;

            loadSettings();
            applySettings();

            btnOpen_Click(sender, e);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (comPort.IsOpen)
                    comPort.Close();

                comPort.PortName = cboPort.Text;
                comPort.Open();
                if (comPort.IsOpen)
                {
                    comPort.Write("0");
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (comPort.IsOpen)
            {
                comPort.Close();
            }
            ntfyIcon.Visible = false;
        }

        private void checkMenuItem(ToolStripMenuItem item, bool enabled)
        {
            this.BeginInvoke(new MethodInvoker(delegate () {
                item.Checked = enabled;
            }));
        }


        private void showBalloon(int antenna)
        {
            String antText = "";

            switch (antenna)
            {
                case 0b000000:
                    antText = "Dummy load";
                    break;
                case 0b100000:
                    antText = (Properties.Settings.Default.antName1 != "") ? Properties.Settings.Default.antName1 : "Antenna 1";
                    break;
                case 0b010000:
                    antText = (Properties.Settings.Default.antName2 != "") ? Properties.Settings.Default.antName2 : "Antenna 2";
                    break;
                case 0b001000:
                    antText = (Properties.Settings.Default.antName3 != "") ? Properties.Settings.Default.antName3 : "Antenna 3";
                    break;
                case 0b000100:
                    antText = (Properties.Settings.Default.antName4 != "") ? Properties.Settings.Default.antName4 : "Antenna 4";
                    break;
                case 0b000010:
                    antText = (Properties.Settings.Default.antName5 != "") ? Properties.Settings.Default.antName5 : "Antenna 5";
                    break;
            }

            if (antText != "")
                ntfyIcon.ShowBalloonTip(500, "Switched to", antText, ToolTipIcon.None);
        }

        private void stateChangeCallback(int state)
        {
            checkMenuItem(itemAntenna1, false);
            checkMenuItem(itemAntenna2, false);
            checkMenuItem(itemAntenna3, false);
            checkMenuItem(itemAntenna4, false);
            checkMenuItem(itemAntenna5, false);

            
            switch (state)
            {
                case 0b100000:
                    checkMenuItem(itemAntenna1, true);
                    break;
                case 0b010000:
                    checkMenuItem(itemAntenna2, true);
                    break;
                case 0b001000:
                    checkMenuItem(itemAntenna3, true);
                    break;
                case 0b000100:
                    checkMenuItem(itemAntenna4, true);
                    break;
                case 0b000010:
                    checkMenuItem(itemAntenna5, true);
                    break;
            }

            showBalloon(state);
        }
        
        private void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            txtSerialTx += comPort.ReadExisting().ToString();

            if (frmLog.Instance != null)
                frmLog.Instance.SetTextBox(txtSerialTx);

            string pattern;
            pattern = magicString;
            pattern += ":";
            pattern += @"(\d+)$";

            Regex regex = new Regex(pattern);
            Match match = regex.Match(txtSerialTx.Trim());
            if (match.Success)
            {
                stateChangeCallback(Int32.Parse(match.Groups[1].Value) - 1);
            }
        }


        private void itemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void itemSettings_Click(object sender, EventArgs e)
        {
            loadSettings();
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        public void comPortWrite(string str)
        {
            if (comPort.IsOpen)
            {
                comPort.Write(str);
            }
        }

        private void itemAntenna1_Click(object sender, EventArgs e)
        {
            comPortWrite("32");
        }

        private void itemAntenna2_Click(object sender, EventArgs e)
        {
            comPortWrite("16");
        }

        private void itemAntenna3_Click(object sender, EventArgs e)
        {
            comPortWrite("8");
        }

        private void itemAntenna4_Click(object sender, EventArgs e)
        {
            comPortWrite("4");
        }

        private void itemAntenna5_Click(object sender, EventArgs e)
        {
            comPortWrite("2");
        }

        private void itemLog_Click(object sender, EventArgs e)
        {
            

            if (frmLog.Instance != null)
                frmLog.Instance.Show();
            else {
                frmLog fLog = new frmLog();
                fLog.Owner = this;
                fLog.Show(this);
            }
        }

        private void ntfyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            //ctxMenu.Show(Control.MousePosition);
        }

        private void ctxMenu_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(ntfyIcon, null);
            }
        }

        private void saveSettings()
        {
            Properties.Settings.Default.serialPort = cboPort.Text;

            Properties.Settings.Default.isShow1 = chckBox1.Checked;
            Properties.Settings.Default.isShow2 = chckBox2.Checked;
            Properties.Settings.Default.isShow3 = chckBox3.Checked;
            Properties.Settings.Default.isShow4 = chckBox4.Checked;
            Properties.Settings.Default.isShow5 = chckBox5.Checked;

            Properties.Settings.Default.antName1 = txtAntName1.Text;
            Properties.Settings.Default.antName2 = txtAntName2.Text;
            Properties.Settings.Default.antName3 = txtAntName3.Text;
            Properties.Settings.Default.antName4 = txtAntName4.Text;
            Properties.Settings.Default.antName5 = txtAntName5.Text;

            Properties.Settings.Default.Save();

            applySettings();
        }

        private void loadSettings()
        {
            cboPort.Text = Properties.Settings.Default.serialPort;

            chckBox1.Checked = Properties.Settings.Default.isShow1;
            chckBox2.Checked = Properties.Settings.Default.isShow2;
            chckBox3.Checked = Properties.Settings.Default.isShow3;
            chckBox4.Checked = Properties.Settings.Default.isShow4;
            chckBox5.Checked = Properties.Settings.Default.isShow5;

            txtAntName1.Text = Properties.Settings.Default.antName1;
            txtAntName2.Text = Properties.Settings.Default.antName2;
            txtAntName3.Text = Properties.Settings.Default.antName3;
            txtAntName4.Text = Properties.Settings.Default.antName4;
            txtAntName5.Text = Properties.Settings.Default.antName5;
        }

        private void applySettings()
        {
            itemAntenna1.Visible = Properties.Settings.Default.isShow1;
            itemAntenna2.Visible = Properties.Settings.Default.isShow2;
            itemAntenna3.Visible = Properties.Settings.Default.isShow3;
            itemAntenna4.Visible = Properties.Settings.Default.isShow4;
            itemAntenna5.Visible = Properties.Settings.Default.isShow5;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            saveSettings();
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
