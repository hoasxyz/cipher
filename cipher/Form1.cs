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

namespace Cipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i = 1;
        int j = 1;
        int n = Datapass.n;//数值上限
        int N = Datapass.N;//题目数量
        int M = Datapass.M;//操作数
        ArrayList sign = Datapass.sign;
        string[,] Num = new string[Datapass.N, Datapass.M+1];
        string[,] Sign = new string[Datapass.N, Datapass.M ];
        ArrayList Equation = new ArrayList();
        ArrayList input = new ArrayList();
        ArrayList Answer = new ArrayList();
        string temp;

        private void Form1_Load(object sender, EventArgs e)
        {
            Datapass.wrong = 0;
            Datapass.Mistake_Number.Clear();
            Datapass.Mistake_Equation.Clear();
            Datapass.Mistake_Youranswer.Clear();
            Datapass.Mistake_Rightanswer.Clear();

            button2.Enabled = false;
            button3.Enabled = false;
            button4.Visible = false;
            label2.Visible = false;
            label5.Text = "第" + i + "题";
            textBox1.Text = "9999";//默认值

            Random rd = new Random();
            temp = "";
            for (int k = 0; k < M ; k++)
            {
                Num[i - 1, k] = Convert.ToString(rd.Next(1, n + 1));
                Sign[i - 1, k] = Convert.ToString(sign[rd.Next(0, sign.Count)]);
                temp +=  Num[i - 1, k]+Sign[i - 1, k];
            }//接收上一窗口用户输入信息
            Num[i - 1, M] = Convert.ToString(rd.Next(1, n + 1));
            temp +=  Num[i - 1, M];
            label1.Text = temp;
            Equation.Add(temp);
            MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
            sc.Language = "javascript";
            Answer.Add(Convert.ToInt32(sc.Eval(temp)));
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == null || textBox1.Text == "")
            {
                MessageBox.Show("不可为空！");
            } 
            else
            {
                try
                {
                    input.Add(Convert.ToInt32(textBox1.Text));
                    if ((Convert.ToInt32(Answer[i - 1]) == Convert.ToInt32(input[i - 1])))
                    {
                        label2.Text = "恭喜你答对啦！";
                        label2.Visible = true;
                    }
                    else
                    {
                        label2.Text = "答错啦！正确答案是" + (Convert.ToInt32(Answer[i - 1]));
                        label2.Visible = true;
                        Datapass.Mistake_Number.Add(i);
                        Datapass.Mistake_Equation.Add(Equation[i - 1]);
                        Datapass.Mistake_Youranswer.Add(input[i - 1]);
                        Datapass.Mistake_Rightanswer.Add(Answer[i - 1]);
                        Datapass.wrong++;
                    }
                    button1.Enabled = false;
                    if (i != N)
                    {
                        button2.Enabled = true;
                    }
                    if (i > 1)
                    {
                        button3.Enabled = true;
                    }
                    if (i == N)
                    {
                        button4.Visible = true;
                    }
                }
                catch
                {
                    MessageBox.Show("请输入正确的格式！");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button3.Enabled = true;
            label2.Visible = false;
            textBox1.Text = "";
            i++;
            label5.Text = "第" + i + "题";
            textBox1.Text = "9999";//默认值
            if (i == input.Count+1 && i ==j+1)
            {
                j++;
                button2.Enabled = false;
                Random rd = new Random();
                temp = "";
                for (int k = 0; k < M ; k++)
                {
                    Num[i - 1, k] = Convert.ToString(rd.Next(1, n + 1));
                    Sign[i - 1, k] = Convert.ToString(sign[rd.Next(0, sign.Count)]);
                    temp += Num[i - 1, k] + Sign[i - 1, k];
                }//接收上一窗口用户输入信息
                Num[i - 1, M] = Convert.ToString(rd.Next(1, n + 1));
                temp += Num[i - 1, M];
                Equation.Add(temp);
                MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
                sc.Language = "javascript";
                Answer.Add(Convert.ToInt32(sc.Eval(temp)));
                label1.Text = temp;
            }
            else
            {
                label1.Text = Convert.ToString(Equation[i - 1]);
                if (j != input.Count && i == j)
                {
                    textBox1.Text = "";
                }
                else
                {
                    textBox1.Text = Convert.ToString(input[i - 1]);
                    button1.Enabled = false;
                    if ((Convert.ToInt32(Answer[i - 1]) == Convert.ToInt32(input[i - 1])))
                    {
                        label2.Text = "恭喜你答对啦！";
                        label2.Visible = true;
                    }
                    else
                    {
                        label2.Text = "答错啦！正确答案是" + (Convert.ToInt32(Answer[i - 1]));
                        label2.Visible = true;
                    }
                }
            }
            if (i == input.Count + 1 || i == N)
            {
                button2.Enabled = false;
            }
            if (input.Count == N)
            {
                button4.Visible = true;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            i--;
            label5.Text = "第" + i + "题";
            label1.Text = Convert.ToString(Equation[i - 1]); ;
            textBox1.Text = Convert.ToString(input[i - 1]);
            if ((Convert.ToInt32(Answer[i - 1]) == Convert.ToInt32(input[i - 1])))
            {
                label2.Text = "恭喜你答对啦！";
                label2.Visible = true;
            }
            else
            {
                label2.Text = "答错啦！正确答案是" + (Convert.ToInt32(Answer[i - 1]));
                label2.Visible = true;
            }
            if (i ==j&&j!=input.Count)
            {
                button1.Enabled = true;
            }
            if (i != j)
            {
                button2.Enabled = true;
            }
            if (i == 1)
            {
                button3.Enabled = false;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            this.Close();
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && !char.IsNumber(e.KeyChar)&& e.KeyChar != (char)45)
            {
                e.Handled = true;//如果不是输入数字则输入失败
                MessageBox.Show("请输入数字！");
                return;
            }
        }
    }
}
