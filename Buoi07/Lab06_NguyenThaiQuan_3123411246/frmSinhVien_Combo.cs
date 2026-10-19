using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Practice6
{
    /// <summary>
    /// Bài tập tại lớp 2: frmSinhvien_Combo – ComboBox hiển thị mã lớp.
    /// Thêm sinh viên: mã sv không trùng, tuổi >= 17.
    /// Xóa / Sửa: kiểm tra khóa chính / khóa ngoại.
    /// </summary>
    public class frmSinhVien_Combo : Form
    {
        private ComboBox cboLop;
        private TextBox txtMaSV, txtHoTen, txtNgaySinh;
        private Button btnThem, btnXoa, btnSua;

        public frmSinhVien_Combo()
        {
            Text = "frmSinhvien_Combo";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            ClientSize = new Size(420, 220);
            BackColor = Color.FromArgb(240, 244, 250);

            // Labels
            Controls.Add(new Label { Text = "Lớp", AutoSize = true, Location = new Point(15, 22) });
            Controls.Add(new Label { Text = "Mã sv", AutoSize = true, Location = new Point(15, 55) });
            Controls.Add(new Label { Text = "Họ tên", AutoSize = true, Location = new Point(15, 88) });
            Controls.Add(new Label { Text = "Ngày sinh", AutoSize = true, Location = new Point(15, 121) });

            // ComboBox Lớp
            cboLop = new ComboBox { Location = new Point(90, 19), Size = new Size(300, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            Controls.Add(cboLop);

            // TextBoxes
            txtMaSV = new TextBox { Location = new Point(90, 52), Size = new Size(300, 23) };
            txtHoTen = new TextBox { Location = new Point(90, 85), Size = new Size(300, 23) };
            txtNgaySinh = new TextBox { Location = new Point(90, 118), Size = new Size(300, 23), PlaceholderText = "__/__/____" };
            Controls.AddRange(new Control[] { txtMaSV, txtHoTen, txtNgaySinh });

            // Buttons
            btnThem = new Button { Text = "Thêm", Location = new Point(60, 160), Size = new Size(85, 32) };
            btnXoa = new Button { Text = "Xóa", Location = new Point(165, 160), Size = new Size(85, 32) };
            btnSua = new Button { Text = "Sửa", Location = new Point(270, 160), Size = new Size(85, 32) };
            Controls.AddRange(new Control[] { btnThem, btnXoa, btnSua });

            btnThem.Click += BtnThem_Click;
            btnXoa.Click += BtnXoa_Click;
            btnSua.Click += BtnSua_Click;

            Load += (s, e) => NapLop();
        }

        private void NapLop()
        {
            var dt = Db.LayDuLieu("select MaLop from Lop");
            cboLop.Items.Clear();
            foreach (DataRow r in dt.Rows)
                cboLop.Items.Add(r["MaLop"].ToString()!.Trim());
            if (cboLop.Items.Count > 0) cboLop.SelectedIndex = 0;
        }

        private bool LayNgay(out DateTime ngay)
        {
            ngay = default;
            if (DateTime.TryParseExact(txtNgaySinh.Text.Trim(), new[] { "d/M/yyyy", "dd/MM/yyyy" },
                CultureInfo.InvariantCulture, DateTimeStyles.None, out ngay)) return true;
            MessageBox.Show("Ngày sinh không hợp lệ (dd/MM/yyyy)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNgaySinh.Focus();
            return false;
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            // Kiểm tra tất cả phải nhập
            if (cboLop.SelectedIndex < 0 || txtMaSV.Text.Trim() == "" || txtHoTen.Text.Trim() == "" || txtNgaySinh.Text.Trim() == "")
            {
                MessageBox.Show("Tất cả thông tin phải được nhập dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!LayNgay(out var ngay)) return;

            // Kiểm tra tuổi >= 17 (chỉ tính theo năm sinh)
            int tuoi = DateTime.Now.Year - ngay.Year;
            if (tuoi < 17)
            {
                MessageBox.Show("Sinh viên phải có tuổi từ 17 trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã sv không trùng
            var check = Db.LayGiaTri("select count(*) from SinhVien where MaSinhVien = @sv", "QLSinhVien", ("@sv", txtMaSV.Text.Trim()));
            if (check != null && Convert.ToInt32(check) > 0)
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Db.ThucThiQL("insert into SinhVien(MaSinhVien, HoTen, NgaySinh, MaLop) values(@sv, @ten, @ns, @lop)",
                ("@sv", txtMaSV.Text.Trim()), ("@ten", txtHoTen.Text.Trim()), ("@ns", ngay), ("@lop", cboLop.Text));
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Db.ThucThiQL("delete from SinhVien where MaSinhVien = @sv", ("@sv", txtMaSV.Text.Trim()));
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var set = new System.Collections.Generic.List<string>();
            var ps = new System.Collections.Generic.List<(string, object)> { ("@sv", txtMaSV.Text.Trim()) };

            if (cboLop.SelectedIndex >= 0) { set.Add("MaLop = @lop"); ps.Add(("@lop", cboLop.Text)); }
            if (txtHoTen.Text.Trim() != "") { set.Add("HoTen = @ten"); ps.Add(("@ten", txtHoTen.Text.Trim())); }
            if (txtNgaySinh.Text.Trim() != "")
            {
                if (!LayNgay(out var ngay)) return;
                set.Add("NgaySinh = @ns"); ps.Add(("@ns", ngay));
            }

            if (set.Count == 0)
            {
                MessageBox.Show("Phải nhập ít nhất một trường cần thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Db.ThucThiQL($"update SinhVien set {string.Join(", ", set)} where MaSinhVien = @sv", ps.ToArray());
        }
    }
}
