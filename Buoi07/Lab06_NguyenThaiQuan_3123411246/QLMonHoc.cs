using System;

namespace Practice6
{
    /// <summary>
    /// Bài tập tại lớp 1: Quản lý môn học – bảng MonHoc(MaMonHoc, TenMonHoc).
    /// </summary>
    public class QLMonHoc : FormQuanLy
    {
        public QLMonHoc() : base("Quản lý môn học", "Mã mh", "Tên mh") { }

        protected override void Them()
        {
            if (!BatBuoc(0, 1)) return;
            Db.ThucThiQL("insert into MonHoc(MaMonHoc, TenMonHoc) values(@ma, @ten)", ("@ma", Gt(0)), ("@ten", Gt(1)));
        }

        protected override void Xoa()
        {
            if (!BatBuoc(0)) return;
            Db.ThucThiQL("delete from MonHoc where MaMonHoc = @ma", ("@ma", Gt(0)));
        }

        protected override void Sua()
        {
            if (!BatBuoc(0, 1)) return;
            Db.ThucThiQL("update MonHoc set TenMonHoc = @ten where MaMonHoc = @ma", ("@ma", Gt(0)), ("@ten", Gt(1)));
        }
    }
}
