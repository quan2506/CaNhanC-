/*
* CHƯƠNG TRÌNH KIỂM TRA SỐ HOÀN HẢO
* Tác giả : Bùi Minh Quang
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho số tự nhiên n. Hãy kiểm tra n có là số hoàn hảo.
*                   (Ví dụ: 6 = 1 + 2 + 3 là số hoàn hảo).
* Ý tưởng: Duyệt tìm các ước số nhỏ hơn n (từ 1 đến n / 2), cộng dồn và lưu chuỗi biểu thức.
* Mã giả:
*   1. Nhập n
*   2. Lặp i từ 1 đến n / 2: nếu n % i == 0 thì cộng vào tongUoc và lưu chuỗi
*   3. Nếu tongUoc == n -> In "n = 1 + ... la so hoan hao."
*      Ngược lại -> In "n khong la so hoan hao."
*/
using System;

namespace LTCsharp.Buoi07
{
    class KiemTraSoHoanHao
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int n;
            int tongUoc = 0;
            string chuoiUoc = "";

            // Nhập dữ liệu
            Console.Write("Moi ban nhap n: ");
            n = int.Parse(Console.ReadLine());

            // Xử lý tìm ước
            for (int i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    tongUoc += i;
                    if (chuoiUoc == "")
                    {
                        chuoiUoc += i;
                    }
                    else
                    {
                        chuoiUoc += " + " + i;
                    }
                }
            }

            // Xuất dữ liệu
            if (tongUoc == n && n > 0)
            {
                Console.WriteLine("{0} = {1} la so hoan hao.", n, chuoiUoc);
            }
            else
            {
                Console.WriteLine("{0} khong la so hoan hao.", n);
            }

            // Dừng màn hình
            Console.Read();
        }
    }
}