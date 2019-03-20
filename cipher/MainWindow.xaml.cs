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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cipher
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public static string name= "学小习";
		public MainWindow()
		{
			InitializeComponent();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}

		private void StatusBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			
		}

		private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/hoasxyz/cipher");
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (User.Text == "学小习" && Password.Text == "学小习")
			{
				MainInterface mainInterface = new MainInterface();
				mainInterface.Owner = this;
				mainInterface.ShowDialog();
				this.Close();
			}
			else
			{
					MessageBox.Show("请输入正确的用户名或密码！");
			}
			
		}
	}
}
