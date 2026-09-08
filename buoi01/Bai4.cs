/*
* CHƯƠNG TRÌNH XÁC ĐỊNH QUÝ CỦA MỘT THÁNG
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập vào tháng. Hãy cho biết tháng đó thuộc quí nào?
* Ý tưởng: Một năm có 4 quý, mỗi quý gồm 3 tháng:
*          - Quý 1: Tháng 1, 2, 3
*          - Quý 2: Tháng 4, 5, 6
*          - Quý 3: Tháng 7, 8, 9
*          - Quý 4: Tháng 10, 11, 12
*          Công thức tính nhanh: qui = (thang - 1) / 3 + 1.
* Mã giả:
*   1. Nhập thang (1 <= thang <= 12)
*   2. qui = (thang - 1) / 3 + 1
*   3. In "Thang {thang} thuoc qui {qui}."
*/
using System;

namespace LTCsharp.Buoi01
{
    class TimQui
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int thang;
            int qui;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap thang: ");
            thang = int.Parse(Console.ReadLine());

            // Xử lý
            if (thang >= 1 && thang <= 12)
            {
                qui = (thang - 1) / 3 + 1;
                // Xuất dữ liệu
                Console.WriteLine("Thang {0} thuoc qui {1}.", thang, qui);
            }
            else
            {
                Console.WriteLine("Thang nhap vao khong hop le!");
            }

            // Dừng màn hình
            Console.Read();
        }
    }
}