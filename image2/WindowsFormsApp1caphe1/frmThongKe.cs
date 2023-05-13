using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApp1caphe1.DAO;
using WindowsFormsApp1caphe1.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1caphe1
{
    public partial class frmThongKe : Form
    {

        public frmThongKe()
        {
            InitializeComponent();
            LoadListBillDate(dateTimePicker1.Value, dateTimePicker2.Value);
            LoadDateTimePickerHD();
        }

        void LoadDateTimePickerHD()
        {
            DateTime today = DateTime.Now;
            dateTimePicker1.Value = new DateTime(today.Year, today.Month, 1);
            dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(1).AddDays(-1);
        }

        void LoadListBillDate(DateTime ngayVao, DateTime ngayRa) 
        {
            dataGridViewHD.DataSource = HoaDonDAO.Instance.GetBillListByDate(ngayVao, ngayRa);
        }
        void LoadListBillMonth(int thang)
        {
            dataGridViewHD.DataSource = HoaDonDAO.Instance.GetBillListByMonth(thang);
        }
        void LoadListBillNam(int nam)
        {
            dataGridViewHD.DataSource = HoaDonDAO.Instance.GetBillListByNam(nam);
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            this.uSP_GetListBillByDateForReportTableAdapter.Fill(this.qLyQuanCaPhe2DataSet.USP_GetListBillByDateForReport, dateTimePicker1.Value, dateTimePicker2.Value);
            this.reportViewer1.RefreshReport();
           // this.reportViewer2.RefreshReport();
        }

        private void btnthongke_Click_1(object sender, EventArgs e)
        {
            try
            {
                LoadListBillDate(dateTimePicker1.Value, dateTimePicker2.Value);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + exp.Message);
            }
        }

        private void btnthongketheothang_Click(object sender, EventArgs e)
        {
            try
            {
                int thang = dateTimePicker1.Value.Month; // Lấy tháng từ dateTimePicker1

                LoadListBillMonth(thang);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + exp.Message);
            }
        }

        private void btnthongketheonam_Click(object sender, EventArgs e)
        {
            try
            {
                int nam = dateTimePicker1.Value.Year; // Lấy năm từ dateTimePicker1
                LoadListBillNam(nam);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + exp.Message);
            }
        }

        private void dataGridViewHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
