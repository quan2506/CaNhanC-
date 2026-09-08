/*
* CHƯƠNG TRÌNH TÍNH DIỆN TÍCH TAM GIÁC THEO CÔNG THỨC HERON
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Cho 3 số thực a, b, c là độ dài 3 cạnh của một tam giác. 
*                   Hãy tính diện tích tam giác này theo công thức Heron: 
*                   S = sqrt(p * (p - a) * (p - b) * (p - c)) với p = (a + b + c) / 2.
*                   In kết quả với 2 số lẻ thập phân.
* Ý tưởng: Nhập 3 cạnh a, b, c. Tính nửa chu vi p, sau đó dùng Math.Sqrt để tính diện tích S.
* Mã giả:
*   1. Nhập a, b, c
*   2. p = (a + b + c) / 2
*   3. s = Math.Sqrt(p * (p - a) * (p - b) * (p - c))
*   4. In "Dien tich tam giac S = {s:0.00}"
*/
using System;

namespace LTCsharp.Buoi01
{
    class DienTichTamGiac
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            double a, b, c;
            double p, s;

            // Nhập dữ liệu
            Console.Write("Nhap do dai canh a: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Nhap do dai canh b: ");
            b = double.Parse(Console.ReadLine());
            Console.Write("Nhap do dai canh c: ");
            c = double.Parse(Console.ReadLine());

            // Xử lý theo công thức Heron
            p = (a + b + c) / 2.0;
            s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            // Xuất dữ liệu với 2 chữ số thập phân
            Console.WriteLine("Dien tich tam giac S = {0:0.00}", s);

            // Dừng màn hình chờ phím
            Console.Read();
        }
    }
}