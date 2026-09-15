/*
* CHƯƠNG TRÌNH TÍNH DIỆN TÍCH VÀ CHU VI HÌNH TRÒN
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập vào bán kính R của một hình tròn. Hãy tính diện tích và chu vi hình tròn 
*                   đó theo công thức: S = 3.14 * R^2, P = 2 * 3.14 * R. In kết quả với 1 số lẻ thập phân.
* Ý tưởng: Nhập số thực R, áp dụng trực tiếp 2 công thức tính S và P, xuất kết quả định dạng 0.0.
* Mã giả:
*   1. Nhập bán kính R
*   2. dienTich = 3.14 * R * R
*   3. chuVi = 2 * 3.14 * R
*   4. In "Dien tich S = ..." và "Chu vi P = ..."
*/
using System;

namespace LTCsharp.Buoi02
{
    class HinhTron
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            double r;
            double s, p;

            // Nhập dữ liệu
            Console.Write("Nhap ban kinh R: ");
            r = double.Parse(Console.ReadLine());

            // Xử lý theo công thức đề bài
            s = 3.14 * r * r;
            p = 2 * 3.14 * r;

            // Xuất dữ liệu với 1 chữ số thập phân
            Console.WriteLine("Dien tich S = {0:0.0}", s);
            Console.WriteLine("Chu vi P = {0:0.0}", p);

            // Dừng màn hình chờ phím
            Console.Read();
        }
    }
}