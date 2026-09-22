/*
* CHƯƠNG TRÌNH TÍNH GIÁ TRỊ CÁC HÀM SỐ PHÂN NHÁNH
* Tác giả : Nguyễn Trường Thành
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho số thực x. Tính f1(x) và f2(x):
*                   f1(x) = 0 (nếu x <= 0); x (nếu 0 < x <= 1); x^4 (nếu x > 1)
*                   f2(x) = x^2 + 4x + 5 (nếu x <= 2); 1 / (x^2 + 4x + 5) (nếu x > 2)
* Ý tưởng: Sử dụng câu lệnh if-else if-else để xét các miền giá trị của x và tính f1, f2.
* Mã giả:
*   1. Nhập x
*   2. Xét x để tính f1
*   3. Xét x để tính f2
*   4. In kết quả f1(x) và f2(x)
*/
using System;

namespace LTCsharp.Buoi03
{
    class GiaTriHamSo1
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            double x;
            double f1, f2;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap so thuc x: ");
            x = double.Parse(Console.ReadLine());

            // Xử lý tính f1(x)
            if (x <= 0)
            {
                f1 = 0;
            }
            else if (x <= 1)
            {
                f1 = x;
            }
            else
            {
                f1 = Math.Pow(x, 4);
            }

            // Xử lý tính f2(x)
            double mau = x * x + 4 * x + 5;
            if (x <= 2)
            {
                f2 = mau;
            }
            else
            {
                f2 = 1.0 / mau;
            }

            // Xuất dữ liệu
            Console.WriteLine("f1({0}) = {1:0.00}", x, f1);
            Console.WriteLine("f2({0}) = {1:0.00}", x, f2);

            // Dừng màn hình
            Console.Read();
        }
    }
}