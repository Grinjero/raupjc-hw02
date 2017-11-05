using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {
        private TodoRepository _repository = new TodoRepository();

        [TestMethod()]
        [ExpectedException(typeof(DuplicateTodoItemException))]
        public void AddTest()
        {
            TodoItem item1 = new TodoItem("Učiii");
            TodoItem item2 = new TodoItem("Ajmo");

            _repository.Add(item1);
            _repository.Add(item2);
            
            Assert.AreEqual(_repository.GetAll().First(),item1);
            Assert.AreEqual(_repository.GetAll().ElementAt(1), item2);

            Assert.AreEqual(_repository.GetAll().Count(), 2);

            _repository.Add(item1);
        }

        [TestMethod()]
        public void GetTest()
        {
            TodoItem item1 = new TodoItem("Učiii");
            TodoItem item2 = new TodoItem("Ajmo");

            _repository.Add(item1);
            _repository.Add(item2);

            Assert.AreEqual(item1, _repository.Get(item1.Id));
        }

        [TestMethod()]
        public void GetActiveTest()
        {
            TodoItem item1 = new TodoItem("Učiii");
            TodoItem item2 = new TodoItem("Ajmo");
            TodoItem item3 = new TodoItem("Parada");
            TodoItem item4 = new TodoItem("Slava");

            item1.MarkAsCompleted();
            item3.MarkAsCompleted();

            _repository.Add(item1);
            _repository.Add(item2);
            _repository.Add(item3);
            _repository.Add(item4);

            List<TodoItem> expectedList = new List<TodoItem> { item2, item4 };
            List<TodoItem> actualList = _repository.GetActive();

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            TodoItem item1 = new TodoItem("Učiii");
            TodoItem item2 = new TodoItem("Ajmo");
            TodoItem item3 = new TodoItem("Parada");
            TodoItem item4 = new TodoItem("Slava");

            _repository.Add(item1);
            _repository.Add(item2);
            _repository.Add(item3);
            _repository.Add(item4);

            List<TodoItem> expectedList = new List<TodoItem> { item1, item2, item3 , item4 };
            List<TodoItem> actualList = _repository.GetAll();

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            TodoItem item1 = new TodoItem("Učiii");
            TodoItem item2 = new TodoItem("Ajmo");
            TodoItem item3 = new TodoItem("Parada");
            TodoItem item4 = new TodoItem("Slava");

            item1.MarkAsCompleted();
            item3.MarkAsCompleted();

            _repository.Add(item1);
            _repository.Add(item2);
            _repository.Add(item3);
            _repository.Add(item4);

            List<TodoItem> expectedList = new List<TodoItem> { item1, item3 };
            List<TodoItem> actualList = _repository.GetCompleted();

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            Func<TodoItem, bool> filter = delegate (TodoItem item)
            {
                return item.Text.ToLower().StartsWith("a");
            };

                TodoItem item1 = new TodoItem("Učiii");
                TodoItem item2 = new TodoItem("Ajmo");
                TodoItem item3 = new TodoItem("Parada");
                TodoItem item4 = new TodoItem("Slava");
                TodoItem item5 = new TodoItem("armenija");

                _repository.Add(item1);
                _repository.Add(item2);
                _repository.Add(item3);
                _repository.Add(item4);
                _repository.Add(item5);

                List<TodoItem> actualList = _repository.GetFiltered(filter);
                List<TodoItem> expectedList = new List<TodoItem> { item2, item5 };

                CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            TodoItem item1 = new TodoItem("Učiii");
            TodoItem item2 = new TodoItem("Ajmo");

            _repository.Add(item1);
            _repository.Add(item2);

            _repository.MarkAsCompleted(item1.Id);
            Assert.IsTrue(item1.isCompleted);

            Assert.IsFalse(item2.isCompleted);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            TodoItem item1 = new TodoItem("Učiii");
            TodoItem item2 = new TodoItem("Ajmo");
            TodoItem item3 = new TodoItem("Parada");
            TodoItem item4 = new TodoItem("Slava");
            TodoItem item5 = new TodoItem("armenija");

            _repository.Add(item1);
            _repository.Add(item2);
            _repository.Add(item3);
            _repository.Add(item4);

            Assert.IsFalse(_repository.Remove(item5.Id));
            Assert.IsTrue(_repository.Remove(item3.Id));

            List<TodoItem> expectedList = new List<TodoItem> { item1, item2, item4 };
            List<TodoItem> actualList = _repository.GetAll();

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            TodoItem item1 = new TodoItem("Učiii");
            TodoItem item2 = new TodoItem("Ajmo");
            TodoItem item3 = new TodoItem("Parada");
            TodoItem item4 = new TodoItem("Slava");
            TodoItem item5 = new TodoItem("armenija");

            _repository.Add(item1);
            _repository.Add(item2);
            _repository.Add(item3);
            _repository.Add(item4);

            item1.Text = "Nemoj učit";

            _repository.Update(item1);

            Assert.AreEqual(_repository.Get(item1.Id).Text, "Nemoj učit");

            _repository.Update(item5);

            List<TodoItem> expectedList = new List<TodoItem> { item1, item2, item3, item4, item5 };
            List<TodoItem> actualList = _repository.GetAll();

            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}