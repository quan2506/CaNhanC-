/*
 * ============================================================
 * UNIT TEST - LẬP TRÌNH HƯỚNG ĐỐI TƯỢNG TRONG C#
 * ============================================================
 * Framework: xUnit
 * Cách chạy: cd "lab 2/Buoi2.Tests" && dotnet test
 * ============================================================
 */

using LTCsharp.Lab2.OOP;

namespace Buoi2.Tests
{
    // =================================================================
    // BÀI 1.1: SINH VIÊN OOP
    // =================================================================
    public class SinhVienOOPTests
    {
        [Fact]
        public void TinhTuoi_NamCuThe_TraVeDung()
        {
            SinhVienOOP sv = new SinhVienOOP("Nguyen A", 2004);
            Assert.Equal(22, sv.TinhTuoi(2026));
        }

        [Fact]
        public void Constructor_CoThamSo_GanDung()
        {
            SinhVienOOP sv = new SinhVienOOP("Tran B", 2000);
            Assert.Equal("Tran B", sv.HoTen);
            Assert.Equal(2000, sv.NamSinh);
        }

        [Fact]
        public void Constructor_MacDinh_GiaTriMacDinh()
        {
            SinhVienOOP sv = new SinhVienOOP();
            Assert.Equal("", sv.HoTen);
            Assert.Equal(2000, sv.NamSinh);
        }

        [Fact]
        public void CopyConstructor_SaoChepDung()
        {
            SinhVienOOP sv1 = new SinhVienOOP("Le C", 1998);
            SinhVienOOP sv2 = new SinhVienOOP(sv1);
            Assert.Equal("Le C", sv2.HoTen);
            Assert.Equal(1998, sv2.NamSinh);
        }

        [Fact]
        public void Property_GanVaDoc()
        {
            SinhVienOOP sv = new SinhVienOOP();
            sv.HoTen = "Test";
            sv.NamSinh = 2005;
            Assert.Equal("Test", sv.HoTen);
            Assert.Equal(2005, sv.NamSinh);
        }
    }

    // =================================================================
    // BÀI 1.2: POINT
    // =================================================================
    public class PointTests
    {
        [Fact]
        public void Constructor_MacDinh_GocToaDo()
        {
            Point p = new Point();
            Assert.Equal(0, p.X);
            Assert.Equal(0, p.Y);
        }

        [Theory]
        [InlineData(3, 4, 6, 8, 9, 12)]
        [InlineData(0, 0, 1, 1, 1, 1)]
        [InlineData(-1, -2, 3, 4, 2, 2)]
        public void OperatorCong_TinhDung(double x1, double y1, double x2, double y2, double rx, double ry)
        {
            Point a = new Point(x1, y1);
            Point b = new Point(x2, y2);
            Point c = a + b;
            Assert.Equal(rx, c.X);
            Assert.Equal(ry, c.Y);
        }

        [Fact]
        public void OperatorTru_TinhDung()
        {
            Point a = new Point(6, 8);
            Point b = new Point(3, 4);
            Point c = a - b;
            Assert.Equal(3, c.X);
            Assert.Equal(4, c.Y);
        }

        [Fact]
        public void OperatorLayAm_DoiDau()
        {
            Point a = new Point(3, -4);
            Point b = -a;
            Assert.Equal(-3, b.X);
            Assert.Equal(4, b.Y);
        }

        [Theory]
        [InlineData(0, 0, 3, 4, 5)]
        [InlineData(1, 1, 4, 5, 5)]
        [InlineData(0, 0, 0, 0, 0)]
        public void KhoangCach_ThanhVien_TinhDung(double x1, double y1, double x2, double y2, double kc)
        {
            Point a = new Point(x1, y1);
            Point b = new Point(x2, y2);
            Assert.Equal(kc, a.KhoangCach(b), precision: 4);
        }

        [Fact]
        public void KhoangCach_Static_BangThanhVien()
        {
            Point a = new Point(0, 0);
            Point b = new Point(3, 4);
            Assert.Equal(a.KhoangCach(b), Point.KhoangCach(a, b));
        }

