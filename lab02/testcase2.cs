/*
 * ============================================================
 * TEST CASE - LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG TRONG C#
 * ============================================================
 * Cách chạy: cd "lab 2" && dotnet run
 * ============================================================
 */

using System;
using LTCsharp.Lab2.OOP;

namespace LTCsharp.Test
{
    class TestOOP
    {
        static int pass = 0, total = 0;

        static void KiemTra(string ten, double kq, double md, double ss = 0.01)
        {
            total++;
            bool d = Math.Abs(kq - md) <= ss;
            if (d) pass++;
            Console.WriteLine("  {0}: {1} (md: {2}) => {3}", ten, kq, md, d ? "PASS" : "FAIL");
        }
        static void KiemTra(string ten, int kq, int md)
        {
            total++;
            bool d = kq == md;
            if (d) pass++;
            Console.WriteLine("  {0}: {1} (md: {2}) => {3}", ten, kq, md, d ? "PASS" : "FAIL");
        }
        static void KiemTra(string ten, string kq, string md)
        {
            total++;
            bool d = kq == md;
            if (d) pass++;
            Console.WriteLine("  {0}: '{1}' (md: '{2}') => {3}", ten, kq, md, d ? "PASS" : "FAIL");
        }
        static void KiemTra(string ten, bool kq, bool md)
        {
            total++;
            bool d = kq == md;
            if (d) pass++;
            Console.WriteLine("  {0}: {1} (md: {2}) => {3}", ten, kq, md, d ? "PASS" : "FAIL");
        }

        // ===================== BAI 1.1 =====================
        static void TestBai1_1()
        {
            Console.WriteLine("--- Bai 1.1: Tinh Tuoi SinhVien ---");
            SinhVienOOP sv = new SinhVienOOP("Nguyen A", 2004);
            KiemTra("1.1.1 TinhTuoi(2026)", sv.TinhTuoi(2026), 22);
            KiemTra("1.1.2 HoTen", sv.HoTen, "Nguyen A");
            KiemTra("1.1.3 NamSinh", sv.NamSinh, 2004);

            SinhVienOOP sv2 = new SinhVienOOP(sv); // copy
            KiemTra("1.1.4 Copy HoTen", sv2.HoTen, "Nguyen A");

            SinhVienOOP sv3 = new SinhVienOOP();
            KiemTra("1.1.5 Default NamSinh", sv3.NamSinh, 2000);
            Console.WriteLine();
        }

        // ===================== BAI 1.2 =====================
        static void TestBai1_2()
        {
            Console.WriteLine("--- Bai 1.2: Lop Point ---");
            Point a = new Point(3, 4);
            Point b = new Point(6, 8);

            // Operator +
            Point c = a + b;
            KiemTra("1.2.1 (3,4)+(6,8).X", c.X, 9.0);
            KiemTra("1.2.2 (3,4)+(6,8).Y", c.Y, 12.0);

            // Operator -
            Point d = b - a;
            KiemTra("1.2.3 (6,8)-(3,4).X", d.X, 3.0);

            // Lấy âm
            Point e = -a;
            KiemTra("1.2.4 -(3,4).X", e.X, -3.0);
            KiemTra("1.2.5 -(3,4).Y", e.Y, -4.0);

            // Khoảng cách
            Point p1 = new Point(0, 0);
            Point p2 = new Point(3, 4);
            KiemTra("1.2.6 KC(0,0)-(3,4)", p1.KhoangCach(p2), 5.0);
            KiemTra("1.2.7 KC static", Point.KhoangCach(p1, p2), 5.0);

            // Trung điểm
            Point td = p1.TrungDiem(p2);
            KiemTra("1.2.8 TrungDiem.X", td.X, 1.5);
            KiemTra("1.2.9 TrungDiem.Y", td.Y, 2.0);

            Point td2 = Point.TrungDiem(p1, p2);
            KiemTra("1.2.10 TrungDiem static.X", td2.X, 1.5);
            Console.WriteLine();
        }

        // ===================== BAI 1.3 =====================
        static void TestBai1_3()
        {
            Console.WriteLine("--- Bai 1.3: Lop Person ---");
            Person p1 = new Person(1, "Tran A", 1990, 0);
            KiemTra("1.3.1 IsLiving (sống)", p1.IsLiving(), true);

            Person p2 = new Person(2, "Le B", 1950, 2020);
            KiemTra("1.3.2 IsLiving (mất)", p2.IsLiving(), false);

            Person p3 = new Person(p1); // copy
            KiemTra("1.3.3 Copy name", p3.Name, "Tran A");

            Person p4 = new Person();
            KiemTra("1.3.4 Default Yob", p4.Yob, 2000);
            Console.WriteLine();
        }

