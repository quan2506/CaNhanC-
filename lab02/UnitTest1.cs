/*
 * ============================================================
 * UNIT TEST - CHƯƠNG 2: THỰC HÀNH NHẬP XUẤT DỮ LIỆU
 * ============================================================
 * Framework: xUnit
 * Cách chạy: cd Buoi2/Buoi2.Tests && dotnet test
 * ============================================================
 *
 * GIẢI THÍCH UNIT TEST:
 *
 * Unit test (kiểm thử đơn vị) là gì?
 * - Kiểm tra từng phương thức/lớp một cách TỰ ĐỘNG
 * - Dùng framework chuyên dụng (xUnit, NUnit, MSTest)
 * - Chạy bằng lệnh "dotnet test" thay vì "dotnet run"
 *
 * Cấu trúc 1 test case (mẫu AAA):
 *   Arrange: Chuẩn bị dữ liệu đầu vào
 *   Act:     Gọi phương thức cần test
 *   Assert:  Kiểm tra kết quả có đúng mong đợi không
 *
 * Các attribute quan trọng:
 *   [Fact]         : Đánh dấu 1 test case cố định
 *   [Theory]       : Test case chạy nhiều lần với dữ liệu khác nhau
 *   [InlineData]   : Cung cấp dữ liệu cho [Theory]
 *
 * Các phương thức Assert phổ biến:
 *   Assert.Equal(expected, actual)  : Kiểm tra bằng nhau
 *   Assert.True(condition)          : Kiểm tra điều kiện đúng
 *   Assert.False(condition)         : Kiểm tra điều kiện sai
 *   Assert.Throws<Exception>(...)   : Kiểm tra ném ngoại lệ
 * ============================================================
 */

using LTCsharp.Buoi2;

namespace Buoi2.Tests
{
    // Bài 2: Xuất và nhập chuỗi
    public class NhapXuatChuoiTests
    {
        [Fact]
        public void ChaoHoi_TraVeDungDinhDang()
        {
            NhapXuatChuoi nxc = new NhapXuatChuoi();
            Assert.Equal("Chao ban Tran Anh Minh!", nxc.ChaoHoi("Tran Anh Minh"));
        }

        [Theory]
        [InlineData("Nguyen Van A", "Chao ban Nguyen Van A!")]
        [InlineData("", "Chao ban !")]
        [InlineData("Test", "Chao ban Test!")]
        public void ChaoHoi_NhieuTen(string ten, string mongDoi)
        {
            Assert.Equal(mongDoi, new NhapXuatChuoi().ChaoHoi(ten));
        }
    }

    // Bài 3: Tính x^y
    public class TinhLuyThuaTests
    {
        [Theory]
        [InlineData(7, 3, 343)]
        [InlineData(2, 10, 1024)]
        [InlineData(5, 0, 1)]
        [InlineData(0, 5, 0)]
        [InlineData(1, 100, 1)]
        [InlineData(-2, 3, -8)]
        public void TinhXMuY_TinhDung(int x, int y, long mongDoi)
        {
            TinhLuyThua tlt = new TinhLuyThua();
            Assert.Equal(mongDoi, tlt.TinhXMuY(x, y));
        }
    }

    // Bài 4: Kiểm tra nhập số an toàn
    public class TinhLuyThuaSafeTests
    {
        [Theory]
        [InlineData("123", true, 123)]
        [InlineData("0", true, 0)]
        [InlineData("-5", true, -5)]
        [InlineData("abc", false, 0)]
        [InlineData("12.5", false, 0)]
        [InlineData("", false, 0)]
        public void ThuParse_KiemTraDung(string input, bool hopLe, int giaTriMongDoi)
        {
            TinhLuyThuaSafe safe = new TinhLuyThuaSafe();
            bool ketQua = safe.ThuParse(input, out int giaTri);
            Assert.Equal(hopLe, ketQua);
            if (hopLe) Assert.Equal(giaTriMongDoi, giaTri);
        }
    }

    // Bài 5: Menu tính toán
    public class MenuTinhToanTests
    {
        [Fact]
        public void SetXY_GanDungGiaTri()
        {
            MenuTinhToan menu = new MenuTinhToan();
            menu.SetXY(3.0, 4.0);
            Assert.Equal(3.0, menu.GetX());
            Assert.Equal(4.0, menu.GetY());
        }

        [Theory]
        [InlineData(2, 3, 8)]
        [InlineData(5, 2, 25)]
        [InlineData(10, 0, 1)]
        public void TinhXMuY_TinhDung(double x, double y, double mongDoi)
        {
            MenuTinhToan menu = new MenuTinhToan();
            menu.SetXY(x, y);
            Assert.Equal(mongDoi, menu.TinhXMuY(), precision: 4);
        }

