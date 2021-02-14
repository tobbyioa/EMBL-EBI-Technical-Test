using PersonApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonApi.Interfaces
{
    public interface IPersonService
    {
        Task<Person> Create(Person person);
        Task<Person> Get(string id);
        Task<List<Person>> GetAll();
        Task<Person> Update(Person person);
        Task<bool> Delete(string id);
    }
}
