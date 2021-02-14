using PersonApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonApi.Interfaces
{
    // interface for the CRUD operations
    public interface IPersonManagement
    {
        // Get all available persons objects
        Task<List<Person>> GetAllPerson();
        // Get a person by Id
        Task<Person> GetPerson(string id);
        //Add a new person object to the Database
        Task<bool> AddPerson(Person person);
        // Add a list pr persons to the database
        Task<bool> AddPersons(List<Person> person);
        //Updates a person object with detaiils of the object supplied
        Task<bool> UpdatePerson(Person person);
        //Deletes a person object from database by Id
        Task<bool> DeletePerson(string id);
    }
}
