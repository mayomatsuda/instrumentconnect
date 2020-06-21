using System;
using System.Windows.Forms;

namespace Instrument_Connect
{
    public partial class Connect : Form
    {
        private string peerIP = "";
        private string code = "";

        public Connect(string c, string p)
        {
            InitializeComponent();
            code = c;
            peerIP = p;
            peerTextBox.Text = peerIP;
            clickToCopy.Text = "(click to copy)";
        }

        private void Connect_Load(object sender, EventArgs e)
        {
            yourIP.Text = code;
        }

        private void done_Click(object sender, EventArgs e)
        {
            string entered = peerTextBox.Text;
            peerIP = entered;
            this.Close();
        }

        public string getIP()
        {
            return peerIP;
        }

        private void yourIP_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(code);
            clickToCopy.Text = "(copied!)";
        }

        private void clickToCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(code);
            clickToCopy.Text = "(copied!)";
        }
    }
}
