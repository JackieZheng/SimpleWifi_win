using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWifiExampleWinForm
{
    public partial class FrmInputDialog : Form
    {
        public FrmInputDialog()
        {
            InitializeComponent();
        }
        public FrmInputDialog(string title)
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(title))
            {
                this.Text = title;
            }            
            
        }
        public delegate void TextEventHandler(string strText);
        public TextEventHandler TextHandler;

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (null != TextHandler)
            {
                TextHandler.Invoke(txtString.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void BtnConcel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void TxtString_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Keys.Enter == (Keys)e.KeyChar)
            {
                if (null != TextHandler)
                {
                    TextHandler.Invoke(txtString.Text);
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
