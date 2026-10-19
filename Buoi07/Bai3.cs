/*
* CHƯƠNG TRÌNH TÍNH SỐ PI THEO CÔNG THỨC LEIBNIZ
* Tác giả : Bùi Minh Quang
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập vào sai số epsilon. Viết chương trình tính số pi theo công thức:
*                   pi = 4 * (1 - 1/3 + 1/5 - 1/7 + ... + (-1)^n / (2n + 1))
*                   cho đến khi 4 / (2n + 1) < epsilon.
* Ý tưởng: Dùng vòng lặp cộng/trừ các hạng tử với dấu xen kẽ cho đến khi giá trị 4 / (2n + 1) nhỏ hơn epsilon.
* Mã giả:
*   1. Nhập epsilon
*   2. Khởi tạo pi = 0, n = 0, dau = 1
*   3. Lặp khi 4 / (2n + 1) >= epsilon:
*        pi += dau * (4.0 / (2*n + 1))
*        dau = -dau
*        n++
*   4. In pi và sai số thực tế
*/
using System;

namespace LTCsharp.Buoi07
{
    class TinhSoPi
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            double epsilon;
            double pi = 0.0;
            int n = 0;
            double dau = 1.0;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap do sai so epsilon: ");
            epsilon = double.Parse(Console.ReadLine());

            // Xử lý
            while (true)
            {
                double hangTu = 4.0 / (2 * n + 1);
                if (hangTu < epsilon)
                {
                    break;
                }
                pi += dau * hangTu;
                dau = -dau;
                n++;
            }

            double saiSoThucTe = Math.Abs(pi - Math.PI);

            // Xuất dữ liệu
            Console.WriteLine("So pi tinh den do chinh xac {0} la {1}.", epsilon, pi);
            Console.WriteLine("Do sai so thuc te la {0}.", saiSoThucTe);

            // Dừng màn hình
            Console.Read();
        }
    }
}