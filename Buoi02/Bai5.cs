/*
* CHƯƠNG TRÌNH TÍNH HAI CHỮ SỐ CUỐI CÙNG CỦA n^278
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 15/09/2026
*
* Phát biểu đề bài: Nhập vào một số nguyên n. Hãy tính toán hai chữ số cuối cùng của n^278.
* Ý tưởng: 
*          - Hai chữ số cuối cùng của một số chính là số dư khi chia số đó cho 100 (tức là tính n^278 % 100).
*          - Để tính lũy thừa lớn n^278 một cách hiệu quả và tránh tràn số, ta sử dụng thuật toán lũy thừa nhị phân (Binary Exponentiation) kết hợp phép đồng dư (mod 100 ở từng bước nhân).
* Mã giả:
*   1. Nhập n
*   2. Khởi tạo ketQua = 1, coSo = n % 100, soMu = 278
*   3. Lặp trong khi soMu > 0:
*        - Nếu soMu lẻ: ketQua = (ketQua * coSo) % 100
*        - coSo = (coSo * coSo) % 100
*        - soMu = soMu / 2
*   4. In "n^278 co 2 chu so cuối cùng la {ketQua:D2}."
*/

using System;

namespace LTCsharp.Buoi01
{
    class HaiChuSoCuoi
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            long n;
            long ketQua = 1;
            long coSo;
            long soMu = 278;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap so nguyen n: ");
            n = long.Parse(Console.ReadLine());

            // Xử lý tính n^278 % 100 bằng thuật toán lũy thừa nhị phân
            coSo = n % 100;
            if (coSo < 0) coSo += 100; // Xử lý trường hợp n âm nếu có

            long muTam = soMu;
            while (muTam > 0)
            {
                if (muTam % 2 == 1)
                {
                    ketQua = (ketQua * coSo) % 100;
                }
                coSo = (coSo * coSo) % 100;
                muTam /= 2;
            }

            // Xuất dữ liệu (định dạng :D2 để luôn hiển thị đủ 2 chữ số, ví dụ: 05 thay vì 5)
            Console.WriteLine("{0}^278 co 2 chu so cuối cung la {1:D2}.", n, ketQua);

            // Dừng màn hình
            Console.Read();
        }
    }
}