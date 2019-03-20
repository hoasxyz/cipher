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

namespace cipher
{
	/// <summary>
	/// Preference.xaml 的交互逻辑
	/// </summary>
	public partial class Preference : Window
	{
		public Preference()
		{
			InitializeComponent();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void Button1_Click(object sender, RoutedEventArgs e)
		{
			if (RadioButton1.IsChecked == true)
			{
				Datapass.practice = 1;
				try
				{
					if (Convert.ToInt32(TextBox1.Text) == 0 || Convert.ToInt32(TextBox2.Text) == 0 || Convert.ToInt32(TextBox3.Text) == 0)
					{
						MessageBox.Show("练习有关的参数不能为零！");
						return;
					}
					else if (CheckBox1.IsChecked == false && CheckBox2.IsChecked == false && CheckBox3.IsChecked == false && CheckBox4.IsChecked == false && CheckBox5.IsChecked == false)
					{
						MessageBox.Show("请选择需要进行练习的运算！");
						return;
					}
					else if ((Convert.ToInt32(TextBox3.Text) > 8) || (Convert.ToInt32(TextBox3.Text) < 2))
					{
						MessageBox.Show("操作数设置过多或者过少！");
						return;
					}
					else if (Convert.ToInt32(TextBox2.Text) == 0)
					{
						MessageBox.Show("操作数上限不可为0！");
						return;
					}
					else
					{
						Datapass.N = Convert.ToInt32(TextBox1.Text);//题目数量
						Datapass.n = Convert.ToInt32(TextBox2.Text);//在不同窗口传递数据
						Datapass.M = Convert.ToInt32(TextBox3.Text) - 1;//操作数
						if (CheckBox1.IsChecked == true)//判断用户勾选的运算符
							Datapass.sign.Add('+');
						if (CheckBox2.IsChecked == true)
							Datapass.sign.Add('-');
						if (CheckBox3.IsChecked == true)
							Datapass.sign.Add('*');
						if (CheckBox4.IsChecked == true)
							Datapass.sign.Add('/');
						if (CheckBox5.IsChecked == true)
							Datapass.sign.Add('%');
						
						this.Close();
					}
				}
				catch
				{
					MessageBox.Show("请规范输入格式！");
					return;
				}
			}
			else
			{
				Datapass.practice = 0;
				Datapass.N = 50;
				switch (comboBox1.SelectedIndex)
				{
					case 0:
						Datapass.n = 10;
						Datapass.M = 1;
						
						break;
					case 1:
						Datapass.n = 10;
						Datapass.M = 3;
						
						break;
					case 2:
						Datapass.n = 10;
						Datapass.M = 5;
						
						break;
					case 3:
						Datapass.n = 100;
						Datapass.M = 5;
						
						break;
					default:
						MessageBox.Show("你没有选择考试难度哦！");
						return;
				}
				this.Close();
			}
		}

		private void RadioButton1_Checked(object sender, RoutedEventArgs e)
		{
			
		}

		private void RadioButton1_Unchecked(object sender, RoutedEventArgs e)
		{
			
		}

		private void RadioButton2_Checked(object sender, RoutedEventArgs e)
		{
			
		}

		private void RadioButton1_Click(object sender, RoutedEventArgs e)
		{
			comboBox1.IsEnabled = false;
			TextBox1.IsEnabled = true;
			TextBox2.IsEnabled = true;
			TextBox3.IsEnabled = true;
			CheckBox1.IsEnabled = true;
			CheckBox2.IsEnabled = true;
			CheckBox3.IsEnabled = true;
			CheckBox4.IsEnabled = true;
			CheckBox5.IsEnabled = true;
		}

		private void RadioButton2_Click(object sender, RoutedEventArgs e)
		{
			comboBox1.IsEnabled = true;
			TextBox1.IsEnabled = false;
			TextBox2.IsEnabled = false;
			TextBox3.IsEnabled = false;
			CheckBox1.IsEnabled = false;
			CheckBox2.IsEnabled = false;
			CheckBox3.IsEnabled = false;
			CheckBox4.IsEnabled = false;
			CheckBox5.IsEnabled = false;
		}
	}
}
