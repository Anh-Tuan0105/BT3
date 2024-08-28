using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    public class Data
    {
        private Data() { }
        private static Data gi;
        private readonly static object giLock = new object();
        public static Data Gi()
        {
            if(gi == null)
            {
                lock(giLock)
                {
                    if(gi == null)
                    {
                        gi = new Data();
                    }
                }
            }
            return gi;
        }
        public List<Student> students { get; set; }
        public List<Teacher> teachers {  get; set; }
        public string[] ChucNang = { "Giảng Viên", "Học Sinh", "Thoát" };
        public string[] ChucNangPhu = { "ID", "Tuổi", "Lớp", "GPA" };
        public string[] ChucNangPhuGiaoVien = { "ID", "Tuổi", "Lớp" };
        public string[] supChucNang = { "Danh Sách Giảng Viên", "Danh Sách Học Sinh" };
        public string[] TinhNang = { "Thêm", "Sửa", "Xoá" };
        public int pTeacher = 0;
        public int pStudent = 0;
        public int pChucNang = 0;
        public int pTinhNang = 0;
        public void addData()
        {
            teachers = new List<Teacher>
            {
                new Teacher(1, "Võ Văn Vậu", "Nam", 30, "23DTHA5"),
                new Teacher(2, "Nguyễn Nguyên Ngọ", "Nam", 55, "23DTHA6"),
                new Teacher(3, "Trần Trị Trương", "Nữ", 31, "23DTHA7")
            };
            students = new List<Student>
            {
                new Student(2380601424, "Nguyễn Thanh Bảo Ngân", "Nữ", 19, "23DTHA5", 3.9),
                new Student(2380601806, "Nguyễn Công Quang", "Nam", 21, "23DTHA6", 1.9),
                new Student(2380601640, "Nguyễn Trường Phát", "Nam", 19, "23DTHA7", 3.7),
                new Student(2380601465, "Lê Huỳnh Ngọc", "Nam", 19, "23DTHA5", 2.6),
                new Student(2380602440, "Huỳnh Ngọc Anh Tuấn", "Nam", 19, "23DTHA6", 3.6)
            };
        }
        public Data(List<Student> students, List<Teacher> teachers)
        {
            this.students = students;
            this.teachers = teachers;
        }
        // Convert Students list to array
        public uint[] GetStudentIds()
        {
            return students.Select(s => s.ID).ToArray();
        }

        public string[] GetStudentNames()
        {
            return students.Select(s => s.Name).ToArray();
        }

        public int[] GetStudentAges()
        {
            return students.Select(s => s.Age).ToArray();
        }

        public string[] GetStudentClasses()
        {
            return students.Select(s => s.Class).ToArray();
        }

        public double[] GetStudentGPAs()
        {
            return students.Select(s => s.GPA).ToArray();
        }
        // Convert Teacher list to array
        public uint[] GetTeacherIds()
        {
            return teachers.Select(t => t.ID).ToArray();
        }

        public string[] GetTeacherNames()
        {
            return teachers.Select(t => t.Name).ToArray();
        }

        public int[] GetTeacherAges()
        {
            return teachers.Select(t => t.Age).ToArray();
        }

        public string[] GetTeacherClasses()
        {
            return teachers.Select(t => t.Class).ToArray();
        }
        // Add Teacher
        public bool AddTeacher(uint id, string name, string gender, int age, string className)
        {
            try
            {
                teachers.Add(new Teacher(id, name, gender, age, className));
                return true;
            }
            catch (Exception ex)
            {
                Terminal.gI().EfectPrintf("Lỗi tại AddTeacher \n" + ex.ToString(), 0, Terminal.gI().SizeY);
                return false;
            }
        }
        // Add Student
        public bool AddStudent(uint id, string name, string gender, int age, string className, double gpa)
        {
            try
            {
                students.Add(new Student(id, name, gender, age, className, gpa));
                return true;
            }
            catch (Exception ex)
            {
                Terminal.gI().EfectPrintf("Lỗi tại AddStudent \n" + ex.ToString(), 0, Terminal.gI().SizeY);
                return false;
            }
        }
        // Remove Teacher
        public bool RemoveTeacher(int index)
        {
            try
            {
                if (index >= 0 && index < teachers.Count)
                {
                    teachers.RemoveAt(index);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Terminal.gI().EfectPrintf("Lỗi tại RemoveTeacher \n" + ex.ToString(), 0, Terminal.gI().SizeY);
                return false;
            }
        }
        // Remove Student
        public bool RemoveStudent(int index)
        {
            try
            {
                if (index >= 0 && index < students.Count)
                {
                    students.RemoveAt(index);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Terminal.gI().EfectPrintf("Lỗi tại RemoveStudent \n" + ex.ToString(), 0, Terminal.gI().SizeY);
                return false;
            }
        }
        // Get list of all teachers
        public List<Teacher> GetAllTeachers()
        {
            return teachers;
        }

        // Get list of all students
        public List<Student> GetAllStudents()
        {
            return students;
        }

        // Find teacher by ID
        public Teacher FindTeacherById(uint id)
        {
            return teachers.FirstOrDefault(t => t.ID == id);
        }

        // Find student by ID
        public Student FindStudentById(uint id)
        {
            return students.FirstOrDefault(s => s.ID == id);
        }
    }
}
