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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = "请选择考试难度";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Datapass.N = 50;
            switch (Convert.ToString(comboBox1.SelectedItem))
            {
                case "简单（十以内单次运算）":
                    Datapass.n = 10;
                    Datapass.M = 1;
                    break;
                case "普通（十以内少次运算）":
                    Datapass.n = 10;
                    Datapass.M = 3;
                    break;
                case "较难（十以内多次运算）":
                    Datapass.n = 10;
                    Datapass.M = 5;
                    break;
                case "困难（二位数多次运算）":
                    Datapass.n = 100;
                    Datapass.M = 5;
                    break;
                default:
                    MessageBox.Show("你没有选择考试难度哦！");
                    return;
            }
            Form6 f6 = new Form6();
            f6.Show();
            this.Close();
        }
    }
}
