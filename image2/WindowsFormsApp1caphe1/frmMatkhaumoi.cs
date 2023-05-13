using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1caphe1
{
    public partial class frmMatkhaumoi : Form
    {
        SqlConnection cn = new SqlConnection();
        public frmMatkhaumoi()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // SqlConnection cn = new SqlConnection("Data Source=LAPTOP-LLNCUK9F\\SQLEXPRESS;Initial Catalog=QLyQuanCaPhe2;Integrated Security=True");

        private void frmMatkhaumoi_Load(object sender, EventArgs e)
        {
            String strCon;
            strCon = ConfigurationManager.ConnectionStrings["QLCAPHE"].ConnectionString;
            cn.ConnectionString = strCon;
        }

        private void btnCapnhatmk_Click(object sender, EventArgs e)
        {

            if (txtMKcu.Text.Length >= 8 && txtTendnmoi.Text.Length >= 8)
            {
                // Check if the username and password contain special characters
                if (!ContainsSpecialCharacters(txtMKcu.Text) && !ContainsSpecialCharacters(txtTendnmoi.Text))
                {
                    SqlDataAdapter data = new SqlDataAdapter("SELECT COUNT(*) FROM NhanVien WHERE matKhau = '" + txtMKcu.Text + "'", cn);
                    DataTable dataTable = new DataTable();
                    data.Fill(dataTable);
                    errorProvider2.Clear();

                    if (dataTable.Rows[0][0].ToString() == "1")
                    {
                        if (txtMKmoi.Text == txtNhapLaiMKmoi.Text)
                        {
                            if (txtMKmoi.Text.Length >= 8 && !ContainsSpecialCharacters(txtMKmoi.Text))
                            {
                                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("UPDATE NhanVien SET tenDangnhap = N'" + txtTendnmoi.Text + "', matKhau = '" + txtMKmoi.Text + "' WHERE matKhau = '" + txtMKcu.Text + "'", cn);
                                DataTable dataTable1 = new DataTable();
                                sqlDataAdapter.Fill(dataTable1);
                                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Độ dài mật khẩu phải trên 8 kí tự và không có kí tự đặc biệt!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                errorProvider2.SetError(txtMKmoi, "");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu nhập lại không khớp!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errorProvider2.SetError(txtMKmoi, "");
                            errorProvider2.SetError(txtNhapLaiMKmoi, "");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProvider2.SetError(txtMKcu, "");
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập và mật khẩu không được chứa kí tự đặc biệt!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    errorProvider2.SetError(txtMKcu, "");
                    errorProvider2.SetError(txtTendnmoi, "");
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu phải trên 8 kí tự!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider2.SetError(txtMKcu, "");
                errorProvider2.SetError(txtTendnmoi, "");
            }

        }

        // Function to check if a string contains special characters
        private bool ContainsSpecialCharacters(string input)
        {
                return !Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
        }


    }
}
