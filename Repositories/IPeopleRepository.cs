using MongoDB.Driver;
using PeopleApi.Models;

namespace PeopleApi.Repositories;

public interface IPeopleRepository
{
    Task<IEnumerable<Person>> GetPeople();
    Task<Person> GetOnePerson();
    Task CreatePerson();
    Task<ReplaceOneResult> UpdatePerson();
    Task<DeleteResult> DeletePerson();

}