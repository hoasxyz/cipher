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
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;

namespace cipher
{
    /// <summary>
    /// Solution.xaml 的交互逻辑
    /// </summary>
    public partial class Solution : Window
    {
		ObservableCollection<testInfo> testInfoList = new ObservableCollection<testInfo>();

		public Solution()
        {
            InitializeComponent();
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}

		private void ListView1_Loaded(object sender, RoutedEventArgs e)
		{
			ListView1.Items.Clear();
			Datapass.right = Datapass.N - Datapass.wrong;
			if(Datapass.practice==1)
			{
				Label1.Content= "本次练习共有" + Datapass.N + "题";
			}
			else
			{
				Label1.Content = Datapass.time;
			}
			
			Label2.Content = "你做对了" + Datapass.right + "道，做错了" + Datapass.wrong + "道";
			for (int j = 0; j < Datapass.wrong; j++)
			{
				testInfoList.Add(
					new testInfo(
					Convert.ToString(Datapass.Mistake_Number[j]),
					Convert.ToString(Datapass.Mistake_Equation[j]),
					Convert.ToString(Datapass.Mistake_Rightanswer[j]),
					Convert.ToString(Datapass.Mistake_Youranswer[j]))
					);
			}
			ListView1.ItemsSource = testInfoList;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ExcelWorksheet workSheet;
			using (var q = new ExcelPackage())
			{
				workSheet = q.Workbook.Worksheets.Add("练习错题");
				workSheet.Cells[1, 1].Value = "学生:" + MainWindow.name;
				workSheet.Cells[2, 1].Value = "题号";
				workSheet.Cells[2, 2].Value = "题目";
				workSheet.Cells[2, 3].Value = "正确答案";
				workSheet.Cells[2, 4].Value = "你的答案";
				

				for (int j = 0; j < Datapass.wrong; j++)
				{
					workSheet.Cells[j + 3, 1].Value = Datapass.Mistake_Number[j];
					workSheet.Cells[j + 3, 2].Value = Datapass.Mistake_Equation[j];
					workSheet.Cells[j + 3, 3].Value = Datapass.Mistake_Rightanswer[j];
					workSheet.Cells[j + 3, 4].Value = Datapass.Mistake_Youranswer[j];
				}
				// Displays a SaveFileDialog so the user can save the Image  
				// assigned to Button2.  
				SaveFileDialog saveFileDialog1 = new SaveFileDialog();
				saveFileDialog1.Filter = "Excel 工作簿|*.xlsx";
				saveFileDialog1.Title = "另存为";
				saveFileDialog1.ShowDialog();

				// If the file name is not an empty string open it for saving.  
				if (saveFileDialog1.FileName != "")
				{
					string localFilePath = saveFileDialog1.FileName.ToString();
					q.SaveAs(new FileInfo(localFilePath));
				}
			}
		}
	}

	class testInfo//题目信息类
	{
		private string _num;
		private string _question;
		private string _rightans;
		private string _yourans;
		public string Num//get和set分别为只读和只写，这是绑定的正常写法，Email为我们要进行绑定的一个属性
		{
			get { return _num; }
			set { _num = value; }
		}
		public string Question
		{
			get { return _question; }
			set { _question = value; }
		}
		public string Rightans
		{
			get { return _rightans; }
			set { _rightans = value; }
		}
		public string Yourans
		{
			get { return _yourans; }
			set { _yourans = value; }
		}
		public testInfo(string num, string question, string rightans, string yourans)//构造函数
		{
			_num = num;
			_question = question;
			_rightans = rightans;
			_yourans = yourans;
		}
	}
}
