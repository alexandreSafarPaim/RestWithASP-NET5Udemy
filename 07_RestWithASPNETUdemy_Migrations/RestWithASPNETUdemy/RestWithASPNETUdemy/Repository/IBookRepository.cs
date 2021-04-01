using System.Collections.Generic;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Repository
{
    public interface IBookRepository
    {
        Book Create(Book book);

        Book FindById(int id);

        List<Book> FindAll();

        Book Update(Book book);

        void Delete(int id);

        bool Exists(int id);
    }
}