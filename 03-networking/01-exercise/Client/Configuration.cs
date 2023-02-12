using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Configuration : Form
    {
        public string IP_SERVER;
        public int PORT;

        public Configuration(string IP_SERVER, int PORT)
        {
            InitializeComponent();
            this.IP_SERVER = IP_SERVER;
            txtIP.Text = IP_SERVER;
            this.PORT = PORT;
            txtPort.Text = PORT.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IPAddress.TryParse(IP_SERVER, out IPAddress IPa))
            {
                MessageBox.Show(this, "The IP not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIP.Text = IP_SERVER;
                return;
            }
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {
            IP_SERVER = txtIP.Text;
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(txtPort.Text, out Int32 port) || port > IPEndPoint.MaxPort)
            {
                MessageBox.Show(this, "The PORT not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPort.Text = PORT.ToString();
                return;
            }

            PORT = port;
        }
    }
}