        [Theory]
        [InlineData(4, 2)]
        [InlineData(9, 3)]
        [InlineData(16, 4)]
        [InlineData(0, 0)]
        public void CanX_TinhDung(double x, double mongDoi)
        {
            MenuTinhToan menu = new MenuTinhToan();
            menu.SetXY(x, 0);
            Assert.Equal(mongDoi, menu.CanX(), precision: 4);
        }

        [Fact]
        public void CanY_TinhDung()
        {
            MenuTinhToan menu = new MenuTinhToan();
            menu.SetXY(0, 25);
            Assert.Equal(5, menu.CanY(), precision: 4);
        }
    }

    public class TimMaxTests
    {
        // ----- Test phương thức Max3 -----

        // [Fact]: đánh dấu đây là 1 test case
        // Tên phương thức theo quy ước: TenPhuongThuc_TinhHuong_KetQuaMongDoi
        [Fact]
        public void Max3_BaSoKhacNhau_TraVeSoLonNhat()
        {
            // Arrange: chuẩn bị
            TimMax tm = new TimMax();

            // Act: thực hiện
            int ketQua = tm.Max3(3, 7, 5);

            // Assert: kiểm tra kết quả
            Assert.Equal(7, ketQua);
        }

        // [Theory] + [InlineData]: chạy cùng 1 test với nhiều bộ dữ liệu
        // Mỗi [InlineData] là 1 lần chạy test với dữ liệu khác nhau
        [Theory]
        [InlineData(3, 7, 5, 7)]       // Max(3,7,5) = 7
        [InlineData(10, 2, 8, 10)]     // Max(10,2,8) = 10
        [InlineData(1, 1, 1, 1)]       // 3 số bằng nhau
        [InlineData(-1, -5, -3, -1)]   // Số âm
        [InlineData(-10, 0, 5, 5)]     // Số âm và dương
        [InlineData(0, 0, 0, 0)]       // Tất cả = 0
        public void Max3_NhieuTruongHop_TraVeDung(int a, int b, int c, int mongDoi)
        {
            // Arrange
            TimMax tm = new TimMax();

            // Act
            int ketQua = tm.Max3(a, b, c);

            // Assert
            Assert.Equal(mongDoi, ketQua);
        }

        // ----- Test phương thức MaxNhieu (params) -----

        [Fact]
        public void MaxNhieu_NhieuSo_TraVeSoLonNhat()
        {
            TimMax tm = new TimMax();

            // params cho phép truyền số lượng tham số tùy ý
            Assert.Equal(8, tm.MaxNhieu(1, 5, 3, 8, 2));
        }

        [Fact]
        public void MaxNhieu_MotSo_TraVeChinhNo()
        {
            TimMax tm = new TimMax();
            Assert.Equal(42, tm.MaxNhieu(42));
        }

        [Fact]
        public void MaxNhieu_SoAm_TraVeSoLonNhat()
        {
            TimMax tm = new TimMax();
            Assert.Equal(-1, tm.MaxNhieu(-3, -1, -7, -2));
        }

        // Test trường hợp ngoại lệ: mảng rỗng phải ném exception
        [Fact]
        public void MaxNhieu_MangRong_NemException()
        {
            TimMax tm = new TimMax();

            // Assert.Throws: kiểm tra phương thức có ném exception không
            Assert.Throws<ArgumentException>(() => tm.MaxNhieu());
        }
    }

    // =================================================================
    // TEST BÀI 7: KIỂM TRA SỐ NGUYÊN TỐ
    // =================================================================
    public class SoNguyenToTests
    {
        // [Theory] với nhiều [InlineData]: cách test hiệu quả nhất
        // Mỗi dòng InlineData là 1 test case riêng biệt
        [Theory]
        [InlineData(2, true)]       // 2 là số nguyên tố nhỏ nhất
        [InlineData(3, true)]       // 3 là số nguyên tố
        [InlineData(5, true)]
        [InlineData(7, true)]
        [InlineData(11, true)]
        [InlineData(13, true)]
        [InlineData(97, true)]      // Số nguyên tố lớn
        public void KiemTra_SoNguyenTo_TraVeTrue(int n, bool mongDoi)
        {
            SoNguyenTo snt = new SoNguyenTo();
            Assert.Equal(mongDoi, snt.KiemTra(n));
        }