        // ===================== BAI 1.4 =====================
        static void TestBai1_4()
        {
            Console.WriteLine("--- Bai 1.4: Lop PhanSo ---");
            PhanSo a = new PhanSo(1, 2);
            PhanSo b = new PhanSo(1, 3);

            KiemTra("1.4.1 1/2 + 1/3", (a + b).ToString(), "5/6");
            KiemTra("1.4.2 1/2 - 1/3", (a - b).ToString(), "1/6");
            KiemTra("1.4.3 1/2 * 1/3", (a * b).ToString(), "1/6");
            KiemTra("1.4.4 1/2 / 1/3", (a / b).ToString(), "3/2");
            KiemTra("1.4.5 -1/2", (-a).ToString(), "-1/2");
            KiemTra("1.4.6 1/2 > 1/3", a > b, true);
            KiemTra("1.4.7 1/2 < 1/3", a < b, false);
            KiemTra("1.4.8 1/2 == 2/4", a == new PhanSo(2, 4), true);
            KiemTra("1.4.9 1/2 != 1/3", a != b, true);

            // Rút gọn
            PhanSo c = new PhanSo(4, 6);
            KiemTra("1.4.10 RutGon 4/6", c.ToString(), "2/3");

            // Mẫu âm
            PhanSo d = new PhanSo(1, -2);
            KiemTra("1.4.11 1/(-2)", d.ToString(), "-1/2");
            Console.WriteLine();
        }

        // ===================== BAI 1.5 =====================
        static void TestBai1_5()
        {
            Console.WriteLine("--- Bai 1.5: Lop DonThuc ---");
            DonThuc dt = new DonThuc(3, 2); // 3x²

            KiemTra("1.5.1 3x² tai x=2", dt.TinhGiaTri(2), 12.0);
            KiemTra("1.5.2 3x² tai x=0", dt.TinhGiaTri(0), 0.0);

            // Đạo hàm: (3x²)' = 6x
            DonThuc dh = dt.DaoHam();
            KiemTra("1.5.3 DaoHam HeSo", dh.HeSo, 6.0);
            KiemTra("1.5.4 DaoHam Bac", dh.Bac, 1);
            KiemTra("1.5.5 DaoHam(x=3)", dh.TinhGiaTri(3), 18.0);

            // Hằng số
            DonThuc hs = new DonThuc(5, 0); // 5
            DonThuc dhHs = hs.DaoHam();
            KiemTra("1.5.6 DaoHam(5)", dhHs.HeSo, 0.0);
            Console.WriteLine();
        }

        // ===================== BAI 2.1 =====================
        static void TestBai2_1()
        {
            Console.WriteLine("--- Bai 2.1: ArrayPoint ---");
            ArrayPoint ap = new ArrayPoint();
            ap.Add(new Point(1, 2));
            ap.Add(new Point(3, 4));
            ap.Add(new Point(5, 6));

            KiemTra("2.1.1 Count", ap.Count, 3);
            KiemTra("2.1.2 [0].X", ap[0].X, 1.0);
            KiemTra("2.1.3 [1].Y", ap[1].Y, 4.0);
            KiemTra("2.1.4 [2].X", ap[2].X, 5.0);
            Console.WriteLine();
        }

        // ===================== BAI 2.2 =====================
        static void TestBai2_2()
        {
            Console.WriteLine("--- Bai 2.2: PersonList ---");
            PersonList pl = new PersonList();
            pl.Add(new Person(1, "A", 1990, 0));
            pl.Add(new Person(2, "B", 1950, 2020));
            pl.Add(new Person(3, "C", 1985, 0));

            KiemTra("2.2.1 Count", pl.Count, 3);

            PersonList living = pl.LivingPeople();
            KiemTra("2.2.2 Living count", living.Count, 2);
            KiemTra("2.2.3 Living[0]", living[0].Name, "A");
            KiemTra("2.2.4 Living[1]", living[1].Name, "C");
            Console.WriteLine();
        }

        // ===================== BAI 2.3 =====================
        static void TestBai2_3()
        {
            Console.WriteLine("--- Bai 2.3: DaySo ---");
            DaySo ds = new DaySo(new int[] { 1, 2, 3, 4, 5, 6 });

            KiemTra("2.3.1 Length", ds.Length, 6);
            KiemTra("2.3.2 [0]", ds[0], 1);
            KiemTra("2.3.3 [5]", ds[5], 6);

            int[] chan = ds.TimSoChan();
            KiemTra("2.3.4 So chan count", chan.Length, 3);
            KiemTra("2.3.5 chan[0]", chan[0], 2);
            Console.WriteLine();
        }

