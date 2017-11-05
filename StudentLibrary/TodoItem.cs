using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary
{
    public class TodoItem
    {

        public Guid Id { get; set; }
        public string Text { get; set; }

        public bool isCompleted
        {
            get
            {
                return DateCompleted.HasValue;
            }
        }

        public DateTime? DateCompleted { get; set; }

        public DateTime DateCreated { get; set; }

        public bool MarkAsCompleted()
        {
            if(!isCompleted)
            {
                DateCompleted = DateTime.Now;
                return true;
            }
            return false;
        }

        public TodoItem(string text)
        {
            Id = Guid.NewGuid();

            DateCreated = DateTime.UtcNow;

            Text = text;
        }


        public override bool Equals(object obj)
        {
            if(obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            TodoItem other = (TodoItem)obj;

            return other.Id.Equals(this.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
