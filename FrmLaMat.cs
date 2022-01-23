using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class FrmLaMat : Form
    {
        Data dt = new Data();
        public FrmLaMat()
        {
            InitializeComponent();
        }

        private void FrmLaMat_Load(object sender, EventArgs e)
        {
            bunifuDatePicker1.Value = DateTime.Today.Date;
            dt.LoadLaMat(bunifuDataGridView1,radioButton1,radioButton2,bunifuDatePicker1);
            bunifuDatePicker1.Enabled = false;
        }

        private void bunifuDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(@"../HinhAnhLaMat/" + bunifuDataGridView1.CurrentRow.Cells[1].Value.ToString() + "");
                label3.Text = bunifuDataGridView1.CurrentRow.Cells[2].Value.ToString();
                label4.Text = bunifuDataGridView1.CurrentRow.Cells[3].Value.ToString();
            }
            catch { }
        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
 
            dt.LoadLaMat(bunifuDataGridView1, radioButton1, radioButton2, bunifuDatePicker1);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            bunifuDatePicker1.Enabled = false;
            dt.LoadLaMat(bunifuDataGridView1, radioButton1, radioButton2, bunifuDatePicker1);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            bunifuDatePicker1.Enabled = true;
            dt.LoadLaMat(bunifuDataGridView1, radioButton1, radioButton2, bunifuDatePicker1);
        }
    }
}
