using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1caphe1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmDangnhap frmDangNhap = new frmDangnhap();
            frmDangNhap.MdiParent = this;
            frmDangNhap.StartPosition = FormStartPosition.CenterScreen;
            frmDangNhap.Show();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangnhap frmDangNhap = new frmDangnhap();
            // Đặt form đăng nhập làm con của form hiện tại
            frmDangNhap.MdiParent = this;
            // Đặt vị trí xuất hiện của form đăng nhập ở giữa màn hình
            frmDangNhap.StartPosition = FormStartPosition.CenterScreen;
            frmDangNhap.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn có muốn đăng xuất khỏi phần mền?", "Đăng xuất",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Application.Exit();

        }
    }
}

