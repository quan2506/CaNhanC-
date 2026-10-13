/*
* CHƯƠNG TRÌNH TÍNH GIÁ TRỊ CÁC BIỂU THỨC S1 VÀ S2
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập vào số nguyên dương n. Hãy tính giá trị của:
*                   S1 = 1/1 + 1/2 + ... + 1/n
*                   S2 = 1/n - 1/(n-1) + 1/(n-2) - ... + (-1)^(n+1) * 1/1
* Ý tưởng: 
*   - Duyệt i từ 1 đến n để cộng dồn vào S1: S1 += 1.0 / i.
*   - Với S2: duyệt mẫu số m từ n về 1 với dấu xen kẽ bắt đầu từ dấu dương (+1).
* Mã giả:
*   1. Nhập n
*   2. S1 = 0, S2 = 0, dau = 1
*   3. Lặp i từ 1 đến n: S1 += 1.0 / i
*   4. Lặp m từ n về 1:
*        S2 += dau * (1.0 / m)
*        dau = -dau
*   5. In giá trị S1 và S2
*/
using System;

namespace LTCsharp.Buoi05
{
    class GiaTriBieuThuc
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int n;
            double s1 = 0.0, s2 = 0.0;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap so nguyen n: ");
            n = int.Parse(Console.ReadLine());

            // Xử lý S1
            for (int i = 1; i <= n; i++)
            {
                s1 += 1.0 / i;
            }

            // Xử lý S2: 1/n - 1/(n-1) + 1/(n-2) - ...
            double dau = 1.0;
            for (int m = n; m >= 1; m--)
            {
                s2 += dau * (1.0 / m);
                dau = -dau;
            }

            // Xuất dữ liệu
            Console.WriteLine("S1(n={0}) = {1:0.0000}", n, s1);
            Console.WriteLine("S2(n={0}) = {1:0.0000}", n, s2);

            // Dừng màn hình
            Console.Read();
        }
    }
}