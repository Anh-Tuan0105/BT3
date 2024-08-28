using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    public class Teacher : Human
    {
        public Teacher(uint ID, string Name, string Gender, int Age, string Class) 
        {
            this.ID = ID;
            this.Name = Name;
            this.Gender = Gender;
            this.Age = Age;
            this.Class = Class;
        }
    }
}
