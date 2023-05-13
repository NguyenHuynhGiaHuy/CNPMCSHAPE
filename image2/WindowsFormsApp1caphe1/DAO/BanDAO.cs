using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1caphe1.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace WindowsFormsApp1caphe1.DAO
{
    public class BanDAO
    {
        private static BanDAO instance;
        public  static BanDAO Instance
        {
            get { if (instance == null) instance = new BanDAO(); return BanDAO.instance; }
            private set { BanDAO.instance = value; }

        }
        private BanDAO()
        {
            // Hàm khởi tạo private để ngăn việc tạo thể hiện mới của lớp từ bên ngoài
        }
        public static int TableWidth = 100;
        public static int TableHeight = 108;
        
        public List<Table> LoadTableList()
        {
            //// Phương thức để tải danh sách các bàn từ cơ sở dữ liệu
            List<Table> tablelist = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("gettablelist");
            foreach (DataRow item in data.Rows)
            {
                Table tb = new Table(item);
                tablelist.Add(tb);
            }   
            return tablelist;
        }
        public void SwitchTable(int id1, int id2)
        {
            // Phương thức để chuyển đổi vị trí của hai bàn
            DataProvider.Instance.ExecuteNonQuery("UPS_SwitchTabel @idBan1 , @idBan2", new object[] { id1 , id2 });
        }
        public List<Table> GetListBan()
        {
            //// Phương thức để lấy danh sách các bàn từ cơ sở dữ liệu
            List<Table> list = new List<Table>();

            string query = "select * from Ban";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table ban = new Table(item);
                list.Add(ban);
            }

            return list;
        }
        public bool ThemBan(String tenBan, String loai, String tinhTrangBan)
        {
            //// Phương thức để lấy danh sách các bàn từ cơ sở dữ liệu
            string query = string.Format("Insert Ban ( tenBan, loai, tinhTrangBan ) values  (  N'{0}', N'{1}', N'{2}')", tenBan, loai, tinhTrangBan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool SuaBan(int idBan, String tenBan, String loai, String tinhTrangBan)
        {
            // Phương thức để cập nhật thông tin của một bàn trong cơ sở dữ liệu
            string query = string.Format("update Ban set  tenBan = N'{0}', loai = N'{1}', tinhTrangBan = N'{2}' where idBan = {3}", tenBan, loai, tinhTrangBan, idBan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public bool XoaBan(int idBan)
        {
            // Phương thức để xóa một bàn khỏi cơ sở dữ liệu
            string query = string.Format("Delete Ban where idBan = {0}", idBan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
        public List<Table> Timkiemban(string tenBan)
        {
            // Phương thức để tìm kiếm các bàn theo tên bàn từ cơ sở dữ liệu
            List<Table> list = new List<Table>();

            string query = string.Format("select * from Ban where tenBan like N'%{0}%'", tenBan);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Table ban = new Table(item);
                list.Add(ban);
            }

            return list;
        }
    }
}
