using System;
using System.Collections.Generic;
using System.Linq;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {
        private MySQLContext _contex;


        public PersonRepositoryImplementation(MySQLContext context)
        {
            //Context injection
            _contex = context;
        }

        // Method responsible for returning all people,
        public List<Person> FindAll()
        {
            return _contex.Persons.ToList();
        }

        // Method responsible for returning one person by ID
        public Person FindById(long id)
        {
            return _contex.Persons.FirstOrDefault(p => p.Id.Equals(id));
        }

        // Method responsible to crete one new person
        public Person Create(Person person)
        {
            try
            {
                _contex.Add(person);
                _contex.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        // Method responsible for updating one person
        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            var result = _contex.Persons.FirstOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _contex.Entry(result).CurrentValues.SetValues(person);
                    _contex.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return person;
        }

        // Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            var result = _contex.Persons.FirstOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _contex.Persons.Remove(result);
                    _contex.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }

        //Checks if a person with given id exists
        public bool Exists(long id)
        {
            return _contex.Persons.Any(p => p.Id.Equals(id));
        }
    }
}