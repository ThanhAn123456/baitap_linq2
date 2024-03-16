namespace baitap_linq2
{
    class SINHVIEN
    {
        public int sinhVienID { get; set; }
        public string tenSinhVien { get; set; }
        public double diemTB { get; set; }
        public int khoaID { get; set; }
    }
    class KHOA
    {
        public int khoaID { get; set; }
        public string tenKhoa { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<SINHVIEN> danhSachSinhVien = new List<SINHVIEN>
            {
                new SINHVIEN { sinhVienID = 1, tenSinhVien = "SinhVien1", diemTB = 8.5, khoaID = 1 },
                new SINHVIEN { sinhVienID = 2, tenSinhVien = "SinhVien2", diemTB = 7.2, khoaID = 2 },
                new SINHVIEN { sinhVienID = 3, tenSinhVien = "SinhVien3", diemTB = 5.9, khoaID = 1 },
                new SINHVIEN { sinhVienID = 4, tenSinhVien = "SinhVien4", diemTB = 3.7, khoaID = 2 },
                new SINHVIEN { sinhVienID = 5, tenSinhVien = "SinhVien5", diemTB = 8.9, khoaID = 1 },
                new SINHVIEN { sinhVienID = 6, tenSinhVien = "SinhVien6", diemTB = 6.4, khoaID = 2 }
            };

            List<KHOA> danhSachKhoa = new List<KHOA>
            {
                new KHOA { khoaID = 1, tenKhoa = "CNTT" },
                new KHOA { khoaID = 2, tenKhoa = "Kinh Te" }
            };

            // Danh sach sinh vien theo khoa sap xep theo ten
            var sinhVienTheoKhoa = from sv in danhSachSinhVien
                                   join k in danhSachKhoa on sv.khoaID equals k.khoaID
                                   orderby sv.tenSinhVien
                                   group sv by k.tenKhoa into svGroup
                                   select new
                                   {
                                       khoa = svGroup.Key,
                                       sinhVien = svGroup.ToList()
                                   };
            Console.WriteLine("Danh sach sinh vien theo khoa sap xep theo ten:");
            foreach(var item1 in sinhVienTheoKhoa)
            {
                Console.WriteLine($"Khoa: {item1.khoa}");
                foreach (var item2 in item1.sinhVien)
                {
                    Console.WriteLine($"  {item2.tenSinhVien}");
                }
            }

            // Danh sach sinh vien cos diem trung binh >7,<4
            var sinhVienDiem7 = danhSachSinhVien.Where(sv => sv.diemTB > 7);
            var sinhVienDiem4 = danhSachSinhVien.Where(sv => sv.diemTB < 4);
            Console.WriteLine("\nDanh sach sinh vien co diem TB > 7:");
            foreach(var item in sinhVienDiem7)
            {
                Console.WriteLine($"  Sinh vien: {item.tenSinhVien}");
            }
            Console.WriteLine("\nDanh sach sinh vien co diem TB < 4:");
            foreach (var item in sinhVienDiem4)
            {
                Console.WriteLine($"  Sinh vien: {item.tenSinhVien}");
            }

            // Kiem tra co sinh vien ten "Khoa"
            var sinhVienTenKhoa = danhSachSinhVien.Where(sv => sv.tenSinhVien.Contains("Khoa"));
            if (sinhVienTenKhoa.Count() > 0)
            {
                Console.WriteLine("\nCac sinh vien ten Khoa:");
                foreach(var item in sinhVienTenKhoa)
                {
                    Console.WriteLine($" ID: {item.sinhVienID}, Ten: {item.tenSinhVien}");
                }
            }
            else
            {
                Console.WriteLine("\nKhong co sinh vien nao ten Khoa!");
            }

            // Danh sach sinh vien co thong tin khoa
            var sinhVienVaKhoa = from sv in danhSachSinhVien
                                 join k in danhSachKhoa on sv.khoaID equals k.khoaID
                                 select new
                                 {
                                     iD = sv.sinhVienID,
                                     ten = sv.tenSinhVien,
                                     khoa = k.tenKhoa
                                 };
            Console.WriteLine("\nDanh sach sinh vien co thong tin khoa:");
            foreach (var item in sinhVienVaKhoa)
            {
                Console.WriteLine($"  ID: {item.iD}, Sinh vien: {item.ten}, Khoa: {item.khoa}");
            }

            // Sinh vien gioi nhat
            var sinhVienGioiNhat = danhSachSinhVien.OrderByDescending(sv => sv.diemTB).FirstOrDefault();
            Console.WriteLine($"\nSinh vien gioi nhat: {sinhVienGioiNhat.tenSinhVien}");

            Console.ReadLine();
        }
    }
    
}
