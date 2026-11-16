/*
* CHƯƠNG TRÌNH KIỂM TRA MA TRẬN TOÀN SỐ LẺ
* Tác giả : Lê Ánh Xuân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho ma trận A chứa các số nguyên có n dòng và m cột (1 <= n, m <= 100).
*                   Hãy kiểm tra xem ma trận có toàn lẻ không?
* Ý tưởng: Dùng cờ hiệu (flag) ban đầu gán là true. Quét toàn bộ ma trận, 
*          nếu gặp bất kỳ phần tử chẵn nào thì đổi cờ thành false và dừng lặp.
* Mã giả:
*   1. Nhập ma trận nguyên A[n, m]
*   2. isToanLe = true
*   3. Duyệt các phần tử: nếu A[i, j] % 2 == 0 thì isToanLe = false, break
*   4. Xuất kết quả tương ứng
*/
using System;

namespace LTCsharp.Buoi12
{
    class MaTranToanLe
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int n, m;
            bool isToanLe = true;

            // Nhập kích thước
            Console.Write("Nhap so dong n: ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot m: ");
            m = int.Parse(Console.ReadLine());

            int[,] A = new int[n, m];

            // Nhập dữ liệu ma trận
            Console.WriteLine("Nhap ma tran A:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("A[{0},{1}] = ", i, j);
                    A[i, j] = int.Parse(Console.ReadLine());
                }
            }

            // Xử lý
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (A[i, j] % 2 == 0)
                    {
                        isToanLe = false;
                        break;
                    }
                }
                if (!isToanLe) break;
            }

            // Xuất dữ liệu
            if (isToanLe)
            {
                Console.WriteLine("Mang A toan le!");
            }
            else
            {
                Console.WriteLine("Mang A khong toan le!");
            }

            // Dừng màn hình chờ phím
            Console.Read();
        }
    }
}