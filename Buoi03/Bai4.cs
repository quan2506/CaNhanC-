/*
* CHƯƠNG TRÌNH XUẤT TÊN GỌI TIẾNG ANH CỦA THÁNG
* Tác giả : Nguyễn Trường Thành
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Viết chương trình nhập vào tháng từ 1 đến 12. 
*                   Cho biết tên gọi tiếng Anh của tháng vừa nhập.
* Ý tưởng: Dùng cấu trúc switch-case để gán tên tiếng Anh tương ứng từ tháng 1 (January) đến tháng 12 (December).
* Mã giả:
*   1. Nhập thang
*   2. Switch(thang): gán tenThang tương ứng
*   3. In kết quả "Tieng anh cua thang {thang} la {tenThang}."
*/
using System;

namespace LTCsharp.Buoi03
{
    class ThangTiengAnh
    {
        public static void Main(string[] args)
        {
            // Khai báo biến
            int thang;
            string tenThang = "";

            // Nhập dữ liệu
            Console.Write("Moi ban nhap vao thang: ");
            thang = int.Parse(Console.ReadLine());

            // Xử lý
            switch (thang)
            {
                case 1: tenThang = "January"; break;
                case 2: tenThang = "February"; break;
                case 3: tenThang = "March"; break;
                case 4: tenThang = "April"; break;
                case 5: tenThang = "May"; break;
                case 6: tenThang = "June"; break;
                case 7: tenThang = "July"; break;
                case 8: tenThang = "August"; break;
                case 9: tenThang = "September"; break;
                case 10: tenThang = "October"; break;
                case 11: tenThang = "November"; break;
                case 12: tenThang = "December"; break;
                default:
                    tenThang = "";
                    break;
            }

            // Xuất dữ liệu
            if (tenThang != "")
            {
                Console.WriteLine("Tieng anh cua thang {0} la {1}.", thang, tenThang);
            }
            else
            {
                Console.WriteLine("Thang khong hop le! Vui long nhap tu 1 den 12.");
            }

            // Dừng màn hình
            Console.Read();
        }
    }
}