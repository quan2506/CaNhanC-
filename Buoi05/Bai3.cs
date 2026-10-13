/*
* CHƯƠNG TRÌNH TÍNH TỔNG PHÂN SỐ VỚI ĐỘ SAI SỐ EPSILON
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập số thực a và độ sai số epsilon (<= 0.1). Hãy tính:
*                   S = 1/a + 1/(a+1) + ... + 1/(a+n) cho đến khi 1/(a+n) < epsilon.
* Ý tưởng: Dùng vòng lặp while/for tăng n bắt đầu từ 0. Tính giá trị hạng tử term = 1.0 / (a + n).
*          Cộng term vào S cho đến khi term < epsilon thì dừng lại.
* Mã giả:
*   1. Nhập a và epsilon (epsilon <= 0.1)
*   2. S = 0, n = 0
*   3. Lặp:
*        term = 1.0 / (a + n)
*        Nếu term < epsilon -> break
*        S += term
*        n++
*   4. In kết quả S
*/
using System;

namespace LTCsharp.Buoi05
{
    class TongPhanSoSaiSo
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            double a, epsilon;
            double s = 0.0;
            int n = 0;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap so a: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Moi ban nhap sai so epsilon (<=0.1): ");
            epsilon = double.Parse(Console.ReadLine());

            // Xử lý
            while (true)
            {
                double hangTu = 1.0 / (a + n);
                if (hangTu < epsilon)
                {
                    break;
                }
                s += hangTu;
                n++;
            }

            // Xuất dữ liệu
            Console.WriteLine("Gia tri cua bieu thuc S(a = {0}, epsilon = {1}) = {2:0.0000}", a, epsilon, s);

            // Dừng màn hình
            Console.Read();
        }
    }
}