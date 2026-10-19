using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Practice6
{
    /// <summary>
    /// Bài tập tại lớp 2 (phần 2): frmDiem_Combo – ComboBox Sinh viên + Môn học.
    /// Điểm phải nằm trong khoảng 0-10.
    /// Thêm: chỉ khi mã sv và mã mh tồn tại, không trùng khóa chính.
    /// Xóa / Sửa: kiểm tra khóa chính / khóa ngoại.
    /// </summary>
    public class frmDiem_Combo : Form
    {
        private ComboBox cboSinhVien, cboMonHoc;
        private TextBox txtDiem;
        private Button btnThem, btnXoa, btnSua;

        public frmDiem_Combo()
        {
            Text = "frmDiem_combo";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            ClientSize = new Size(380, 180);
            BackColor = Color.FromArgb(240, 244, 250);

            // Labels
            Controls.Add(new Label { Text = "Sinh viên", AutoSize = true, Location = new Point(15, 22) });
            Controls.Add(new Label { Text = "Môn học", AutoSize = true, Location = new Point(15, 55) });
            Controls.Add(new Label { Text = "Điểm", AutoSize = true, Location = new Point(15, 88) });

            // ComboBoxes
            cboSinhVien = new ComboBox { Location = new Point(90, 19), Size = new Size(260, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            cboMonHoc = new ComboBox { Location = new Point(90, 52), Size = new Size(260, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            Controls.AddRange(new Control[] { cboSinhVien, cboMonHoc });

            // TextBox Điểm
            txtDiem = new TextBox { Location = new Point(90, 85), Size = new Size(260, 23) };
            txtDiem.KeyPress += (s, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.') e.Handled = true;
            };
            Controls.Add(txtDiem);

            // Buttons
            btnThem = new Button { Text = "Thêm", Location = new Point(40, 125), Size = new Size(85, 32) };
            btnXoa = new Button { Text = "Xóa", Location = new Point(145, 125), Size = new Size(85, 32) };
            btnSua = new Button { Text = "Sửa", Location = new Point(250, 125), Size = new Size(85, 32) };
            Controls.AddRange(new Control[] { btnThem, btnXoa, btnSua });

            btnThem.Click += BtnThem_Click;
            btnXoa.Click += BtnXoa_Click;
            btnSua.Click += BtnSua_Click;

            Load += (s, e) => NapDuLieu();
        }

        private void NapDuLieu()
        {
            // Nạp mã sinh viên
            var dtSV = Db.LayDuLieu("select MaSinhVien from SinhVien");
            cboSinhVien.Items.Clear();
            foreach (DataRow r in dtSV.Rows)
                cboSinhVien.Items.Add(r["MaSinhVien"].ToString()!.Trim());
            if (cboSinhVien.Items.Count > 0) cboSinhVien.SelectedIndex = 0;

            // Nạp mã môn học
            var dtMH = Db.LayDuLieu("select MaMonHoc from MonHoc");
            cboMonHoc.Items.Clear();
            foreach (DataRow r in dtMH.Rows)
                cboMonHoc.Items.Add(r["MaMonHoc"].ToString()!.Trim());
            if (cboMonHoc.Items.Count > 0) cboMonHoc.SelectedIndex = 0;
        }

        private bool LayDiem(out double diem)
        {
            if (double.TryParse(txtDiem.Text.Trim(), System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture, out diem) && diem >= 0 && diem <= 10) return true;
            MessageBox.Show("Điểm phải là số từ 0 đến 10!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDiem.Focus();
            return false;
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            if (cboSinhVien.SelectedIndex < 0 || cboMonHoc.SelectedIndex < 0 || txtDiem.Text.Trim() == "")
            {
                MessageBox.Show("Tất cả thông tin phải được nhập dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!LayDiem(out var d)) return;

            // Kiểm tra không trùng khóa chính
            var check = Db.LayGiaTri("select count(*) from Diem where MaSinhVien = @sv and MaMonHoc = @mh", "QLSinhVien",
                ("@sv", cboSinhVien.Text), ("@mh", cboMonHoc.Text));
            if (check != null && Convert.ToInt32(check) > 0)
            {
                MessageBox.Show("Điểm của sinh viên này cho môn học này đã tồn tại (trùng khóa chính)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Db.ThucThiQL("insert into Diem(MaSinhVien, MaMonHoc, Diem) values(@sv, @mh, @d)",
                ("@sv", cboSinhVien.Text), ("@mh", cboMonHoc.Text), ("@d", d));
        }

        private void BtnXoa_Click(object? sender, EventArgs e)
        {
            if (cboSinhVien.SelectedIndex < 0 || cboMonHoc.SelectedIndex < 0)
            {
                MessageBox.Show("Phải chọn sinh viên và môn học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Db.ThucThiQL("delete from Diem where MaSinhVien = @sv and MaMonHoc = @mh",
                ("@sv", cboSinhVien.Text), ("@mh", cboMonHoc.Text));
        }

        private void BtnSua_Click(object? sender, EventArgs e)
        {
            if (cboSinhVien.SelectedIndex < 0 || cboMonHoc.SelectedIndex < 0 || txtDiem.Text.Trim() == "")
            {
                MessageBox.Show("Phải chọn sinh viên, môn học và nhập điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!LayDiem(out var d)) return;

            Db.ThucThiQL("update Diem set Diem = @d where MaSinhVien = @sv and MaMonHoc = @mh",
                ("@sv", cboSinhVien.Text), ("@mh", cboMonHoc.Text), ("@d", d));
        }
    }
}
