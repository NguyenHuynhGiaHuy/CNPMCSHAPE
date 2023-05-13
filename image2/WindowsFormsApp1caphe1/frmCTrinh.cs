using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using WindowsFormsApp1caphe1.DAO;
using WindowsFormsApp1caphe1.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1caphe1
{
    public partial class frmCTrinh : Form
    {


        int panelWidth;
        bool Hidden;
        int panelHeight;
        public frmCTrinh()
        {
            InitializeComponent();
            // Khởi tạo kích thước và trạng thái ban đầu của panel
            panelWidth = panelslide1.Width;
            Hidden = false;

            panelHeight = panel_slide1.Height;
            Hidden = false;

            // Đặt kích thước và vị trí ban đầu cho panelslide1
            panelslide1.Height = btnBanhang.Height;
            panelslide1.Top = btnBanhang.Top;


        }
        private void frmCTrinh_Load(object sender, EventArgs e)
        {
    
            frmBanhang formbh = new frmBanhang();
            // thiết lập formbh là form con
            formbh.TopLevel = false;
            //Lấp đầy frombh trong panel_body1
            formbh.Dock = DockStyle.Fill;
            // thêm form con vào trong panel_body1 của formCTrinh
            panel_body1.Controls.Add(formbh);
            formbh.Show();
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void timechuchay_Tick(object sender, EventArgs e)
        {
            //try 
            //{
            //    int currentX = lblChuchay.Location.X;

            //    // Di chuyển label sang phải
            //    currentX++;
            //    lblChuchay.Location = new Point(currentX, lblChuchay.Location.Y);

            //    // Nếu label vượt ra khỏi màn hình
            //    if (currentX >= this.Width)
            //    {
            //        // Tạo form mới
            //        frmCTrinh fr = new frmCTrinh();

            //        // Đặt lại vị trí label bên trái màn hình
            //        int newX = -lblChuchay.Width;
            //        lblChuchay.Location = new Point(newX, lblChuchay.Location.Y);

            //        // Đặt giá trị x mới để label tiếp tục di chuyển
            //        currentX = newX;
            //    }
            //}
            //catch
            //{

            //}
            
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }

        private Form curentFormChild = null;
        private void OpenChilForm(Form childForm)
        {
            if (curentFormChild != null)
            {
                curentFormChild.Close();
            }
            curentFormChild = childForm;

            // cấu hình form con
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Thêm form con vào trong panel_body1
            panel_body1.Controls.Add(childForm);
            panel_body1.Tag = childForm;
            // đưa form con lên phía trước của panel_body1
            childForm.BringToFront();
            // đặt kích thước của childForm bằng kích thước của panel_body1
            childForm.Size = panel_body1.Size;
            childForm.Show();

        }

       
        private void btntopdown_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (Hidden)
            {
                // Mở rộng panel_slide1 xuống
                panel_slide1.Height = panel_slide1.Height + 10;
                if (panel_slide1.Height >= panelHeight)
                {
                    timer3.Stop();
                    Hidden = false;
                    this.Refresh();
                }

            }
            else
            {
                // Thu nhỏ panel_slide1 lên
                panel_slide1.Height = panel_slide1.Height - 10;
                if (panel_slide1.Height <= 0)
                {
                    timer3.Stop();
                    Hidden = true;
                    this.Refresh();
                }
            }
        }

        private void btnmenu_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hidden)
            {
                // Mở rộng panelslide1 sang phải
                panelslide1.Width = panelslide1.Width + 10;
                if (panelslide1.Width >= panelWidth)
                {
                    timer1.Stop();
                    Hidden = false;
                    this.Refresh();
                }

            }
            else
            {
                // Thu nhỏ panelslide1 sang trái
                panelslide1.Width = panelslide1.Width - 10;
                if (panelslide1.Width <= 0)
                {
                    timer1.Stop();
                    Hidden = true;
                    this.Refresh();
                }
            }
        }

        private void btnBanhang_Click_1(object sender, EventArgs e)
        {
            // Mở form Banhang trong panel_body1
            OpenChilForm(new frmBanhang());
            // Đặt vị trí của Slidepane1 tương ứng với nút Banhang
            Slidepane1.Top = btnBanhang.Top;
        }

        private void btnQuanly_Click_1(object sender, EventArgs e)
        {
            OpenChilForm(new frmQuanly());
            Slidepane1.Top = btnQuanly.Top;

        }

        private void panelslide1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDoimatkhau_Click_1(object sender, EventArgs e)
        {
            // Tạo và hiển thị form Matkhaumoi
            frmMatkhaumoi frmdoimatkhau = new frmMatkhaumoi();
            this.Hide();
            frmdoimatkhau.ShowDialog();
            this.Show();
            Slidepane1.Top = btnDoimatkhau.Top;
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private void btnThongke_Click_1(object sender, EventArgs e)
        {
            OpenChilForm(new frmThongKe());
            Slidepane1.Top = btnThongke.Top;
        }

        private void btnCaidat_Click(object sender, EventArgs e)
        {
            OpenChilForm(new frmCaidat());
            Slidepane1.Top = btnCaidat.Top;
        }
    }
}
