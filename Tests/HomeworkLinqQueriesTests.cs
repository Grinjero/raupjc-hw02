using Microsoft.VisualStudio.TestTools.UnitTesting;
using Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentLibrary;

namespace Tests
{
    [TestClass()]
    public class HomeworkLinqQueriesTests
    {
        [TestMethod()]
        public void Linq1Test()
        {
            int[] integers = new[] { 1, 3, 3, 4, 2, 2, 2, 3, 3, 4, 5 };

            string[] expected = new string[] {
                "Broj 1 ponavlja se 1 puta",
                "Broj 2 ponavlja se 3 puta",
                "Broj 3 ponavlja se 4 puta",
                "Broj 4 ponavlja se 2 puta",
                "Broj 5 ponavlja se 1 puta"
            };

            CollectionAssert.AreEqual(expected, HomeworkLinqQueries.Linq1(integers));
        }

        [TestMethod()]
        public void Linq2_1Test()
        {
            Student[] students1 = new Student[]
            {
                new Student("Ana", "00036", Gender.Female),

                new Student("Ivan", "222", Gender.Male)
            };

            Student[] students2 = new Student[]
            {
                new Student("ttt", "00036", Gender.Male),

                new Student("Wwww", "3333", Gender.Male)
            };

            Student[] students3 = new Student[]
            {
                new Student("ADAWDAWD", "3333334444", Gender.Male),

                new Student("adadad", "22222222", Gender.Male)
            };

            Student[] students4 = new Student[]
            {
                new Student("Fernando", "9999", Gender.Female),

                new Student("Bruscetoo", "666666", Gender.Female)
            };

            University fer = new University("FER", students3);
            University ffzg = new University("FFZG", students1);
            University tvz = new University("TVZ", students2);
            University fkit = new University("FKIT", students4);

            University[] universities = new University[]
            {
                ffzg,

                tvz,

                fer,

                fkit
            };

            University[] filtered = HomeworkLinqQueries.Linq2_1(universities);
            University[] expected = new University[]
            {
                tvz, fer
            };

            CollectionAssert.AreEqual(expected, filtered);
        }

        [TestMethod()]
        public void Linq2_3Test()
        {
            Student ivan = new Student("Ivan", "222", Gender.Male);
            Student ana = new Student("Ana", "00036", Gender.Female);
            Student ante = new Student("Ante", "011111", Gender.Male);
            Student prokop = new Student("Prokop", "3333", Gender.Male);
            Student zakop = new Student("Zakop", "3333334444", Gender.Male);

            Student[] students1 = new Student[]
            {
                ivan,

                ana
            };

            Student[] students2 = new Student[]
            {
                ivan,

                ante
            };

            Student[] students3 = new Student[]
            {
                ana,

                prokop
            };

            Student[] students4 = new Student[]
            {
                zakop,
                prokop
            };

            University fer = new University("FER", students3);
            University ffzg = new University("FFZG", students1);
            University tvz = new University("TVZ", students2);
            University fkit = new University("FKIT", students4);

            University[] universities = new University[]
            {
                ffzg,

                tvz,

                fer,

                fkit
            };

            Student[] filtered = HomeworkLinqQueries.Linq2_3(universities);
            Student[] expected = new Student[]
            {
                ivan,
                ana,
                ante,
                zakop,
                prokop
            };

            CollectionAssert.AreEquivalent(expected, filtered);
        }

        [TestMethod()]
        public void Linq2_4Test()
        {
            Student ivan = new Student("Ivan", "222", Gender.Male);
            Student ana = new Student("Ana", "00036", Gender.Female);
            Student ante = new Student("Ante", "011111", Gender.Male);
            Student prokop = new Student("Prokop", "3333", Gender.Male);
            Student zakop = new Student("Zakop", "3333334444", Gender.Female);
            Student mateja = new Student("mateja", "22222", Gender.Female);

            Student[] students1 = new Student[]
            {
                ivan,

                zakop
            };

            Student[] students2 = new Student[]
            {
                ivan,

                ante
            };

            Student[] students3 = new Student[]
            {
                ana,

                prokop
            };

            Student[] students4 = new Student[]
            {
                ana,

                mateja
            };

            University fer = new University("FER", students3);
            University ffzg = new University("FFZG", students1);
            University tvz = new University("TVZ", students2);
            University fkit = new University("FKIT", students4);

            University[] universities = new University[]
            {
                ffzg,

                tvz,

                fer,

                fkit
            };

            Student[] filtered = HomeworkLinqQueries.Linq2_4(universities);
            Student[] expected = new Student[]
            {
                ana,
                mateja,
                ivan,
                ante
            };

            CollectionAssert.AreEquivalent(expected, filtered);
        }

        [TestMethod()]
        public void Linq2_2Test()
        {
            Student[] students1 = new Student[]
            {
                new Student("Ana", "00036", Gender.Female),

                new Student("Ivan", "222", Gender.Male)
            };

            Student[] students2 = new Student[]
            {
                new Student("ttt", "00036", Gender.Male),

                new Student("Wwww", "3333", Gender.Male)
            };

            Student[] students3 = new Student[]
            {
                new Student("ADAWDAWD", "3333334444", Gender.Male),

                new Student("adadad", "22222222", Gender.Male)
            };

            Student[] students4 = new Student[]
            {

                new Student("Bruscetoo", "666666", Gender.Female)
            };

            University fer = new University("FER", students3);
            University ffzg = new University("FFZG", students1);
            University tvz = new University("TVZ", students2);
            University fkit = new University("FKIT", students4);

            University[] universities = new University[]
            {
                ffzg,

                tvz,

                fer,

                fkit
            };

            University[] filtered = HomeworkLinqQueries.Linq2_2(universities);
            University[] expected = new University[]
            {
                fkit
            };

            CollectionAssert.AreEqual(expected, filtered);
        }
    }
}