        [Fact]
        public void TrungDiem_TinhDung()
        {
            Point a = new Point(0, 0);
            Point b = new Point(4, 6);
            Point td = a.TrungDiem(b);
            Assert.Equal(2, td.X);
            Assert.Equal(3, td.Y);
        }

        [Fact]
        public void TrungDiem_Static_BangThanhVien()
        {
            Point a = new Point(1, 2);
            Point b = new Point(5, 8);
            Point td1 = a.TrungDiem(b);
            Point td2 = Point.TrungDiem(a, b);
            Assert.Equal(td1.X, td2.X);
            Assert.Equal(td1.Y, td2.Y);
        }

        [Fact]
        public void ToString_DinhDang()
        {
            Point p = new Point(3.5, 4.2);
            Assert.Equal("(3.5, 4.2)", p.ToString());
        }
    }

    // =================================================================
    // BÀI 1.3: PERSON
    // =================================================================
    public class PersonTests
    {
        [Fact]
        public void IsLiving_YodBang0_True()
        {
            Person p = new Person(1, "A", 1990, 0);
            Assert.True(p.IsLiving());
        }

        [Fact]
        public void IsLiving_YodKhac0_False()
        {
            Person p = new Person(2, "B", 1950, 2020);
            Assert.False(p.IsLiving());
        }

        [Fact]
        public void CopyConstructor_DeepCopy()
        {
            Person p1 = new Person(1, "Nguyen A", 1990, 0);
            Person p2 = new Person(p1);
            Assert.Equal(p1.Name, p2.Name);
            Assert.Equal(p1.Yob, p2.Yob);
        }

        [Fact]
        public void Constructor_MacDinh()
        {
            Person p = new Person();
            Assert.Equal(0, p.Id);
            Assert.Equal("", p.Name);
            Assert.Equal(2000, p.Yob);
            Assert.Equal(0, p.Yod);
        }
    }

    // =================================================================
    // BÀI 1.4: PHÂN SỐ
    // =================================================================
    public class PhanSoTests
    {
        [Theory]
        [InlineData(1, 2, 1, 3, 5, 6)]     // 1/2 + 1/3 = 5/6
        [InlineData(1, 4, 1, 4, 1, 2)]     // 1/4 + 1/4 = 1/2
        [InlineData(0, 1, 3, 7, 3, 7)]     // 0 + 3/7 = 3/7
        public void Cong_TinhDung(int t1, int m1, int t2, int m2, int rt, int rm)
        {
            PhanSo a = new PhanSo(t1, m1);
            PhanSo b = new PhanSo(t2, m2);
            PhanSo c = a + b;
            Assert.Equal(rt, c.Tu);
            Assert.Equal(rm, c.Mau);
        }

        [Fact]
        public void Tru_TinhDung()
        {
            PhanSo a = new PhanSo(1, 2);
            PhanSo b = new PhanSo(1, 3);
            PhanSo c = a - b;
            Assert.Equal(1, c.Tu);
            Assert.Equal(6, c.Mau);
        }

        [Fact]
        public void Nhan_TinhDung()
        {
            PhanSo a = new PhanSo(2, 3);
            PhanSo b = new PhanSo(3, 4);
            PhanSo c = a * b;
            Assert.Equal(1, c.Tu);
            Assert.Equal(2, c.Mau);
        }

        [Fact]
        public void Chia_TinhDung()
        {
            PhanSo a = new PhanSo(1, 2);
            PhanSo b = new PhanSo(1, 3);
            PhanSo c = a / b;
            Assert.Equal(3, c.Tu);
            Assert.Equal(2, c.Mau);
        }

        [Fact]
        public void Chia_Cho0_NemException()
        {
            PhanSo a = new PhanSo(1, 2);
            PhanSo b = new PhanSo(0, 1);
            Assert.Throws<DivideByZeroException>(() => a / b);
        }

