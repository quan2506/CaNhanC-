using System;

namespace Practice5
{
    /// <summary>
    /// Bài tập tại lớp 1: Quản lý môn học – thao tác trên bảng MonHoc(MaMonHoc, TenMonHoc).
    /// </summary>
    public class QLMonHoc : FormQuanLy
    {
        // Txt[0] = Mã mh, Txt[1] = Tên mh
        public QLMonHoc() : base("Quản lý môn học", "Mã mh", "Tên mh") { }

        // THÊM: Mã môn học và Tên môn học đều không được để trống
        protected override void Them()
        {
            if (!BatBuoc(0, 1)) return;
            Db.ThucThi("insert into MonHoc(MaMonHoc, TenMonHoc) values(@ma, @ten)", ("@ma", Gt(0)), ("@ten", Gt(1)));
        }

        // XÓA: chỉ bắt buộc Mã môn học (đề: "Tên môn học không nhập dữ liệu")
        protected override void Xoa()
        {
            if (!BatBuoc(0)) return;
            Db.ThucThi("delete from MonHoc where MaMonHoc = @ma", ("@ma", Gt(0)));
        }

        // SỬA: đổi tên môn học theo mã môn học vừa nhập
        protected override void Sua()
        {
            if (!BatBuoc(0, 1)) return;
            Db.ThucThi("update MonHoc set TenMonHoc = @ten where MaMonHoc = @ma", ("@ma", Gt(0)), ("@ten", Gt(1)));
        }
    }
}
