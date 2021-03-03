using BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Data
{
    public class SqlBookAPIRepo : IBookAPIRepo
    {
        private readonly BookContext _context;
        public SqlBookAPIRepo(BookContext context)
        {
            _context = context;
        }
        public void CreateCommand(Book bk)
        {
            if (bk == null)
            {
                throw new ArgumentNullException(nameof(bk));
            }
            _context.Books.Add(bk);
        }

        public void DeleteCommand(Book bk)
        {
            if (bk == null)
            {
                throw new ArgumentNullException(nameof(bk));
            }
            _context.Books.Remove(bk);

        }

        public IEnumerable<Book> GetAllCommands()
        {
            return _context.Books.ToList();
        }

        public Book GetCommandById(int id)
        {
            return _context.Books.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Book bk)
        {
            throw new NotImplementedException();
        }
    }
}
