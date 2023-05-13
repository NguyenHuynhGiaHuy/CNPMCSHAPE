using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApp1caphe1.DTO
{
    public class Danhmucsp
    {
        string tenSP;
        int soluong;
        float giaTien;
        float thanhTien;
        public Danhmucsp(string tenSP, int soLuong, float giaTien, float thanhTien)
        {
            this.TenSP = tenSP; 
            this.Soluong = soLuong;
            this.GiaTien = giaTien; 
            this.ThanhTien = thanhTien;
        }
        public Danhmucsp(DataRow row)
        {
            this.TenSP = row["tenSP"].ToString();
            this.Soluong = (int)row["soluong"];
            this.GiaTien = (float)Convert.ToDouble(row["giaTien"].ToString());
            this.ThanhTien = (float)Convert.ToDouble(row["thanhTien"].ToString());
        }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public float GiaTien { get => giaTien; set => giaTien = value; }
        public float ThanhTien { get => thanhTien; set => thanhTien = value; }
    }
}
