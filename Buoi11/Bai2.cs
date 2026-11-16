/*
* CHƯƠNG TRÌNH XÓA CÁC PHẦN TỬ CÓ GIÁ TRỊ CHẴN TRONG MẢNG
* Tác giả : Lê Ánh Xuân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho số nguyên n (n <= 500) và dãy n số nguyên a0, a1, ..., an-1.
*                   Hãy xóa các phần tử có giá trị chẵn.
* Ý tưởng: Duyệt qua từng phần tử. Nếu gặp phần tử chẵn, dồn tất cả phần tử phía sau 
*          lên trước 1 vị trí và giảm số lượng n đi 1; sau đó giữ nguyên chỉ số i để xét lại.
* Mã giả:
*   1. Nhập n và mảng a[n]
*   2. Lặp i từ 0 đến n-1:
*        Nếu a[i] % 2 == 0:
*            Dồn phần tử từ k = i đến n-2: a[k] = a[k+1]
*            n--, i--
*   3. Xuất mảng trước và sau khi xóa
*/
using System;

namespace LTCsharp.Buoi11
{
    class XoaChan
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int n;

            // Nhập dữ liệu
            Console.Write("Nhap so luong phan tu n: ");
            n = int.Parse(Console.ReadLine());

            int[] a = new int[500];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap a[{0}]: ", i);
                a[i] = int.Parse(Console.ReadLine());
            }

            // In mảng trước khi xóa
            Console.WriteLine("* Mang truoc xoa:");
            Console.Write("Day so co {0} phan tu: ", n);
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();

            // Xử lý xóa phần tử chẵn
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 == 0)
                {
                    for (int k = i; k < n - 1; k++)
                    {
                        a[k] = a[k + 1];
                    }
                    n--;
                    i--; // Giảm chỉ số để kiểm tra giá trị mới dồn về tại vị trí i
                }
            }

            // Xuất dữ liệu sau khi xóa
            Console.WriteLine("* Mang sau khi xoa:");
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