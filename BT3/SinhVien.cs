using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    internal class SinhVien
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public SinhVien()
        {
            Id = 0;
            Name = "";
            Age = 0;
        }

        public static void InDanhSachSinhVien(List<SinhVien> sinhViens)
        {
            Console.WriteLine("Danh sach sinh vien:");
            foreach (var sv in sinhViens)
            {
                Console.WriteLine($"ID: {sv.Id}, Name: {sv.Name}, Age: {sv.Age}");
            }
        }
    }
}
