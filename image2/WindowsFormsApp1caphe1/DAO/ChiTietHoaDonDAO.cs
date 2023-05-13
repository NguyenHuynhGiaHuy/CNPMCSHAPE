using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1caphe1.DTO;

namespace WindowsFormsApp1caphe1.DAO
{
    public class ChiTietHoaDonDAO
    {
        private static ChiTietHoaDonDAO instance;

        public static ChiTietHoaDonDAO Instance
        {
            get { if (instance == null) instance = new ChiTietHoaDonDAO(); return ChiTietHoaDonDAO.instance; }
            private set { ChiTietHoaDonDAO.instance = value; }
        }

        private ChiTietHoaDonDAO() { }
        public void XoaCTHDbyID(int idCTHD)
        {
            DataProvider.Instance.ExecuteQuery("Delete ChiTietHoaDon WHERE ChiTietHoaDon.id = " + idCTHD);
        }
        public List<ChiTietHoaDon> GetListBillInfo(int idCTHD)
        {
            List<ChiTietHoaDon> listBillInfo = new List<ChiTietHoaDon>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM ChiTietHoaDon WHERE ChiTietHoaDon.idHD = " + idCTHD);
            //vòng lặp foreach để duyệt qua từng dòng trong DataTable và tạo một đối tượng ChiTietHoaDon từ dòng đó, sau đó thêm đối tượng vào danh sách listBillInfo Trả về danh sách listBillInfo.
            foreach (DataRow item in data.Rows)
            {
                ChiTietHoaDon chitiethoadon = new ChiTietHoaDon(item);
                listBillInfo.Add(chitiethoadon);
            }

            return listBillInfo;
        }
        public void ThemChiTietHoaDon(int idHD, int id , int soLuong)
        {
            DataProvider.Instance.ExecuteNonQuery(" InsertChiTietHoaDon @idHD , @id , @soLuong ", new object[] { idHD, id, soLuong });
        }
        //public void XoaChiTietHoaDon(int idHD)
        //{
        //    DataProvider.Instance.ExecuteNonQuery(" exec deleteHoaDon @idHoaDon ", new object[] { idHD });
        //}


    }
}
