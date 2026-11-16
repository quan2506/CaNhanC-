/*
* CHƯƠNG TRÌNH ĐẾM SỐ TRÊN BIÊN MA TRẬN
* Tác giả : Lê Ánh Xuân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho ma trận A chứa các số thực có n dòng và m cột (1 <= n, m <= 100).
*                   Hãy đếm các số dương, âm và không trên đường biên ma trận A.
* Ý tưởng: Một phần tử A[i, j] nằm trên biên khi: i == 0 || i == n - 1 || j == 0 || j == m - 1.
*          Duyệt qua các phần tử biên và phân loại > 0, < 0 hoặc == 0.
* Mã giả:
*   1. Nhập số dòng n, số cột m và ma trận số thực A[n, m]
*   2. Duyệt i từ 0 đến n-1, j từ 0 đến m-1:
*        Nếu ở biên:
*            Nếu A[i, j] > 0 -> demDuong++
*            Nếu A[i, j] < 0 -> demAm++
*            Nếu A[i, j] == 0 -> demKhong++
*   3. In kết quả đếm
*/
using System;

namespace LTCsharp.Buoi12
{
    class DemSoTrenBienMang2C
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int n, m;
            int demDuong = 0, demAm = 0, demKhong = 0;

            // Nhập kích thước
            Console.Write("Nhap so dong n: ");
            n = int.Parse(Console.ReadLine());
            Console.Write("Nhap so cot m: ");
            m = int.Parse(Console.ReadLine());

            double[,] A = new double[n, m];

            // Nhập dữ liệu ma trận
            Console.WriteLine("Nhap ma tran A:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write("A[{0},{1}] = ", i, j);
                    A[i, j] = double.Parse(Console.ReadLine());
                }
            }

            // Xử lý
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == 0 || i == n - 1 || j == 0 || j == m - 1)
                    {
                        if (A[i, j] > 0)
                            demDuong++;
                        else if (A[i, j] < 0)
                            demAm++;
                        else
                            demKhong++;
                    }
                }
            }

            // Xuất dữ liệu
            Console.WriteLine("Tren duong bien co {0} so duong, {1} so am va {2} so khong.", demDuong, demAm, demKhong);

            // Dừng màn hình chờ phím
            Console.Read();
        }
    }
}