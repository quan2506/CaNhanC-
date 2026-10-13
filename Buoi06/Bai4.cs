/*
* CHƯƠNG TRÌNH KIỂM TRA SỐ HOÀN HẢO
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Số tự nhiên n gọi là số hoàn hảo nếu tổng các ước tự nhiên của nó 
*                   không kể chính nó bằng n. Cho số tự nhiên n. Hãy kiểm tra n có là số hoàn hảo.
* Ý tưởng: Duyệt từ 1 đến n / 2 để tìm các ước số. Cộng dồn ước số và ghép chuỗi biểu thức.
*          So sánh tổng ước với chính nó.
* Mã giả:
*   1. Nhập n
*   2. tongUoc = 0, chuoiUoc = ""
*   3. Duyệt i từ 1 đến n / 2:
*        Nếu n % i == 0 -> tongUoc += i, nối i vào chuoiUoc
*   4. Nếu tongUoc == n -> In "n = ... la so hoan hao."
*      Ngược lại -> In "n khong la so hoan hao."
*/
using System;

namespace LTCsharp.Buoi06
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

            // Xử lý
            for (int i = 1; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    tongUoc += i;
                    if (chuoiUoc == "")
                        chuoiUoc += i;
                    else
                        chuoiUoc += " + " + i;
                }
            }

            // Xuất kết quả
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