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
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Cipher
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        int n = Datapass.n;//数值上限
        int M = Datapass.M;//操作数
        int N = 50;
        char[] sign = Datapass.signall;//每一题运算符号
        string[,] Num = new string[50, Datapass.M + 1];//第二个数
        string[,] Sign = new string[50, Datapass.M];

        int j = 1;
        string temp;
        string[] Equation = new string[50];
        string[] input = new string[50];
        int[] Answer = new int[50];

        private void Form6_Load(object sender, EventArgs e)
        {
            Datapass.wrong = 0;
            Datapass.Mistake_Number.Clear();
            Datapass.Mistake_Equation.Clear();
            Datapass.Mistake_Youranswer.Clear();
            Datapass.Mistake_Rightanswer.Clear();
            Datapass.Grade = 0;

            button3.Enabled = false;
            Random rd = new Random();
            for (int i = 1; i <= N; i++)
            {
                temp = "";
                for (int k = 0; k < M; k++)
                {
                    Num[i - 1, k] = Convert.ToString(rd.Next(1, n + 1));
                    Sign[i - 1, k] = Convert.ToString(sign[rd.Next(0, sign.Length)]);
                    temp += Num[i - 1, k] + Sign[i - 1, k];
                }
                Num[i - 1, M] = Convert.ToString(rd.Next(1, n + 1));
                temp += Num[i - 1, M];
                Equation[i - 1] = temp;
                MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
                sc.Language = "javascript";
                Answer[i - 1] = (Convert.ToInt32(sc.Eval(temp)));
                input[i - 1] = "";
            }
            label5.Text = "第" + j + "题";
            label1.Text = Equation[j - 1];
            sw = new Stopwatch();
            time.Tick += new EventHandler(time_Tick);  //时钟触发信号
            time.Interval = 1;
            sw.Start();
            time.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
                if (MessageBox.Show("考题或许未全部完成，确定要提交吗？", "三思呀！", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int k = 1; k <= 50; k++)
                    {
                        int tryy;
                        if (input[k - 1] == "")
                        {
                            Datapass.Mistake_Number.Add(k);
                            Datapass.Mistake_Equation.Add(Equation[k - 1]);
                            Datapass.Mistake_Youranswer.Add(input[k - 1]);
                            Datapass.Mistake_Rightanswer.Add(Convert.ToString(Answer[k - 1]));
                            Datapass.wrong++;
                            continue;
                        }
                        try
                        {
                            tryy = Convert.ToInt32(input[k - 1]);
                        }
                        catch
                        {
                            Datapass.Mistake_Number.Add(k);
                            Datapass.Mistake_Equation.Add(Equation[k - 1]);
                            Datapass.Mistake_Youranswer.Add(input[k - 1]);
                            Datapass.Mistake_Rightanswer.Add(Convert.ToString(Answer[k - 1]));
                            Datapass.wrong++;
                            continue;
                        }
                        if ((Convert.ToInt32(input[k - 1]) == Answer[k - 1]))
                        {
                            Datapass.Grade += 2;
                        }
                        else
                        {
                            Datapass.Mistake_Number.Add(k);
                            Datapass.Mistake_Equation.Add(Equation[k - 1]);
                            Datapass.Mistake_Youranswer.Add(input[k - 1]);
                            Datapass.Mistake_Rightanswer.Add(Convert.ToString(Answer[k - 1]));
                            Datapass.wrong++;
                        }
                    }
                    Form7 f7 = new Form7();
                    Datapass.time = label2.Text;
                    f7.Show();
                    this.Close();
                }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            input[j - 1] = textBox1.Text;
            j++;
            label5.Text = "第" + j + "题";
            label1.Text = Equation[j - 1];
            textBox1.Text = input[j - 1];
            if (j == N)
            {
                button2.Enabled = false;
            }
            if (j > 1)
            {
                button3.Enabled = true;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            input[j - 1] = textBox1.Text;
            j--;
            label5.Text = "第" + j + "题";
            label1.Text = Equation[j - 1];
            textBox1.Text = input[j - 1];
            if (j < N)
            {
                button2.Enabled = true;
            }
            if (j == 1)
            {
                button3.Enabled = false;
            }
        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)8 && !(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)45)
            {
                e.Handled = true;//如果不是输入数字则输入失败
                MessageBox.Show("请输入数字！");
                return;
            }
        }
        Timer time = new Timer();
        Stopwatch sw; //秒表对象
        TimeSpan ts;
        static int count = 1;

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    button5.Enabled = true;
        //    button6.Enabled = true;
        //    if (button5.Text == "继续") //开始后将继续按钮重置为暂停
        //        button2.Text = "暂停";
        //    sw = new Stopwatch();
        //    time.Tick += new EventHandler(time_Tick);  //时钟触发信号
        //    time.Interval = 1;
        //    sw.Start();
        //    time.Start();
        //}

        void time_Tick(object sender, EventArgs e)
        {
            ts = sw.Elapsed;
            label2.Text = string.Format("本次考试用时{0}分{1}秒", ts.Minutes, ts.Seconds);
        }

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    //停止时间按钮
        //    sw.Stop();
        //    time.Stop();
        //    label2.Text = string.Format("本次考试用时{0}分{1}秒", 0, 0);
        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    if (button5.Text == "暂停")
        //    {
        //        //暂停事件按钮
        //        button5.Text = "继续";
        //        sw.Stop();
        //        time.Stop();
        //    }
        //    else if (button5.Text == "继续")
        //    {
        //        //继续事件
        //        button5.Text = "暂停";
        //        sw.Start();
        //        time.Start();
        //    }
        //}
    }
    }
