/*
* CHƯƠNG TRÌNH XỬ LÝ CÁC CHỮ SỐ CỦA MỘT SỐ NGUYÊN
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập số nguyên n. Hãy (a) cho biết chữ số thứ k (tính từ trái sang); 
*                   (b) tổng các chữ số lẻ; (c) tìm chữ số lẻ nhỏ nhất và lớn nhất.
* Ý tưởng: Đưa số nguyên n về dạng chuỗi để dễ dàng truy xuất chữ số thứ k (vị trí k tính từ 1).
*          Duyệt từng ký tự số để tính tổng chữ số lẻ và tìm min/max các chữ số lẻ.
* Mã giả:
*   1. Nhập n (chuỗi hoặc số) và k
*   2. ChuSoThuK = s[k - 1]
*   3. Duyệt từng chữ số: nếu là số lẻ -> cộng tổng, cập nhật min, max
*   4. In kết quả theo mẫu
*/
using System;

namespace LTCsharp.Buoi06
{
    class XuLyChuSo1
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            string nStr;
            int k;
            int tongLe = 0;
            int minLe = 10, maxLe = -1;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap so nguyen n: ");
            nStr = Console.ReadLine();
            Console.Write("Moi ban nhap vi tri k: ");
            k = int.Parse(Console.ReadLine());

            // (a) Chữ số thứ k (tính từ trái sang, vị trí 1-based)
            char chuSoK = nStr[k - 1];

            // (b) và (c) Xử lý các chữ số lẻ
            for (int i = 0; i < nStr.Length; i++)
            {
                if (char.IsDigit(nStr[i]))
                {
                    int val = nStr[i] - '0';
                    if (val % 2 != 0)
                    {
                        tongLe += val;
                        if (val < minLe) minLe = val;
                        if (val > maxLe) maxLe = val;
                    }
                }
            }

            // Xuất dữ liệu
            Console.WriteLine("Chu so o vi tri {0} (tinh tu trai) cua {1} la {2}.", k, nStr, chuSoK);
            Console.WriteLine("Tong cac chu so le cua {0} la {1}.", nStr, tongLe);
            if (maxLe != -1)
            {
                Console.WriteLine("{0} co chu so le nho nhat la {1} va lon nhat la {2}.", nStr, minLe, maxLe);
            }
            else
            {
                Console.WriteLine("{0} khong co chu so le.", nStr);
            }

            // Dừng màn hình
            Console.Read();
        }
    }
}