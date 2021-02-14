using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonApi.Database;
using PersonApi.Interfaces;
using PersonApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonApi.Repositories
{
    public class PersonManagement: IPersonManagement
    {
        private readonly IServiceScope _serviceScope;
        private readonly ApplicationDbContext _db;
        public PersonManagement(IServiceProvider services)
        {
            _serviceScope = services.CreateScope();
            _db = _serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }

        public async Task<bool> AddPerson(Person person)
        {
            bool result = false;
            _db.Persons.AddRange(person);
            int numCreated = await _db.SaveChangesAsync();
            if (numCreated == 1)
                result = true;
            return result;
        }

        public async Task<bool> AddPersons(List<Person> person)
        {
            bool result = false;
            _db.Persons.AddRange(person);
            int numCreated = await _db.SaveChangesAsync();
            if (numCreated >= 1)
                result = true;
            return result;
        }

        public async Task<bool> DeletePerson(string id)
        {
            Person p = await _db.Persons.FindAsync(id);
            bool result = false;
            _db.Persons.Remove(p);
            int numCreated = await _db.SaveChangesAsync();
            if (numCreated >= 1)
                result = true;
            return result;
        }

        public async Task<List<Person>> GetAllPerson()
        {
            List<Person> ps = await _db.Persons.ToListAsync();
            return ps;
        }

        public async Task<Person> GetPerson(string id)
        {
            Person p = await _db.Persons.FindAsync(id);
            return p;
        }

        public async Task<bool> UpdatePerson(Person person)
        {
            bool result = false;
            _db.Persons.Update(person);
            int numCreated = await _db.SaveChangesAsync();
            if (numCreated >= 1)
                result = true;
            return result;
        }
    }
}
