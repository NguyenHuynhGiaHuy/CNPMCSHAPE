using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1caphe1.DTO;


namespace WindowsFormsApp1caphe1.DAO
{
    public class DanhmucspDAO
    {
        private static DanhmucspDAO instance;
        public static DanhmucspDAO Instance
        {
            get { if (instance == null) instance = new DanhmucspDAO(); return DanhmucspDAO.instance; }
            private set { instance = value; }
        }
        private DanhmucspDAO() { }
        public List<Danhmucsp> GetListMenuByTable(int idBan)
        {
            List<Danhmucsp> listMenu = new List<Danhmucsp>();
            String query = "SELECT SP.tenSP , CTHD.soLuong , SP.giaTien , SP.giaTien*CTHD.soLuong as[thanhTien] from ChiTietHoaDon as CTHD, HoaDon as HD, SanPham as SP WHERE CTHD.idHD = HD.idHD and CTHD.id = SP.id and HD.ghiChu = 0 and  HD.idBan = "+idBan;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows) 
            {
                Danhmucsp danhmucsp = new Danhmucsp(item);
                listMenu.Add(danhmucsp);
            }
            return listMenu;
        }
    }
}
