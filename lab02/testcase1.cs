/*
 * ============================================================
 * TEST CASE - THỰC HÀNH 1: THỰC HÀNH NHẬP XUẤT DỮ LIỆU
 * ============================================================
 * Tác giả : Nguyễn Trường Thành
 * Ngày viết: 15/9/2026
 * Cách chạy: cd Buoi2 && dotnet run
 * ============================================================
 * File này chạy test tự động cho các bài tập có logic tính toán
 * (không test các bài cần nhập từ bàn phím)
 * ============================================================
 */

using System;
using LTCsharp.Buoi2;

namespace LTCsharp.Test
{
    class TestChuong2
    {
        // Biến đếm số test pass và tổng số test
        static int pass = 0, total = 0;

        // Hàm kiểm tra kết quả số thực
        static void KiemTra(string tenTest, double ketQua, double mongDoi, double saiSo = 0.01)
        {
            total++;
            bool dung = (Math.Abs(ketQua - mongDoi) <= saiSo);
            if (dung) pass++;
            Console.WriteLine("  {0}: {1} (mong doi: {2}) => {3}",
                tenTest, ketQua, mongDoi, dung ? "PASS" : "FAIL");
        }

        // Hàm kiểm tra kết quả số nguyên
        static void KiemTra(string tenTest, int ketQua, int mongDoi)
        {
            total++;
            bool dung = (ketQua == mongDoi);
            if (dung) pass++;
            Console.WriteLine("  {0}: {1} (mong doi: {2}) => {3}",
                tenTest, ketQua, mongDoi, dung ? "PASS" : "FAIL");
        }

        // Hàm kiểm tra kết quả chuỗi
        static void KiemTra(string tenTest, string ketQua, string mongDoi)
        {
            total++;
            bool dung = (ketQua == mongDoi);
            if (dung) pass++;
            Console.WriteLine("  {0}: '{1}' (mong doi: '{2}') => {3}",
                tenTest, ketQua, mongDoi, dung ? "PASS" : "FAIL");
        }

        // Hàm kiểm tra kết quả bool
        static void KiemTra(string tenTest, bool ketQua, bool mongDoi)
        {
            total++;
            bool dung = (ketQua == mongDoi);
            if (dung) pass++;
            Console.WriteLine("  {0}: {1} (mong doi: {2}) => {3}",
                tenTest, ketQua, mongDoi, dung ? "PASS" : "FAIL");
        }

        // =============================================================
        // TEST BÀI 6: TÌM GIÁ TRỊ LỚN NHẤT
        // =============================================================
        static void TestBai6_TimMax()
        {
            Console.WriteLine("--- Test Bai 6: Tim Max ---");
            TimMax tm = new TimMax();

            // Test Max3 cơ bản
            KiemTra("6.1 Max(3,7,5)", tm.Max3(3, 7, 5), 7);
            KiemTra("6.2 Max(10,2,8)", tm.Max3(10, 2, 8), 10);
            KiemTra("6.3 Max(1,1,1)", tm.Max3(1, 1, 1), 1);

            // Test với số âm
            KiemTra("6.4 Max(-1,-5,-3)", tm.Max3(-1, -5, -3), -1);
            KiemTra("6.5 Max(-10,0,5)", tm.Max3(-10, 0, 5), 5);

            // Test MaxNhieu (params)
            KiemTra("6.6 MaxNhieu(1,5,3,8,2)", tm.MaxNhieu(1, 5, 3, 8, 2), 8);
            KiemTra("6.7 MaxNhieu(42)", tm.MaxNhieu(42), 42);
            KiemTra("6.8 MaxNhieu(-3,-1,-7,-2)", tm.MaxNhieu(-3, -1, -7, -2), -1);

            Console.WriteLine();
        }

