using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Practice6
{
    /// <summary>
    /// Bài nâng cao 1: Quản lý sinh viên – bảng SinhVien(MaSinhVien, HoTen, NgaySinh, MaLop).
    /// </summary>
    public class QLSinhVien : FormQuanLy
    {
        private const int MALOP = 0, MASV = 1, HOTEN = 2, NGAYSINH = 3;

        public QLSinhVien() : base("Quản lý sinh viên", "Mã lớp", "Mã sv", "Họ tên", "Ngày sinh")
        {
            Txt[NGAYSINH].PlaceholderText = "dd/MM/yyyy";
        }

        private bool LayNgay(out DateTime ngay)
        {
            ngay = default;
            if (Gt(NGAYSINH) == "") return true;
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
            Db.ThucThiQL("insert into SinhVien(MaSinhVien, HoTen, NgaySinh, MaLop) values(@sv, @ten, @ns, @lop)",
                ("@sv", Gt(MASV)), ("@ten", Gt(HOTEN)), ("@ns", ngay), ("@lop", Gt(MALOP)));
        }

        // XÓA: bắt buộc Mã sv và Họ tên
        protected override void Xoa()
        {
            if (!BatBuoc(MASV, HOTEN)) return;
            Db.ThucThiQL("delete from SinhVien where MaSinhVien = @sv and HoTen = @ten",
                ("@sv", Gt(MASV)), ("@ten", Gt(HOTEN)));
        }

        // SỬA: bắt buộc Mã sv; các trường khác ít nhất 1 có dữ liệu
        protected override void Sua()
        {
            if (!BatBuoc(MASV) || !ItNhatMot(MALOP, HOTEN, NGAYSINH) || !LayNgay(out var ngay)) return;

            var set = new List<string>();
            var ps = new List<(string, object)> { ("@sv", Gt(MASV)) };
            if (Gt(MALOP) != "") { set.Add("MaLop = @lop"); ps.Add(("@lop", Gt(MALOP))); }
            if (Gt(HOTEN) != "") { set.Add("HoTen = @ten"); ps.Add(("@ten", Gt(HOTEN))); }
            if (Gt(NGAYSINH) != "") { set.Add("NgaySinh = @ns"); ps.Add(("@ns", ngay)); }

            Db.ThucThiQL($"update SinhVien set {string.Join(", ", set)} where MaSinhVien = @sv", ps.ToArray());
        }
    }
}
