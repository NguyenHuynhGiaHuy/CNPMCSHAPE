using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1caphe1.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }
        private String strCon = "Data Source=LAPTOP-LLNCUK9F\\SQLEXPRESS;Initial Catalog=QLyQuanCaPhe2;Integrated Security=True";
 
        public DataTable ExecuteQuery(string strQuery, object[] parameter = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(strQuery, connection);
                if (parameter != null)
                {
                    string[] listPara = strQuery.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                connection.Close();
            }
            return data;
        }
 
        public int ExecuteNonQuery(string strQuery, object[] parameter = null)
        {
            int data = 0;

            // tạo một đối tượng kết nối (SqlConnection) đến cơ sở dữ liệu.
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                //SqlCommand với truy vấn SQL và kết nối tương ứng.
                SqlCommand cmd = new SqlCommand(strQuery, connection);

                //Kiểm tra xem tham số parameter có giá trị hay không
                if (parameter != null)
                {
                    // chia chuỗi strQuery thành một mảng các chuỗi con, sử dụng khoảng trắng (' ') như dấu phân cách.
                    string[] listPara = strQuery.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        //Nếu phần tử chứa ký tự '@' (đại diện cho một tham số), tham số được thêm vào SqlCommand thông qua phương thức AddWithValue.
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                //Gọi phương thức ExecuteNonQuery() của đối tượng SqlCommand để thực thi truy vấn 
                data = cmd.ExecuteNonQuery();

                connection.Close();
            }
            return data;
        }

        public object ExecuteScalar(string strQuery, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(strQuery, connection);

                if (parameter != null)
                {
                    string[] listPara = strQuery.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = cmd.ExecuteScalar();

                connection.Close();
            }
            return data;

        }

    }
}
