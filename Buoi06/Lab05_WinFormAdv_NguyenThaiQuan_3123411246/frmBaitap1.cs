using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>
    /// Bài tập tại lớp 1 (Window Form nâng cao): Quản lý sinh viên bằng ListView.
    /// Chức năng: Thêm (không trùng mã), Sửa (không sửa mã), Xóa (nút + chuột phải),
    /// Load form nạp ComboBox dân tộc, hỏi xác nhận trước khi đóng form.
    /// </summary>
    public class frmBaitap1 : Form
    {
        // Khai báo các control ở mức class để các hàm xử lý bên dưới đều dùng được
        private TextBox txtHoTen, txtMaSV;
        private RadioButton rdoNam, rdoNu;              // RadioButton cùng form => chỉ chọn được 1 trong 2
        private CheckBox chkAnh, chkPhap, chkHoa;       // CheckBox => chọn được nhiều
        private ComboBox cboDanToc;
        private ListView lv;                            // Bảng hiển thị danh sách sinh viên
        private ContextMenuStrip ctx;                   // Menu hiện ra khi bấm chuột phải

        public frmBaitap1()
        {
            Text = "frmBaitap1";
            ClientSize = new Size(560, 480);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;

            // ----- Các ô nhập thông tin -----
            AddLabel("Họ và Tên", 60, 20);
            txtHoTen = new TextBox { Location = new Point(190, 17), Size = new Size(280, 23) };
            AddLabel("Mã sinh viên", 60, 60);
            txtMaSV = new TextBox { Location = new Point(190, 57), Size = new Size(280, 23) };

            AddLabel("Giới tính", 60, 100);
            rdoNam = new RadioButton { Text = "Nam", Checked = true, Location = new Point(190, 98), AutoSize = true };  // Mặc định Nam
            rdoNu = new RadioButton { Text = "Nữ", Location = new Point(290, 98), AutoSize = true };

            AddLabel("Ngoại ngữ", 60, 140);
            chkAnh = new CheckBox { Text = "Anh", Checked = true, Location = new Point(190, 138), AutoSize = true };   // Mặc định tích Anh
            chkPhap = new CheckBox { Text = "Pháp", Location = new Point(290, 138), AutoSize = true };
            chkHoa = new CheckBox { Text = "Hoa", Location = new Point(390, 138), AutoSize = true };

            AddLabel("Dân tộc", 60, 180);
            // DropDownList: chỉ cho chọn trong danh sách, không cho gõ tự do
            cboDanToc = new ComboBox { Location = new Point(190, 177), Size = new Size(280, 23), DropDownStyle = ComboBoxStyle.DropDownList };

            // ----- ListView dạng bảng -----
            lv = new ListView
            {
                Location = new Point(20, 220), Size = new Size(520, 190),
                View = View.Details,        // Hiển thị dạng bảng có tiêu đề cột
                FullRowSelect = true,       // Click chọn cả dòng chứ không chỉ ô đầu
                MultiSelect = false,        // Mỗi lần chỉ chọn một dòng
                GridLines = true            // Hiện đường kẻ lưới
            };
            lv.Columns.Add("Họ tên", 130);          // SubItems[0]
            lv.Columns.Add("Mã sinh viên", 100);    // SubItems[1]
            lv.Columns.Add("Giới tính", 70);        // SubItems[2]
            lv.Columns.Add("Ngoại ngữ", 120);       // SubItems[3]
            lv.Columns.Add("Dân tộc", 80);          // SubItems[4]

            var btnThem = new Button { Text = "Thêm", Location = new Point(130, 425), Size = new Size(90, 35) };
            var btnXoa = new Button { Text = "Xóa", Location = new Point(240, 425), Size = new Size(90, 35) };
            var btnSua = new Button { Text = "Sửa", Location = new Point(350, 425), Size = new Size(90, 35) };

            // ContextMenuStrip: menu chuột phải. Gán vào ListView.ContextMenuStrip để chuột phải lên ListView thì hiện menu này
            ctx = new ContextMenuStrip();
            ctx.Items.Add("Xóa", null, (s, e) => Xoa());
            lv.ContextMenuStrip = ctx;

            Controls.AddRange(new Control[] { txtHoTen, txtMaSV, rdoNam, rdoNu, chkAnh, chkPhap, chkHoa, cboDanToc, lv, btnThem, btnXoa, btnSua });

            // Sự kiện Load: chạy một lần khi form vừa hiện lên -> nạp dữ liệu cho ComboBox dân tộc
            Load += (s, e) =>
            {
                cboDanToc.Items.AddRange(new object[] { "Kinh", "Tày", "Thái", "Mường", "Hoa", "Khmer", "Nùng", "H'Mông" });
                cboDanToc.SelectedIndex = 0;   // Chọn sẵn "Kinh"
            };

            btnThem.Click += (s, e) => Them();
            btnXoa.Click += (s, e) => Xoa();
            btnSua.Click += (s, e) => Sua();
            lv.SelectedIndexChanged += (s, e) => HienThiLenControl();   // Click dòng nào thì đưa dữ liệu dòng đó lên các ô nhập

            // FormClosing: chạy trước khi form đóng. e.Cancel = true => hủy việc đóng.
            // CloseReason.UserClosing: chỉ hỏi khi người dùng chủ động đóng (bấm X), không hỏi khi hệ thống tắt máy.
            FormClosing += (s, e) =>
            {
                if (e.CloseReason == CloseReason.UserClosing &&
                    MessageBox.Show("Bạn có chắc chắn muốn đóng form?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
            };
        }

        // Hàm phụ: tạo một Label tại vị trí (x, y) và đưa lên form
        private void AddLabel(string text, int x, int y) =>
            Controls.Add(new Label { Text = text, AutoSize = true, Location = new Point(x, y + 3) });

        // Ghép các CheckBox đang được tích thành một chuỗi, ví dụ "Anh, Pháp"
        private string NgoaiNgu()
        {
            var ds = new List<string>();
            if (chkAnh.Checked) ds.Add("Anh");
            if (chkPhap.Checked) ds.Add("Pháp");
            if (chkHoa.Checked) ds.Add("Hoa");
            return string.Join(", ", ds);
        }

        // Kiểm tra họ tên và mã sinh viên không được rỗng
        private bool HopLe()
        {
            if (txtHoTen.Text.Trim() == "" || txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Họ tên và Mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // Tìm dòng có mã sinh viên = ma (SubItems[1]); trả về null nếu không có. Dùng để kiểm tra trùng mã.
        private ListViewItem Tim(string ma)
        {
            foreach (ListViewItem it in lv.Items)
                if (it.SubItems[1].Text.Equals(ma, StringComparison.OrdinalIgnoreCase)) return it;
            return null;
        }

        // Ghi dữ liệu từ các ô nhập vào một dòng ListView (dùng chung cho Thêm và Sửa)
        private void GanDuLieu(ListViewItem it)
        {
            it.SubItems[0].Text = txtHoTen.Text.Trim();
            it.SubItems[1].Text = txtMaSV.Text.Trim();
            it.SubItems[2].Text = rdoNam.Checked ? "Nam" : "Nữ";
            it.SubItems[3].Text = NgoaiNgu();
            it.SubItems[4].Text = cboDanToc.Text;
        }

        // THÊM: hợp lệ + không trùng mã => thêm một dòng mới
        private void Them()
        {
            if (!HopLe()) return;
            if (Tim(txtMaSV.Text.Trim()) != null)   // Đề yêu cầu: không cho trùng mã sinh viên
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var it = new ListViewItem(new string[5]);   // Tạo dòng có sẵn 5 cột rỗng để SubItems[i] không bị lỗi
            GanDuLieu(it);
            lv.Items.Add(it);
            LamMoi();
        }

        // XÓA: phải chọn một dòng; hỏi xác nhận rồi xóa
        private void Xoa()
        {
            if (lv.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn một dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                lv.Items.Remove(lv.SelectedItems[0]);
                LamMoi();
            }
        }

        // SỬA: cập nhật dòng đang chọn bằng dữ liệu trên các ô nhập; KHÔNG cho sửa Mã sinh viên
        private void Sua()
        {
            if (lv.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn một dòng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var it = lv.SelectedItems[0];
            txtMaSV.Text = it.SubItems[1].Text;   // Trả mã về giá trị cũ => mã không bao giờ bị đổi
            GanDuLieu(it);
        }

        // Khi chọn một dòng: đưa dữ liệu dòng đó lên các ô nhập để xem/sửa
        private void HienThiLenControl()
        {
            if (lv.SelectedItems.Count == 0) return;
            var it = lv.SelectedItems[0];
            txtHoTen.Text = it.SubItems[0].Text;
            txtMaSV.Text = it.SubItems[1].Text;
            txtMaSV.Enabled = false;                       // Khóa ô mã sinh viên khi đang sửa
            rdoNam.Checked = it.SubItems[2].Text == "Nam";
            rdoNu.Checked = !rdoNam.Checked;
            string nn = it.SubItems[3].Text;               // Ví dụ "Anh, Pháp" -> tích Anh và Pháp
            chkAnh.Checked = nn.Contains("Anh");
            chkPhap.Checked = nn.Contains("Pháp");
            chkHoa.Checked = nn.Contains("Hoa");
            cboDanToc.Text = it.SubItems[4].Text;
        }

        // Đưa các ô nhập về trạng thái ban đầu, sẵn sàng nhập sinh viên mới
        private void LamMoi()
        {
            txtHoTen.Clear(); txtMaSV.Clear(); txtMaSV.Enabled = true;   // Mở khóa lại ô mã
            rdoNam.Checked = true;
            chkAnh.Checked = true; chkPhap.Checked = false; chkHoa.Checked = false;
            cboDanToc.SelectedIndex = 0;
            lv.SelectedItems.Clear();
            txtHoTen.Focus();                                            // Đặt con trỏ vào ô họ tên
        }
    }
}
