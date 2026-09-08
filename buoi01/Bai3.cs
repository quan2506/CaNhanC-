/*
* CHƯƠNG TRÌNH TÍNH BIỂU THỨC F(X) = 1 + 2X + 3X^2 - 4X^3 DÙNG KHÔNG QUÁ 8 PHÉP TOÁN
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho số thực x. Tính f(x) = 1 + 2x + 3x^2 - 4x^3 chỉ dùng phép cộng, trừ, nhân
*                   trong đó sử dụng không quá 8 phép toán.
* Ý tưởng: Áp dụng sơ đồ Horner để biến đổi:
*          f(x) = 1 + x * (2 + x * (3 - 4 * x))
*          -> Chỉ tốn đúng 6 phép toán (nhỏ hơn 8).
* Mã giả:
*   1. Nhập x
*   2. fx = 1 + x * (2 + x * (3 - 4 * x))
*   3. In giá trị f(x)
*/
using System;

namespace LTCsharp.Buoi01
{
    class BieuThucNhanh1
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            double x;
            double fx;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap so thuc x: ");
            x = double.Parse(Console.ReadLine());

            // Xử lý bằng Horner (tốn 6 phép toán)
            fx = 1 + x * (2 + x * (3 - 4 * x));

            // Xuất dữ liệu
            Console.WriteLine("f({0}) = {1:0.00}", x, fx);

            // Dừng màn hình
            Console.Read();
        }
    }
}