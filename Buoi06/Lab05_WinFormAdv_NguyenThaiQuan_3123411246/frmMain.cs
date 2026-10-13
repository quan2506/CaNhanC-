using System;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>
    /// Bài tập về nhà 2: Form chính (MDI) có MenuStrip, gắn tất cả bài tập;
    /// chọn menu nào thì hiển thị form tương ứng bên trong form chính.
    /// </summary>
    public class frmMain : Form
    {
        public frmMain()
        {
            Text = "BTVN - Practice 5";
            WindowState = FormWindowState.Maximized;   // Mở toàn màn hình
            IsMdiContainer = true;                     // Cho phép chứa các form con bên trong (MDI)

            var menu = new MenuStrip();   // Thanh menu ở đầu form

            // Mỗi ToolStripMenuItem là một menu cha; DropDownItems.Add(chữ, icon, hàm xử lý khi click) thêm mục con.
            // (s, e) => Mo(new frmXxx()) nghĩa là: khi click thì tạo form mới và mở ra.
            var bai = new ToolStripMenuItem("Bài tập lớp");
            bai.DropDownItems.Add("Bài 1 - Quản lý sinh viên", null, (s, e) => Mo(new frmBaitap1()));
            bai.DropDownItems.Add("Bài 2 - Tài khoản ngân hàng", null, (s, e) => Mo(new frmBaiTap2()));

            var nc = new ToolStripMenuItem("Nâng cao");
            nc.DropDownItems.Add("Quản lý học viên", null, (s, e) => Mo(new frmQuanLyHocVien()));

            var vn = new ToolStripMenuItem("Về nhà");
            vn.DropDownItems.Add("Đồng hồ đếm ngược", null, (s, e) => Mo(new frmDongHo()));

            var db = new ToolStripMenuItem("ADO.NET (Bài 7)");
            db.DropDownItems.Add("Quản lý Khoa", null, (s, e) => Mo(new QLKhoa()));
            db.DropDownItems.Add("Quản lý Môn học", null, (s, e) => Mo(new QLMonHoc()));
            db.DropDownItems.Add("Quản lý Sinh viên (CSDL)", null, (s, e) => Mo(new QLSinhVien()));
            db.DropDownItems.Add("Quản lý Điểm", null, (s, e) => Mo(new QLDiem()));
            db.DropDownItems.Add("Quản lý Lớp", null, (s, e) => Mo(new QLLop()));

            var b3 = new ToolStripMenuItem("Combobox/Listbox/TreeView");
            b3.DropDownItems.Add("Lớp 1 - Ước số (ComboBox)", null, (s, e) => Mo(new frmCombobox()));
            b3.DropDownItems.Add("Lớp 2 - QL sinh viên (TreeView)", null, (s, e) => Mo(new frmQLSVTree()));
            b3.DropDownItems.Add("Nâng cao 1 - Xử lý chuỗi", null, (s, e) => Mo(new frmChuoi()));
            b3.DropDownItems.Add("Về nhà 1 - Từ điển", null, (s, e) => Mo(new frmTuDien()));
            b3.DropDownItems.Add("Về nhà 2 - Listbox", null, (s, e) => Mo(new frmListbox()));
            b3.DropDownItems.Add("Về nhà 3 - Danh bạ", null, (s, e) => Mo(new frmDanhBa()));

            menu.Items.AddRange(new ToolStripItem[] { bai, nc, vn, b3, db });
            MainMenuStrip = menu;     // Đăng ký đây là menu chính của form
            Controls.Add(menu);       // Đưa menu lên form (quên dòng này menu sẽ không hiện)
        }

        /// <summary>Hiển thị form con bên trong form chính.</summary>
        private void Mo(Form f)
        {
            f.MdiParent = this;                               // Gắn form con vào form chính (MDI)
            f.StartPosition = FormStartPosition.CenterParent; // Hiện ở giữa form chính
            f.Show();                                         // Show: không chặn thao tác với form khác
        }
    }
}
