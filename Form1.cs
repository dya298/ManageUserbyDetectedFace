using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class Form1 : Form
    {
        List<Image<Gray, byte>> trainingImages1 = new List<Image<Gray, byte>>();
        List<string> labels1 = new List<string>();
        HaarCascade face;
        int ContTrain1, NumLabels1, t, t1;

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (trainingImages1.ToArray().Length != 0)
            {
                MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain1, 0.001);
                EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                   trainingImages1.ToArray(),
                   labels1.ToArray(),
                   3000,
                   ref termCrit);
                foreach (Image<Gray, Single> images in recognizer._eigenImages)
                {
                    PictureBox p = new PictureBox();
                    p.Size = new Size(144, 137);
                    p.Image = images.ToBitmap();
                    //flowLayoutPanel1.Controls.Add(p);
                    flowLayoutPanel1.Invoke((MethodInvoker)(() => flowLayoutPanel1.Controls.Add(p)));
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            face = new HaarCascade("haarcascade_frontalface_default.xml");
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

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
