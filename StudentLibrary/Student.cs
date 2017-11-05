using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary
{
    public class Student
    {
        public string Name { get; set; }

        public string Jmbag { get; set; }

        public Gender Gender { get; set; }

        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public Student(string name, string jmbag, Gender gender)
        {
            Name = name;
            Jmbag = jmbag;
            Gender = gender;
        }

        public void main(String[] args)
        {
            var topStudents = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 ") ,
                new Student (" Luka ", jmbag :" 3274272 ") ,
                new Student ("Ana", jmbag :" 9382832 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            bool isIvanTopStudent = topStudents.Contains(ivan);
            Console.WriteLine("Ivan top student = " + isIvanTopStudent);


            var list = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 ") ,
                new Student (" Ivan ", jmbag :" 001234567 ")
            };
            // 2 :(
            var distinctStudentsCount = list.Distinct().Count();


            topStudents = new List<Student>()
            {
                new Student (" Ivan ", jmbag :" 001234567 ") ,
                new Student (" Luka ", jmbag :" 3274272 ") ,
                new Student ("Ana", jmbag :" 9382832 ")
            };
            ivan = new Student(" Ivan ", jmbag: " 001234567 ");
            // false :(
            // == operator is a different operation from . Equals ()
            // Maybe it isn ’t such a bad idea to override it as well
            isIvanTopStudent = topStudents.Any(s => s == ivan);
        }

        public static bool operator== (Student obj1, Student obj2)
        {
            if(obj1.Equals(obj2))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static bool operator!=(Student obj1, Student obj2)
        {
            if (obj1.Equals(obj2))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override bool Equals(object obj)
        {
            if(obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Student other = (Student)obj;
            return other.Jmbag.Equals(this.Jmbag);
        }


        public override int GetHashCode()
        {
            return Jmbag.GetHashCode();
        }
    }

    public enum Gender
    {
        Male, Female
    }
}
