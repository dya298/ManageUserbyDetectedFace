using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using AForge.Video;
using AForge.Video.DirectShow;
using Bunifu.Framework.UI;
using System.Text.RegularExpressions;

namespace MultiFaceRec
{
    public partial class FrmLoadDanCu : Form
    {
        Emgu.CV.Capture grabber;
        Image<Bgr, Byte> currentFrame;
        SqlConnection cnn;
        SqlDataAdapter dap3,dap,dap2;
        DataSet ds_canho,ds_Phong,ds_dancu;
        DataColumn[] key = new DataColumn[1];
        //
        Image<Bgr, Byte> ImageFrame;
        HaarCascade face,face1;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        Image<Gray, byte> graytest = null;
        Image<Gray, byte> grayImages = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        int ContTrain, NumLabels,t,temp;
        string name = null;
        Image InputImg;
        Image<Bgr, byte> grayScale;
        //
        Data dt = new Data();
        //
        //
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCapture;
        public FrmLoadDanCu()
        {
            // HIỆN PHÒNG
            InitializeComponent();
            cnn = new SqlConnection("Data Source=117.2.159.103,14333;Initial Catalog=QLyChungCu;User ID=sa;Password=sa2012");
                   
            //
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            face1 = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels = Convert.ToInt16(Labels[0]);
                ContTrain = NumLabels;
                string LoadFaces;
                for (int tf = 1; tf < NumLabels + 1; tf++)
                {
 
                    labels.Add(Labels[tf]);
                }
                DirectoryInfo directoryInfo1 = new DirectoryInfo(@"..\bin\TrainedFaces\All");
                FileInfo[] infos1 = directoryInfo1.GetFiles("*", SearchOption.AllDirectories);
                for (int i = 0; i < infos1.Length; i++)
                {
                    string tong = "";
                    foreach (char c in infos1[i].Name)
                    {
                        if (Char.IsDigit(c))
                        {
                            tong += c;
                            
                        }
                    }
                    LoadFaces = "face" + tong + ".bmp";
                    trainingImages.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/All/" + LoadFaces));
                }
            }
            catch (Exception e)
            {
                
            }

        }

