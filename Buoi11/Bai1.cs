/*
* CHƯƠNG TRÌNH SẮP XẾP CHẴN TĂNG DẦN Ở ĐẦU, LẺ GIẢM DẦN Ở CUỐI
* Tác giả : Lê Ánh Xuân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho số nguyên n (n <= 500) và dãy n số nguyên a0, a1, ..., an-1. 
*                   Hãy sắp xếp các số chẵn ở phía trước tăng dần, các số lẻ ở phía sau giảm dần.
* Ý tưởng: So sánh hai phần tử a[i] và a[j] (với i < j):
*          - Nếu a[i] lẻ và a[j] chẵn -> đổi chỗ để đưa chẵn lên đầu.
*          - Nếu cùng chẵn mà a[i] > a[j] -> đổi chỗ (tăng dần).
*          - Nếu cùng lẻ mà a[i] < a[j] -> đổi chỗ (giảm dần).
* Mã giả:
*   1. Nhập số lượng n và mảng a[n]
*   2. Lặp i từ 0 đến n-2, j từ i+1 đến n-1:
*        Nếu (a[i] lẻ và a[j] chẵn) hoặc (a[i], a[j] chẵn và a[i] > a[j]) 
*            hoặc (a[i], a[j] lẻ và a[i] < a[j]) -> Swap(a[i], a[j])
*   3. Xuất mảng trước và sau sắp xếp
*/
using System;

namespace LTCsharp.Buoi11
{
    class SapChanLe
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

            // In mảng trước khi sắp xếp
            Console.WriteLine("* Mang truoc khi sap xep:");
            Console.Write("Day so co {0} phan tu: ", n);
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();

            // Xử lý sắp xếp
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    bool swap = false;

                    // Chẵn đứng trước lẻ
                    if (a[i] % 2 != 0 && a[j] % 2 == 0)
                    {
                        swap = true;
                    }
                    // Cùng chẵn: tăng dần
                    else if (a[i] % 2 == 0 && a[j] % 2 == 0 && a[i] > a[j])
                    {
                        swap = true;
                    }
                    // Cùng lẻ: giảm dần
                    else if (a[i] % 2 != 0 && a[j] % 2 != 0 && a[i] < a[j])
                    {
                        swap = true;
                    }

                    if (swap)
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }

            // Xuất dữ liệu sau sắp xếp
            Console.WriteLine("* Mang sau khi sap xep:");
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