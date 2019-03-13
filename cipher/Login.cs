using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cipher
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string name;

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (username.Text == string.Empty)
            {
                MessageBox.Show("用户名不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool register = (username.Text == "学小习" && usercode.Text == "学小习");
            if (register)
            {
                name = username.Text;
                Form2 main = new Form2();
                main.ShowDialog(this);
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或密码不正确！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            username.Text = "学小习";
            usercode.Text = "学小习";
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/hoasxyz/cipher");
        }
    }
}