        // =============================================================
        // TEST BÀI 7: KIỂM TRA SỐ NGUYÊN TỐ
        // =============================================================
        static void TestBai7_SoNguyenTo()
        {
            Console.WriteLine("--- Test Bai 7: So Nguyen To ---");
            SoNguyenTo snt = new SoNguyenTo();

            // Số nguyên tố
            KiemTra("7.1 KiemTra(2)", snt.KiemTra(2), true);
            KiemTra("7.2 KiemTra(3)", snt.KiemTra(3), true);
            KiemTra("7.3 KiemTra(7)", snt.KiemTra(7), true);
            KiemTra("7.4 KiemTra(13)", snt.KiemTra(13), true);
            KiemTra("7.5 KiemTra(97)", snt.KiemTra(97), true);

            // Không phải số nguyên tố
            KiemTra("7.6 KiemTra(1)", snt.KiemTra(1), false);
            KiemTra("7.7 KiemTra(0)", snt.KiemTra(0), false);
            KiemTra("7.8 KiemTra(-5)", snt.KiemTra(-5), false);
            KiemTra("7.9 KiemTra(4)", snt.KiemTra(4), false);
            KiemTra("7.10 KiemTra(10)", snt.KiemTra(10), false);
            KiemTra("7.11 KiemTra(100)", snt.KiemTra(100), false);

            Console.WriteLine();
        }

        // =============================================================
        // TEST BÀI 8: HOÁN VỊ (ref)
        // =============================================================
        static void TestBai8_HoanVi()
        {
            Console.WriteLine("--- Test Bai 8: Hoan Vi (ref) ---");
            HoanVi hv = new HoanVi();

            // Test hoán vị 2 số khác nhau
            double a = 3.5, b = 7.2;
            hv.Swap(ref a, ref b);
            KiemTra("8.1 Swap(3.5,7.2) => a", a, 7.2);
            KiemTra("8.2 Swap(3.5,7.2) => b", b, 3.5);

            // Test hoán vị 2 số bằng nhau
            double c = 5.0, d = 5.0;
            hv.Swap(ref c, ref d);
            KiemTra("8.3 Swap(5,5) => c", c, 5.0);
            KiemTra("8.4 Swap(5,5) => d", d, 5.0);

            // Test hoán vị số âm
            double e = -3.14, f = 2.71;
            hv.Swap(ref e, ref f);
            KiemTra("8.5 Swap(-3.14,2.71) => e", e, 2.71);
            KiemTra("8.6 Swap(-3.14,2.71) => f", f, -3.14);

            Console.WriteLine();
        }

        // =============================================================
        // TEST BÀI 9: TÌM MIN MAX (out)
        // =============================================================
        static void TestBai9_TimMinMax()
        {
            Console.WriteLine("--- Test Bai 9: Tim Min Max (out) ---");
            TimMinMax tmm = new TimMinMax();
            double max, min;

            // Test cơ bản
            tmm.Tim(5, 2, 8, out max, out min);
            KiemTra("9.1 Tim(5,2,8) max", max, 8.0);
            KiemTra("9.2 Tim(5,2,8) min", min, 2.0);

            // Test số âm
            tmm.Tim(-3, -1, -7, out max, out min);
            KiemTra("9.3 Tim(-3,-1,-7) max", max, -1.0);
            KiemTra("9.4 Tim(-3,-1,-7) min", min, -7.0);

            // Test 3 số bằng nhau
            tmm.Tim(4, 4, 4, out max, out min);
            KiemTra("9.5 Tim(4,4,4) max", max, 4.0);
            KiemTra("9.6 Tim(4,4,4) min", min, 4.0);

            // Test số thực
            tmm.Tim(1.5, 3.7, 2.1, out max, out min);
            KiemTra("9.7 Tim(1.5,3.7,2.1) max", max, 3.7);
            KiemTra("9.8 Tim(1.5,3.7,2.1) min", min, 1.5);

            Console.WriteLine();
        }

