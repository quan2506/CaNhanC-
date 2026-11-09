/*
* CHƯƠNG TRÌNH TÍNH TỔNG CÁC PHẦN TỬ CỰC TRỊ TRONG DÃY SỐ
* Tác giả : Đoàn Phụng Lan Uyên 
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho dãy số thực có n phần tử (n <= 500). Hãy tính tổng các phần tử cực trị
*                   có trong dãy số. Biết một phần tử là cực trị khi lớn hơn hoặc nhỏ hơn các phần tử xung quanh nó.
* Ý tưởng: 
*   - Phần tử đầu (i = 0): so sánh với a[1].
*   - Phần tử cuối (i = n - 1): so sánh với a[n - 2].
*   - Các phần tử giữa (0 < i < n - 1): so sánh với cả a[i - 1] và a[i + 1].
* Mã giả:
*   1. Nhập n và mảng số thực a[n]
*   2. Lặp i từ 0 đến n - 1:
*        Nếu a[i] là cực đại hoặc cực tiểu so với lân cận -> tong += a[i]
*   3. Xuất tổng
*/
using System;

namespace LTCsharp.Buoi10
{
    class TrungBinhCongCucTri
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int n;
            double tongCucTri = 0;

            // Nhập dữ liệu
            Console.Write("Nhap so phan tu n: ");
            n = int.Parse(Console.ReadLine());

            double[] a = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap a[{0}]: ", i);
                a[i] = double.Parse(Console.ReadLine());
            }

            // Xử lý tìm và tính tổng cực trị
            if (n == 1)
            {
                tongCucTri = a[0];
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    bool isCucTri = false;

                    if (i == 0)
                    {
                        if (a[0] != a[1]) isCucTri = true;
                    }
                    else if (i == n - 1)
                    {
                        if (a[n - 1] != a[n - 2]) isCucTri = true;
                    }
                    else
                    {
                        if ((a[i] > a[i - 1] && a[i] > a[i + 1]) || (a[i] < a[i - 1] && a[i] < a[i + 1]))
                        {
                            isCucTri = true;
                        }
                    }

                    if (isCucTri)
                    {
                        tongCucTri += a[i];
                    }
                }
            }

            // Xuất kết quả
            Console.WriteLine("Tong cac phan tu cuc tri co trong day so: {0}", tongCucTri);

            // Dừng màn hình
            Console.Read();
        }
    }
}