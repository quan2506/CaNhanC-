/*
* CHƯƠNG TRÌNH TÍNH NHANH A^2, A^5, A^17 CHỈ DÙNG 6 PHÉP NHÂN
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho số thực a. Hãy tính a^2, a^5 và a^17 chỉ dùng 6 phép nhân.
* Ý tưởng:
*   - Phép 1: a2 = a * a            (được a^2)
*   - Phép 2: a4 = a2 * a2          (được a^4)
*   - Phép 3: a5 = a4 * a           (được a^5)
*   - Phép 4: a8 = a4 * a4          (được a^8)
*   - Phép 5: a16 = a8 * a8         (được a^16)
*   - Phép 6: a17 = a16 * a         (được a^17)
* Mã giả:
*   1. Nhập số thực a
*   2. Thực hiện 6 phép nhân trung gian để lấy a2, a5, a17
*   3. In kết quả với định dạng 2 chữ số thập phân
*/
using System;

namespace LTCsharp.Buoi01
{
    class LuyThuaNhanh1
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            double a;
            double a2, a4, a5, a8, a16, a17;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap so thuc a: ");
            a = double.Parse(Console.ReadLine());

            // Xử lý (chính xác 6 phép nhân)
            a2 = a * a;       // Phép nhân 1
            a4 = a2 * a2;     // Phép nhân 2
            a5 = a4 * a;      // Phép nhân 3
            a8 = a4 * a4;     // Phép nhân 4
            a16 = a8 * a8;    // Phép nhân 5
            a17 = a16 * a;    // Phép nhân 6

            // Xuất dữ liệu
            Console.WriteLine("Ket qua: {0}^2={1:0.00}, {0}^5={2:0.00}, {0}^17={3:0.00}.", a, a2, a5, a17);

            // Dừng màn hình
            Console.Read();
        }
    }
}