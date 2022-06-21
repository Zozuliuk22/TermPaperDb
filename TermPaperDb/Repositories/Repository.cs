using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Migrations;
using TermPaperDb.Interfaces;

namespace TermPaperDb.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IS02_SellingRailwayTicketsEntities _context;

        public Repository()
        {
            _context = new IS02_SellingRailwayTicketsEntities();
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T item)
        {
            _context.Set<T>().AddOrUpdate(item);
            _context.SaveChanges();
        }
    }
}