using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoeStore.Models;
using System.Data;

namespace ShoeStore.Controls
{
    class ChiTietHoaDon
    {
        private Status status = new Status();
        private Database database = new Database();
        private DataTable chiTietHoaDon_tb;
        private string str;
        private string idHoaDon = "0";

        public DataTable ChiTietHoaDon_tb { get => chiTietHoaDon_tb; }

        public ChiTietHoaDon()
        {

        }
        public void LoadDanhSachChiTiet(string idHoaDon)
        {
            //Proc select * giống LoadDanhSach()
            str = "select * from CHITIETHOADON, GIAY " +
                "where CHITIETHOADON.status=1 and CHITIETHOADON.idGiay = GIAY.idGiay" +
                " and CHITIETHOADON.idHoaDon = '" + idHoaDon + "'";
            this.chiTietHoaDon_tb = database.Execute(str);
        }
		public string ThemChiTiet(string idHoaDon, string idGiay, string donGia, string soLuong)
		{
			// Tính thành tiền
			float thanhTien = float.Parse(soLuong) * float.Parse(donGia);

			// Kiểm tra xem sản phẩm đã tồn tại trong bảng CHITIETHOADON chưa
			string checkExistQuery = "SELECT idChiTietHoaDon, soLuong FROM CHITIETHOADON WHERE idGiay = '" + idGiay + "' AND idHoaDon = '" + idHoaDon + "'";

			// Thực thi câu lệnh SELECT để lấy idChiTietHoaDon và soLuong cũ
			DataTable dt = database.Execute(checkExistQuery);

			// Kiểm tra nếu có dòng dữ liệu và idChiTietHoaDon tồn tại
			if (dt.Rows.Count > 0)
			{
				// Lấy idChiTietHoaDon từ kết quả SELECT
				string idct = dt.Rows[0]["idChiTietHoaDon"].ToString();
				float oldSoLuong = float.Parse(dt.Rows[0]["soLuong"].ToString());

				// Tính lại số lượng tổng cộng mới và thành tiền mới
				float newSoLuong = oldSoLuong + float.Parse(soLuong);
				float newThanhTien = newSoLuong * float.Parse(donGia);

				// Cập nhật lại số lượng và thành tiền trong bảng CHITIETHOADON
				string updateQuery = "UPDATE CHITIETHOADON SET  " +
									 "soLuong = '" + newSoLuong + "' " +
									 "WHERE idGiay = '" + idGiay + "' AND idHoaDon = '" + idHoaDon + "' AND idChiTietHoaDon = '" + idct + "'";

				// Thực thi câu lệnh UPDATE
				database.ExecuteNonQuery(updateQuery);
			}
			else
			{
				// Sản phẩm chưa tồn tại, thực hiện INSERT mới
				string insertQuery = "execute pr_ThemChiTietHoaDon '" + idHoaDon + "', '" + idGiay + "', '" + soLuong + "', '" + donGia + "', '" + thanhTien + "'";

				// Thực thi câu lệnh INSERT
				database.ExecuteNonQuery(insertQuery);
			}

			// Cập nhật lại danh sách chi tiết
			LoadDanhSachChiTiet(idHoaDon);
			return status.Success;
		}


		public string XoaChiTiet(string idHoaDon, int index)
        {
            //Proc Xoá (set status = 0) chi tiết hoá đơn
            //Trigger khi xoa (set status = 0) 1 chi tiết hoá đơn, số lượng sẽ cộng lại cho kho GIAY
            //Trigger khi xoá (set status = 0) 1 chi tiết hoá đơn, dòng có idHoaDon của bảng HOADON sẽ giảm tổng số lượng và tổng Thành tiền
            string idChiTietHoaDon = chiTietHoaDon_tb.Rows[index]["idChiTietHoaDon"].ToString();
            //str = "update CHITIETHOADON set status=0 where idChiTietHoaDon = '" + idChiTietHoaDon + "'";
            str = "pr_XoaChiTietHoaDon '" + idChiTietHoaDon + "'";
            database.ExecuteNonQuery(str);
			str = "delete chitiethoadon where idchitiethoadon=" + idChiTietHoaDon;
			database.ExecuteNonQuery(str);
			LoadDanhSachChiTiet(idHoaDon);
            return status.Success;
        }
      
        public string XoaByID(string idHoaDon)
        {
            //Không cần ghi
            str = "update CHITIETHOADON set status=0 where idHoaDon = '" + idHoaDon + "'";
            database.ExecuteNonQuery(str);
            LoadDanhSachChiTiet(idHoaDon);
            return status.Success;
        }
    }
}