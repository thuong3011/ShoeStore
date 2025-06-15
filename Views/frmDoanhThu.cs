using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ShoeStore.Controls;

namespace ShoeStore.Views
{
	public partial class frmDoanhThu : Form
	{
		private HoaDon hoaDon = new HoaDon();
		Models.Database db = new Models.Database();

		public frmDoanhThu()
		{
			InitializeComponent();
		}

		private void frmDoanhThu_Load(object sender, EventArgs e)
		{
            
			chart1.Series["Tổng doanh thu"].Points.Clear();
			nam.Value = DateTime.Now.Year;
			nam.Minimum = 2000;
			nam.Maximum = DateTime.Now.Year;

			LoadData();

			// Gán sự kiện khi thay đổi năm
			nam.ValueChanged += (s, ev) => LoadData();
		}

		private void LoadData()
		{
			int namValue = (int)nam.Value;

			// Truy vấn doanh thu theo tháng từ bảng HOADON
			string sqlDoanhThu = $@"
        SELECT MONTH(ngayinhoadon) AS Thang, SUM(thanhtien) AS TongThanhTien
        FROM HOADON 
        WHERE YEAR(ngayinhoadon) = {namValue} AND MONTH(ngayinhoadon) BETWEEN 1 AND 12
        GROUP BY MONTH(ngayinhoadon)
        ORDER BY Thang";

			DataTable doanhThuTheoThang = db.Execute(sqlDoanhThu);

			// Xóa sạch dữ liệu cũ của biểu đồ
			chart1.Series["Tổng doanh thu"].Points.Clear();

			// Khởi tạo mảng doanh thu mặc định với giá trị 0 cho 12 tháng
			decimal[] doanhThuThang = new decimal[12];

			// Kiểm tra dữ liệu trả về từ SQL
			if (doanhThuTheoThang.Rows.Count > 0)
			{
				foreach (DataRow row in doanhThuTheoThang.Rows)
				{
					int thang = Convert.ToInt32(row["Thang"]);
					decimal tongThanhTien = Convert.ToDecimal(row["TongThanhTien"]);

					// Chỉ cập nhật nếu tháng hợp lệ (1-12)
					if (thang >= 1 && thang <= 12)
					{
						doanhThuThang[thang - 1] = tongThanhTien; // Chỉ mục từ 0-11
					}
				}
			}

			// Thêm dữ liệu vào biểu đồ với đủ 12 tháng
			for (int i = 0; i < 12; i++)
			{
				chart1.Series["Tổng doanh thu"].Points.AddXY(i + 1, doanhThuThang[i]);
			}

			// Thiết lập giới hạn trục X để đảm bảo phần tử cuối cùng là 12
			chart1.ChartAreas[0].AxisX.Minimum = 1; // Giá trị nhỏ nhất là 1
			chart1.ChartAreas[0].AxisX.Maximum = 12; // Giá trị lớn nhất là 12

			// Định dạng giá trị trên trục Y theo định dạng tiền tệ
			chart1.ChartAreas[0].AxisY.LabelStyle.Format = "N0"; // Định dạng số với dấu phân cách hàng nghìn
			chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Blue; // Tùy chọn: Đổi màu chữ nếu cần

			// Cập nhật tiêu đề biểu đồ
			chart1.ChartAreas[0].AxisX.Title = "Tháng";
			chart1.ChartAreas[0].AxisY.Title = "Tổng doanh thu (đ)"; // Thêm đơn vị tiền tệ vào tiêu đề trục Y
			chart1.Legends[0].Title = $"Tổng doanh thu theo tháng ({namValue})";

			// Truy vấn tổng chi từ NHAPKHO theo năm đã chọn
			string sqlChi = $"SELECT SUM(thanhtien) FROM NHAPKHO WHERE YEAR(ngayNhapKho) = {namValue}";
			DataTable dtChi = db.Execute(sqlChi);
			chi.Text = GetFormattedMoney(dtChi);

			// Truy vấn tổng thu từ HOADON theo năm đã chọn
			string sqlThu = $"SELECT SUM(thanhtien) FROM HOADON WHERE YEAR(ngayinhoadon) = {namValue}";
			DataTable dtThu = db.Execute(sqlThu);
			thu.Text = GetFormattedMoney(dtThu);
		}


		// Hàm định dạng tiền tệ
		private string GetFormattedMoney(DataTable dt)
		{
			if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
			{
				if (decimal.TryParse(dt.Rows[0][0].ToString(), out decimal value))
				{
					return string.Format("{0:n0} đ", value); // Định dạng số với dấu phân cách và thêm 'đ'
				}
			}
			return "0 đ"; // Trả về '0 đ' nếu không có dữ liệu hoặc lỗi
		}

		private void chart1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Bạn đã nhấn vào biểu đồ!");
		}
	}
}
