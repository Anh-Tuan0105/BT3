using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BT3
{
    public class Terminal
    {
        private Terminal() { }
        private static Terminal gi;
        private readonly static object giLock = new object();
        private readonly object _lock = new object();
        public static Terminal gI()
        {
            if (gi == null)
            {
                lock (giLock)
                {
                    if(gi == null)
                    {
                        gi = new Terminal();
                    }
                }
            }
            return gi;
        }
        public int SizeX { get; set; } = 100;
        public int SizeY { get; set; } = 20;
        public void SetTitle(string title, int time = 75)
        {
            string currentTitle = "";
            foreach (char c in title)
            {
                currentTitle += c;
                Console.Title = currentTitle;
                Thread.Sleep(time);
            }
        }                                             // gắn giá trị mặc định: nếu không được chuyền vô, nó tự lấy cái t gán
        public void EfectPrintf(string s, int x, int y, ConsoleColor color = ConsoleColor.White, int time = 100)
        {
            string Stringsub = "";
            foreach (char c in s)
            {
                Stringsub += c;
                Print(Stringsub, x, y, color);
                Thread.Sleep(time);
            }
        }
        public void Print(string s, int x, int y, ConsoleColor color = ConsoleColor.White)
        {
            lock (_lock)
            {
                Console.SetCursorPosition(x, y);
                Console.ForegroundColor = color;
                Console.WriteLine(s);
                Console.ResetColor();
                Console.SetCursorPosition(0, SizeY);
            }
        }
        // menu
        public void ShowMenuChucNang()
        {
            Print("Chức Năng", 2, 1, ConsoleColor.Cyan);
            for (int i = 0; i < Data.Gi().ChucNang.Length; i++)
            {
                Print(Data.Gi().ChucNang[i], 2, i + 2, ConsoleColor.Green);
                if (Data.Gi().pChucNang == i)
                    Print(Data.Gi().ChucNang[i], 2, i + 2, ConsoleColor.Red);
            }
        }
        public void ShowMenuTeacher(List<Teacher> teachers)
        {
            Print(Data.Gi().supChucNang[0], SizeX / 2 - 30, 1, ConsoleColor.Green);
            for (int i = 0; i < teachers.Count; i++)
            {

                Print(teachers[i].Name, SizeX / 2 - 30, i + 2, ConsoleColor.White);
                if (Data.Gi().pTeacher == i)
                {
                    Print(teachers[i].Name, SizeX / 2 - 30, i + 2, ConsoleColor.Red);
                    Print("                                        ", 50, 0);
                    Print(teachers[i].Name, 50, 0, ConsoleColor.DarkRed);
                    Print(teachers[i].ID.ToString(), SizeX / 2, 2, ConsoleColor.White);
                    Print(teachers[i].Age.ToString(), SizeX / 2 + 10, 2, ConsoleColor.White);
                    Print(teachers[i].Class, SizeX / 2 + 20, 2, ConsoleColor.White);
                }


            }
            ShowMenuTinhNang(teachers.Select(s => s.Name).ToArray());
            ShowMenuChucNangPhuGV();
        }
        public void ShowMenuStudent(List<Student> students)
        {
            Print(Data.Gi().supChucNang[1], SizeX / 2 - 30, 1, ConsoleColor.Green);
            for (int i = 0; i < students.Count; i++)
            {
                Print(students[i].Name, SizeX / 2 - 30, i + 2, ConsoleColor.White);
                if (Data.Gi().pStudent == i)
                {
                    Print(students[i].Name, SizeX / 2 - 30, i + 2, ConsoleColor.Red);
                    Print("                                        ", 50, 0);
                    Print(students[i].Name, 50, 0, ConsoleColor.DarkRed);
                    Print(students[i].ID.ToString(), SizeX / 2, 2, ConsoleColor.White);
                    Print(students[i].Age.ToString(), SizeX / 2 + 15, 2, ConsoleColor.White);
                    Print(students[i].Class, SizeX / 2 + 30, 2, ConsoleColor.White);
                    Print(students[i].GPA.ToString(), SizeX / 2 + 45, 2, students[i].Passing() ? ConsoleColor.White : ConsoleColor.Red);
                }
            }
            ShowMenuTinhNang(students.Select(s => s.Name).ToArray());
            ShowMenuChucNangPhu();
        }
        public void ShowMenuTinhNang(string[] arr)
        {
            for (int i = 0; i < Data.Gi().TinhNang.Length; i++)
            {
                Print(Data.Gi().TinhNang[i], ((SizeX / 2) - 30) + 7 * i, arr.Length + 2, ConsoleColor.Cyan);
                if (Data.Gi().pTinhNang == i)
                {
                    Print(Data.Gi().TinhNang[i], ((SizeX / 2) - 30) + 7 * i, arr.Length + 2, ConsoleColor.DarkCyan);
                }
            }
        }
        public void ShowMenuChucNangPhu()
        {
            for (int i = 0; i < Data.Gi().ChucNangPhu.Length; i++)
            {
                Print(Data.Gi().ChucNangPhu[i], 50 + (i * 15), 1, ConsoleColor.Cyan);
            }
        }
        public void ShowMenuChucNangPhuGV()
        {
            for (int i = 0; i < Data.Gi().ChucNangPhuGiaoVien.Length; i++)
            {
                Print(Data.Gi().ChucNangPhuGiaoVien[i], 50 + (i * 10), 1, ConsoleColor.Cyan);
            }
        }
        public void ShowMenuTeacher1(List<Teacher> teachers)
        {
            Print(Data.Gi().supChucNang[0], 0, 0, ConsoleColor.Green);
            for (int i = 0; i < teachers.Count; i++)
            {
                Print(teachers[i].Name, 0, i + 1, ConsoleColor.White);
            }
        }
        public void ShowMenuStudent1(List<Student> students)
        {
            Print(Data.Gi().supChucNang[1], 0, 0, ConsoleColor.Green);
            for (int i = 0; i < students.Count; i++)
            {
                Print(students[i].Name, 0, i + 1, ConsoleColor.White);
            }
        }
    }
}
