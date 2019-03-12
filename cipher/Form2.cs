using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
			//this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
			//this.Hide();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = Login.name + " 小朋友你好呀！";
            toolStripStatusLabel2.Text = " | 登录时间：" + DateTime.Now.ToLongTimeString();
        }
    }
}
