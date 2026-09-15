/*
* CHƯƠNG TRÌNH QUY ĐỔI TỔNG SỐ GIÂY SANG DẠNG GIỜ:PHÚT:GIÂY
* Tác giả : Nguyễn Trường Thành
* Ngày viết:15/09/2026
*
* Phát biểu đề bài: Một thiết bị hoạt động được t giây. Hãy viết chương trình chuyển số giây đó 
*                   dưới dạng số giờ, số phút và số giây (h:m:s).
* Ý tưởng:
*   - Số giờ h = t / 3600
*   - Phần dư sau khi lấy giờ: t % 3600
*   - Số phút m = (t % 3600) / 60
*   - Số giây còn lại s = (t % 3600) % 60
* Mã giả:
*   1. Nhập t
*   2. h = t / 3600
*   3. m = (t % 3600) / 60
*   4. s = (t % 3600) % 60
*   5. In "t giay co dang h:m:s"
*/
using System;

namespace LTCsharp.Buoi02
{
    class DoiSangGioPhutGiay
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            long t;
            long h, m, s;

            // Nhập dữ liệu
            Console.Write("Nhap vao tong so giay: ");
            t = long.Parse(Console.ReadLine());

            // Xử lý chuyển đổi
            h = t / 3600;
            long phanDu = t % 3600;
            m = phanDu / 60;
            s = phanDu % 60;

            // Xuất dữ liệu
            Console.WriteLine("{0} giay co dang {1}:{2}:{3}", t, h, m, s);

            // Dừng màn hình chờ phím
            Console.Read();
        }
    }
}