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

namespace MultiFaceRec
{
    public partial class FrmNhatKy : Form
    {
        SqlConnection cnn;
        SqlDataAdapter dap,dap1,dap2,dap3,dap4;
        DataSet ds_Dancu,ds_check,ds_search,ds_combo,ds_selected;
        DataColumn[] key = new DataColumn[1];
        public FrmNhatKy()
        {
            InitializeComponent();
            cnn = new SqlConnection("Data Source=congtackhac.serveftp.com;Initial Catalog=QuanLyRaVaoNhom2;User ID=sa;Password=123456a@");
            string sql_dancu = "select * from DANCU1";
            dap = new SqlDataAdapter(sql_dancu, cnn);
            ds_Dancu = new DataSet();
            dap.Fill(ds_Dancu, "DANCU1");
            // 
            key[0] = ds_Dancu.Tables["DANCU1"].Columns[0];
            ds_Dancu.Tables["DANCU1"].PrimaryKey = key;
        }
        private string filter = string.Empty;

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows[e.NewValue].Index;
            }
            catch
            {

            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                vScrollBar1.Maximum = dataGridView1.RowCount-1;
            }
            catch
            {

            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                vScrollBar1.Maximum = dataGridView1.RowCount-1;
            }
            catch
            {

            }
        }
        void loadData()
        {
            dataGridView1.Rows.Clear();
            //          
            foreach (DataRow x in ds_Dancu.Tables["DANCU1"].Rows)
            {
                dataGridView1.Rows.Add(new object[] {
                imageList1.Images[0],
                x["IDDANCU"].ToString(),
                x["TENDANCU"].ToString(),
                x["IDPHONG"].ToString(),
                Boolean.Parse(x["TRANGTHAI"].ToString()) ? imageList1.Images[1] : imageList1.Images[2]
                });
            }
            bunifuLabel3.Text = dataGridView1.Rows.Count.ToString();
            bunifuLabel4.Text = dataGridView1.Rows.Count.ToString();
        }
        void loadDataSearch(string ten)
        {
            string sql_check = "select * from DANCU1 where TENDANCU like N'%"+ten+"%'";
            dap2 = new SqlDataAdapter(sql_check, cnn);
            ds_search = new DataSet();
            dap2.Fill(ds_search, "DANCU1");
            // 
            key[0] = ds_search.Tables["DANCU1"].Columns[0];
            ds_search.Tables["DANCU1"].PrimaryKey = key;
            dataGridView1.Rows.Clear();
            //          
            foreach (DataRow x in ds_search.Tables["DANCU1"].Rows)
            {
                dataGridView1.Rows.Add(new object[] {
                imageList1.Images[0],
                x["IDDANCU"].ToString(),
                x["TENDANCU"].ToString(),
                x["IDPHONG"].ToString(),
                Boolean.Parse(x["TRANGTHAI"].ToString()) ? imageList1.Images[1] : imageList1.Images[2]
                });
            }
            bunifuLabel4.Text = dataGridView1.Rows.Count.ToString();
        }
        void loadDataCheck(int a)
        {
            string sql_check = "select * from DANCU1 where TRANGTHAI='" + a + "'";
            dap1 = new SqlDataAdapter(sql_check, cnn);
            ds_check = new DataSet();
            dap1.Fill(ds_check, "DANCU1");
            // 
            key[0] = ds_check.Tables["DANCU1"].Columns[0];
            ds_check.Tables["DANCU1"].PrimaryKey = key;
            //
            dataGridView1.Rows.Clear();
            //
            foreach (DataRow x in ds_check.Tables["DANCU1"].Rows)
            {
                dataGridView1.Rows.Add(new object[] {
                imageList1.Images[0],
                x["IDDANCU"].ToString(),
                x["TENDANCU"].ToString(),
                x["IDPHONG"].ToString(),
                Boolean.Parse(x["TRANGTHAI"].ToString()) ? imageList1.Images[1] : imageList1.Images[2]
                });
            }
            bunifuLabel4.Text = dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString());

        }

        private void FrmNhatKy_Load(object sender, EventArgs e)
        {
            comboxPhong();
        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql_selected = "select DANCU1.IDDANCU,TENDANCU,DANCU1.IDPHONG,TRANGTHAI from DANCU1,PHONG " +
                "where DANCU1.IDPHONG = PHONG.IDPHONG and PHONG.IDPHONG = '"+(bunifuDropdown1.SelectedIndex+1)+"'";
            dap4 = new SqlDataAdapter(sql_selected, cnn);
            ds_selected = new DataSet();
            dap4.Fill(ds_selected, "DANCU1,PHONG");
            // 
            key[0] = ds_selected.Tables["DANCU1,PHONG"].Columns[0];
            ds_selected.Tables["DANCU1,PHONG"].PrimaryKey = key;
            //
            dataGridView1.Rows.Clear();
            //          
            foreach (DataRow x in ds_selected.Tables["DANCU1,PHONG"].Rows)
            {
                dataGridView1.Rows.Add(new object[] {
                imageList1.Images[0],
                x["IDDANCU"].ToString(),
                x["TENDANCU"].ToString(),
                x["IDPHONG"].ToString(),
                Boolean.Parse(x["TRANGTHAI"].ToString()) ? imageList1.Images[1] : imageList1.Images[2]
                });
            }
            bunifuLabel4.Text = dataGridView1.Rows.Count.ToString();
                
        }

        void comboxPhong()
        {
            string strLop = "select * from Phong";
            dap3 = new SqlDataAdapter(strLop, cnn);
            ds_combo = new DataSet();
            dap3.Fill(ds_combo, "PHONG");
            bunifuDropdown1.DataSource = ds_combo.Tables["PHONG"];
            bunifuDropdown1.DisplayMember = "TENPHONG";
            bunifuDropdown1.ValueMember = "IDPHONG";
        }
        private void bunifuTextBox2_TextChange(object sender, EventArgs e)
        {
            loadDataSearch(bunifuTextBox2.Text);
            if(bunifuTextBox2.Text==string.Empty)
            {
                loadData();
            }    
        }

        private void FrmNhatKy_Shown(object sender, EventArgs e)
        {
            loadData();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            loadData();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            loadDataCheck(1);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            loadDataCheck(0);
        }
    }
}