        // ===================== BAI 2.4 =====================
        static void TestBai2_4()
        {
            Console.WriteLine("--- Bai 2.4: Mang2Chieu ---");
            int[,] data = { { 2, 3, 4 }, { 5, 6, 7 }, { 8, 9, 11 } };
            Mang2Chieu m = new Mang2Chieu(data);

            KiemTra("2.4.1 [0,0]", m[0, 0], 2);
            KiemTra("2.4.2 [2,2]", m[2, 2], 11);

            int[] nt = m.TimSoNguyenTo();
            KiemTra("2.4.3 NT count", nt.Length, 5); // 2,3,5,7,11
            Console.WriteLine();
        }

        // ===================== BAI 2.3b DaThuc =====================
        static void TestBai2_3b()
        {
            Console.WriteLine("--- Bai 2.3b: DaThuc ---");
            // P(x) = 1 + 2x + 3x²
            DaThuc dt = new DaThuc(new double[] { 1, 2, 3 });

            KiemTra("2.3b.1 P(0)", dt.TinhGiaTri(0), 1.0);
            KiemTra("2.3b.2 P(1)", dt.TinhGiaTri(1), 6.0);  // 1+2+3=6
            KiemTra("2.3b.3 P(2)", dt.TinhGiaTri(2), 17.0); // 1+4+12=17
            KiemTra("2.3b.4 Bac", dt.Bac, 2);
            Console.WriteLine();
        }

        // ===================== BAI 2.4b DayPhanSo =====================
        static void TestBai2_4b()
        {
            Console.WriteLine("--- Bai 2.4b: DayPhanSo ---");
            DayPhanSo dps = new DayPhanSo(new PhanSo[]
            {
                new PhanSo(1, 2),
                new PhanSo(1, 3),
                new PhanSo(1, 6)
            });

            // 1/2 + 1/3 + 1/6 = 3/6 + 2/6 + 1/6 = 6/6 = 1
            PhanSo tong = dps.TinhTong();
            KiemTra("2.4b.1 Tong 1/2+1/3+1/6", tong.ToString(), "1");
            Console.WriteLine();
        }

        // ===================== BAI 2.5 PhongBan =====================
        static void TestBai2_5()
        {
            Console.WriteLine("--- Bai 2.5: PhongBan ---");
            PhongBan pb = new PhongBan();
            pb.Add(new NhanVienPB("A", 10000000, 2));  // 10tr - 200k = 9.8tr
            pb.Add(new NhanVienPB("B", 8000000, 0));   // 8tr
            pb.Add(new NhanVienPB("C", 5000000, 1));   // 5tr - 100k = 4.9tr

            KiemTra("2.5.1 NV A luong", pb[0].TinhLuong(), 9800000);
            KiemTra("2.5.2 NV B luong", pb[1].TinhLuong(), 8000000);
            KiemTra("2.5.3 Tong luong", pb.TongLuong(), 22700000);
            Console.WriteLine();
        }

        // ===================== BAI 3.1 IComparable =====================
        static void TestBai3_1()
        {
            Console.WriteLine("--- Bai 3.1: Sort IComparable ---");
            PhanSoComparable[] arr = {
                new PhanSoComparable(3, 4),
                new PhanSoComparable(1, 2),
                new PhanSoComparable(2, 3)
            };
            Array.Sort(arr);
            KiemTra("3.1.1 Sorted[0]", arr[0].ToString(), "1/2");
            KiemTra("3.1.2 Sorted[1]", arr[1].ToString(), "2/3");
            KiemTra("3.1.3 Sorted[2]", arr[2].ToString(), "3/4");
            Console.WriteLine();
        }

        // ===================== BAI 3.3 Delegate =====================
        static void TestBai3_3()
        {
            Console.WriteLine("--- Bai 3.3: Sort Delegate ---");
            int[] arr = { 5, 2, 8, 1, 9 };
            SapXepHelper.SapXep(arr, (a, b) => a.CompareTo(b));

            KiemTra("3.3.1 [0]", arr[0], 1);
            KiemTra("3.3.2 [1]", arr[1], 2);
            KiemTra("3.3.3 [4]", arr[4], 9);

            // Sắp giảm dần
            SapXepHelper.SapXep(arr, (a, b) => b.CompareTo(a));
            KiemTra("3.3.4 Giam [0]", arr[0], 9);
            Console.WriteLine();
        }

