/*
* CHƯƠNG TRÌNH GIẢI PHƯƠNG TRÌNH BẬC 2: AX^2 + BX + C = 0
* Tác giả : Nguyễn Trường Thành
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập 3 số thực a, b, c. Hãy tìm nghiệm của phương trình bậc 2: ax^2 + bx + c = 0.
* Ý tưởng:
*   - Nếu a == 0: trở thành phương trình bậc 1 bx + c = 0.
*   - Nếu a != 0: tính biệt thức delta = b^2 - 4ac:
*       + delta < 0: vô nghiệm.
*       + delta == 0: nghiệm kép x = -b / (2a).
*       + delta > 0: 2 nghiệm phân biệt x1, x2.
* Mã giả:
*   1. Nhập a, b, c
*   2. Biện luận nghiệm theo delta
*   3. Xuất nghiệm tương ứng
*/
using System;

namespace LTCsharp.Buoi03
{
    class PhuongTrinhBac2
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            double a, b, c;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap he so a, b, c: ");
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            a = double.Parse(input[0]);
            b = double.Parse(input[1]);
            c = double.Parse(input[2]);

            // Xử lý và xuất kết quả
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c == 0)
                        Console.WriteLine("Phuong trinh co vo so nghiem.");
                    else
                        Console.WriteLine("Phuong trinh vo nghiem.");
                }
                else
                {
                    double x = -c / b;
                    Console.WriteLine("Phuong trinh bac nhat co 1 nghiem: x = {0:0.00}", x);
                }
            }
            else
            {
                double delta = b * b - 4 * a * c;

                if (delta < 0)
                {
                    Console.WriteLine("Phuong trinh bac 2 {0}x^2 + {1}x + {2} = 0 vo nghiem.", a, b, c);
                }
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    Console.WriteLine("Phuong trinh bac 2 {0}x^2 + {1}x + {2} = 0 co nghiem kep: x = {3:0.00}", a, b, c, x);
                }
                else
                {
                    double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                    Console.WriteLine("Phuong trinh bac 2 {0}x^2 + {1}x + {2} = 0 co: 2 nghiem, x1 = {3:0.00}, x2 = {4:0.00}", a, b, c, x1, x2);
                }
            }

            // Dừng màn hình
            Console.Read();
        }
    }
}