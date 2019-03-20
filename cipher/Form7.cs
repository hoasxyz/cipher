using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;

namespace Cipher
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

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    ExcelWorksheet workSheet;
        //    using (var p = new ExcelPackage())
        //    {
        //        workSheet = p.Workbook.Worksheets.Add("考试错题");

        //        workSheet.Cells[1, 1].Value = "题号";
        //        workSheet.Cells[1, 2].Value = "题目";
        //        workSheet.Cells[1, 3].Value = "正确答案";
        //        workSheet.Cells[1, 4].Value = "你的答案";

        //        for (int j = 0; j < Datapass.wrong; j++)
        //        {
        //            workSheet.Cells[j + 2, 1].Value = Datapass.Mistake_Number[j];
        //            workSheet.Cells[j + 2, 2].Value = Datapass.Mistake_Equation[j];
        //            workSheet.Cells[j + 2, 3].Value = Datapass.Mistake_Rightanswer[j];
        //            workSheet.Cells[j + 2, 4].Value = Datapass.Mistake_Youranswer[j];
        //        }
        //        //p.SaveAs(new FileInfo("考试错题.xlsx"));
        //    }
        //}
        private void button4_Click(object sender,EventArgs e)
        {
            ExcelWorksheet workSheet;
            using (var p = new ExcelPackage())
            {
                workSheet = p.Workbook.Worksheets.Add("考试错题");

                workSheet.Cells[1, 1].Value = "题号";
                workSheet.Cells[1, 2].Value = "题目";
                workSheet.Cells[1, 3].Value = "正确答案";
                workSheet.Cells[1, 4].Value = "你的答案";

                for (int j = 0; j < Datapass.wrong; j++)
                {
                    workSheet.Cells[j + 2, 1].Value = Datapass.Mistake_Number[j];
                    workSheet.Cells[j + 2, 2].Value = Datapass.Mistake_Equation[j];
                    workSheet.Cells[j + 2, 3].Value = Datapass.Mistake_Rightanswer[j];
                    workSheet.Cells[j + 2, 4].Value = Datapass.Mistake_Youranswer[j];
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
                    p.SaveAs(new FileInfo(localFilePath));
                }
            }

        }
    }
}
