using System;
using System.Drawing;
using System.Windows.Forms;

namespace Practice6
{
    /// <summary>
    /// Form thêm sản phẩm mới vào bảng SANPHAM.
    /// Đồng thời thêm 1 dòng vào TONKHO với SLDau = 0, SLNhap = 0, SLBan = 0.
    /// </summary>
    public class frmThemSanPham : Form
    {
        private TextBox txtTenSP;
        private Button btnThem, btnThoat;

        public frmThemSanPham()
        {
            Text = "Thêm sản phẩm mới";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            ClientSize = new Size(350, 110);
            BackColor = Color.FromArgb(240, 244, 250);

            Controls.Add(new Label { Text = "Tên sản phẩm", AutoSize = true, Location = new Point(15, 22) });
            txtTenSP = new TextBox { Location = new Point(110, 19), Size = new Size(220, 23) };
            Controls.Add(txtTenSP);

            btnThem = new Button { Text = "Thêm", Location = new Point(90, 60), Size = new Size(75, 30) };
            btnThoat = new Button { Text = "Thoát", Location = new Point(185, 60), Size = new Size(75, 30) };
            Controls.AddRange(new Control[] { btnThem, btnThoat });

            btnThem.Click += BtnThem_Click;
            btnThoat.Click += (s, e) => Close();
        }

        private void BtnThem_Click(object? sender, EventArgs e)
        {
            if (txtTenSP.Text.Trim() == "")
            {
                MessageBox.Show("Tên sản phẩm không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSP.Focus();
                return;
            }

            // Thêm sản phẩm (MaSP tự động tăng)
            int result = Db.ThucThi("insert into SANPHAM(TenSP) values(@ten)", "QLCuaHang", ("@ten", txtTenSP.Text.Trim()));
            if (result > 0)
            {
                // Lấy MaSP vừa thêm
                var maSP = Db.LayGiaTri("select IDENT_CURRENT('SANPHAM')", "QLCuaHang");
                if (maSP != null)
                {
                    string homNay = DateTime.Today.ToString("yyyy-MM-dd");
                    // Thêm dòng tồn kho với SLDau = 0
                    Db.ThucThi("insert into TONKHO(MaSP, NgayTon, SLDau, SLNhap, SLBan) values(@sp, @ngay, 0, 0, 0)",
                        "QLCuaHang", ("@sp", Convert.ToInt32(maSP)), ("@ngay", homNay));
                }
                txtTenSP.Clear();
            }
        }
    }
}
