using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Practice6
{
    /// <summary>
    /// Bài tập về nhà - Form Bán hàng:
    /// - Tạo hóa đơn mới (MaHD tự tăng, ngày tạo = hôm nay, tình trạng = 0)
    /// - Thêm chi tiết hóa đơn: ComboBox sản phẩm, số lượng, kiểm tra tồn kho
    /// - Cập nhật SLBan trong bảng TONKHO
    /// - Nút Hủy, Thanh toán
    /// </summary>
    public class frmBanHang : Form
    {
        private TextBox txtMaHD, txtSoLuong;
        private ComboBox cboSanPham;
        private Button btnTaoHD, btnThem, btnHuy, btnThanhToan;
        private GroupBox grpChiTiet;

        public frmBanHang()
        {
            Text = "BanHang";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            ClientSize = new Size(420, 280);
            BackColor = Color.FromArgb(240, 244, 250);

            // Nút tạo hóa đơn mới
            btnTaoHD = new Button { Text = "Tạo hóa đơn mới", Location = new Point(230, 12), Size = new Size(150, 30) };
            Controls.Add(btnTaoHD);

            // Group chi tiết hóa đơn
            grpChiTiet = new GroupBox { Text = "Chi tiết hóa đơn", Location = new Point(15, 50), Size = new Size(390, 170) };
            Controls.Add(grpChiTiet);

            // Mã hóa đơn
            grpChiTiet.Controls.Add(new Label { Text = "Mã hóa đơn", AutoSize = true, Location = new Point(15, 25) });
            txtMaHD = new TextBox { Location = new Point(115, 22), Size = new Size(250, 23), ReadOnly = true };
            grpChiTiet.Controls.Add(txtMaHD);

            // Mã sản phẩm (ComboBox)
            grpChiTiet.Controls.Add(new Label { Text = "Mã sản phẩm", AutoSize = true, Location = new Point(15, 58) });
            cboSanPham = new ComboBox { Location = new Point(115, 55), Size = new Size(250, 23), DropDownStyle = ComboBoxStyle.DropDownList, Enabled = false };
            grpChiTiet.Controls.Add(cboSanPham);

            // Số lượng
            grpChiTiet.Controls.Add(new Label { Text = "Số lượng", AutoSize = true, Location = new Point(15, 91) });
            txtSoLuong = new TextBox { Location = new Point(115, 88), Size = new Size(250, 23), Enabled = false };
            txtSoLuong.KeyPress += (s, e) => { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; };
            grpChiTiet.Controls.Add(txtSoLuong);

            // Buttons trong group
            btnThem = new Button { Text = "Thêm", Location = new Point(55, 125), Size = new Size(75, 30), Enabled = false };
            btnHuy = new Button { Text = "Hủy", Location = new Point(155, 125), Size = new Size(75, 30), Enabled = false };
            btnThanhToan = new Button { Text = "Thanh toán", Location = new Point(255, 125), Size = new Size(90, 30), Enabled = false };
            grpChiTiet.Controls.AddRange(new Control[] { btnThem, btnHuy, btnThanhToan });

            // Nút thanh toán ở dưới cùng
            var btnThanhToanMain = new Button { Text = "Thanh toán", Location = new Point(300, 235), Size = new Size(100, 30), Visible = false };

            // Sự kiện
            btnTaoHD.Click += BtnTaoHD_Click;
            btnThem.Click += BtnThem_Click;
            btnHuy.Click += BtnHuy_Click;
            btnThanhToan.Click += BtnThanhToan_Click;
        }

        private void NapSanPham()
        {
            cboSanPham.Items.Clear();
            var dt = Db.LayDuLieu("select MaSP from SANPHAM", "QLCuaHang");
            foreach (DataRow r in dt.Rows)
                cboSanPham.Items.Add(r["MaSP"].ToString()!.Trim());
            if (cboSanPham.Items.Count > 0) cboSanPham.SelectedIndex = 0;
        }

        private void BtnTaoHD_Click(object? sender, EventArgs e)
        {
            // Tạo hóa đơn mới: ngày tạo = hôm nay, tình trạng = 0
            string homNay = DateTime.Today.ToString("yyyy-MM-dd");
            int result = Db.ThucThi(
                "insert into HOADON(NgayTao, TinhTrangThanhToan) values(@ngay, 0)",
                "QLCuaHang", ("@ngay", homNay));

            if (result > 0)
            {
                // Lấy mã hóa đơn vừa tạo
                var maHD = Db.LayGiaTri("select IDENT_CURRENT('HOADON')", "QLCuaHang");
                if (maHD != null)
                {
                    txtMaHD.Text = maHD.ToString();

                    // Mở các control chi tiết
                    NapSanPham();
                    cboSanPham.Enabled = true;
                    txtSoLuong.Enabled = true;
                    btnThem.Enabled = true;
                    btnHuy.Enabled = true;
                    btnThanhToan.Enabled = true;
                    btnTaoHD.Enabled = false;  // Không cho tạo thêm khi đang có hóa đơn
                }
            }
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            if (txtMaHD.Text.Trim() == "" || cboSanPham.SelectedIndex < 0 || txtSoLuong.Text.Trim() == "")
            {
                MessageBox.Show("Phải nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHD = int.Parse(txtMaHD.Text.Trim());
            int maSP = int.Parse(cboSanPham.Text);
            int soLuong = int.Parse(txtSoLuong.Text.Trim());

            if (soLuong <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra khóa chính (MaHD, MaSP) không trùng
            var check = Db.LayGiaTri(
                "select count(*) from CHITIET_HOADON where MaHD = @hd and MaSP = @sp",
                "QLCuaHang", ("@hd", maHD), ("@sp", maSP));
            if (check != null && Convert.ToInt32(check) > 0)
            {
                MessageBox.Show("Sản phẩm này đã có trong hóa đơn (trùng khóa chính)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số lượng tồn kho
            string homNay = DateTime.Today.ToString("yyyy-MM-dd");
            var tonObj = Db.LayGiaTri(
                "select (SLDau + SLNhap - SLBan) from TONKHO where MaSP = @sp and NgayTon = @ngay",
                "QLCuaHang", ("@sp", maSP), ("@ngay", homNay));

            if (tonObj == null || tonObj == DBNull.Value)
            {
                MessageBox.Show("Chưa tạo tồn kho cho sản phẩm này ngày hôm nay! Hãy chạy 'Tạo tồn kho' trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int slTon = Convert.ToInt32(tonObj);
            if (soLuong > slTon)
            {
                MessageBox.Show($"Số lượng bán ({soLuong}) phải nhỏ hơn số lượng tồn ({slTon})!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm chi tiết hóa đơn
            int result = Db.ThucThi(
                "insert into CHITIET_HOADON(MaHD, MaSP, SoLuong) values(@hd, @sp, @sl)",
                "QLCuaHang", ("@hd", maHD), ("@sp", maSP), ("@sl", soLuong));

            if (result > 0)
            {
                // Cập nhật SLBan trong TONKHO
                Db.ThucThi(
                    "update TONKHO set SLBan = SLBan + @sl where MaSP = @sp and NgayTon = @ngay",
                    "QLCuaHang", ("@sp", maSP), ("@ngay", homNay), ("@sl", soLuong));
                txtSoLuong.Clear();
            }
        }

        private void BtnHuy_Click(object? sender, EventArgs e)
        {
            if (txtMaHD.Text.Trim() == "") return;

            int maHD = int.Parse(txtMaHD.Text.Trim());

            // Hoàn trả tồn kho cho các chi tiết đã thêm
            string homNay = DateTime.Today.ToString("yyyy-MM-dd");
            var dtCT = Db.LayDuLieu(
                "select MaSP, SoLuong from CHITIET_HOADON where MaHD = @hd",
                "QLCuaHang", ("@hd", maHD));

            foreach (DataRow r in dtCT.Rows)
            {
                int maSP = Convert.ToInt32(r["MaSP"]);
                int sl = Convert.ToInt32(r["SoLuong"]);
                Db.ThucThi(
                    "update TONKHO set SLBan = SLBan - @sl where MaSP = @sp and NgayTon = @ngay",
                    "QLCuaHang", ("@sp", maSP), ("@ngay", homNay), ("@sl", sl));
            }

            // Xóa chi tiết và hóa đơn
            Db.ThucThi("delete from CHITIET_HOADON where MaHD = @hd", "QLCuaHang", ("@hd", maHD));
            Db.ThucThi("delete from HOADON where MaHD = @hd", "QLCuaHang", ("@hd", maHD));

            ResetForm();
            MessageBox.Show("Đã hủy hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnThanhToan_Click(object? sender, EventArgs e)
        {
            if (txtMaHD.Text.Trim() == "") return;

            int maHD = int.Parse(txtMaHD.Text.Trim());
            Db.ThucThi(
                "update HOADON set TinhTrangThanhToan = 1 where MaHD = @hd",
                "QLCuaHang", ("@hd", maHD));

            ResetForm();
        }

        private void ResetForm()
        {
            txtMaHD.Clear();
            txtSoLuong.Clear();
            cboSanPham.Items.Clear();
            cboSanPham.Enabled = false;
            txtSoLuong.Enabled = false;
            btnThem.Enabled = false;
            btnHuy.Enabled = false;
            btnThanhToan.Enabled = false;
            btnTaoHD.Enabled = true;
        }
    }
}
