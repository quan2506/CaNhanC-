/*
* CHƯƠNG TRÌNH LIỆT KÊ DÒNG TẠO THÀNH DÃY TĂNG
* Tác giả : Lê Ánh Xuân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho ma trận A chứa các số nguyên có n dòng và m cột (1 <= n, m <= 100).
*                   Hãy liệt kê các dòng mà các giá trị tạo thành dãy tăng.
* Ý tưởng: Duyệt qua từng dòng i. Với mỗi dòng, kiểm tra nếu tồn tại A[i, j] >= A[i, j+1] 
*          thì dòng đó không tăng. Ngược lại, in chỉ số dòng i ra màn hình.
* Mã giả:
*   1. Nhập ma trận nguyên A[n, m]
*   2. Lặp i từ 0 đến n-1:
*        isTang = true
*        Lặp j từ 0 đến m-2:
*            Nếu A[i, j] >= A[i, j + 1] -> isTang = false, break
*        Nếu isTang == true -> ghi nhận dòng i
*   3. Xuất danh sách chỉ số các dòng thỏa mãn
*/
using System;

namespace LTCsharp.Buoi12
{
    class DongTangDan
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int n, m;

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

            // Xử lý và xuất kết quả
            Console.Write("Cac dong tao thanh day tang: ");
            for (int i = 0; i < n; i++)
            {
                bool isTang = true;

                for (int j = 0; j < m - 1; j++)
                {
                    if (A[i, j] >= A[i, j + 1])
                    {
                        isTang = false;
                        break;
                    }
                }

                if (isTang)
                {
                    Console.Write("{0} ", i);
                }
            }
            Console.WriteLine();

            // Dừng màn hình chờ phím
            Console.Read();
        }
    }
}