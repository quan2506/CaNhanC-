/*
* CHƯƠNG TRÌNH QUY ĐỔI GIỜ PHÚT GIÂY SANG TỔNG SỐ GIÂY
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Một thiết bị hoạt động được h giờ, m phút và s giây. 
*                   Hãy viết chương trình chuyển thời gian đó sang tổng số giây.
* Ý tưởng: 1 giờ = 3600 giây, 1 phút = 60 giây. 
*          Tổng giây = h * 3600 + m * 60 + s.
* Mã giả:
*   1. Nhập h, m, s
*   2. tongGiay = h * 3600 + m * 60 + s
*   3. In "Tong so giay cua h:m:s la tongGiay giay"
*/
using System;

namespace LTCsharp.Buoi02
{
    class DoiSangGiay
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int h, m, s;
            long tongGiay;

            // Nhập dữ liệu
            Console.Write("Nhap so gio: ");
            h = int.Parse(Console.ReadLine());
            Console.Write("Nhap so phut: ");
            m = int.Parse(Console.ReadLine());
            Console.Write("Nhap so giay: ");
            s = int.Parse(Console.ReadLine());

            // Xử lý
            tongGiay = h * 3600 + m * 60 + s;

            // Xuất dữ liệu
            Console.WriteLine("Tong so giay cua {0}:{1}:{2} la {3} giay", h, m, s, tongGiay);

            // Dừng màn hình chờ phím
            Console.Read();
        }
    }
}