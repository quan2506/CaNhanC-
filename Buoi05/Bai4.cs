/*
* CHƯƠNG TRÌNH TÌM SỐ NGUYÊN DƯƠNG N BÉ NHẤT ĐỂ CHUỖI ĐIỀU HÒA > A
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập vào số thực a. Hãy tìm số nguyên dương n bé nhất thỏa:
*                   1 + 1/2 + 1/3 + ... + 1/n > a.
* Ý tưởng: Dùng vòng lặp tăng n từ 1, cộng dồn tổng tong += 1.0 / n. 
*          Ngay khi tong > a thì dừng và n lúc đó chính là giá trị nhỏ nhất cần tìm.
* Mã giả:
*   1. Nhập số thực a
*   2. tong = 0, n = 0
*   3. Lặp khi tong <= a:
*        n++
*        tong += 1.0 / n
*   4. In kết quả n
*/
using System;

namespace LTCsharp.Buoi05
{
    class TimBeNhatThoa
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            double a;
            double tong = 0.0;
            int n = 0;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap so thuc a: ");
            a = double.Parse(Console.ReadLine());

            // Xử lý
            while (tong <= a)
            {
                n++;
                tong += 1.0 / n;
            }

            // Xuất dữ liệu
            Console.WriteLine("So nguyen duong n be nhat thoa man la: {0}", n);
            Console.WriteLine("Gia tri tong dat duoc: {0:0.0000}", tong);

            // Dừng màn hình
            Console.Read();
        }
    }
}