using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntennaSwitchGUI
{
    public partial class frmLog : Form
    {

        static frmLog instance;
        public static frmLog Instance { get { return instance; } }

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

        //frmMain frmMain = new frmMain();

        public frmLog()
        {
            InitializeComponent();
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            txtRx.Text += value;
        }

        public void SetTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(SetTextBox), new object[] { value });
                return;
            }
            txtRx.Text = value;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (frmMain.Instance != null)
            {
                frmMain.Instance.comPortWrite(txtTx.Text);
                txtTx.Clear();
            }
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            if (frmMain.Instance != null)
                txtRx.Text = frmMain.Instance.txtSerialTx;
        }


    }
}
