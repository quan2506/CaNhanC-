using System;
using System.Text;

namespace LTCsharp.Buoi2
{
    class NhapXuatTen
    {
        public void Run()
        {
            Console.Write("Nhap ho ten: ");
            string hoTen = Console.ReadLine() ?? "";
            Console.WriteLine("Ho ten da nhap: " + hoTen);
        }
    }

    class NhapXuatChuoi
    {
        public void Run()
        {
            Console.Write("Nhap ho ten cua ban: ");
            string hoTen = Console.ReadLine() ?? "";
            Console.WriteLine("Chao ban " + hoTen + "!");
        }

        public string ChaoHoi(string hoTen)
        {
            return "Chao ban " + hoTen + "!";
        }
    }

    class TinhLuyThua
    {
        public void Run()
        {
            Console.Write("Nhap so nguyen x: ");
            int x = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap so nguyen y: ");
            int y = int.Parse(Console.ReadLine() ?? "0");
            long ketQua = TinhXMuY(x, y);
            Console.WriteLine("Ket qua {0} mu {1} la: {2}", x, y, ketQua);
        }

        public long TinhXMuY(int x, int y)
        {
            return (long)Math.Pow(x, y);
        }
    }

    class TinhLuyThuaSafe
    {
        public void Run()
        {
            try
            {
                Console.Write("Nhap so nguyen x: ");
                int x = int.Parse(Console.ReadLine() ?? "");
                Console.Write("Nhap so nguyen y: ");
                int y = int.Parse(Console.ReadLine() ?? "");
                long ketQua = (long)Math.Pow(x, y);
                Console.WriteLine("Ket qua {0} mu {1} la: {2}", x, y, ketQua);
            }
            catch (FormatException)
            {
                Console.WriteLine("Loi: Gia tri nhap vao khong phai so nguyen!");
            }
        }

        public bool ThuParse(string input, out int result)
        {
            return int.TryParse(input, out result);
        }
    }

    
    class MenuTinhToan
    {
        private double x, y;

        public MenuTinhToan() { x = 0; y = 0; }

        public void Run()
        {
            int chon;
            do
            {
                Console.WriteLine("\n         MENU");
                Console.WriteLine("1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("2. Tinh x^y");
                Console.WriteLine("3. Tinh can bac 2 cua x va y");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");
                chon = int.Parse(Console.ReadLine() ?? "4");

                switch (chon)
                {
                    case 1:
                        Console.Write("Nhap x: ");
                        x = double.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Nhap y: ");
                        y = double.Parse(Console.ReadLine() ?? "0");
                        Console.WriteLine("Da nhap x = {0}, y = {1}", x, y);
                        break;
                    case 2:
                        Console.WriteLine("{0}^{1} = {2}", x, y, Math.Pow(x, y));
                        break;
                    case 3:
                        Console.WriteLine("Can bac 2 cua {0} = {1:F4}", x, Math.Sqrt(x));
                        Console.WriteLine("Can bac 2 cua {0} = {1:F4}", y, Math.Sqrt(y));
                        break;
                    case 4:
                        Console.WriteLine("Thoat chuong trinh.");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            } while (chon != 4);
        }

        public double GetX() { return x; }
        public double GetY() { return y; }
        public void SetXY(double x, double y) { this.x = x; this.y = y; }
        public double TinhXMuY() { return Math.Pow(x, y); }
        public double CanX() { return Math.Sqrt(x); }
        public double CanY() { return Math.Sqrt(y); }
    }

    class TimMax
    {
        public int Max3(int a, int b, int c)
        {
            int max = a;

            if (b > max) max = b;

            if (c > max) max = c;

            return max;
        }

        public int MaxNhieu(params int[] mangSo)
        {
            if (mangSo.Length == 0)
                throw new ArgumentException("Can it nhat 1 so!");

            int max = mangSo[0];

            for (int i = 1; i < mangSo.Length; i++)
            {
                if (mangSo[i] > max)
                    max = mangSo[i];
            }

            return max;
        }
    }

    class SoNguyenTo
    {
        public bool KiemTra(int n)
        {
            if (n <= 1) return false;

            if (n == 2) return true;

            if (n % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
            {
                if (n % i == 0) return false;
            }

            return true;
        }
    }

    class HoanVi
    {
        public void Swap(ref double a, ref double b)
        {
            double temp = a;

            a = b;

            b = temp;

        }
    }

    class TimMinMax
    {
        public void Tim(double a, double b, double c,
                        out double max, out double min)
        {
            max = a;
            min = a;

            if (b > max) max = b;
            if (b < min) min = b;

            if (c > max) max = c;
            if (c < min) min = c;
        }
    }

    class XuLyChuoi
    {
        public bool KiemTraDoiXung(string s)
        {
            s = s.ToLower().Trim();

            int dau = 0;
            int cuoi = s.Length - 1;

            while (dau < cuoi)
            {
                if (s[dau] != s[cuoi])
                    return false;

                dau++;
                cuoi--;
            }

            return true;
        }

        public string DaoChuoi(string s)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                sb.Append(s[i]);
            }

            return sb.ToString();
        }

        public string ChuyenThuong(string s)
        {
            return s.ToLower();
        }

        public string ChuyenHoa(string s)
        {
            return s.ToUpper();
        }

        public int DemSoTu(string s)
        {
            string[] mangTu = s.Trim().Split(
                new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries
            );

            return mangTu.Length;
        }
    }

