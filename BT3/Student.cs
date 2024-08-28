using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    public class Student : Human 
    {
        public double GPA { get; set; }
        public Student(uint ID , string Name, string Gender, int Age, string Class, double GPA)
        {
            this.ID = ID;
            this.Name = Name;
            this.Gender = Gender;
            this.Age = Age;
            this.Class = Class;
            this. GPA = GPA;
        }
        public bool Passing()
        {
            return GPA >= 2.0;
        }
    }
}
