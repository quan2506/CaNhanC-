using Xunit;
using System.Linq;
using BaiThucHanhLINQ;

namespace BaiTap.Tests
{
    // ===============================================================
    // UNIT TEST BAI 2.1: MANG SO NGUYEN
    // ===============================================================
    public class Bai21Tests
    {
        private readonly int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

        [Fact] public void ChiaHet4Va3() => Assert.Equal(new[] { 12, 24, 0 }, mangSo.Where(s => s % 4 == 0 && s % 3 == 0));
        [Fact] public void NhoHonBang3() => Assert.Equal(new[] { 3, 0 }, mangSo.Where(s => s <= 3));
        [Fact] public void ChanChiaDoi() => Assert.Equal(new[] { 25, 21, 8, 3, 9, 4, 6, 7, 12, 0 }, mangSo.Select(s => s % 2 == 0 ? s / 2 : s));
    }

    // ===============================================================
    // UNIT TEST BAI 3.1: THONG KE MANG SO
    // ===============================================================
    public class Bai31Tests
    {
        private readonly int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

        [Fact] public void TongPhanTu() => Assert.Equal(11, mangSo.Count());
        [Fact] public void SoChan() => Assert.Equal(6, mangSo.Count(x => x % 2 == 0));
        [Fact] public void SoLe() => Assert.Equal(5, mangSo.Count(x => x % 2 != 0));
        [Fact] public void Tong() => Assert.Equal(305, mangSo.Sum());
        [Fact] public void Max() => Assert.Equal(85, mangSo.Max());
        [Fact] public void Min() => Assert.Equal(1, mangSo.Min());
        [Fact] public void Distinct() => Assert.Equal(8, mangSo.Distinct().Count());

        [Theory]
        [InlineData(0, 3)]
        [InlineData(2, 3)]
        [InlineData(3, 3)]
        [InlineData(4, 1)]
        [InlineData(1, 1)]
        public void GroupByDu5(int du, int soLuong)
        {
            var nhom = mangSo.GroupBy(x => x % 5).ToDictionary(g => g.Key, g => g.Count());
            Assert.Equal(soLuong, nhom[du]);
        }
    }

    // ===============================================================
    // UNIT TEST BAI 5.1: TRUY VAN List<MonHoc>
    // ===============================================================
    public class Bai51Tests
    {
        private readonly System.Collections.Generic.List<MonHoc> ds = DuLieu.DS_Mon();

        [Fact] public void LapTrinh5Mon() => Assert.Equal(5, ds.Count(m => m.TenMon.StartsWith("L\u1EADp tr\u00ECnh")));

        [Fact]
        public void CD_GiamDan_DauCC()
        {
            var b = ds.Where(m => m.He == "CD").OrderByDescending(m => m.SoTiet).ThenBy(m => m.MaMon).ToList();
            Assert.Equal("CC++", b.First().MaMon);
            Assert.Equal("JQUE", b.Last().MaMon);
        }

        [Fact] public void ChuaWeb3Mon() => Assert.Equal(3, ds.Count(m => m.TenMon.Contains("Web", System.StringComparison.OrdinalIgnoreCase)));
        [Fact] public void KTV8Mon() => Assert.Equal(8, ds.Count(m => m.He == "KTV"));
    }

    // ===============================================================
    // UNIT TEST BAI 5.2: THONG KE List<MonHoc>
    // ===============================================================
    public class Bai52Tests
    {
        private readonly System.Collections.Generic.List<MonHoc> ds = DuLieu.DS_Mon();

        [Fact] public void TongMon18() => Assert.Equal(18, ds.Count);
        [Fact] public void TongTietKTV512() => Assert.Equal(512, ds.Where(m => m.He == "KTV").Sum(m => (int)m.SoTiet));
        [Fact] public void MaxTiet128_CC() => Assert.Equal("CC++", ds.OrderByDescending(m => m.SoTiet).First().MaMon);
        [Fact] public void SoNhomTiet7() => Assert.Equal(7, ds.GroupBy(m => m.SoTiet).Count());
        [Fact] public void KTV4NhomHP() => Assert.Equal(4, ds.Where(m => m.He == "KTV").GroupBy(m => m.MaMon.Substring(0, 3)).Count());
        [Fact] public void MoiNhomHP2Mon() => Assert.True(ds.Where(m => m.He == "KTV").GroupBy(m => m.MaMon.Substring(0, 3)).All(g => g.Count() == 2));
        [Fact] public void SoTietTren40_11Mon() => Assert.Equal(11, ds.Count(m => m.SoTiet > 40 && !string.IsNullOrEmpty(m.He)));
    }

    // ===============================================================
    // UNIT TEST BAI 6.2: JOIN
    // ===============================================================
    public class Bai62Tests
    {
        private readonly System.Collections.Generic.List<MonHoc> dsMon = DuLieu.DS_Mon();
        private readonly System.Collections.Generic.List<He> dsHe = DuLieu.DS_He();

        [Fact]
        public void InnerJoin17()
        {
            var inner = (from m in dsMon join h in dsHe on m.He equals h.MaHe select m).ToList();
            Assert.Equal(17, inner.Count);
        }

        [Fact]
        public void LeftJoin18_QTNull()
        {
            var leftJ = (from h in dsHe join m in dsMon on h.MaHe equals m.He into grp
                         from m2 in grp.DefaultIfEmpty() select new { h.MaHe, MaMon = m2?.MaMon }).ToList();
            Assert.Equal(18, leftJ.Count);
            Assert.Contains(leftJ, x => x.MaHe == "QT" && x.MaMon == null);
        }

        [Fact]
        public void FullJoin19()
        {
            var left = from h in dsHe join m in dsMon on h.MaHe equals m.He into grp
                       from m2 in grp.DefaultIfEmpty() select new { He = h.MaHe, MaMon = m2?.MaMon ?? "" };
            var right = from m in dsMon where !dsHe.Any(h => h.MaHe == m.He)
                        select new { He = m.He, MaMon = m.MaMon };
            Assert.Equal(19, left.Union(right).Count());
        }

        [Fact] public void HeChuaCoMon_QT() => Assert.Single(dsHe.Where(h => !dsMon.Any(m => m.He == h.MaHe)));
        [Fact] public void MonChuaHe_XYZ() => Assert.Equal("XYZ", dsMon.First(m => string.IsNullOrEmpty(m.He) || !dsHe.Any(h => h.MaHe == m.He)).MaMon);
        [Fact] public void Top5DauCC128() => Assert.Equal("CC++", (from m in dsMon join h in dsHe on m.He equals h.MaHe orderby m.SoTiet descending select m).First().MaMon);

        [Fact]
        public void TongMonMoiHe()
        {
            var tongHe = (from h in dsHe join m in dsMon on h.MaHe equals m.He into grp
                          select new { h.MaHe, Tong = grp.Count() }).ToDictionary(x => x.MaHe, x => x.Tong);
            Assert.Equal(8, tongHe["KTV"]);
            Assert.Equal(9, tongHe["CD"]);
            Assert.Equal(0, tongHe["QT"]);
        }

        [Fact] public void LoaiSoTiet7() => Assert.Equal(7, dsMon.Select(m => m.SoTiet).Distinct().Count());
    }
}