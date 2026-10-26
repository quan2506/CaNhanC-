/*
* CHƯƠNG TRÌNH RÚT GỌN PHÂN SỐ DÙNG HÀM ƯỚC CHUNG LỚN NHẤT
* Tác giả : Bùi Minh Quang
* Ngày viết: 08/09/2026
*
* Phát biểu đề bài: Nhập vào tử số và mẫu số của một phân số. Hãy rút gọn phân số đã nhập.
* Ý tưởng: Xây dựng hàm tìm ước chung lớn nhất UCLN(a, b) bằng thuật toán Euclid.
*          Chia cả tử số và mẫu số cho UCLN để được phân số tối giản.
* Mã giả:
*   1. Viết hàm TimUCLN(a, b).
*   2. Nhập tuSo, mauSo.
*   3. ucln = TimUCLN(tuSo, mauSo).
*   4. tuRutGon = tuSo / ucln, mauRutGon = mauSo / ucln.
*   5. In phân số rút gọn.
*/
using System;

namespace LTCsharp.Buoi08
{
    class RutGonPhanSo
    {
        // Hàm tìm ước chung lớn nhất của hai số
        static int TimUCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (b != 0)
            {
                int r = a % b;
                a = b;
                b = r;
            }
            return a;
        }

        public static void Main(string[] args)
        {
            // Khai báo biến
            int tuSo, mauSo;

            // Nhập dữ liệu
            Console.Write("Moi ban nhap tu so: ");
            tuSo = int.Parse(Console.ReadLine());
            Console.Write("Moi ban nhap mau so: ");
            mauSo = int.Parse(Console.ReadLine());

            // Xử lý rút gọn
            int ucln = TimUCLN(tuSo, mauSo);
            int tuRutGon = tuSo / ucln;
            int mauRutGon = mauSo / ucln;

            // Đưa dấu âm lên tử nếu mẫu số âm
            if (mauRutGon < 0)
            {
                tuRutGon = -tuRutGon;
                mauRutGon = -mauRutGon;
            }

            // Xuất dữ liệu
            Console.WriteLine("Phan so {0}/{1} duoc rut gon thanh {2}/{3}.", tuSo, mauSo, tuRutGon, mauRutGon);

            // Dừng màn hình
            Console.Read();
        }
    }
}