using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MultiFaceRec
{
    public partial class FrmDangNhap : Form
    {
        Data dt = new Data();
        public FrmDangNhap()
        {
            InitializeComponent();
        }
        public Image toImages(byte[] data)
        {
            if (data == null)
            {
                return null;
            }
            else
            {
                using (MemoryStream ms = new MemoryStream(data))
                {
                    return Image.FromStream(ms);
                }
            }
        }
        private void FrmDangNhap_Load(object sender, EventArgs e)
        {
            txtMK.UseSystemPasswordChar = true;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            if (txtTenTK.Text == "" || txtMK.Text == "")
            {
                MessageBox.Show("Không được để trống");
            }
            else
            {
                if (dt.dangnhap(txtTenTK.Text, txtMK.Text) == 1)
                {                 
                    FrmHome home = new FrmHome();
                    home.bunifuLabel9.Text = dt.checkQuyen(txtTenTK.Text);
                    home.bunifuLabel2.Text = dt.checkQuyenTen(txtTenTK.Text);
                    home.bunifuLabel3.Text = dt.checkQuyenChucVu(txtTenTK.Text);
                    home.bunifuImageButton1.Image = toImages(dt.checkIDImage(txtTenTK.Text));
                    home.bunifuImageButton1.ActiveImage = toImages(dt.checkIDImage(txtTenTK.Text));
                    home.Show();
                    this.Hide();                  
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không hợp lệ");
                }
            }
        }          
        private void bunifuCheckBox1_Click(object sender, EventArgs e)
        {
            if(cbHienPass.Checked==true)
            {
                txtMK.UseSystemPasswordChar = false;
            }    
            else
            {
                txtMK.UseSystemPasswordChar = true;
            }    
        }

        private void cbHienPass_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            
        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void txtMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuButton1_Click_1(sender, e);
            }
        }

        private void txtTenTK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuButton1_Click_1(sender, e);
            }
        }
    }
}
