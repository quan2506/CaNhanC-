using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>
    /// Bài tập lớp (buổi Combobox) - Bài 1: nhập số, lưu vào ComboBox;
    /// chọn một số thì liệt kê các ước số của nó vào ListBox; có 3 nút tính toán trên các ước đó.
    /// </summary>
    public class frmCombobox : Form
    {
        private TextBox txtSo;
        private ComboBox cboSo;
        private ListBox lstUoc;

        public frmCombobox()
        {
            Text = "Combobox";
            ClientSize = new Size(440, 270);
            StartPosition = FormStartPosition.CenterScreen;

            // Nhóm "Nhập Số": TextBox + nút Cập nhật + ComboBox
            // Ký tự & trước một chữ cái tạo HotKey: &Cập nhật => nhấn Alt+C tương đương bấm nút
            var gbNhap = new GroupBox { Text = "Nhập Số", Location = new Point(10, 5), Size = new Size(190, 95) };
            txtSo = new TextBox { Location = new Point(10, 25), Size = new Size(80, 23) };
            var btnCapNhat = new Button { Text = "&Cập nhật", Location = new Point(100, 24), Size = new Size(80, 25) };
            cboSo = new ComboBox { Location = new Point(10, 60), Size = new Size(170, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            gbNhap.Controls.AddRange(new Control[] { txtSo, btnCapNhat, cboSo });

            // Nhóm "Danh sách các ước số" chứa ListBox lấp đầy
            var gbUoc = new GroupBox { Text = "Danh sách các ước số", Location = new Point(210, 5), Size = new Size(220, 120) };
            lstUoc = new ListBox { Dock = DockStyle.Fill };
            gbUoc.Controls.Add(lstUoc);

            // Các nút tính toán + Thoát, mỗi nút có HotKey riêng
            var btnTong = new Button { Text = "&Tổng các ước số", Location = new Point(210, 135), Size = new Size(220, 28) };
            var btnChan = new Button { Text = "&Số lượng các ước số chẵn", Location = new Point(210, 170), Size = new Size(220, 28) };
            var btnNT = new Button { Text = "Số lượng các ước số &nguyên tố", Location = new Point(210, 205), Size = new Size(220, 28) };
            var btnThoat = new Button { Text = "Th&oát", Location = new Point(110, 205), Size = new Size(90, 28) };
            Controls.AddRange(new Control[] { gbNhap, gbUoc, btnTong, btnChan, btnNT, btnThoat });

            btnCapNhat.Click += (s, e) => CapNhat();
            cboSo.SelectedIndexChanged += (s, e) => HienUoc();   // Chọn số khác trong ComboBox => hiện ước số của số đó
            // Ba nút tính: lấy các ước đang có trên ListBox rồi hiển thị kết quả bằng MessageBox (theo đề)
            btnTong.Click += (s, e) => MessageBox.Show("Tổng các ước số: " + Uoc().Sum());
            btnChan.Click += (s, e) => MessageBox.Show("Số lượng ước số chẵn: " + Uoc().FindAll(x => x % 2 == 0).Count);
            btnNT.Click += (s, e) => MessageBox.Show("Số lượng ước số nguyên tố: " + Uoc().FindAll(NguyenTo).Count);
            // btnThoat: thoát khỏi ứng dụng có xác nhận từ người dùng
            btnThoat.Click += (s, e) =>
            {
                if (MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Close();
            };
            AcceptButton = btnCapNhat;   // Nhấn Enter ở bất kỳ đâu trên form = bấm nút Cập nhật
        }

        // Nút Cập nhật: kiểm tra dữ liệu nhập -> kiểm tra trùng -> thêm vào ComboBox
        private void CapNhat()
        {
            // int.TryParse: trả false nếu chuỗi không phải số nguyên (không gây lỗi chương trình)
            if (!int.TryParse(txtSo.Text.Trim(), out int n) || n <= 0)
            {
                MessageBox.Show("Vui lòng nhập một số nguyên dương!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSo.SelectAll(); txtSo.Focus();   // Bôi đen nội dung sai để người dùng gõ đè
                return;
            }
            // Kiểm tra số vừa nhập đã có trong ComboBox chưa
            if (cboSo.Items.Contains(n))
            {
                MessageBox.Show("Số này đã tồn tại trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSo.SelectAll(); txtSo.Focus();
                return;
            }
            cboSo.Items.Add(n);
            cboSo.SelectedItem = n;   // Chọn luôn số vừa thêm (kích hoạt SelectedIndexChanged => hiện ước số)
            txtSo.Clear();            // Xóa dữ liệu trong textbox
            txtSo.Focus();            // Đặt con trỏ lại textbox
        }

        // Liệt kê các ước số của số đang chọn vào ListBox
        private void HienUoc()
        {
            lstUoc.Items.Clear();
            if (cboSo.SelectedItem == null) return;
            int n = (int)cboSo.SelectedItem;
            for (int i = 1; i <= n; i++)
                if (n % i == 0) lstUoc.Items.Add(i);   // i là ước của n nếu n chia hết cho i
        }

        // Đọc các ước số đang có trên ListBox ra một List<int> để tính toán
        private List<int> Uoc()
        {
            var ds = new List<int>();
            foreach (var x in lstUoc.Items) ds.Add((int)x);
            return ds;
        }

        // Kiểm tra số nguyên tố: n >= 2 và không chia hết cho số nào từ 2 đến căn bậc hai của n
        private static bool NguyenTo(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)   // i*i <= n tương đương i <= căn(n)
                if (n % i == 0) return false;
            return true;
        }
    }

    // Phương thức mở rộng: thêm hàm Sum() (tính tổng) cho List<int>
    internal static class ListExt
    {
        public static int Sum(this List<int> ds) { int t = 0; foreach (var x in ds) t += x; return t; }
    }
}
