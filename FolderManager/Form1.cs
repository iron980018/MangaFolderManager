using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;
using static OfficeOpenXml.ExcelErrorValue;

namespace FolderManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            clear_datagridview();
            load_all_under_save();
        }

        private void clear_datagridview()
        {
            dataGridView1.Rows.Clear();
        }

        private void search_target()
        {
            string excelFilePath = @".\save.xlsx";
            string searchText = textBox1.Text; // 要尋找的文字

            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // 假設你的資料在第一個工作表

                int lastRow = worksheet.Dimension.End.Row;

                // 將符合條件的數據加入到 dataGridView1
                for (int row = 1; row <= lastRow; row++) // 開始行是 1 (無標題行
                {
                    string column1 = worksheet.Cells[row, 1].Text; // 第一列
                    string column2 = worksheet.Cells[row, 2].Text; // 第二列
                    string column3 = worksheet.Cells[row, 3].Text; // 第三列
                    string column4 = worksheet.Cells[row, 4].Text; // 第四列
                    string column5 = worksheet.Cells[row, 5].Text; // 第五列

                    // 如果任何一列包含指定文字，將其添加到 dataGridView1
                    if (column1.Contains(searchText) || column3.Contains(searchText) || column4.Contains(searchText) || column5.Contains(searchText))
                    {
                        Image image;

                        // 讀取圖片到 MemoryStream
                        using (MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(column2 + @"\1.jpg")))
                        {
                            // 將 MemoryStream 轉換為 Image
                            image = Image.FromStream(memoryStream);
                        }
                        dataGridView1.Rows.Add(image, column1, column3, column4, column5);
                    }
                }
            }
        }

        private string search_adress_by_name(string target_name)
        {
            string excelFilePath = @".\save.xlsx";
            string target_adress = "FileNotExit";
            // 檢查 Excel 文件是否存在
            if (System.IO.File.Exists(excelFilePath))
            {
                // 使用 EPPlus 讀取 Excel 文件
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(new System.IO.FileInfo(excelFilePath)))
                {

                    var worksheet = package.Workbook.Worksheets[0]; // 假設你的資料在第一個工作表
                    int rowcount = worksheet.Dimension?.Rows ?? 0;
                    int lastRow;

                    // 獲取資料的最後一列
                    if (rowcount == 0)
                    {
                        MessageBox.Show("404 Not Found : no data");
                    }
                    else
                    {
                        lastRow = worksheet.Dimension.End.Row;

                        // 遍歷 Excel 表格，查找資料夾名稱和位置

                        for (int row = 1; row <= lastRow; row++)
                        {
                            string currentFolderName = worksheet.Cells[row, 1].Text; // 第一列是資料夾名稱
                            string currentFolderLocation = worksheet.Cells[row, 2].Text; // 第二列是資料夾位置

                            if (currentFolderName == target_name)
                            {
                                target_adress = currentFolderLocation;
                            }
                        }
                    }                    
                }
            }
            else
            {
                MessageBox.Show("Excel 文件不存在");
            }
            return target_adress;
        }

        private void load_all_under_save()
        {
            /*
            //btn
            DataGridViewButtonColumn btn_open = new DataGridViewButtonColumn();
            btn_open.Name = "open";
            btn_open.HeaderText = "開啟";
            btn_open.DefaultCellStyle.NullValue = "開啟";
            btn_open.Width = 60;
            DataGridViewButtonColumn btn_edit = new DataGridViewButtonColumn();
            btn_edit.Name = "edit";
            btn_edit.HeaderText = "編輯";
            btn_edit.DefaultCellStyle.NullValue = "編輯";
            btn_edit.Width = 60;
            DataGridViewButtonColumn btn_delete = new DataGridViewButtonColumn();
            btn_delete.Name = "delete";
            btn_delete.HeaderText = "刪除";
            btn_delete.DefaultCellStyle.NullValue = "刪除";
            btn_delete.Width = 60;

            dataGridView1.Columns.Add(btn_open);
            dataGridView1.Columns.Add(btn_edit);
            dataGridView1.Columns.Add(btn_delete);
            */
            //image
            string saveFolderPath = @".\save";
            /*
            DataGridViewImageColumn imageColumn = (DataGridViewImageColumn)dataGridView1.Columns["Image"];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;*/

            dataGridView1.RowTemplate.Height = 250;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // 檢查資料夾是否存在
            if (Directory.Exists(saveFolderPath))
            {
                // 讀取資料夾
                string[] subdirectories = Directory.GetDirectories(saveFolderPath);

                // 輸出每個資料夾的名稱和位置
                foreach (string subdirectory in subdirectories)
                {
                    string excelFilePath = @".\save.xlsx";
                    string folderNameToFind = Path.GetFileName(subdirectory);
                    string folderLocationToFind = subdirectory; // 此處應該填寫完整的位置

                    // 檢查 Excel 文件是否存在
                    if (System.IO.File.Exists(excelFilePath))
                    {
                        // 使用 EPPlus 讀取 Excel 文件
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        using (var package = new ExcelPackage(new System.IO.FileInfo(excelFilePath)))
                        {                           

                            var worksheet = package.Workbook.Worksheets[0]; // 假設你的資料在第一個工作表
                            bool folderExists = false;
                            int lastRow;
                            int rowcount = worksheet.Dimension?.Rows ?? 0;
                            
                            // 獲取資料的最後一列
                            if (rowcount == 0)
                            {
                                lastRow = 0;
                            }
                            else
                            {
                                lastRow = worksheet.Dimension.End.Row;

                                // 遍歷 Excel 表格，查找資料夾名稱和位置
                                
                                for (int row = 1; row <= lastRow; row++)
                                {
                                    string currentFolderName = worksheet.Cells[row, 1].Text; // 第一列是資料夾名稱
                                    string currentFolderLocation = worksheet.Cells[row, 2].Text; // 第二列是資料夾位置

                                    if (currentFolderName == folderNameToFind && currentFolderLocation == folderLocationToFind)
                                    {
                                        //MessageBox.Show($"資料夾已存在：{folderNameToFind}，位置：{folderLocationToFind}");
                                        folderExists = true;

                                        // 單張圖片路徑
                                        string imagePath = subdirectory+"\\1.jpg";
                                        Image image ;

                                        // 讀取圖片到 MemoryStream
                                        using (MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(imagePath)))
                                        {
                                            // 將 MemoryStream 轉換為 Image
                                            image = Image.FromStream(memoryStream);
                                        }

                                        dataGridView1.Rows.Add(image, folderNameToFind, worksheet.Cells[row, 3].Text, worksheet.Cells[row, 4].Text, worksheet.Cells[row, 5].Text);
                                        break;
                                    }
                                }
                            }

                            if (!folderExists)
                            {
                                // 資料夾不存在，將其加入 Excel 文件
                                int newRowIndex = lastRow + 1;
                                worksheet.Cells[newRowIndex, 1].Value = folderNameToFind;
                                worksheet.Cells[newRowIndex, 2].Value = folderLocationToFind;
                                worksheet.Cells[newRowIndex, 3].Value = " "; // 假設" "是TAG1預設值
                                worksheet.Cells[newRowIndex, 4].Value = " "; // 假設" "是TAG2預設值
                                worksheet.Cells[newRowIndex, 5].Value = " "; // 假設" "是TAG3預設值

                                package.Save(); // 保存修改
                                //Console.WriteLine($"已將資料夾添加到 Excel 文件：{folderNameToFind}，位置：{folderLocationToFind}");

                                string imagePath = subdirectory + "\\1.jpg";
                                Image image;

                                // 讀取圖片到 MemoryStream
                                using (MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(imagePath)))
                                {
                                    // 將 MemoryStream 轉換為 Image
                                    image = Image.FromStream(memoryStream);
                                }

                                dataGridView1.Rows.Add(image, folderNameToFind, " ", " ", " ");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Excel 文件不存在");
                    }

                    

                    /*
                    MessageBox.Show($"資料夾名稱: {Path.GetFileName(subdirectory)}");
                    MessageBox.Show($"位置: {subdirectory}");
                    //Console.WriteLine();
                    */
                }
            }
            else
            {
                MessageBox.Show("資料夾不存在");
            }
        }

        private void unzip_Click(object sender, EventArgs e)
        {
            //  卡關-暫無功能
            //  C#
            /*
            string originalFolderPath = @".\original";
            string saveFolderPath = @".\save";
            string zipFolderPath = @".\zip";

            // 获取 original 文件夹下的所有 zip 文件
            string[] zipFiles = Directory.GetFiles(originalFolderPath, "*.zip");

            // 循环处理每个 zip 文件
            foreach (string zipFile in zipFiles)
            {
                // 获取保存解压后文件的文件夹路径（含文件名）
                string saveFolder = Path.Combine(saveFolderPath, Path.GetFileNameWithoutExtension(zipFile));

                // 解压缩文件到指定文件夹
                try
                {
                    // 创建保存解压文件的文件夹
                    Directory.CreateDirectory(saveFolder);

                    // 解压文件
                    ZipFile.ExtractToDirectory(zipFile, saveFolder);
                    Console.WriteLine($"成功解压缩文件到 {saveFolder}");
                }
                catch (Exception er)
                {
                    Console.WriteLine($"解压缩文件时发生错误: {er.Message}");
                }

                // 移动原始 zip 文件到 zip 文件夹
                try
                {
                    // 创建目标文件夹
                    Directory.CreateDirectory(zipFolderPath);

                    // 移动文件
                    string destinationFilePath = Path.Combine(zipFolderPath, Path.GetFileName(zipFile));
                    File.Move(zipFile, destinationFilePath);
                    Console.WriteLine($"成功移动文件到 {destinationFilePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"移动文件时发生错误: {ex.Message}");
                }
            }
            */

            // python
            /*
            // 指定Python腳本文件的路徑
            //F:\Microsoft VS save\FolderManager\FolderManager\bin\Debug
            string pythonScriptPath = @".\original\unzip.py";

            // 設定進程啟動信息
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = @"C:\Users\iron0\AppData\Local\Programs\Python\Python311\python.exe", // 或者你的Python安裝路徑，例如：@"C:\Users\iron0\AppData\Local\Programs\Python\Python311\python.exe"/"python"
                Arguments = pythonScriptPath,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // 創建一個進程對象並啟動
            using (Process process = new Process { StartInfo = psi })
            {
                process.Start();

                // 等待Python腳本執行完成
                process.WaitForExit();

                //讀取Python腳本的輸出
                //string output = process.StandardOutput.ReadToEnd();
                //Console.WriteLine("Python腳本的輸出：\n" + output);
                
            }
            */

            //python 2
            /*
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\iron0\AppData\Local\Programs\Python\Python311\python.exe";
            start.Arguments = $"\"{@".\original\unzip.py"}\"";
            start.UseShellExecute = false;// Do not use OS shell
            start.CreateNoWindow = true; // We don't need new window
            start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
            start.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                    string result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
                    //return result;
                }
            }
            */

            //MessageBox.Show("解壓完成");

            //clear_datagridview();
            //load_all_under_save();
            
        }

        private void search_Click(object sender, EventArgs e)
        {
            clear_datagridview();
            if (textBox1.Text == "" || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                load_all_under_save();
            }
            else
            {
                search_target();
            }
        }
        private int FindRowByName(ExcelWorksheet worksheet, string name)
        {
            int lastRow = worksheet.Dimension.End.Row;

            for (int row = 1; row <= lastRow; row++)
            {
                string currentName = worksheet.Cells[row, 1].Text; // 第一列是名字
                if (currentName == name)
                {
                    return row;
                }
            }

            return -1; // 如果未找到，返回 -1
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Form2 關閉前執行的代碼
            //Console.WriteLine("Form2 即將關閉。可以在這裡執行進一步的操作。");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "open" && e.RowIndex >= 0)
            {
                string adress = search_adress_by_name(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

                if (System.IO.Directory.Exists(adress))
                {
                    // 開啟資料夾
                    Process.Start("explorer.exe", adress);
                }
                else
                {
                    MessageBox.Show("資料夾不存在");
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "edit" && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // 獲取第二列的內容
                string contentOfSecondColumn = row.Cells[1].Value.ToString();

                Form2 form2 = new Form2(contentOfSecondColumn);
                form2.ShowDialog();

                
                clear_datagridview();
                if (textBox1.Text == "" || string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    load_all_under_save();
                }
                else
                {
                    search_target();
                }
                
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "delete" && e.RowIndex >= 0)
            {
                MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                DialogResult d = MessageBox.Show("確定刪除?", "提示", mess);
                if (d == DialogResult.OK) 
                {

                    string excelFilePath = @".\save.xlsx";
                    string nameToDelete = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); // 要刪除的名字
                    string adress = search_adress_by_name(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

                    using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
                    {
                        var worksheet = package.Workbook.Worksheets[0]; // 假設你的資料在第一個工作表

                        // 找到要刪除的行
                        int rowToDelete = FindRowByName(worksheet, nameToDelete);

                        if (rowToDelete != -1)
                        {
                            // 刪除行
                            worksheet.DeleteRow(rowToDelete, 1);

                            // 往前補充，將下一行往前移動
                            for (int row = rowToDelete; row <= worksheet.Dimension.End.Row; row++)
                            {
                                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                                {
                                    worksheet.Cells[row, col].Value = worksheet.Cells[row + 1, col].Value;
                                }
                            }

                            // 刪除多餘的行（最後一行會被複製到前一行，所以最後一行可以刪除）
                            worksheet.DeleteRow(worksheet.Dimension.End.Row, 1);

                            // 保存修改
                            package.Save();
                            Console.WriteLine($"已成功刪除名字為 {nameToDelete} 的行並往前補充。");
                        }
                        else
                        {
                            Console.WriteLine($"找不到名字為 {nameToDelete} 的行。");
                        }
                    }

                    try
                    {
                        // 刪除資料夾及其內容
                        if (Directory.Exists(adress))
                        {
                            Directory.Delete(adress, true);
                            Console.WriteLine($"成功刪除資料夾 {adress} 及其內容。");
                        }
                        else
                        {
                            Console.WriteLine($"資料夾 {adress} 不存在。");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"刪除資料夾時發生錯誤：{ex.Message}");
                    }

                    clear_datagridview();
                    //MessageBox.Show("clear");
                    if(textBox1.Text != null && textBox1.Text != "")
                    {
                        //MessageBox.Show(textBox1.Text);
                    }
                    else
                    {
                        load_all_under_save();
                        //MessageBox.Show("load");
                    }

                    MessageBox.Show("刪除成功");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void refresh_Click(object sender, EventArgs e)
        {
            clear_datagridview();
            load_all_under_save();
        }
    }
}
