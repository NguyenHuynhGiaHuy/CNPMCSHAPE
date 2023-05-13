using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1caphe1.DTO
{
    public class HoaDon
    {
        private int idHD;
        private int idBan;
        private DateTime? ngayVao;
        private DateTime? ngayRa;
        private int ghiChu;
        private int giamGia;
        private float tongTien;
        public HoaDon(int idHD, DateTime? ngayVao, DateTime? ngayRa, int ghiChu, int giamGia = 0)
        {
            this.IdHD = idHD;
            this.NgayVao = (DateTime)ngayVao; 
            this.NgayRa = (DateTime)ngayRa;
            this.GhiChu = ghiChu;
            //this.TongTien = float(tongTien);
            ListMenu = new List<Danhmucsp>();
        }
        public HoaDon(DataRow row)
        {
            this.IdHD = (int)row["idHD"];
            this.NgayVao = (DateTime)(DateTime?)row["ngayVao"];
            var ngayRaTemp = row["ngayRa"];
            if (ngayRaTemp.ToString() != "")
                this.NgayRa = (DateTime)(DateTime?)ngayRaTemp;
            this.GhiChu = GhiChu;
            this.GiamGia = (int)row["giamGia"];
        }
        public List<Danhmucsp> ListMenu { get; set; }
        public int IdBan { get => idBan; set => idBan = value; }
        public int IdHD { get => idHD; set => idHD = value; }
        public DateTime? NgayVao { get => ngayVao; set => ngayVao = value; }
        public DateTime? NgayRa { get => ngayRa; set => ngayRa = value; }
        public int GhiChu { get => ghiChu; set => ghiChu = value; }
        public int GiamGia { get => giamGia; set => giamGia = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }

        public HoaDon()
        {
        }
    }
}
