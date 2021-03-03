using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Data
{
    public interface IBookAPIRepo
    {
        bool SaveChanges();
        IEnumerable<Book> GetAllCommands();
        Book GetCommandById(int id);
        void CreateCommand(Book bk);
        void UpdateCommand(Book bk);
        void DeleteCommand(Book bk);

    }
}
