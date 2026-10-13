using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>
    /// Bài tập tại lớp 2: Quản lý thông tin tài khoản ngân hàng.
    /// Điểm chính: nút Thêm đổi thành Hủy, bật/tắt nút Lưu - Xóa theo trạng thái,
    /// tự đánh STT và tính Tổng tiền sau mỗi lần Lưu/Xóa.
    /// </summary>
    public class frmBaiTap2 : Form
    {
        private TextBox txtSoTK, txtTen, txtDiaChi, txtSoTien, txtTong;
        private Button btnThem, btnLuu, btnXoa, btnThoat;
        private ListView lv;

        public frmBaiTap2()
        {
            Text = "frmBaiTap2";
            ClientSize = new Size(560, 450);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;

            // Tiêu đề lớn màu xanh
            Controls.Add(new Label
            {
                Text = "QUẢN LÝ THÔNG TIN TÀI KHOẢN", ForeColor = Color.Blue,
                Font = new Font("Arial", 16, FontStyle.Bold), AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter, Location = new Point(0, 10), Size = new Size(560, 40)
            });

            // Bốn ô nhập (hàm Dong tạo nhãn + ô nhập trên cùng một dòng)
            txtSoTK = Dong("Số tài khoản", 65);
            txtTen = Dong("Tên khách hàng", 95);
            txtDiaChi = Dong("Địa chỉ khách hàng", 125);
            txtSoTien = Dong("Số tiền trong tài khoản", 155);
            txtSoTien.TextAlign = HorizontalAlignment.Right;   // Số tiền căn lề phải
            // Chặn ký tự không phải chữ số (e.Handled = true => bỏ phím vừa gõ)
            txtSoTien.KeyPress += (s, e) => { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; };

            btnThem = new Button { Text = "Thêm", Location = new Point(290, 190), Size = new Size(65, 25) };
            btnLuu = new Button { Text = "Lưu", Location = new Point(360, 190), Size = new Size(65, 25) };
            btnXoa = new Button { Text = "Xóa", Location = new Point(430, 190), Size = new Size(65, 25) };
            btnThoat = new Button { Text = "Thoát", Location = new Point(500, 190), Size = new Size(55, 25) };

            lv = new ListView { Location = new Point(10, 225), Size = new Size(540, 170), View = View.Details, FullRowSelect = true, MultiSelect = false, GridLines = true };
            lv.Columns.Add("STT", 40);
            lv.Columns.Add("Số tài khoản", 110);
            lv.Columns.Add("Tên khách hàng", 150);
            lv.Columns.Add("Địa chỉ", 110);
            lv.Columns.Add("Số tiền", 110, HorizontalAlignment.Right);

            Controls.Add(new Label { Text = "Tổng tiền", AutoSize = true, Location = new Point(360, 410) });
            txtTong = new TextBox { Location = new Point(430, 406), Size = new Size(120, 23), ReadOnly = true, TextAlign = HorizontalAlignment.Right };
            Controls.AddRange(new Control[] { btnThem, btnLuu, btnXoa, btnThoat, lv, txtTong });

            TrangThaiBanDau();   // Form load lên: Lưu và Xóa bị vô hiệu hóa

            btnThem.Click += (s, e) => NhanThem();
            btnLuu.Click += (s, e) => Luu();
            btnXoa.Click += (s, e) => Xoa();
            btnThoat.Click += (s, e) => Close();
            lv.SelectedIndexChanged += (s, e) => HienThi();   // Click một khách hàng => hiện thông tin lên các ô
        }

        // Tạo một dòng gồm nhãn (căn phải) + ô nhập tại tọa độ y, trả về ô nhập vừa tạo
        private TextBox Dong(string nhan, int y)
        {
            Controls.Add(new Label { Text = nhan, AutoSize = false, TextAlign = ContentAlignment.MiddleRight, Location = new Point(10, y), Size = new Size(190, 23) });
            var t = new TextBox { Location = new Point(210, y), Size = new Size(335, 23) };
            Controls.Add(t);
            return t;
        }

        // Trạng thái ban đầu: nút Thêm hiện chữ "Thêm"; Lưu và Xóa bị mờ (Enabled = false)
        private void TrangThaiBanDau()
        {
            btnThem.Text = "Thêm";
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void XoaTextbox() { txtSoTK.Clear(); txtTen.Clear(); txtDiaChi.Clear(); txtSoTien.Clear(); }

        // Nút Thêm có 2 vai trò dựa vào chữ trên nút:
        //   "Thêm": chuyển sang chế độ nhập (đổi thành "Hủy", bật Lưu, xóa trống ô, con trỏ vào Số tài khoản)
        //   "Hủy" : thoát chế độ nhập, trở về trạng thái ban đầu
        private void NhanThem()
        {
            if (btnThem.Text == "Thêm")
            {
                btnThem.Text = "Hủy";
                btnLuu.Enabled = true;
                btnXoa.Enabled = false;
                lv.SelectedItems.Clear();
                XoaTextbox();
                txtSoTK.Focus();   // Đặt con trỏ vào textbox Số tài khoản
            }
            else
            {
                TrangThaiBanDau();
                XoaTextbox();
            }
        }

        // LƯU: kiểm tra dữ liệu, chặn trùng số tài khoản rồi thêm vào ListView
        private void Luu()
        {
            // long.TryParse: kiểm tra Số tiền là số nguyên hợp lệ mà không gây lỗi chương trình
            if (txtSoTK.Text.Trim() == "" || txtTen.Text.Trim() == "" || !long.TryParse(txtSoTien.Text, out long tien))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (ListViewItem x in lv.Items)
                if (x.SubItems[1].Text == txtSoTK.Text.Trim())
                {
                    MessageBox.Show("Số tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            // Cột STT để trống, hàm CapNhat() sẽ điền sau. Cột tiền hiển thị dạng 5,200,000
            var it = new ListViewItem(new[] { "", txtSoTK.Text.Trim(), txtTen.Text.Trim(), txtDiaChi.Text.Trim(), tien.ToString("N0", CultureInfo.InvariantCulture) });
            it.Tag = tien;   // Cất số tiền gốc (kiểu long) vào Tag để cộng tổng chính xác, không phải đọc lại từ chuỗi có dấu phẩy
            lv.Items.Add(it);
            CapNhat();
            XoaTextbox();
            TrangThaiBanDau();
        }

        // XÓA: xóa dòng đang chọn rồi tính lại STT và Tổng tiền
        private void Xoa()
        {
            if (lv.SelectedItems.Count == 0) return;
            lv.Items.Remove(lv.SelectedItems[0]);
            CapNhat();
            XoaTextbox();
            TrangThaiBanDau();
        }

        // Click một dòng: hiện thông tin lên các ô, bật nút Xóa, tắt nút Lưu
        private void HienThi()
        {
            if (lv.SelectedItems.Count == 0) { btnXoa.Enabled = false; return; }
            var it = lv.SelectedItems[0];
            txtSoTK.Text = it.SubItems[1].Text;
            txtTen.Text = it.SubItems[2].Text;
            txtDiaChi.Text = it.SubItems[3].Text;
            txtSoTien.Text = ((long)it.Tag).ToString();   // Lấy lại số tiền gốc từ Tag
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnThem.Text = "Thêm";
        }

        // Đánh lại STT (1, 2, 3...) và tính Tổng tiền. Gọi sau mỗi lần Lưu / Xóa
        private void CapNhat()
        {
            long tong = 0;
            for (int i = 0; i < lv.Items.Count; i++)
            {
                lv.Items[i].SubItems[0].Text = (i + 1).ToString();   // STT = vị trí + 1
                tong += (long)lv.Items[i].Tag;                       // Cộng dồn số tiền
            }
            txtTong.Text = tong.ToString("N0", CultureInfo.InvariantCulture);   // "N0" = có dấu phân cách hàng nghìn, không số lẻ
        }
    }
}
