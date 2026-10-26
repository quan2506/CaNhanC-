/*
* CHƯƠNG TRÌNH LIỆT KÊ CÁC SỐ HOÀN HẢO GIẢM DẦN TRONG ĐOẠN [1, N]
* Tác giả : Bùi Minh Quang
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập số nguyên dương n. Hãy liệt kê các số hoàn hảo trong đoạn [1, n] theo thứ tự giảm dần.
* Ý tưởng: Xây dựng hàm KiemTraHoanHao(x) kiểm tra xem tổng các ước số thực sự của x có bằng chính x hay không.
*          Duyệt x ngược từ n về 1, số nào là số hoàn hảo thì in ra màn hình.
* Mã giả:
*   1. Viết hàm KiemTraHoanHao(x): tính tổng ước số từ 1 đến x/2. Nếu sum == x và x > 1 return true.
*   2. Nhập n.
*   3. Lặp x từ n về 1: nếu KiemTraHoanHao(x) thì in x.
*/
using System;

namespace LTCsharp.Buoi08
{
    class LietKeSoHoanHao
    {
        // Hàm kiểm tra một số có phải số hoàn hảo hay không
        static bool KiemTraHoanHao(int x)
        {
            if (x <= 1) return false;

            int tongUoc = 0;
            for (int i = 1; i <= x / 2; i++)
            {
                if (x % i == 0)
                {
                    tongUoc += i;
                }
            }
            return tongUoc == x;
        }

        public static void Main(string[] args)
        {
            // Khai báo biến
            int n;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap so n: ");
            n = int.Parse(Console.ReadLine());

            // Xử lý và xuất dữ liệu
            Console.Write("Cac so hoan hao trong doan [1, {0}]: ", n);
            for (int i = n; i >= 1; i--)
            {
                if (KiemTraHoanHao(i))
                {
                    Console.Write("{0} ", i);
                }
            }
            Console.WriteLine();

            // Dừng màn hình
            Console.Read();
        }
    }
}