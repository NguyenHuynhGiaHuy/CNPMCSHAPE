using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1caphe1.DTO;

namespace WindowsFormsApp1caphe1.DAO
{
    public class SanPhamDAO
    {
        private static SanPhamDAO instance;
        public static SanPhamDAO Instance
        {
            get { if (instance == null) instance = new SanPhamDAO(); return SanPhamDAO.instance; }
            private set { SanPhamDAO.instance = value; }
        }
        private SanPhamDAO() { }
        public List<SanPham> GetFoodByCategoryID(int id)
        {
            List<SanPham> list = new List<SanPham>();
            String query = "SELECT * FROM SanPham where idloaiSP = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                SanPham sanPham = new SanPham(item);
                list.Add(sanPham);
            }
            return list;
        }
        public List<SanPham> GetListFood()
        {
            List<SanPham> list = new List<SanPham>();

            string query = "select * from SanPham";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                SanPham sp = new SanPham(item);
                list.Add(sp);
            }

            return list;
        }

        public bool ThemSP(int idloaiSP, String tenSP, float giaTien, String donViTinh)
        {
            string query = string.Format("Insert SanPham ( idloaiSP, tenSP, giaTien, donViTinh ) values  ( {0}, N'{1}', {2}, N'{3}')", idloaiSP, tenSP, giaTien, donViTinh);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool SuaSP(int id, int idloaiSP, String tenSP, float giaTien, String donViTinh)
        {
            string query = string.Format("update SanPham set idloaiSP = {0}, tenSP = N'{1}', giaTien = {2}, donViTinh = N'{3}' where id = {4}", idloaiSP, tenSP, giaTien, donViTinh, id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool XoaSP(int id)
        {
            ChiTietHoaDonDAO.Instance.XoaCTHDbyID(id);
            string query = string.Format("Delete SanPham where id = {0}",id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public List<SanPham> TimkiemSP(string tenSP)
        {
            List<SanPham> list = new List<SanPham>();

            string query = string.Format("select * from SanPham where tenSP like N'%{0}%'", tenSP);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                SanPham sp = new SanPham(item);
                list.Add(sp);
            }

            return list;
        }
    }
}
