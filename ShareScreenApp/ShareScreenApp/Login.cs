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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.hostname = textBox1.Text;
            form.port = int.Parse(textBox2.Text);
            form.options.Password = textBox3.Text.ToCharArray();

            this.Hide();
            form.ShowDialog();

            this.Close();
        }
    }
}
