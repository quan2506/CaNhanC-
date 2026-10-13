/*
* CHƯƠNG TRÌNH PHÂN TÍCH THỪA SỐ NGUYÊN TỐ CẢI TIẾN
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập số nguyên n (n > 1). Hãy phân tích n thành thừa số nguyên tố dạng a^x x b^y...
* Ý tưởng: Duyệt d từ 2, đếm số lần n chia hết cho d (số mũ). Nếu số mũ > 0, in dạng d^mu. 
*          Sau đó nối các thừa số bằng ký tự 'x'.
* Mã giả:
*   1. Nhập n (n > 1)
*   2. Lặp d = 2, 3, ... đến khi d * d > n:
*        Đếm mu = 0
*        Khi n % d == 0: mu++, n /= d
*        Nếu mu > 0: in d^mu
*   3. Nếu n > 1 -> in phần thừa nguyên tố còn lại n^1
*/
using System;

namespace LTCsharp.Buoi06
{
    class PhanTichThuaSo1
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int n, tempN;
            string ketQua = "";

            // Nhập dữ liệu
            Console.Write("Moi ban nhap so nguyen n: ");
            n = int.Parse(Console.ReadLine());
            tempN = n;

            // Xử lý phân tích
            for (int d = 2; d * d <= tempN; d++)
            {
                if (tempN % d == 0)
                {
                    int mu = 0;
                    while (tempN % d == 0)
                    {
                        mu++;
                        tempN /= d;
                    }

                    string thauSo = (mu == 1) ? string.Format("{0}", d) : string.Format("{0}^{1}", d, mu);
                    if (ketQua == "")
                        ketQua += thauSo;
                    else
                        ketQua += " x " + thauSo;
                }
            }

            if (tempN > 1)
            {
                if (ketQua == "")
                    ketQua += tempN;
                else
                    ketQua += " x " + tempN;
            }

            // Xuất dữ liệu
            Console.WriteLine("{0} = {1}", n, ketQua);

            // Dừng màn hình
            Console.Read();
        }
    }
}