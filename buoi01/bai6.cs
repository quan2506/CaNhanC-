/*
* CHƯƠNG TRÌNH TÍNH LŨY THỪA A^N
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập số thực a và số nguyên n. Hãy tính a^n.
* Ý tưởng: Dùng hàm Math.Pow(a, n) để tính lũy thừa.
* Mã giả:
*   1. Nhập số thực a
*   2. Nhập số nguyên n
*   3. ketQua = Math.Pow(a, n)
*   4. In "Ket qua a^n = ketQua"
*/
using System;

namespace LTCsharp.Buoi01
{
    class TinhMu
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            double a;
            int n;
            double ketQua;

            // Nhập dữ liệu
            Console.Write("Nhap so thuc a: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Nhap so mu n: ");
            n = int.Parse(Console.ReadLine());

            // Xử lý tính lũy thừa
            ketQua = Math.Pow(a, n);

            // Xuất dữ liệu
            Console.WriteLine("Ket qua {0}^{1} = {2}", a, n, ketQua);

            // Dừng màn hình chờ phím
            Console.Read();
        }
    }
}