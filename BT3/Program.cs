using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<SinhVien> students = new List<SinhVien>()
            {
                new SinhVien() { Id = 1, Name = "Anh", Age = 22 },
                new SinhVien() { Id = 2, Name = "Tuan", Age = 22 },
                new SinhVien() { Id = 3, Name = "Dat", Age = 19 },
                new SinhVien() { Id = 4, Name = "Thinh", Age = 18 },
                new SinhVien() { Id = 5, Name = "An", Age = 15 }
            };

            //In toan bo danh sach sinh vien
            SinhVien.InDanhSachSinhVien(students);
            //Tim va in ra sinh vien co tuoi tu 15 den 18
            Console.WriteLine("\nSinh vien co tuoi tu 15 den 18:");
            var filteredStudents = students.Where(s => s.Age >= 15 && s.Age <= 18).ToList();
            SinhVien.InDanhSachSinhVien(filteredStudents);
            //Tim va in ra sinh vien ten ban dau bang A
            Console.WriteLine("\nSinh vien co ten bat dau bang A:");
            var studentsWithNameA = students.Where(s => s.Name.StartsWith("A")).ToList();
            SinhVien.InDanhSachSinhVien(studentsWithNameA);
            //Tinh tong tuoi cua tat ca sinh vien trong danh sach
            Console.WriteLine("\nTong tuoi cua tat ca sinh vien:");
            var totalAge = students.Sum(s => s.Age);
            Console.WriteLine($"Tong tuoi: {totalAge}");
            //Tim va in ra hoc sinh co tuoi lon nhat
            Console.WriteLine("\nSinh vien co tuoi lon nhat");
            var maxAge = students.Max(s => s.Age);
            var oldestStudents = students.Where(s => s.Age == maxAge).ToList();
            SinhVien.InDanhSachSinhVien(oldestStudents);
            //Sap xep danh sach sinh vien theo tuoi tang dan va in ra danh sach sau khi sap xep
            Console.WriteLine("\nDanh sach sinh vien sau khi sap xep theo tuoi tang dan:");
            var sortedStudents = students.OrderBy(s => s.Age).ToList();
            SinhVien.InDanhSachSinhVien(sortedStudents);
        }
    }
}