        [Theory]
        [InlineData(0, false)]      // 0 không phải NT
        [InlineData(1, false)]      // 1 không phải NT
        [InlineData(4, false)]      // 4 = 2 × 2
        [InlineData(9, false)]      // 9 = 3 × 3
        [InlineData(10, false)]     // 10 = 2 × 5
        [InlineData(100, false)]    // 100 = 10 × 10
        [InlineData(-5, false)]     // Số âm không phải NT
        public void KiemTra_KhongPhaiNguyenTo_TraVeFalse(int n, bool mongDoi)
        {
            SoNguyenTo snt = new SoNguyenTo();
            Assert.Equal(mongDoi, snt.KiemTra(n));
        }
    }

    // =================================================================
    // TEST BÀI 8: HOÁN VỊ HAI SỐ (ref)
    // =================================================================
    public class HoanViTests
    {
        [Fact]
        public void Swap_HaiSoKhacNhau_DoiChoThanhCong()
        {
            // Arrange
            HoanVi hv = new HoanVi();
            double a = 3.5, b = 7.2;

            // Act - truyền ref để thay đổi giá trị gốc
            hv.Swap(ref a, ref b);

            // Assert - kiểm tra a, b đã đổi chỗ
            Assert.Equal(7.2, a, precision: 2);  // precision: số chữ số thập phân so sánh
            Assert.Equal(3.5, b, precision: 2);
        }

        [Fact]
        public void Swap_HaiSoBangNhau_GiuNguyen()
        {
            HoanVi hv = new HoanVi();
            double a = 5.0, b = 5.0;

            hv.Swap(ref a, ref b);

            Assert.Equal(5.0, a);
            Assert.Equal(5.0, b);
        }

        [Fact]
        public void Swap_SoAm_DoiChoThanhCong()
        {
            HoanVi hv = new HoanVi();
            double a = -3.14, b = 2.71;

            hv.Swap(ref a, ref b);

            Assert.Equal(2.71, a, precision: 2);
            Assert.Equal(-3.14, b, precision: 2);
        }
    }

    // =================================================================
    // TEST BÀI 9: TÌM MIN MAX (out)
    // =================================================================
    public class TimMinMaxTests
    {
        [Fact]
        public void Tim_BaSoDuong_TimDungMaxMin()
        {
            // Arrange
            TimMinMax tmm = new TimMinMax();

            // Act - dùng out để nhận nhiều giá trị trả về
            tmm.Tim(5, 2, 8, out double max, out double min);

            // Assert
            Assert.Equal(8, max);
            Assert.Equal(2, min);
        }

        [Fact]
        public void Tim_BaSoAm_TimDungMaxMin()
        {
            TimMinMax tmm = new TimMinMax();

            tmm.Tim(-3, -1, -7, out double max, out double min);

            Assert.Equal(-1, max);
            Assert.Equal(-7, min);
        }

        [Fact]
        public void Tim_BaSoBangNhau_MaxBangMin()
        {
            TimMinMax tmm = new TimMinMax();

            tmm.Tim(4, 4, 4, out double max, out double min);

            Assert.Equal(4, max);
            Assert.Equal(4, min);
        }

        [Fact]
        public void Tim_SoThuc_TimDungMaxMin()
        {
            TimMinMax tmm = new TimMinMax();

            tmm.Tim(1.5, 3.7, 2.1, out double max, out double min);

            Assert.Equal(3.7, max);
            Assert.Equal(1.5, min);
        }
    }

    // =================================================================
    // TEST BÀI 10: CHUỖI ĐỐI XỨNG (Palindrome)
    // =================================================================
    public class KiemTraDoiXungTests
    {
        [Theory]
        [InlineData("abcba", true)]     // Lẻ ký tự, đối xứng
        [InlineData("abba", true)]      // Chẵn ký tự, đối xứng
        [InlineData("a", true)]         // 1 ký tự
        [InlineData("racecar", true)]   // Từ đối xứng tiếng Anh
        [InlineData("", true)]          // Chuỗi rỗng
        [InlineData("AbBa", true)]      // Không phân biệt hoa/thường
        [InlineData("abc", false)]      // Không đối xứng
        [InlineData("hello", false)]    // Không đối xứng
        [InlineData("ab", false)]       // 2 ký tự khác nhau
        public void KiemTraDoiXung_NhieuTruongHop(string chuoi, bool mongDoi)
        {
            XuLyChuoi xlc = new XuLyChuoi();
            Assert.Equal(mongDoi, xlc.KiemTraDoiXung(chuoi));
        }
    }

