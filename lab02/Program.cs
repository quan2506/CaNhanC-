using System;
using LTCsharp.Buoi2;
using LTCsharp.Lab2.OOP;

namespace LTCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int chon;
            do
            {
                Console.WriteLine("\n========================================");
                Console.WriteLine("  LAB 2 - CHON PRACTICE");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Practice 1: Nhap xuat du lieu");
                Console.WriteLine("2. Practice 2: Lap trinh OOP");
                Console.WriteLine("3. Test Practice 1 (tu dong)");
                Console.WriteLine("4. Test Practice 2 (tu dong)");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon: ");
                chon = int.Parse(Console.ReadLine() ?? "0");

                switch (chon)
                {
                    case 1: MenuPractice1(); break;
                    case 2: MenuPractice2(); break;
                    case 3: LTCsharp.Test.TestChuong2.Main(args); break;
                    case 4: LTCsharp.Test.TestOOP.Main(args); break;
                }
            } while (chon != 0);
        }

        static void MenuPractice1()
        {
            int chon;
            do
            {
                Console.WriteLine("\n--- PRACTICE 1: NHAP XUAT DU LIEU ---");
                Console.WriteLine("1. Bai 1: Nhap xuat ho ten");
                Console.WriteLine("2. Bai 2: Xuat loi chao");
                Console.WriteLine("3. Bai 3: Tinh x^y");
                Console.WriteLine("4. Bai 4: Tinh x^y (xu ly loi)");
                Console.WriteLine("5. Bai 5: Menu tinh toan");
                Console.WriteLine("0. Quay lai");
                Console.Write("Chon bai: ");
                chon = int.Parse(Console.ReadLine() ?? "0");

                switch (chon)
                {
                    case 1: new NhapXuatTen().Run(); break;
                    case 2: new NhapXuatChuoi().Run(); break;
                    case 3: new TinhLuyThua().Run(); break;
                    case 4: new TinhLuyThuaSafe().Run(); break;
                    case 5: new MenuTinhToan().Run(); break;
                }
            } while (chon != 0);
        }

        static void MenuPractice2()
        {
            int chon;
            do
            {
                Console.WriteLine("\n--- PRACTICE 2: LAP TRINH OOP ---");
                Console.WriteLine("1. Bai 1.1: SinhVien - Tinh tuoi");
                Console.WriteLine("2. Bai 1.2: Point - Toa do");
                Console.WriteLine("3. Bai 1.4: PhanSo - Phep tinh");
                Console.WriteLine("4. Bai 1.5: DonThuc - Dao ham");
                Console.WriteLine("5. Bai 3.5: NhanVien - Tinh luong");
                Console.WriteLine("6. Bai 3.6: ThiSinh - Tinh diem");
                Console.WriteLine("0. Quay lai");
                Console.Write("Chon bai: ");
                chon = int.Parse(Console.ReadLine() ?? "0");

                switch (chon)
                {
                    case 1: RunSinhVien(); break;
                    case 2: RunPoint(); break;
                    case 3: RunPhanSo(); break;
                    case 4: RunDonThuc(); break;
                    case 5: RunNhanVien(); break;
                    case 6: RunThiSinh(); break;
                }
            } while (chon != 0);
        }

        static void RunSinhVien()
        {
            Console.Write("Nhap ho ten: ");
            string hoTen = Console.ReadLine() ?? "";
            Console.Write("Nhap nam sinh: ");
            int namSinh = int.Parse(Console.ReadLine() ?? "2000");
            SinhVienOOP sv = new SinhVienOOP(hoTen, namSinh);
            Console.WriteLine("Ho ten: {0}", sv.HoTen);
            Console.WriteLine("Nam sinh: {0}", sv.NamSinh);
            Console.WriteLine("Tuoi: {0}", sv.TinhTuoi());
        }

        static void RunPoint()
        {
            Console.Write("Nhap x1, y1 (cach dau cach): ");
            string[] p1 = (Console.ReadLine() ?? "0 0").Split(' ');
            Console.Write("Nhap x2, y2 (cach dau cach): ");
            string[] p2 = (Console.ReadLine() ?? "0 0").Split(' ');

            Point a = new Point(double.Parse(p1[0]), double.Parse(p1[1]));
            Point b = new Point(double.Parse(p2[0]), double.Parse(p2[1]));

            Console.WriteLine("A = {0}", a);
            Console.WriteLine("B = {0}", b);
            Console.WriteLine("A + B = {0}", a + b);
            Console.WriteLine("A - B = {0}", a - b);
            Console.WriteLine("Khoang cach: {0:F4}", a.KhoangCach(b));
            Console.WriteLine("Trung diem: {0}", a.TrungDiem(b));
        }

        static void RunPhanSo()
        {
            Console.Write("Nhap tu1 mau1 (cach dau cach): ");
            string[] ps1 = (Console.ReadLine() ?? "1 2").Split(' ');
            Console.Write("Nhap tu2 mau2 (cach dau cach): ");
            string[] ps2 = (Console.ReadLine() ?? "1 3").Split(' ');

            PhanSo a = new PhanSo(int.Parse(ps1[0]), int.Parse(ps1[1]));
            PhanSo b = new PhanSo(int.Parse(ps2[0]), int.Parse(ps2[1]));

            Console.WriteLine("a = {0}", a);
            Console.WriteLine("b = {0}", b);
            Console.WriteLine("a + b = {0}", a + b);
            Console.WriteLine("a - b = {0}", a - b);
            Console.WriteLine("a * b = {0}", a * b);
            Console.WriteLine("a / b = {0}", a / b);
            Console.WriteLine("a > b: {0}", a > b);
            Console.WriteLine("a == b: {0}", a == b);
        }

        static void RunDonThuc()
        {
            Console.Write("Nhap he so a: ");
            double a = double.Parse(Console.ReadLine() ?? "3");
            Console.Write("Nhap bac n: ");
            int n = int.Parse(Console.ReadLine() ?? "2");
            Console.Write("Nhap x: ");
            double x = double.Parse(Console.ReadLine() ?? "2");

            DonThuc dt = new DonThuc(a, n);
            Console.WriteLine("P(x) = {0}", dt);
            Console.WriteLine("P({0}) = {1}", x, dt.TinhGiaTri(x));
            Console.WriteLine("P'(x) = {0}", dt.DaoHam());
            Console.WriteLine("P'({0}) = {1}", x, dt.DaoHam().TinhGiaTri(x));
        }

        static void RunNhanVien()
        {
            Console.Write("Nhap ten NV kinh doanh: ");
            string ten1 = Console.ReadLine() ?? "";
            Console.Write("Nhap luong co ban: ");
            double cb = double.Parse(Console.ReadLine() ?? "5000000");
            Console.Write("Nhap so hop dong: ");
            int hd = int.Parse(Console.ReadLine() ?? "3");

            NVKinhDoanh kd = new NVKinhDoanh("KD01", ten1, cb, hd);
            Console.WriteLine("Luong KD: {0:N0} VND", kd.TinhLuong());

            Console.Write("\nNhap ten NV san xuat: ");
            string ten2 = Console.ReadLine() ?? "";
            Console.Write("Nhap so san pham: ");
            int sp = int.Parse(Console.ReadLine() ?? "4000");

            NVSanXuat sx = new NVSanXuat("SX01", ten2, sp);
            Console.WriteLine("Luong SX: {0:N0} VND", sx.TinhLuong());
        }

        static void RunThiSinh()
        {
            Console.Write("Nhap diem bai 1, 2, 3 (cach dau cach): ");
            string[] d = (Console.ReadLine() ?? "8 7 9").Split(' ');
            Console.Write("Nhap diem tieng Anh: ");
            double ta = double.Parse(Console.ReadLine() ?? "9");

            ThiSinhChuyen ts = new ThiSinhChuyen("C01", "ThiSinh",
                double.Parse(d[0]), double.Parse(d[1]), double.Parse(d[2]), ta);
            Console.WriteLine("Diem thuong: {0}", ts.DiemThuong());
            Console.WriteLine("Tong diem: {0}", ts.TongDiem());
        }
    }
}
