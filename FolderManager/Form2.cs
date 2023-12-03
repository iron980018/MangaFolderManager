using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace FolderManager
{
    public partial class Form2 : Form
    {
        private string target_name = "";
        public Form2(string name)
        {
            InitializeComponent();

            string excelFilePath = @".\save.xlsx";
            string searchText = name; // 要尋找的文字
            target_name = name;

            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // 假設你的資料在第一個工作表

                int lastRow = worksheet.Dimension.End.Row;

                // 將符合條件的數據加入到 dataGridView1
                for (int row = 1; row <= lastRow; row++) // 開始行是 1 (無標題行
                {
                    string column1 = worksheet.Cells[row, 1].Text; // 第一列
                    //string column2 = worksheet.Cells[row, 2].Text; // 第二列
                    string column3 = worksheet.Cells[row, 3].Text; // 第三列
                    string column4 = worksheet.Cells[row, 4].Text; // 第四列
                    string column5 = worksheet.Cells[row, 5].Text; // 第五列
                    
                    if (column1.Contains(searchText))
                    {
                        textBox1.Text = column3;
                        textBox2.Text = column4;
                        textBox3.Text = column5;
                        break;
                    }
                }
            }
        }

        private void close_form()
        {
            this.Close();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            string excelFilePath = @".\save.xlsx"; // 替換為實際的 Excel 文件路徑
            string targetValue = target_name; // 替換為你要匹配的目標值
            string newValue3 = textBox1.Text; // 替換為新的第3列的值
            string newValue4 = textBox2.Text; // 替換為新的第4列的值
            string newValue5 = textBox3.Text; // 替換為新的第5列的值

            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // 假設你的數據在第一個工作表中

                // 找到包含指定文字的行
                var rowWithTarget = (from row in worksheet.Cells["A1:A" + worksheet.Dimension.End.Row]
                                     where row.Text == targetValue
                                     select row.Start.Row).FirstOrDefault();

                // 檢查是否找到相符的值
                if (rowWithTarget > 0)
                {
                    // 將新的值存放在第3、4、5列
                    worksheet.Cells[rowWithTarget, 3].Value = newValue3;
                    worksheet.Cells[rowWithTarget, 4].Value = newValue4;
                    worksheet.Cells[rowWithTarget, 5].Value = newValue5;

                    // 保存修改
                    package.Save();
                    MessageBox.Show("更新成功。");
                }
                else
                {
                    MessageBox.Show("更新失敗");
                }
            }

            close_form();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            close_form();
        }
    }
}
