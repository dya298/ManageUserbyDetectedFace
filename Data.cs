using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MultiFaceRec
{
    public class Data
    {
        DatabaseDataContext data = new DatabaseDataContext();
        public double loadData_notjoinKHA()
        {
            return data.DANCUs.Where(s => !data.RAVAO_HINHs.Where(es => es.IDDANCU == s.MADCU).Any()).Count();
        }
        public int checkHA(string ID)
        {
            var check = data.RAVAO_HINHs.Where(s => s.IDDANCU == ID).FirstOrDefault();
            if (data.RAVAO_HINHs.Contains(check))
            {
                return 1;
            }
            return 0;
        }
        public IQueryable loadBang()
        {
            return (from c in data.DANCUs
                    select new
                    {
                        c.MADCU,
                        c.TENCUDAN,
                        c.MAPHONG,
                    });
        }
        public IQueryable loadTaiKhoan()
        {
            return from c in data.RAVAO_TAIKHOANs select new { c.TENDN, c.MATKHAU, c.HOTEN, c.NGAYSINH, c.GIOITINH, c.CMND, c.SDT, c.DIACHI, c.CHUCVU, c.HINHANH };
        }
        public byte[] checkIDImage(string name)
        {
            var id = (from c in data.RAVAO_TAIKHOANs where c.TENDN == name select c).First();
            if (id.HINHANH != null)
            {
                return id.HINHANH.ToArray();
            }
            return null;
        }
        //Hien thi phong cua cu dan
        public string hienthiphong(string ID)
        {
            var ten = data.DANCUs.Where(s => s.MADCU == ID).FirstOrDefault();
            return ten.MAPHONG.ToString();
        }

        //Hien thi ten
        public string hienthiten(string ID)
        {
                var ten = data.DANCUs.Where(s => s.MADCU == ID).FirstOrDefault();
                return ten.TENCUDAN.ToString();
        }
        //Thêm table HINHANH
        public void themHA(string tenhinh, string id)
        {
            RAVAO_HINH kh = new RAVAO_HINH();
            kh.TENHINH = tenhinh;
            kh.IDDANCU = id;
            data.RAVAO_HINHs.InsertOnSubmit(kh);
            data.SubmitChanges();
        }
        public void xoaHA(int id)
        {
            RAVAO_HINH kh = data.RAVAO_HINHs.Where(k => k.IDHINH == id).FirstOrDefault();
            if (kh != null)
            {
                data.RAVAO_HINHs.DeleteOnSubmit(kh);
                data.SubmitChanges();
            }
        }
        //Trả tên table DANCU từ mã id
        public string tenDancu(string id)
        {
            var dt = data.DANCUs.Where(kh => kh.MADCU == id).FirstOrDefault();
            if (data.DANCUs.Contains(dt))
            {
                return dt.TENCUDAN;
            }
            return " ";
        }
        //

        public double tongDancu()
        {
            return data.DANCUs.Select(kh => kh.MADCU).Count();
        }
        //public int loadDanCuNhom()
        //{
        //    return data.DANCUs.Where(s => data.LIETKENGUOITHANs.Where(es => es.IDDANCU == s.IDDANCU).Any()).Count();
        //}
        public int loadDanCuIn()
        {
            return data.DANCUs.Where(kh => kh.TRANGTHAI == true).Count();
        }
        public int demNguoiLa()
        {
            return data.RAVAO_LAMATs.Count();
        }
        public int loadDanCuOut()
        {
            return data.DANCUs.Where(kh => kh.TRANGTHAI == false).Count();
        }

        public int checktrongchungcu(string ten)
        {
            var mk = data.DANCUs.Where(s => data.RAVAO_HINHs.Where(es => es.IDDANCU == s.MADCU).Any())
               .Where(kh => kh.TRANGTHAI == true).Where(k => k.MADCU == ten).FirstOrDefault();
            if (data.DANCUs.Contains(mk))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        //
        public int checkrachungcu(string ten)
        {
            var mk = data.DANCUs.Where(s => data.RAVAO_HINHs.Where(es => es.IDDANCU == s.MADCU).Any())
               .Where(kh => kh.TRANGTHAI == false).Where(k => k.MADCU == ten).FirstOrDefault();
            if (data.DANCUs.Contains(mk))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        // LOAD LỊCH SỬ RA VÀO
        public IQueryable lichsuDanCu(string id)
        {
            return from c in data.RAVAO_LICHSUs where (c.IDDANCU == id) select new { c.THOIGIAN, c.CAMERA };
        }
        public void capnhatVao(string ten)
        {
            DANCU dANCU = data.DANCUs.Where(k => k.MADCU == ten).FirstOrDefault();
            if (dANCU != null)
            {
                dANCU.TRANGTHAI = true;
                data.SubmitChanges();
            }
        }
        public void capnhatRa(string ten)
        {
            DANCU dANCU = data.DANCUs.Where(k => k.MADCU == ten).FirstOrDefault();
            if (dANCU != null)
            {
                dANCU.TRANGTHAI = false;
                data.SubmitChanges();
            }
        }
        public void themLichSu(string id, string camera)
        {
            RAVAO_LICHSU lICHSURAVAO = new RAVAO_LICHSU();
            lICHSURAVAO.IDDANCU = id;
            lICHSURAVAO.THOIGIAN = DateTime.Now;
            lICHSURAVAO.CAMERA = camera;
            data.RAVAO_LICHSUs.InsertOnSubmit(lICHSURAVAO);
            data.SubmitChanges();
        }
        public void themTK(string tentk, string matkhau, string hoten, DateTime ns, string gt,
            string cmnd, string sdt, string diachi, string chucvu, string pq, System.Data.Linq.Binary hinhanh)
        {
            RAVAO_TAIKHOAN tk = new RAVAO_TAIKHOAN();
            tk.TENDN = tentk;
            tk.MATKHAU = matkhau;
            tk.HOTEN = hoten;
            tk.NGAYSINH = ns;
            tk.GIOITINH = gt;
            tk.CMND = cmnd;
            tk.SDT = sdt;
            tk.DIACHI = diachi;
            tk.CHUCVU = chucvu;
            tk.QUYEN = pq;
            tk.HINHANH = hinhanh;
            data.RAVAO_TAIKHOANs.InsertOnSubmit(tk);
            data.SubmitChanges();
        }
        public void xoaTK(string tendn)
        {
            var id = data.RAVAO_TAIKHOANs.Where(s => s.TENDN == tendn).FirstOrDefault();
            if (id != null)
            {
                data.RAVAO_TAIKHOANs.DeleteOnSubmit(id);
                data.SubmitChanges();
            }
        }
        public void suaTK(string tentk, string matkhau, string hoten, DateTime ns, string gt,
            string cmnd, string sdt, string diachi, string chucvu, string pq, System.Data.Linq.Binary hinhanh)
        {
            var tk = data.RAVAO_TAIKHOANs.Where(s => s.TENDN == tentk).FirstOrDefault();
            if (tk != null)
            {
                tk.TENDN = tentk;
                tk.MATKHAU = matkhau;
                tk.HOTEN = hoten;
                tk.NGAYSINH = ns;
                tk.GIOITINH = gt;
                tk.CMND = cmnd;
                tk.SDT = sdt;
                tk.DIACHI = diachi;
                tk.CHUCVU = chucvu;
                tk.QUYEN = pq;
                tk.HINHANH = hinhanh;
                data.SubmitChanges();
            }
        }
        public int checkTK(string tendn)
        {
            var id = data.RAVAO_TAIKHOANs.Where(s => s.TENDN == tendn).FirstOrDefault();
            if (data.RAVAO_TAIKHOANs.Contains(id))
            {
                return 1;
            }
            return 0;
        }

        public void themLaMat(string hinh, string camera)
        {
            DateTime now = DateTime.Now;
            string asString = now.ToString("dd/MM/yyyy hh:mm:ss tt");
            RAVAO_LAMAT lamat = new RAVAO_LAMAT();
            lamat.HINH = hinh;
            lamat.THOIDIEM = asString;
            lamat.CAMERA = camera;
            data.RAVAO_LAMATs.InsertOnSubmit(lamat);
            data.SubmitChanges();
        }

        public int demlamat()
        {

            int solamat = data.RAVAO_LAMATs.Count();
            return solamat;
        }

        public void thoiluongRAVAO(string id)
        {
            DateTime datenow = DateTime.Now;
            DateTime date = new DateTime(datenow.Year, datenow.Month,
                datenow.Day, datenow.Hour, datenow.Minute, datenow.Second);
            //
            RAVAO_THOILUONG tl = new RAVAO_THOILUONG();
            tl.ID_DANCU = id;
            tl.LANTHU = 0;
            tl.NGAYHIENTAI = date.Date;
            tl.GIORA = date.TimeOfDay;
            data.RAVAO_THOILUONGs.InsertOnSubmit(tl);
            data.SubmitChanges();
        }
        DateTime datenow = DateTime.Now;
        public int solan(string id)
        {
            if (checkNgay() == 1)
            {
                var maxSolan = (data.RAVAO_THOILUONGs.Where(q => q.ID_DANCU == id && q.NGAYHIENTAI == datenow).Where(q => q.LANTHU >= 0).Max(q => q.LANTHU));
                return int.Parse(maxSolan.ToString());
            }
            return 0;
        }
        public int checkNgay()
        {
            var key = data.RAVAO_THOILUONGs.Where(kh => kh.NGAYHIENTAI == datenow).FirstOrDefault();
            if (data.RAVAO_THOILUONGs.Contains(key))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void capnhatTL(string id)
        {
            DateTime datenow = DateTime.Now;
            DateTime date = new DateTime(datenow.Year, datenow.Month,
                datenow.Day, datenow.Hour, datenow.Minute, datenow.Second);
            RAVAO_THOILUONG tl = data.RAVAO_THOILUONGs.Where(k => k.ID_DANCU == id && k.NGAYHIENTAI == date).Where(q => q.LANTHU == 0).FirstOrDefault();
            if (tl != null)
            {
                tl.LANTHU = solan(id) + 1;
                tl.GIOVAO = date.TimeOfDay;
                data.SubmitChanges();
            }

        }
        public IQueryable lichsuravaofilter(string id, DateTime dt)
        {
            return from c in data.RAVAO_LICHSUs where (c.IDDANCU == id) where (c.THOIGIAN.Date == dt) select new { c.THOIGIAN, c.CAMERA };
        }

        public IQueryable thoiluongfilter(string id, DateTime dt)
        {
            return from c in data.RAVAO_THOILUONGs where (c.ID_DANCU == id) where (c.NGAYHIENTAI == dt.Date) select new { c.GIORA, c.GIOVAO, c.LANTHU };
        }
        public int dangnhap(string ttk, string mk)
        {
            var tentaikhoan = data.RAVAO_TAIKHOANs.Where(tk => tk.TENDN == ttk).FirstOrDefault();
            var matkhau = data.RAVAO_TAIKHOANs.Where(tk => tk.MATKHAU == mk).FirstOrDefault();
            var matkhau1 = data.RAVAO_TAIKHOANs.Where(tk => tk.MATKHAU == mk).Where(kh => kh.TENDN == ttk).FirstOrDefault();
            if ((data.RAVAO_TAIKHOANs.Contains(tentaikhoan) && data.RAVAO_TAIKHOANs.Contains(matkhau)))
            {
                if (data.RAVAO_TAIKHOANs.Contains(matkhau1))
                {
                    return 1;
                }
            }
            return 0;
        }
        public string checkQuyen(string ten)
        {

            var dt = data.RAVAO_TAIKHOANs.Where(kh => kh.TENDN == ten).FirstOrDefault();
            if (data.RAVAO_TAIKHOANs.Contains(dt))
            {
                return dt.QUYEN;
            }
            return " ";
        }
        public string checkQuyenTen(string ten)
        {

            var dt = data.RAVAO_TAIKHOANs.Where(kh => kh.TENDN == ten).FirstOrDefault();
            if (data.RAVAO_TAIKHOANs.Contains(dt))
            {
                return dt.HOTEN;
            }
            return " ";
        }
        public string checkQuyenChucVu(string ten)
        {
            var dt = data.RAVAO_TAIKHOANs.Where(kh => kh.TENDN == ten).FirstOrDefault();
            if (data.RAVAO_TAIKHOANs.Contains(dt))
            {
                return dt.CHUCVU;
            }
            return " ";
        }
        public IQueryable loadHinh(string id)
        {
            return from c in data.RAVAO_HINHs where (c.IDDANCU == id) select new { c.IDDANCU, c.TENHINH, c.IDHINH };
        }
        public IQueryable date()
        {
            return (from c in data.RAVAO_THOILUONGs select new { c.NGAYHIENTAI }.NGAYHIENTAI).Distinct();
        }

        public void LoadLaMat(DataGridView dgv, RadioButton rd1, RadioButton rd2, DateTimePicker dtpick)
        {
            string date = "";
            if (rd1.Checked)
            {
                date = "";
            }
            else
            {
                date = "";
                date += dtpick.Value.Day.ToString();
                date += "/" + dtpick.Value.Month.ToString();
                date += "/" + dtpick.Value.Year.ToString();
            }
            var lamat = from la in data.RAVAO_LAMATs where la.THOIDIEM.Contains(date) select la;
            dgv.DataSource = lamat;
        }
        public IQueryable loadCBDcu()
        {
            return data.DANCUs.Where(s => data.RAVAO_THOILUONGs.Where(es => es.ID_DANCU == s.MADCU).Any()).Select(s => s);
        }
        //
        public int thongkeHD(string id, DateTime date)
        {
            var maxSolan = (data.RAVAO_THOILUONGs.Where(q => q.ID_DANCU == id).Where(q => q.NGAYHIENTAI == date).Where(q => q.LANTHU > 0).Max(q => q.LANTHU));
            if (maxSolan != null)
            {
                return int.Parse(maxSolan.ToString());
            }
            else
            {
                return 0;
            }
        }
        public IQueryable coHA(string ten)
        {
            if (ten == String.Empty)
            {
                return (from c in data.DANCUs
                        from d in data.RAVAO_HINHs
                        where (c.MADCU == d.IDDANCU)
                        select new
                        {
                            c.MADCU,
                            c.TENCUDAN,
                            c.MAPHONG,
                        }).Distinct();
            }
            else
            {
                return (from c in data.DANCUs
                        from d in data.RAVAO_HINHs
                        where (c.MADCU == d.IDDANCU)
                        where (c.TENCUDAN.Contains(ten))
                        select new
                        {
                            c.MADCU,
                            c.TENCUDAN,
                            c.MAPHONG,
                        }).Distinct();
            }
        }
        public IQueryable khongHA(string ten)
        {
            if (ten == String.Empty)
            {
                //return (from c in data.RAVAO_HINHs join
                //         d in data.DANCUs on
                //         c.IDDANCU equals d.MADCU
                //        select new
                //        {
                //            d.MADCU,
                //            d.TENCUDAN,
                //            d.MAPHONG,
                //        });
                return data.DANCUs.Where(s => !data.RAVAO_HINHs.Where(es => es.IDDANCU == s.MADCU).Any()).Select(k=> new { k.MADCU,k.TENCUDAN,k.MAPHONG});            
            }
            else
            {
                //return (from c in data.DANCUs
                //        from d in data.RAVAO_HINHs
                //        where (c.MADCU != d.IDDANCU)
                //        where (c.TENCUDAN.Contains(ten))
                //        select new
                //        {
                //            c.MADCU,
                //            c.TENCUDAN,
                //            c.MAPHONG,
                //        }).Distinct();
                return data.DANCUs.Where(s => !data.RAVAO_HINHs.Where(es => es.IDDANCU == s.MADCU).Any()).
                    Where(k => k.TENCUDAN.Contains(ten)).Select(k => new { k.MADCU, k.TENCUDAN, k.MAPHONG });
            }
        }
        public void updateCamTat1(int id)
        {
            RAVAO_TRANGTHAICAMERA tt = data.RAVAO_TRANGTHAICAMERAs.Where(k => k.ID == id).FirstOrDefault();
            if (tt != null)
            {
                tt.TRANGTHAI = 1;
                data.SubmitChanges();
            }
        }
        public void updateCamTat0(int id)
        {
            RAVAO_TRANGTHAICAMERA tt = data.RAVAO_TRANGTHAICAMERAs.Where(k => k.ID == id).FirstOrDefault();
            if (tt != null)
            {
                tt.TRANGTHAI = 0;
                data.SubmitChanges();
            }
        }
        public int ttRa()
        {
            var key = data.RAVAO_TRANGTHAICAMERAs.Where(kh => kh.TRANGTHAI == 1 && kh.ID==1).FirstOrDefault();
            if (data.RAVAO_TRANGTHAICAMERAs.Contains(key))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int ttVao()
        {
            var key = data.RAVAO_TRANGTHAICAMERAs.Where(kh => kh.TRANGTHAI == 1 && kh.ID == 2).FirstOrDefault();
            if (data.RAVAO_TRANGTHAICAMERAs.Contains(key))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
