using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1caphe1.DAO;
using WindowsFormsApp1caphe1.DTO;

namespace WindowsFormsApp1caphe1
{
    public partial class frmQuanly : Form
    {
        SqlConnection cn = new SqlConnection();
        BindingSource sp = new BindingSource();
        BindingSource ban = new BindingSource();
        BindingSource nhanvien = new BindingSource();
        public frmQuanly()
        {
            InitializeComponent();
            LoadAll();

        }

        void LoadAll()
        {
            dataGridViewSanpham.DataSource = sp;
            dataGridViewBan.DataSource = ban;
            dataGridViewNhanvien.DataSource = nhanvien;
            LoadTaikhoan();
            loadNV();
            LoadLoaisp();
            Loadsp();
            Bingdingsp();
            LoadBan();
            Bingdingban();
            Bingdingnhanvien();
            BingdingTaikhoan();

        }

        // Taikkhoan 
        void LoadTaikhoan()
        {
            string strQuery = "Select tenDangnhap as [Tên đăng nhập], matKhau as [Mật khẩu], tenNV as [Tên hiển thị], chucVu as [Quyền] from NhanVien";

            dataGridViewTaikhoan.DataSource = DataProvider.Instance.ExecuteQuery(strQuery);
        }
        void BingdingTaikhoan()
        {

            txttendn.DataBindings.Clear();
            txttendn.DataBindings.Add("Text", dataGridViewTaikhoan.DataSource, "Tên đăng nhập", true, DataSourceUpdateMode.Never);

            txtquyen.DataBindings.Clear();
            txtquyen.DataBindings.Add("Text", dataGridViewTaikhoan.DataSource, "Quyền", true, DataSourceUpdateMode.Never);


            txttenhthi.DataBindings.Clear();
            txttenhthi.DataBindings.Add("Text", dataGridViewTaikhoan.DataSource, "Tên hiển thị", true, DataSourceUpdateMode.Never);

            txtmk.DataBindings.Clear();
            txtmk.DataBindings.Add("Text", dataGridViewTaikhoan.DataSource, "Mật khẩu", true, DataSourceUpdateMode.Never);


        }
        private void btn_xemtk_Click(object sender, EventArgs e)
        {
            LoadTaikhoan();
        }
        // Tai khoan 

        private void frmQuanly_Load_1(object sender, EventArgs e)
        {
            String strCon;
            strCon = ConfigurationManager.ConnectionStrings["QLCAPHE"].ConnectionString;
            cn.ConnectionString = strCon;

        }
        // San pham 
        void LoadLoaisp()
        {
            List<LoaiSP> listloaiSP = LoaiSPDAO.Instance.GetDanhmucsp();
            cmbloaisp.DataSource = listloaiSP;
            cmbloaisp.DisplayMember = "tenLoaiSanPham";
        }
        void Loadsp()
        {

            sp.DataSource = SanPhamDAO.Instance.GetListFood();

        }
        void Bingdingsp()
        {
            txtMsp.DataBindings.Clear();
            txtMsp.DataBindings.Add(new Binding("Text", dataGridViewSanpham.DataSource, "id", true, DataSourceUpdateMode.Never));

            txtTensp.DataBindings.Clear();
            txtTensp.DataBindings.Add(new Binding("Text", dataGridViewSanpham.DataSource, "tenSP", true, DataSourceUpdateMode.Never));


            txtGia.DataBindings.Clear();
            Binding binding = new Binding("Text", dataGridViewSanpham.DataSource, "giaTien", true, DataSourceUpdateMode.Never);
            binding.Format += (s, e) =>
            {
                e.Value = ((float)e.Value).ToString("N0");
            };
            txtGia.DataBindings.Add(binding);

            txtDVT.DataBindings.Clear();
            txtDVT.DataBindings.Add(new Binding("Text", dataGridViewSanpham.DataSource, "donViTinh", true, DataSourceUpdateMode.Never));
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            Loadsp();
        }

