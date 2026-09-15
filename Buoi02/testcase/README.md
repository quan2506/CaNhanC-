# BẢNG TEST CASE - BUỔI 02
**Tác giả:** Nguyễn Thái Quân  
**Môn:** Lập trình C#  

---

## 1. Bài 1: InNhan (In nhãn thông tin sinh viên)
| STT | Trường hợp kiểm thử | Dữ liệu vào (Input) | Kết quả mong đợi (Output) |
| :---: | :--- | :--- | :--- |r>`* Truong: Dai Hoc HUFLIT   *`<br>`* Khoa: CNTT               *`<br>`* Ho ten: Nguyen Truong Thanh *`<br>`****************************` |

| 1 | Mẫu chuẩn thông tin | Không có | `****************************`<b
---

## 2. Bài 2: HinhTron (Tính diện tích và chu vi hình tròn)
| STT | Trường hợp kiểm thử | Dữ liệu vào (Input) | Kết quả mong đợi (Output) |
| :---: | :--- | :--- | :--- |
| 1 | Bán kính số nguyên ($R = 2$) | `2` | `Dien tich S = 12.6`<br>`Chu vi P = 12.6` |
| 2 | Bán kính số thập phân ($R = 3.5$) | `3.5` | `Dien tich S = 38.5`<br>`Chu vi P = 22.0` |
| 3 | Bán kính bằng 0 (Biên) | `0` | `Dien tich S = 0.0`<br>`Chu vi P = 0.0` |

---

## 3. Bài 3: DoiSangGiay (Quy đổi giờ, phút, giây sang tổng số giây)
| STT | Trường hợp kiểm thử | Dữ liệu vào (Input) | Kết quả mong đợi (Output) |
| :---: | :--- | :--- | :--- |
| 1 | Giờ, phút, giây đầy đủ | `1`<br>`15`<br>`30` | `Tong so giay cua 1:15:30 la 4530 giay` |
| 2 | Chỉ có giây nhỏ | `0`<br>`0`<br>`45` | `Tong so giay cua 0:0:45 la 45 giay` |
| 3 | Thời gian lớn hơn một ngày | `24`<br>`59`<br>`59` | `Tong so giay cua 24:59:59 la 89999 giay` |

---

## 4. Bài 4: DoiSangGioPhutGiay (Quy đổi tổng số giây sang dạng giờ:phút:giây)
| STT | Trường hợp kiểm thử | Dữ liệu vào (Input) | Kết quả mong đợi (Output) |
| :---: | :--- | :--- | :--- |
| 1 | Số giây tương ứng 1 giờ 15 phút 30 giây | `4530` | `4530 giay co dang 1:15:30` |
| 2 | Số giây dưới 1 phút | `45` | `45 giay co dang 0:0:45` |
| 3 | Số giây lớn (24 giờ 59 phút 59 giây) | `89999` | `89999 giay co dang 24:59:59` |

---

## 5. Bài 5: HaiChuSoCuoi (Tính hai chữ số cuối cùng của $n^{278}$)
| STT | Trường hợp kiểm thử | Dữ liệu vào (Input) | Kết quả mong đợi (Output) |
| :---: | :--- | :--- | :--- |
| 1 | Mẫu cơ bản với $n = 2$ | `2` | `2^278 co 2 chu so cuối cung la 96.` |
| 2 | Cơ số nhỏ với $n = 3$ | `3` | `3^278 co 2 chu so cuối cung la 49.` |
| 3 | Cơ số có 2 chữ số với $n = 12$ | `12` | `12^278 co 2 chu so cuối cung la 84.` |