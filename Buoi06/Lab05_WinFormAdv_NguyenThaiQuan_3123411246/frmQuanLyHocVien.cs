using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>
    /// Bài tập nâng cao 1: Quản lý học viên.
    /// MenuStrip (Cập nhật / Kết thúc) + 2 ListBox lớp A, lớp B cho chọn nhiều mục.
    /// Chức năng: chuyển lớp, xóa, nhập học viên mới (mở form phụ), hỏi xác nhận khi thoát.
    /// </summary>
    public class frmQuanLyHocVien : Form
    {
        private ListBox lstA, lstB;

        public frmQuanLyHocVien()
        {
            Text = "Quản lý học viên";
            ClientSize = new Size(420, 260);
            StartPosition = FormStartPosition.CenterScreen;

            // ----- Menu -----
            var menu = new MenuStrip();
            var mnuCapNhat = new ToolStripMenuItem("Cập nhật");
            var mnuKetThuc = new ToolStripMenuItem("&Kết thúc");   // &K => phím tắt Alt+K
            mnuCapNhat.DropDownItems.Add("Nhập học viên mới", null, (s, e) => NhapMoi());
            mnuCapNhat.DropDownItems.Add("Chuyển sang lớp B", null, (s, e) => Chuyen(lstA, lstB));   // A -> B
            mnuCapNhat.DropDownItems.Add("Chuyển sang lớp A", null, (s, e) => Chuyen(lstB, lstA));   // B -> A
            mnuCapNhat.DropDownItems.Add("Xóa học viên", null, (s, e) => Xoa());
            mnuKetThuc.Click += (s, e) => Close();   // Close() sẽ kích hoạt FormClosing bên dưới để hỏi xác nhận
            menu.Items.AddRange(new ToolStripItem[] { mnuCapNhat, mnuKetThuc });
            MainMenuStrip = menu;
            Controls.Add(menu);

            // ----- Hai ListBox -----
            // MultiExtended: giữ Ctrl hoặc Shift để chọn nhiều học viên cùng lúc
            lstA = new ListBox { Dock = DockStyle.Fill, SelectionMode = SelectionMode.MultiExtended };
            lstB = new ListBox { Dock = DockStyle.Fill, SelectionMode = SelectionMode.MultiExtended };
            lstA.Items.AddRange(new object[] { "Trần Hùng", "Nguyễn Hưng", "Lâm Tứ" });
            lstB.Items.AddRange(new object[] { "Tuấn Hưng", "Hồng Ngọc", "Anh Minh", "Bảo Lâm" });

            // Mỗi ListBox nằm trong một GroupBox có tiêu đề; Dock.Fill làm ListBox lấp đầy GroupBox
            var gbA = new GroupBox { Text = "Lớp A", Location = new Point(15, 40), Size = new Size(190, 205) };
            var gbB = new GroupBox { Text = "Lớp B", Location = new Point(215, 40), Size = new Size(190, 205) };
            gbA.Controls.Add(lstA);
            gbB.Controls.Add(lstB);
            Controls.AddRange(new Control[] { gbA, gbB });

            // Hỏi xác nhận trước khi thoát chương trình
            FormClosing += (s, e) =>
            {
                if (e.CloseReason == CloseReason.UserClosing &&
                    MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;   // Chọn No => hủy việc đóng
            };
        }

        // Kiểm tra có ít nhất một học viên được chọn trong các ListBox truyền vào.
        // Nếu không có ai được chọn: hiện MessageBox yêu cầu chọn (đúng ghi chú của đề) và trả về false.
        private static bool CoChon(params ListBox[] ds)
        {
            foreach (var l in ds) if (l.SelectedItems.Count > 0) return true;
            MessageBox.Show("Bạn phải chọn học viên trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Chuyển các mục đang chọn từ ListBox "nguon" sang ListBox "dich"
        private void Chuyen(ListBox nguon, ListBox dich)
        {
            if (!CoChon(nguon)) return;
            // Chép các mục chọn ra danh sách tạm trước. Nếu vừa duyệt SelectedItems vừa Remove,
            // tập hợp thay đổi giữa chừng sẽ gây lỗi hoặc bỏ sót phần tử.
            var ds = new List<object>();
            foreach (var x in nguon.SelectedItems) ds.Add(x);
            foreach (var x in ds) { dich.Items.Add(x); nguon.Items.Remove(x); }
        }

        // Xóa tất cả học viên đang chọn ở cả Lớp A và Lớp B
        private void Xoa()
        {
            if (!CoChon(lstA, lstB)) return;
            foreach (var l in new[] { lstA, lstB })
            {
                var ds = new List<object>();
                foreach (var x in l.SelectedItems) ds.Add(x);
                foreach (var x in ds) l.Items.Remove(x);
            }
        }

        // Mở form nhập học viên mới. ShowDialog = hiển thị dạng "modal": phải đóng form phụ mới thao tác được form chính.
        private void NhapMoi()
        {
            using var f = new frmNhapHocVien();
            // Form phụ phát sự kiện CapNhat(tên, lớp); form chính nhận và thêm tên vào ListBox đúng lớp
            f.CapNhat += (ten, lop) => (lop == "Lớp A" ? lstA : lstB).Items.Add(ten);
            f.ShowDialog(this);
        }
    }

    /// <summary>Form phụ "Nhập học viên mới": nhập họ tên + chọn lớp, bấm Cập nhật để gửi về form chính.</summary>
    public class frmNhapHocVien : Form
    {
        // Event (sự kiện tự định nghĩa) dùng để gửi dữ liệu về form chính: tham số 1 = họ tên, tham số 2 = lớp
        public event Action<string, string> CapNhat;
        private TextBox txtTen;
        private ComboBox cboLop;

        public frmNhapHocVien()
        {
            Text = "Nhập học viên mới";
            ClientSize = new Size(330, 140);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;    // Dạng hộp thoại, không kéo giãn được
            MaximizeBox = false; MinimizeBox = false;

            Controls.Add(new Label { Text = "Họ và Tên", AutoSize = true, Location = new Point(20, 25) });
            txtTen = new TextBox { Location = new Point(100, 22), Size = new Size(210, 23) };
            Controls.Add(new Label { Text = "Lớp", AutoSize = true, Location = new Point(20, 65) });
            // ComboBox chứa Lớp A và Lớp B (theo đề)
            cboLop = new ComboBox { Location = new Point(100, 62), Size = new Size(210, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            cboLop.Items.AddRange(new object[] { "Lớp A", "Lớp B" });
            cboLop.SelectedIndex = 0;

            var btnCapNhat = new Button { Text = "Cập nhật", Location = new Point(100, 100), Size = new Size(95, 28) };
            var btnTroVe = new Button { Text = "Trở về", Location = new Point(215, 100), Size = new Size(95, 28) };
            Controls.AddRange(new Control[] { txtTen, cboLop, btnCapNhat, btnTroVe });

            btnCapNhat.Click += (s, e) =>
            {
                // Họ tên rỗng: báo lỗi và đặt con trỏ vào ô Họ và Tên
                if (txtTen.Text.Trim() == "")
                {
                    MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTen.Focus();
                    return;
                }
                CapNhat?.Invoke(txtTen.Text.Trim(), cboLop.Text);   // Gửi dữ liệu về form chính (?. = chỉ gọi nếu có nơi đăng ký nhận)
                txtTen.Clear();
                txtTen.Focus();   // Sẵn sàng nhập học viên tiếp theo
            };
            btnTroVe.Click += (s, e) => Close();   // Trở về: đóng form phụ, quay lại form chính
        }
    }
}
