/*
* CHƯƠNG TRÌNH ĐẾM SỐ LẦN XUẤT HIỆN CỦA TỪNG CHỮ SỐ
* Tác giả : Bùi Minh Quang
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập vào số nguyên dương n. Hãy đếm số lần xuất hiện của từng chữ số.
* Ý tưởng: Viết hàm DemSoLanXuatHien(n, d) để đếm số lần chữ số d xuất hiện trong n bằng cách
*          lấy từng chữ số cuối (temp % 10) so sánh với d. Sau đó duyệt d từ 0 đến 9, nếu hàm trả về > 0 thì in ra.
* Mã giả:
*   1. Viết hàm DemSoLanXuatHien(n, d):
*        count = 0, temp = n
*        Lặp khi temp > 0:
*            Nếu temp % 10 == d -> count++
*            temp /= 10
*        Return count
*   2. Nhập số nguyên n.
*   3. Lặp d từ 0 đến 9:
*        k = DemSoLanXuatHien(n, d)
*        Nếu k > 0 -> in "Chu so d xuat hien k lan."
*/
using System;

namespace LTCsharp.Buoi08
{
    class DemChuSo
    {
        // Hàm đếm số lần xuất hiện của chữ số d trong số nguyên n
        static int DemSoLanXuatHien(long n, int d)
        {
            if (n == 0 && d == 0) return 1;

            int dem = 0;
            long temp = Math.Abs(n);

            while (temp > 0)
            {
                int chuSo = (int)(temp % 10);
                if (chuSo == d)
                {
                    dem++;
                }
                temp /= 10;
            }

            return dem;
        }

        public static void Main(string[] args)
        {
            // Khai báo biến
            long n;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap so nguyen n: ");
            n = long.Parse(Console.ReadLine());

            // Xử lý và xuất dữ liệu duyệt từ chữ số 0 đến 9
            for (int d = 0; d <= 9; d++)
            {
                int soLan = DemSoLanXuatHien(n, d);
                if (soLan > 0)
                {
                    Console.WriteLine("Chu so {0} xuat hien {1} lan.", d, soLan);
                }
            }

            // Dừng màn hình
            Console.Read();
        }
    }
}