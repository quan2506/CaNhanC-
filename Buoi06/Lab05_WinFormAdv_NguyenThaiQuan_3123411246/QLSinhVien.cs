using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>
    /// Bài nâng cao 1: Quản lý sinh viên – thao tác trên bảng SinhVien(MaSinhVien, HoTen, NgaySinh, MaLop).
    /// Ngày sinh nhập theo dạng dd/MM/yyyy.
    /// </summary>
    public class QLSinhVien : FormQuanLy
    {
        // Đặt tên cho chỉ số các ô để code dễ đọc (thay vì Gt(0), Gt(1)...)
        private const int MALOP = 0, MASV = 1, HOTEN = 2, NGAYSINH = 3;

        public QLSinhVien() : base("Quản lý sinh viên", "Mã lớp", "Mã sv", "Họ tên", "Ngày sinh")
        {
            Txt[NGAYSINH].PlaceholderText = "dd/MM/yyyy";   // Chữ mờ gợi ý định dạng nhập
        }

        /// <summary>
        /// Đọc ô Ngày sinh thành kiểu DateTime.
        /// Ô để trống => coi là hợp lệ (vì Xóa/Sửa có thể không nhập ngày sinh).
        /// Ô sai định dạng => báo lỗi và trả false.
        /// </summary>
        private bool LayNgay(out DateTime ngay)
        {
            ngay = default;
            if (Gt(NGAYSINH) == "") return true;
            // TryParseExact: chỉ chấp nhận đúng định dạng d/M/yyyy, tránh nhầm giữa tháng và ngày
            if (DateTime.TryParseExact(Gt(NGAYSINH), new[] { "d/M/yyyy", "dd/MM/yyyy" },
                CultureInfo.InvariantCulture, DateTimeStyles.None, out ngay)) return true;
            MessageBox.Show("Ngày sinh không hợp lệ (định dạng dd/MM/yyyy)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Txt[NGAYSINH].Focus();
            return false;
        }

        // THÊM: cả 4 thông tin đều bắt buộc
        protected override void Them()
        {
            if (!BatBuoc(MALOP, MASV, HOTEN, NGAYSINH) || !LayNgay(out var ngay)) return;
            Db.ThucThi("insert into SinhVien(MaSinhVien, HoTen, NgaySinh, MaLop) values(@sv, @ten, @ns, @lop)",
                ("@sv", Gt(MASV)), ("@ten", Gt(HOTEN)), ("@ns", ngay), ("@lop", Gt(MALOP)));
        }

        // XÓA: bắt buộc Mã sv và Họ tên; chỉ xóa sinh viên khớp CẢ HAI thông tin (mã và tên trùng)
        protected override void Xoa()
        {
            if (!BatBuoc(MASV, HOTEN)) return;   // Mã lớp, Ngày sinh không cần nhập
            Db.ThucThi("delete from SinhVien where MaSinhVien = @sv and HoTen = @ten",
                ("@sv", Gt(MASV)), ("@ten", Gt(HOTEN)));
        }

        // SỬA: bắt buộc Mã sv; trong Mã lớp / Họ tên / Ngày sinh phải có ít nhất một ô có dữ liệu.
        // Ô nào không nhập thì giữ nguyên giá trị cũ => câu UPDATE chỉ chứa các cột có nhập dữ liệu.
        protected override void Sua()
        {
            if (!BatBuoc(MASV) || !ItNhatMot(MALOP, HOTEN, NGAYSINH) || !LayNgay(out var ngay)) return;

            var set = new List<string>();                                    // Các đoạn "Cột = @tham số"
            var ps = new List<(string, object)> { ("@sv", Gt(MASV)) };       // Danh sách tham số
            if (Gt(MALOP) != "") { set.Add("MaLop = @lop"); ps.Add(("@lop", Gt(MALOP))); }
            if (Gt(HOTEN) != "") { set.Add("HoTen = @ten"); ps.Add(("@ten", Gt(HOTEN))); }
            if (Gt(NGAYSINH) != "") { set.Add("NgaySinh = @ns"); ps.Add(("@ns", ngay)); }

            // Ví dụ kết quả: update SinhVien set MaLop = @lop, HoTen = @ten where MaSinhVien = @sv
            Db.ThucThi($"update SinhVien set {string.Join(", ", set)} where MaSinhVien = @sv", ps.ToArray());
        }
    }
}
