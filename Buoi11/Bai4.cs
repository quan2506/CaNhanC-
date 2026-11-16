/*
* CHƯƠNG TRÌNH ĐẢO NGƯỢC DÃY SỐ
* Tác giả : Lê Ánh Xuân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho số nguyên n (n <= 500) và dãy n số nguyên a0, a1, ..., an-1. 
*                   Hãy đảo ngược dãy số này.
* Ý tưởng: Dùng 2 con trỏ `left = 0` và `right = n - 1`. Hoán đổi giá trị a[left] và a[right],
*          sau đó tăng left lên 1 và giảm right đi 1 cho đến khi left >= right.
* Mã giả:
*   1. Nhập n và mảng a[n]
*   2. left = 0, right = n - 1
*   3. Lặp khi left < right:
*        Swap(a[left], a[right])
*        left++, right--
*   4. Xuất kết quả
*/
using System;

namespace LTCsharp.Buoi11
{
    class DaoDay
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int n;

            // Nhập dữ liệu
            Console.Write("Nhap so luong phan tu n: ");
            n = int.Parse(Console.ReadLine());

            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap a[{0}]: ", i);
                a[i] = int.Parse(Console.ReadLine());
            }

            // In mảng trước khi đảo
            Console.WriteLine("* Mang truoc dao:");
            Console.Write("Day so co {0} phan tu: ", n);
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();

            // Xử lý đảo ngược dãy
            int left = 0;
            int right = n - 1;
            while (left < right)
            {
                int temp = a[left];
                a[left] = a[right];
                a[right] = temp;

                left++;
                right--;
            }

            // Xuất dữ liệu sau khi đảo
            Console.WriteLine("* Mang sau khi dao:");
            Console.Write("Day so co {0} phan tu: ", n);
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();

            // Dừng màn hình chờ phím
            Console.Read();
        }
    }
}