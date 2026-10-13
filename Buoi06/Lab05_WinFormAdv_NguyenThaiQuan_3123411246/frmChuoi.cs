using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>
    /// Bài nâng cao (buổi Combobox) - Bài 1: Form xử lý chuỗi.
    /// Tạo 50 tên ngẫu nhiên vào ListBox rồi xóa / đổi hoa-thường các phần tử; double click để đổi tên.
    /// </summary>
    public class frmChuoi : Form
    {
        // Ba mảng dữ liệu theo đề: tên đầy đủ = HỌ + TÊN LÓT + TÊN
        private static readonly string[] HO = { "Lê", "Nguyễn", "Lý", "Trần", "Lâm", "Hồ", "Lai", "Huỳnh", "La" };
        private static readonly string[] TENLOT = { "Quang", "Thành", "Ngọc", "Anh", "Xuân", "Bảo", "Cẩm", "Thị", "Kim", "Thái", "Hồng" };
        private static readonly string[] TEN = { "Hà", "Danh", "Sơn", "Mai", "Thắng", "Kỳ", "Thành", "Lâm", "Tâm", "Phụng", "Thắm" };

        private ListBox lst;
        private readonly Random rnd = new Random();   // Bộ sinh số ngẫu nhiên

        public frmChuoi()
        {
            Text = "frmChuoi";
            ClientSize = new Size(560, 400);
            StartPosition = FormStartPosition.CenterScreen;

            var btnNgauNhien = new Button { Text = "Nhập tên ngẫu nhiên", Location = new Point(50, 15), Size = new Size(165, 32) };
            lst = new ListBox { Location = new Point(50, 60), Size = new Size(170, 320), SelectionMode = SelectionMode.MultiExtended };
            Controls.AddRange(new Control[] { btnNgauNhien, lst });

            // Hai mảng song song: nhan[i] là chữ trên nút, hanhDong[i] là việc làm khi bấm nút đó.
            // Dùng vòng lặp để tạo 7 nút thay vì viết lặp 7 lần.
            string[] nhan = {
                "Xóa Phần tử đang chọn", "Xóa phần tử có tên là Sơn", "Xóa Phần tử có họ là Lê",
                "Chuyển PT đang chọn thành chữ HOA", "Chuyển PT đang chọn thành chữ thường",
                "Chuyển PT đang chọn thành viết Hoa đầu mỗi từ", "Xóa tất cả các Phần tử" };
            Action[] hanhDong = {
                XoaChon,
                () => XoaNeu(t => Tu(t, true) == "Sơn"),      // true: lấy từ cuối (tên)
                () => XoaNeu(t => Tu(t, false) == "Lê"),      // false: lấy từ đầu (họ)
                () => DoiChon(t => t.ToUpper()),              // chữ HOA
                () => DoiChon(t => t.ToLower()),              // chữ thường
                () => DoiChon(t => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(t.ToLower())),  // Viết Hoa Đầu Mỗi Từ
                () => lst.Items.Clear() };
            for (int i = 0; i < nhan.Length; i++)
            {
                var b = new Button { Text = nhan[i], Location = new Point(235, 60 + i * 46), Size = new Size(300, 40) };
                var hd = hanhDong[i];   // Copy ra biến cục bộ để mỗi nút giữ đúng hành động của nó
                b.Click += (s, e) => hd();
                Controls.Add(b);
            }

            // btnNgauNhien: thêm 50 tên, mỗi tên ghép ngẫu nhiên từ 3 mảng (rnd.Next(n) cho số từ 0 đến n-1)
            btnNgauNhien.Click += (s, e) =>
            {
                for (int i = 0; i < 50; i++)
                    lst.Items.Add($"{HO[rnd.Next(HO.Length)]} {TENLOT[rnd.Next(TENLOT.Length)]} {TEN[rnd.Next(TEN.Length)]}");
            };

            // Double click vào tên: mở hộp nhập, đổi tên mới vào đúng vị trí đó
            lst.DoubleClick += (s, e) =>
            {
                // IndexFromPoint: xác định dòng nằm dưới vị trí con trỏ chuột (-1 nếu click vào vùng trống)
                int i = lst.IndexFromPoint(lst.PointToClient(Cursor.Position));
                if (i < 0) return;
                string moi = HopThoai("Nhập tên mới:", "Đổi tên", lst.Items[i].ToString());
                if (!string.IsNullOrWhiteSpace(moi)) lst.Items[i] = moi.Trim();
            };
        }

        // Tách tên thành các từ rồi lấy từ cuối (tenCuoi = true => TÊN) hoặc từ đầu (false => HỌ)
        private static string Tu(string t, bool tenCuoi)
        {
            var p = t.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return p.Length == 0 ? "" : (tenCuoi ? p[p.Length - 1] : p[0]);
        }

        // Lấy danh sách chỉ số các dòng đang được chọn
        private List<int> ChiSoChon()
        {
            var ds = new List<int>();
            foreach (int i in lst.SelectedIndices) ds.Add(i);
            return ds;
        }

        // Xóa các phần tử đang chọn. Xóa từ CUỐI lên ĐẦU vì xóa một phần tử làm các phần tử phía sau bị dồn chỉ số.
        private void XoaChon()
        {
            var ds = ChiSoChon();
            for (int k = ds.Count - 1; k >= 0; k--) lst.Items.RemoveAt(ds[k]);
        }

        // Xóa mọi phần tử thỏa điều kiện dk (cũng duyệt từ cuối lên đầu)
        private void XoaNeu(Predicate<string> dk)
        {
            for (int i = lst.Items.Count - 1; i >= 0; i--)
                if (dk(lst.Items[i].ToString())) lst.Items.RemoveAt(i);
        }

        // Biến đổi các phần tử đang chọn bằng hàm f (ví dụ ToUpper)
        private void DoiChon(Func<string, string> f)
        {
            var ds = ChiSoChon();
            foreach (int i in ds) lst.Items[i] = f(lst.Items[i].ToString());
            foreach (int i in ds) lst.SetSelected(i, true);   // Gán lại phần tử làm mất vùng chọn nên phải chọn lại
        }

        // Hộp thoại nhập chuỗi tự tạo (thay cho InputBox của Visual Basic).
        // Trả về chuỗi người dùng nhập, hoặc null nếu bấm Hủy.
        private string HopThoai(string loiNhac, string tieuDe, string macDinh)
        {
            using var f = new Form { Text = tieuDe, ClientSize = new Size(320, 110), StartPosition = FormStartPosition.CenterParent, FormBorderStyle = FormBorderStyle.FixedDialog, MaximizeBox = false, MinimizeBox = false };
            var lbl = new Label { Text = loiNhac, AutoSize = true, Location = new Point(12, 12) };
            var txt = new TextBox { Text = macDinh, Location = new Point(12, 35), Size = new Size(295, 23) };
            var ok = new Button { Text = "OK", DialogResult = DialogResult.OK, Location = new Point(150, 70), Size = new Size(75, 27) };
            var huy = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Location = new Point(232, 70), Size = new Size(75, 27) };
            f.Controls.AddRange(new Control[] { lbl, txt, ok, huy });
            f.AcceptButton = ok; f.CancelButton = huy;   // Enter = OK, Esc = Hủy
            return f.ShowDialog(this) == DialogResult.OK ? txt.Text : null;
        }
    }
}