        // ===================== BAI 3.5 Ke Thua NhanVien =====================
        static void TestBai3_5()
        {
            Console.WriteLine("--- Bai 3.5: Ke Thua NhanVien ---");
            // NV Kinh doanh: lương CB 5tr + 3 HĐ × 500k = 6.5tr
            NVKinhDoanh kd = new NVKinhDoanh("KD01", "Nguyen A", 5000000, 3);
            KiemTra("3.5.1 KD luong", kd.TinhLuong(), 6500000);

            // NV Sản xuất: 2000 SP × 1000 = 2tr (< 3000 nên không thưởng)
            NVSanXuat sx1 = new NVSanXuat("SX01", "Tran B", 2000);
            KiemTra("3.5.2 SX 2000sp", sx1.TinhLuong(), 2000000);

            // NV Sản xuất: 4000 SP × 1000 × 1.05 = 4.2tr (> 3000 nên thưởng 5%)
            NVSanXuat sx2 = new NVSanXuat("SX02", "Le C", 4000);
            KiemTra("3.5.3 SX 4000sp", sx2.TinhLuong(), 4200000);

            // Đa hình: mảng NhanVienCty chứa cả 2 loại
            NhanVienCty[] ds = { kd, sx1, sx2 };
            double tong = 0;
            foreach (var nv in ds) tong += nv.TinhLuong();
            KiemTra("3.5.4 Tong luong", tong, 12700000);
            Console.WriteLine();
        }

        // ===================== BAI 3.6 Ke Thua ThiSinh =====================
        static void TestBai3_6()
        {
            Console.WriteLine("--- Bai 3.6: Ke Thua ThiSinh ---");
            // Chuyên: b1=8, b2=7, b3=9, TA=9 → tổng = 24 + 2 = 26
            ThiSinhChuyen c1 = new ThiSinhChuyen("C01", "Nguyen A", 8, 7, 9, 9);
            KiemTra("3.6.1 Chuyen DiemThuong(TA=9)", c1.DiemThuong(), 2.0);
            KiemTra("3.6.2 Chuyen TongDiem", c1.TongDiem(), 26.0);

            // Chuyên: TA=7 → thưởng 1
            ThiSinhChuyen c2 = new ThiSinhChuyen("C02", "Tran B", 5, 6, 7, 7);
            KiemTra("3.6.3 Chuyen DiemThuong(TA=7)", c2.DiemThuong(), 1.0);
            KiemTra("3.6.4 Chuyen TongDiem", c2.TongDiem(), 19.0);

            // Chuyên: TA=5 → không thưởng
            ThiSinhChuyen c3 = new ThiSinhChuyen("C03", "Le C", 5, 5, 5, 5);
            KiemTra("3.6.5 Chuyen DiemThuong(TA=5)", c3.DiemThuong(), 0.0);
            KiemTra("3.6.6 Chuyen TongDiem", c3.TongDiem(), 15.0);

            // Siêu cúp: b1=8, b2=9, b3=7, CSDL=8 → tổng = 32
            ThiSinhSieuCup sc = new ThiSinhSieuCup("SC01", "Pham D", 8, 9, 7, 8);
            KiemTra("3.6.7 SieuCup TongDiem", sc.TongDiem(), 32.0);

            // Đa hình
            ThiSinh[] ds = { c1, sc };
            KiemTra("3.6.8 DaHinh [0]", ds[0].TongDiem(), 26.0);
            KiemTra("3.6.9 DaHinh [1]", ds[1].TongDiem(), 32.0);
            Console.WriteLine();
        }

        // ===================== MAIN =====================
        public static void Main(string[] args)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("  TEST - LAP TRINH HUONG DOI TUONG C#      ");
            Console.WriteLine("============================================\n");

            TestBai1_1();
            TestBai1_2();
            TestBai1_3();
            TestBai1_4();
            TestBai1_5();
            TestBai2_1();
            TestBai2_2();
            TestBai2_3();
            TestBai2_4();
            TestBai2_3b();
            TestBai2_4b();
            TestBai2_5();
            TestBai3_1();
            TestBai3_3();
            TestBai3_5();
            TestBai3_6();

            Console.WriteLine("============================================");
            Console.WriteLine("  KET QUA: {0}/{1} PASS", pass, total);
            if (pass == total)
                Console.WriteLine("  >>> TAT CA DUNG! <<<");
            else
                Console.WriteLine("  >>> CO {0} SAI! <<<", total - pass);
            Console.WriteLine("============================================");
        }
    }
}
