using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    class TestLinq
    {
        static int pass = 0, total = 0;

        static void Check(string name, bool condition)
        {
            total++;
            if (condition) pass++;
            Console.WriteLine("  {0} => {1}", name, condition ? "PASS" : "FAIL");
        }

        static void CheckSeq<T>(string name, IEnumerable<T> actual, IEnumerable<T> expected)
        {
            total++;
            bool ok = actual.SequenceEqual(expected);
            if (ok) pass++;
            Console.WriteLine("  {0} => {1}", name, ok ? "PASS" : "FAIL");
            if (!ok)
            {
                Console.WriteLine("    Actual:   [{0}]", string.Join(", ", actual));
                Console.WriteLine("    Expected: [{0}]", string.Join(", ", expected));
            }
        }

        // ===============================================================
        // TEST BAI 2.1: MANG SO NGUYEN
        // ===============================================================
        static void TestBai21()
        {
            Console.WriteLine("\n--- Test Bai 2.1: Mang so nguyen ---");
            int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

            // a. Chia het cho 4 va 3
            var a = mangSo.Where(s => s % 4 == 0 && s % 3 == 0);
            CheckSeq("2.1a Chia het 4 va 3", a, new[] { 12, 24, 0 });

            // b. Phan tu <= 3
            var b = mangSo.Where(s => s <= 3);
            CheckSeq("2.1b Phan tu <= 3", b, new[] { 3, 0 });

            // c. Chan chia doi, le giu nguyen
            var c = mangSo.Select(s => s % 2 == 0 ? s / 2 : s);
            CheckSeq("2.1c Chan/2, le giu", c, new[] { 25, 21, 8, 3, 9, 4, 6, 7, 12, 0 });
        }

        // ===============================================================
        // TEST BAI 2.2: MANG CHUOI
        // ===============================================================
        static void TestBai22()
        {
            Console.WriteLine("\n--- Test Bai 2.2: Mang chuoi ---");
            string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga",
                "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

            // a. 4 ky tu, sap xep
            var a = (from s in mangChuoi where s.Length == 4 orderby s[0] select s).ToArray();
            Check("2.2a So phan tu 4 ky tu", a.Length == 4);

            // c. Chua ky tu u
            var c = mangChuoi.Where(s => s.Contains("u")).ToArray();
            Check("2.2c Chua ky tu u", c.Length == 2);

            // d. Bat dau bang chu in hoa
            var d = mangChuoi.Where(s => !string.IsNullOrEmpty(s) && char.IsUpper(s[0])).ToArray();
            Check("2.2d Chu in hoa", d.Length == 4);
            Check("2.2d Ket qua Thuy Kieu", d[0] == "Thúy" && d[1] == "Kiều");
        }

        // ===============================================================
        // TEST BAI 3.1: THONG KE MANG SO
        // ===============================================================
        static void TestBai31()
        {
            Console.WriteLine("\n--- Test Bai 3.1: Thong ke mang so ---");
            int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

            Check("3.1a Tong phan tu = 11", mangSo.Count() == 11);
            Check("3.1a So chan = 6", mangSo.Count(x => x % 2 == 0) == 6);
            Check("3.1a So le = 5", mangSo.Count(x => x % 2 != 0) == 5);
            Check("3.1b Tong = 305", mangSo.Sum() == 305);
            Check("3.1b Max = 85", mangSo.Max() == 85);
            Check("3.1b Min = 1", mangSo.Min() == 1);
            Check("3.1c Distinct = 8", mangSo.Distinct().Count() == 8);

            var nhom = mangSo.GroupBy(x => x % 5).ToDictionary(g => g.Key, g => g.Count());
            Check("3.1d Du 0: 3 phan tu", nhom[0] == 3);
            Check("3.1d Du 2: 3 phan tu", nhom[2] == 3);
            Check("3.1d Du 3: 3 phan tu", nhom[3] == 3);
            Check("3.1d Du 4: 1 phan tu", nhom[4] == 1);
            Check("3.1d Du 1: 1 phan tu", nhom[1] == 1);
        }

        // ===============================================================
        // TEST BAI 3.2: THONG KE MANG CHUOI
        // ===============================================================
        static void TestBai32()
        {
            Console.WriteLine("\n--- Test Bai 3.2: Thong ke mang chuoi ---");
            string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
                "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
                "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

            int minLen = monAn.Min(s => s.Length);
            int maxLen = monAn.Max(s => s.Length);
            Check("3.2a Min length = 6", minLen == 6);
            Check("3.2a Max length = 16", maxLen == 16);
            Check("3.2c So mon Banh = 3", monAn.Count(s => s.Split(' ')[0] == "Bánh") == 3);
            var nhom = monAn.GroupBy(s => s.Split(' ')[0]);
            Check("3.2b Co nhom mon an", nhom.Count() >= 4);
        }

        // ===============================================================
        // TEST BAI 5.1: TRUY VAN List<MonHoc>
        // ===============================================================
        static void TestBai51()
        {
            Console.WriteLine("\n--- Test Bai 5.1: Truy van List<MonHoc> ---");
            var ds = DuLieu.DS_Mon();

            var a = ds.Where(m => m.TenMon.StartsWith("Lập trình")).ToList();
            Check("5.1a Lap trinh: 5 mon", a.Count == 5);

            var b = ds.Where(m => m.He == "CD").OrderByDescending(m => m.SoTiet).ThenBy(m => m.MaMon).ToList();
            Check("5.1b CD giam dan: dau tien CC++", b.First().MaMon == "CC++");
            Check("5.1b CD giam dan: cuoi cung JQUE", b.Last().MaMon == "JQUE");

            var c = ds.Where(m => m.TenMon.Contains("Web", StringComparison.OrdinalIgnoreCase)).ToList();
            Check("5.1c Chua Web: 3 mon", c.Count == 3);

            var d = ds.Where(m => m.He == "KTV").OrderBy(m => m.MaMon).ToList();
            Check("5.1d KTV tang dan: 8 mon", d.Count == 8);
            Check("5.1d KTV dau tien HP2_1", d.First().MaMon == "HP2_1");
        }

        // ===============================================================
        // TEST BAI 5.2: THONG KE List<MonHoc>
        // ===============================================================
        static void TestBai52()
        {
            Console.WriteLine("\n--- Test Bai 5.2: Thong ke List<MonHoc> ---");
            var ds = DuLieu.DS_Mon();

            Check("5.2a Tong mon = 18", ds.Count == 18);
            Check("5.2b Lap trinh = 5", ds.Count(m => m.TenMon.StartsWith("Lập trình")) == 5);
            Check("5.2c Tong tiet KTV = 512", ds.Where(m => m.He == "KTV").Sum(m => (int)m.SoTiet) == 512);

            var heNhom = ds.Where(m => !string.IsNullOrEmpty(m.He)).GroupBy(m => m.He).ToDictionary(g => g.Key, g => g.Count());
            Check("5.2d KTV = 8 mon", heNhom["KTV"] == 8);
            Check("5.2d CD = 9 mon", heNhom["CD"] == 9);

            var tietNhom = ds.GroupBy(m => m.SoTiet).OrderByDescending(g => g.Key).ToList();
            Check("5.2e Nhom tiet dau = 128", tietNhom.First().Key == 128);
            Check("5.2e So nhom tiet = 7", tietNhom.Count == 7);

            Check("5.2f Max tiet = 128 (CC++)", ds.OrderByDescending(m => m.SoTiet).First().MaMon == "CC++");

            var ktvHP = ds.Where(m => m.He == "KTV").GroupBy(m => m.MaMon.Substring(0, 3)).ToList();
            Check("5.2j KTV 4 nhom HP", ktvHP.Count == 4);
            Check("5.2j Moi nhom 2 mon", ktvHP.All(g => g.Count() == 2));

            var kFilter = ds.Where(m => m.SoTiet > 40 && !string.IsNullOrEmpty(m.He)).ToList();
            Check("5.2k SoTiet > 40: 11 mon", kFilter.Count == 11);
        }

        // ===============================================================
        // TEST BAI 6.2: JOIN
        // ===============================================================
        static void TestBai62()
        {
            Console.WriteLine("\n--- Test Bai 6.2: Join hai nguon ---");
            var dsMon = DuLieu.DS_Mon();
            var dsHe = DuLieu.DS_He();

            // a. Inner join
            var inner = (from m in dsMon join h in dsHe on m.He equals h.MaHe select m).ToList();
            Check("6.2a Inner join = 17", inner.Count == 17);

            // b. Left outer join
            var leftJ = (from h in dsHe
                         join m in dsMon on h.MaHe equals m.He into grp
                         from m2 in grp.DefaultIfEmpty()
                         select new { h.MaHe, MaMon = m2?.MaMon }).ToList();
            Check("6.2b Left join = 18", leftJ.Count == 18);
            Check("6.2b QT co null", leftJ.Any(x => x.MaHe == "QT" && x.MaMon == null));

            // c. Full outer
            var left = from h in dsHe join m in dsMon on h.MaHe equals m.He into grp
                       from m2 in grp.DefaultIfEmpty()
                       select new { He = h.MaHe, MaMon = m2?.MaMon ?? "" };
            var right = from m in dsMon where !dsHe.Any(h => h.MaHe == m.He)
                        select new { He = m.He, MaMon = m.MaMon };
            Check("6.2c Full join = 19", left.Union(right).Count() == 19);

            // d. He chua co mon + mon chua he
            var heChuaCo = dsHe.Where(h => !dsMon.Any(m => m.He == h.MaHe)).ToList();
            Check("6.2d He chua co mon: QT", heChuaCo.Count == 1 && heChuaCo[0].MaHe == "QT");
            var monChuaHe = dsMon.Where(m => string.IsNullOrEmpty(m.He) || !dsHe.Any(h => h.MaHe == m.He)).ToList();
            Check("6.2d Mon chua he: XYZ", monChuaHe.Count == 1 && monChuaHe[0].MaMon == "XYZ");

            // e. Top 5
            var top5 = (from m in dsMon join h in dsHe on m.He equals h.MaHe
                        orderby m.SoTiet descending select m).Take(5).ToList();
            Check("6.2e Top5 dau = CC++ 128", top5[0].MaMon == "CC++" && top5[0].SoTiet == 128);

            // f. Tong mon moi he
            var tongHe = (from h in dsHe join m in dsMon on h.MaHe equals m.He into grp
                          select new { h.MaHe, Tong = grp.Count() }).ToDictionary(x => x.MaHe, x => x.Tong);
            Check("6.2f KTV=8, CD=9, QT=0", tongHe["KTV"]==8 && tongHe["CD"]==9 && tongHe["QT"]==0);

            // g. So loai SoTiet
            Check("6.2g Loai SoTiet = 7", dsMon.Select(m => m.SoTiet).Distinct().Count() == 7);

            // h. Mon dau tien Lap trinh
            var first = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
            Check("6.2h FirstOrDefault HP3_1", first != null && first.MaMon == "HP3_1");
        }

        // ===============================================================
        // MAIN
        // ===============================================================
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("============================================");
            Console.WriteLine("  TEST CASE - THUC HANH LINQ CO BAN        ");
            Console.WriteLine("============================================");

            TestBai21();
            TestBai22();
            TestBai31();
            TestBai32();
            TestBai51();
            TestBai52();
            TestBai62();

            Console.WriteLine("\n============================================");
            Console.WriteLine("  KET QUA: {0}/{1} PASS", pass, total);
            if (pass == total)
                Console.WriteLine("  >>> TAT CA DUNG! <<<");
            else
                Console.WriteLine("  >>> CO {0} SAI! <<<", total - pass);
            Console.WriteLine("============================================");
            Console.Read();
        }
    }
}