        private void FrmLoadDanCu_Load(object sender, EventArgs e)
        {
            //
            bunifuPages1.SetPage(0);
            string sql_phong = "SELECT * FROM PHONG";
            dap = new SqlDataAdapter(sql_phong, cnn);
            ds_Phong = new DataSet();
            dap.Fill(ds_Phong, "PHONG");
            key[0] = ds_Phong.Tables["PHONG"].Columns[0];
            ds_Phong.Tables["PHONG"].PrimaryKey = key;
            //
            foreach (DataRow dataRow in ds_Phong.Tables["PHONG"].Rows)
            {
                Button button = new Button() { Width = 129, Height = 200 };
                button.Text = dataRow["SOPHONG"].ToString();
                button.TextAlign = ContentAlignment.BottomCenter;
                button.Font = new Font("Segoe UI", 14);
                button.Margin = new Padding(20, 20, 20, 20);
                button.Image = Image.FromFile(@"..\bin\iconUser.png");
                button.Click += btnClickPhong;
                button.Tag = dataRow;
                flowLayoutPanel1.Controls.Add(button);
            }
            bunifuGroupBox6.Hide();
        }   
        void btnClickPhong(object sender, EventArgs e)
        {
            //TRUYỀN ID 
            string mp = ((sender as Button).Tag as DataRow)["MAPHONG"].ToString();
            string tenp = ((sender as Button).Tag as DataRow)["SOPHONG"].ToString();
            ShowDialogPhong(mp, tenp);
        }


        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            bunifuLabel1.Text = bunifuLabel1.Text.TrimEnd(lblTemp.Text.ToCharArray()).TrimEnd('>');
            // CHUYỂN TRANG VỀ DANH SÁCH DÂN CƯ
            bunifuPages1.SetPage(1);
            //
            pictureBox3.Image = null;
        }    
        void ShowDialogPhong(string mp,string tenp)
        {
            bunifuLabel2.Text = tenp;
            //flowLayoutPanel2.Controls.Add(labelPhong);
            //
            // HIỆN DANH SÁCH DÂN CƯ THEO PHÒNG CHƯA TẠO HÌNH ẢNH
            cnn = new SqlConnection("Data Source=117.2.159.103,14333;Initial Catalog=QLyChungCu;User ID=sa;Password=sa2012");
            string sql_dancu = "select DANCU.MADCU,DANCU.TENNO from DANCU where NOT EXISTS (select null from RAVAO_HINH where RAVAO_HINH.IDDANCU=DANCU.MADCU) " +
                "and DANCU.MAPHONG='"+mp+"'";
            //
            string sql_dc = "select * from DANCU where MAPHONG='"+mp+"'";
            dap2 = new SqlDataAdapter(sql_dc, cnn);
            ds_dancu = new DataSet();
            dap2.Fill(ds_dancu, "DANCU");           
            key[0] = ds_dancu.Tables["DANCU"].Columns[0];
            ds_dancu.Tables["DANCU"].PrimaryKey = key;
            // TẠO DANH SÁCH DÂN CƯ Ở TRÊN THEO BUTTON
            foreach (DataRow dataRow in ds_dancu.Tables["DANCU"].Rows)
            {
                if(dt.checkHA(dataRow["MADCU"].ToString())==1)
                {
                    BunifuCards bunifu_card = new BunifuCards() { };
                    bunifu_card.Size = new Size(217, 130);
                    bunifu_card.color = Color.Green;
                    bunifu_card.BackColor = Color.White;
                    bunifu_card.RightSahddow = true;
                    bunifu_card.Margin = new Padding(5, 5, 10, 10);
                    //
                    Label label = new Label();
                    label.Text = dataRow["TENCUDAN"].ToString();
                    label.Location = new Point(10, 11);
                    label.Font = new Font("Segoe UI", 13);
                    label.Size = new Size(98, 23);
                    label.Dock = DockStyle.Top;
                    bunifu_card.Controls.Add(label);
                    //
                    PictureBox pictureBox = new PictureBox() { };
                    pictureBox.Image = Image.FromFile(@"..\HinhAnh\iconUser3.png");
                    pictureBox.Location = new Point(49, 34);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Size = new Size(118, 74);
                    bunifu_card.Controls.Add(pictureBox);
                    //
                    BunifuImageButton imagebtn = new BunifuImageButton();
                    imagebtn.Image = Image.FromFile(@"..\HinhAnh\iconRight.png");
                    imagebtn.Size = new Size(30, 29);
                    imagebtn.Location = new Point(182, 96);
                    imagebtn.Click += btnClickDancu;
                    imagebtn.Cursor = Cursors.Hand;
                    imagebtn.Tag = dataRow;
                    bunifu_card.Controls.Add(imagebtn);
                    flowLayoutPanel2.Controls.Add(bunifu_card);
                }
                else
                {
                    BunifuCards bunifu_card = new BunifuCards() { };
                    bunifu_card.Size = new Size(217, 130);
                    bunifu_card.color = Color.Tomato;
                    bunifu_card.BackColor = Color.White;
                    bunifu_card.RightSahddow = true;
                    bunifu_card.Margin = new Padding(5, 5, 10, 10);
                    //
                    Label label = new Label();
                    label.Text = dataRow["TENCUDAN"].ToString();
                    label.Location = new Point(10, 11);
                    label.Font = new Font("Segoe UI", 13);
                    label.Size = new Size(98, 23);
                    label.Dock = DockStyle.Top;
                    bunifu_card.Controls.Add(label);
                    //
                    PictureBox pictureBox = new PictureBox() { };
                    pictureBox.Image = Image.FromFile(@"..\HinhAnh\iconUser3.png");
                    pictureBox.Location = new Point(49, 34);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox.Size = new Size(118, 74);
                    bunifu_card.Controls.Add(pictureBox);
                    //
                    BunifuImageButton imagebtn = new BunifuImageButton();
                    imagebtn.Image = Image.FromFile(@"..\HinhAnh\iconRight.png");
                    imagebtn.Size = new Size(30, 29);
                    imagebtn.Location = new Point(182, 96);
                    imagebtn.Click += btnClickDancu;
                    imagebtn.Cursor = Cursors.Hand;
                    imagebtn.Tag = dataRow;
                    bunifu_card.Controls.Add(imagebtn);
                    flowLayoutPanel2.Controls.Add(bunifu_card);
                }    
                
                //                
            }
            bunifuPages1.SetPage(1);
        }
        void btnClickDancu(object sender, EventArgs e)
        {
            string mp = ((sender as BunifuImageButton).Tag as DataRow)["MADCU"].ToString();
            ShowDialogPhongDancu(mp);
        }
        private void bunifuButton2_Click(object sender, EventArgs e)
        {

        

        }
        void themDancu(object sender,NewFrameEventArgs eventArgs)
        {
            
        }


        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCheckBox1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            bunifuGroupBox6.Hide();
            bunifuCheckBox2.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        }

        private void bunifuCheckBox2_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            bunifuGroupBox6.Show();
            bunifuCheckBox1.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Unchecked;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            bunifuGroupBox6.Hide();

            //
           
                grabber = new Emgu.CV.Capture(1);
                grabber.QueryFrame();
                //Initialize the FrameGraber event
                Application.Idle += new EventHandler(FrameGrabber);
                toolStrip4.Enabled = true;
            //

        }
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        public string tachTen(string id)
        {
            int max1 = 0;
            string tenDC1 = dt.tenDancu(id);
            for (int k = 0; k < tenDC1.Length; k++)
            {
                if (tenDC1[k] == ' ')
                {
                    max1 = k;
                    if (k > max1)
                    {
                        max1 = k;
                    }
                }
            }
            return convertToUnSign3(tenDC1.Substring(max1 + 1));
        }
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                bunifuGroupBox6.Show();
                pictureBox4.Image.Dispose();
                pictureBox4.Image = null;
            }
            catch { }
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            try
            {
                ContTrain = ContTrain + 1; // phần này biến dự trữ để so sánh              
                gray = grabber.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
                    face, // file xml
                    1.2,
                    10,
                    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    new Size(20, 20));

                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = currentFrame.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(lblID.Text);
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/All/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }
                try
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(@"..\bin\TrainedFaces\" + lblID.Text);
                    if (directoryInfo.Exists)
                    {
                        if (MessageBox.Show("Bạn có muốn thêm hình ảnh mới?", "Quy trình nhận diện khuôn mặt", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            FileInfo[] infos = directoryInfo.GetFiles("*", SearchOption.TopDirectoryOnly);
                            try
                            {
                                DirectoryInfo directoryInfo1 = new DirectoryInfo(@"..\bin\TrainedFaces\All");
                                FileInfo[] infos1 = directoryInfo1.GetFiles("*bmp", SearchOption.AllDirectories);
                                int[] listSTT = new int[infos1.Length + 1];
                                double max;
                                for (int i = 0; i < infos1.Length; i++)
                                {
                                    string tong = "";
                                    foreach (char c in infos1[i].Name)
                                    {
                                        if (Char.IsDigit(c))
                                        {
                                            tong += c;
                                        }
                                    }
                                    max = double.Parse(tong.ToString());
                                    if (double.Parse(tong) > max)
                                    {
                                        tong = max.ToString();
                                    }
                                    listSTT[i] = int.Parse(tong);
                                }
                                int max1 = listSTT[0];
                                for (int i = 0; i < listSTT.Length - 1; i++)
                                {
                                    if (listSTT[i] > max1)
                                    {
                                        max1 = listSTT[i];
                                    }
                                }
                                TrainedFace.Save(Application.StartupPath + "/TrainedFaces/" + lblID.Text + "/" + tachTen(lblID.Text) + (infos.Length + 1) + "-" + max1 + ".bmp");
                                try { dt.themHA(tachTen(lblID.Text) + (infos.Length + 1) + "-" + max1 + ".bmp", (lblID.Text)); } catch { MessageBox.Show("Thêm thất bại!!"); };

                            }
                            catch
                            {

                            }

                        }
                    }
                    else
                    {
                        directoryInfo.Create();
                        try
                        {
                            DirectoryInfo directoryInfo1 = new DirectoryInfo(@"..\bin\TrainedFaces\All");
                            FileInfo[] infos1 = directoryInfo1.GetFiles("*bmp", SearchOption.AllDirectories);
                            int[] listSTT = new int[infos1.Length + 1];
                            double max;
                            for (int i = 0; i < infos1.Length; i++)
                            {
                                string tong = "";
                                foreach (char c in infos1[i].Name)
                                {
                                    if (Char.IsDigit(c))
                                    {
                                        tong += c;
                                    }
                                }
                                max = double.Parse(tong.ToString());
                                if (double.Parse(tong) > max)
                                {
                                    tong = max.ToString();
                                }
                                listSTT[i] = int.Parse(tong);
                            }
                            int max1 = listSTT[0];
                            for (int i = 0; i < listSTT.Length - 1; i++)
                            {
                                if (listSTT[i] > max1)
                                {
                                    max1 = listSTT[i];
                                }
                            }
                            TrainedFace.Save(Application.StartupPath + "/TrainedFaces/" + lblID.Text + "/" + tachTen(lblID.Text) + 1 + "-" + max1 + ".bmp");
                            try { dt.themHA(tachTen(lblID.Text) + 1+"-" + max1 + ".bmp", (lblID.Text)); } catch { MessageBox.Show("Thêm thất bại!!"); };
                        }
                        catch { }

                    }
                }
                catch
                {

                }
                bunifuDataGridView1.DataSource = dt.loadHinh((lblTemp.Text));
            }
            catch
            {
                MessageBox.Show("Nhận dạng không thành công!!");
            }
        }
        private void bunifuPanel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog commonOpenFileDialog = new CommonOpenFileDialog();
            commonOpenFileDialog.IsFolderPicker = true;
            if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                try
                {
                    bunifuTextBox3.Text = commonOpenFileDialog.FileName;
                    DirectoryInfo directoryInfo1 = new DirectoryInfo(bunifuTextBox3.Text);
                    FileInfo[] file = directoryInfo1.GetFiles("*", SearchOption.TopDirectoryOnly);
                    for (int i = 0; i < file.Length; i++)
                    {
                        InputImg = AutoResizeImage(bunifuTextBox3.Text + @"\"
                            + file[i].ToString());
                        ImageFrame = new Image<Bgr, byte>(new Bitmap(InputImg));
                        pictureBox3.Image = ImageFrame.ToBitmap();
                        DetectFaces(i + 1);
                        MessageBox.Show("Thành công!!");
                        bunifuDataGridView1.DataSource = dt.loadHinh(lblTemp.Text);
                    }
                }
                catch
                {
                    MessageBox.Show("Folder bạn lựa chọn không tồn tại, xin vui lòng chọn lại.");
                }
            }
        }
        private void bunifuDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string path = (@"..\bin\TrainedFaces\"
                + bunifuDataGridView1.CurrentRow.Cells[0].Value.ToString() + "\\" + bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString());
                pictureBox3.Image = Image.FromFile(path);
            }
            catch { }
        }
        void FrameGrabber(object sender, EventArgs eventArgs)
        {
            try
            {
                currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);

            }
            catch { }
            gray = currentFrame.Convert<Gray, Byte>();
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;

                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);
                //                
            
                if (trainingImages.ToArray().Length != 0)
                {
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray(),
                       3000,
                       ref termCrit);
                    name = recognizer.Recognize(result);                                
                }               
            }           
            pictureBox4.Image = currentFrame.ToBitmap();
            //            
        }

      
       
        private void DetectFaces(int temp)
        {
            try
            {
                //
                ContTrain = ContTrain + 1; // phần này biến dự trữ để so sánh               
                Image<Gray, byte> grayframe = ImageFrame.Convert<Gray, byte>();
                grayImages = grayframe.Convert<Gray, Byte>();
                MCvAvgComp[][] facesDetected = grayImages.DetectHaarCascade(
                    face, // file xml
                    1.2,
                    10,
                    Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                    new Size(20, 20));
                foreach (MCvAvgComp f in facesDetected[0])
                {
                    TrainedFace = grayframe.Copy(f.rect).Convert<Gray, byte>();
                    break;
                }
                TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                trainingImages.Add(TrainedFace);
                labels.Add(lblID.Text);
                File.WriteAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", trainingImages.ToArray().Length.ToString() + "%");
                for (int i = 1; i < trainingImages.ToArray().Length + 1; i++)
                {
                    trainingImages.ToArray()[i - 1].Save(Application.StartupPath + "/TrainedFaces/All/face" + i + ".bmp");
                    File.AppendAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt", labels.ToArray()[i - 1] + "%");
                }
                try
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(@"..\bin\TrainedFaces\" + lblID.Text);
                    if (directoryInfo.Exists)
                    {
                        FileInfo[] infos = directoryInfo.GetFiles("*", SearchOption.TopDirectoryOnly);
                        try
                        {
                            DirectoryInfo directoryInfo1 = new DirectoryInfo(@"..\bin\TrainedFaces\All");
                            FileInfo[] infos1 = directoryInfo1.GetFiles("*bmp", SearchOption.AllDirectories);
                            int[] listSTT = new int[infos1.Length + 1];
                            double max;
                            for (int i = 0; i < infos1.Length; i++)
                            {
                                string tong = "";
                                foreach (char c in infos1[i].Name)
                                {
                                    if (Char.IsDigit(c))
                                    {
                                        tong += c;
                                    }
                                }
                                max = double.Parse(tong.ToString());
                                if (double.Parse(tong) > max)
                                {
                                    tong = max.ToString();
                                }
                                listSTT[i] = int.Parse(tong);
                            }
                            int max1 = listSTT[0];
                            for (int i = 0; i < listSTT.Length - 1; i++)
                            {
                                if (listSTT[i] > max1)
                                {
                                    max1 = listSTT[i];
                                }
                            }
                            TrainedFace.Save(Application.StartupPath + "/TrainedFaces/" + lblID.Text + "/" + tachTen(lblID.Text) + (infos.Length + 1) + "-" + max1 +temp+ ".bmp");
                            try { dt.themHA(tachTen(lblID.Text)  +(infos.Length + 1) + "-" + max1 + temp +".bmp", (lblID.Text)); } catch { MessageBox.Show("Thêm thất bại!!"); };
                        }
                        catch
                        {

                        }

                    }
                    else
                    {
                        directoryInfo.Create();
                        try
                        {
                            DirectoryInfo directoryInfo1 = new DirectoryInfo(@"..\bin\TrainedFaces\All");
                            FileInfo[] infos1 = directoryInfo1.GetFiles("*bmp", SearchOption.AllDirectories);
                            int[] listSTT = new int[infos1.Length + 1];
                            double max;
                            for (int i = 0; i < infos1.Length; i++)
                            {
                                string tong = "";
                                foreach (char c in infos1[i].Name)
                                {
                                    if (Char.IsDigit(c))
                                    {
                                        tong += c;
                                    }
                                }
                                max = double.Parse(tong.ToString());
                                if (double.Parse(tong) > max)
                                {
                                    tong = max.ToString();
                                }
                                listSTT[i] = int.Parse(tong);
                            }
                            int max1 = listSTT[0];
                            for (int i = 0; i < listSTT.Length - 1; i++)
                            {
                                if (listSTT[i] > max1)
                                {
                                    max1 = listSTT[i];
                                }
                            }
                            TrainedFace.Save(Application.StartupPath + "/TrainedFaces/" + lblID.Text + "/" + tachTen(lblID.Text) + 1 + "-" + max1 +temp + ".bmp");
                            try { dt.themHA(tachTen(lblID.Text) + 1 + "-" + max1 + temp + ".bmp", (lblID.Text)); } catch { MessageBox.Show("Thêm thất bại!!"); };
                        }
                        catch
                        {

                        }

                    }

                }
                catch
                {

                }
            }
            catch
            {
                MessageBox.Show("Nhận dạng không thành công!!");
            }
        }
        public Image AutoResizeImage(string url)
        {
            var InputImg = Image.FromFile(url);
            var ImageFrame = new Image<Bgr, byte>(new Bitmap(InputImg));
            Image<Gray, byte> grayframe = ImageFrame.Convert<Gray, byte>();
            grayImages = grayframe.Convert<Gray, Byte>();
            MCvAvgComp[][] facesDetected = grayImages.DetectHaarCascade(
                face,
                1.2,
                10,
                Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                new Size(20, 20));
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = grayframe.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                grayframe.Draw(f.rect, new Gray(Color.Red.ToArgb()), 2);
                if (trainingImages.ToArray().Length != 0)
                {
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray().ToArray(),
                       3000,
                       ref termCrit);
                    name = recognizer.Recognize(result);
                    grayframe.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Gray(Color.LightGreen.ToArgb()));
                }
            }
            return InputImg;
        }
        void ShowDialogPhongDancu(string mp)
        {
            //
            bunifuLabel1.Text = bunifuLabel2.Text + ">" + dt.tenDancu((mp));
            //
            lblTemp.Text = mp;
            //
            bunifuPages1.SetPage(2);
            lblID.Text = mp;
            bunifuDataGridView1.DataSource = dt.loadHinh((lblTemp.Text));

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // CHUYỂN TRANG VỀ DANH SÁCH PHÒNG
            bunifuPages1.SetPage(0);
            //
            bunifuLabel1.Text = "";
            //
            // CLEAR BUTTON Ở TRANG DÂN CƯ
            flowLayoutPanel2.Controls.Clear();
            //
        }
    }
}
