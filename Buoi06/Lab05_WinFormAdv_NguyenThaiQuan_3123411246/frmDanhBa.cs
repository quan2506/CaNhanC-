using System;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>
    /// Bài về nhà (buổi Combobox) - Bài 3: Danh bạ với TreeView A-Z.
    /// Thêm người mới vào node của chữ cái đầu của TÊN (First Name), ví dụ "Bình" -> node B.
    /// </summary>
    public class frmDanhBa : Form
    {
        private TreeView tv;
        private TextBox txtFirst, txtLast;

        public frmDanhBa()
        {
            Text = "frmBTVN2";
            ClientSize = new Size(500, 380);
            StartPosition = FormStartPosition.CenterScreen;

            tv = new TreeView { Location = new Point(5, 5), Size = new Size(240, 370) };
            // Khi form load: treeView chứa tất cả ký tự A -> Z.
            // Trong C#, char có thể tăng dần như số: 'A' -> 'B' -> ... -> 'Z'.
            for (char c = 'A'; c <= 'Z'; c++) tv.Nodes.Add(c.ToString());

            Controls.Add(new Label { Text = "First Name", AutoSize = true, Location = new Point(270, 33) });
            txtFirst = new TextBox { Location = new Point(350, 30), Size = new Size(130, 23) };
            Controls.Add(new Label { Text = "Last Name", AutoSize = true, Location = new Point(270, 73) });
            txtLast = new TextBox { Location = new Point(350, 70), Size = new Size(130, 23) };
            var btnAdd = new Button { Text = "Add", Location = new Point(405, 110), Size = new Size(75, 27) };
            var btnExit = new Button { Text = "Exit", Location = new Point(405, 180), Size = new Size(75, 27) };
            Controls.AddRange(new Control[] { tv, txtFirst, txtLast, btnAdd, btnExit });

            btnAdd.Click += (s, e) => Them();
            btnExit.Click += (s, e) => Close();
            AcceptButton = btnAdd;   // Enter = Add
        }

        // Lấy chữ cái đầu của tên và BỎ DẤU tiếng Việt: "Bình" -> 'B', "Đức" -> 'D'.
        private static char ChuCaiDau(string ten)
        {
            // 'đ' không phải chữ có dấu tách được nên thay thủ công thành 'd' trước.
            // Normalize(FormD) tách chữ có dấu thành "chữ cái gốc + dấu" (vd "ì" -> "i" + dấu huyền).
            string d = ten.Trim().Replace('đ', 'd').Replace('Đ', 'D').Normalize(NormalizationForm.FormD);
            foreach (char c in d)
                // Bỏ qua các ký tự dấu (NonSpacingMark), lấy ký tự gốc đầu tiên và viết hoa
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark) return char.ToUpper(c);
            return '?';
        }

        // Nút Add: đưa người mới vào node tương ứng với chữ cái đầu của tên
        private void Them()
        {
            string first = txtFirst.Text.Trim(), last = txtLast.Text.Trim();
            if (first == "" || last == "")
            {
                MessageBox.Show("Vui lòng nhập First Name và Last Name!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            char ch = ChuCaiDau(first);
            if (ch < 'A' || ch > 'Z')   // Tên phải bắt đầu bằng chữ cái
            {
                MessageBox.Show("Tên phải bắt đầu bằng chữ cái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // ch - 'A' cho vị trí trong cây: 'A' -> 0, 'B' -> 1, ..., 'Z' -> 25
            var node = tv.Nodes[ch - 'A'];
            var moi = node.Nodes.Add($"{first}, {last}");   // Hiển thị dạng "Bình, Ngô Thanh" như hình mẫu
            node.Expand();
            tv.SelectedNode = moi;   // Tô sáng người vừa thêm
            txtFirst.Clear(); txtLast.Clear();
            txtFirst.Focus();
        }
    }
}
