using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1caphe1.DAO;
using WindowsFormsApp1caphe1.DTO;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Drawing.Printing;
using System.Text.RegularExpressions;
using static WindowsFormsApp1caphe1.frmBanhang;


namespace WindowsFormsApp1caphe1
{
    public partial class frmBanhang : Form
    {

        private int currentBillId = -1;
        public frmBanhang()
        {
            
            InitializeComponent();
            LoadTable();
            LoadLoaiSP();
            LoadBan();
        }
        #region phuongthuc 
        // Phương thức để load danh sách bàn
        void LoadBan()
        {
            // lấy danh sách bàn từ CSDL
            List<Table> ban = BanDAO.Instance.LoadTableList();
            cmbBan.DataSource = ban; ;
            cmbBan.DisplayMember = "tenBan";
        }
        // Phương thức để load danh sách loại sản phẩm
        void LoadLoaiSP()
        {
            List<LoaiSP> listloaiSP = LoaiSPDAO.Instance.GetDanhmucsp();
            cmbLoai.DataSource = listloaiSP;
            cmbLoai.DisplayMember = "tenLoaiSanPham";
        }
        // Phương thức để load danh sách sản phẩm bới loại sản phẩm
        void LoadSPListByLoaiSP(int id)
        {
            // Lấy danh sách sản phẩm dựa trên loại sản phẩm được chọn
            List<SanPham> listsp = SanPhamDAO.Instance.GetFoodByCategoryID(id);
            cmbloaisp.DataSource = listsp;
            cmbloaisp.DisplayMember = "tenSP";
        }
        void LoadTable()
        {
            // Xóa các controls bàn cũ trên FlowLayoutPanel
            flpBan.Controls.Clear();
            // Lấy danh sách bàn từ CSDL
            List<Table> tablelist = BanDAO.Instance.LoadTableList();

            foreach (Table item in tablelist)
            {
                Button btn = new Button() { Width = BanDAO.TableWidth, Height = BanDAO.TableHeight };
                btn.Text = item.TenBan + Environment.NewLine + item.TinhTrangBan;
                btn.Click += btn_Click;
                btn.Tag = item;
                // Đặt màu nền cho button dựa trên tình trạng bàn
                switch (item.TinhTrangBan)
                {
                    case "Trống":
                        btn.BackColor = Color.Gray;
                        break;
                    default:
                        btn.BackColor = Color.Orange;
                        break;
                }
                // Thêm button vào FlowLayoutPanel
                flpBan.Controls.Add(btn);
            }

        }
        void ShowHoaDon(int idHD)
        {
            // Xóa các items cũ trong ListView
            listView1.Items.Clear();
            // Lấy danh sách sản phẩm trong hóa đơn dựa trên ID hóa đơn
            List<WindowsFormsApp1caphe1.DTO.Danhmucsp> listBillInfo = DanhmucspDAO.Instance.GetListMenuByTable(idHD);
            float ThanhTien = 0;
            foreach (WindowsFormsApp1caphe1.DTO.Danhmucsp item in listBillInfo)
            {
                // Hiển thị thông tin sản phẩm trong ListView
                ListViewItem lsvItem = new ListViewItem(item.TenSP.ToString());
                lsvItem.SubItems.Add(item.Soluong.ToString());
                lsvItem.SubItems.Add(item.GiaTien.ToString());
                lsvItem.SubItems.Add(item.ThanhTien.ToString());
                ThanhTien += item.ThanhTien;
                listView1.Items.Add(lsvItem);
            }
            // Định dạng và hiển thị tổng tiền hóa đơn
            CultureInfo culture = new CultureInfo("vi-VN");
            txtThanhTien.Text = ThanhTien.ToString("c", culture);
        }
        #endregion

        // sự kiện khi click vào button bàn
        void btn_Click(object sender, EventArgs e)
        {
            // Lấy ID hóa đơn chưa thanh toán của bàn được chọn gán cho txtBillId
            int maBan = ((sender as Button).Tag as Table).IdBan;
            //gọi pt GetUncheckBillIDByTableID  từ lớp HoaDonDAO.Instance để lấy mã hóa đơn chưa thanh toán cho bàn có IdBan là maBan. Mã hóa đơn này được gán cho biến currentBillId
            currentBillId = HoaDonDAO.Instance.GetUncheckBillIDByTableID(maBan);
            //Gán giá trị của currentBillId vào thuộc tính Text của đối tượng txtBillId. Điều này có thể là để hiển thị mã hóa đơn chưa thanh toán lên một trường văn bản (textbox) có tên là txtBillId
            txtBillId.Text = currentBillId.ToString();
            // Lưu danh sách hóa đơn vô bàn
            listView1.Tag = (sender as Button).Tag;
            // Hiển thị thông tin hóa đơn của bàn
            ShowHoaDon(maBan);
        }

        // sự kiện khi chọn loại sản phẩm
        private void cmbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cmb = sender as ComboBox;
            if (cmb.SelectedItem == null)
            {
                return;
            }
            //toán tử as để ép kiểu từ kiểu dữ liệu của phần tử được chọn sang kiểu LoaiSP
            LoaiSP selected = cmb.SelectedItem as LoaiSP;
            id = selected.Id;
            // Tải danh sách sản phẩm dựa trên loại sản phẩm được chọn
            LoadSPListByLoaiSP(id);
        }

