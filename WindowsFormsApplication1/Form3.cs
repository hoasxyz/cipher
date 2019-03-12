using System;
using System.Collections;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public ArrayList sign = new ArrayList();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("练习有关参数不能为空！");
                    return;
                }
                else if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false && checkBox5.Checked == false)
                {
                    MessageBox.Show("请选择需要进行练习的运算！");
                    return;
                }
                else if ((Convert.ToInt32(textBox3.Text) > 8) || (Convert.ToInt32(textBox3.Text) < 2))
                {
                    MessageBox.Show("操作数设置过多或者过少！");
                    return;
                }
                else if (Convert.ToInt32(textBox2.Text)== 0)
                {
                    MessageBox.Show("操作数上限不可为0！");
                    return;
                }
                else
                {
                    Datapass.N = Convert.ToInt32(textBox1.Text);//题目数量
                    Datapass.n = Convert.ToInt32(textBox2.Text);//在不同窗口传递数据
                    Datapass.M = Convert.ToInt32(textBox3.Text) - 1;//操作数
                    if (checkBox1.Checked == true)//判断用户勾选的运算符
                        Datapass.sign.Add('+');
                    if (checkBox2.Checked == true)
                        Datapass.sign.Add('-');
                    if (checkBox3.Checked == true)
                        Datapass.sign.Add('*');
                    if (checkBox4.Checked == true)
                        Datapass.sign.Add('/');
                    if (checkBox5.Checked == true)
                        Datapass.sign.Add('%');
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("请规范输入格式！");
                return;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && !(char.IsNumber(e.KeyChar)))
            {
                e.Handled = true;//如果不是输入数字则输入失败
                MessageBox.Show("请输入数字！");
                return;
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && !(char.IsNumber(e.KeyChar)))
            {
                e.Handled = true;//如果不是输入数字则输入失败
                MessageBox.Show("请输入数字！");
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && !(char.IsNumber(e.KeyChar)))
            {
                e.Handled = true;//如果不是输入数字则输入失败
                MessageBox.Show("请输入数字！");
                return;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = "3";
            textBox2.Text = "3";
            textBox3.Text = "3";//默认值
        }
    }
}
