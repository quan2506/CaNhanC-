using System;
using System.Windows.Forms;

namespace Practice5
{
    /// <summary>Điểm khởi chạy của chương trình.</summary>
    internal static class Program
    {
        [STAThread]   // Bắt buộc cho ứng dụng Windows Forms (một luồng giao diện duy nhất)
        static void Main()
        {
            ApplicationConfiguration.Initialize();   // Thiết lập cấu hình mặc định cho WinForms
            Application.Run(new frmMain());          // Chạy form chính; đóng form này là thoát chương trình
        }
    }
}
