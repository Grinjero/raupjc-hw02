using StudentLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.OrderBy(number => number)
                .GroupBy(number => number)
                .Select(group => 
                String.Format("Broj {0} ponavlja se {1} puta", group.Key, group.Count())).ToArray();
        }
        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(university => 
                university.Students
                .Where(student => student.Gender == Gender.Female).Count() == 0).ToArray();
        }
        public static University[] Linq2_2(University[] universityArray)
        {
            double averageNoStudents = universityArray.Average(university => university.Students.Count());

            return universityArray
                .Where(university => university.Students.Count() < averageNoStudents)
                .ToArray();
        }

        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(university => university.Students)
                .Distinct()
                .ToArray();
        }

        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(university =>
                university.Students
                .Where(student => student.Gender == Gender.Female).Count() == 0
                || university.Students
                .Where(student => student.Gender == Gender.Male).Count() == 0)
                .SelectMany(university => university.Students)
                .ToArray();
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            return null;
                   
        }
    }

    public class University
    {
        public string Name { get; set; }
        public Student[] Students { get; set; }

        public University() { }

        public University(string name, Student[] students)
        {
            Name = name;
            Students = students;
        }
    }
}
