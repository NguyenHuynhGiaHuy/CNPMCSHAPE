using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1caphe1.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1caphe1
{
    public partial class frmDangnhap : Form
    {
        private NhanVien nv;

        public frmDangnhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }
      
        private void Login()
        {

            //2 Khai báo biến kết nối
            SqlConnection connection = new SqlConnection();
            String strCon = "Data Source=LAPTOP-LLNCUK9F\\SQLEXPRESS;Initial Catalog=QLyQuanCaPhe2;Integrated Security=True";
            connection.ConnectionString = strCon;
            //3 Mở kết nối 
            connection.Open();
            // COLLATE SQL_Latin1_General_CP1_CS_AS được sử dụng để so sánh tenDangnhap mà phân biệt chữ hoa, chữ thường.
            String strQuery = "SELECT * FROM NhanVien WHERE tenDangnhap COLLATE SQL_Latin1_General_CP1_CS_AS = N'" + txtDNhap.Text.Trim() + "' AND matKhau = '" + txtMKhau.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(strQuery, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            errorProvider2.Clear();
            if (reader.HasRows)
            {
                reader.Read();
                nv = new NhanVien(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(4));
                MessageBox.Show("Đăng nhập thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StatusStrip statusStrip = (StatusStrip)this.ParentForm.Controls["statusSTrip1"];
                statusStrip.Items["toolStripStatusLabel1"].Text += " " + nv.TenNV;
                this.Hide();
                frmCTrinh frm = new frmCTrinh();
                this.Hide();
                frm.ShowDialog();
                this.Close();

            }
            else
            {

                errorProvider2.SetError(txtDNhap, "");
                errorProvider2.SetError(txtMKhau, "");
                MessageBox.Show("Chưa nhập thông tin hoặc sai thông tin!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Đăng nhập thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Đóng kết nối 
            connection.Close();
           
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
                Login();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtDNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtMKhau.PasswordChar = '\0';
            }
            else
            {
                txtMKhau.PasswordChar = '*';
            }
        }

        private void frmDangnhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                  MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void frmDangnhap_Load(object sender, EventArgs e)
        {


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}
