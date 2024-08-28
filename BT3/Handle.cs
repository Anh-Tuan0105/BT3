using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    public class Handle
    {
        private static readonly Lazy<Handle> instance = new Lazy<Handle>(() => new Handle());
        public static Handle gI() => instance.Value;
        private bool isRunning = true;
        public Handle()
        {
            var data = Data.Gi();
            data.addData();
            Start();
            MainLoop();
            Stop();
        }


        public void Start()
        {
            Terminal.gI().SetTitle("Xin chào");
            Terminal.gI().EfectPrintf("Ấn Phím bất kỳ để bắt đầu", Terminal.gI().SizeX / 2, Terminal.gI().SizeY / 2, ConsoleColor.Red, 55);
            Console.ReadKey();
        }
        public void Stop()
        {
            Console.Clear();
            Terminal.gI().EfectPrintf("Tạm Biệt", Terminal.gI().SizeX / 2 + 5, Terminal.gI().SizeY / 2, ConsoleColor.Red, 30);
            Terminal.gI().SetTitle("Then Kiu bây bề đã chạy thử", 35);
        }
        private void AddTeacherToList()
        {
            var data = Data.Gi();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Nhập ID giáo viên: ");
            uint ID = uint.Parse(Console.ReadLine());
            Console.Write("Nhập tên giáo viên: ");
            string Name = Console.ReadLine();
            Console.Write("Nhập giới tính: ");
            string gender = Console.ReadLine();
            Console.Write("Nhập Tuổi: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Nhập Lớp: ");
            string classname = Console.ReadLine();
            bool isSuccess = data.AddTeacher(ID, Name, gender, age, classname);
            if (isSuccess)
            {
                Console.WriteLine("Thêm Thành Công");
            }
            else
            {
                Console.WriteLine("Thêm Thất Bại");
            }
            Console.ReadKey();
            Console.Clear();
        }
        private void ChangeTeacher()
        {
            var data = Data.Gi();
            Console.Clear();
            Terminal.gI().ShowMenuTeacher1(data.teachers);
            Terminal.gI().Print("ID giáo viên cần chỉnh sửa: ", 0, data.teachers.Count + 2);
            Console.SetCursorPosition(28, data.teachers.Count + 2);
            Console.ForegroundColor = ConsoleColor.White;
            uint ID = uint.Parse(Console.ReadLine());
            Teacher t = data.FindTeacherById(ID);
            if (t != null)
            {
                Console.Write("Nhập tên giáo viên: ");
                string Name = Console.ReadLine();
                if (Name != null && Name.Length > 0)
                {
                    t.Name = Name;
                }
                Console.Write("Nhập giới tính: ");
                string gender = Console.ReadLine();
                if (gender != null && gender.Length > 0)
                {
                    t.Gender = gender;
                }
                Console.Write("Nhập Tuổi: ");
                string age = Console.ReadLine();
                if (age != null && age.Length > 0)
                {
                    t.Age = int.Parse(age);
                }
                Console.Write("Nhập Lớp: ");
                string classname = Console.ReadLine();
                if (classname != null && classname.Length > 0)
                {
                    t.Class = classname;
                }
            }
            else
            {
                Console.WriteLine("Không có giáo viên có ID như thế!");
            }
            Console.Clear();
        }
        private void RemoveTeacher()
        {
            var data = Data.Gi();
            Console.Clear();
            Terminal.gI().ShowMenuTeacher1(data.teachers);
            Terminal.gI().Print("ID giáo viên cần xóa: ", 0, data.teachers.Count + 2);
            Console.SetCursorPosition(22, data.teachers.Count + 2);
            Console.ForegroundColor = ConsoleColor.White;
            int ID = int.Parse(Console.ReadLine());
            bool isSuccess = data.RemoveTeacher(ID - 1);
            if (isSuccess)
            {
                Console.WriteLine("Xóa Thành Công");
            }
            else
            {
                Console.WriteLine("Xóa Thất Bại");
            }
            Console.Clear();
        }
        private void AddStudentToList()
        {
            var data = Data.Gi();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Nhập ID sinh viên: ");
            uint ID = uint.Parse(Console.ReadLine());
            Console.Write("Nhập tên sinh viên: ");
            string Name = Console.ReadLine();
            Console.Write("Nhập giới tính: ");
            string gender = Console.ReadLine();
            Console.Write("Nhập Tuổi: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Nhập Lớp: ");
            string classname = Console.ReadLine();
            Console.Write("Nhập điểm GPA: ");
            double GPA = double.Parse(Console.ReadLine());
            bool isSuccess = data.AddStudent(ID, Name, gender, age, classname, GPA);
            if (isSuccess)
            {
                Console.WriteLine("Thêm Thành Công");
            }
            else
            {
                Console.WriteLine("Thêm Thất Bại");
            }
            Console.ReadKey();
            Console.Clear();
        }
        private void ChangeStudent()
        {
            var data = Data.Gi();
            Console.Clear();
            Terminal.gI().ShowMenuStudent1(data.students);
            Terminal.gI().Print("ID sinh viên cần chỉnh sửa: ", 0, data.students.Count + 2);
            Console.SetCursorPosition(28, data.students.Count + 2);
            Console.ForegroundColor = ConsoleColor.White;
            uint ID = uint.Parse(Console.ReadLine());
            Student s = data.FindStudentById(ID);
            if (s != null)
            {
                Console.Write("Nhập tên sinh viên: ");
                string Name = Console.ReadLine();
                if (Name != null && Name.Length > 0)
                {
                    s.Name = Name;
                }
                Console.Write("Nhập giới tính: ");
                string gender = Console.ReadLine();
                if (gender != null && gender.Length > 0)
                {
                    s.Gender = gender;
                }
                Console.Write("Nhập Tuổi: ");
                string age = Console.ReadLine();
                if (age != null && age.Length > 0)
                {
                    s.Age = int.Parse(age);
                }
                Console.Write("Nhập Lớp: ");
                string classname = Console.ReadLine();
                if (classname != null && classname.Length > 0)
                {
                    s.Class = classname;
                }
                Console.Write("Nhập GPA: ");
                string GPA = Console.ReadLine();
                if (GPA != null && GPA.Length > 0)
                {
                    s.GPA = double.Parse(GPA);
                }

            }
            else
            {
                Console.WriteLine("Không có sinh viên có ID như thế!");
            }
            Console.Clear();
        }
        private void RemoveStudent()
        {
            var data = Data.Gi();
            Console.Clear();
            Terminal.gI().ShowMenuStudent1(data.students);
            Terminal.gI().Print("ID sinh viên cần xóa: ", 0, data.students.Count + 2);
            Console.SetCursorPosition(22, data.students.Count + 2);
            Console.ForegroundColor = ConsoleColor.White;
            int ID = int.Parse(Console.ReadLine());
            bool isSuccess = data.RemoveStudent(ID - 1);
            if (isSuccess)
            {
                Console.WriteLine("Xóa Thành Công");
            }
            else
            {
                Console.WriteLine("Xóa Thất Bại");
            }
            Console.Clear();
        }
        // Main Loop
        public void MainLoop()
        {
            while (isRunning)
            {

                Console.Clear();
                var data = Data.Gi();
                Terminal.gI().ShowMenuChucNang();

                if (data.pChucNang == 0)
                {
                    Terminal.gI().ShowMenuTeacher(data.teachers);
                }
                else if (data.pChucNang == 1)
                {
                    Terminal.gI().ShowMenuStudent(data.students);
                }
                ConsoleKeyInfo key1 = Console.ReadKey();
                if (key1.Key == ConsoleKey.RightArrow)
                {
                    ReadKey(key1);
                }
                else
                {
                    data.pChucNang = ReadKeyUD(data.pChucNang, data.ChucNang, key1);
                }
            }

        }

        private int ReadKeyUD(int position, string[] array, ConsoleKeyInfo key)
        {
            var data = Data.Gi();

            if (key.Key == ConsoleKey.UpArrow)
            {
                position = (position - 1 + array.Length) % array.Length;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                position = (position + 1) % array.Length;
            }
            else if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape)
            {
                if (data.pChucNang == 2)
                {
                    isRunning = false;
                }
            }
            Terminal.gI().Print(position.ToString(), 1, 0);

            return position;
        }

        // Placeholder for Left/Right key handling if needed
        private void ReadKey(ConsoleKeyInfo key)
        {
            var data = Data.Gi();
            bool isRunRL = true;
            while (isRunRL)
            {
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (data.pChucNang == 0)
                    {
                        data.pTeacher = ReadKeyUD(data.pTeacher, data.GetTeacherNames(), key);
                        Terminal.gI().ShowMenuChucNang();
                        Terminal.gI().ShowMenuTeacher(data.teachers);
                        ConsoleKeyInfo key2 = Console.ReadKey();
                        if (data.pTeacher == data.teachers.Count - 1)
                        {
                            if (key2.Key == ConsoleKey.RightArrow)
                            {
                                data.pTinhNang++;
                                if (data.pTinhNang >= data.TinhNang.Length)
                                {
                                    data.pTinhNang = 0;
                                }
                            }
                            else if (key2.Key == ConsoleKey.LeftArrow)
                            {
                                data.pTinhNang--;
                                if (data.pTinhNang < 0)
                                {
                                    data.pTinhNang = data.TinhNang.Length - 1;
                                }
                            }
                            else if (key2.Key == ConsoleKey.UpArrow)
                            {
                                data.pTeacher = data.teachers.Count - 1;
                                data.pTeacher = ReadKeyUD(data.pTeacher, data.GetTeacherNames(), key2);
                            }
                            else if (key2.Key == ConsoleKey.Enter || key2.Key == ConsoleKey.Spacebar)
                            {
                                if (data.pTinhNang == 0)
                                {
                                    AddTeacherToList();
                                }
                                else if (data.pTinhNang == 1)
                                {
                                    ChangeTeacher();
                                }
                                else if (data.pTinhNang == 2)
                                {
                                    RemoveTeacher();
                                    data.pTeacher = data.teachers.Count - 1;
                                }
                            }
                        }
                        else if (key2.Key == ConsoleKey.LeftArrow)
                        {
                            isRunRL = false;
                        }
                        else
                        {
                            data.pTeacher = ReadKeyUD(data.pTeacher, data.GetTeacherNames(), key2);
                        }
                        //data.pTeacher = ReadKeyUD(data.pTeacher, data.GetTeacherNames(), key2);
                    }
                    else if (data.pChucNang == 1)
                    {
                        data.pStudent = ReadKeyUD(data.pStudent, data.GetStudentNames(), key);
                        Terminal.gI().ShowMenuChucNang();
                        Terminal.gI().ShowMenuStudent(data.students);
                        ConsoleKeyInfo key2 = Console.ReadKey();
                        if (data.pStudent == data.students.Count - 1)
                        {
                            if (key2.Key == ConsoleKey.RightArrow)
                            {
                                data.pTinhNang++;
                                if (data.pTinhNang >= data.TinhNang.Length)
                                {
                                    data.pTinhNang = 0;
                                }
                            }
                            else if (key2.Key == ConsoleKey.LeftArrow)
                            {
                                data.pTinhNang--;
                                if (data.pTinhNang < 0)
                                {
                                    data.pTinhNang = data.TinhNang.Length - 1;
                                }
                            }
                            else if (key2.Key == ConsoleKey.UpArrow)
                            {
                                data.pStudent = data.students.Count - 1;
                                data.pStudent = ReadKeyUD(data.pStudent, data.GetStudentNames(), key2);
                            }
                            else if (key2.Key == ConsoleKey.Enter || key2.Key == ConsoleKey.Spacebar)
                            {
                                if (data.pTinhNang == 0)
                                {
                                    AddStudentToList();
                                }
                                else if (data.pTinhNang == 1)
                                {
                                    ChangeStudent();
                                }
                                else if (data.pTinhNang == 2)
                                {
                                    RemoveStudent();
                                    data.pStudent = data.students.Count - 1;
                                }
                            }
                        }
                        else if (key2.Key == ConsoleKey.LeftArrow && data.pTinhNang == 0)
                        {
                            isRunRL = false;
                        }
                        else
                        {
                            data.pStudent = ReadKeyUD(data.pStudent, data.GetStudentNames(), key2);
                        }
                        //data.pStudent = ReadKeyUD(data.pStudent, data.GetStudentNames(), key2);
                    }
                }
            }
        }
    }
}
