using System;
using System.Drawing;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>
    /// Bài tập lớp (buổi Combobox) - Bài 2: Quản lý sinh viên bằng TreeView.
    /// Cấu trúc cây:  Danh sách lớp (gốc) -> Lớp -> "Mã, Họ tên" (sinh viên) -> Địa chỉ.
    /// </summary>
    public class frmQLSVTree : Form
    {
        private TreeView tv;
        private TreeNode goc;                    // Node gốc "Danh sách lớp"
        private ComboBox cboLop;
        private TextBox txtMa, txtTen, txtDiaChi, txtTenLop;
        private CheckBox chkThemLop;
        private GroupBox gbLop;                  // Nhóm "Thông tin lớp" (ẩn/hiện theo checkbox)

        public frmQLSVTree()
        {
            Text = "Quản lý sinh viên";
            ClientSize = new Size(640, 400);
            StartPosition = FormStartPosition.CenterScreen;

            tv = new TreeView { Location = new Point(5, 5), Size = new Size(230, 390) };
            goc = tv.Nodes.Add("Danh sách lớp");   // Nodes.Add trả về node vừa tạo

            Controls.Add(new Label { Text = "Chọn Lớp", AutoSize = true, Location = new Point(255, 15) });
            cboLop = new ComboBox { Location = new Point(330, 11), Size = new Size(290, 23), DropDownStyle = ComboBoxStyle.DropDownList };

            // Nhóm thông tin sinh viên
            var gbSV = new GroupBox { Text = "Thông tin sinh viên", Location = new Point(250, 45), Size = new Size(380, 210) };
            gbSV.Controls.Add(new Label { Text = "Mã SV:", AutoSize = true, Location = new Point(20, 33) });
            txtMa = new TextBox { Location = new Point(100, 30), Size = new Size(260, 23) };
            gbSV.Controls.Add(new Label { Text = "Họ Tên:", AutoSize = true, Location = new Point(20, 73) });
            txtTen = new TextBox { Location = new Point(100, 70), Size = new Size(260, 23) };
            gbSV.Controls.Add(new Label { Text = "Địa Chỉ", AutoSize = true, Location = new Point(20, 113) });
            txtDiaChi = new TextBox { Location = new Point(100, 110), Size = new Size(260, 23) };
            var btnCapNhat = new Button { Text = "Cập Nhật", Location = new Point(100, 150), Size = new Size(120, 30) };
            var btnXoa = new Button { Text = "Xóa", Location = new Point(240, 150), Size = new Size(120, 30) };
            gbSV.Controls.AddRange(new Control[] { txtMa, txtTen, txtDiaChi, btnCapNhat, btnXoa });

            // Checkbox "Thêm lớp" + nhóm "Thông tin lớp" (mặc định ẩn: Visible = false)
            chkThemLop = new CheckBox { Text = "Thêm lớp", AutoSize = true, Location = new Point(255, 270) };
            gbLop = new GroupBox { Text = "Thông tin lớp", Location = new Point(250, 295), Size = new Size(380, 65), Visible = false };
            gbLop.Controls.Add(new Label { Text = "Tên lớp", AutoSize = true, Location = new Point(20, 28) });
            txtTenLop = new TextBox { Location = new Point(85, 25), Size = new Size(180, 23) };
            var btnThemLop = new Button { Text = "Thêm lớp", Location = new Point(280, 24), Size = new Size(85, 26) };
            gbLop.Controls.AddRange(new Control[] { txtTenLop, btnThemLop });

            Controls.AddRange(new Control[] { tv, cboLop, gbSV, chkThemLop, gbLop });

            // Khi form hiện lên: đã có sẵn một số lớp trên TreeView (đồng thời nạp vào ComboBox)
            foreach (var l in new[] { "05DHTH1", "05DHTH2", "05DHTH3", "05DHTH4" }) ThemLop(l);
            cboLop.SelectedIndex = 0;
            goc.Expand();   // Mở rộng node gốc để thấy các lớp

            // Tích checkbox => hiện GroupBox (và các control bên trong); bỏ tích => ẩn
            chkThemLop.CheckedChanged += (s, e) => gbLop.Visible = chkThemLop.Checked;
            btnThemLop.Click += (s, e) => NhanThemLop();
            btnCapNhat.Click += (s, e) => CapNhat();
            btnXoa.Click += (s, e) => Xoa();
            tv.AfterSelect += (s, e) => HienThi();   // Chọn một node => hiển thị thông tin nếu là sinh viên
        }

        // Thêm một lớp vào cả TreeView và ComboBox.
        // Hai danh sách cùng thứ tự nên chỉ số của ComboBox chính là chỉ số node lớp trong cây.
        private void ThemLop(string ten)
        {
            goc.Nodes.Add(new TreeNode(ten) { Tag = "lop" });   // Tag đánh dấu đây là node lớp
            cboLop.Items.Add(ten);
        }

        // Nút "Thêm lớp": kiểm tra tên rỗng và trùng tên rồi mới thêm
        private void NhanThemLop()
        {
            string ten = txtTenLop.Text.Trim();
            if (ten == "")
            {
                MessageBox.Show("Vui lòng nhập tên lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (TreeNode n in goc.Nodes)
                if (n.Text.Equals(ten, StringComparison.OrdinalIgnoreCase))   // So sánh không phân biệt hoa/thường
                {
                    MessageBox.Show("Tên lớp đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            ThemLop(ten);
            txtTenLop.Clear();
        }

        // Kiểm tra mã sinh viên đã có trong toàn bộ cây chưa (duyệt từng lớp -> từng sinh viên).
        // Mã sinh viên được cất trong Tag của node sinh viên.
        private bool TonTaiMa(string ma)
        {
            foreach (TreeNode lop in goc.Nodes)
                foreach (TreeNode sv in lop.Nodes)
                    if (sv.Tag is string t && t == ma) return true;
            return false;
        }

        // Nút "Cập Nhật": thêm một sinh viên vào lớp đang chọn trên ComboBox
        private void CapNhat()
        {
            string ma = txtMa.Text.Trim(), ten = txtTen.Text.Trim(), dc = txtDiaChi.Text.Trim();
            if (cboLop.SelectedIndex < 0) { MessageBox.Show("Vui lòng chọn lớp!"); return; }
            // Kiểm tra: các textbox nhập không được để trống
            if (ma == "" || ten == "" || dc == "")
            {
                MessageBox.Show("Các ô nhập không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Kiểm tra: không trùng mã sinh viên
            if (TonTaiMa(ma))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMa.Focus();
                return;
            }
            var lop = goc.Nodes[cboLop.SelectedIndex];              // Node lớp tương ứng với lớp chọn trong ComboBox
            var sv = new TreeNode($"{ma}, {ten}") { Tag = ma };     // Node sinh viên, hiển thị "mã, họ tên", Tag giữ mã
            sv.Nodes.Add(new TreeNode(dc) { Tag = "diachi" });      // Node con là địa chỉ
            lop.Nodes.Add(sv);
            lop.Expand();
            txtMa.Clear(); txtTen.Clear(); txtDiaChi.Clear();
            txtMa.Focus();
        }

        // Node sinh viên là node ở cấp 2 (gốc = 0, lớp = 1, sinh viên = 2) và cha của nó là node lớp.
        private static bool LaSinhVien(TreeNode n) => n != null && n.Level == 2 && n.Parent.Tag is string t && t == "lop";

        // Nút "Xóa": chỉ cho xóa node sinh viên đang chọn, có xác nhận
        private void Xoa()
        {
            if (!LaSinhVien(tv.SelectedNode))
            {
                MessageBox.Show("Chỉ được xóa node là sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                tv.SelectedNode.Remove();   // Xóa node (kèm node địa chỉ con)
        }

        // Click chọn một node sinh viên: hiển thị mã, họ tên, địa chỉ lên các textbox
        private void HienThi()
        {
            var n = tv.SelectedNode;
            if (!LaSinhVien(n)) return;
            string ma = (string)n.Tag;
            txtMa.Text = ma;
            txtTen.Text = n.Text.Substring(ma.Length + 2);   // Bỏ phần "mã, " ở đầu để lấy họ tên
            txtDiaChi.Text = n.Nodes.Count > 0 ? n.Nodes[0].Text : "";   // Địa chỉ là node con đầu tiên
            cboLop.SelectedIndex = n.Parent.Index;           // Chọn lớp của sinh viên trên ComboBox
        }
    }
}
