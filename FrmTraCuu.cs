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

namespace MultiFaceRec
{
    public partial class FrmTraCuu : Form
    {
        SqlConnection cnn;
        SqlDataAdapter dap;
        DataSet ds_Dancu;
        DataColumn[] key = new DataColumn[1];
        Data dt = new Data();
        public FrmTraCuu()
        {
            InitializeComponent();
            //DÂN CƯ
            cnn = new SqlConnection("Data Source=117.2.159.103,14333;Initial Catalog=QLyChungCu;User ID=sa;Password=sa2012");
            string sql_dancu = "select DANCU.MADCU,DANCU.TENCUDAN,DANCU.MAPHONG,DANCU.TRANGTHAI from DANCU where  " +
                "EXISTS (select null from RAVAO_HINH where RAVAO_HINH.IDDANCU=DANCU.MADCU)";            
            dap = new SqlDataAdapter(sql_dancu, cnn);
            ds_Dancu = new DataSet();
            dap.Fill(ds_Dancu, "DANCU");
            key[0] = ds_Dancu.Tables["DANCU"].Columns[0];
            ds_Dancu.Tables["DANCU"].PrimaryKey = key;
        }        
        private void FrmTraCuu_Load(object sender, EventArgs e)
        {
            comboxPhong();
            //
            try
            {
                bunifuDataGridView1.Columns[0].HeaderText = "Thời gian";
                bunifuDataGridView1.Columns[1].HeaderText = "Khu vực Camera";

                bunifuDataGridView2.Columns[0].HeaderText = "Giờ ra";
                bunifuDataGridView2.Columns[1].HeaderText = "Giờ vào";
                bunifuDataGridView2.Columns[2].HeaderText = "Lần thứ";
            }
            catch
            {

            }
        }
        void loadData()
        {
            dataGridView1.Rows.Clear();
            //          
            foreach (DataRow x in ds_Dancu.Tables["DANCU"].Rows)
            {
                dataGridView1.Rows.Add(new object[] {
                imageList1.Images[0],
                x["MADCU"].ToString(),
                x["TENCUDAN"].ToString(),
                x["MAPHONG"].ToString(),
                Boolean.Parse(x["TRANGTHAI"].ToString()) ? imageList1.Images[1] : imageList1.Images[2]
                });
            }
            bunifuLabel7.Text = dataGridView1.Rows.Count.ToString();
            bunifuLabel4.Text = dataGridView1.Rows.Count.ToString();
        }
        void loadDataCheck(int a)
        {
            string sql_check = "select DANCU.MADCU,DANCU.TENCUDAN,DANCU.MAPHONG,DANCU.TRANGTHAI from DANCU where " +
                " EXISTS (select null from RAVAO_HINH where RAVAO_HINH.IDDANCU=DANCU.MADCU) and TRANGTHAI='" + a + "'";
            SqlDataAdapter dap1 = new SqlDataAdapter(sql_check, cnn);
            DataSet ds_check = new DataSet();
            dap1.Fill(ds_check, "DANCU");
            // 
            key[0] = ds_check.Tables["DANCU"].Columns[0];
            ds_check.Tables["DANCU"].PrimaryKey = key;
            //
            dataGridView1.Rows.Clear();
            //
            foreach (DataRow x in ds_check.Tables["DANCU"].Rows)
            {
                dataGridView1.Rows.Add(new object[] {
                imageList1.Images[0],
                x["MADCU"].ToString(),
                x["TENCUDAN"].ToString(),
                x["MAPHONG"].ToString(),
                Boolean.Parse(x["TRANGTHAI"].ToString()) ? imageList1.Images[1] : imageList1.Images[2]
                });
            }
            bunifuLabel4.Text = dataGridView1.Rows.Count.ToString();
        }
        void comboxPhong()
        {
            string strLop = "select * from PHONG";
            SqlDataAdapter dap3 = new SqlDataAdapter(strLop, cnn);
            DataSet ds_combo = new DataSet();
            dap3.Fill(ds_combo, "PHONG");
            bunifuDropdown1.DataSource = ds_combo.Tables["PHONG"];
            bunifuDropdown1.DisplayMember = "TENPHONG";
            bunifuDropdown1.ValueMember = "MAPHONG";
        }
        void loadDataSearch(string ten)
        {
            string sql_check = "select DANCU.MADCU,DANCU.TENCUDAN,DANCU.MAPHONG,DANCU.TRANGTHAI from DANCU where  " +
                "EXISTS (select null from RAVAO_HINH where RAVAO_HINH.IDDANCU=DANCU.MADCU) and TENCUDAN like N'%" + ten + "%'";
            SqlDataAdapter dap2 = new SqlDataAdapter(sql_check, cnn);
            DataSet ds_search = new DataSet();
            dap2.Fill(ds_search, "DANCU");
            // 
            key[0] = ds_search.Tables["DANCU"].Columns[0];
            ds_search.Tables["DANCU"].PrimaryKey = key;
            dataGridView1.Rows.Clear();
            //          
            foreach (DataRow x in ds_search.Tables["DANCU"].Rows)
            {
                dataGridView1.Rows.Add(new object[] {
                imageList1.Images[0],
                x["MADCU"].ToString(),
                x["TENCUDAN"].ToString(),
                x["MAPHONG"].ToString(),
                Boolean.Parse(x["TRANGTHAI"].ToString()) ? imageList1.Images[1] : imageList1.Images[2]
                });
            }
            bunifuLabel4.Text = dataGridView1.Rows.Count.ToString();
        }
        private void FrmTraCuu_Shown(object sender, EventArgs e)
        {
            loadData();           
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuPages1.SetPage(1);
            lblID.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            loadDTGls();
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(@"..\bin\TrainedFaces\" + lblID.Text);
                FileInfo[] fi = directoryInfo.GetFiles("*", SearchOption.TopDirectoryOnly);
                for(int i=0;i<=fi.Length;i++)
                {
                    Label label = new Label() { };
                    label.Text = fi[i].ToString();
                    PictureBox picture = new PictureBox();
                    picture.Image = Image.FromFile(@"..\bin\TrainedFaces\" + lblID.Text + "\\" + label.Text);
                    picture.Size = new Size(96, 125);                  
                    flowLayoutPanel1.Controls.Add(picture);
                }    
            }
            catch
            {

            }
        }
        void loadDTGls()
        {
            bunifuDatePicker1.Value = DateTime.Today;
            label1.Text = "NHẬT KÝ RA VÀO - " + bunifuDatePicker1.Value.ToShortDateString();
            label2.Text = "THỐNG KÊ SỐ LẦN RA VÀO - " + bunifuDatePicker1.Value.ToShortDateString();
            bunifuDataGridView1.DataSource = dt.lichsuravaofilter((lblID.Text), bunifuDatePicker1.Value);
            bunifuDataGridView2.DataSource = dt.thoiluongfilter((lblID.Text), bunifuDatePicker1.Value);
        }
        private void bunifuButton4_Click_1(object sender, EventArgs e)
        {
            loadData();
        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            loadDataCheck(1);
        }

        private void bunifuButton5_Click_1(object sender, EventArgs e)
        {
            loadDataCheck(0);
        }

        private void bunifuTextBox2_TextChange(object sender, EventArgs e)
        {
            loadDataSearch(bunifuTextBox2.Text);
            if (bunifuTextBox2.Text == string.Empty)
            {
                loadData();
            }
        }

        private void bunifuDropdown1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string sql_selected = "select DANCU.MADCU,DANCU.TENCUDAN,DANCU.MAPHONG,DANCU.TRANGTHAI from DANCU where  " +
               "EXISTS (select null from RAVAO_HINH where RAVAO_HINH.IDDANCU=DANCU.MADCU) and MAPHONG = '" + (bunifuDropdown1.SelectedValue.ToString()) + "'";
            SqlDataAdapter dap4 = new SqlDataAdapter(sql_selected, cnn);
            DataSet ds_selected = new DataSet();
            dap4.Fill(ds_selected, "DANCU,PHONG");
            // 
            key[0] = ds_selected.Tables["DANCU,PHONG"].Columns[0];
            ds_selected.Tables["DANCU,PHONG"].PrimaryKey = key;
            //
            dataGridView1.Rows.Clear();
            //          
            foreach (DataRow x in ds_selected.Tables["DANCU,PHONG"].Rows)
            {
                dataGridView1.Rows.Add(new object[] {
                imageList1.Images[0],
                x["MADCU"].ToString(),
                x["TENCUDAN"].ToString(),
                x["MAPHONG"].ToString(),
                Boolean.Parse(x["TRANGTHAI"].ToString()) ? imageList1.Images[1] : imageList1.Images[2]
                });
            }
            bunifuLabel4.Text = dataGridView1.Rows.Count.ToString();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            loadDTGls();
        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = "NHẬT KÝ RA VÀO - " + bunifuDatePicker1.Value.ToShortDateString();
            label2.Text = "THỐNG KÊ SỐ LẦN RA VÀO - " + bunifuDatePicker1.Value.ToShortDateString();
            bunifuDataGridView1.DataSource = dt.lichsuravaofilter((lblID.Text), bunifuDatePicker1.Value);
            bunifuDataGridView2.DataSource = dt.thoiluongfilter((lblID.Text), bunifuDatePicker1.Value);
            try
            {
                bunifuDataGridView1.Columns[0].HeaderText = "Thời gian";
                bunifuDataGridView1.Columns[1].HeaderText = "Khu vực Camera";

                bunifuDataGridView2.Columns[0].HeaderText = "Giờ ra";
                bunifuDataGridView2.Columns[1].HeaderText = "Giờ vào";
                bunifuDataGridView2.Columns[2].HeaderText = "Lần thứ";
            }
            catch { }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
            flowLayoutPanel1.Controls.Clear();
        }
    }
}
