using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Practice6
{
    /// <summary>
    /// Bài nâng cao (phần 2): Danh sách sinh viên – ListView hiển thị điểm,
    /// ComboBox lọc theo mã môn học, tính tổng điểm.
    /// - Khoảng trắng trong combobox = tất cả môn học
    /// - Chọn mã môn học cụ thể + nhấn Lọc = chỉ hiện sinh viên có mã mh đó
    /// </summary>
    public class frmDanhSachSinhVien : Form
    {
        private ComboBox cboMonHoc;
        private Button btnLocDuLieu;
        private ListView lvSinhVien;
        private TextBox txtTongDiem;

        public frmDanhSachSinhVien()
        {
            Text = "Danh sách sinh viên";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(700, 420);
            BackColor = Color.FromArgb(240, 244, 250);

            // Label + ComboBox Môn học
            Controls.Add(new Label { Text = "Môn học", AutoSize = true, Location = new Point(15, 17) });
            cboMonHoc = new ComboBox { Location = new Point(80, 14), Size = new Size(430, 23), DropDownStyle = ComboBoxStyle.DropDownList };
            Controls.Add(cboMonHoc);

            // Button Lọc dữ liệu
            btnLocDuLieu = new Button { Text = "Lọc dữ liệu", Location = new Point(530, 12), Size = new Size(100, 28) };
            Controls.Add(btnLocDuLieu);

            // ListView
            lvSinhVien = new ListView
            {
                Location = new Point(15, 50),
                Size = new Size(670, 320),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };
            lvSinhVien.Columns.Add("STT", 45);
            lvSinhVien.Columns.Add("Tên SV", 140);
            lvSinhVien.Columns.Add("Ngày sinh", 130);
            lvSinhVien.Columns.Add("Tên môn học", 180);
            lvSinhVien.Columns.Add("Điểm", 70);
            Controls.Add(lvSinhVien);

            // Tổng điểm
            Controls.Add(new Label { Text = "Tổng điểm", AutoSize = true, Location = new Point(490, 382) });
            txtTongDiem = new TextBox { Location = new Point(570, 379), Size = new Size(80, 23), ReadOnly = true };
            Controls.Add(txtTongDiem);

            btnLocDuLieu.Click += BtnLocDuLieu_Click;
            Load += (s, e) => NapMonHoc();
        }

        private void NapMonHoc()
        {
            cboMonHoc.Items.Clear();
            cboMonHoc.Items.Add(" ");  // Khoảng trắng = tất cả
            var dt = Db.LayDuLieu("select MaMonHoc from MonHoc");
            foreach (DataRow r in dt.Rows)
                cboMonHoc.Items.Add(r["MaMonHoc"].ToString()!.Trim());
            cboMonHoc.SelectedIndex = 0;
        }

        private void BtnLocDuLieu_Click(object? sender, EventArgs e)
        {
            lvSinhVien.Items.Clear();
            string maMonHoc = cboMonHoc.Text.Trim();

            DataTable dt;
            if (maMonHoc == "")
            {
                // Hiển thị tất cả
                dt = Db.LayDuLieu(
                    @"select sv.HoTen, sv.NgaySinh, mh.TenMonHoc, d.Diem
                      from Diem d
                      join SinhVien sv on d.MaSinhVien = sv.MaSinhVien
                      join MonHoc mh on d.MaMonHoc = mh.MaMonHoc
                      order by sv.HoTen");
            }
            else
            {
                // Lọc theo mã môn học
                dt = Db.LayDuLieu(
                    @"select sv.HoTen, sv.NgaySinh, mh.TenMonHoc, d.Diem
                      from Diem d
                      join SinhVien sv on d.MaSinhVien = sv.MaSinhVien
                      join MonHoc mh on d.MaMonHoc = mh.MaMonHoc
                      where d.MaMonHoc = @mh
                      order by sv.HoTen",
                    "QLSinhVien", ("@mh", maMonHoc));
            }

            double tongDiem = 0;
            int stt = 1;
            foreach (DataRow r in dt.Rows)
            {
                var item = new ListViewItem(stt.ToString());
                item.SubItems.Add(r["HoTen"].ToString()!.Trim());

                // Format ngày sinh
                if (r["NgaySinh"] != DBNull.Value)
                    item.SubItems.Add(Convert.ToDateTime(r["NgaySinh"]).ToString("M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture));
                else
                    item.SubItems.Add("");

                item.SubItems.Add(r["TenMonHoc"].ToString()!.Trim());

                double diem = r["Diem"] != DBNull.Value ? Convert.ToDouble(r["Diem"]) : 0;
                item.SubItems.Add(diem.ToString());
                tongDiem += diem;

                lvSinhVien.Items.Add(item);
                stt++;
            }

            txtTongDiem.Text = tongDiem.ToString();
        }
    }
}
