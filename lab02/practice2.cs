using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LTCsharp.Lab2.OOP
{

    class SinhVienOOP
    {
        private string hoTen;
        private int namSinh;

        public SinhVienOOP()
        {
            hoTen = "";
            namSinh = 2000;
        }

        public SinhVienOOP(string hoTen, int namSinh)
        {
            this.hoTen = hoTen;
            this.namSinh = namSinh;
        }

        public SinhVienOOP(SinhVienOOP other)
        {
            this.hoTen = other.hoTen;
            this.namSinh = other.namSinh;
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public int NamSinh
        {
            get { return namSinh; }
            set { namSinh = value; }
        }

        public int TinhTuoi()
        {
            return DateTime.Now.Year - namSinh;
        }

        public int TinhTuoi(int namHienTai)
        {
            return namHienTai - namSinh;
        }

        public void Nhap()
        {
            Console.Write("Nhap ho ten: ");
            hoTen = Console.ReadLine() ?? "";
            Console.Write("Nhap nam sinh: ");
            namSinh = int.Parse(Console.ReadLine() ?? "2000");
        }

        public void Xuat()
        {
            Console.WriteLine("Ho ten: {0}, Nam sinh: {1}, Tuoi: {2}",
                hoTen, namSinh, TinhTuoi());
        }

        public override string ToString()
        {
            return $"{hoTen} - {namSinh}";
        }
    }

    class Point
    {
        private double x, y;

        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point() { x = 0; y = 0; }
        public Point(double x, double y) { this.x = x; this.y = y; }
        public Point(Point other) { this.x = other.x; this.y = other.y; }

        public void Input()
        {
            Console.Write("Nhap x: ");
            x = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap y: ");
            y = double.Parse(Console.ReadLine() ?? "0");
        }

        public void Output()
        {
            Console.WriteLine("({0}, {1})", x, y);
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        public static Point operator +(Point a, Point b)
        {
            return new Point(a.x + b.x, a.y + b.y);
        }

        public static Point operator -(Point a, Point b)
        {
            return new Point(a.x - b.x, a.y - b.y);
        }

        public static Point operator -(Point a)
        {
            return new Point(-a.x, -a.y);
        }

        public double KhoangCach(Point p)
        {
            double dx = this.x - p.x;
            double dy = this.y - p.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static double KhoangCach(Point a, Point b)
        {
            double dx = a.x - b.x;
            double dy = a.y - b.y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public Point TrungDiem(Point p)
        {
            return new Point((this.x + p.x) / 2, (this.y + p.y) / 2);
        }

        public static Point TrungDiem(Point a, Point b)
        {
            return new Point((a.x + b.x) / 2, (a.y + b.y) / 2);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Point p)
                return Math.Abs(x - p.x) < 0.0001 && Math.Abs(y - p.y) < 0.0001;
            return false;
        }
        public override int GetHashCode() => HashCode.Combine(x, y);
    }

    class Person
    {
        private int id;
        private string name;
        private int yob;
        private int yod;

        public Person()
        {
            id = 0; name = ""; yob = 2000; yod = 0;
        }

        public Person(int id, string name, int yob, int yod)
        {
            this.id = id;
            this.name = name;
            this.yob = yob;
            this.yod = yod;
        }

        public Person(Person other)
        {
            this.id = other.id;
            this.name = other.name;
            this.yob = other.yob;
            this.yod = other.yod;
        }

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public int Yob { get { return yob; } set { yob = value; } }
        public int Yod { get { return yod; } set { yod = value; } }

        public bool IsLiving()
        {
            return yod == 0;
        }

        public void Input()
        {
            Console.Write("ID: "); id = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Name: "); name = Console.ReadLine() ?? "";
            Console.Write("YOB: "); yob = int.Parse(Console.ReadLine() ?? "2000");
            Console.Write("YOD (0=living): "); yod = int.Parse(Console.ReadLine() ?? "0");
        }

        public void Output()
        {
            Console.WriteLine("[{0}] {1} ({2}-{3}) {4}",
                id, name, yob, yod == 0 ? "now" : yod.ToString(),
                IsLiving() ? "LIVING" : "DECEASED");
        }

        public override string ToString()
        {
            return $"[{id}] {name} ({yob}-{(yod == 0 ? "now" : yod.ToString())})";
        }
    }

    class PhanSo
    {
        private int tu;
        private int mau;

        public PhanSo() { tu = 0; mau = 1; }

        public PhanSo(int tu, int mau)
        {
            if (mau == 0) throw new DivideByZeroException("Mau so khong duoc bang 0!");
            this.tu = tu;
            this.mau = mau;
            RutGon();
        }

        public PhanSo(PhanSo other)
        {
            this.tu = other.tu;
            this.mau = other.mau;
        }

        public int Tu { get { return tu; } }
        public int Mau { get { return mau; } }

        private static int UCLN(int a, int b)
        {
            a = Math.Abs(a); b = Math.Abs(b);
            while (b != 0) { int r = a % b; a = b; b = r; }
            return a;
        }

        private void RutGon()
        {
            if (tu == 0) { mau = 1; return; }
            if (mau < 0) { tu = -tu; mau = -mau; }
            int ucln = UCLN(Math.Abs(tu), mau);
            tu /= ucln;
            mau /= ucln;
        }

        public double GiaTri()
        {
            return (double)tu / mau;
        }

        public override string ToString()
        {
            if (mau == 1) return tu.ToString();
            return $"{tu}/{mau}";
        }

        public static PhanSo operator +(PhanSo a)
        {
            return new PhanSo(a.tu, a.mau);
        }

        public static PhanSo operator -(PhanSo a)
        {
            return new PhanSo(-a.tu, a.mau);
        }

        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tu * b.mau + b.tu * a.mau, a.mau * b.mau);
        }

        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tu * b.mau - b.tu * a.mau, a.mau * b.mau);
        }

        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tu * b.tu, a.mau * b.mau);
        }

        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            if (b.tu == 0) throw new DivideByZeroException("Khong the chia cho 0!");
            return new PhanSo(a.tu * b.mau, a.mau * b.tu);
        }

        public static bool operator >(PhanSo a, PhanSo b)
        {
            return a.tu * b.mau > b.tu * a.mau;
        }
        public static bool operator <(PhanSo a, PhanSo b)
        {
            return a.tu * b.mau < b.tu * a.mau;
        }
        public static bool operator >=(PhanSo a, PhanSo b)
        {
            return a.tu * b.mau >= b.tu * a.mau;
        }
        public static bool operator <=(PhanSo a, PhanSo b)
        {
            return a.tu * b.mau <= b.tu * a.mau;
        }
        public static bool operator ==(PhanSo a, PhanSo b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;
            return a.tu * b.mau == b.tu * a.mau;
        }
        public static bool operator !=(PhanSo a, PhanSo b)
        {
            return !(a == b);
        }

        public override bool Equals(object? obj)
        {
            if (obj is PhanSo ps) return this == ps;
            return false;
        }
        public override int GetHashCode() => HashCode.Combine(tu, mau);

        public void Nhap()
        {
            Console.Write("Nhap tu so: "); tu = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap mau so: "); mau = int.Parse(Console.ReadLine() ?? "1");
            if (mau == 0) mau = 1;
            RutGon();
        }
    }

    class DonThuc
    {
        private double heSo;
        private int bac;

        public DonThuc() { heSo = 0; bac = 0; }
        public DonThuc(double heSo, int bac)
        {
            this.heSo = heSo;
            this.bac = Math.Max(0, bac);
        }
        public DonThuc(DonThuc other) { heSo = other.heSo; bac = other.bac; }

        public double HeSo { get { return heSo; } set { heSo = value; } }
        public int Bac { get { return bac; } set { bac = Math.Max(0, value); } }

        public double TinhGiaTri(double x)
        {
            return heSo * Math.Pow(x, bac);
        }

        public DonThuc DaoHam()
        {
            if (bac == 0) return new DonThuc(0, 0);
            return new DonThuc(heSo * bac, bac - 1);
        }

        public double TinhDaoHam(double x)
        {
            return DaoHam().TinhGiaTri(x);
        }

        public override string ToString()
        {
            if (heSo == 0) return "0";
            if (bac == 0) return heSo.ToString();
            if (bac == 1) return $"{heSo}x";
            return $"{heSo}x^{bac}";
        }
    }

    class ArrayPoint
    {
        private ArrayList points;

        public ArrayPoint() { points = new ArrayList(); }

        public Point this[int i]
        {
            get
            {
                if (i < 0 || i >= points.Count)
                    throw new IndexOutOfRangeException("Chi so ngoai pham vi!");
                return (Point)points[i]!;
            }
            set
            {
                if (i < 0 || i >= points.Count)
                    throw new IndexOutOfRangeException("Chi so ngoai pham vi!");
                points[i] = value;
            }
        }

        public void Add(Point p) { points.Add(p); }
        public int Count { get { return points.Count; } }

        public void Output()
        {
            for (int i = 0; i < points.Count; i++)
                Console.WriteLine("  [{0}]: {1}", i, points[i]);
        }
    }

    class PersonList
    {
        private List<Person> danhSach;

        public PersonList() { danhSach = new List<Person>(); }

        public PersonList(PersonList other)
        {
            danhSach = new List<Person>();
            foreach (var p in other.danhSach)
                danhSach.Add(new Person(p));
        }

        public int Count { get { return danhSach.Count; } }

        public Person this[int i]
        {
            get { return danhSach[i]; }
        }

        public void Add(Person x)
        {
            danhSach.Add(x);
        }

        public PersonList LivingPeople()
        {
            PersonList result = new PersonList();
            foreach (var p in danhSach)
            {
                if (p.IsLiving())
                    result.Add(new Person(p));
            }
            return result;
        }

        public void Input()
        {
            Console.Write("Nhap so nguoi: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("--- Nguoi thu {0} ---", i + 1);
                Person p = new Person();
                p.Input();
                danhSach.Add(p);
            }
        }

        public void Output()
        {
            foreach (var p in danhSach)
                p.Output();
        }
    }

    class DaySo
    {
        private int[] data;

        public DaySo() { data = new int[0]; }

        public DaySo(int n)
        {
            data = new int[n];
        }

        public DaySo(int[] arr)
        {
            data = new int[arr.Length];
            Array.Copy(arr, data, arr.Length);
        }

        public DaySo(DaySo other)
        {
            data = new int[other.data.Length];
            Array.Copy(other.data, data, other.data.Length);
        }

        public int Length { get { return data.Length; } }

        public int this[int i]
        {
            get
            {
                if (i < 0 || i >= data.Length)
                    throw new IndexOutOfRangeException();
                return data[i];
            }
            set
            {
                if (i < 0 || i >= data.Length)
                    throw new IndexOutOfRangeException();
                data[i] = value;
            }
        }

        public int[] TimSoChan()
        {
            List<int> chan = new List<int>();
            foreach (int x in data)
                if (x % 2 == 0) chan.Add(x);
            return chan.ToArray();
        }

        public void Nhap()
        {
            Console.Write("Nhap so luong: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            data = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("a[{0}] = ", i);
                data[i] = int.Parse(Console.ReadLine() ?? "0");
            }
        }

        public void Xuat()
        {
            Console.WriteLine(string.Join(", ", data));
        }

        public int[] ToArray()
        {
            return (int[])data.Clone();
        }
    }

    class Mang2Chieu
    {
        private int[,] data;
        private int dong, cot;

        public Mang2Chieu() { dong = 0; cot = 0; data = new int[0, 0]; }

        public Mang2Chieu(int dong, int cot)
        {
            this.dong = dong;
            this.cot = cot;
            data = new int[dong, cot];
        }

        public Mang2Chieu(int[,] arr)
        {
            dong = arr.GetLength(0);
            cot = arr.GetLength(1);
            data = (int[,])arr.Clone();
        }

        public Mang2Chieu(Mang2Chieu other)
        {
            dong = other.dong;
            cot = other.cot;
            data = (int[,])other.data.Clone();
        }

        public int Dong { get { return dong; } }
        public int Cot { get { return cot; } }

        public int this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= dong || j < 0 || j >= cot)
                    throw new IndexOutOfRangeException();
                return data[i, j];
            }
            set
            {
                if (i < 0 || i >= dong || j < 0 || j >= cot)
                    throw new IndexOutOfRangeException();
                data[i, j] = value;
            }
        }

        private static bool LaSoNguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
                if (n % i == 0) return false;
            return true;
        }

        public int[] TimSoNguyenTo()
        {
            List<int> result = new List<int>();
            for (int i = 0; i < dong; i++)
                for (int j = 0; j < cot; j++)
                    if (LaSoNguyenTo(data[i, j]))
                        result.Add(data[i, j]);
            return result.ToArray();
        }

        public void SinhNgauNhien(int seed = 0)
        {
            Random rand = seed > 0 ? new Random(seed) : new Random();
            for (int i = 0; i < dong; i++)
                for (int j = 0; j < cot; j++)
                    data[i, j] = rand.Next(1, 100);
        }

        public void Xuat()
        {
            for (int i = 0; i < dong; i++)
            {
                for (int j = 0; j < cot; j++)
                    Console.Write("{0,5}", data[i, j]);
                Console.WriteLine();
            }
        }
    }

    class DaThuc
    {
        private DonThuc[] heSo;

        public DaThuc() { heSo = new DonThuc[] { new DonThuc(0, 0) }; }

        public DaThuc(double[] coeffs)
        {
            heSo = new DonThuc[coeffs.Length];
            for (int i = 0; i < coeffs.Length; i++)
                heSo[i] = new DonThuc(coeffs[i], i);
        }

        public DaThuc(DaThuc other)
        {
            heSo = new DonThuc[other.heSo.Length];
            for (int i = 0; i < other.heSo.Length; i++)
                heSo[i] = new DonThuc(other.heSo[i]);
        }

        public int Bac { get { return heSo.Length - 1; } }

        public DonThuc this[int i]
        {
            get
            {
                if (i < 0 || i >= heSo.Length) throw new IndexOutOfRangeException();
                return heSo[i];
            }
            set
            {
                if (i < 0 || i >= heSo.Length) throw new IndexOutOfRangeException();
                heSo[i] = value;
            }
        }

        public double TinhGiaTri(double x)
        {
            double result = 0;
            for (int i = heSo.Length - 1; i >= 0; i--)
                result = result * x + heSo[i].HeSo;
            return result;
        }

        public void Nhap()
        {
            Console.Write("Nhap bac da thuc: ");
            int n = int.Parse(Console.ReadLine() ?? "0");
            heSo = new DonThuc[n + 1];
            for (int i = 0; i <= n; i++)
            {
                Console.Write("He so bac {0}: ", i);
                double a = double.Parse(Console.ReadLine() ?? "0");
                heSo[i] = new DonThuc(a, i);
            }
        }

        public void Xuat()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = heSo.Length - 1; i >= 0; i--)
            {
                if (heSo[i].HeSo == 0) continue;
                if (sb.Length > 0 && heSo[i].HeSo > 0) sb.Append(" + ");
                else if (sb.Length > 0 && heSo[i].HeSo < 0) sb.Append(" - ");

                double absHeSo = Math.Abs(heSo[i].HeSo);
                if (sb.Length == 0 && heSo[i].HeSo < 0) sb.Append("-");

                if (i == 0) sb.Append(absHeSo);
                else if (i == 1) sb.Append(absHeSo == 1 ? "x" : $"{absHeSo}x");
                else sb.Append(absHeSo == 1 ? $"x^{i}" : $"{absHeSo}x^{i}");
            }
            return sb.Length == 0 ? "0" : sb.ToString();
        }
    }

    class DayPhanSo
    {
        private PhanSo[] danhSach;

        public DayPhanSo() { danhSach = new PhanSo[0]; }

        public DayPhanSo(PhanSo[] arr)
        {
            danhSach = new PhanSo[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                danhSach[i] = new PhanSo(arr[i]);
        }

        public int Count { get { return danhSach.Length; } }

        public PhanSo this[int i]
        {
            get { return danhSach[i]; }
        }

        public PhanSo TinhTong()
        {
            if (danhSach.Length == 0) return new PhanSo(0, 1);
            PhanSo tong = new PhanSo(danhSach[0].Tu, danhSach[0].Mau);
            for (int i = 1; i < danhSach.Length; i++)
                tong = tong + danhSach[i];
            return tong;
        }
    }

    class NhanVienPB
    {
        private string hoTen;
        private double mucLuong;
        private int soNgayVang;

        public NhanVienPB() { hoTen = ""; mucLuong = 0; soNgayVang = 0; }
        public NhanVienPB(string hoTen, double mucLuong, int soNgayVang)
        {
            this.hoTen = hoTen;
            this.mucLuong = mucLuong;
            this.soNgayVang = soNgayVang;
        }

        public string HoTen { get { return hoTen; } }
        public double MucLuong { get { return mucLuong; } }
        public int SoNgayVang { get { return soNgayVang; } }

        public double TinhLuong()
        {
            double luong = mucLuong - soNgayVang * 100000;
            return luong < 0 ? 0 : luong;
        }
    }

    class PhongBan
    {
        private List<NhanVienPB> danhSach;

        public PhongBan() { danhSach = new List<NhanVienPB>(); }

        public void Add(NhanVienPB nv) { danhSach.Add(nv); }
        public int Count { get { return danhSach.Count; } }

        public NhanVienPB this[int i]
        {
            get { return danhSach[i]; }
        }

        public double TongLuong()
        {
            double tong = 0;
            foreach (var nv in danhSach)
                tong += nv.TinhLuong();
            return tong;
        }
    }

    class PhanSoComparable : PhanSo, IComparable<PhanSoComparable>
    {
        public PhanSoComparable(int tu, int mau) : base(tu, mau) { }

        public int CompareTo(PhanSoComparable? other)
        {
            if (other == null) return 1;
            double diff = this.GiaTri() - other.GiaTri();
            if (diff < 0) return -1;
            if (diff > 0) return 1;
            return 0;
        }
    }

    interface ISoSanh
    {
        int SoSanhVoi(object other);
    }

    static class SapXepHelper
    {
        public static void SapXep(ISoSanh[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (arr[i].SoSanhVoi(arr[j]) > 0)
                    {
                        ISoSanh temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
        }

        public static void SapXep<T>(T[] arr, Comparison<T> soSanh)
        {
            for (int i = 0; i < arr.Length - 1; i++)
                for (int j = i + 1; j < arr.Length; j++)
                    if (soSanh(arr[i], arr[j]) > 0)
                    {
                        T temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
        }
    }

    class ConsoleMenu
    {
        public delegate void MenuChooseHandler(int choice);
        public event MenuChooseHandler? Choose;

        private List<string> menuItems;
        private string title;

        public ConsoleMenu(string title)
        {
            this.title = title;
            menuItems = new List<string>();
        }

        public void AddItem(string item) { menuItems.Add(item); }

        public void Show()
        {
            Console.WriteLine(title);
            for (int i = 0; i < menuItems.Count; i++)
                Console.WriteLine("  {0}. {1}", i + 1, menuItems[i]);
            Console.WriteLine("  0. Thoat chuong trinh");
        }

        public void Run()
        {
            int choice;
            do
            {
                Show();
                Console.Write("Thuc hien: ");
                choice = int.Parse(Console.ReadLine() ?? "0");
                if (choice != 0)
                    Choose?.Invoke(choice);
            } while (choice != 0);
        }

        protected virtual void OnChoose(int choice) { }
    }

    abstract class NhanVienCty
    {
        protected string maNV;
        protected string hoTen;

        public NhanVienCty() { maNV = ""; hoTen = ""; }
        public NhanVienCty(string maNV, string hoTen)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
        }

        public string MaNV { get { return maNV; } }
        public string HoTen { get { return hoTen; } }

        public abstract double TinhLuong();

        public override string ToString()
        {
            return $"[{maNV}] {hoTen} - Luong: {TinhLuong():N0}";
        }
    }

    class NVKinhDoanh : NhanVienCty
    {
        private double luongCoBan;
        private int soHopDong;

        public NVKinhDoanh() : base() { luongCoBan = 0; soHopDong = 0; }
        public NVKinhDoanh(string maNV, string hoTen, double luongCoBan, int soHopDong)
            : base(maNV, hoTen)
        {
            this.luongCoBan = luongCoBan;
            this.soHopDong = soHopDong;
        }

        public double LuongCoBan { get { return luongCoBan; } }
        public int SoHopDong { get { return soHopDong; } }

        public override double TinhLuong()
        {
            return luongCoBan + soHopDong * 500000;
        }
    }

    class NVSanXuat : NhanVienCty
    {
        private int soSanPham;

        public NVSanXuat() : base() { soSanPham = 0; }
        public NVSanXuat(string maNV, string hoTen, int soSanPham)
            : base(maNV, hoTen)
        {
            this.soSanPham = soSanPham;
        }

        public int SoSanPham { get { return soSanPham; } }

        public override double TinhLuong()
        {
            double luong = soSanPham * 1000.0;
            if (soSanPham > 3000) luong *= 1.05;
            return luong;
        }
    }

    abstract class ThiSinh
    {
        protected string sbd;
        protected string hoTen;
        protected double bai1, bai2, bai3;

        public ThiSinh() { sbd = ""; hoTen = ""; bai1 = bai2 = bai3 = 0; }
        public ThiSinh(string sbd, string hoTen, double bai1, double bai2, double bai3)
        {
            this.sbd = sbd;
            this.hoTen = hoTen;
            this.bai1 = bai1;
            this.bai2 = bai2;
            this.bai3 = bai3;
        }

        public string SBD { get { return sbd; } }
        public string HoTenTS { get { return hoTen; } }
        public double Bai1 { get { return bai1; } }
        public double Bai2 { get { return bai2; } }
        public double Bai3 { get { return bai3; } }

        public abstract double TongDiem();

        public override string ToString()
        {
            return $"[{sbd}] {hoTen} - Tong diem: {TongDiem():F1}";
        }
    }

    class ThiSinhChuyen : ThiSinh
    {
        private double tiengAnh;

        public ThiSinhChuyen() : base() { tiengAnh = 0; }
        public ThiSinhChuyen(string sbd, string hoTen, double b1, double b2, double b3, double ta)
            : base(sbd, hoTen, b1, b2, b3)
        {
            tiengAnh = ta;
        }

        public double TiengAnh { get { return tiengAnh; } }

        public double DiemThuong()
        {
            if (tiengAnh >= 9 && tiengAnh <= 10) return 2;
            if (tiengAnh >= 7 && tiengAnh <= 8) return 1;
            return 0;
        }

        public override double TongDiem()
        {
            return bai1 + bai2 + bai3 + DiemThuong();
        }
    }

    class ThiSinhSieuCup : ThiSinh
    {
        private double csdl;

        public ThiSinhSieuCup() : base() { csdl = 0; }
        public ThiSinhSieuCup(string sbd, string hoTen, double b1, double b2, double b3, double csdl)
            : base(sbd, hoTen, b1, b2, b3)
        {
            this.csdl = csdl;
        }

        public double CSDL { get { return csdl; } }

        public override double TongDiem()
        {
            return bai1 + bai2 + bai3 + csdl;
        }
    }

    class CuocThi
    {
        private List<ThiSinh> danhSach;

        public CuocThi() { danhSach = new List<ThiSinh>(); }

        public void Add(ThiSinh ts) { danhSach.Add(ts); }
        public int Count { get { return danhSach.Count; } }
        public ThiSinh this[int i] { get { return danhSach[i]; } }

        public void Output()
        {
            foreach (var ts in danhSach)
                Console.WriteLine("  " + ts.ToString());
        }
    }
}