        // =============================================================
        // TEST BÀI 10: CHUỖI ĐỐI XỨNG
        // =============================================================
        static void TestBai10_DoiXung()
        {
            Console.WriteLine("--- Test Bai 10: Chuoi Doi Xung ---");
            XuLyChuoi xlc = new XuLyChuoi();

            // Chuỗi đối xứng (palindrome)
            KiemTra("10.1 'abcba'", xlc.KiemTraDoiXung("abcba"), true);
            KiemTra("10.2 'abba'", xlc.KiemTraDoiXung("abba"), true);
            KiemTra("10.3 'a'", xlc.KiemTraDoiXung("a"), true);
            KiemTra("10.4 'racecar'", xlc.KiemTraDoiXung("racecar"), true);
            KiemTra("10.5 ''", xlc.KiemTraDoiXung(""), true);
            KiemTra("10.6 'AbBa' (hoa thuong)", xlc.KiemTraDoiXung("AbBa"), true);

            // Chuỗi không đối xứng
            KiemTra("10.7 'abc'", xlc.KiemTraDoiXung("abc"), false);
            KiemTra("10.8 'hello'", xlc.KiemTraDoiXung("hello"), false);

            Console.WriteLine();
        }

        // =============================================================
        // TEST BÀI 11: ĐẢO CHUỖI
        // =============================================================
        static void TestBai11_DaoChuoi()
        {
            Console.WriteLine("--- Test Bai 11: Dao Chuoi ---");
            XuLyChuoi xlc = new XuLyChuoi();

            KiemTra("11.1 Dao('Hello')", xlc.DaoChuoi("Hello"), "olleH");
            KiemTra("11.2 Dao('abcba')", xlc.DaoChuoi("abcba"), "abcba");
            KiemTra("11.3 Dao('')", xlc.DaoChuoi(""), "");
            KiemTra("11.4 Dao('A')", xlc.DaoChuoi("A"), "A");
            KiemTra("11.5 Dao('12345')", xlc.DaoChuoi("12345"), "54321");

            Console.WriteLine();
        }

        // =============================================================
        // TEST BÀI 12: THAO TÁC CHUỖI
        // =============================================================
        static void TestBai12_ThaoTacChuoi()
        {
            Console.WriteLine("--- Test Bai 12: Thao Tac Chuoi ---");
            XuLyChuoi xlc = new XuLyChuoi();

            // Test chuyển thường
            KiemTra("12.1 Thuong('Hello World')",
                xlc.ChuyenThuong("Hello World"), "hello world");
            KiemTra("12.2 Thuong('ABC')",
                xlc.ChuyenThuong("ABC"), "abc");

            // Test chuyển hoa
            KiemTra("12.3 Hoa('Hello World')",
                xlc.ChuyenHoa("Hello World"), "HELLO WORLD");
            KiemTra("12.4 Hoa('abc')",
                xlc.ChuyenHoa("abc"), "ABC");

            // Test đếm số từ
            KiemTra("12.5 DemTu('Xin chao ban')",
                xlc.DemSoTu("Xin chao ban"), 3);
            KiemTra("12.6 DemTu('Mot')",
                xlc.DemSoTu("Mot"), 1);
            KiemTra("12.7 DemTu('  Nhieu   khoang   trang  ')",
                xlc.DemSoTu("  Nhieu   khoang   trang  "), 3);
            KiemTra("12.8 DemTu('A B C D E')",
                xlc.DemSoTu("A B C D E"), 5);

            Console.WriteLine();
        }

        // =============================================================
        // TEST BÀI 13: LỚP SINH VIÊN
        // =============================================================
        static void TestBai13_SinhVien()
        {
            Console.WriteLine("--- Test Bai 13: Lop SinhVien ---");

            // Test constructor có tham số
            SinhVien sv = new SinhVien("SV001", "Nguyen Van A", "TP.HCM", 2);
            KiemTra("13.1 MaSV", sv.GetMaSV(), "SV001");
            KiemTra("13.2 HoTen", sv.GetHoTen(), "Nguyen Van A");
            KiemTra("13.3 DiaChi", sv.GetDiaChi(), "TP.HCM");
            KiemTra("13.4 NamThu", sv.GetNamThu(), 2);

            // Test constructor mặc định
            SinhVien sv2 = new SinhVien();
            KiemTra("13.5 Default MaSV", sv2.GetMaSV(), "");
            KiemTra("13.6 Default NamThu", sv2.GetNamThu(), 1);

            // Test ToString
            string str = sv.ToString();
            total++;
            bool dung = str.Contains("SV001") && str.Contains("Nguyen Van A");
            if (dung) pass++;
            Console.WriteLine("  13.7 ToString='{0}' => {1}", str, dung ? "PASS" : "FAIL");

            Console.WriteLine();
        }

