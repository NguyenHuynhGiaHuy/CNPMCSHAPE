using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1caphe1.DTO;

namespace WindowsFormsApp1caphe1.DAO
{
    public class LoaiSPDAO
    {
        private static LoaiSPDAO instance;
        public static LoaiSPDAO Instance
        {
            get { if (instance == null) instance = new LoaiSPDAO(); return LoaiSPDAO.instance; }
            private set { instance = value; }
        }
        private LoaiSPDAO() { }
        public List<LoaiSP> GetDanhmucsp()
        {
            List<LoaiSP> listloaiSP = new List<LoaiSP>();
            String query = "select * from LoaiSanPham";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                LoaiSP loaiSP = new LoaiSP(item);
                listloaiSP.Add(loaiSP);
            }
            return listloaiSP;
        }
        public LoaiSP GetloaispByID(int id)
        {
            LoaiSP loaisp = null;

            string query = "select * from LoaiSanPham where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                loaisp = new LoaiSP(item);
                return loaisp;
            }

            return loaisp;
        }
    }
}
