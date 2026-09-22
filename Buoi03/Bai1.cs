/*
* CHƯƠNG TRÌNH TÌM GIÁ TRỊ LỚN NHẤT VÀ NHỎ NHẤT CỦA 5 SỐ
* Tác giả : Nguyễn Trường Thành
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập vào giá trị a, b, c, d, e. Hãy tìm giá trị lớn nhất và nhỏ nhất của 5 số.
* Ý tưởng: Khởi tạo max = a, min = a. Lần lượt so sánh với b, c, d, e để cập nhật max và min.
* Mã giả:
*   1. Nhập a, b, c, d, e
*   2. max = a, min = a
*   3. Lần lượt kiểm tra b, c, d, e với max và min để cập nhật
*   4. In kết quả max, min
*/
using System;

namespace LTCsharp.Buoi03
{
    class MaxMin5So
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            double a, b, c, d, e;
            double max, min;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap 5 so a, b, c, d, e: ");
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            a = double.Parse(input[0]);
            b = double.Parse(input[1]);
            c = double.Parse(input[2]);
            d = double.Parse(input[3]);
            e = double.Parse(input[4]);

            // Xử lý tìm max
            max = a;
            if (b > max) max = b;
            if (c > max) max = c;
            if (d > max) max = d;
            if (e > max) max = e;

            // Xử lý tìm min
            min = a;
            if (b < min) min = b;
            if (c < min) min = c;
            if (d < min) min = d;
            if (e < min) min = e;

            // Xuất dữ liệu
            Console.WriteLine("Gia tri lon nhat cua {0}, {1}, {2}, {3}, {4} la {5}.", a, b, c, d, e, max);
            Console.WriteLine("Gia tri nho nhat cua {0}, {1}, {2}, {3}, {4} la {5}.", a, b, c, d, e, min);

            // Dừng màn hình
            Console.Read();
        }
    }
}