        // =============================================================
        // TEST BÀI 14: TÍNH LƯƠNG NHÂN VIÊN
        // =============================================================
        static void TestBai14_NhanVien()
        {
            Console.WriteLine("--- Test Bai 14: Tinh Luong NhanVien ---");

            // Lương 10 triệu, vắng 2 ngày → trừ 200k → còn 9.8 triệu
            NhanVien nv1 = new NhanVien("Tran B", 10000000, 2);
            KiemTra("14.1 Luong(10tr, 2ng)", nv1.TinhLuong(), 9800000);

            // Không vắng → lương giữ nguyên
            NhanVien nv2 = new NhanVien("Le C", 5000000, 0);
            KiemTra("14.2 Luong(5tr, 0ng)", nv2.TinhLuong(), 5000000);

            // Vắng nhiều → lương = 0 (không âm)
            NhanVien nv3 = new NhanVien("Pham D", 500000, 10);
            KiemTra("14.3 Luong(500k, 10ng)", nv3.TinhLuong(), 0);

            // Vắng 1 ngày
            NhanVien nv4 = new NhanVien("Hoang E", 8000000, 1);
            KiemTra("14.4 Luong(8tr, 1ng)", nv4.TinhLuong(), 7900000);

            // Test getter
            KiemTra("14.5 HoTen", nv1.GetHoTen(), "Tran B");
            KiemTra("14.6 SoNgayVang", nv1.GetSoNgayVang(), 2);

            Console.WriteLine();
        }

        // =============================================================
        // TEST BÀI 15: MẢNG 1 CHIỀU
        // =============================================================
        static void TestBai15_Mang1Chieu()
        {
            Console.WriteLine("--- Test Bai 15: Mang 1 Chieu ---");

            // Tạo mảng test
            int[] data = { 7, 2, 11, 4, 13, 6, 3 };
            XuLyMang xlm = new XuLyMang(data);

            // Test tìm max, min
            int max, min;
            xlm.TimMaxMin(out max, out min);
            KiemTra("15.1 Max", max, 13);
            KiemTra("15.2 Min", min, 2);

            // Test lấy mảng số nguyên tố
            // Trong {7, 2, 11, 4, 13, 6, 3}: NT là {7, 2, 11, 13, 3}
            int[] nt = xlm.LayMangSoNguyenTo();
            KiemTra("15.3 So luong NT", nt.Length, 5);

            // Kiểm tra các số nguyên tố đúng
            total++;
            bool dungNT = (nt[0] == 7 && nt[1] == 2 && nt[2] == 11
                        && nt[3] == 13 && nt[4] == 3);
            if (dungNT) pass++;
            Console.WriteLine("  15.4 NT={{{0},{1},{2},{3},{4}}} (mong doi: 7,2,11,13,3) => {5}",
                nt[0], nt[1], nt[2], nt[3], nt[4], dungNT ? "PASS" : "FAIL");

            // Test với mảng không có số nguyên tố
            int[] data2 = { 4, 6, 8, 9, 10 };
            XuLyMang xlm2 = new XuLyMang(data2);
            int[] nt2 = xlm2.LayMangSoNguyenTo();
            KiemTra("15.5 Mang khong co NT", nt2.Length, 0);

            // Test với mảng 1 phần tử
            int[] data3 = { 17 };
            XuLyMang xlm3 = new XuLyMang(data3);
            xlm3.TimMaxMin(out max, out min);
            KiemTra("15.6 Max mang 1 pt", max, 17);
            KiemTra("15.7 Min mang 1 pt", min, 17);

            Console.WriteLine();
        }

