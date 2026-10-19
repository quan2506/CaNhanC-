using System;
using System.Drawing;
using System.Windows.Forms;

namespace Practice6
{
    /// <summary>
    /// Form nền (lớp cha) cho các form CRUD: tự dựng giao diện gồm
    /// vài ô nhập (mỗi ô một nhãn) + 3 nút Thêm / Xóa / Sửa.
    /// Lớp con chỉ cần override Them(), Xoa(), Sua().
    /// </summary>
    public abstract class FormQuanLy : Form
    {
        protected readonly TextBox[] Txt;
        private readonly string[] nhan;

        protected FormQuanLy(string tieuDe, params string[] nhan)
        {
            this.nhan = nhan;
            Text = tieuDe;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            BackColor = Color.FromArgb(240, 244, 250);

            Txt = new TextBox[nhan.Length];
            int y = 19;
            for (int i = 0; i < nhan.Length; i++, y += 33)
            {
                Controls.Add(new Label { Text = nhan[i], AutoSize = true, Location = new Point(15, y + 3) });
                Txt[i] = new TextBox { Location = new Point(85, y), Size = new Size(225, 23) };
                Controls.Add(Txt[i]);
            }

            y += 10;
            var btnThem = new Button { Text = "Thêm", Location = new Point(20, y), Size = new Size(85, 32) };
            var btnXoa = new Button { Text = "Xóa", Location = new Point(122, y), Size = new Size(85, 32) };
            var btnSua = new Button { Text = "Sửa", Location = new Point(224, y), Size = new Size(85, 32) };

            btnThem.Click += (s, e) => Them();
            btnXoa.Click += (s, e) => Xoa();
            btnSua.Click += (s, e) => Sua();
            Controls.AddRange(new Control[] { btnThem, btnXoa, btnSua });
            ClientSize = new Size(330, y + 50);
        }

        protected abstract void Them();
        protected abstract void Xoa();
        protected abstract void Sua();

        protected string Gt(int i) => Txt[i].Text.Trim();

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

        protected bool ItNhatMot(params int[] chiSo)
        {
            foreach (int i in chiSo) if (Gt(i) != "") return true;
            MessageBox.Show("Phải nhập dữ liệu ít nhất một trường cần thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Txt[chiSo[0]].Focus();
            return false;
        }
    }
}
