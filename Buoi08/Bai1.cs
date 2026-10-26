/*
* CHƯƠNG TRÌNH TÍNH TỔ HỢP CHẬP K CỦA N DÙNG HÀM GIAI THỪA
* Tác giả : Bùi Minh Quang
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập vào số nguyên dương n, k với k <= n. Hãy tính C(k, n) = n! / (k! * (n - k)!).
* Ý tưởng: Xây dựng một hàm GiaiThua(m) trả về giá trị m!. 
*          Sau đó áp dụng công thức: Ckn = GiaiThua(n) / (GiaiThua(k) * GiaiThua(n - k)).
* Mã giả:
*   1. Định nghĩa hàm GiaiThua(m): tích từ 1 đến m.
*   2. Nhập k và n (k <= n).
*   3. ckn = GiaiThua(n) / (GiaiThua(k) * GiaiThua(n - k))
*   4. In kết quả C(k, n) = ckn
*/
using System;

namespace LTCsharp.Buoi08
{
    class GiaiThua
    {
        // Hàm tính giai thừa của một số nguyên không âm
        static long TinhGiaiThua(int m)
        {
            long gt = 1;
            for (int i = 1; i <= m; i++)
            {
                gt *= i;
            }
            return gt;
        }

        public static void Main(string[] args)
        {
            // Khai báo biến
            int k, n;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap k: ");
            k = int.Parse(Console.ReadLine());
            Console.Write("Moi ban nhap n: ");
            n = int.Parse(Console.ReadLine());

            // Xử lý tính tổ hợp
            long ckn = TinhGiaiThua(n) / (TinhGiaiThua(k) * TinhGiaiThua(n - k));

            // Xuất dữ liệu
            Console.WriteLine("C({0}, {1}) = {2}", k, n, ckn);

            // Dừng màn hình
            Console.Read();
        }
    }
}