        // =============================================================
        // TEST BÀI 17: MẢNG 2 CHIỀU
        // =============================================================
        static void TestBai17_Mang2Chieu()
        {
            Console.WriteLine("--- Test Bai 17: Mang 2 Chieu ---");

            // Tạo mảng 3x4 với seed cố định
            XuLyMang2D xlm2d = new XuLyMang2D(3, 4);
            xlm2d.SinhNgauNhien(42);

            // Test kích thước
            KiemTra("17.1 So dong", xlm2d.GetDong(), 3);
            KiemTra("17.2 So cot", xlm2d.GetCot(), 4);

            // Test tất cả phần tử trong [10, 100]
            int[,] m = xlm2d.GetMang();
            total++;
            bool trongKhoang = true;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 4; j++)
                    if (m[i, j] < 10 || m[i, j] > 100)
                        trongKhoang = false;
            if (trongKhoang) pass++;
            Console.WriteLine("  17.3 Tat ca phan tu trong [10,100] => {0}",
                trongKhoang ? "PASS" : "FAIL");

            // Test tách chẵn lẻ
            int[] mangChan, mangLe;
            xlm2d.TachChanLe(out mangChan, out mangLe);

            // Tổng chẵn + lẻ = tổng phần tử
            KiemTra("17.4 Chan+Le=12",
                mangChan.Length + mangLe.Length, 12);

            // Kiểm tra mảng chẵn thực sự chẵn
            total++;
            bool tatCaChan = true;
            for (int i = 0; i < mangChan.Length; i++)
                if (mangChan[i] % 2 != 0) tatCaChan = false;
            if (tatCaChan) pass++;
            Console.WriteLine("  17.5 Tat ca so chan deu chan => {0}",
                tatCaChan ? "PASS" : "FAIL");

            // Kiểm tra mảng lẻ thực sự lẻ
            total++;
            bool tatCaLe = true;
            for (int i = 0; i < mangLe.Length; i++)
                if (mangLe[i] % 2 == 0) tatCaLe = false;
            if (tatCaLe) pass++;
            Console.WriteLine("  17.6 Tat ca so le deu le => {0}",
                tatCaLe ? "PASS" : "FAIL");

            // Test mảng 2x2
            XuLyMang2D xlm2 = new XuLyMang2D(2, 2);
            xlm2.SinhNgauNhien(99);
            xlm2.TachChanLe(out mangChan, out mangLe);
            KiemTra("17.7 Mang 2x2: Chan+Le=4",
                mangChan.Length + mangLe.Length, 4);

            Console.WriteLine();
        }

        // =============================================================
        // HÀM MAIN
        // =============================================================
        public static void Main(string[] args)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("  TEST CASE - CHUONG 2: THUC HANH          ");
            Console.WriteLine("============================================\n");

            TestBai6_TimMax();
            TestBai7_SoNguyenTo();
            TestBai8_HoanVi();
            TestBai9_TimMinMax();
            TestBai10_DoiXung();
            TestBai11_DaoChuoi();
            TestBai12_ThaoTacChuoi();
            TestBai13_SinhVien();
            TestBai14_NhanVien();
            TestBai15_Mang1Chieu();
            TestBai17_Mang2Chieu();

            Console.WriteLine("============================================");
            Console.WriteLine("  KET QUA TONG: {0}/{1} PASS", pass, total);
            if (pass == total)
                Console.WriteLine("  >>> TAT CA TEST CASE DEU DUNG! <<<");
            else
                Console.WriteLine("  >>> CO {0} TEST CASE SAI! <<<", total - pass);
            Console.WriteLine("============================================");

            Console.WriteLine("\nNhan phim bat ky de thoat...");
            Console.Read();
        }
    }
}
