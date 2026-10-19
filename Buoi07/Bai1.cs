/*
* CHƯƠNG TRÌNH IN CÁC HÌNH TAM GIÁC CÂN RỖNG
* Tác giả : Bùi Minh Quang
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập vào chiều cao h. Hãy in hình tam giác ứng với chiều cao h (in 3 tam giác h, h+2, h+4).
* Ý tưởng: Viết hàm in một tam giác cân rỗng:
*          - Đỉnh: in khoảng trắng rồi in ký tự '*'.
*          - Cạnh bên: in ký tự '*' ở đầu và cuối đường chéo.
*          - Đáy: in các dấu '*' cách nhau.
* Mã giả:
*   1. Nhập chiều cao h
*   2. Lặp 3 lần: in tam giác với chiều cao h, h + 2, h + 4
*/
using System;

namespace LTCsharp.Buoi07
{
    class InHinhTamGiacVaVuong
    {
        static void InTamGiac(int h)
        {
            Console.WriteLine("h={0}", h);
            for (int i = 0; i < h; i++)
            {
                // In khoảng trắng căn lề trái
                for (int sp = 0; sp < h - 1 - i; sp++)
                {
                    Console.Write("  ");
                }

                if (i == 0)
                {
                    Console.WriteLine("*");
                }
                else if (i == h - 1)
                {
                    for (int j = 0; j < h; j++)
                    {
                        Console.Write("*   ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("*");
                    for (int sp = 0; sp < 2 * i - 1; sp++)
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine("  *");
                }
            }
        }

        public static void Main(string[] args)
        {
            // Khai báo biến
            int h;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap chieu cao h: ");
            h = int.Parse(Console.ReadLine());

            // Xử lý và in kết quả
            InTamGiac(h);
            InTamGiac(h + 2);
            InTamGiac(h + 4);

            // Dừng màn hình
            Console.Read();
        }
    }
}