        [Fact]
        public void Constructor_MauBang0_NemException()
        {
            Assert.Throws<DivideByZeroException>(() => new PhanSo(1, 0));
        }

        [Fact]
        public void RutGon_TuDong()
        {
            PhanSo ps = new PhanSo(4, 6);
            Assert.Equal(2, ps.Tu);
            Assert.Equal(3, ps.Mau);
        }

        [Fact]
        public void MauAm_ChuyenSang()
        {
            PhanSo ps = new PhanSo(1, -2);
            Assert.Equal(-1, ps.Tu);
            Assert.Equal(2, ps.Mau);
        }

        [Theory]
        [InlineData(1, 2, 1, 3, true)]    // 1/2 > 1/3
        [InlineData(1, 3, 1, 2, false)]   // 1/3 > 1/2 → false
        public void SoSanh_LonHon(int t1, int m1, int t2, int m2, bool md)
        {
            Assert.Equal(md, new PhanSo(t1, m1) > new PhanSo(t2, m2));
        }

        [Fact]
        public void SoSanh_BangNhau()
        {
            Assert.True(new PhanSo(1, 2) == new PhanSo(2, 4));
            Assert.True(new PhanSo(1, 3) != new PhanSo(1, 2));
        }

        [Fact]
        public void MotNgoi_LayAm()
        {
            PhanSo a = new PhanSo(3, 4);
            PhanSo b = -a;
            Assert.Equal(-3, b.Tu);
            Assert.Equal(4, b.Mau);
        }
    }

    // =================================================================
    // BÀI 1.5: ĐƠN THỨC
    // =================================================================
    public class DonThucTests
    {
        [Theory]
        [InlineData(3, 2, 2, 12)]    // 3x² tại x=2 → 12
        [InlineData(2, 3, 3, 54)]    // 2x³ tại x=3 → 54
        [InlineData(5, 0, 99, 5)]    // 5 (hằng số) → 5
        [InlineData(0, 5, 10, 0)]    // 0x⁵ → 0
        public void TinhGiaTri_TinhDung(double a, int n, double x, double md)
        {
            DonThuc dt = new DonThuc(a, n);
            Assert.Equal(md, dt.TinhGiaTri(x), precision: 4);
        }

        [Fact]
        public void DaoHam_3x2_Thanh6x()
        {
            DonThuc dt = new DonThuc(3, 2);
            DonThuc dh = dt.DaoHam();
            Assert.Equal(6, dh.HeSo);
            Assert.Equal(1, dh.Bac);
        }

        [Fact]
        public void DaoHam_HangSo_Bang0()
        {
            DonThuc dt = new DonThuc(5, 0);
            DonThuc dh = dt.DaoHam();
            Assert.Equal(0, dh.HeSo);
        }

        [Fact]
        public void DaoHam_4x3_Thanh12x2()
        {
            DonThuc dt = new DonThuc(4, 3);
            DonThuc dh = dt.DaoHam();
            Assert.Equal(12, dh.HeSo);
            Assert.Equal(2, dh.Bac);
        }
    }

    // =================================================================
    // BÀI 2.1: ARRAY POINT
    // =================================================================
    public class ArrayPointTests
    {
        [Fact]
        public void AddVaIndexer_HoatDongDung()
        {
            ArrayPoint ap = new ArrayPoint();
            ap.Add(new Point(1, 2));
            ap.Add(new Point(3, 4));

            Assert.Equal(2, ap.Count);
            Assert.Equal(1, ap[0].X);
            Assert.Equal(4, ap[1].Y);
        }

        [Fact]
        public void Indexer_NgoaiPhamVi_NemException()
        {
            ArrayPoint ap = new ArrayPoint();
            ap.Add(new Point(1, 2));

            Assert.Throws<IndexOutOfRangeException>(() => ap[5]);
        }
    }

