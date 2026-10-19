using System;
using System.Collections.Generic;

namespace Practice6
{
    /// <summary>
    /// Bài tập về nhà 1: Quản lý Lớp – bảng Lop(MaLop, TenLop, MaKhoa).
    /// MaKhoa là khóa ngoại tham chiếu bảng Khoa.
    /// </summary>
    public class QLLop : FormQuanLy
    {
        private const int MAKHOA = 0, MALOP = 1, TENLOP = 2;

        public QLLop() : base("frmLop", "Mã khoa", "Mã lớp", "Tên lớp") { }

        // THÊM: Mã khoa, Mã lớp, Tên lớp đều bắt buộc
        protected override void Them()
        {
            if (!BatBuoc(MAKHOA, MALOP, TENLOP)) return;
            Db.ThucThiQL("insert into Lop(MaLop, TenLop, MaKhoa) values(@lop, @ten, @khoa)",
                ("@lop", Gt(MALOP)), ("@ten", Gt(TENLOP)), ("@khoa", Gt(MAKHOA)));
        }

        // XÓA: chỉ cần Mã lớp
        protected override void Xoa()
        {
            if (!BatBuoc(MALOP)) return;
            Db.ThucThiQL("delete from Lop where MaLop = @lop", ("@lop", Gt(MALOP)));
        }

        // SỬA: bắt buộc Mã lớp; Mã khoa / Tên lớp ít nhất 1 có dữ liệu
        protected override void Sua()
        {
            if (!BatBuoc(MALOP) || !ItNhatMot(MAKHOA, TENLOP)) return;
            var set = new List<string>();
            var ps = new List<(string, object)> { ("@lop", Gt(MALOP)) };
            if (Gt(MAKHOA) != "") { set.Add("MaKhoa = @khoa"); ps.Add(("@khoa", Gt(MAKHOA))); }
            if (Gt(TENLOP) != "") { set.Add("TenLop = @ten"); ps.Add(("@ten", Gt(TENLOP))); }
            Db.ThucThiQL($"update Lop set {string.Join(", ", set)} where MaLop = @lop", ps.ToArray());
        }
    }
}
