using System;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>
    /// Bài nâng cao 2: Quản lý Điểm – thao tác trên bảng Diem(MaSinhVien, MaMonHoc, Diem).
    /// Bảng Diem có KHÓA CHÍNH GHÉP (MaSinhVien + MaMonHoc) nên điều kiện where luôn phải có cả hai.
    /// </summary>
    public class QLDiem : FormQuanLy
    {
        private const int MASV = 0, MAMH = 1, DIEM = 2;   // Chỉ số các ô nhập

        public QLDiem() : base("Quản lý Điểm", "Mã sv", "Mã mh", "Điểm")
        {
            // Sự kiện KeyPress: chạy mỗi khi gõ một phím vào ô Điểm.
            // Chỉ cho phép chữ số, dấu chấm và phím điều khiển (Backspace...). Phím khác bị chặn (e.Handled = true).
            Txt[DIEM].KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
            };
        }

        /// <summary>Đọc ô Điểm thành số thực; yêu cầu là số trong khoảng 0 đến 10, nếu không thì báo lỗi.</summary>
        private bool LayDiem(out double diem)
        {
            // InvariantCulture: dùng dấu chấm làm dấu thập phân, không phụ thuộc cài đặt vùng của Windows
            if (double.TryParse(Gt(DIEM), System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture, out diem) && diem >= 0 && diem <= 10) return true;
            MessageBox.Show("Điểm phải là số từ 0 đến 10!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Txt[DIEM].Focus();
            return false;
        }

        // THÊM: Mã sv, Mã mh, Điểm đều bắt buộc
        protected override void Them()
        {
            if (!BatBuoc(MASV, MAMH, DIEM) || !LayDiem(out var d)) return;
            Db.ThucThi("insert into Diem(MaSinhVien, MaMonHoc, Diem) values(@sv, @mh, @d)",
                ("@sv", Gt(MASV)), ("@mh", Gt(MAMH)), ("@d", d));
        }

        // XÓA: chỉ bắt buộc Mã sv và Mã mh (Điểm không cần nhập); xóa đúng 1 dòng theo khóa chính ghép
        protected override void Xoa()
        {
            if (!BatBuoc(MASV, MAMH)) return;
            Db.ThucThi("delete from Diem where MaSinhVien = @sv and MaMonHoc = @mh",
                ("@sv", Gt(MASV)), ("@mh", Gt(MAMH)));
        }

        // SỬA: đổi điểm của sinh viên theo môn học; Điểm phải nhập và phải là số
        protected override void Sua()
        {
            if (!BatBuoc(MASV, MAMH, DIEM) || !LayDiem(out var d)) return;
            Db.ThucThi("update Diem set Diem = @d where MaSinhVien = @sv and MaMonHoc = @mh",
                ("@sv", Gt(MASV)), ("@mh", Gt(MAMH)), ("@d", d));
        }
    }
}
