using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1caphe1.DTO
{
    public class Table
    {

        int idBan;
        String tenBan;
        String loai;
        String tinhTrangBan;
        public Table(int idBan, string tenBan, string loai, string tinhTrangBan)
        {
            this.IdBan = idBan;
            this.TenBan = tenBan;
            this.Loai = loai;
            this.TinhTrangBan = tinhTrangBan;
        }

        public int IdBan { get => idBan; set => idBan = value; }
        public string TenBan { get => tenBan; set => tenBan = value; }
        public string Loai { get => loai; set => loai = value; }
        public string TinhTrangBan { get => tinhTrangBan; set => tinhTrangBan = value; }

        public Table()
        {

        }
        public Table(DataRow row)
        {
            this.IdBan = (int)row["idBan"];
            this.TenBan = row["tenBan"].ToString();
            this.Loai = row["loai"].ToString();
            this.TinhTrangBan = row["tinhTrangBan"].ToString();

        }
    }
}
