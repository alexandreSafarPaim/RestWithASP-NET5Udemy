using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext _contex;

        public BookRepositoryImplementation(MySQLContext context)
        {
            //Context injection
            _contex = context;
        }

        // Method responsible for returning all people,
        public List<Book> FindAll()
        {
            return _contex.Books.ToList();
        }

        // Method responsible for returning one person by ID
        public Book FindById(int id)
        {
            return _contex.Books.FirstOrDefault(p => p.Id.Equals(id));
        }

        // Method responsible to crete one new person
        public Book Create(Book book)
        {
            try
            {
                _contex.Add(book);
                _contex.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return book;
        }

        // Method responsible for updating one person
        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;

            var result = _contex.Books.FirstOrDefault(p => p.Id.Equals(book.Id));

            if (result != null)
            {
                try
                {
                    _contex.Entry(result).CurrentValues.SetValues(book);
                    _contex.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return book;
        }

        // Method responsible for deleting a person from an ID
        public void Delete(int id)
        {
            var result = _contex.Books.FirstOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _contex.Books.Remove(result);
                    _contex.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        //Checks if a person with given id exists
        public bool Exists(int id)
        {
            return _contex.Books.Any(p => p.Id.Equals(id));
        }
    }
}