        // Xử lý sự kiện khi click vào button "Thêm"
        private void btnthem_Click(object sender, EventArgs e)
        {
            Table table = listView1.Tag as Table;
            int idHD = HoaDonDAO.Instance.GetUncheckBillIDByTableID(table.IdBan);
            int id = (cmbloaisp.SelectedItem as SanPham).Id;
            int soLuong = (int)numericUpDown1.Value;

            if (idHD == -1)
            {
                HoaDonDAO.Instance.ThemHoaDon(table.IdBan);
                ChiTietHoaDonDAO.Instance.ThemChiTietHoaDon(HoaDonDAO.Instance.GetMaxIDBill(), id, soLuong);
            }
            else
            {
                ChiTietHoaDonDAO.Instance.ThemChiTietHoaDon(idHD, id, soLuong);
            }
            if (currentBillId == -1)
            {
                currentBillId = HoaDonDAO.Instance.GetMaxIDBill();
                txtBillId.Text = currentBillId.ToString();
            }
            ShowHoaDon(table.IdBan);
            LoadTable();
        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            currentBillId = -1;
            txtBillId.Text = "";
            Table table = listView1.Tag as Table;

            int idHD = HoaDonDAO.Instance.GetUncheckBillIDByTableID(table.IdBan);
            double tongTien = 0;

            if (double.TryParse(txtThanhTien.Text.Split(',')[0], out tongTien))
            {
                string formattedTongTien = tongTien.ToString("C");

                if (idHD != -1)
                {
                    string message = string.Format("Bạn muốn thanh toán hóa đơn cho bàn {0} với tổng tiền {1}", table.TenBan, formattedTongTien);

                    DialogResult result = MessageBox.Show(message, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.OK)
                    {
                        HoaDonDAO.Instance.KiemtraNgayRa(idHD, (float)tongTien);
                        ShowHoaDon(table.IdBan);
                        LoadTable();
                    }
                }
            }
            else
            {
                // Xử lý lỗi nếu không thể chuyển đổi tổng tiền sang kiểu double
                MessageBox.Show("Số tiền thanh toán không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            int id1 = (listView1.Tag as Table).IdBan; //lấy ra id table đang chọn
            int id2 = (cmbBan.SelectedItem as Table).IdBan; //lấy ra id table muốn chuyển bàn
            if (MessageBox.Show(string.Format("Bạn có muốn chuyển bàn {0} qua bàn {1} không?", (listView1.Tag as Table).TenBan, (cmbBan.SelectedItem as Table).TenBan), "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BanDAO.Instance.SwitchTable(id1, id2);
                LoadTable();
            }
        }
        private void btninhoadon_Click(object sender, EventArgs e)
        {
            try
            {
                //Chuyển đổi giá trị trong txtBillId.Text từ kiểu chuỗi (string) sang kiểu số nguyên (int)
                int billId = int.Parse(txtBillId.Text);
                PrintBill(billId);
            }
            catch
            {

            }

           
        }
        private void PrintBill(int billId)
        {
            HoaDon bill = HoaDonDAO.Instance.GetBillById(billId);

            // Kiểm tra hóa đơn tồn tại
            if (bill == null)
            {
                MessageBox.Show("Hóa đơn không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo nội dung hóa đơn
            StringBuilder billContent = new StringBuilder();
            billContent.AppendLine("CAFPE LINH");
            billContent.AppendLine("Địa chỉ: 29 Tô Vĩnh Diện,Khu Phố 2, Linh Chiếu, Thủ Đức, Thành phố Hồ Chí Minh");
            billContent.AppendLine("Ngày: " + DateTime.Now.ToString("dd/MM/yyyy"));
            billContent.AppendLine("HĐ:" + txtBillId.Text);
            billContent.AppendLine();

            billContent.AppendLine("HÓA ĐƠN TÍNH TIỀN:");
            billContent.AppendLine();
            billContent.AppendFormat("{0,-30}\t{1,-10}\t{2,-10}\t{3,-10}\n", "Tên sản phẩm", "Số lượng", "Đơn giá", "Thành tiền");
            billContent.AppendLine("------------------------------------------------------------------------------------------------");

            foreach (ListViewItem listItem in listView1.Items)
            {
                string productName = listItem.SubItems[0].Text;
                string quantity = listItem.SubItems[1].Text;
                string price = listItem.SubItems[2].Text;
                string totalPrice = listItem.SubItems[3].Text;
                billContent.AppendFormat("{0,-30}\t{1,-15}\t{2,-15}\t{3,-30}\n", productName, quantity, price, totalPrice);
            }

            billContent.AppendLine("------------------------------------------------------------------------------------------------");
            billContent.AppendLine("Tổng tiền: " + txtThanhTien.Text);
            billContent.AppendLine("**HẸN GẶP LẠI QUÝ KHÁCH!**" );


            string billContentString = billContent.ToString();

            // In hóa đơn
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (s, args) =>
            {
                using (Font font = new Font("Arial", 10, FontStyle.Regular))
                {
                    float lineHeight = font.GetHeight(args.Graphics);
                    float startX = 10;
                    float startY = 10;

                    foreach (string line in billContent.ToString().Split('\n'))
                    {
                        args.Graphics.DrawString(line, font, Brushes.Black, startX, startY);
                        startY += lineHeight;
                    }
                }
            };

            try
            {
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
