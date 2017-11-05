using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary
{
    public interface ITodoRepository
    {
        /// <summary >
        /// Gets TodoItem for a given id
        /// </ summary >
        /// <returns > TodoItem if found , null otherwise </ returns >
        TodoItem Get(Guid todoId);

        /// <summary >
        /// Adds new TodoItem object in database .
        /// If object with the same id already exists ,
        /// method should throw DuplicateTodoItemException with the message" duplicate id: {id }".
        /// </ summary >
        /// <returns > TodoItem that was added </ returns >
        TodoItem Add(TodoItem todoItem);

        /// <summary >
        /// Tries to remove a TodoItem with given id from the database .
        /// </ summary >
        /// <returns > True if success , false otherwise </ returns >
        bool Remove(Guid todoId);

        /// <summary >
        /// Updates given TodoItem in the database .
        /// If TodoItem does not exist , method will add one .
        /// </ summary >
        /// <returns > TodoItem that was updated </ returns >
        TodoItem Update(TodoItem todoItem);

        /// <summary >
        /// Tries to mark a TodoItem as completed in the database .
        /// </ summary >
        /// <returns > True if success , false otherwise </ returns >
        bool MarkAsCompleted(Guid todoId);

        /// <summary >
        /// Gets all TodoItem objects in the database , sorted by date created (descending )
        /// </ summary >
        List<TodoItem> GetAll () ;

        /// <summary >
        /// Gets all incomplete TodoItem objects in the database
        /// </ summary >
        List<TodoItem> GetActive();

        /// Gets all completed TodoItem objects in the database
        /// </ summary >
        List<TodoItem> GetCompleted();

        /// <summary >
        /// Gets all TodoItem objects in database that apply to the filter
        /// </ summary >
        List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction);
    }

    public class TodoRepository : ITodoRepository
    {
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if(_inMemoryTodoDatabase.Contains(todoItem))
            {
                throw new DuplicateTodoItemException("Item already exists within this database");
            }

            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public TodoItem Get(Guid todoId)
        {
            List<TodoItem> list = (from todoItem in _inMemoryTodoDatabase
                   where todoItem.Id.Equals(todoId)
                   select todoItem).ToList();

            if(list.Count == 0)
            {
                return null;
            } else
            {
                return list.First();
            }
        }

        public List<TodoItem> GetActive()
        {
            List<TodoItem> list = (from todoItem in _inMemoryTodoDatabase
                                  where todoItem.isCompleted == false
                                  select todoItem).ToList();
            return list;
        }

        public List<TodoItem> GetAll()
        {
            List<TodoItem> list = (from todoItem in _inMemoryTodoDatabase
                                   select todoItem).ToList();
            return list;
        }

        public List<TodoItem> GetCompleted()
        {
            List<TodoItem> list = (from todoItem in _inMemoryTodoDatabase
                                   where todoItem.isCompleted == true
                                   select todoItem).ToList();
            return list;
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            List<TodoItem> list = (from todoItem in _inMemoryTodoDatabase
                                   where filterFunction.Invoke(todoItem)
                                   select todoItem).ToList();
            return list;
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            TodoItem item = Get(todoId);
            return item.MarkAsCompleted();
        }

        public bool Remove(Guid todoId)
        {
            TodoItem toRemove = Get(todoId);
            return _inMemoryTodoDatabase.Remove(toRemove);
        }

        public TodoItem Update(TodoItem todoItem)
        {
            TodoItem updated = Get(todoItem.Id);

            if (updated == null)
            {
                _inMemoryTodoDatabase.Add(todoItem);
                return todoItem;
            }
            else
            {
                updated.DateCreated = todoItem.DateCreated;
                updated.DateCompleted = todoItem.DateCompleted;
                updated.Text = todoItem.Text;
                return updated;
            }
        }
    }

    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException()
        {
        }

        public DuplicateTodoItemException(string message) : base(message)
        {
        }

        public DuplicateTodoItemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateTodoItemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
