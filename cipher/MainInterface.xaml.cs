using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Threading;
using System.Collections;

namespace cipher
{
    /// <summary>
    /// MainInterface.xaml 的交互逻辑
    /// </summary>
    public partial class MainInterface : Window
    {
		static int n = Datapass.n;//数值上限
		static int M = Datapass.M;//操作数
		static int N = Datapass.N;
		static char[] sign = Datapass.signall;//每一题运算符号
		static string[,] Num = new string[50, Datapass.M + 1];//第二个数
		static string[,] Sign = new string[50, Datapass.M];

		static int i = 1;//用来回顾题目时的索引
		static int j = 1;//反映做题进度
		static string temp;
		public static string[] Equation = new string[50];
		public static ArrayList input1 = new ArrayList(55);
		public static string[] input = new string[55];
		public static int[] Answer = new int[50];
		public static string[] right = new string[50];

		private DispatcherTimer timer=new DispatcherTimer();//设置定时器
		Stopwatch sw = new Stopwatch(); //秒表对象
		TimeSpan ts;

		public MainInterface()
        {
            InitializeComponent();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}

		public static void Update()
		{
			n = Datapass.n;//数值上限
			M = Datapass.M;//操作数
			N = Datapass.N;
			sign = Datapass.signall;
			Num = new string[50, Datapass.M + 1];
			Sign = new string[50, Datapass.M];
			Equation = new string[50];
			input1 = new ArrayList(55);
			input = new string[55];
			Answer = new int[50];
			right = new string[50];

			i = 1;j = 1;
			Random rd = new Random();
			Datapass.wrong = 0;
			Datapass.Mistake_Number.Clear();
			Datapass.Mistake_Equation.Clear();
			Datapass.Mistake_Youranswer.Clear();
			Datapass.Mistake_Rightanswer.Clear();
			Datapass.Grade = 0;

			for (int t = 1; t <= Datapass.N; t++)
			{
				temp = "";
				for (int k = 0; k < Datapass.M; k++)
				{
					Num[t - 1, k] = Convert.ToString(rd.Next(1, n + 1));
					Sign[t - 1, k] = Convert.ToString(sign[rd.Next(0, sign.Length)]);
					temp += Num[t - 1, k] + Sign[t - 1, k];
				}
				Num[t - 1, M] = Convert.ToString(rd.Next(1, n + 1));
				temp += Num[t - 1, M];
				Equation[t - 1] = temp;
				MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
				sc.Language = "javascript";
				Answer[t - 1] = (Convert.ToInt32(sc.Eval(temp)));
				input[t - 1] = "";
			}
		}

		void time_Tick(object sender, EventArgs e)
		{
			ts = sw.Elapsed;
			Label2.Content = string.Format("本次考试用时{0}分{1}秒", ts.Minutes, ts.Seconds);
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			Button4.Visibility = Visibility.Hidden;
			Button1.Visibility = Visibility.Hidden;
			Button2.Visibility = Visibility.Hidden;
			Button3.Visibility = Visibility.Hidden;

			Label1.Visibility = Visibility.Hidden;
			Label2.Visibility = Visibility.Hidden;
			Label3.Visibility = Visibility.Hidden;
			Label4.Visibility = Visibility.Hidden;
			textBox1.Visibility = Visibility.Hidden;

			Preference preference = new Preference();
			preference.Show();
			this.Owner.Hide();
		}

