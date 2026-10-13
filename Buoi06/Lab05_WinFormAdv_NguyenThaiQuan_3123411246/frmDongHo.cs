using System;
using System.Drawing;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>
    /// Bài tập về nhà 1: Đồng hồ đếm ngược bắt đầu từ 30:00.
    /// Dùng control Timer: cứ mỗi khoảng Interval (ms) thì phát sinh sự kiện Tick một lần.
    /// </summary>
    public class frmDongHo : Form
    {
        private Label lblThoiGian;
        private Button btnBatDau;
        private Timer timer;
        private int giay = 30 * 60;   // Tổng số giây còn lại: 30 phút = 1800 giây

        public frmDongHo()
        {
            Text = "Đồng hồ";
            ClientSize = new Size(220, 110);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            lblThoiGian = new Label
            {
                Text = "30:00", Font = new Font("Consolas", 16, FontStyle.Bold),
                AutoSize = false, TextAlign = ContentAlignment.MiddleCenter, Location = new Point(0, 15), Size = new Size(220, 35)
            };
            btnBatDau = new Button { Text = "Bắt đầu", Location = new Point(70, 60), Size = new Size(80, 30) };
            Controls.AddRange(new Control[] { lblThoiGian, btnBatDau });

            // Interval = 1000 ms = 1 giây. Timer mới tạo chưa chạy, phải gọi Start() mới đếm.
            timer = new Timer { Interval = 1000 };
            timer.Tick += (s, e) =>   // Chạy mỗi giây một lần
            {
                giay--;          // Giảm 1 giây
                HienThi();       // Cập nhật chữ trên Label
                if (giay <= 0)   // Hết giờ
                {
                    timer.Stop();
                    btnBatDau.Text = "Bắt đầu";
                    giay = 30 * 60;   // Đặt lại 30:00 để có thể bắt đầu lần nữa
                    MessageBox.Show("Hết giờ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    HienThi();
                }
            };

            // Một nút đóng nhiều vai trò: Bắt đầu -> Tạm dừng -> Tiếp tục
            btnBatDau.Click += (s, e) =>
            {
                if (timer.Enabled) { timer.Stop(); btnBatDau.Text = "Tiếp tục"; }      // Đang chạy => dừng
                else { timer.Start(); btnBatDau.Text = "Tạm dừng"; }                   // Đang dừng => chạy
            };
            FormClosed += (s, e) => timer.Dispose();   // Giải phóng Timer khi đóng form
        }

        // Đổi số giây thành dạng "mm:ss". Ví dụ 1800 -> "30:00", 65 -> "01:05".
        //  giay / 60 = số phút (chia nguyên); giay % 60 = số giây lẻ; ":00" = luôn hiển thị đủ 2 chữ số.
        private void HienThi() => lblThoiGian.Text = $"{giay / 60:00}:{giay % 60:00}";
    }
}
