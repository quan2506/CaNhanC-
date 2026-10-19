using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Practice6
{
    /// <summary>
    /// Bài tập về nhà - QLCuaHang: Form chính chứa menu.
    /// Menu: Tạo tồn kho | Thêm sản phẩm mới | Bán hàng
    /// </summary>
    public class frmCuaHangMain : Form
    {
        public frmCuaHangMain()
        {
            Text = "Quản lý cửa hàng";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(600, 400);
            IsMdiContainer = true;
            BackColor = Color.FromArgb(240, 244, 250);

            var menu = new MenuStrip();

            var mnuTonKho = new ToolStripMenuItem("Tạo tồn kho");
            mnuTonKho.Click += (s, e) => TaoTonKho();

            var mnuThemSP = new ToolStripMenuItem("Thêm sản phẩm mới");
            mnuThemSP.Click += (s, e) => Mo(new frmThemSanPham());

            var mnuBanHang = new ToolStripMenuItem("Bán hàng");
            mnuBanHang.Click += (s, e) => Mo(new frmBanHang());

            menu.Items.AddRange(new ToolStripItem[] { mnuTonKho, mnuThemSP, mnuBanHang });
            MainMenuStrip = menu;
            Controls.Add(menu);
        }

        private void Mo(Form f)
        {
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterParent;
            f.Show();
        }

        /// <summary>
        /// Tạo tồn kho cho ngày hôm nay cho tất cả sản phẩm.
        /// SLTon = SLTon(ngày trước) + SLNhap(ngày trước) - SLXuat(ngày trước)
        /// Tổng SL nhập = 0, Tổng SL xuất = 0
        /// </summary>
        private void TaoTonKho()
        {
            string homNay = DateTime.Today.ToString("yyyy-MM-dd");

            // Kiểm tra đã tạo tồn kho hôm nay chưa
            var check = Db.LayGiaTri($"select count(*) from TONKHO where NgayTon = @ngay", "QLCuaHang", ("@ngay", homNay));
            if (check != null && Convert.ToInt32(check) > 0)
            {
                MessageBox.Show("Tồn kho hôm nay đã được tạo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy tất cả sản phẩm
            var dtSP = Db.LayDuLieu("select MaSP from SANPHAM", "QLCuaHang");

            foreach (DataRow r in dtSP.Rows)
            {
                int maSP = Convert.ToInt32(r["MaSP"]);

                // Tìm dòng tồn kho gần nhất (ngày trước)
                var dtTon = Db.LayDuLieu(
                    "select top 1 SLDau, SLNhap, SLBan from TONKHO where MaSP = @sp and NgayTon < @ngay order by NgayTon desc",
                    "QLCuaHang", ("@sp", maSP), ("@ngay", homNay));

                int slTon = 0;
                if (dtTon.Rows.Count > 0)
                {
                    var row = dtTon.Rows[0];
                    slTon = Convert.ToInt32(row["SLDau"]) + Convert.ToInt32(row["SLNhap"]) - Convert.ToInt32(row["SLBan"]);
                }

                // Tạo dòng tồn kho mới: SLDau = slTon, SLNhap = 0, SLBan = 0
                Db.ThucThi(
                    "insert into TONKHO(MaSP, NgayTon, SLDau, SLNhap, SLBan) values(@sp, @ngay, @dau, 0, 0)",
                    "QLCuaHang", ("@sp", maSP), ("@ngay", homNay), ("@dau", slTon));
            }

            MessageBox.Show("Đã tạo tồn kho cho ngày hôm nay!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
