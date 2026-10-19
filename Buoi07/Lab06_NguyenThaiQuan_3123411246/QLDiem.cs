using System;
using System.Windows.Forms;

namespace Practice6
{
    /// <summary>
    /// Bài nâng cao 2: Quản lý Điểm – bảng Diem(MaSinhVien, MaMonHoc, Diem).
    /// Khóa chính ghép (MaSinhVien + MaMonHoc).
    /// Điểm phải là số và chỉ được nhập số.
    /// </summary>
    public class QLDiem : FormQuanLy
    {
        private const int MASV = 0, MAMH = 1, DIEM = 2;

        public QLDiem() : base("Quản lý Điểm", "Mã sv", "Mã mh", "Điểm")
        {
            // Chỉ cho phép nhập số và dấu chấm vào ô Điểm
            Txt[DIEM].KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
            };
        }

        private bool LayDiem(out double diem)
        {
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
            Db.ThucThiQL("insert into Diem(MaSinhVien, MaMonHoc, Diem) values(@sv, @mh, @d)",
                ("@sv", Gt(MASV)), ("@mh", Gt(MAMH)), ("@d", d));
        }

        // XÓA: bắt buộc Mã sv và Mã mh
        protected override void Xoa()
        {
            if (!BatBuoc(MASV, MAMH)) return;
            Db.ThucThiQL("delete from Diem where MaSinhVien = @sv and MaMonHoc = @mh",
                ("@sv", Gt(MASV)), ("@mh", Gt(MAMH)));
        }

        // SỬA: đổi điểm theo mã sv + mã mh
        protected override void Sua()
        {
            if (!BatBuoc(MASV, MAMH, DIEM) || !LayDiem(out var d)) return;
            Db.ThucThiQL("update Diem set Diem = @d where MaSinhVien = @sv and MaMonHoc = @mh",
                ("@sv", Gt(MASV)), ("@mh", Gt(MAMH)), ("@d", d));
        }
    }
}
