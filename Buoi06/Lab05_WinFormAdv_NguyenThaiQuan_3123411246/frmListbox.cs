using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>
    /// Bài về nhà (buổi Combobox) - Bài 2: Thêm số tự nhiên vào ListBox (chọn nhiều) và xử lý.
    /// Các phần tử được lưu kiểu long nên khi đọc ra phải ép kiểu: (long)lst.Items[i].
    /// </summary>
    public class frmListbox : Form
    {
        private TextBox txtSo;
        private ListBox lst;

        public frmListbox()
        {
            Text = "frmListbox";
            ClientSize = new Size(420, 400);
            StartPosition = FormStartPosition.CenterScreen;

            Controls.Add(new Label
            {
                Text = "LISTBOX", ForeColor = Color.OrangeRed, Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Location = new Point(10, 5), Size = new Size(400, 35)
            });
            Controls.Add(new Label { Text = "Listbox", AutoSize = true, Location = new Point(20, 50) });
            Controls.Add(new Label { Text = "Xử lý Listbox", AutoSize = true, Location = new Point(215, 50) });

            txtSo = new TextBox { Location = new Point(20, 70), Size = new Size(170, 23) };
            var btnNhap = new Button { Text = "&Nhập", Location = new Point(20, 100), Size = new Size(170, 30) };
            // MultiExtended: cho phép chọn nhiều phần tử (đề: "listbox được chọn nhiều phần tử")
            lst = new ListBox { Location = new Point(20, 140), Size = new Size(170, 185), SelectionMode = SelectionMode.MultiExtended };
            Controls.AddRange(new Control[] { txtSo, btnNhap, lst });

            var btnKetThuc = new Button { Text = "&KẾT THÚC", Location = new Point(20, 345), Size = new Size(375, 32) };
            Controls.Add(btnKetThuc);

            // Tạo 7 nút xử lý bằng vòng lặp: nhan[i] là chữ trên nút, hd[i] là hàm xử lý tương ứng
            string[] nhan = { "Tổng các phần tử trong List", "Xóa Phần tử đầu và cuối", "Xóa Phần tử đang chọn",
                "Tăng mỗi phần tử lên 2", "Thay bằng bình phương", "Chọn số chẵn", "Chọn số lẻ" };
            Action[] hd = { Tong, XoaDauCuoi, XoaChon, () => Doi(x => x + 2), () => Doi(x => x * x), () => Chon(0), () => Chon(1) };
            for (int i = 0; i < nhan.Length; i++)
            {
                var b = new Button { Text = nhan[i], Location = new Point(215, 70 + i * 40), Size = new Size(180, 32) };
                var h = hd[i];
                b.Click += (s, e) => h();
                Controls.Add(b);
            }

            btnNhap.Click += (s, e) => Nhap();
            AcceptButton = btnNhap;                 // Nhấn Enter = bấm Nhập
            btnKetThuc.Click += (s, e) => Close();
        }

        // Nút Nhập: kiểm tra số tự nhiên N rồi thêm vào ListBox
        private void Nhap()
        {
            if (!long.TryParse(txtSo.Text.Trim(), out long n) || n < 0)   // Số tự nhiên: số nguyên >= 0
            {
                MessageBox.Show("Vui lòng nhập số tự nhiên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo.SelectAll(); txtSo.Focus();
                return;
            }
            lst.Items.Add(n);
            txtSo.Clear();
            txtSo.Focus();
        }

        // Tính tổng tất cả các phần tử, hiện bằng MessageBox
        private void Tong()
        {
            long t = 0;
            foreach (var x in lst.Items) t += (long)x;
            MessageBox.Show("Tổng các phần tử: " + t);
        }

        // Xóa phần tử cuối trước, rồi mới xóa phần tử đầu.
        // Nếu xóa đầu trước thì chỉ số của phần tử cuối đã bị dịch đi một.
        private void XoaDauCuoi()
        {
            if (lst.Items.Count == 0) return;
            lst.Items.RemoveAt(lst.Items.Count - 1);
            if (lst.Items.Count > 0) lst.Items.RemoveAt(0);
        }

        // Xóa các phần tử đang chọn: lấy chỉ số rồi xóa từ cuối lên đầu để chỉ số không bị lệch
        private void XoaChon()
        {
            var ds = new List<int>();
            foreach (int i in lst.SelectedIndices) ds.Add(i);
            for (int k = ds.Count - 1; k >= 0; k--) lst.Items.RemoveAt(ds[k]);
        }

        // Thay mỗi phần tử x bằng f(x). Dùng chung cho "tăng 2" (x + 2) và "bình phương" (x * x).
        private void Doi(Func<long, long> f)
        {
            for (int i = 0; i < lst.Items.Count; i++) lst.Items[i] = f((long)lst.Items[i]);
        }

        // Chọn các phần tử theo số dư khi chia 2: du = 0 => số chẵn, du = 1 => số lẻ
        private void Chon(int du)
        {
            lst.ClearSelected();   // Bỏ chọn tất cả trước
            for (int i = 0; i < lst.Items.Count; i++)
                if ((long)lst.Items[i] % 2 == du) lst.SetSelected(i, true);
        }
    }
}
