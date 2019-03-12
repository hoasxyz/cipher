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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            label3.Text = Datapass.time;
            listView1.Items.Clear();
            Datapass.right = Datapass.N - Datapass.wrong;
            label1.Text = "本次考试共有" + Datapass.N + "题";
            label2.Text = "你做对了" + Datapass.right + "道，做错了" + Datapass.wrong + "道，分数为"+Datapass.Grade;
            for (int j = 0; j < Datapass.wrong; j++)
            {
                ListViewItem li = new ListViewItem();
                li.SubItems.Clear();
                li.SubItems[0].Text = Convert.ToString(Datapass.Mistake_Number[j]);
                li.SubItems.Add(Convert.ToString(Datapass.Mistake_Equation[j]));
                li.SubItems.Add(Convert.ToString(Datapass.Mistake_Rightanswer[j]));
                li.SubItems.Add(Convert.ToString(Datapass.Mistake_Youranswer[j]));
                listView1.Items.Add(li);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Close();
        }
    }
}
