using System;
using System.Drawing;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>
    /// Form nền (lớp cha) cho các form ADO.NET: Khoa, Môn học, Sinh viên, Điểm, Lớp.
    /// Mọi form này đều có: vài ô nhập (mỗi ô một nhãn) + 3 nút Thêm / Xóa / Sửa.
    /// Lớp này tự dựng giao diện; lớp con chỉ cần viết Them(), Xoa(), Sua() (abstract = bắt buộc override).
    /// </summary>
    public abstract class FormQuanLy : Form
    {
        protected readonly TextBox[] Txt;   // Mảng các ô nhập, Txt[0] là ô đầu tiên (từ trên xuống)
        private readonly string[] nhan;     // Nội dung nhãn của từng ô, dùng để báo lỗi "xxx không được để trống"

        /// <param name="tieuDe">Tiêu đề cửa sổ</param>
        /// <param name="nhan">Danh sách nhãn; số nhãn = số ô nhập sẽ được tạo</param>
        protected FormQuanLy(string tieuDe, params string[] nhan)
        {
            this.nhan = nhan;
            Text = tieuDe;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;   // Không cho kéo giãn cửa sổ
            MaximizeBox = false;
            BackColor = Color.FromArgb(240, 244, 250);

            // Tạo lần lượt từng cặp (Label, TextBox), mỗi dòng cách nhau 33 pixel
            Txt = new TextBox[nhan.Length];
            int y = 19;
            for (int i = 0; i < nhan.Length; i++, y += 33)
            {
                Controls.Add(new Label { Text = nhan[i], AutoSize = true, Location = new Point(15, y + 3) });
                Txt[i] = new TextBox { Location = new Point(85, y), Size = new Size(225, 23) };
                Controls.Add(Txt[i]);
            }

            // Ba nút đặt bên dưới các ô nhập
            y += 10;
            var btnThem = new Button { Text = "Thêm", Location = new Point(20, y), Size = new Size(85, 32) };
            var btnXoa = new Button { Text = "Xóa", Location = new Point(122, y), Size = new Size(85, 32) };
            var btnSua = new Button { Text = "Sửa", Location = new Point(224, y), Size = new Size(85, 32) };

            // Gắn sự kiện Click: bấm nút thì gọi hàm tương ứng được lớp con viết
            btnThem.Click += (s, e) => Them();
            btnXoa.Click += (s, e) => Xoa();
            btnSua.Click += (s, e) => Sua();
            Controls.AddRange(new Control[] { btnThem, btnXoa, btnSua });
            ClientSize = new Size(330, y + 50);   // Chiều cao form tự co theo số ô nhập
        }

        // Ba hàm này lớp con bắt buộc phải viết (chứa câu lệnh SQL và quy tắc kiểm tra riêng)
        protected abstract void Them();
        protected abstract void Xoa();
        protected abstract void Sua();

        /// <summary>Lấy nội dung (đã Trim khoảng trắng đầu/cuối) của ô nhập thứ i.</summary>
        protected string Gt(int i) => Txt[i].Text.Trim();

        /// <summary>
        /// Kiểm tra các ô chỉ định BẮT BUỘC phải có dữ liệu.
        /// Nếu có ô trống: báo lỗi, đặt con trỏ vào ô đó (Focus) và trả về false.
        /// </summary>
        /// <param name="chiSo">Chỉ số các ô cần kiểm tra, ví dụ BatBuoc(0, 1)</param>
        protected bool BatBuoc(params int[] chiSo)
        {
            foreach (int i in chiSo)
                if (Gt(i) == "")
                {
                    MessageBox.Show($"{nhan[i]} không được để trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Txt[i].Focus();
                    return false;
                }
            return true;
        }

        /// <summary>
        /// Trong các ô chỉ định phải có ÍT NHẤT MỘT ô có dữ liệu (dùng cho chức năng Sửa:
        /// trường nào không nhập thì không đổi, nhưng không được bỏ trống tất cả).
        /// </summary>
        protected bool ItNhatMot(params int[] chiSo)
        {
            foreach (int i in chiSo) if (Gt(i) != "") return true;
            MessageBox.Show("Phải nhập dữ liệu ít nhất một trường cần thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Txt[chiSo[0]].Focus();
            return false;
        }
    }
}
