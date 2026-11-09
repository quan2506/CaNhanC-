/*
* CHƯƠNG TRÌNH XÁC ĐỊNH SỐ LƯỢNG CÁC PHẦN TỬ KỀ NHAU TRÁI DẤU
* Tác giả : Đoàn Phụng Lan Uyên 
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho dãy số thực có n phần tử (n <= 500). Hãy xác định số lượng 
*                   các phần tử kề nhau mà cả hai đều trái dấu.
* Ý tưởng: Phần tử a[i] được coi là kề trái dấu nếu nó trái dấu với phần tử trước nó (a[i-1]) 
*          HOẶC trái dấu với phần tử sau nó (a[i+1]). Hai số x, y trái dấu khi x * y < 0.
* Mã giả:
*   1. Nhập n và dãy số thực a[n]
*   2. Đếm số phần tử thỏa mãn:
*        - i = 0: a[0] * a[1] < 0
*        - i = n - 1: a[n - 1] * a[n - 2] < 0
*        - 0 < i < n - 1: (a[i] * a[i - 1] < 0) hoặc (a[i] * a[i + 1] < 0)
*   3. Xuất kết quả
*/
using System;

namespace LTCsharp.Buoi10
{
    class KeNhauTraiDau
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int n;
            int dem = 0;

            // Nhập dữ liệu
            Console.Write("Nhap so phan tu n: ");
            n = int.Parse(Console.ReadLine());

            double[] a = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap a[{0}]: ", i);
                a[i] = double.Parse(Console.ReadLine());
            }

            // Xử lý đếm phần tử
            if (n >= 2)
            {
                for (int i = 0; i < n; i++)
                {
                    bool thoaMan = false;

                    if (i == 0)
                    {
                        if (a[0] * a[1] < 0) thoaMan = true;
                    }
                    else if (i == n - 1)
                    {
                        if (a[n - 1] * a[n - 2] < 0) thoaMan = true;
                    }
                    else
                    {
                        if (a[i] * a[i - 1] < 0 || a[i] * a[i + 1] < 0)
                        {
                            thoaMan = true;
                        }
                    }

                    if (thoaMan) dem++;
                }
            }

            // Xuất kết quả
            Console.WriteLine("So luong cac phan tu ke nhau ma trai dau: {0}", dem);

            // Dừng màn hình
            Console.Read();
        }
    }
}