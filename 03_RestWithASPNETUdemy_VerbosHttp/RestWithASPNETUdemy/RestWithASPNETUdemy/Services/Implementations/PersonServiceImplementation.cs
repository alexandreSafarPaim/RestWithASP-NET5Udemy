using System;
using System.Collections.Generic;
using System.Threading;
using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            person.Id = IncrementAndGet();
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }


        public Person FindById(long id)
        {
            return new Person
            {
                Id = id,
                FirstName = "Alexandre",
                LestName = "Paim",
                Adress = "Belo Horizonte",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            Random rnd = new Random();

            string[] firstNames = { "Alexandre", "Patricia", "Berenice" };
            string[] lestNames = { "Paim", "Galacho", "Soares" };
            string[] citys = { "Belo Horizonte", "São Paulo", "Rio de Janiero" };

            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = firstNames[rnd.Next(firstNames.Length)],
                LestName = lestNames[rnd.Next(lestNames.Length)],
                Adress = citys[rnd.Next(citys.Length)],
                Gender = (i % 2 == 0) ? "Male" : "Female"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}