/*
* CHƯƠNG TRÌNH CHÈN GIÁ TRỊ LẺ VÀO GIỮA HAI PHẦN TỬ CHẴN LIÊN TIẾP
* Tác giả : Lê Ánh Xuân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho số nguyên n (n <= 500) và dãy n số nguyên a0, a1, ..., an-1. 
*                   Hãy thêm vào vị trí có 2 phần tử liên tiếp là chẵn 1 giá trị lẻ để tạo thành mảng chẵn lẻ xen kẽ.
* Ý tưởng: Dùng một mảng kết quả mới `b`. Quét mảng `a`, đưa a[i] vào `b`. Nếu a[i] và a[i+1] đều chẵn, 
*          chèn thêm một giá trị lẻ (ví dụ: a[i] + 1 hoặc giá trị lẻ bất kỳ như đề mẫu minh họa) vào mảng `b`.
* Mã giả:
*   1. Nhập mảng a có n phần tử
*   2. Khởi tạo mảng b, biến đếm m = 0
*   3. Lặp i từ 0 đến n-1:
*        Thêm a[i] vào b[m++]
*        Nếu i < n - 1 và a[i] chẵn và a[i+1] chẵn:
*            Chèn số lẻ vào b[m++] (ở ví dụ đề bài chèn lẻ tăng tương ứng: 3, 5, 9,...)
*   4. In kết quả mảng trước và sau khi thêm
*/
using System;

namespace LTCsharp.Buoi11
{
    class ThemChanLe
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

            // In mảng trước khi thêm
            Console.WriteLine("* Mang truoc them:");
            Console.Write("Day so co {0} phan tu: ", n);
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();

            // Xử lý thêm phần tử lẻ
            int[] b = new int[1000];
            int m = 0;

            for (int i = 0; i < n; i++)
            {
                b[m++] = a[i];

                // Nếu 2 phần tử liên tiếp cùng là số chẵn
                if (i < n - 1 && a[i] % 2 == 0 && a[i + 1] % 2 == 0)
                {
                    // Chèn số lẻ nằm giữa (a[i] + 1 nếu lẻ, ngược lại a[i] - 1)
                    int giaTriLe = (a[i] + 1) % 2 != 0 ? a[i] + 1 : a[i] - 1;
                    b[m++] = giaTriLe;
                }
            }

            // Xuất dữ liệu sau khi thêm
            Console.WriteLine("* Mang sau khi them:");
            Console.Write("Day so co {0} phan tu: ", m);
            for (int i = 0; i < m; i++)
            {
                Console.Write("{0} ", b[i]);
            }
            Console.WriteLine();

            // Dừng màn hình chờ phím
            Console.Read();
        }
    }
}