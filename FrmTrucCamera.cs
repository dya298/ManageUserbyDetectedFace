using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Bunifu.Framework.UI;
using System.Drawing.Imaging;

namespace MultiFaceRec
{
    public partial class FrmTrucCamera : Form
    {
        Capture grabber1;
        Image<Bgr, Byte> currentFrame1, temp;
        Image<Bgr, Byte> currentFrame;
        Image<Gray, byte> gray1, gray2 = null;
        HaarCascade face, face1;
        Image<Gray, byte> result1, result2, TrainedFace1 = null;
        MCvFont font1 = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        MCvFont font2 = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        string name1, name2 = null;
        List<Image<Gray, byte>> trainingImages1 = new List<Image<Gray, byte>>();
        List<string> labels1 = new List<string>();
        int ContTrain1, NumLabels1, t, t1;
        List<string> NamePersons = new List<string>();
        List<string> NamePersons1 = new List<string>();
        //
        Capture grabber;
        //
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCapture;
        FilterInfoCollection filterInfoCollection1;
        VideoCaptureDevice videoCapture1;
        //
        FrmHome frmHome = new FrmHome();
        //
        MJPEGStream stream, stream2;
        //
        int i = 15;
        int p = 15;
        string[] list = new string[200];

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            //stream.Stop();
            videoCapture.Stop();
            btnBatCameraVao.Enabled = true;
            //
            bunifuButton3.Enabled = false;
            //
            dt.updateCamTat0(2);
            //
            try
            {
                pictureBox1.Image = Image.FromFile(@"../HinhAnh/background.jpg");
            }
            catch { }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            //stream2.Stop();
            videoCapture1.Stop();
            bunifuButton2.Enabled = true;
            //
            bunifuButton1.Enabled = false;
            //
            dt.updateCamTat0(1);
            //
            try
            {
                pictureBox2.Image = Image.FromFile(@"../HinhAnh/background.jpg");
            }
            catch { }
        }



