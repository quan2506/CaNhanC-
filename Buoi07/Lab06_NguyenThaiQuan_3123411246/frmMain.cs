using System;
using System.Windows.Forms;

namespace Practice6
{
    /// <summary>
    /// Form chính (MDI) có MenuStrip gắn tất cả bài tập Practice 6.
    /// </summary>
    public class frmMain : Form
    {
        public frmMain()
        {
            Text = "Practice 6 - ADO.NET + ComboBox + ListView";
            WindowState = FormWindowState.Maximized;
            IsMdiContainer = true;

            var menu = new MenuStrip();

            // ===== Phần 1: Bài tập tại lớp (CRUD cơ bản) =====
            var baiLop = new ToolStripMenuItem("Bài tập tại lớp");
            baiLop.DropDownItems.Add("Quản lý Môn học", null, (s, e) => Mo(new QLMonHoc()));

            // ===== Phần 2: Bài tập nâng cao (CRUD nâng cao) =====
            var nangCao = new ToolStripMenuItem("Nâng cao");
            nangCao.DropDownItems.Add("Quản lý Sinh viên", null, (s, e) => Mo(new QLSinhVien()));
            nangCao.DropDownItems.Add("Quản lý Điểm", null, (s, e) => Mo(new QLDiem()));

            // ===== Phần 3: Bài tập về nhà (CRUD Lớp) =====
            var veNha1 = new ToolStripMenuItem("Về nhà (QLSinhVien)");
            veNha1.DropDownItems.Add("Quản lý Lớp", null, (s, e) => Mo(new QLLop()));

            // ===== Phần 4: ComboBox =====
            var combo = new ToolStripMenuItem("ComboBox");
            combo.DropDownItems.Add("SV - Combo (chọn Lớp)", null, (s, e) => Mo(new frmSinhVien_Combo()));
            combo.DropDownItems.Add("Điểm - Combo (chọn SV + MH)", null, (s, e) => Mo(new frmDiem_Combo()));

            // ===== Phần 5: ListView =====
            var listview = new ToolStripMenuItem("ListView");
            listview.DropDownItems.Add("Danh sách Lớp", null, (s, e) => Mo(new frmDanhSachLop()));
            listview.DropDownItems.Add("Danh sách Sinh viên (lọc MH)", null, (s, e) => Mo(new frmDanhSachSinhVien()));

            // ===== Phần 6: Quản lý Cửa hàng =====
            var cuaHang = new ToolStripMenuItem("Về nhà (QLCuaHang)");
            cuaHang.DropDownItems.Add("Quản lý Cửa hàng (BanHang)", null, (s, e) => Mo(new frmCuaHangMain()));

            menu.Items.AddRange(new ToolStripItem[] { baiLop, nangCao, veNha1, combo, listview, cuaHang });
            MainMenuStrip = menu;
            Controls.Add(menu);
        }

        private void Mo(Form f)
        {
            f.MdiParent = this;
            f.StartPosition = FormStartPosition.CenterParent;
            f.Show();
        }
    }
}
