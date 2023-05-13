using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1caphe1.DTO
{
    public class SanPham
    {
        int id;
        int idloaiSP;
        String tenSP;
        float giaTien;
        String donViTinh;
        public SanPham(int id,int idloaiSP, String tenSP,float giaTien, String donViTinh)
        {
            this.Id = id;
            this.IdloaiSP = idloaiSP;
            this.TenSP = tenSP;
            this.GiaTien = giaTien;
            this.DonViTinh = donViTinh;

        }

        public string TenSP { get => tenSP; set => tenSP = value; }
        public int Id { get => id; set => id = value; }
        public int IdloaiSP { get => idloaiSP; set => idloaiSP = value; }
        public float GiaTien { get => giaTien; set => giaTien = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }

        public SanPham(DataRow row )
        {
            this.Id = (int)row["id"];
            this.IdloaiSP = (int)row["idloaiSP"];
            this.TenSP = row["tenSP"].ToString();
            this.GiaTien = (float)Convert.ToDouble(row["giaTien"].ToString());
            this.DonViTinh = row["donViTinh"].ToString();

        }

    }
}
 