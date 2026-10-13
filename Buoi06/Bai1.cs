/*
* CHƯƠNG TRÌNH IN CHỮ I VÀ CHỮ U THEO CHIỀU CAO H
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập vào chiều cao h. Hãy in chữ I và U ứng với chiều cao h.
* Ý tưởng: 
*   Mỗi dòng in chữ I (kích thước ngang h) và chữ U (kích thước ngang h) đặt cạnh nhau cách nhau vài khoảng trắng:
*   - Chữ I: dòng 0 và dòng h-1 in hàng ngang '*', các dòng ở giữa in '*' ở cột giữa (h / 2).
*   - Chữ U: dòng 0 đến h-2 in '*' ở 2 viền ngoài, dòng h-1 in hàng ngang '*'.
* Mã giả:
*   1. Nhập chiều cao h
*   2. Lặp dòng r từ 0 đến h - 1:
*        In ký tự tương ứng của chữ I tại dòng r
*        In khoảng cách phân cách
*        In ký tự tương ứng của chữ U tại dòng r
*   3. Xuất kết quả
*/
using System;

namespace LTCsharp.Buoi06
{
    class InChuIvaU
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int h;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap chieu cao h: ");
            h = int.Parse(Console.ReadLine());

            // Xuất dữ liệu
            Console.WriteLine("Chu I va U ung voi h = {0} la:", h);

            int mid = h / 2;

            for (int r = 0; r < h; r++)
            {
                // In chữ I
                for (int c = 0; c < h; c++)
                {
                    if (r == 0 || r == h - 1 || c == mid)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                // Khoảng cách giữa chữ I và chữ U
                Console.Write("  ");

                // In chữ U
                for (int c = 0; c < h; c++)
                {
                    if (r == h - 1 || c == 0 || c == h - 1)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }

                Console.WriteLine();
            }

            // Dừng màn hình
            Console.Read();
        }
    }
}