    // =================================================================
    // BÀI 2.2: PERSON LIST
    // =================================================================
    public class PersonListTests
    {
        [Fact]
        public void LivingPeople_LocDung()
        {
            PersonList pl = new PersonList();
            pl.Add(new Person(1, "A", 1990, 0));
            pl.Add(new Person(2, "B", 1950, 2020));
            pl.Add(new Person(3, "C", 1985, 0));
            pl.Add(new Person(4, "D", 1970, 2015));

            PersonList living = pl.LivingPeople();

            Assert.Equal(2, living.Count);
            Assert.Equal("A", living[0].Name);
            Assert.Equal("C", living[1].Name);
        }

        [Fact]
        public void LivingPeople_KhongCoAiSong_Rong()
        {
            PersonList pl = new PersonList();
            pl.Add(new Person(1, "A", 1900, 1980));

            Assert.Equal(0, pl.LivingPeople().Count);
        }

        [Fact]
        public void CopyConstructor_DeepCopy()
        {
            PersonList pl1 = new PersonList();
            pl1.Add(new Person(1, "Test", 2000, 0));

            PersonList pl2 = new PersonList(pl1);
            Assert.Equal(1, pl2.Count);
            Assert.Equal("Test", pl2[0].Name);
        }
    }

    // =================================================================
    // BÀI 2.3: DÃY SỐ
    // =================================================================
    public class DaySoTests
    {
        [Fact]
        public void Indexer_DocVaGhi()
        {
            DaySo ds = new DaySo(new int[] { 10, 20, 30 });
            Assert.Equal(20, ds[1]);
            ds[1] = 99;
            Assert.Equal(99, ds[1]);
        }

        [Fact]
        public void TimSoChan_LocDung()
        {
            DaySo ds = new DaySo(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 });
            int[] chan = ds.TimSoChan();
            Assert.Equal(4, chan.Length);
            Assert.Equal(new int[] { 2, 4, 6, 8 }, chan);
        }

        [Fact]
        public void TimSoChan_KhongCoChan_Rong()
        {
            DaySo ds = new DaySo(new int[] { 1, 3, 5, 7 });
            Assert.Empty(ds.TimSoChan());
        }

