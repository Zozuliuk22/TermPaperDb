using System.Collections.Generic;

namespace TermPaperDb.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);

        IEnumerable<T> GetAll();

        void Update(T item);

        void Delete(T item);
    }
}
