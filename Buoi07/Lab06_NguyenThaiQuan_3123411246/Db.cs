using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Practice6
{
    /// <summary>
    /// Lớp tiện ích kết nối CSDL QLSinhVien.
    /// Cung cấp hàm ThucThi() cho Insert/Update/Delete và LayDuLieu() cho Select.
    /// </summary>
    public static class Db
    {
        // ====== CẤU HÌNH KẾT NỐI ======
        public const string TenServer = ".";
        public const bool DungWindowsAuth = true;
        public const string UserId = "sa";
        public const string Password = "123456";
        // ================================

        private static string ChuoiKetNoi(string tenCSDL)
        {
            if (DungWindowsAuth)
                return $"Data Source={TenServer};Initial Catalog={tenCSDL};Integrated Security=True;TrustServerCertificate=True";
            return $"Data Source={TenServer};Initial Catalog={tenCSDL};User ID={UserId};Password={Password};TrustServerCertificate=True";
        }

        // Kết nối mặc định tới CSDL QLSinhVien
        public static SqlConnection TaoKetNoi(string tenCSDL = "QLSinhVien")
            => new SqlConnection(ChuoiKetNoi(tenCSDL));

        /// <summary>
        /// Thực thi Insert / Update / Delete với tham số.
        /// Trả về số dòng bị ảnh hưởng (-1 nếu lỗi).
        /// </summary>
        public static int ThucThi(string sql, string tenCSDL = "QLSinhVien", params (string ten, object giaTri)[] thamSo)
        {
            using var c = TaoKetNoi(tenCSDL);
            try
            {
                c.Open();
                var cmd = new SqlCommand(sql, c);
                foreach (var (ten, giaTri) in thamSo) cmd.Parameters.AddWithValue(ten, giaTri);
                int dong = cmd.ExecuteNonQuery();
                if (dong > 0) MessageBox.Show("Thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Không có dòng nào bị ảnh hưởng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return dong;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        /// <summary>Overload đơn giản cho CSDL QLSinhVien (không cần truyền tên CSDL).</summary>
        public static int ThucThiQL(string sql, params (string ten, object giaTri)[] thamSo)
            => ThucThi(sql, "QLSinhVien", thamSo);

        /// <summary>Overload cho CSDL QLCuaHang.</summary>
        public static int ThucThiCH(string sql, params (string ten, object giaTri)[] thamSo)
            => ThucThi(sql, "QLCuaHang", thamSo);

        /// <summary>
        /// Lấy dữ liệu (SELECT) trả về DataTable.
        /// </summary>
        public static DataTable LayDuLieu(string sql, string tenCSDL = "QLSinhVien", params (string ten, object giaTri)[] thamSo)
        {
            using var c = TaoKetNoi(tenCSDL);
            var dt = new DataTable();
            try
            {
                c.Open();
                var cmd = new SqlCommand(sql, c);
                foreach (var (ten, giaTri) in thamSo) cmd.Parameters.AddWithValue(ten, giaTri);
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>Lấy một giá trị đơn (ExecuteScalar).</summary>
        public static object? LayGiaTri(string sql, string tenCSDL = "QLSinhVien", params (string ten, object giaTri)[] thamSo)
        {
            using var c = TaoKetNoi(tenCSDL);
            try
            {
                c.Open();
                var cmd = new SqlCommand(sql, c);
                foreach (var (ten, giaTri) in thamSo) cmd.Parameters.AddWithValue(ten, giaTri);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