        string[] list1 = new string[200];
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            //stream2 = new MJPEGStream("http://192.168.100.6:4747/mjpegfeed?300x400");
            //stream2.NewFrame += FrameGrabber1;
            //stream2.Start();
            bunifuButton1.Enabled = true;
            bunifuButton2.Enabled = false;
            videoCapture1 = new VideoCaptureDevice(filterInfoCollection1[comboBox2.SelectedIndex].MonikerString);
            videoCapture1.NewFrame += FrameGrabber1;
            videoCapture1.Start();
            //
            dt.updateCamTat1(1);
        }

        //
        Data dt = new Data();
        public FrmTrucCamera()
        {
            face = new HaarCascade("haarcascade_frontalface_default.xml");
            face1 = new HaarCascade("haarcascade_frontalface_default.xml");
            InitializeComponent();
            try
            {
                string Labelsinfo = File.ReadAllText(Application.StartupPath + "/TrainedFaces/TrainedLabels.txt");
                string[] Labels = Labelsinfo.Split('%');
                NumLabels1 = Convert.ToInt16(Labels[0]);
                ContTrain1 = NumLabels1;
                string LoadFaces;
                for (int tf = 1; tf < NumLabels1 + 1; tf++)
                {
                    LoadFaces = "face" + tf + ".bmp";
                    trainingImages1.Add(new Image<Gray, byte>(Application.StartupPath + "/TrainedFaces/All/" + LoadFaces));
                    labels1.Add(Labels[tf]);
                }
            }
            catch (Exception e)
            {
                
            }
        }
        private void btnBatCameraVao_Click(object sender, EventArgs e)
        {
            //stream = new MJPEGStream("http://192.168.100.6:4747/mjpegfeed?300x400");
            //stream.NewFrame += FrameGrabber;
            //stream.Start();
            //  
            btnBatCameraVao.Enabled = false;
            videoCapture = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            videoCapture.NewFrame += FrameGrabber;
            videoCapture.Start();
            bunifuButton3.Enabled = true;
            //
            dt.updateCamTat1(2);
        }

        private void imageBoxCameraVao_Click(object sender, EventArgs e)
        {

        }
        //Camera Ra
        void FrameGrabber1(object sender, NewFrameEventArgs eventArgs)
        {
            NamePersons1.Add("");
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();

            Image<Bgr, byte> grayScale = new Image<Bgr, byte>(bitmap);

            gray2 = grayScale.Convert<Gray, Byte>();
            MCvAvgComp[][] facesDetected = gray2.DetectHaarCascade(
          face1,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t1 = t1 + 1;
                result2 = grayScale.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                grayScale.Draw(f.rect, new Bgr(Color.Red), 2);
                grayScale.Draw(p + "s", ref font2, new Point(f.rect.X + 90, f.rect.Y + 110), new Bgr(Color.Yellow));
                if (trainingImages1.ToArray().Length != 0)
                {
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain1, 0.001);
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages1.ToArray(),
                       labels1.ToArray(),
                       3000,
                       ref termCrit);
                    name2 = recognizer.Recognize0(result2);
                    grayScale.Draw(name2, ref font2, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                }
                NamePersons1[t1 - 1] = name2;
                NamePersons1.Add("");
                //
                p -= 1;
            }
            t1 = 0;
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                list1[nnn] = NamePersons1[nnn];
            }
            pictureBox2.Image = grayScale.ToBitmap();
            if (p == 0 || p < 0)
            {
                for (int j = 0; j < list1.Length; j++)
                {
                    if (list1[j] == null)
                    {
                        break;
                    }
                    else
                    {
                        if (dt.checkrachungcu(list1[j]) == 0)
                        {
                            string tendancu2 = "";
                            BunifuCards bunifu_card = new BunifuCards() { };
                            bunifu_card.Size = new Size(910, 43);
                            bunifu_card.Dock = DockStyle.Bottom;
                            bunifu_card.BackColor = Color.White;
                            bunifu_card.RightSahddow = true;
                            //
                            Label label = new Label();
                            label.Text = list1[j];
                            label.Location = new Point(55, 9);
                            label.Size = new Size(110, 25);
                            label.Font = new Font("Segoe UI", 14);
                            if (label.Text == "" || label.Text == null)//Neu rong thi la nguoi la
                            {
                                bunifu_card.color = Color.Tomato;
                                string tenhinhlamat2 = "lamat" + (dt.demlamat() + 1).ToString() + ".png";
                                dt.themLaMat(tenhinhlamat2, "Cổng ra");
                                pictureBox2.Image.Save(@"../HinhAnhLaMat/" + tenhinhlamat2 + "");
                                //
                                Label label2 = new Label();
                                label2.Text = "Người lạ";
                                label2.Location = new Point(18, 9);
                                label2.Size = new Size(100, 30);
                                label2.Font = new Font("Segoe UI", 14);
                                bunifu_card.Controls.Add(label2);
                            }
                            else
                            {
                                bunifu_card.color = Color.Yellow;
                                tendancu2 = dt.hienthiten(list1[j]);
                                dt.themLichSu(label.Text, "Cổng ra");
                                dt.thoiluongRAVAO(list1[j]);
                                dt.capnhatRa(list1[j]);
                                //
                                Label label3 = new Label();
                                label3.Text = dt.hienthiphong(list1[j]);
                                label3.Location = new Point(300, 9);
                                label3.Font = new Font("Segoe UI", 14);
                                label3.Size = new Size(70, 30);
                                bunifu_card.Controls.Add(label3);
                                //
                                Label label2 = new Label();
                                label2.Text = dt.tenDancu(list1[j]);
                                label2.Location = new Point(45, 9);
                                label2.Size = new Size(250, 30);
                                label2.Font = new Font("Segoe UI", 14);
                                bunifu_card.Controls.Add(label2);
                            }

                            //
                            Label label1 = new Label();
                            label1.Text = DateTime.Now.ToShortTimeString();
                            label1.Location = new Point(400, 9);
                            label1.Size = new Size(200, 25);
                            label1.Font = new Font("Segoe UI", 14);
                            bunifu_card.Controls.Add(label1);
                            //
                            PictureBox pictureBox = new PictureBox() { };
                            pictureBox.Image = Image.FromFile(@"..\HinhAnh\iconUser.png");
                            pictureBox.Location = new Point(18, 7);
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                            pictureBox.Size = new Size(23, 29);
                            bunifu_card.Controls.Add(pictureBox);
                            try
                            {
                                flowLayoutPanel1.Invoke((MethodInvoker)(() => flowLayoutPanel1.Controls.Add(bunifu_card)));
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            
                        }
                    }
                }
                p = 15;
            }
            NamePersons1.Clear();
        }

        //CameraVao
        void FrameGrabber(object sender, NewFrameEventArgs eventArgs)
        {
            NamePersons.Add("");
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            Image<Bgr, byte> grayScale = new Image<Bgr, byte>(bitmap);
            gray1 = grayScale.Convert<Gray, Byte>();
            MCvAvgComp[][] facesDetected = gray1.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result1 = grayScale.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                grayScale.Draw(f.rect, new Bgr(Color.Red), 2);
                grayScale.Draw(i + "s", ref font1, new Point(f.rect.X + 90, f.rect.Y + 110), new Bgr(Color.Yellow));
                if (trainingImages1.ToArray().Length != 0)
                {
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain1, 0.001);
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages1.ToArray(),
                       labels1.ToArray(),
                       3000,
                       ref termCrit);
                    name1 = recognizer.Recognize0(result1);
                    grayScale.Draw(name1, ref font1, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                }
                NamePersons[t - 1] = name1;
                NamePersons.Add("");
                //
                i -= 1
                ;
            }
            t = 0;
            for (int nnn = 0; nnn < facesDetected[0].Length; nnn++)
            {
                list[nnn] = NamePersons[nnn];
            }
            pictureBox1.Image = grayScale.ToBitmap();
            if (i == 0 || i < 0)
            {
                for (int j = 0; j < list.Length; j++)
                {
                    if (list[j] == null)
                    {

                        break;
                    }
                    else
                    {
                        if (dt.checktrongchungcu(list[j]) == 0)
                        {
                            string tendancu1 = "";
                            BunifuCards bunifu_card = new BunifuCards() { };
                            bunifu_card.Size = new Size(910, 43);
                            bunifu_card.Dock = DockStyle.Bottom;
                            bunifu_card.BackColor = Color.White;
                            bunifu_card.RightSahddow = true;
                            //
                            Label label = new Label();
                            label.Text = list[j];
                            label.Location = new Point(55, 9);
                            label.Size = new Size(110, 25);
                            label.Font = new Font("Segoe UI", 14);
                            if (label.Text == "" || label.Text == null)
                            {
                                bunifu_card.color = Color.Tomato;
                                string tenhinhlamat1 = "lamat" + (dt.demlamat() + 1).ToString() + ".png";
                                dt.themLaMat(tenhinhlamat1, "Cổng vào");
                                pictureBox1.Image.Save(@"../HinhAnhLaMat/" + tenhinhlamat1 + "");
                                //
                                Label label2 = new Label();
                                label2.Text = "Người lạ";
                                label2.Location = new Point(18, 9);
                                label2.Font = new Font("Segoe UI", 14);
                                label2.Size = new Size(100, 30);
                                bunifu_card.Controls.Add(label2);
                            }
                            else
                            {
                                bunifu_card.color = Color.Green;
                                tendancu1 = dt.hienthiten(list[j]);
                                dt.themLichSu(label.Text, "Cổng vào");
                                dt.capnhatTL(list[j]);
                                dt.capnhatVao(list[j]);
                                //
                                Label label3 = new Label();
                                label3.Text = dt.hienthiphong(list[j]);
                                label3.Location = new Point(300, 9);
                                label3.Font = new Font("Segoe UI", 14);
                                label3.Size = new Size(70, 30);
                                bunifu_card.Controls.Add(label3);
                                //
                                Label label2 = new Label();
                                label2.Text = dt.tenDancu(list[j]);
                                label2.Location = new Point(45, 9);
                                label2.Font = new Font("Segoe UI", 14);
                                label2.Size = new Size(250, 30);
                                bunifu_card.Controls.Add(label2);
                            }
                            //
                            Label label1 = new Label();
                            label1.Text = DateTime.Now.ToShortTimeString();
                            label1.Location = new Point(400, 9);
                            label1.Size = new Size(230, 25);
                            label1.Font = new Font("Segoe UI", 14);
                            bunifu_card.Controls.Add(label1);
                            //
                            PictureBox pictureBox = new PictureBox() { };
                            pictureBox.Image = Image.FromFile(@"..\HinhAnh\iconUser.png");
                            pictureBox.Location = new Point(18, 7);
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                            pictureBox.Size = new Size(23, 29);
                            bunifu_card.Controls.Add(pictureBox);
                            try
                            {
                                flowLayoutPanel1.Invoke((MethodInvoker)(() => flowLayoutPanel1.Controls.Add(bunifu_card)));
                            }
                            catch
                            {

                            }

                        }
                        else
                        {
                           
                        }
                    }
                }
                i = 15;
            }
            NamePersons.Clear();
        }
        private void FrmTrucCamera_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
            {
                comboBox1.Items.Add(filterInfo.Name);
            }
            comboBox1.SelectedIndex = 0;
            videoCapture = new VideoCaptureDevice();
            //
            filterInfoCollection1 = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection1)
            {
                comboBox2.Items.Add(filterInfo.Name);
            }
            comboBox2.SelectedIndex = 0;
            videoCapture1 = new VideoCaptureDevice();
            //
            bunifuButton3.Enabled = false;
            bunifuButton1.Enabled = false;
        }
    }
}
