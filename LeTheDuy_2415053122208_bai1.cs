using System;
using System.Collections.Generic;
using System.Linq;

/*
========================================================
CHƯƠNG TRÌNH QUẢN LÝ DANH SÁCH SINH VIÊN (SỬ DỤNG RANDOM)

Chức năng:
1. Tạo danh sách sinh viên ngẫu nhiên
2. Tìm tuổi lớn nhất và nhỏ nhất
3. Kiểm tra có sinh viên thuộc khoa CNS hay không
4. Lấy 10 sinh viên có điểm trung bình cao nhất của 1 khoa
5. Bỏ sinh viên năm cuối và hiển thị danh sách còn lại
========================================================
*/


// Tạo class SinhVien để lưu thông tin sinh viên
class SinhVien
{
    public string Ten { get; set; }      // Tên sinh viên
    public int Tuoi { get; set; }        // Tuổi
    public string Khoa { get; set; }     // Khoa
    public double DiemTB { get; set; }   // Điểm trung bình
    public int NamHoc { get; set; }      // Năm học (1-4)
}


class Program
{
    static void Main()
    {

        // Tạo đối tượng random để sinh dữ liệu ngẫu nhiên
        Random rd = new Random();

        // Tạo danh sách sinh viên
        List<SinhVien> listSV = new List<SinhVien>();


        // Danh sách tên mẫu
        string[] ten = {
            "An","Binh","Chi","Dung","Huy",
            "Lan","Minh","Nam","Phuc","Trang"
        };

        // Danh sách khoa
        string[] khoa = {
            "CNTT", "CNS", "QTKD", "KT"
        };


        /*
        ==========================================
        TẠO 50 SINH VIÊN NGẪU NHIÊN
        ==========================================
        */

        for (int i = 0; i < 50; i++)
        {
            SinhVien sv = new SinhVien();

            sv.Ten = ten[rd.Next(ten.Length)];
            sv.Tuoi = rd.Next(18, 25);           // tuổi từ 18 - 24
            sv.Khoa = khoa[rd.Next(khoa.Length)];
            sv.DiemTB = Math.Round(rd.NextDouble() * 10, 2); // điểm 0-10
            sv.NamHoc = rd.Next(1, 5);           // năm 1 - năm 4

            listSV.Add(sv);
        }



        /*
        ==========================================
        HIỂN THỊ DANH SÁCH SINH VIÊN
        ==========================================
        */

        Console.WriteLine("DANH SACH SINH VIEN RANDOM\n");

        foreach (var sv in listSV)
        {
            Console.WriteLine(
                $"Ten: {sv.Ten} | Tuoi: {sv.Tuoi} | Khoa: {sv.Khoa} | Diem: {sv.DiemTB} | Nam: {sv.NamHoc}"
            );
        }



        /*
        ==========================================
        1. TÌM TUỔI LỚN NHẤT VÀ NHỎ NHẤT
        ==========================================
        */

        int maxTuoi = listSV.Max(sv => sv.Tuoi);
        int minTuoi = listSV.Min(sv => sv.Tuoi);

        Console.WriteLine("\n---------------------------");
        Console.WriteLine("TUOI LON NHAT: " + maxTuoi);
        Console.WriteLine("TUOI NHO NHAT: " + minTuoi);



        /*
        ==========================================
        2. KIỂM TRA CÓ SINH VIÊN KHOA CNS
        ==========================================
        */

        bool coCNS = listSV.Any(sv => sv.Khoa == "CNS");

        Console.WriteLine("\n---------------------------");

        if (coCNS)
            Console.WriteLine("CO SINH VIEN THUOC KHOA CNS");
        else
            Console.WriteLine("KHONG CO SINH VIEN THUOC KHOA CNS");



        /*
        ==========================================
        3. LẤY 10 SINH VIÊN ĐIỂM CAO NHẤT CỦA KHOA
        Ví dụ: khoa CNTT
        ==========================================
        */

        var top10 = listSV
            .Where(sv => sv.Khoa == "CNTT")     // lọc sinh viên CNTT
            .OrderByDescending(sv => sv.DiemTB) // sắp xếp điểm giảm dần
            .Take(10);                          // lấy 10 sinh viên

        Console.WriteLine("\n---------------------------");
        Console.WriteLine("TOP 10 SINH VIEN DIEM CAO NHAT KHOA CNTT");

        foreach (var sv in top10)
        {
            Console.WriteLine($"{sv.Ten} - Diem: {sv.DiemTB}");
        }



        /*
        ==========================================
        4. BỎ QUA SINH VIÊN NĂM CUỐI
        (năm 4)
        ==========================================
        */

        var svConLai = listSV
            .Where(sv => sv.NamHoc != 4);

        Console.WriteLine("\n---------------------------");
        Console.WriteLine("SINH VIEN KHONG PHAI NAM CUOI\n");

        foreach (var sv in svConLai)
        {
            Console.WriteLine(
                $"{sv.Ten} | Nam: {sv.NamHoc} | Khoa: {sv.Khoa}"
            );
        }


        Console.WriteLine("\n============================");
        Console.WriteLine("CHUONG TRINH KET THUC");
        Console.ReadKey();
    }
}