        private void txtMsp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSanpham.SelectedCells.Count > 0)
                {
                    int id = (int)dataGridViewSanpham.SelectedCells[0].OwningRow.Cells["IdloaiSP"].Value;
                    // lấy loaisp ra 
                    LoaiSP loaiSP = LoaiSPDAO.Instance.GetloaispByID(id);

                    cmbloaisp.SelectedItem = loaiSP;

                    int index = -1;
                    int i = 0;
                    foreach (LoaiSP item in cmbloaisp.Items)
                    {
                        if (item.Id == loaiSP.Id)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cmbloaisp.SelectedIndex = index;
                }
            }
            catch { }


        }
        private void btnThem1_Click(object sender, EventArgs e)
        {
            int idloaiSP = (cmbloaisp.SelectedItem as LoaiSP).Id;
            string tenSP = txtTensp.Text;
            float giaTien = float.Parse(txtGia.Text);
            string donViTinh = txtDVT.Text;
            if (SanPhamDAO.Instance.ThemSP(idloaiSP, tenSP, giaTien, donViTinh))
            {
                MessageBox.Show("Thêm món thành công!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                LoadLoaisp();
                if (themSP != null)
                {
                    themSP(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Thêm món thất bại!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            Loadsp();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            int idloaiSP = (cmbloaisp.SelectedItem as LoaiSP).Id;
            string tenSP = txtTensp.Text;
            float giaTien = float.Parse(txtGia.Text);
            string donViTinh = txtDVT.Text;
            int id = Convert.ToInt32(txtMsp.Text);
            if (SanPhamDAO.Instance.SuaSP(id, idloaiSP, tenSP, giaTien, donViTinh))
            {
                MessageBox.Show("Sửa món thành công!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                LoadLoaisp();
                if (suaSP != null)
                {
                    suaSP(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Sửa món thất bại!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            Loadsp();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            int idloaiSP = (cmbloaisp.SelectedItem as LoaiSP).Id;
            string tenSP = txtTensp.Text;
            float giaTien = float.Parse(txtGia.Text);
            string donViTinh = txtDVT.Text;
            int id = Convert.ToInt32(txtMsp.Text);
            if (SanPhamDAO.Instance.XoaSP(id))
            {
                MessageBox.Show("Xóa món thành công!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                LoadLoaisp();
                if (xoaSP != null)
                {
                    xoaSP(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Xóa món thất bại!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            }
            Loadsp();
        }
        private event EventHandler themSP;
        public event EventHandler ThemSP
        {
            add { themSP += value; }
            remove { themSP -= value; }
        }

        private event EventHandler xoaSP;
        public event EventHandler XoaSP
        {
            add { xoaSP += value; }
            remove { xoaSP -= value; }
        }

        private event EventHandler suaSP;
        public event EventHandler SuaSP
        {
            add { suaSP += value; }
            remove { suaSP -= value; }
        }
        List<SanPham> TimkiemSP(string tenSP)
        {
            List<SanPham> sanPhams = new List<SanPham>();
            sanPhams = SanPhamDAO.Instance.TimkiemSP(tenSP);
            return sanPhams;
        }
        private void btnTimsp_Click(object sender, EventArgs e)
        {
            sp.DataSource = TimkiemSP(txtfindTensp.Text);
        }

        //San pham 

        // Ban 
        void LoadBan()
        {
            ban.DataSource = BanDAO.Instance.GetListBan();
        }
        void Bingdingban()
        {
            txtIDBAN.DataBindings.Clear();
            txtIDBAN.DataBindings.Add(new Binding("Text", dataGridViewBan.DataSource, "IdBan", true, DataSourceUpdateMode.Never));

            txttenban.DataBindings.Clear();
            txttenban.DataBindings.Add(new Binding("Text", dataGridViewBan.DataSource, "TenBan", true, DataSourceUpdateMode.Never));

            txtLoaiban.DataBindings.Clear();
            txtLoaiban.DataBindings.Add(new Binding("Text", dataGridViewBan.DataSource, "Loai", true, DataSourceUpdateMode.Never));

            txtTinhtrang.DataBindings.Clear();
            txtTinhtrang.DataBindings.Add(new Binding("Text", dataGridViewBan.DataSource, "TinhTrangBan", true, DataSourceUpdateMode.Never));
        }

        private void btnxemtt_Click(object sender, EventArgs e)
        {
            LoadBan();
        }

        private void btnthemban_Click(object sender, EventArgs e)
        {
            string tenBan = txttenban.Text;
            string loai = txtLoaiban.Text;
            string tinhTrangBan = txtTinhtrang.Text;
            if (BanDAO.Instance.ThemBan(tenBan, loai, tinhTrangBan))
            {
                MessageBox.Show("Thêm bàn thành công!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Thêm bàn thất bại!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            LoadBan();
        }
        private void btnsuaban_Click(object sender, EventArgs e)
        {
            string tenBan = txttenban.Text;
            string loai = txtLoaiban.Text;
            string tinhTrangBan = txtTinhtrang.Text;
            int idBan = Convert.ToInt32(txtIDBAN.Text);
            if (BanDAO.Instance.SuaBan(idBan, tenBan, loai, tinhTrangBan))
            {
                MessageBox.Show("Sửa bàn thành công!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Sửa bàn thất bại!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            LoadBan();
        }
        private void btnxoaban_Click(object sender, EventArgs e)
        {
            string tenBan = txttenban.Text;
            string loai = txtLoaiban.Text;
            string tinhTrangBan = txtTinhtrang.Text;
            int idBan = Convert.ToInt32(txtIDBAN.Text);
            if (BanDAO.Instance.XoaBan(idBan))
            {
                MessageBox.Show("Xóa bàn thành công!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Xóa bàn thất bại!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            LoadBan();
        }
        List<Table> Timkiemban(string tenBan)
        {
            List<Table> sanPhams = new List<Table>();
            sanPhams = BanDAO.Instance.Timkiemban(tenBan);
            return sanPhams;
        }
        private void btntimban_Click(object sender, EventArgs e)
        {
            ban.DataSource = Timkiemban(txttimban.Text);
        }

        // Ban 

        //Nhan vien 
        void loadNV()
        {

            nhanvien.DataSource = NhanVienDAO.Instance.GetListNhanVien();
        }
        void Bingdingnhanvien()
        {
            txtManv.DataBindings.Clear();
            txtManv.DataBindings.Add(new Binding("Text", dataGridViewNhanvien.DataSource, "IdNV", true, DataSourceUpdateMode.Never));

            txtTennv.DataBindings.Clear();
            txtTennv.DataBindings.Add(new Binding("Text", dataGridViewNhanvien.DataSource, "TenNV", true, DataSourceUpdateMode.Never));

            txtngaysinh.DataBindings.Clear();
            txtngaysinh.DataBindings.Add(new Binding("Text", dataGridViewNhanvien.DataSource, "NamSinh", true, DataSourceUpdateMode.Never));

            txtChucvu.DataBindings.Clear();
            txtChucvu.DataBindings.Add(new Binding("Text", dataGridViewNhanvien.DataSource, "ChucVu", true, DataSourceUpdateMode.Never));
            // định dạng một chuỗi có dấu phân cách hàng nghìn và không có chữ số thập phân bằng cách sử dụng chuỗi định dạng "N0".
            // txtLuong.DataBindings.Clear();
            Binding binding = new Binding("Text", dataGridViewNhanvien.DataSource, "Luong", true, DataSourceUpdateMode.Never);
            binding.Format += (s, e) =>
            {
                e.Value = ((float)e.Value).ToString("N0");
            };
            txtLuong.DataBindings.Add(binding);

            txtGioitinh.DataBindings.Clear();
            txtGioitinh.DataBindings.Add(new Binding("Text", dataGridViewNhanvien.DataSource, "GioiTinh", true, DataSourceUpdateMode.Never));

            txtMatkhau.DataBindings.Clear();
            txtMatkhau.DataBindings.Add(new Binding("Text", dataGridViewNhanvien.DataSource, "MatKhau", true, DataSourceUpdateMode.Never));


        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string tenNV = txtTennv.Text;
            string gioiTinh = txtGioitinh.Text;
            string chucVu = txtChucvu.Text;
            int namSinh = int.Parse(txtngaysinh.Text);
            float luong = float.Parse(txtLuong.Text);



            if (NhanVienDAO.Instance.ThemNhanVien(tenNV, gioiTinh, chucVu, namSinh, luong))
            {
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            loadNV();
           
        }

        private void btnxemnv_Click(object sender, EventArgs e)
        {
            loadNV();
        }

        private void btnxoanv_Click(object sender, EventArgs e)
        {
            string tenNV = txtTennv.Text;
            string chucVu = txtChucvu.Text;
            int namSinh = int.Parse(txtngaysinh.Text);
            float luong = float.Parse(txtLuong.Text);
            string gioiTinh = txtGioitinh.Text;
            int idNV = Convert.ToInt32(txtManv.Text);

            if (NhanVienDAO.Instance.XoaNV(idNV))
            {
                MessageBox.Show("Xóa nhân viên thành công!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            loadNV();
        }

        private void btnsuanv_Click(object sender, EventArgs e)
        {
            int idNV = Convert.ToInt32(txtManv.Text);
            string tenNV = txtTennv.Text;
            string gioiTinh = txtGioitinh.Text;
            string chucVu = txtChucvu.Text;
            float luong = float.Parse(txtLuong.Text);
            int namSinh = int.Parse(txtngaysinh.Text);

            if (NhanVienDAO.Instance.SuaNV(idNV, tenNV, gioiTinh, chucVu, namSinh, luong))
            {
                MessageBox.Show("Sửa nhân viên thành công!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa nhân viên thất bại!", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            loadNV();
        }
        List<NhanVien> Timkiemnv(string tenNV)
        {
            List<NhanVien> nv = new List<NhanVien>();
            nv = NhanVienDAO.Instance.Timkiemnv(tenNV);
            return nv;
        }
        private void btntimkiemnv_Click(object sender, EventArgs e)
        {
            nhanvien.DataSource = Timkiemnv(txttimkiemnv.Text);
        }


        string ImgLocation = "";
        //private object reportViewer1;

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImgLocation = openFileDialog.FileName.ToString();
                pictureBox1.ImageLocation = ImgLocation;
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }




        // Nhan vien 
    }

}


   