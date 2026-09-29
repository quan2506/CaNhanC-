using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiThucHanhLINQ
{
    // Lớp MonHoc: đại diện cho 1 môn học
    // Dùng auto-implemented property với giá trị mặc định ""
    // SoTiet dùng kiểu byte (0-255) tiết kiệm bộ nhớ
    public class MonHoc
    {
        public string MaMon { get; set; } = "";
        public string TenMon { get; set; } = "";
        public string He { get; set; } = "";     // "KTV", "CD", hoặc "" (chưa khai báo)
        public byte SoTiet { get; set; }          // byte: 0-255, đủ cho số tiết
    }

    // Lớp He: đại diện cho 1 hệ đào tạo
    // MaHe là key dùng để join với MonHoc.He
    public class He
    {
        public string MaHe { get; set; } = "";
        public string TenHe { get; set; } = "";
    }

    // Lớp DuLieu: static class chứa dữ liệu mẫu
    // static class: không thể tạo đối tượng (new), gọi qua tên lớp: DuLieu.DS_Mon()
    // Dùng expression-bodied member (=>) thay cho { return ...; }
    public static class DuLieu
    {
        // Trả về List<MonHoc> gồm 18 môn: 8 KTV + 9 CD + 1 chưa khai báo
        // Collection initializer: new List<T> { item1, item2, ... }
        // Object initializer: new MonHoc { MaMon="...", TenMon="..." }
        public static List<MonHoc> DS_Mon() => new List<MonHoc>
        {
            new MonHoc { MaMon="HP2_1", TenMon="Nền tảng C#", He="KTV", SoTiet=64 },
            new MonHoc { MaMon="HP2_2", TenMon="Công nghệ ADO.NET", He="KTV", SoTiet=64 },
            new MonHoc { MaMon="HP3_1", TenMon="Lập trình Windows Forms", He="KTV", SoTiet=64 },
            new MonHoc { MaMon="HP3_2", TenMon="Xây dựng ứng dụng Windows Forms", He="KTV", SoTiet=64 },
            new MonHoc { MaMon="HP4_1", TenMon="Lập trình Web với HTML, CSS và JavaScript", He="KTV", SoTiet=64 },
            new MonHoc { MaMon="HP4_2", TenMon="Xây dựng ứng dụng Web với ASP.NET", He="KTV", SoTiet=64 },
            new MonHoc { MaMon="HP5_1", TenMon="Lập trình CSDL SQL Server căn bản", He="KTV", SoTiet=64 },
            new MonHoc { MaMon="HP5_2", TenMon="Lập trình CSDL SQL Server nâng cao", He="KTV", SoTiet=64 },
            new MonHoc { MaMon="JLCB", TenMon="Joomla cơ bản", He="CD", SoTiet=72 },
            new MonHoc { MaMon="LINQ", TenMon="Language-Integrated Query", He="CD", SoTiet=64 },
            new MonHoc { MaMon="DAWEB", TenMon="Đồ án thực tế Web với ASP.NET", He="CD", SoTiet=40 },
            new MonHoc { MaMon="DAWIN", TenMon="Đồ án thực tế Windows Forms", He="CD", SoTiet=40 },
            new MonHoc { MaMon="CC++", TenMon="Lập trình hướng đối tượng với C/C++", He="CD", SoTiet=128 },
            new MonHoc { MaMon="JQUE", TenMon="JQuery", He="CD", SoTiet=22 },
            new MonHoc { MaMon="XML", TenMon="Công nghệ XML", He="CD", SoTiet=32 },
            new MonHoc { MaMon="CRYS", TenMon="Crystal Report trong Visual Studio", He="CD", SoTiet=32 },
            new MonHoc { MaMon="BWEB", TenMon="HTML, CSS và JavaScript", He="CD", SoTiet=32 },
            new MonHoc { MaMon="XYZ", TenMon="Chưa đặt tên môn", He="", SoTiet=0 }, // He rỗng: dùng để test full outer join
        };

        // Trả về List<He> gồm 3 hệ
        // Hệ QT không có môn nào → dùng để test left outer join
        public static List<He> DS_He() => new List<He>
        {
            new He { MaHe="KTV", TenHe="Kỹ thuật viên" },
            new He { MaHe="CD", TenHe="Chuyên đề" },
            new He { MaHe="QT", TenHe="Chứng chỉ quốc tế" },
        };
    }

    class Program
    {
        // ===============================================================
        // BAI 2.1: TRUY VAN MANG SO NGUYEN
        // Mục tiêu: Where (lọc), Select (biến đổi), Query vs Method Syntax
        // ===============================================================
        static void Bai21()
        {
            Console.WriteLine("=== BAI 2.1: TRUY VAN MANG SO NGUYEN ===\n");
            int[] mangSo = { 50, 42, 16, 3, 9, 8, 12, 7, 24, 0 };

            // a. Chia hết cho 4 VÀ 3 (tức chia hết cho BCNN = 12)
            // Query Syntax: from...where...select (giống SQL)
            // Method Syntax: .Where(lambda) — lambda: s => biểu_thức_bool
            Console.WriteLine("a. Chia het cho 4 va 3:");
            var a_q = from s in mangSo where s % 4 == 0 && s % 3 == 0 select s;
            Console.Write("   Query:  "); foreach (var x in a_q) Console.Write("{0} ", x);
            var a_m = mangSo.Where(s => s % 4 == 0 && s % 3 == 0);  // Method Syntax tương đương
            Console.Write("\n   Method: "); foreach (var x in a_m) Console.Write("{0} ", x);

            // b. Phần tử <= 3
            // <= : toán tử so sánh "nhỏ hơn hoặc bằng"
            Console.WriteLine("\n\nb. Phan tu <= 3:");
            var b_q = from s in mangSo where s <= 3 select s;
            Console.Write("   Query:  "); foreach (var x in b_q) Console.Write("{0} ", x);
            var b_m = mangSo.Where(s => s <= 3);
            Console.Write("\n   Method: "); foreach (var x in b_m) Console.Write("{0} ", x);

            // c. Số chẵn chia đôi, số lẻ giữ nguyên
            // Dùng Select (projection) thay vì Where (lọc)
            // Toán tử 3 ngôi: điều_kiện ? giá_trị_đúng : giá_trị_sai
            Console.WriteLine("\n\nc. Chan chia doi, le giu nguyen:");
            var c_q = from s in mangSo select (s % 2 == 0 ? s / 2 : s);  // s%2==0 → chẵn
            Console.Write("   Query:  "); foreach (var x in c_q) Console.Write("{0} ", x);
            var c_m = mangSo.Select(s => s % 2 == 0 ? s / 2 : s);        // Select: biến đổi mỗi phần tử
            Console.Write("\n   Method: "); foreach (var x in c_m) Console.Write("{0} ", x);
            Console.WriteLine("\n");
        }

        // ===============================================================
        // BAI 2.2: TRUY VAN MANG CHUOI
        // Mục tiêu: Length, orderby, ToLower/ToUpper, Contains, char.IsUpper
        // ===============================================================
        static void Bai22()
        {
            Console.WriteLine("=== BAI 2.2: TRUY VAN MANG CHUOI ===\n");
            // Mảng 14 chuỗi trích Truyện Kiều
            string[] mangChuoi = { "đầu", "lòng", "hai", "ả", "tố", "nga",
                "Thúy", "Kiều", "là", "chị", "em", "là", "Thúy", "Vân" };

            // a. Lọc phần tử có 4 ký tự, sắp xếp tăng dần theo ký tự đầu
            // s.Length: thuộc tính trả về số ký tự (Unicode)
            // orderby s[0]: sắp xếp theo mã Unicode ký tự đầu (hoa < thường)
            Console.WriteLine("a. Phan tu co 4 ky tu, sap xep tang dan:");
            var a_q = from s in mangChuoi where s.Length == 4 orderby s[0] select s;
            Console.Write("   "); foreach (var x in a_q) Console.Write("{0} ", x);

            // b. Biến đổi: <chữ thường> - <CHỮ HOA>
            // $"...{biểu_thức}...": string interpolation (nội suy chuỗi)
            // ToLower(): trả về chuỗi MỚI chữ thường (chuỗi gốc không đổi, immutable)
            // ToUpper(): trả về chuỗi MỚI CHỮ HOA
            Console.WriteLine("\n\nb. Bien doi <chu thuong> - <CHU HOA>:");
            var b_q = from s in mangChuoi select $"{s.ToLower()} - {s.ToUpper()}";
            foreach (var x in b_q) Console.WriteLine("   {0}", x);

            // c. Lọc phần tử chứa ký tự "u" (không dấu)
            // Contains("u"): so sánh chính xác Unicode, "u" ≠ "ú" ≠ "ù" ≠ "ủ"
            Console.WriteLine("c. Phan tu chua ky tu u:");
            var c_q = mangChuoi.Where(s => s.Contains("u"));
            Console.Write("   "); foreach (var x in c_q) Console.Write("{0} ", x);

            // d. Phần tử bắt đầu bằng chữ in hoa
            // !string.IsNullOrEmpty(s): kiểm tra an toàn trước khi truy cập s[0]
            // &&: short-circuit — nếu vế trái false thì không kiểm tra vế phải
            // char.IsUpper(s[0]): kiểm tra ký tự đầu có phải chữ HOA không
            Console.WriteLine("\n\nd. Phan tu bat dau bang chu in hoa:");
            var d_q = mangChuoi.Where(s => !string.IsNullOrEmpty(s) && char.IsUpper(s[0]));
            Console.Write("   "); foreach (var x in d_q) Console.Write("{0} ", x);
            Console.WriteLine("\n");
        }

        // ===============================================================
        // BAI 3.1: THONG KE MANG SO
        // Mục tiêu: Count, Sum, Max, Min, Distinct, GroupBy
        // ===============================================================
        static void Bai31()
        {
            Console.WriteLine("=== BAI 3.1: THONG KE MANG SO ===\n");
            int[] mangSo = { 50, 42, 12, 3, 9, 8, 1, 50, 3, 42, 85 };

            // a. Tổng phần tử, số chẵn, số lẻ
            // Count(): không tham số → đếm tất cả
            // Count(lambda): có lambda → chỉ đếm phần tử thỏa điều kiện
            Console.WriteLine("a. Tong: {0}, Chan: {1}, Le: {2}",
                mangSo.Count(), mangSo.Count(x => x % 2 == 0), mangSo.Count(x => x % 2 != 0));

            // b. Tổng giá trị, Max, Min — các hàm aggregate (tổng hợp)
            // Sum(): tổng tất cả. Max()/Min(): giá trị lớn/nhỏ nhất
            Console.WriteLine("b. Tong={0}, Max={1}, Min={2}",
                mangSo.Sum(), mangSo.Max(), mangSo.Min());

            // c. Số giá trị khác nhau
            // Distinct(): loại trùng lặp → Count(): đếm
            // Method chaining: Distinct().Count() — pipeline
            Console.WriteLine("c. So gia tri khac nhau: {0}", mangSo.Distinct().Count());

            // d. Phân nhóm theo số dư khi chia 5
            // GroupBy(lambda): nhóm phần tử theo key trả về từ lambda
            // Trả về IEnumerable<IGrouping<int, int>>
            // g.Key: giá trị key (số dư), g: danh sách phần tử trong nhóm
            Console.WriteLine("d. Phan nhom theo so du chia 5:");
            var nhom = mangSo.GroupBy(x => x % 5);
            foreach (var g in nhom)
            {
                Console.Write("   Du {0}: ", g.Key);
                foreach (var x in g) Console.Write("{0} ", x);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // ===============================================================
        // BAI 3.2: THONG KE MANG CHUOI
        // Mục tiêu: Min/Max với selector, GroupBy trên chuỗi, Split
        // ===============================================================
        static void Bai32()
        {
            Console.WriteLine("=== BAI 3.2: THONG KE MANG CHUOI ===\n");
            // 14 món ăn Việt Nam
            string[] monAn = { "Bún bò Huế", "Hủ tiếu heo", "Bánh canh", "Bánh mì",
                "Nước Cà phê", "Mì quảng", "Cơm tấm", "Nước Chanh dây", "Mì xào",
                "Bún riêu", "Bánh cuốn", "Mì gói", "Bún chả", "Hủ tiếu Nam vang" };

            // a. Tìm phần tử ngắn nhất và dài nhất
            // Min(s => s.Length): tìm giá trị Length nhỏ nhất (trả về int, không phải phần tử)
            // Phải dùng 2 bước: tìm minLen → Where lọc phần tử có Length == minLen
            int minLen = monAn.Min(s => s.Length);
            int maxLen = monAn.Max(s => s.Length);
            Console.WriteLine("a. Ngan nhat ({0} ky tu):", minLen);
            foreach (var s in monAn.Where(s => s.Length == minLen)) Console.WriteLine("   " + s);
            Console.WriteLine("   Dai nhat ({0} ky tu):", maxLen);
            foreach (var s in monAn.Where(s => s.Length == maxLen)) Console.WriteLine("   " + s);

            // b. Phân nhóm theo từ đầu tiên
            // Split(' '): tách chuỗi thành mảng theo khoảng trắng
            // [0]: lấy từ đầu tiên làm key nhóm
            Console.WriteLine("\nb. Phan nhom theo tu dau tien:");
            var nhom = monAn.GroupBy(s => s.Split(' ')[0]);
            foreach (var g in nhom)
            {
                Console.WriteLine("   [{0}]:", g.Key);
                foreach (var x in g) Console.WriteLine("      " + x);
            }

            // c. Đếm phần tử có từ đầu là "Bánh"
            // Count(lambda): đếm phần tử thỏa điều kiện
            Console.WriteLine("\nc. So mon bat dau bang Bánh: {0}", monAn.Count(s => s.Split(' ')[0] == "Bánh"));
            Console.WriteLine();
        }

        // ===============================================================
        // BAI 5.1: TRUY VAN CO BAN List<MonHoc>
        // Mục tiêu: StartsWith, OrderBy/ThenBy, Contains + StringComparison,
        //           Select (projection), Query Syntax
        // ===============================================================
        static void Bai51()
        {
            Console.WriteLine("=== BAI 5.1: TRUY VAN CO BAN List<MonHoc> ===\n");
            var ds = DuLieu.DS_Mon();  // Lấy 18 môn từ nguồn dữ liệu

            // a. Tên môn bắt đầu bằng "Lập trình"
            // StartsWith(): kiểm tra chuỗi bắt đầu bằng chuỗi con (case-sensitive)
            Console.WriteLine("a. Mon bat dau bang 'Lap trinh':");
            var a = ds.Where(m => m.TenMon.StartsWith("Lập trình"));
            foreach (var m in a) Console.WriteLine("   {0}", m.TenMon);

            // b. Môn hệ CD, sắp xếp SoTiet giảm → MaMon tăng
            // OrderByDescending: sắp xếp CHÍNH giảm dần
            // ThenBy: sắp xếp PHỤ tăng dần (chỉ dùng sau OrderBy/OrderByDescending)
            Console.WriteLine("\nb. Mon he CD, SoTiet giam dan, MaMon tang dan:");
            var b = ds.Where(m => m.He == "CD")
                      .OrderByDescending(m => m.SoTiet)   // Sắp chính: SoTiet giảm
                      .ThenBy(m => m.MaMon);              // Sắp phụ: MaMon tăng (khi SoTiet bằng nhau)
            foreach (var m in b) Console.WriteLine("   {0,-8} {1,-45} {2}", m.MaMon, m.TenMon, m.SoTiet);

            // c. Môn chứa từ "web" (không phân biệt hoa/thường), lấy TenMon + He
            // Contains("Web", OrdinalIgnoreCase): tìm kiếm không phân biệt hoa/thường
            // Select → new { ... }: projection — tạo anonymous type chỉ chứa cột cần thiết
            Console.WriteLine("\nc. Mon chua tu 'web':");
            var c = ds.Where(m => m.TenMon.Contains("Web", StringComparison.OrdinalIgnoreCase))
                      .Select(m => new { m.TenMon, m.He });  // Anonymous type: chỉ lấy 2 trường
            foreach (var m in c) Console.WriteLine("   {0} ({1})", m.TenMon, m.He);

            // d. Môn hệ KTV, MaMon tăng dần — dùng Query Syntax
            // Query Syntax: from...where...orderby...select (giống SQL)
            // Compiler chuyển thành Method Syntax khi biên dịch
            Console.WriteLine("\nd. Mon he KTV, MaMon tang dan:");
            var d = from m in ds where m.He == "KTV" orderby m.MaMon select m;
            foreach (var m in d) Console.WriteLine("   {0,-8} {1}", m.MaMon, m.TenMon);
            Console.WriteLine();
        }

        // ===============================================================
        // BAI 5.2: THONG KE List<MonHoc>
        // Mục tiêu: Count, Sum, GroupBy, Max, First, Substring, pipeline
        // ===============================================================
        static void Bai52()
        {
            Console.WriteLine("=== BAI 5.2: THONG KE List<MonHoc> ===\n");
            var ds = DuLieu.DS_Mon();

            // a. Tổng số môn — ds.Count là property (không ngoặc), nhanh hơn .Count() method
            Console.WriteLine("a. Tong so mon: {0}", ds.Count);

            // b. Số môn "Lập trình" — Count(lambda): đếm có điều kiện
            Console.WriteLine("b. So mon 'Lap trinh': {0}", ds.Count(m => m.TenMon.StartsWith("Lập trình")));

            // c. Tổng tiết KTV — Where lọc → Sum tính tổng
            // Sum(m => m.SoTiet): SoTiet kiểu byte, Sum trả về int (tự ép kiểu)
            Console.WriteLine("c. Tong so tiet KTV: {0}", ds.Where(m => m.He == "KTV").Sum(m => m.SoTiet));

            // d. Tổng môn mỗi hệ — GroupBy → Count mỗi nhóm
            // Lọc He rỗng trước để tránh nhóm key = ""
            Console.WriteLine("\nd. Tong so mon moi he:");
            var d = ds.Where(m => !string.IsNullOrEmpty(m.He)).GroupBy(m => m.He);
            foreach (var g in d) Console.WriteLine("   He {0}: {1} mon", g.Key, g.Count());

            // e. Nhóm theo SoTiet, giảm dần
            // GroupBy trả về nhóm → OrderByDescending sắp nhóm theo Key
            Console.WriteLine("\ne. Nhom theo So tiet (giam dan):");
            var e = ds.GroupBy(m => m.SoTiet).OrderByDescending(g => g.Key);
            foreach (var g in e) Console.WriteLine("   {0} tiet: {1} mon", g.Key, g.Count());

            // f. Môn có số tiết cao nhất
            // Max(selector): tìm giá trị max → First(predicate): lấy phần tử đầu tiên match
            // First ném exception nếu không tìm thấy, FirstOrDefault trả null → an toàn hơn
            var maxTiet = ds.Max(m => m.SoTiet);
            var f = ds.First(m => m.SoTiet == maxTiet);
            Console.WriteLine("\nf. Mon co so tiet cao nhat: {0} - {1} ({2} tiet)", f.MaMon, f.TenMon, f.SoTiet);

            // g. Thống kê theo Hệ: tổng môn, tổng tiết, max tiết, min tiết
            // Pipeline: Where → GroupBy → Select (tạo anonymous type chứa thống kê)
            // Tương tự SQL: SELECT He, COUNT(*), SUM(SoTiet), MAX(SoTiet), MIN(SoTiet) GROUP BY He
            Console.WriteLine("\ng. Thong ke theo He:");
            var g_stat = ds.Where(m => !string.IsNullOrEmpty(m.He))
                          .GroupBy(m => m.He)
                          .Select(g2 => new { He=g2.Key, Tong=g2.Count(), TongTiet=g2.Sum(m=>m.SoTiet),
                                              Max=g2.Max(m=>m.SoTiet), Min=g2.Min(m=>m.SoTiet) });
            foreach (var s in g_stat)
                Console.WriteLine("   He {0}: {1} mon, {2} tiet, Max={3}, Min={4}", s.He, s.Tong, s.TongTiet, s.Max, s.Min);

            // h. Phân nhóm theo Hệ — GroupBy → vòng lặp lồng
            Console.WriteLine("\nh. Mon hoc phan nhom theo He:");
            var h = ds.Where(m => !string.IsNullOrEmpty(m.He)).GroupBy(m => m.He);
            foreach (var g3 in h)
            {
                Console.WriteLine("   [{0}]", g3.Key);
                foreach (var m in g3) Console.WriteLine("      {0,-8} {1}", m.MaMon, m.TenMon);
            }

            // i. Phân nhóm theo SoTiet, tăng dần
            // GroupBy → OrderBy sắp nhóm tăng dần theo Key
            Console.WriteLine("\ni. Nhom theo SoTiet (tang dan):");
            var i = ds.GroupBy(m => m.SoTiet).OrderBy(g4 => g4.Key);
            foreach (var g4 in i)
            {
                Console.WriteLine("   [{0} tiet]", g4.Key);
                foreach (var m in g4) Console.WriteLine("      {0,-8} {1}", m.MaMon, m.TenMon);
            }

            // j. Hệ KTV, phân nhóm theo học phần HP2, HP3, HP4, HP5
            // Substring(0, 3): cắt 3 ký tự đầu → "HP2_1" → "HP2"
            Console.WriteLine("\nj. KTV phan nhom theo hoc phan:");
            var j = ds.Where(m => m.He == "KTV")
                      .GroupBy(m => m.MaMon.Substring(0, 3))  // Key = "HP2", "HP3", "HP4", "HP5"
                      .OrderBy(g5 => g5.Key);
            foreach (var g5 in j)
            {
                Console.WriteLine("   [{0}]", g5.Key);
                foreach (var m in g5.OrderBy(m => m.MaMon))
                    Console.WriteLine("      {0,-8} {1}", m.MaMon, m.TenMon);
            }

            // k. Phân nhóm theo Hệ, chỉ lấy SoTiet > 40, sắp MaMon
            // Where LỌC TRƯỚC → GroupBy nhóm → OrderBy trong nhóm
            // Lọc trước nhóm hiệu quả hơn nhóm trước rồi lọc
            Console.WriteLine("\nk. Nhom He, SoTiet > 40, sap xep MaMon:");
            var k = ds.Where(m => m.SoTiet > 40 && !string.IsNullOrEmpty(m.He))
                      .GroupBy(m => m.He);
            foreach (var g6 in k)
            {
                Console.WriteLine("   [{0}]", g6.Key);
                foreach (var m in g6.OrderBy(m => m.MaMon))
                    Console.WriteLine("      {0,-8} {1,-45} {2} tiet", m.MaMon, m.TenMon, m.SoTiet);
            }
            Console.WriteLine();
        }

        // ===============================================================
        // BAI 6.2: JOIN HAI NGUON DU LIEU
        // Mục tiêu: Inner Join, Left Outer Join (GroupJoin + DefaultIfEmpty),
        //           Full Outer Join (Union), Take, FirstOrDefault, group by
        // ===============================================================
        static void Bai62()
        {
            Console.WriteLine("=== BAI 6.2: JOIN HAI NGUON DU LIEU ===\n");
            var dsMon = DuLieu.DS_Mon();  // 18 môn
            var dsHe = DuLieu.DS_He();    // 3 hệ

            // a. INNER JOIN: Tên hệ, Mã môn, Tên môn
            // join...on...equals: kết nối 2 nguồn theo key
            // equals (BẮT BUỘC trong LINQ, không dùng ==)
            // Chỉ trả về bản ghi có CẢ HAI BÊN match → 17 dòng (bỏ XYZ và QT)
            Console.WriteLine("a. Inner Join - Ten he, Ma mon, Ten mon:");
            var a = from m in dsMon
                    join h in dsHe on m.He equals h.MaHe    // m.He == h.MaHe
                    select new { h.TenHe, m.MaMon, m.TenMon };  // Anonymous type kết hợp 2 nguồn
            foreach (var x in a)
                Console.WriteLine("   {0,-20} {1,-8} {2}", x.TenHe, x.MaMon, x.TenMon);

            // b. LEFT OUTER JOIN: liệt kê cả hệ chưa có môn
            // join...into grp: GroupJoin — gom match vào nhóm
            // DefaultIfEmpty(): nhóm rỗng → trả 1 phần tử null (thay vì bỏ qua)
            // ?. (null-conditional): m2?.MaMon → null nếu m2 null
            // ?? (null-coalescing): null ?? "(khong co)" → dùng giá trị thay thế
            Console.WriteLine("\nb. Left Outer Join (he chua co mon):");
            var b = from h in dsHe
                    join m in dsMon on h.MaHe equals m.He into grp  // GroupJoin
                    from m2 in grp.DefaultIfEmpty()                  // Trải phẳng, null nếu rỗng
                    select new { h.TenHe, MaMon = m2?.MaMon ?? "(khong co)", TenMon = m2?.TenMon ?? "(khong co)" };
            foreach (var x in b)
                Console.WriteLine("   {0,-20} {1,-8} {2}", x.TenHe, x.MaMon, x.TenMon);

            // c. FULL OUTER JOIN: cả hệ chưa có môn + môn chưa khai báo hệ
            // LINQ không có full outer join → kết hợp 3 bước:
            // Bước 1 (left): Left join lấy hết bên trái
            // Bước 2 (right): Lọc bên phải không match
            // Bước 3: Union ghép lại (cùng kiểu anonymous type)
            Console.WriteLine("\nc. Full outer join:");
            var left = from h in dsHe
                       join m in dsMon on h.MaHe equals m.He into grp
                       from m2 in grp.DefaultIfEmpty()
                       select new { TenHe = h.TenHe, MaMon = m2?.MaMon ?? "(khong co)", TenMon = m2?.TenMon ?? "(khong co)", He = h.MaHe };
            var right = from m in dsMon
                        where !dsHe.Any(h => h.MaHe == m.He)  // Any: có ít nhất 1 match? !Any = không có
                        select new { TenHe = "(chua khai bao)", MaMon = m.MaMon, TenMon = m.TenMon, He = m.He };
            var full = left.Union(right);  // Union: hợp 2 tập, loại trùng
            foreach (var x in full)
                Console.WriteLine("   {0,-20} {1,-8} {2}", x.TenHe, x.MaMon, x.TenMon);

            // d. Chỉ liệt kê hệ chưa có môn + môn chưa khai báo hệ
            // !dsMon.Any(...): lọc hệ không có môn nào match
            // IsNullOrEmpty(m.He) || !dsHe.Any(...): He rỗng HOẶC He không tồn tại trong dsHe
            Console.WriteLine("\nd. He chua co mon + Mon chua khai bao he:");
            var heChuaCo = dsHe.Where(h => !dsMon.Any(m => m.He == h.MaHe));
            foreach (var h in heChuaCo)
                Console.WriteLine("   He: {0} - {1} (chua co mon)", h.MaHe, h.TenHe);
            var monChuaHe = dsMon.Where(m => string.IsNullOrEmpty(m.He) || !dsHe.Any(h => h.MaHe == m.He));
            foreach (var m in monChuaHe)
                Console.WriteLine("   Mon: {0} - {1} (chua khai bao he)", m.MaMon, m.TenMon);

            // e. Top 5 môn SoTiet giảm dần
            // orderby...descending: sắp giảm dần
            // .Take(5): lấy 5 phần tử đầu (tương tự TOP 5 trong SQL Server)
            Console.WriteLine("\ne. Top 5 mon SoTiet giam dan:");
            var e2 = (from m in dsMon
                     join h in dsHe on m.He equals h.MaHe
                     orderby m.SoTiet descending
                     select new { h.TenHe, m.MaMon, m.TenMon, m.SoTiet }).Take(5);
            foreach (var x in e2)
                Console.WriteLine("   {0,-20} {1,-8} {2,-40} {3}", x.TenHe, x.MaMon, x.TenMon, x.SoTiet);

            // f. Tổng số môn mỗi hệ — dùng GroupJoin (vẫn giữ hệ QT với Count=0)
            // GroupJoin giữ hệ không match (khác Inner Join + GroupBy sẽ mất QT)
            Console.WriteLine("\nf. Tong so mon moi he:");
            var f = from h in dsHe
                    join m in dsMon on h.MaHe equals m.He into grp  // GroupJoin
                    select new { h.MaHe, h.TenHe, TongMon = grp.Count() };  // grp.Count()=0 nếu rỗng
            foreach (var x in f)
                Console.WriteLine("   {0} - {1}: {2} mon", x.MaHe, x.TenHe, x.TongMon);

            // g. Số loại SoTiet khác nhau
            // Pipeline: Select (projection) → Distinct (loại trùng) → Count (đếm)
            Console.WriteLine("\ng. So loai SoTiet khac nhau: {0}", dsMon.Select(m => m.SoTiet).Distinct().Count());

            // h. Môn đầu tiên bắt đầu bằng "Lập trình"
            // FirstOrDefault: trả null nếu không tìm thấy (an toàn)
            // First: ném InvalidOperationException nếu không tìm thấy
            var h2 = dsMon.FirstOrDefault(m => m.TenMon.StartsWith("Lập trình"));
            if (h2 != null)
                Console.WriteLine("h. Mon dau tien 'Lap trinh': {0} - {1}", h2.MaMon, h2.TenMon);

            // i. Liệt kê môn theo hệ, đánh số thứ tự trong mỗi nhóm
            // group new { m, h } by h.TenHe: nhóm kết quả join theo TenHe
            // int stt = 1: biến đếm thủ công, reset = 1 cho mỗi nhóm
            // stt++: post-increment (dùng giá trị hiện tại rồi mới tăng)
            Console.WriteLine("\ni. Mon theo tung he (co STT):");
            var i2 = from m in dsMon
                     join h in dsHe on m.He equals h.MaHe
                     group new { m, h } by h.TenHe;  // Nhóm kết quả join theo tên hệ
            foreach (var g in i2)
            {
                Console.WriteLine("   [{0}]", g.Key);
                int stt = 1;  // Reset cho mỗi nhóm
                foreach (var x in g)
                    Console.WriteLine("      {0}. {1,-8} {2}", stt++, x.m.MaMon, x.m.TenMon);
            }
            Console.WriteLine();
        }

        // ===============================================================
        // MAIN: Gọi lần lượt các bài tập
        // ===============================================================
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;  // Hỗ trợ Unicode tiếng Việt

            Bai21();  // Bài 2.1: Truy vấn mảng số (Where, Select)
            Bai22();  // Bài 2.2: Truy vấn mảng chuỗi (Length, ToLower, Contains)
            Bai31();  // Bài 3.1: Thống kê mảng số (Count, Sum, Max, Distinct, GroupBy)
            Bai32();  // Bài 3.2: Thống kê mảng chuỗi (Min/Max Length, Split, GroupBy)
            Bai51();  // Bài 5.1: Truy vấn List<MonHoc> (StartsWith, OrderBy, Contains)
            Bai52();  // Bài 5.2: Thống kê List<MonHoc> (GroupBy, Sum, Substring)
            Bai62();  // Bài 6.2: Join hai nguồn (Inner, Left Outer, Full, GroupJoin)

            Console.WriteLine("\nNhan phim bat ky de thoat...");
            Console.Read();
        }
    }
}