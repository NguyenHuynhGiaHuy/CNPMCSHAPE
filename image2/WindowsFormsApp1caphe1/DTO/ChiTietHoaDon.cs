using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1caphe1.DTO
{
    public class ChiTietHoaDon
    {
        
        int idCTHD;
        int idHD;
        int id;
        int soLuong;
        String ghiChu;
        public ChiTietHoaDon(int idCTHD, int idHD, int id, int soLuong, string ghiChu)
        {
            this.IdCTHD = idCTHD;
            this.IdHD = idHD;
            this.Id = id;
            this.SoLuong = soLuong;
            this.GhiChu = ghiChu;
        }

        public int IdCTHD { get => idCTHD; set => idCTHD = value; }
        public int IdHD { get => idHD; set => idHD = value; }
        public int Id { get => id; set => id = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }

        public ChiTietHoaDon()
        {
        }
        public ChiTietHoaDon(DataRow row)
        {
            this.IdCTHD = (int)row["idCTHD"];
            this.IdHD = (int)row["idHD"];
            this.Id = (int)row["id"];
            this.SoLuong = (int)row["soLuong"];
           
        }

    }
}
