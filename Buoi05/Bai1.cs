/*
* CHƯƠNG TRÌNH TÍNH GIAI THỪA N!
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập vào số nguyên dương n (1 <= n <= 12). Hãy tính n! biết: n! = 1.2.3.4...n.
* Ý tưởng: Dùng vòng lặp for chạy từ 1 đến n, nhân dồn vào biến giaiThua và ghép chuỗi biểu thức để in theo mẫu.
* Mã giả:
*   1. Nhập n (1 <= n <= 12)
*   2. giaiThua = 1, bieuThuc = ""
*   3. Lặp i từ 1 đến n:
*        giaiThua *= i
*        nối i vào bieuThuc (ngăn cách bởi dấu '.')
*   4. In kết quả "n! = bieuThuc = giaiThua"
*/
using System;

namespace LTCsharp.Buoi05
{
    class GiaiThua
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int n;
            long giaiThua = 1;
            string chuoiPhepNhan = "";

            // Nhập dữ liệu
            Console.Write("Moi ban nhap so n: ");
            n = int.Parse(Console.ReadLine());

            // Xử lý
            for (int i = 1; i <= n; i++)
            {
                giaiThua *= i;
                if (i == 1)
                {
                    chuoiPhepNhan += i;
                }
                else
                {
                    chuoiPhepNhan += "." + i;
                }
            }

            // Xuất dữ liệu
            Console.WriteLine("{0}! = {1} = {2}.", n, chuoiPhepNhan, giaiThua);

            // Dừng màn hình
            Console.Read();
        }
    }
}