using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace MultiFaceRec
{
    public partial class FormBackup : Form
    {
        Data dt = new Data();
        public FormBackup()
        {
            InitializeComponent();
        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnfoler_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();
            commonOpenFileDialog.IsFolderPicker = true;
            if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                try
                {
                    txtfolder.Text = commonOpenFileDialog.FileName;
              
                }
                catch
                {
                }
                 
            }
        }

        private void btnsaoluu_Click(object sender, EventArgs e)
        {
            if (txtfolder.Text == "")
            {
                MessageBox.Show("Vui lòng chọn đường dẫn !");
            }
            else
            {
                string ngay = DateTime.Today.Day.ToString();
                ngay += "-" + DateTime.Today.Month.ToString();
                ngay += "-" + DateTime.Today.Year.ToString();

                string[] folderPaths = Directory.GetDirectories(@"..\bin\TrainedFaces\");
                string targetPath = @"" + txtfolder.Text + " "+"\\"+  ngay + "\\";
                if (Directory.Exists(targetPath))
                {
                    MessageBox.Show("Bạn đã sao lưu trước đó. Thực hiện lại vào ngày mai!");
                }
                else
                {
                    SqlConnection cnn = new SqlConnection("Data Source=117.2.159.103,14333;Initial Catalog=QLyChungCu;User ID=sa;Password=sa2012");
                    cnn.Open();
                    string que1 = "BACKUP DATABASE QLyChungCu TO DISK = 'C:\\FTP\\Databasebackup\\backup-" + ngay + ".bak'";
                    string que2 = "BACKUP DATABASE QLyChungCu TO DISK = 'C:\\FTP\\Databasebackup\\backup-last.bak'";
                    SqlCommand cmd1 = new SqlCommand(que1, cnn);
                    SqlCommand cmd2 = new SqlCommand(que2, cnn);
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cnn.Close();
                    System.IO.Directory.CreateDirectory(targetPath);
                    //Copy File TrainedLabels
                    System.IO.File.Copy(@"..\bin\TrainedFaces\TrainedLabels.txt", targetPath + "TrainedLabels.txt", true);
                    //Duyet cac folder co trong folderPath
                    foreach (var folders in folderPaths)
                    {
                        string folder = folders.ToString();
                        string[] arrListStr = folder.Split('\\');
                        string folertarget = targetPath + arrListStr[arrListStr.Length - 1];
                        //Tao folder o folder targer
                        System.IO.Directory.CreateDirectory(folertarget);
                        //Lay danh sach cac files trong folder
                        string[] files = Directory.GetFiles(folder);
                        //Duyet de copy cac file sang folder target
                        foreach (string s in files)
                        {
                            string fileName = System.IO.Path.GetFileName(s);
                            string destFile = System.IO.Path.Combine(folertarget, fileName);
                            System.IO.File.Copy(s, destFile, true);
                        }

                    }
                    MessageBox.Show("Sao lưu dữ liệu hoàn tất");

                }
            }
        }

        private void btnphuchoi_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Data Source=117.2.159.103,14333;Initial Catalog=QLyChungCu;User ID=sa;Password=sa2012");
            cnn.Open();
            string que1 = " ALTER DATABASE QLyChungCu SET SINGLE_USER with rollback immediate;";
            string que2 = " use master restore database QLyChungCu from disk = 'C:\\FTP\\Databasebackup\\backup-last.bak' WITH REPLACE;";
            SqlCommand cmd1 = new SqlCommand(que1, cnn);
            cmd1.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand(que2, cnn);
            cmd2.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("Phục hồi dữ liệu hoàn tất");
        }

        private void FormBackup_Load(object sender, EventArgs e)
        {
            
        }

        
      
    }
}
