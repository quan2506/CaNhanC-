/*
* CHƯƠNG TRÌNH TÌM ĐOẠN DÀI NHẤT CÓ TỔNG BẰNG K
* Tác giả : Đoàn Phụng Lan Uyên 
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho dãy số thực có n phần tử (n <= 500) và số k cho trước. 
*                   Hãy tìm đoạn [i, j] dài nhất trong dãy số có tổng bằng k (i <= j).
* Ý tưởng: Duyệt mọi cặp chỉ số (i, j) với 0 <= i <= j < n. Tính tổng các phần tử từ i đến j.
*          Nếu tổng xấp xỉ k và độ dài (j - i + 1) lớn hơn độ dài dài nhất từng tìm thấy thì cập nhật i, j.
* Mã giả:
*   1. Nhập n, dãy a[n] và giá trị k
*   2. bestI = -1, bestJ = -1, maxLen = 0
*   3. Lặp i từ 0 đến n - 1:
*        tong = 0
*        Lặp j từ i đến n - 1:
*            tong += a[j]
*            Nếu Math.Abs(tong - k) < 1e-9 và (j - i + 1) > maxLen:
*                maxLen = j - i + 1, bestI = i, bestJ = j
*   4. In đoạn con tìm được
*/
using System;

namespace LTCsharp.Buoi10
{
    class TimDoan
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int n;
            double k;
            int bestI = -1, bestJ = -1;
            int maxLen = 0;

            // Nhập dữ liệu
            Console.Write("Nhap so phan tu n: ");
            n = int.Parse(Console.ReadLine());

            double[] a = new double[n];
            for (int idx = 0; idx < n; idx++)
            {
                Console.Write("Nhap a[{0}]: ", idx);
                a[idx] = double.Parse(Console.ReadLine());
            }

            Console.Write("Moi ban nhap so k: ");
            k = double.Parse(Console.ReadLine());

            // Xử lý tìm đoạn dài nhất
            for (int i = 0; i < n; i++)
            {
                double tong = 0;
                for (int j = i; j < n; j++)
                {
                    tong += a[j];

                    // So sánh số thực với sai số nhỏ tránh lỗi dấu phẩy động
                    if (Math.Abs(tong - k) < 1e-6)
                    {
                        int doDai = j - i + 1;
                        if (doDai > maxLen)
                        {
                            maxLen = doDai;
                            bestI = i;
                            bestJ = j;
                        }
                    }
                }
            }

            // Xuất kết quả
            if (bestI != -1)
            {
                Console.Write("Doan [{0}, {1}] dai nhat co tong bang {2}: ", bestI, bestJ, k);
                for (int idx = bestI; idx <= bestJ; idx++)
                {
                    Console.Write("{0} ", a[idx]);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Khong co doan nao co tong bang {0}", k);
            }

            // Dừng màn hình
            Console.Read();
        }
    }
}