    // =================================================================
    // TEST BÀI 11: ĐẢO CHUỖI
    // =================================================================
    public class DaoChuoiTests
    {
        [Theory]
        [InlineData("Hello", "olleH")]
        [InlineData("abcba", "abcba")]  // Chuỗi đối xứng → đảo = chính nó
        [InlineData("", "")]            // Chuỗi rỗng
        [InlineData("A", "A")]          // 1 ký tự
        [InlineData("12345", "54321")]  // Chuỗi số
        public void DaoChuoi_NhieuTruongHop(string dauVao, string mongDoi)
        {
            XuLyChuoi xlc = new XuLyChuoi();
            Assert.Equal(mongDoi, xlc.DaoChuoi(dauVao));
        }
    }

    // =================================================================
    // TEST BÀI 12: CÁC THAO TÁC TRÊN CHUỖI
    // =================================================================
    public class ThaoTacChuoiTests
    {
        [Theory]
        [InlineData("Hello World", "hello world")]
        [InlineData("ABC", "abc")]
        [InlineData("already lower", "already lower")]
        public void ChuyenThuong_TraVeChuThuong(string dauVao, string mongDoi)
        {
            XuLyChuoi xlc = new XuLyChuoi();
            Assert.Equal(mongDoi, xlc.ChuyenThuong(dauVao));
        }

        [Theory]
        [InlineData("Hello World", "HELLO WORLD")]
        [InlineData("abc", "ABC")]
        public void ChuyenHoa_TraVeChuHoa(string dauVao, string mongDoi)
        {
            XuLyChuoi xlc = new XuLyChuoi();
            Assert.Equal(mongDoi, xlc.ChuyenHoa(dauVao));
        }

        [Theory]
        [InlineData("Xin chao ban", 3)]
        [InlineData("Mot", 1)]
        [InlineData("  Nhieu   khoang   trang  ", 3)]  // Nhiều khoảng trắng
        [InlineData("A B C D E", 5)]
        public void DemSoTu_DemDungSoTu(string dauVao, int mongDoi)
        {
            XuLyChuoi xlc = new XuLyChuoi();
            Assert.Equal(mongDoi, xlc.DemSoTu(dauVao));
        }
    }

    // =================================================================
    // TEST BÀI 13: LỚP SINH VIÊN
    // =================================================================
    public class SinhVienTests
    {
        [Fact]
        public void Constructor_CoThamSo_GanDungGiaTri()
        {
            // Arrange & Act
            SinhVien sv = new SinhVien("SV001", "Nguyen Van A", "TP.HCM", 2);

            // Assert - kiểm tra tất cả field được gán đúng
            Assert.Equal("SV001", sv.GetMaSV());
            Assert.Equal("Nguyen Van A", sv.GetHoTen());
            Assert.Equal("TP.HCM", sv.GetDiaChi());
            Assert.Equal(2, sv.GetNamThu());
        }

        [Fact]
        public void Constructor_MacDinh_GanGiaTriMacDinh()
        {
            SinhVien sv = new SinhVien();

            Assert.Equal("", sv.GetMaSV());
            Assert.Equal("", sv.GetHoTen());
            Assert.Equal("", sv.GetDiaChi());
            Assert.Equal(1, sv.GetNamThu());
        }

        [Fact]
        public void ToString_ChuaCacThongTin()
        {
            SinhVien sv = new SinhVien("SV001", "Nguyen Van A", "TP.HCM", 2);
            string str = sv.ToString();

            // Assert.Contains: kiểm tra chuỗi có chứa chuỗi con
            Assert.Contains("SV001", str);
            Assert.Contains("Nguyen Van A", str);
        }
    }

    // =================================================================
    // TEST BÀI 14: TÍNH LƯƠNG NHÂN VIÊN
    // =================================================================
    public class NhanVienTests
    {
        [Theory]
        [InlineData(10000000, 2, 9800000)]    // 10tr - 2×100k = 9.8tr
        [InlineData(5000000, 0, 5000000)]     // Không vắng → lương giữ nguyên
        [InlineData(8000000, 1, 7900000)]     // 8tr - 1×100k = 7.9tr
        [InlineData(500000, 10, 0)]           // 500k - 10×100k = -500k → tối thiểu = 0
        [InlineData(1000000, 10, 0)]          // 1tr - 10×100k = 0
        public void TinhLuong_NhieuTruongHop_TinhDung(
            double mucLuong, int soNgayVang, double luongMongDoi)
        {
            // Arrange
            NhanVien nv = new NhanVien("Test", mucLuong, soNgayVang);

            // Act
            double luongThuc = nv.TinhLuong();

            // Assert
            Assert.Equal(luongMongDoi, luongThuc);
        }

        [Fact]
        public void Constructor_LuuDungThongTin()
        {
            NhanVien nv = new NhanVien("Tran B", 10000000, 2);

            Assert.Equal("Tran B", nv.GetHoTen());
            Assert.Equal(10000000, nv.GetMucLuong());
            Assert.Equal(2, nv.GetSoNgayVang());
        }
    }

