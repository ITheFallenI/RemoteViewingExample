using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareScreenApp
{
    public partial class Form1 : Form
    {
        public string hostname = ""; //"192.168.1.81";
        public int port = 0000; //5900;

        public RemoteViewing.Vnc.VncClientConnectOptions options = new RemoteViewing.Vnc.VncClientConnectOptions();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            this.Text = "Watching: " + hostname + ":" + port;

            if (vncControl1.Client.IsConnected)
            {
                vncControl1.Client.Close();
            }

            vncControl1.Client.Connect(hostname, port, options); 
            Cursor = Cursors.Default;
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void Test()
        {

        }
    }
}
