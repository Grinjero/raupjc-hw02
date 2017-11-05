using System.Collections;
using System.Collections.Generic;

namespace StudentLibrary
{
    public interface IGenericList <X> : IEnumerable <X>
    {
        void Add(X item);

        bool Remove(X item);

        bool RemoveAt(int index);

        X GetElement(int index);

        int IndexOf(X item);

        int Count { get; }

        void Clear();

        bool Contains(X item);
    }
}