    class SinhVien
    {
        private string maSV;
        private string hoTen;
        private string diaChi;
        private int namThu;

        public SinhVien()
        {
            maSV = "";
            hoTen = "";
            diaChi = "";
            namThu = 1;
        }

        public SinhVien(string maSV, string hoTen, string diaChi, int namThu)
        {
            this.maSV = maSV;
            this.hoTen = hoTen;
            this.diaChi = diaChi;
            this.namThu = namThu;
        }

        public void Nhap()
        {
            Console.Write("  Nhap ma sinh vien: ");
            maSV = Console.ReadLine() ?? "";

            Console.Write("  Nhap ho ten: ");
            hoTen = Console.ReadLine() ?? "";

            Console.Write("  Nhap dia chi: ");
            diaChi = Console.ReadLine() ?? "";

            Console.Write("  Nhap sinh vien nam thu: ");
            namThu = int.Parse(Console.ReadLine() ?? "1");
        }

        public void Xuat()
        {
            Console.WriteLine("  Ma SV    : {0}", maSV);
            Console.WriteLine("  Ho ten   : {0}", hoTen);
            Console.WriteLine("  Dia chi  : {0}", diaChi);
            Console.WriteLine("  Nam thu  : {0}", namThu);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - Nam {3}",
                maSV, hoTen, diaChi, namThu);
        }

        public string GetMaSV() { return maSV; }
        public string GetHoTen() { return hoTen; }
        public string GetDiaChi() { return diaChi; }
        public int GetNamThu() { return namThu; }
    }

    class NhanVien
    {
        private string hoTen;
        private double mucLuong;
        private int soNgayVang;

        public NhanVien()
        {
            hoTen = "";
            mucLuong = 0;
            soNgayVang = 0;
        }

        public NhanVien(string hoTen, double mucLuong, int soNgayVang)
        {
            this.hoTen = hoTen;
            this.mucLuong = mucLuong;
            this.soNgayVang = soNgayVang;
        }

        public void Nhap()
        {
            Console.Write("  Nhap ho ten nhan vien: ");
            hoTen = Console.ReadLine() ?? "";

            Console.Write("  Nhap muc luong (VND): ");
            mucLuong = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("  Nhap so ngay vang: ");
            soNgayVang = int.Parse(Console.ReadLine() ?? "0");
        }

        public double TinhLuong()
        {
            double tienTru = soNgayVang * 100000;

            double luongThuc = mucLuong - tienTru;

            if (luongThuc < 0) luongThuc = 0;

            return luongThuc;
        }

        public void Xuat()
        {
            Console.WriteLine("  Ho ten      : {0}", hoTen);
            Console.WriteLine("  Muc luong   : {0:N0} VND", mucLuong);
            Console.WriteLine("  So ngay vang: {0}", soNgayVang);
            Console.WriteLine("  Luong thuc  : {0:N0} VND", TinhLuong());
        }

        public string GetHoTen() { return hoTen; }
        public double GetMucLuong() { return mucLuong; }
        public int GetSoNgayVang() { return soNgayVang; }
    }

    class XuLyMang
    {
        private int[] mang;

        public XuLyMang()
        {
            mang = new int[0];
        }

        public XuLyMang(int[] mangBanDau)
        {
            mang = new int[mangBanDau.Length];
            Array.Copy(mangBanDau, mang, mangBanDau.Length);
        }

        public void NhapMang()
        {
            Console.Write("  Nhap so phan tu n: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            mang = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("  mang[{0}] = ", i);
                mang[i] = int.Parse(Console.ReadLine() ?? "0");
            }
        }

        public void InMang()
        {
            Console.Write("  Mang: ");
            for (int i = 0; i < mang.Length; i++)
            {
                Console.Write("{0} ", mang[i]);
            }
            Console.WriteLine();
        }

        public void TimMaxMin(out int max, out int min)
        {
            if (mang.Length == 0)
                throw new InvalidOperationException("Mang rong!");

            max = mang[0];
            min = mang[0];

            for (int i = 1; i < mang.Length; i++)
            {
                if (mang[i] > max) max = mang[i];
                if (mang[i] < min) min = mang[i];
            }
        }

        public int[] LayMangSoNguyenTo()
        {
            SoNguyenTo snt = new SoNguyenTo();

            int dem = 0;
            for (int i = 0; i < mang.Length; i++)
            {
                if (snt.KiemTra(mang[i]))
                    dem++;
            }

            int[] ketQua = new int[dem];

            int viTri = 0;
            for (int i = 0; i < mang.Length; i++)
            {
                if (snt.KiemTra(mang[i]))
                {
                    ketQua[viTri] = mang[i];
                    viTri++;
                }
            }

            return ketQua;
        }

