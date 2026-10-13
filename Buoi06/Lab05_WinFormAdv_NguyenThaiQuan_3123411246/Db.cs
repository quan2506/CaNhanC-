using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;   // Thư viện ADO.NET kết nối SQL Server (tương đương System.Data.SqlClient trong tài liệu)

namespace Practice5
{
    /// <summary>
    /// Lớp dùng chung cho các bài ADO.NET (Bài 7):
    ///  - Lưu chuỗi kết nối tới CSDL QLSinhVien (2 cách: Windows Authentication / SQL Server Authentication).
    ///  - Cung cấp hàm ThucThi() để chạy lệnh Thêm / Xóa / Sửa, tránh phải viết lại mã mở-đóng kết nối ở mỗi form.
    /// </summary>
    public static class Db
    {
        // ====== CẤU HÌNH KẾT NỐI - sửa lại cho đúng máy của bạn ======
        public const string TenServer = ".";          // Tên server. vd: ".", "localhost\\SQLEXPRESS", "(localdb)\\MSSQLLocalDB"
        public const bool DungWindowsAuth = true;     // true: Windows Authentication, false: SQL Server Authentication
        public const string UserId = "sa";            // Chỉ dùng khi DungWindowsAuth = false
        public const string Password = "123456";      // Chỉ dùng khi DungWindowsAuth = false
        // ===============================================================

        // Cách 1: Đăng nhập bằng quyền Windows (Integrated Security = True, không cần user/password).
        // TrustServerCertificate=True: bỏ qua kiểm tra chứng chỉ SSL (cần thiết với thư viện Microsoft.Data.SqlClient mới).
        public static readonly SqlConnection conn = new SqlConnection(
            $"Data Source={TenServer};Initial Catalog=QLSinhVien;Integrated Security=True;TrustServerCertificate=True");

        // Cách 2: Đăng nhập bằng tài khoản SQL Server (User ID + Password).
        public static readonly SqlConnection connsql = new SqlConnection(
            $"Data Source={TenServer};Initial Catalog=QLSinhVien;User ID={UserId};Password={Password};TrustServerCertificate=True");

        // Chọn kết nối nào sẽ dùng dựa vào hằng DungWindowsAuth ở trên.
        public static SqlConnection Ketnoi => DungWindowsAuth ? conn : connsql;

        /// <summary>
        /// Thực thi một câu lệnh Insert / Update / Delete.
        /// Quy trình 4 bước: (1) mở kết nối  (2) tạo SqlCommand  (3) ExecuteNonQuery  (4) đóng kết nối.
        /// Dùng tham số (@ten) thay vì nối chuỗi để tránh lỗi dấu nháy đơn (') và SQL Injection.
        /// </summary>
        /// <param name="sql">Câu lệnh SQL có chứa tham số, ví dụ: "delete from Khoa where MaKhoa = @ma"</param>
        /// <param name="thamSo">Danh sách (tên tham số, giá trị) tương ứng với các @tham số trong câu lệnh</param>
        public static void ThucThi(string sql, params (string ten, object giaTri)[] thamSo)
        {
            var c = Ketnoi;
            try
            {
                // Bước 1: kiểm tra trạng thái trước khi mở (nếu đã mở rồi mà Open() tiếp sẽ gây lỗi)
                if (c.State == ConnectionState.Closed) c.Open();

                // Bước 2: tạo command gắn với câu lệnh và kết nối
                var cmd = new SqlCommand(sql, c);
                foreach (var (ten, giaTri) in thamSo) cmd.Parameters.AddWithValue(ten, giaTri);

                // Bước 3: ExecuteNonQuery dùng cho Insert/Update/Delete, trả về số dòng bị ảnh hưởng
                int dong = cmd.ExecuteNonQuery();

                if (dong > 0) MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Không có dòng nào bị ảnh hưởng (dữ liệu không tồn tại?)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Lỗi thường gặp: sai tên server, trùng khóa chính, vi phạm khóa ngoại...
                MessageBox.Show("Thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Bước 4: finally luôn chạy dù thành công hay lỗi => kết nối luôn được đóng, không bị rò rỉ
                if (c.State == ConnectionState.Open) c.Close();
            }
        }
    }
}
