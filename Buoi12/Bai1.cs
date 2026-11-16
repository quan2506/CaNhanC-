/*
* CHƯƠNG TRÌNH TÍNH TỔNG CÁC SỐ CHẴN, LẺ TRONG MA TRẬN
* Tác giả : Lê Ánh Xuân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho ma trận A chứa các số nguyên có n dòng và m cột (1 <= n, m <= 100).
*                   Hãy tính tổng các số chẵn, số lẻ có trong ma trận A.
* Ý tưởng: Duyệt qua từng phần tử A[i, j]. Nếu chia hết cho 2 thì cộng vào tổng chẵn, 
*          ngược lại cộng vào tổng lẻ.
* Mã giả: 
*   1. Nhập số dòng n, số cột m
*   2. Nhập các phần tử của mảng 2 chiều A[n, m]
*   3. Duyệt i từ 0 đến n-1, j từ 0 đến m-1:
*        Nếu A[i, j] % 2 == 0 -> tongChan += A[i, j]
*        Ngược lại -> tongLe += A[i, j]
*   4. In kết quả tongChan, tongLe
*/
using System;

namespace LTCsharp.Buoi12
{
    class TongChanLeMang2C
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int n, m;
            int tongChan = 0, tongLe = 0;

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
                        tongChan += A[i, j];
                    }
                    else
                    {
                        tongLe += A[i, j];
                    }
                }
            }

            // Xuất dữ liệu
            Console.WriteLine("Tong cac so chan la {0} va tong so le la {1}.", tongChan, tongLe);

            // Dừng màn hình chờ phím
            Console.Read();
        }
    }
}
            