        public int[] GetMang() { return mang; }
    }

    class XuLyMang2D
    {
        private int[,] mang;
        private int dong;
        private int cot;

        public XuLyMang2D()
        {
            dong = 0;
            cot = 0;
            mang = new int[0, 0];
        }

        public XuLyMang2D(int dong, int cot)
        {
            this.dong = dong;
            this.cot = cot;
            mang = new int[dong, cot];
        }

        public void SinhNgauNhien()
        {
            Random rand = new Random();

            for (int i = 0; i < dong; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    mang[i, j] = rand.Next(10, 101);
                }
            }
        }

        public void SinhNgauNhien(int seed)
        {
            Random rand = new Random(seed);

            for (int i = 0; i < dong; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    mang[i, j] = rand.Next(10, 101);
                }
            }
        }

        public void InMang()
        {
            for (int i = 0; i < dong; i++)
            {
                Console.Write("  ");
                for (int j = 0; j < cot; j++)
                {
                    Console.Write("{0,5}", mang[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void TachChanLe(out int[] mangChan, out int[] mangLe)
        {
            int demChan = 0, demLe = 0;
            for (int i = 0; i < dong; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    if (mang[i, j] % 2 == 0) demChan++;
                    else demLe++;
                }
            }

            mangChan = new int[demChan];
            mangLe = new int[demLe];

            int viTriChan = 0, viTriLe = 0;
            for (int i = 0; i < dong; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    if (mang[i, j] % 2 == 0)
                    {
                        mangChan[viTriChan] = mang[i, j];
                        viTriChan++;
                    }
                    else
                    {
                        mangLe[viTriLe] = mang[i, j];
                        viTriLe++;
                    }
                }
            }
        }

        public int[,] GetMang() { return mang; }
        public int GetDong() { return dong; }
        public int GetCot() { return cot; }
    }

    class Chuong2_NhapXuat
    {
        static void Bai1_MaNguon()
        {
            Console.WriteLine("--- BAI 1: MA NGUON CHUONG TRINH ---\n");

            Console.Write("Nhap ho ten: ");

            string hoTen = Console.ReadLine() ?? "";

            Console.WriteLine("Ho ten da nhap: {0}", hoTen);

            Console.WriteLine("\n--- Huong dan MSIL ---");
            Console.WriteLine("B2: Tim ildasm.exe va chay: ildasm BaiTap.exe /OUT=BaiTap.il");
            Console.WriteLine("B3: Tim ilasm.exe va chay: ilasm BaiTap.il");
        }

        static void Bai2_NhapXuatChuoi()
        {
            Console.WriteLine("--- BAI 2: XUAT VA NHAP CHUOI ---\n");

            Console.Write("Nhap ho ten cua ban: ");
            string hoTen = Console.ReadLine() ?? "";

            Console.WriteLine("Chao ban {0}!", hoTen);
        }

        static void Bai3_NhapSoNguyen()
        {
            Console.WriteLine("--- BAI 3: NHAP SO NGUYEN ---\n");

            Console.Write("Nhap so nguyen x: ");
            int x = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Nhap so nguyen y: ");
            int y = int.Parse(Console.ReadLine() ?? "0");

            long ketQua = (long)Math.Pow(x, y);

            Console.WriteLine("Ket qua {0} mu {1} la: {2}", x, y, ketQua);
        }

        static void Bai4_NhapCoKiemTra()
        {
            Console.WriteLine("--- BAI 4: NHAP CO KIEM TRA LOI ---\n");

            Console.Write("Nhap so nguyen x: ");
            string inputX = Console.ReadLine() ?? "";

            int x;
            if (!int.TryParse(inputX, out x))
            {
                Console.WriteLine("Loi: '{0}' khong phai so nguyen!", inputX);
                return;
            }

            Console.Write("Nhap so nguyen y: ");
            string inputY = Console.ReadLine() ?? "";

            int y;
            if (!int.TryParse(inputY, out y))
            {
                Console.WriteLine("Loi: '{0}' khong phai so nguyen!", inputY);
                return;
            }

            long ketQua = (long)Math.Pow(x, y);
            Console.WriteLine("Ket qua {0} mu {1} la: {2}", x, y, ketQua);
        }

        static void Bai5_Menu()
        {
            Console.WriteLine("--- BAI 5: MENU CHUC NANG ---\n");

            double x = 0, y = 0;
            int chon;

            do
            {
                Console.WriteLine("\n  MENU");
                Console.WriteLine("  1. Nhap hai gia tri so thuc cho x, y");
                Console.WriteLine("  2. Tinh x^y");
                Console.WriteLine("  3. Tinh can bac 2 cua x va y");
                Console.WriteLine("  4. Thoat");
                Console.Write("  Chon chuc nang: ");

                chon = int.Parse(Console.ReadLine() ?? "4");

                switch (chon)
                {
                    case 1:
                        Console.Write("  Nhap x: ");
                        x = double.Parse(Console.ReadLine() ?? "0");
                        Console.Write("  Nhap y: ");
                        y = double.Parse(Console.ReadLine() ?? "0");
                        Console.WriteLine("  Da nhap x={0}, y={1}", x, y);
                        break;

                    case 2:
                        double luaThua = Math.Pow(x, y);
                        Console.WriteLine("  {0}^{1} = {2}", x, y, luaThua);
                        break;

                    case 3:
                        double canX = Math.Sqrt(x);
                        double canY = Math.Sqrt(y);
                        Console.WriteLine("  Can bac 2 cua {0} = {1:F4}", x, canX);
                        Console.WriteLine("  Can bac 2 cua {0} = {1:F4}", y, canY);
                        break;

                    case 4:
                        Console.WriteLine("  Thoat chuong trinh.");
                        break;

                    default:
                        Console.WriteLine("  Lua chon khong hop le!");
                        break;
                }

            } while (chon != 4);
        }

        static void Bai6_TimMax()
        {
            Console.WriteLine("--- BAI 6: TIM GIA TRI LON NHAT ---\n");

            Console.Write("Nhap so nguyen a: ");
            int a = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap so nguyen b: ");
            int b = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap so nguyen c: ");
            int c = int.Parse(Console.ReadLine() ?? "0");

            TimMax tm = new TimMax();

            int max = tm.Max3(a, b, c);
            Console.WriteLine("Max cua ({0}, {1}, {2}) = {3}", a, b, c, max);

            int maxNhieu = tm.MaxNhieu(a, b, c, 100, -5);
            Console.WriteLine("Max cua ({0}, {1}, {2}, 100, -5) = {3}",
                a, b, c, maxNhieu);
        }

        static void Bai7_SoNguyenTo()
        {
            Console.WriteLine("--- BAI 7: KIEM TRA SO NGUYEN TO ---\n");

            Console.Write("Nhap so nguyen n: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            SoNguyenTo snt = new SoNguyenTo();
            bool laNguyenTo = snt.KiemTra(n);

            Console.WriteLine("{0} {1} so nguyen to.",
                n, laNguyenTo ? "la" : "khong phai");
        }

        static void Bai8_HoanVi()
        {
            Console.WriteLine("--- BAI 8: HOAN VI HAI SO THUC (ref) ---\n");

            Console.Write("Nhap so thuc a: ");
            double a = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap so thuc b: ");
            double b = double.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("Truoc hoan vi: a={0}, b={1}", a, b);

            HoanVi hv = new HoanVi();
            hv.Swap(ref a, ref b);

            Console.WriteLine("Sau hoan vi : a={0}, b={1}", a, b);
        }

        static void Bai9_TimMinMax()
        {
            Console.WriteLine("--- BAI 9: TIM MIN MAX (out) ---\n");

            Console.Write("Nhap so thuc a: ");
            double a = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap so thuc b: ");
            double b = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap so thuc c: ");
            double c = double.Parse(Console.ReadLine() ?? "0");

            double max, min;

            TimMinMax tmm = new TimMinMax();
            tmm.Tim(a, b, c, out max, out min);

            Console.WriteLine("Max cua ({0}, {1}, {2}) = {3}", a, b, c, max);
            Console.WriteLine("Min cua ({0}, {1}, {2}) = {3}", a, b, c, min);
        }

        static void Bai10_DoiXung()
        {
            Console.WriteLine("--- BAI 10: KIEM TRA CHUOI DOI XUNG ---\n");

            Console.Write("Nhap chuoi: ");
            string s = Console.ReadLine() ?? "";

            XuLyChuoi xlc = new XuLyChuoi();
            bool doiXung = xlc.KiemTraDoiXung(s);

            Console.WriteLine("'{0}' {1} doi xung.",
                s, doiXung ? "la chuoi" : "khong phai chuoi");
        }

        static void Bai11_DaoChuoi()
        {
            Console.WriteLine("--- BAI 11: DAO CHUOI ---\n");

            Console.Write("Nhap chuoi: ");
            string s = Console.ReadLine() ?? "";

            XuLyChuoi xlc = new XuLyChuoi();
            string daoChuoi = xlc.DaoChuoi(s);

            Console.WriteLine("Chuoi goc : '{0}'", s);
            Console.WriteLine("Chuoi dao : '{0}'", daoChuoi);
        }

        static void Bai12_ThaoTacChuoi()
        {
            Console.WriteLine("--- BAI 12: CAC THAO TAC TREN CHUOI ---\n");

            Console.Write("Nhap chuoi gom nhieu tu: ");
            string s = Console.ReadLine() ?? "";

            XuLyChuoi xlc = new XuLyChuoi();

            Console.WriteLine("Chuoi goc     : '{0}'", s);
            Console.WriteLine("Chu thuong    : '{0}'", xlc.ChuyenThuong(s));
            Console.WriteLine("Chu hoa       : '{0}'", xlc.ChuyenHoa(s));
            Console.WriteLine("So tu trong chuoi: {0}", xlc.DemSoTu(s));
        }

        static void Bai13_SinhVien()
        {
            Console.WriteLine("--- BAI 13: NHAP XUAT SINH VIEN ---\n");

            SinhVien sv = new SinhVien();

            Console.WriteLine("Nhap thong tin sinh vien:");
            sv.Nhap();

            Console.WriteLine("\nThong tin sinh vien:");
            sv.Xuat();
        }

        static void Bai14_NhanVien()
        {
            Console.WriteLine("--- BAI 14: TINH LUONG NHAN VIEN ---\n");

            NhanVien nv = new NhanVien();

            Console.WriteLine("Nhap thong tin nhan vien:");
            nv.Nhap();

            Console.WriteLine("\nThong tin va luong nhan vien:");
            nv.Xuat();
        }

        static void Bai15_Mang1Chieu()
        {
            Console.WriteLine("--- BAI 15: XU LY MANG 1 CHIEU ---\n");

            XuLyMang xlm = new XuLyMang();
            xlm.NhapMang();

            xlm.InMang();

            int max, min;
            xlm.TimMaxMin(out max, out min);
            Console.WriteLine("  Max = {0}, Min = {1}", max, min);

            int[] mangNT = xlm.LayMangSoNguyenTo();
            Console.Write("  Cac so nguyen to: ");
            for (int i = 0; i < mangNT.Length; i++)
                Console.Write("{0} ", mangNT[i]);
            Console.WriteLine();
        }

        static void Bai16_SapXepTen()
        {
            Console.WriteLine("--- BAI 16: SAP XEP MANG HO TEN ---\n");

            Console.Write("Nhap so luong nguoi n: ");
            int n = int.Parse(Console.ReadLine() ?? "0");

            string[] mangTen = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write("  Ho ten [{0}]: ", i + 1);
                mangTen[i] = Console.ReadLine() ?? "";
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    if (string.Compare(mangTen[j], mangTen[j + 1],
                        StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        string temp = mangTen[j];
                        mangTen[j] = mangTen[j + 1];
                        mangTen[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("\nMang da sap xep tang dan:");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("  {0}. {1}", i + 1, mangTen[i]);
            }
        }

        static void Bai17_Mang2Chieu()
        {
            Console.WriteLine("--- BAI 17: XU LY MANG 2 CHIEU ---\n");

            Console.Write("Nhap so dong n: ");
            int n = int.Parse(Console.ReadLine() ?? "3");
            Console.Write("Nhap so cot m: ");
            int m = int.Parse(Console.ReadLine() ?? "3");

            XuLyMang2D xlm2d = new XuLyMang2D(n, m);
            xlm2d.SinhNgauNhien();

            Console.WriteLine("\nMang 2 chieu [{0}x{1}]:", n, m);
            xlm2d.InMang();

            int[] mangChan, mangLe;
            xlm2d.TachChanLe(out mangChan, out mangLe);

            Console.Write("\nCac so chan: ");
            for (int i = 0; i < mangChan.Length; i++)
                Console.Write("{0} ", mangChan[i]);

            Console.Write("\nCac so le : ");
            for (int i = 0; i < mangLe.Length; i++)
                Console.Write("{0} ", mangLe[i]);
            Console.WriteLine();
        }

        static void RunTests()
        {
            Console.WriteLine("========== CHAY TAT CA TEST CASE ==========\n");
            int pass = 0, total = 0;

            Console.WriteLine("--- Test Bai 6: Tim Max ---");
            {
                TimMax tm = new TimMax();

                total++; int kq1 = tm.Max3(3, 7, 5);
                bool d1 = (kq1 == 7);
                if (d1) pass++;
                Console.WriteLine("  Test 6.1: Max(3,7,5)={0} (mong doi: 7) => {1}",
                    kq1, d1 ? "PASS" : "FAIL");

                total++; int kq2 = tm.Max3(-1, -5, -3);
                bool d2 = (kq2 == -1);
                if (d2) pass++;
                Console.WriteLine("  Test 6.2: Max(-1,-5,-3)={0} (mong doi: -1) => {1}",
                    kq2, d2 ? "PASS" : "FAIL");

                total++; int kq3 = tm.MaxNhieu(1, 5, 3, 8, 2);
                bool d3 = (kq3 == 8);
                if (d3) pass++;
                Console.WriteLine("  Test 6.3: MaxNhieu(1,5,3,8,2)={0} (mong doi: 8) => {1}",
                    kq3, d3 ? "PASS" : "FAIL");
            }
            Console.WriteLine();

            Console.WriteLine("--- Test Bai 7: So Nguyen To ---");
            {
                SoNguyenTo snt = new SoNguyenTo();
                int[] soTest = { 2, 3, 4, 7, 10, 13, 1, 0, -5, 97 };
                bool[] mongDoi = { true, true, false, true, false, true,
                                   false, false, false, true };

                for (int i = 0; i < soTest.Length; i++)
                {
                    total++;
                    bool kq = snt.KiemTra(soTest[i]);
                    bool dung = (kq == mongDoi[i]);
                    if (dung) pass++;
                    Console.WriteLine("  Test 7.{0}: KiemTra({1})={2} (mong doi: {3}) => {4}",
                        i + 1, soTest[i], kq, mongDoi[i], dung ? "PASS" : "FAIL");
                }
            }
            Console.WriteLine();

            Console.WriteLine("--- Test Bai 8: Hoan Vi (ref) ---");
            {
                HoanVi hv = new HoanVi();

                double a = 3.5, b = 7.2;
                hv.Swap(ref a, ref b);
                total++; bool d1 = (Math.Abs(a - 7.2) < 0.01 && Math.Abs(b - 3.5) < 0.01);
                if (d1) pass++;
                Console.WriteLine("  Test 8.1: Swap(3.5, 7.2) => a={0}, b={1} => {2}",
                    a, b, d1 ? "PASS" : "FAIL");

                double c = -1, d = -1;
                hv.Swap(ref c, ref d);
                total++; bool d2 = (Math.Abs(c - (-1)) < 0.01 && Math.Abs(d - (-1)) < 0.01);
                if (d2) pass++;
                Console.WriteLine("  Test 8.2: Swap(-1, -1) => c={0}, d={1} => {2}",
                    c, d, d2 ? "PASS" : "FAIL");
            }
            Console.WriteLine();

            Console.WriteLine("--- Test Bai 9: Tim Min Max (out) ---");
            {
                TimMinMax tmm = new TimMinMax();

                double max, min;
                tmm.Tim(5, 2, 8, out max, out min);
                total++; bool d1 = (Math.Abs(max - 8) < 0.01);
                if (d1) pass++;
                Console.WriteLine("  Test 9.1: Tim(5,2,8) max={0} (mong doi: 8) => {1}",
                    max, d1 ? "PASS" : "FAIL");

                total++; bool d2 = (Math.Abs(min - 2) < 0.01);
                if (d2) pass++;
                Console.WriteLine("  Test 9.2: Tim(5,2,8) min={0} (mong doi: 2) => {1}",
                    min, d2 ? "PASS" : "FAIL");

                tmm.Tim(-3, -1, -7, out max, out min);
                total++; bool d3 = (Math.Abs(max - (-1)) < 0.01);
                if (d3) pass++;
                Console.WriteLine("  Test 9.3: Tim(-3,-1,-7) max={0} (mong doi: -1) => {1}",
                    max, d3 ? "PASS" : "FAIL");

                total++; bool d4 = (Math.Abs(min - (-7)) < 0.01);
                if (d4) pass++;
                Console.WriteLine("  Test 9.4: Tim(-3,-1,-7) min={0} (mong doi: -7) => {1}",
                    min, d4 ? "PASS" : "FAIL");
            }
            Console.WriteLine();

            Console.WriteLine("--- Test Bai 10: Chuoi Doi Xung ---");
            {
                XuLyChuoi xlc = new XuLyChuoi();
                string[] chuoiTest = { "abcba", "abba", "abc", "a", "racecar", "" };
                bool[] mongDoi2 = { true, true, false, true, true, true };

                for (int i = 0; i < chuoiTest.Length; i++)
                {
                    total++;
                    bool kq = xlc.KiemTraDoiXung(chuoiTest[i]);
                    bool dung = (kq == mongDoi2[i]);
                    if (dung) pass++;
                    Console.WriteLine("  Test 10.{0}: KiemTra('{1}')={2} (mong doi: {3}) => {4}",
                        i + 1, chuoiTest[i], kq, mongDoi2[i], dung ? "PASS" : "FAIL");
                }
            }
            Console.WriteLine();

            Console.WriteLine("--- Test Bai 11: Dao Chuoi ---");
            {
                XuLyChuoi xlc = new XuLyChuoi();

                total++; string kq1 = xlc.DaoChuoi("Hello");
                bool d1 = (kq1 == "olleH");
                if (d1) pass++;
                Console.WriteLine("  Test 11.1: Dao('Hello')='{0}' (mong doi: 'olleH') => {1}",
                    kq1, d1 ? "PASS" : "FAIL");

                total++; string kq2 = xlc.DaoChuoi("abcba");
                bool d2 = (kq2 == "abcba");
                if (d2) pass++;
                Console.WriteLine("  Test 11.2: Dao('abcba')='{0}' (mong doi: 'abcba') => {1}",
                    kq2, d2 ? "PASS" : "FAIL");

                total++; string kq3 = xlc.DaoChuoi("");
                bool d3 = (kq3 == "");
                if (d3) pass++;
                Console.WriteLine("  Test 11.3: Dao('')='{0}' (mong doi: '') => {1}",
                    kq3, d3 ? "PASS" : "FAIL");
            }
            Console.WriteLine();

            Console.WriteLine("--- Test Bai 12: Thao Tac Chuoi ---");
            {
                XuLyChuoi xlc = new XuLyChuoi();

                total++; string kq1 = xlc.ChuyenThuong("Hello World");
                bool d1 = (kq1 == "hello world");
                if (d1) pass++;
                Console.WriteLine("  Test 12.1: Thuong('Hello World')='{0}' => {1}",
                    kq1, d1 ? "PASS" : "FAIL");

                total++; string kq2 = xlc.ChuyenHoa("Hello World");
                bool d2 = (kq2 == "HELLO WORLD");
                if (d2) pass++;
                Console.WriteLine("  Test 12.2: Hoa('Hello World')='{0}' => {1}",
                    kq2, d2 ? "PASS" : "FAIL");

                total++; int kq3 = xlc.DemSoTu("Xin chao ban");
                bool d3 = (kq3 == 3);
                if (d3) pass++;
                Console.WriteLine("  Test 12.3: DemTu('Xin chao ban')={0} (mong doi: 3) => {1}",
                    kq3, d3 ? "PASS" : "FAIL");

                total++; int kq4 = xlc.DemSoTu("  Nhieu   khoang   trang  ");
                bool d4 = (kq4 == 3);
                if (d4) pass++;
                Console.WriteLine("  Test 12.4: DemTu('  Nhieu   khoang   trang  ')={0} (mong doi: 3) => {1}",
                    kq4, d4 ? "PASS" : "FAIL");
            }
            Console.WriteLine();

            Console.WriteLine("--- Test Bai 13: Lop SinhVien ---");
            {
                SinhVien sv = new SinhVien("SV001", "Nguyen Van A", "HCM", 2);
                total++; bool d1 = (sv.GetMaSV() == "SV001");
                if (d1) pass++;
                Console.WriteLine("  Test 13.1: MaSV='{0}' (mong doi: 'SV001') => {1}",
                    sv.GetMaSV(), d1 ? "PASS" : "FAIL");

                total++; bool d2 = (sv.GetHoTen() == "Nguyen Van A");
                if (d2) pass++;
                Console.WriteLine("  Test 13.2: HoTen='{0}' (mong doi: 'Nguyen Van A') => {1}",
                    sv.GetHoTen(), d2 ? "PASS" : "FAIL");

                total++; bool d3 = (sv.GetNamThu() == 2);
                if (d3) pass++;
                Console.WriteLine("  Test 13.3: NamThu={0} (mong doi: 2) => {1}",
                    sv.GetNamThu(), d3 ? "PASS" : "FAIL");
            }
            Console.WriteLine();

            Console.WriteLine("--- Test Bai 14: Tinh Luong NhanVien ---");
            {
                NhanVien nv1 = new NhanVien("Tran B", 10000000, 2);
                total++; double luong1 = nv1.TinhLuong();
                bool d1 = (Math.Abs(luong1 - 9800000) < 1);
                if (d1) pass++;
                Console.WriteLine("  Test 14.1: Luong(10tr, 2 ngay vang)={0:N0} (mong doi: 9,800,000) => {1}",
                    luong1, d1 ? "PASS" : "FAIL");

                NhanVien nv2 = new NhanVien("Le C", 5000000, 0);
                total++; double luong2 = nv2.TinhLuong();
                bool d2 = (Math.Abs(luong2 - 5000000) < 1);
                if (d2) pass++;
                Console.WriteLine("  Test 14.2: Luong(5tr, 0 ngay vang)={0:N0} (mong doi: 5,000,000) => {1}",
                    luong2, d2 ? "PASS" : "FAIL");

                NhanVien nv3 = new NhanVien("Pham D", 500000, 10);
                total++; double luong3 = nv3.TinhLuong();
                bool d3 = (Math.Abs(luong3 - 0) < 1);
                if (d3) pass++;
                Console.WriteLine("  Test 14.3: Luong(500k, 10 ngay vang)={0:N0} (mong doi: 0) => {1}",
                    luong3, d3 ? "PASS" : "FAIL");
            }
            Console.WriteLine();

            Console.WriteLine("--- Test Bai 15: Mang 1 Chieu ---");
            {
                int[] data = { 7, 2, 11, 4, 13, 6, 3 };
                XuLyMang xlm = new XuLyMang(data);

                int max, min;
                xlm.TimMaxMin(out max, out min);
                total++; bool d1 = (max == 13);
                if (d1) pass++;
                Console.WriteLine("  Test 15.1: Max={0} (mong doi: 13) => {1}",
                    max, d1 ? "PASS" : "FAIL");

                total++; bool d2 = (min == 2);
                if (d2) pass++;
                Console.WriteLine("  Test 15.2: Min={0} (mong doi: 2) => {1}",
                    min, d2 ? "PASS" : "FAIL");

                int[] nt = xlm.LayMangSoNguyenTo();
                total++; bool d3 = (nt.Length == 5);
                if (d3) pass++;
                Console.WriteLine("  Test 15.3: So luong so nguyen to={0} (mong doi: 5) => {1}",
                    nt.Length, d3 ? "PASS" : "FAIL");
            }
            Console.WriteLine();

            Console.WriteLine("--- Test Bai 17: Mang 2 Chieu ---");
            {
                XuLyMang2D xlm2d = new XuLyMang2D(3, 4);
                xlm2d.SinhNgauNhien(42);

                int[,] m = xlm2d.GetMang();
                total++; bool d1 = true;
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 4; j++)
                        if (m[i, j] < 10 || m[i, j] > 100)
                            d1 = false;
                if (d1) pass++;
                Console.WriteLine("  Test 17.1: Tat ca phan tu trong [10,100] => {0}",
                    d1 ? "PASS" : "FAIL");

                int[] mangChan, mangLe;
                xlm2d.TachChanLe(out mangChan, out mangLe);
                total++; bool d2 = (mangChan.Length + mangLe.Length == 12);
                if (d2) pass++;
                Console.WriteLine("  Test 17.2: Chan({0}) + Le({1}) = {2} (mong doi: 12) => {3}",
                    mangChan.Length, mangLe.Length,
                    mangChan.Length + mangLe.Length,
                    d2 ? "PASS" : "FAIL");

                total++; bool d3 = true;
                for (int i = 0; i < mangChan.Length; i++)
                    if (mangChan[i] % 2 != 0) d3 = false;
                if (d3) pass++;
                Console.WriteLine("  Test 17.3: Tat ca so chan deu chan => {0}",
                    d3 ? "PASS" : "FAIL");

                total++; bool d4 = true;
                for (int i = 0; i < mangLe.Length; i++)
                    if (mangLe[i] % 2 == 0) d4 = false;
                if (d4) pass++;
                Console.WriteLine("  Test 17.4: Tat ca so le deu le => {0}",
                    d4 ? "PASS" : "FAIL");
            }

            Console.WriteLine("\n============================================");
            Console.WriteLine("  KET QUA: {0}/{1} PASS", pass, total);
            if (pass == total)
                Console.WriteLine("  >>> TAT CA TEST CASE DEU DUNG! <<<");
            else
                Console.WriteLine("  >>> CO {0} TEST CASE SAI! <<<", total - pass);
            Console.WriteLine("============================================");
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("============================================");
            Console.WriteLine("  CHUONG 2: THUC HANH NHAP XUAT DU LIEU    ");
            Console.WriteLine("============================================");
            Console.WriteLine(" 0. ** Chay tat ca test case **");
            Console.WriteLine("--- Nhap xuat co ban ---");
            Console.WriteLine(" 1. Ma nguon chuong trinh");
            Console.WriteLine(" 2. Xuat va nhap chuoi");
            Console.WriteLine(" 3. Nhap so nguyen (tinh x^y)");
            Console.WriteLine(" 4. Nhap co kiem tra loi");
            Console.WriteLine(" 5. Menu chuc nang");
            Console.WriteLine("--- Phuong thuc (return, ref, out) ---");
            Console.WriteLine(" 6. Tim gia tri lon nhat (return)");
            Console.WriteLine(" 7. Kiem tra so nguyen to (bool)");
            Console.WriteLine(" 8. Hoan vi hai so (ref)");
            Console.WriteLine(" 9. Tim min max (out)");
            Console.WriteLine("--- Chuoi ---");
            Console.WriteLine("10. Kiem tra chuoi doi xung");
            Console.WriteLine("11. Dao chuoi");
            Console.WriteLine("12. Cac thao tac tren chuoi");
            Console.WriteLine("--- Xay dung lop ---");
            Console.WriteLine("13. Nhap xuat sinh vien");
            Console.WriteLine("14. Tinh luong nhan vien");
            Console.WriteLine("--- Mang ---");
            Console.WriteLine("15. Xu ly mang 1 chieu");
            Console.WriteLine("16. Sap xep mang ho ten");
            Console.WriteLine("17. Xu ly mang 2 chieu");
            Console.WriteLine("--------------------------------------------");

            Console.Write("Chon bai tap (0-17): ");
            int chon = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine();

            switch (chon)
            {
                case 0:  RunTests(); break;
                case 1:  Bai1_MaNguon(); break;
                case 2:  Bai2_NhapXuatChuoi(); break;
                case 3:  Bai3_NhapSoNguyen(); break;
                case 4:  Bai4_NhapCoKiemTra(); break;
                case 5:  Bai5_Menu(); break;
                case 6:  Bai6_TimMax(); break;
                case 7:  Bai7_SoNguyenTo(); break;
                case 8:  Bai8_HoanVi(); break;
                case 9:  Bai9_TimMinMax(); break;
                case 10: Bai10_DoiXung(); break;
                case 11: Bai11_DaoChuoi(); break;
                case 12: Bai12_ThaoTacChuoi(); break;
                case 13: Bai13_SinhVien(); break;
                case 14: Bai14_NhanVien(); break;
                case 15: Bai15_Mang1Chieu(); break;
                case 16: Bai16_SapXepTen(); break;
                case 17: Bai17_Mang2Chieu(); break;
                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    break;
            }

            Console.WriteLine("\nNhan phim bat ky de thoat...");
            Console.Read();
        }
    }
}
