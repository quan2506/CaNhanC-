using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Practice6
{
    /// <summary>
    /// Bài nâng cao: Danh sách Lớp – hiển thị bảng Lop trên ListView.
    /// Nút "Hiển thị dữ liệu" nạp dữ liệu, nút "Thoát" đóng form.
    /// </summary>
    public class frmDanhSachLop : Form
    {
        private ListView lvLop;
        private Button btnHienThi, btnThoat;

        public frmDanhSachLop()
        {
            Text = "Danh sách Lớp";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(580, 350);
            BackColor = Color.FromArgb(240, 244, 250);

            // Button Hiển thị dữ liệu
            btnHienThi = new Button { Text = "Hiển thị dữ liệu", Location = new Point(15, 12), Size = new Size(130, 30) };
            Controls.Add(btnHienThi);

            // ListView
            lvLop = new ListView
            {
                Location = new Point(15, 50),
                Size = new Size(550, 240),
                View = View.Details,
                FullRowSelect = true,
                GridLines = true
            };
            lvLop.Columns.Add("STT", 50);
            lvLop.Columns.Add("Mã lớp", 120);
            lvLop.Columns.Add("Tên lớp", 250);
            lvLop.Columns.Add("Mã khoa", 100);
            Controls.Add(lvLop);

            // Button Thoát
            btnThoat = new Button { Text = "Thoát", Location = new Point(470, 300), Size = new Size(85, 32) };
            Controls.Add(btnThoat);

            btnHienThi.Click += BtnHienThi_Click;
            btnThoat.Click += (s, e) => Close();
        }

        private void BtnHienThi_Click(object? sender, EventArgs e)
        {
            lvLop.Items.Clear();
            var dt = Db.LayDuLieu("select MaLop, TenLop, MaKhoa from Lop");
            int stt = 1;
            foreach (DataRow r in dt.Rows)
            {
                var item = new ListViewItem(stt.ToString());
                item.SubItems.Add(r["MaLop"].ToString()!.Trim());
                item.SubItems.Add(r["TenLop"].ToString()!.Trim());
                item.SubItems.Add(r["MaKhoa"].ToString()!.Trim());
                lvLop.Items.Add(item);
                stt++;
            }
        }
    }
}
