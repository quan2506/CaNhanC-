using System;

namespace Practice5
{
    /// <summary>
    /// Bài mẫu: Quản lý Khoa – thao tác trên bảng Khoa(MaKhoa, TenKhoa) của CSDL QLSinhVien.
    /// Kế thừa FormQuanLy nên giao diện (2 ô nhập + 3 nút) đã được dựng sẵn ở lớp cha.
    /// </summary>
    public class QLKhoa : FormQuanLy
    {
        // base(...) truyền tiêu đề và 2 nhãn => lớp cha tạo 2 ô: Txt[0] = Mã khoa, Txt[1] = Tên khoa
        public QLKhoa() : base("Quản lý Khoa", "Mã khoa", "Tên khoa") { }

        // THÊM: nhập Mã khoa + Tên khoa => lưu vào bảng Khoa
        protected override void Them()
        {
            if (!BatBuoc(0, 1)) return;   // Cả hai ô đều phải có dữ liệu, nếu thiếu thì dừng
            // @ma, @ten là tham số: giá trị được truyền riêng, không nối vào chuỗi SQL
            Db.ThucThi("insert into Khoa(MaKhoa, TenKhoa) values(@ma, @ten)", ("@ma", Gt(0)), ("@ten", Gt(1)));
        }

        // XÓA: chỉ cần Mã khoa, xóa khoa có mã đó
        protected override void Xoa()
        {
            if (!BatBuoc(0)) return;
            Db.ThucThi("delete from Khoa where MaKhoa = @ma", ("@ma", Gt(0)));
        }

        // SỬA: tìm khoa theo Mã khoa, đổi Tên khoa thành tên vừa nhập
        protected override void Sua()
        {
            if (!BatBuoc(0, 1)) return;
            Db.ThucThi("update Khoa set TenKhoa = @ten where MaKhoa = @ma", ("@ma", Gt(0)), ("@ten", Gt(1)));
        }
    }
}
