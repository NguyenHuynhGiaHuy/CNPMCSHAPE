using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1caphe1.DTO
{
    public class NhanVien
    {
        int idNV;
        String tenNV;
        String tenDangnhap;
        String gioiTinh;
        int  namSinh;
        String chucVu;
        float luong;
        String matKhau;
        //Image image;
        public NhanVien(int idNV, string tenNV, string tenDangnhap, int namSinh)
        {
            this.IdNV = idNV;
            this.TenNV = tenNV;
            this.TenDangnhap = tenDangnhap;
            this.NamSinh = namSinh;
        }
        public NhanVien(DataRow row)
        {
            this.IdNV = (int)row["idNV"];
            this.TenNV = row["tenNV"].ToString();
            this.GioiTinh = row["gioiTinh"].ToString();
            this.ChucVu = row["chucVu"].ToString();
            this.NamSinh = (int)row["namSinh"];
            this.MatKhau = row["matKhau"].ToString();
            this.Luong = (float)Convert.ToDouble(row["luong"].ToString());
        }

        public string TenNV { get => tenNV; set => tenNV = value; }
        public string TenDangnhap { get => tenDangnhap; set => tenDangnhap = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public int NamSinh { get => namSinh; set => namSinh = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public float Luong { get => luong; set => luong = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        //public Image Image { get => image; set => image = value; }
        public int IdNV { get => idNV; set => idNV = value; }

        public NhanVien()
        {
        }
    }
}
