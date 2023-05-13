using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1caphe1.DTO
{
    public class TaiKhoan
    {
        String tenNV;
        String tenDangnhap;
        String chucVu;
        int matKhau;

        public TaiKhoan(string tenNV, string tenDangnhap, string chucVu, int matKhau)
        {
            TenNV = tenNV;
            TenDangnhap = tenDangnhap;
            ChucVu = chucVu;
            MatKhau = matKhau;

        }



        public string TenNV { get => tenNV; set => tenNV = value; }
        public string TenDangnhap { get => tenDangnhap; set => tenDangnhap = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public int MatKhau { get => matKhau; set => matKhau = value; }
    }

}
