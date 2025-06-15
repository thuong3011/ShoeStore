using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ShoeStore.Models;

namespace ShoeStore.Controls
{
    class DanhMuc
    {
        private Status status = new Status();
        private Database database = new Database();
        private DataTable hangGiay_tb;
        private DataTable danhMuc_tb;
        private string str;
        public DataTable DanhMuc_tb { get => danhMuc_tb; }
        public DataTable HangGiay_tb { get => hangGiay_tb; }

        public DanhMuc()
        {
            LoadDanhSach();
            HangGiay hangGiay = new HangGiay();
            this.hangGiay_tb = hangGiay.HangGiay_tb;
        }
        public void LoadDanhSach()
        {
            str = "select * from HANGGIAY inner join LOAIGIAY " +
                "on HANGGIAY.idHangGiay = LOAIGIAY.idHangGiay where LOAIGIAY.status=1";
            this.danhMuc_tb = database.Execute(str);
        }
		public void TimKiem(String ten)
		{
			// Xử lý đầu vào (loại bỏ ký tự đặc biệt để giảm nguy cơ SQL Injection)
			ten = ten.Replace("'", "''"); // Escape dấu nháy đơn
			str = "SELECT * FROM HANGGIAY INNER JOIN LOAIGIAY " +
				  "ON HANGGIAY.idHangGiay = LOAIGIAY.idHangGiay " +
				  "WHERE LOAIGIAY.status = 1 AND LOAIGIAY.tenLoaiGiay LIKE N'%" + ten + "%'";
			this.danhMuc_tb = database.Execute(str);
		}

		public string Them(string ten, string idHangGiay, string img)
		{
			// Kiểm tra xem đã tồn tại tên loại giày hay chưa
			string checkStr = $"SELECT COUNT(*) FROM LOAIGIAY WHERE tenLoaiGiay = N'{ten}' AND idHangGiay = '{idHangGiay}'";
			DataTable dt = database.Execute(checkStr);

			if (dt.Rows.Count > 0 && int.Parse(dt.Rows[0][0].ToString()) > 0)
			{
				// Nếu đã tồn tại, trả về Failure
				return status.Failure;
			}

			// Thực hiện thêm mới
			string str = $"INSERT INTO LOAIGIAY(tenLoaiGiay, idHangGiay, linkImage) VALUES(N'{ten}', '{idHangGiay}', N'{img}')";
			if (database.ExecuteNonQuery(str))
			{
				LoadDanhSach();
				return status.Success;
			}
			return status.Failure;
		}

		public string CapNhat(int index, string ten, int idHangGiay , string image)
        {
            string str = "update LOAIGIAY set tenLoaiGiay = N'" + ten + "', idHangGiay='"+ idHangGiay + "',linkImage =N'" +image+ "' where status = 1 and idLoaiGiay = " + danhMuc_tb.Rows[index]["idLoaiGiay"].ToString();
            if (database.ExecuteNonQuery(str))
            {
                LoadDanhSach();
                return status.Success;
            }
            return status.Failure;
        }
        public string Xoa(int index)
        {
            str = "update LOAIGIAY set status=0 where idLoaiGiay = '" + danhMuc_tb.Rows[index]["idLoaiGiay"].ToString() + "'";
            database.ExecuteNonQuery(str);
            LoadDanhSach();
            return status.Success;
        }
    }
}
