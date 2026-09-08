# BẢNG TEST CASE - BUỔI 01
**Tác giả:** Nguyễn Thái Quân  
**Môn:** Lập trình C#

---

## 1. Bài 1: TongDoan (Tính tổng đoạn [a, b])
| STT | Trường hợp kiểm thử | Dữ liệu vào (Input) | Kết quả mong đợi (Output) |
| :---: | :--- | :--- | :--- |
| 1 | Mẫu đề bài | `3 5` | `Tong cua cac so trong doan[3, 5] la 12.` |
| 2 | Đoạn có số âm | `-2 3` | `Tong cua cac so trong doan[-2, 3] la 3.` |
| 3 | Hai số bằng nhau ($a = b$) | `5 5` | `Tong cua cac so trong doan[5, 5] la 5.` |

---

## 2. Bài 2: LuyThuaNhanh1 (Tính $a^2, a^5, a^{17}$ qua 6 phép nhân)
| STT | Trường hợp kiểm thử | Dữ liệu vào (Input) | Kết quả mong đợi (Output) |
| :---: | :--- | :--- | :--- |
| 1 | Số nguyên dương | `2` | `Ket qua: 2^2=4.00, 2^5=32.00, 2^17=131072.00.` |
| 2 | Số thực thập phân | `1.5` | `Ket qua: 1.5^2=2.25, 1.5^5=7.59, 1.5^17=985.26.` |
| 3 | Số âm | `-1` | `Ket qua: -1^2=1.00, -1^5=-1.00, -1^17=-1.00.` |

---

## 3. Bài 3: BieuThucNhanh1 (Lược đồ Horner)
| STT | Trường hợp kiểm thử | Dữ liệu vào (Input) | Kết quả mong đợi (Output) |
| :---: | :--- | :--- | :--- |
| 1 | Test đề bài mẫu ($x = 3$) | `3` | `f(3) = -74.00` |
| 2 | Trường hợp $x = 0$ | `0` | `f(0) = 1.00` |
| 3 | Trường hợp $x$ âm ($x = -1$) | `-1` | `f(-1) = 6.00` |

---

## 4. Bài 4: TimQui (Tìm quý của tháng)
| STT | Trường hợp kiểm thử | Dữ liệu vào (Input) | Kết quả mong đợi (Output) |
| :---: | :--- | :--- | :--- |
| 1 | Tháng thuộc Quý 1 | `3` | `Thang 3 thuoc qui 1.` |
| 2 | Tháng cuối năm thuộc Quý 4 | `11` | `Thang 11 thuoc qui 4.` |
| 3 | Tháng ngoài phạm vi [1, 12] | `15` | `Thang nhap vao khong hop le!` |

---

## 5. Bài 5: DienTichTamGiac (Công thức Heron)
| STT | Trường hợp kiểm thử | Dữ liệu vào (Input) | Kết quả mong đợi (Output) |
| :---: | :--- | :--- | :--- |
| 1 | Mẫu đề bài ($a=2, b=4, c=3$) | `2`<br>`4`<br>`3` | `Dien tich tam giac S = 2.90` |
| 2 | Tam giác vuông 3-4-5 | `3`<br>`4`<br>`5` | `Dien tich tam giac S = 6.00` |
| 3 | Tam giác đều cạnh 6 | `6`<br>`6`<br>`6` | `Dien tich tam giac S = 15.59` |

---

## 6. Bài 6: TinhMu (Tính $a^n$)
| STT | Trường hợp kiểm thử | Dữ liệu vào (Input) | Kết quả mong đợi (Output) |
| :---: | :--- | :--- | :--- |
| 1 | Mẫu đề bài ($a=2, n=4$) | `2`<br>`4` | `Ket qua 2^4 = 16` |
| 2 | Số mũ bằng 0 ($a^0$) | `5`<br>`0` | `Ket qua 5^0 = 1` |
| 3 | Số mũ âm ($a^{-n}$) | `2`<br>`-3` | `Ket qua 2^-3 = 0.125` |