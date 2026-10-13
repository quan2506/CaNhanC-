using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>
    /// Bài về nhà (buổi Combobox) - Bài 1: Từ điển Anh-Việt và Việt-Anh.
    /// Dùng TabControl 2 trang; dữ liệu từ lưu sẵn trong Dictionary (từ -> nghĩa).
    /// </summary>
    public class frmTuDien : Form
    {
        // Dictionary<khóa, giá trị>: tra từ nhanh theo khóa. OrdinalIgnoreCase => không phân biệt chữ hoa/thường.
        private static readonly Dictionary<string, string> AnhViet = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["student"] = "Sinh viên, học sinh", ["teacher"] = "Giáo viên", ["worker"] = "Công nhân",
            ["hat"] = "Cái mũ", ["head"] = "Cái đầu", ["mouse"] = "Con chuột", ["cat"] = "Con mèo",
            ["dog"] = "Con chó", ["snake"] = "Con rắn", ["lamb"] = "Con cừu non", ["loan"] = "Khoản vay",
            ["frog"] = "Con ếch", ["sheep"] = "Con cừu", ["book"] = "Quyển sách", ["house"] = "Ngôi nhà",
            ["water"] = "Nước", ["apple"] = "Quả táo", ["computer"] = "Máy tính"
        };

        private static readonly Dictionary<string, string> VietAnh = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            ["sinh viên"] = "student", ["giáo viên"] = "teacher", ["công nhân"] = "worker",
            ["cái mũ"] = "hat", ["cái đầu"] = "head", ["con chuột"] = "mouse", ["con mèo"] = "cat",
            ["con chó"] = "dog", ["con rắn"] = "snake", ["con ếch"] = "frog", ["con cừu"] = "sheep",
            ["quyển sách"] = "book", ["ngôi nhà"] = "house", ["nước"] = "water", ["quả táo"] = "apple",
            ["máy tính"] = "computer"
        };

        public frmTuDien()
        {
            Text = "TỪ ĐIỂN ANH VIỆT - VIỆT ANH";
            ClientSize = new Size(400, 380);
            StartPosition = FormStartPosition.CenterScreen;

            var tab = new TabControl { Location = new Point(10, 10), Size = new Size(380, 320) };
            // Hai trang tạo bằng cùng một hàm TaoTab, chỉ khác từ điển và nhãn truyền vào => không phải viết lặp code
            tab.TabPages.Add(TaoTab("ANH - VIỆT", "Tiếng Anh", "Tiếng Việt", AnhViet));
            tab.TabPages.Add(TaoTab("VIỆT - ANH", "Tiếng Việt", "Tiếng Anh", VietAnh));

            var btnThoat = new Button { Text = "Thoát", Location = new Point(300, 340), Size = new Size(85, 28) };
            btnThoat.Click += (s, e) => Close();
            Controls.AddRange(new Control[] { tab, btnThoat });
        }

        // Tạo một trang từ điển gồm: ô gõ từ + danh sách từ + ô hiện nghĩa
        private TabPage TaoTab(string tieuDe, string nhanNguon, string nhanDich, Dictionary<string, string> tuDien)
        {
            var page = new TabPage(tieuDe);
            page.Controls.Add(new Label { Text = nhanNguon, AutoSize = true, Location = new Point(15, 15) });
            page.Controls.Add(new Label { Text = nhanDich, AutoSize = true, Location = new Point(195, 15) });

            var txt = new TextBox { Location = new Point(15, 38), Size = new Size(160, 23) };                 // Ô gõ từ cần tra
            var lstTu = new ListBox { Location = new Point(15, 63), Size = new Size(160, 190) };             // Danh sách các từ
            var lstNghia = new TextBox { Location = new Point(195, 38), Size = new Size(160, 215), Multiline = true, ReadOnly = true, BackColor = Color.White };  // Hiện nghĩa

            // Danh sách từ được sắp xếp theo thứ tự chữ cái để dễ dò tìm
            var tu = new List<string>(tuDien.Keys);
            tu.Sort(StringComparer.OrdinalIgnoreCase);
            lstTu.Items.AddRange(tu.ToArray());
            page.Controls.AddRange(new Control[] { txt, lstTu, lstNghia });

            // Yêu cầu: gõ từ cần tra thì chương trình dò đến từ khớp gần nhất.
            // Mỗi lần nội dung ô gõ thay đổi, tìm từ đầu tiên BẮT ĐẦU bằng chuỗi đã gõ và chọn nó trong ListBox.
            txt.TextChanged += (s, e) =>
            {
                string k = txt.Text.Trim();
                if (k == "") return;
                for (int i = 0; i < lstTu.Items.Count; i++)
                    if (lstTu.Items[i].ToString().StartsWith(k, StringComparison.OrdinalIgnoreCase))
                    {
                        lstTu.SelectedIndex = i;
                        return;
                    }
                lstTu.ClearSelected();   // Không có từ nào khớp => bỏ chọn
            };

            // Hàm cục bộ: tra nghĩa của từ t. TryGetValue trả true nếu tìm thấy và gán nghĩa vào biến nghia.
            Action<string> tra = t =>
            {
                lstNghia.Text = tuDien.TryGetValue(t.Trim(), out var nghia) ? nghia : "Không tìm thấy từ này";
            };

            // Yêu cầu: nhấn Enter hoặc double click vào từ thì hiện nghĩa
            txt.KeyDown += (s, e) =>
            {
                if (e.KeyCode != Keys.Enter) return;
                e.SuppressKeyPress = true;   // Chặn tiếng "bíp" mặc định khi nhấn Enter trong TextBox
                tra(lstTu.SelectedItem != null ? lstTu.SelectedItem.ToString() : txt.Text);
            };
            lstTu.DoubleClick += (s, e) =>
            {
                if (lstTu.SelectedItem == null) return;
                txt.Text = lstTu.SelectedItem.ToString();
                tra(txt.Text);
            };
            return page;
        }
    }
}
