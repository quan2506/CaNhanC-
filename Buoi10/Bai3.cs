/*
* CHƯƠNG TRÌNH KIỂM TRA DÃY ĐAN DẤU
* Tác giả : Đoàn Phụng Lan Uyên 
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho dãy số thực có n phần tử (n <= 500). Hãy xác định dãy có tính chất
*                   các phần tử kề nhau là trái dấu nhau hay không?
* Ý tưởng: Dãy đan dấu khi mọi cặp liên tiếp a[i] và a[i+1] đều trái dấu (tích < 0). 
*          Chỉ cần tồn tại một cặp có tích >= 0 thì kết luận ngay không đan dấu.
* Mã giả:
*   1. Nhập dãy a có n phần tử
*   2. isDanDau = true
*   3. Lặp i từ 0 đến n - 2:
*        Nếu a[i] * a[i + 1] >= 0 -> isDanDau = false, break
*   4. In thông báo dãy đan dấu hoặc không
*/
using System;

namespace LTCsharp.Buoi10
{
    class DayDanDau
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int n;
            bool isDanDau = true;

            // Nhập dữ liệu
            Console.Write("Nhap so phan tu n: ");
            n = int.Parse(Console.ReadLine());

            double[] a = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap a[{0}]: ", i);
                a[i] = double.Parse(Console.ReadLine());
            }

            // Xử lý kiểm tra
            for (int i = 0; i < n - 1; i++)
            {
                if (a[i] * a[i + 1] >= 0)
                {
                    isDanDau = false;
                    break;
                }
            }

            // Xuất kết quả
            if (isDanDau)
            {
                Console.WriteLine("Day so tren la day dan dau.");
            }
            else
            {
                Console.WriteLine("Day so tren khong phai la day dan dau.");
            }

            // Dừng màn hình
            Console.Read();
        }
    }
}