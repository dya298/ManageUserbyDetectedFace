using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
namespace MultiFaceRec
{
    public partial class FrmCamera : Form
    {
        public FrmCamera()
        {
            InitializeComponent();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCapture;

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            videoCapture = new VideoCaptureDevice(filterInfoCollection[0].MonikerString);
            videoCapture.NewFrame += VideoCaptureDevices_NewFrame;
            videoCapture.Start();
        }

        private void VideoCaptureDevices_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void FrmCamera_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo filterInfo in filterInfoCollection)
            {
                bunifuDropdown1.Items.Add(filterInfo.Name);
            }
            bunifuDropdown1.SelectedIndex = 0;
            videoCapture = new VideoCaptureDevice();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if(videoCapture.IsRunning == true)
            {
                videoCapture.Stop();
            }    
        }
    }
}