		private void Window_Initialized(object sender, EventArgs e)
		{
			StatusLabel1.Content=MainWindow.name+ " 小朋友你好呀！";
			StatusLabel2.Content = " | 登录时间：" + DateTime.Now.ToLongTimeString();
            MessageBox.Show("首次使用，请先点设置，再点开始。", "温馨提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
			
        }

		private void Set_Click(object sender, RoutedEventArgs e)//设置
		{
			//要检查用户的题目有没有做完
			if (MessageBox.Show("做题记录会丢失，确定要切换界面吗？", "小心呀！", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				Button4.Visibility = Visibility.Hidden;
				Button1.Visibility = Visibility.Hidden;
				Button2.Visibility = Visibility.Hidden;
				Button3.Visibility = Visibility.Hidden;

				Label1.Visibility = Visibility.Hidden;
				Label2.Visibility = Visibility.Hidden;
				Label3.Visibility = Visibility.Hidden;
				Label4.Visibility = Visibility.Hidden;
				textBox1.Visibility = Visibility.Hidden;

				Preference preference = new Preference();
				preference.Show();
			}
			
		}

		private void Window_Activated(object sender, EventArgs e)
		{
			

			

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Update();
			ProgressBar1.Maximum = Datapass.N;
			Label1.Content = Equation[j - 1];
			textBox1.Text = "9999";
			if (Datapass.practice == 1)
			{
				ProgressBar1.Value = 0;
				Label3.Visibility = Visibility.Visible;
				Label1.Visibility = Visibility.Visible;
				Label4.Visibility = Visibility.Visible;
				textBox1.Visibility = Visibility.Visible;
				Label3.Content = "练习：第" + j + "题";
				Label2.Visibility = Visibility.Hidden;
				Button1.Visibility = Visibility.Visible;
				Button2.Visibility = Visibility.Visible;
				Button3.Visibility = Visibility.Visible;
				Button1.IsEnabled = false;
				Button2.IsEnabled = false;
				Button3.IsEnabled = true;
				Button3.Visibility = Visibility.Visible;
				Button4.Visibility = Visibility.Hidden;
			}
			else
			{
				ProgressBar1.Value = 1;
				Button1.Visibility = Visibility.Visible;
				Button2.Visibility = Visibility.Visible;
				Button3.Visibility = Visibility.Visible;
				Label3.Visibility = Visibility.Visible;
				Label1.Visibility = Visibility.Visible;
				Label4.Visibility = Visibility.Visible;
				textBox1.Visibility = Visibility.Visible;
				Button1.IsEnabled = false;
				Button2.IsEnabled = true;
				Button3.IsEnabled = true;
				Button4.Visibility = Visibility.Hidden;
				Label3.Content = "考试：第" + j + "题";
				Label2.Visibility = Visibility.Visible;

				timer.Interval = TimeSpan.FromSeconds(1);
				sw = new Stopwatch();
				timer.Tick += new EventHandler(time_Tick);  //时钟触发信号
				sw.Start();
				timer.Start();
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)//下一题
		{
			
			if (Datapass.practice!=1)//考试
			{
				
				input[j - 1] = textBox1.Text;
				j++;
				ProgressBar1.Value = j;
				Label3.Content= "考试：第" + j + "题";
				Label1.Content = Equation[j - 1];
				textBox1.Text = "99";
				if (j == Datapass.N)
					Button2.IsEnabled = false;
				if (j > 1)
					Button1.IsEnabled = true;
			}
			else//练习
			{
				Button1.IsEnabled = true;
				Button3.IsEnabled = true;
				Label2.Visibility = Visibility.Visible;
				j++;
				Label3.Content = "练习：第" + j + "题";
				textBox1.Text = "9999";//默认值
				if(j==input1.Count+1&&j==i+1)//新题
				{
					i++;
					Button2.IsEnabled = false;
					
					Label1.Content = Equation[j - 1];
				}
				else//旧题
				{
					Label1.Content = Equation[j - 1];
					if(i!=input1.Count&&i==j)
					{
						textBox1.Text = "9999";
					}
					else
					{
						textBox1.Text = Convert.ToString(input1[j - 1]);
						Button3.IsEnabled = false;
						if((Convert.ToInt32(Answer[j - 1]) == Convert.ToInt32(input1[j - 1])))
						{
							Label2.Content = "恭喜你答对啦！";
							Label2.Visibility = Visibility.Visible;
							right[j - 1] = "正确";
						}
						else
						{
							Label2.Content = "答错啦！正确答案是" + (Convert.ToInt32(Answer[i - 1]));
							Label2.Visibility = Visibility.Visible;
							right[j - 1] = "错误";
						}
					}
				}
				if (j == input1.Count + 1 || j == Datapass.N)
				{
					Button2.IsEnabled = false;
				}
				if (input1.Count == Datapass.N)
				{
					Button4.Visibility = Visibility.Visible;
				}
			}
		}

		private void Button3_Click(object sender, RoutedEventArgs e)//提交
		{
			if(Datapass.practice==1)//练习
			{
				if (textBox1.Text == null || textBox1.Text == "")
				{
					MessageBox.Show("不可为空！");
				}
				else
				{
					ProgressBar1.Value += 1;
					try
					{
						input1.Add(Convert.ToInt32(textBox1.Text));
						if ((Convert.ToInt32(Answer[j - 1]) == Convert.ToInt32(input1[j - 1])))
						{
							Label2.Content = "恭喜你答对啦！";
							Label2.Visibility = Visibility.Visible;
							right[j - 1] = "正确";
						}
						else
						{
							Label2.Content = "答错啦！正确答案是" + (Convert.ToInt32(Answer[j - 1]));
							Label2.Visibility = Visibility.Visible;
							Datapass.Mistake_Number.Add(j);
							Datapass.Mistake_Equation.Add(Equation[j - 1]);
							Datapass.Mistake_Youranswer.Add(input1[j - 1]);
							Datapass.Mistake_Rightanswer.Add(Answer[j - 1]);
							Datapass.wrong++;
							right[j - 1] = "错误";
						}
						Button3.IsEnabled = false;
						if (j != Datapass.N)
						{
							Button2.IsEnabled = true;
						}
						if (j > 1)
						{
							Button1.IsEnabled = true;
						}
						if (j == Datapass.N)
						{
							Button4.Visibility = Visibility.Visible;
						}
					}
					catch
					{
						MessageBox.Show("请输入正确的格式！");
					}
				}
			}
			else
			{
				
				if (MessageBox.Show("考题或许未全部完成，确定要提交吗？", "三思呀！", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					sw.Stop();
					timer.Stop();
					Button3.IsEnabled = false;
					input[j - 1] = textBox1.Text;
					for (int k = 1; k <= 50; k++)
					{
						int tryy;
						if (input[k - 1].ToString() == "")
						{
							right[k - 1] = "错误";
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
							right[k - 1] = "错误";
							Datapass.Mistake_Number.Add(k);
							Datapass.Mistake_Equation.Add(Equation[k - 1]);
							Datapass.Mistake_Youranswer.Add(input[k - 1]);
							Datapass.Mistake_Rightanswer.Add(Convert.ToString(Answer[k - 1]));
							Datapass.wrong++;
							continue;
						}
						if ((Convert.ToInt32(input[k - 1]) == Answer[k - 1]))
						{
							right[k - 1] = "正确";
							Datapass.Grade += 2;
						}
						else
						{
							right[k - 1] = "错误";
							Datapass.Mistake_Number.Add(k);
							Datapass.Mistake_Equation.Add(Equation[k - 1]);
							Datapass.Mistake_Youranswer.Add(input[k - 1]);
							Datapass.Mistake_Rightanswer.Add(Convert.ToString(Answer[k - 1]));
							Datapass.wrong++;
						}
					}
					Datapass.time = Label2.Content.ToString();
					Solution sol = new Solution();
					sol.Show();
					
					//考虑此窗口是否隐藏
				}
			}
		}

		private void Button4_Click(object sender, RoutedEventArgs e)
		{
			Solution sol = new Solution();
			sol.Show();
		}

		private void Button1_Click(object sender, RoutedEventArgs e)//上一题
		{
			if(Datapass.practice!=1)
			{
				input[j-1]=textBox1.Text;
				j--;
				ProgressBar1.Value = j;
				Label3.Content= "考试：第" + j + "题";
				Label1.Content= Equation[j - 1];
				textBox1.Text = input[j - 1].ToString();
				if (j < Datapass.N)
				{
					Button2.IsEnabled = true;
				}
				if (j == 1)
				{
					Button1.IsEnabled = false;
				}
			}
			else
			{
				Button3.IsEnabled = false;
				j--;
				Label3.Content= "练习：第" + j + "题";
				Label1.Content = Convert.ToString(Equation[j - 1]);
				textBox1.Text = Convert.ToString(input1[j - 1]);
				if ((Convert.ToInt32(Answer[j - 1]) == Convert.ToInt32(input1[j - 1])))
				{
					Label2.Content = "恭喜你答对啦！";
					Label2.Visibility = Visibility.Visible;
				}
				else
				{
					Label2.Content = "答错啦！正确答案是" + (Convert.ToInt32(Answer[j - 1]));
					Label2.Visibility = Visibility.Visible;
				}
				if (j == i && i != input1.Count)
					Button3.IsEnabled = true;
				if (j != i)
					Button2.IsEnabled = true;
				if (j == 1)
					Button1.IsEnabled = false;
			}
		}

		private void Window_Deactivated(object sender, EventArgs e)
		{
			
		}
	}
}
