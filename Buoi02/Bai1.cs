/*
* CHƯƠNG TRÌNH IN NHÃN THÔNG TIN SINH VIÊN
* Tác giả : Nguyễn Thái Quân
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Viết chương trình in ra nhãn gồm nhiều dòng chứa thông tin trường, khoa, họ tên.
* Ý tưởng: Dùng Console.WriteLine để in các dòng ký tự trang trí và thông tin theo đúng định dạng mẫu.
* Mã giả:
*   1. In dòng viền hoa thị '****************************'
*   2. In "* Truong: Dai Hoc HUFLIT *"
*   3. In "* Khoa: CNTT *"
*   4. In "* Ho ten: Nguyễn Trường Thành *"
*   5. In dòng viền hoa thị đóng
*/
using System;

namespace LTCsharp.Buoi02
{
    class InNhan
    {
        public static void Main(string[] args)
        {
            // Xuất dữ liệu trực tiếp theo khung mẫu
            Console.WriteLine("****************************");
            Console.WriteLine("* Truong: Dai Hoc HUFLIT   *");
            Console.WriteLine("* Khoa: CNTT               *");
            Console.WriteLine("* Ho ten: Nguyen Truong Thanh *");
            Console.WriteLine("****************************");

            // Dừng màn hình chờ phím
            Console.Read();
        }
    }
}