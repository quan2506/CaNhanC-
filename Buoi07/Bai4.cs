/*
* CHƯƠNG TRÌNH TÌM NGÀY ĐỨNG TRƯỚC CỦA MỘT NGÀY CHO TRƯỚC
* Tác giả : Bùi Minh Quang
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập vào ngày, tháng, năm. Hỏi ngày trước đó là ngày nào?
* Ý tưởng: 
*   - Nếu ngày > 1: ngày trước là ngày - 1.
*   - Nếu ngày == 1:
*       + Tháng == 1: lùi về ngày 31 tháng 12 của năm trước (năm - 1).
*       + Tháng > 1: lùi về tháng - 1 và lấy số ngày tối đa của tháng đó (xét năm nhuận cho tháng 2).
* Mã giả:
*   1. Nhập ngày, tháng, năm
*   2. Tính toán ngày, tháng, năm của ngày hôm trước
*   3. Xuất kết quả
*/
using System;

namespace LTCsharp.Buoi07
{
    class NgayTruoc
    {
        static bool LaNamNhuan(int nam)
        {
            return (nam % 400 == 0) || (nam % 4 == 0 && nam % 100 != 0);
        }

        static int LaySoNgayTrongThang(int thang, int nam)
        {
            switch (thang)
            {
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    return LaNamNhuan(nam) ? 29 : 28;
                default:
                    return 31;
            }
        }

        public static void Main(string[] args)
        {
            // Khai báo biến
            int ngay, thang, nam;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap ngay: ");
            ngay = int.Parse(Console.ReadLine());
            Console.Write("Moi ban nhap thang: ");
            thang = int.Parse(Console.ReadLine());
            Console.Write("Moi ban nhap nam: ");
            nam = int.Parse(Console.ReadLine());

            int prevNgay = ngay;
            int prevThang = thang;
            int prevNam = nam;

            // Xử lý
            if (ngay > 1)
            {
                prevNgay = ngay - 1;
            }
            else
            {
                if (thang == 1)
                {
                    prevNgay = 31;
                    prevThang = 12;
                    prevNam = nam - 1;
                }
                else
                {
                    prevThang = thang - 1;
                    prevNgay = LaySoNgayTrongThang(prevThang, nam);
                }
            }

            // Xuất dữ liệu
            Console.WriteLine("Ngay truoc ngay {0}/{1}/{2} la ngay {3}/{4}/{5}.", ngay, thang, nam, prevNgay, prevThang, prevNam);

            // Dừng màn hình
            Console.Read();
        }
    }
}