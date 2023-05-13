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
    internal class NhanVienDAO
    {
        private static NhanVienDAO instance;
        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return NhanVienDAO.instance; }
            private set { NhanVienDAO.instance = value; }

        }


        public List<NhanVien> GetListNhanVien()
        {
            List<NhanVien> list = new List<NhanVien>();

            string query = "SELECT * FROM NhanVien";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhanVien nhanvien = new NhanVien(item);
                list.Add(nhanvien);
            }

            return list;
        }

        public bool ThemNhanVien(String tenNV , String gioiTinh , String chucVu, int namSinh, float luong)
        {
            string query = string.Format("Insert NhanVien ( tenNV, gioiTinh, chucVu, namSinh, luong) values  (  N'{0}', N'{1}' , N'{2}', {3}, {4})", tenNV, gioiTinh, chucVu, namSinh, luong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool SuaNV(int idNV, String tenNV, String gioiTinh, String chucVu, int namSinh, float luong)
        {
            string query = string.Format(" update NhanVien set  tenNV = N'{0}', gioiTinh = N'{1}', chucVu = N'{2}', namSinh = '{3}' , luong = {4} where idNV = {5} ", tenNV, gioiTinh, chucVu,  namSinh,  luong, idNV );
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool XoaNV(int idNV)
        {
            string query = string.Format("Delete NhanVien  where idNV = {0}", idNV);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public List<NhanVien> Timkiemnv(string tenNV)
        {
            List<NhanVien> list = new List<NhanVien>();

            string query = string.Format("select * from NhanVien where tenNV like N'%{0}%'", tenNV);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhanVien nv = new NhanVien(item);
                list.Add(nv);
            }

            return list;
        }

    }
}
