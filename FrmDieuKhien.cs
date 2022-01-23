using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class FrmDieuKhien : Form
    {
        Data dt = new Data();
        //
  
        public FrmDieuKhien()
        {
            InitializeComponent();            
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmDieuKhien_Load(object sender, EventArgs e)
        {
            bunifuDropdown1.DataSource = dt.loadCBDcu();
            bunifuDropdown1.DisplayMember = "TENCUDAN";
            bunifuDropdown1.ValueMember = "MADCU";
        }

        private void FrmDieuKhien_Shown(object sender, EventArgs e)
        {

        }


        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart1.Series["Solan"].Points.Clear();
            foreach (DateTime c in dt.date())
            {
                DateTime date = new DateTime(c.Year, c.Month, c.Day, 0, 0, 0);
                chart1.Series["Solan"].Points.AddXY((date.Day.ToString() + "/" +
                    date.Month.ToString() + "/" +
                    date.Year.ToString())
                    , dt.thongkeHD(bunifuDropdown1.SelectedValue.ToString(), date.Date));
            }
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            bunifuRadialGauge1.Maximum = int.Parse(dt.tongDancu().ToString());
            bunifuRadialGauge1.Value = dt.loadDanCuOut();
            //
            bunifuRadialGauge3.Maximum = int.Parse(dt.tongDancu().ToString());
            bunifuRadialGauge3.Value = dt.loadDanCuIn();
            //
            try
            {
                bunifuRadialGauge2.Maximum = dt.demNguoiLa();
                bunifuRadialGauge2.Value = dt.demNguoiLa();


            }
            catch { }
            //
            double phantram = double.Parse(((dt.loadData_notjoinKHA() / dt.tongDancu()) * 100).ToString());          
            bunifuCircleProgress4.Value = int.Parse(Math.Round(phantram).ToString());
            bunifuCircleProgress3.Value = 100 - bunifuCircleProgress4.Value;
            bunifuLabel7.Text = dt.loadData_notjoinKHA().ToString();
            bunifuLabel5.Text = (dt.tongDancu() - dt.loadData_notjoinKHA()).ToString();
        }
    }
    
}
