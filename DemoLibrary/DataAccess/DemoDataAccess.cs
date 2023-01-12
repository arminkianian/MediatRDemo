using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary.Models;

namespace DemoLibrary.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private List<PersonModel> people = new();

        public DemoDataAccess()
        {
            people.Add(new PersonModel() { Id = 1, FirstName = "Armin", LastName = "Kianian" });
            people.Add(new PersonModel() { Id = 2, FirstName = "Milad", LastName = "Abdi" });
            people.Add(new PersonModel() { Id = 3, FirstName = "Ali", LastName = "Rashidi" });
        }

        public List<PersonModel> GetPeople()
        {
            return people;
        }

        public PersonModel InsertPerson(string firstName, string lastName)
        {
            PersonModel p = new()
            {
                Id = people.Max(p => p.Id) + 1,
                FirstName = firstName,
                LastName = lastName,
            };

            people.Add(p);

            return p;
        }
    }
}
