using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1caphe1.DTO
{
    public class LoaiSP
    {
        int id;
        String tenLoaiSanPham;
        public LoaiSP(int id, string tenLoaiSanPham)
        {
            this.Id = id;
            this.TenLoaiSanPham = tenLoaiSanPham;

        }

        public LoaiSP(DataRow row)
        {
            this.Id = (int)row["id"];
            this.TenLoaiSanPham = row["tenLoaiSanPham"].ToString();
            
        }

        public int Id { get => id; set => id = value; }
        public string TenLoaiSanPham { get => tenLoaiSanPham; set => tenLoaiSanPham = value; }
    }
}
