/*
* CHƯƠNG TRÌNH TÍNH TỔNG CÁC SỐ TRONG ĐOẠN [A, B]
* Tác giả : NGuyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập vào hai số nguyên a và b (a <= b). Hãy tính tổng các số nằm trong đoạn [a, b].
*                   Lưu ý: tổng từ a đến b bằng tổng từ 1 đến b trừ cho tổng từ 1 đến a-1.
* Ý tưởng: Sử dụng công thức tổng cấp số cộng S(n) = n * (n + 1) / 2.
*          Tổng [a, b] = S(b) - S(a - 1).
* Mã giả:
*   1. Nhập a, b
*   2. tongB = b * (b + 1) / 2
*   3. tongA = (a - 1) * a / 2
*   4. tong = tongB - tongA
*   5. In kết quả
*/
using System;

namespace LTCsharp.Buoi01
{
    class TongDoan
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            long a, b;
            long tong;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap so a, b: ");
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            a = long.Parse(input[0]);
            b = long.Parse(input[1]);

            // Xử lý bằng công thức theo gợi ý
            long tongDenB = b * (b + 1) / 2;
            long tongDenATru1 = (a - 1) * a / 2;
            tong = tongDenB - tongDenATru1;

            // Xuất dữ liệu
            Console.WriteLine("Tong cua cac so trong doan[{0}, {1}] la {2}.", a, b, tong);

            // Dừng màn hình
            Console.Read();
        }
    }
}