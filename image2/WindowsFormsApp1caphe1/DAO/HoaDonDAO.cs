using System;
using System.Data;
using WindowsFormsApp1caphe1.DTO;

namespace WindowsFormsApp1caphe1.DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;
        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return HoaDonDAO.instance; }
            private set { HoaDonDAO.instance = value; }
        }
        private HoaDonDAO() { }
        public int GetUncheckBillIDByTableID(int idHD)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from HoaDon where ghiChu = 0 and  idBan = " + idHD);

            if (data.Rows.Count > 0)
            {
                HoaDon bill = new HoaDon(data.Rows[0]);
                return bill.IdHD;
            }

            return -1;

        }
        public void ThemHoaDon(int idHD)
        {
            DataProvider.Instance.ExecuteNonQuery(" exec InsertHoaDon @idBan " , new object[] { idHD });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select Max(idHD) from HoaDon");
            }
            catch
            {
                return 1;
            }
        }
        public void Kiemtrahoadon(int idHD, float tongTien)
        {

            string query = "update HoaDon set ghiChu = 1, tongTien = " + tongTien + "  WHERE idHD = " + idHD;
 
            DataProvider.Instance.ExecuteNonQuery(query);

        }
        public void KiemtraNgayRa(int idHD, float tongTien )
        {
            string query= " update HoaDon set ngayRa = getdate(), ghiChu = 1, tongTien = " + tongTien + " where idHD = " + idHD;
            DataProvider.Instance.ExecuteNonQuery (query);
        }
        public DataTable GetBillListByDate(DateTime ngayVao, DateTime ngayRa)
        {
            return DataProvider.Instance.ExecuteQuery("Exec USP_GetListBillByDate @ngayVao , @ngayRa", new object[] { ngayVao, ngayRa });
        }
        public DataTable GetBillListByMonth(int thang)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillByMonth @thang", new object[] { thang });
        }
        public DataTable GetBillListByNam(int nam)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillByNam @nam", new object[] { nam });
        }

        public HoaDon GetBillById(int idHD)
        {
            string query = "SELECT * FROM HoaDon WHERE idHD = @idHD";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { idHD });

            if (data.Rows.Count > 0)
            {
                HoaDon bill = new HoaDon(data.Rows[0]);
                return bill;
            }

            return null;
        }
    }
}
