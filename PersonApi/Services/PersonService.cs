
using PersonApi.Interfaces;
using PersonApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonApi.Services
{
    public class PersonService: IPersonService
    {
        private readonly IPersonManagement _repo;
        public PersonService(IPersonManagement repo)
        {
            _repo = repo;
        }

        public async Task<Person> Create(Person person)
        {
            bool result = await _repo.AddPerson(person);
            if (result)
            {
                return person;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Delete(string id)
        {
            return  await _repo.DeletePerson(id);
        }
        public async Task<Person> Get(string id)
        {
            return await _repo.GetPerson(id);
        }

        public async Task<List<Person>> GetAll()
        {
            return await _repo.GetAllPerson();
        }

        public async Task<Person> Update(Person person)
        {
            bool result = await _repo.UpdatePerson(person);
            if (result)
            {
                return person;
            }
            else
            {
                return null;
            }
        }
    }
}