    // =================================================================
    // TEST BÀI 15: MẢNG 1 CHIỀU
    // =================================================================
    public class XuLyMangTests
    {
        [Fact]
        public void TimMaxMin_MangNhieuPhanTu_TimDung()
        {
            // Arrange
            int[] data = { 7, 2, 11, 4, 13, 6, 3 };
            XuLyMang xlm = new XuLyMang(data);

            // Act
            xlm.TimMaxMin(out int max, out int min);

            // Assert
            Assert.Equal(13, max);
            Assert.Equal(2, min);
        }

        [Fact]
        public void TimMaxMin_MangMotPhanTu_MaxBangMin()
        {
            XuLyMang xlm = new XuLyMang(new int[] { 17 });

            xlm.TimMaxMin(out int max, out int min);

            Assert.Equal(17, max);
            Assert.Equal(17, min);
        }

        [Fact]
        public void TimMaxMin_MangRong_NemException()
        {
            XuLyMang xlm = new XuLyMang(new int[0]);

            // Mảng rỗng phải ném exception
            Assert.Throws<InvalidOperationException>(() =>
                xlm.TimMaxMin(out int max, out int min));
        }

        [Fact]
        public void LayMangSoNguyenTo_CoSoNT_TraVeDung()
        {
            // Mảng {7, 2, 11, 4, 13, 6, 3}
            // Số NT: {7, 2, 11, 13, 3}
            int[] data = { 7, 2, 11, 4, 13, 6, 3 };
            XuLyMang xlm = new XuLyMang(data);

            int[] nt = xlm.LayMangSoNguyenTo();

            Assert.Equal(5, nt.Length);
            Assert.Equal(new int[] { 7, 2, 11, 13, 3 }, nt);
        }

        [Fact]
        public void LayMangSoNguyenTo_KhongCoNT_TraVeMangRong()
        {
            int[] data = { 4, 6, 8, 9, 10 };
            XuLyMang xlm = new XuLyMang(data);

            int[] nt = xlm.LayMangSoNguyenTo();

            Assert.Empty(nt);  // Assert.Empty: kiểm tra mảng/collection rỗng
        }
    }

    // =================================================================
    // TEST BÀI 17: MẢNG 2 CHIỀU
    // =================================================================
    public class XuLyMang2DTests
    {
        [Fact]
        public void SinhNgauNhien_TatCaPhanTuTrongKhoang10Den100()
        {
            // Arrange
            XuLyMang2D xlm2d = new XuLyMang2D(3, 4);

            // Act - dùng seed cố định để kết quả lặp lại được
            xlm2d.SinhNgauNhien(42);

            // Assert
            int[,] m = xlm2d.GetMang();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    // Assert.InRange: kiểm tra giá trị nằm trong khoảng
                    Assert.InRange(m[i, j], 10, 100);
                }
            }
        }

        [Fact]
        public void TachChanLe_TongBangTongPhanTu()
        {
            XuLyMang2D xlm2d = new XuLyMang2D(3, 4);
            xlm2d.SinhNgauNhien(42);

            xlm2d.TachChanLe(out int[] mangChan, out int[] mangLe);

            // Tổng chẵn + lẻ phải = tổng phần tử (3 × 4 = 12)
            Assert.Equal(12, mangChan.Length + mangLe.Length);
        }

        [Fact]
        public void TachChanLe_MangChan_TatCaDeuChan()
        {
            XuLyMang2D xlm2d = new XuLyMang2D(3, 4);
            xlm2d.SinhNgauNhien(42);

            xlm2d.TachChanLe(out int[] mangChan, out int[] mangLe);

            // Assert.All: kiểm tra TẤT CẢ phần tử đều thỏa điều kiện
            Assert.All(mangChan, so => Assert.Equal(0, so % 2));
        }

        [Fact]
        public void TachChanLe_MangLe_TatCaDeuLe()
        {
            XuLyMang2D xlm2d = new XuLyMang2D(3, 4);
            xlm2d.SinhNgauNhien(42);

            xlm2d.TachChanLe(out int[] mangChan, out int[] mangLe);

            Assert.All(mangLe, so => Assert.NotEqual(0, so % 2));
        }

        [Fact]
        public void Constructor_KichThuocDung()
        {
            XuLyMang2D xlm2d = new XuLyMang2D(5, 3);

            Assert.Equal(5, xlm2d.GetDong());
            Assert.Equal(3, xlm2d.GetCot());
        }
    }
}