        [Fact]
        public void CopyConstructor_DeepCopy()
        {
            DaySo ds1 = new DaySo(new int[] { 1, 2, 3 });
            DaySo ds2 = new DaySo(ds1);
            ds2[0] = 99;
            Assert.Equal(1, ds1[0]); // ds1 không bị ảnh hưởng
        }
    }

    // =================================================================
    // BÀI 2.4: MẢNG 2 CHIỀU
    // =================================================================
    public class Mang2ChieuTests
    {
        [Fact]
        public void Indexer_DocGhi()
        {
            Mang2Chieu m = new Mang2Chieu(3, 3);
            m[1, 2] = 42;
            Assert.Equal(42, m[1, 2]);
        }

        [Fact]
        public void TimSoNguyenTo_TinhDung()
        {
            int[,] data = { { 2, 3, 4 }, { 5, 6, 7 }, { 8, 9, 11 } };
            Mang2Chieu m = new Mang2Chieu(data);
            int[] nt = m.TimSoNguyenTo();

            Assert.Equal(5, nt.Length); // 2, 3, 5, 7, 11
            Assert.Contains(2, nt);
            Assert.Contains(11, nt);
            Assert.DoesNotContain(4, nt);
        }

        [Fact]
        public void Constructor_TuMang_SaoChepDung()
        {
            int[,] data = { { 1, 2 }, { 3, 4 } };
            Mang2Chieu m = new Mang2Chieu(data);
            Assert.Equal(2, m.Dong);
            Assert.Equal(2, m.Cot);
            Assert.Equal(4, m[1, 1]);
        }
    }

    // =================================================================
    // BÀI 2.3b: ĐA THỨC
    // =================================================================
    public class DaThucTests
    {
        [Theory]
        [InlineData(0, 1)]        // P(0) = 1
        [InlineData(1, 6)]        // P(1) = 1+2+3 = 6
        [InlineData(2, 17)]       // P(2) = 1+4+12 = 17
        [InlineData(-1, 2)]       // P(-1) = 1-2+3 = 2
        public void TinhGiaTri_DaThuc_1_2x_3x2(double x, double md)
        {
            DaThuc dt = new DaThuc(new double[] { 1, 2, 3 });
            Assert.Equal(md, dt.TinhGiaTri(x), precision: 4);
        }

        [Fact]
        public void Bac_TraVeDung()
        {
            DaThuc dt = new DaThuc(new double[] { 1, 2, 3, 4 });
            Assert.Equal(3, dt.Bac);
        }

        [Fact]
        public void Indexer_TruyCapDonThuc()
        {
            DaThuc dt = new DaThuc(new double[] { 1, 2, 3 });
            Assert.Equal(2, dt[1].HeSo);
            Assert.Equal(1, dt[1].Bac);
        }
    }

    // =================================================================
    // BÀI 2.4b: DÃY PHÂN SỐ
    // =================================================================
    public class DayPhanSoTests
    {
        [Fact]
        public void TinhTong_1_2_plus_1_3_plus_1_6_Bang1()
        {
            DayPhanSo dps = new DayPhanSo(new PhanSo[]
            {
                new PhanSo(1, 2),
                new PhanSo(1, 3),
                new PhanSo(1, 6)
            });
            PhanSo tong = dps.TinhTong();
            Assert.Equal(1, tong.Tu);
            Assert.Equal(1, tong.Mau);
        }

        [Fact]
        public void TinhTong_MangRong_Bang0()
        {
            DayPhanSo dps = new DayPhanSo(new PhanSo[0]);
            PhanSo tong = dps.TinhTong();
            Assert.Equal(0, tong.Tu);
        }
    }

    // =================================================================
    // BÀI 2.5: PHÒNG BAN
    // =================================================================
    public class PhongBanTests
    {
        [Fact]
        public void TongLuong_TinhDung()
        {
            PhongBan pb = new PhongBan();
            pb.Add(new NhanVienPB("A", 10000000, 2));  // 9.8tr
            pb.Add(new NhanVienPB("B", 8000000, 0));   // 8tr
            pb.Add(new NhanVienPB("C", 5000000, 1));   // 4.9tr

            Assert.Equal(22700000, pb.TongLuong());
        }

        [Fact]
        public void NhanVien_VangNhieu_LuongKhongAm()
        {
            NhanVienPB nv = new NhanVienPB("X", 500000, 100);
            Assert.Equal(0, nv.TinhLuong());
        }
    }

    // =================================================================
    // BÀI 3.1: SẮP XẾP IComparable
    // =================================================================
    public class SortIComparableTests
    {
        [Fact]
        public void ArraySort_SapXepPhanSoTangDan()
        {
            PhanSoComparable[] arr =
            {
                new PhanSoComparable(3, 4),
                new PhanSoComparable(1, 2),
                new PhanSoComparable(2, 3)
            };
            Array.Sort(arr);

            Assert.Equal("1/2", arr[0].ToString());
            Assert.Equal("2/3", arr[1].ToString());
            Assert.Equal("3/4", arr[2].ToString());
        }
    }

    // =================================================================
    // BÀI 3.3: SẮP XẾP DELEGATE
    // =================================================================
    public class SortDelegateTests
    {
        [Fact]
        public void SapXep_TangDan()
        {
            int[] arr = { 5, 2, 8, 1, 9 };
            SapXepHelper.SapXep(arr, (a, b) => a.CompareTo(b));
            Assert.Equal(new int[] { 1, 2, 5, 8, 9 }, arr);
        }

        [Fact]
        public void SapXep_GiamDan()
        {
            int[] arr = { 5, 2, 8, 1, 9 };
            SapXepHelper.SapXep(arr, (a, b) => b.CompareTo(a));
            Assert.Equal(new int[] { 9, 8, 5, 2, 1 }, arr);
        }
    }

    // =================================================================
    // BÀI 3.5: KẾ THỪA NHÂN VIÊN
    // =================================================================
    public class NhanVienCtyTests
    {
        [Theory]
        [InlineData(5000000, 3, 6500000)]    // 5tr + 3×500k = 6.5tr
        [InlineData(3000000, 0, 3000000)]    // 3tr + 0 = 3tr
        [InlineData(10000000, 5, 12500000)]  // 10tr + 5×500k = 12.5tr
        public void NVKinhDoanh_TinhLuong(double cb, int hd, double md)
        {
            NVKinhDoanh nv = new NVKinhDoanh("KD01", "Test", cb, hd);
            Assert.Equal(md, nv.TinhLuong());
        }

        [Theory]
        [InlineData(2000, 2000000)]    // 2000×1000 = 2tr (≤3000 nên không thưởng)
        [InlineData(3000, 3000000)]    // 3000×1000 = 3tr (=3000 nên không thưởng)
        [InlineData(4000, 4200000)]    // 4000×1000×1.05 = 4.2tr (>3000 thưởng 5%)
        [InlineData(5000, 5250000)]    // 5000×1000×1.05 = 5.25tr
        public void NVSanXuat_TinhLuong(int sp, double md)
        {
            NVSanXuat nv = new NVSanXuat("SX01", "Test", sp);
            Assert.Equal(md, nv.TinhLuong());
        }

        [Fact]
        public void DaHinh_MangNhanVienCty()
        {
            NhanVienCty[] ds =
            {
                new NVKinhDoanh("KD01", "A", 5000000, 2),
                new NVSanXuat("SX01", "B", 4000)
            };

            Assert.Equal(6000000, ds[0].TinhLuong());
            Assert.Equal(4200000, ds[1].TinhLuong());
        }
    }

    // =================================================================
    // BÀI 3.6: KẾ THỪA THÍ SINH
    // =================================================================
    public class ThiSinhTests
    {
        [Theory]
        [InlineData(9, 2)]     // 9 ≤ TA ≤ 10 → +2
        [InlineData(10, 2)]
        [InlineData(7, 1)]     // 7 ≤ TA ≤ 8 → +1
        [InlineData(8, 1)]
        [InlineData(6, 0)]     // Khác → 0
        [InlineData(5, 0)]
        [InlineData(0, 0)]
        public void ThiSinhChuyen_DiemThuong(double ta, double dtMongDoi)
        {
            ThiSinhChuyen ts = new ThiSinhChuyen("C01", "Test", 5, 5, 5, ta);
            Assert.Equal(dtMongDoi, ts.DiemThuong());
        }

        [Fact]
        public void ThiSinhChuyen_TongDiem_CoDiemThuong()
        {
            // 8 + 7 + 9 + bonus(TA=9→2) = 26
            ThiSinhChuyen ts = new ThiSinhChuyen("C01", "A", 8, 7, 9, 9);
            Assert.Equal(26, ts.TongDiem());
        }

        [Fact]
        public void ThiSinhSieuCup_TongDiem_4Bai()
        {
            // 8 + 9 + 7 + 8(CSDL) = 32
            ThiSinhSieuCup ts = new ThiSinhSieuCup("SC01", "B", 8, 9, 7, 8);
            Assert.Equal(32, ts.TongDiem());
        }

        [Fact]
        public void DaHinh_MangThiSinh()
        {
            ThiSinh[] ds =
            {
                new ThiSinhChuyen("C01", "A", 8, 7, 9, 9),
                new ThiSinhSieuCup("SC01", "B", 8, 9, 7, 8)
            };

            Assert.Equal(26, ds[0].TongDiem());
            Assert.Equal(32, ds[1].TongDiem());
        }

        [Fact]
        public void CuocThi_QuanLy()
        {
            CuocThi ct = new CuocThi();
            ct.Add(new ThiSinhChuyen("C01", "A", 8, 7, 9, 9));
            ct.Add(new ThiSinhSieuCup("SC01", "B", 8, 9, 7, 8));

            Assert.Equal(2, ct.Count);
            Assert.Equal(26, ct[0].TongDiem());
        }
    }
}
