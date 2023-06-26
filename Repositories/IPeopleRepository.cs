using MongoDB.Driver;
using PeopleApi.Dtos;
using PeopleApi.Models;

namespace PeopleApi.Repositories;

public interface IPeopleRepository
{
    Task<List<Person>> GetPeople();
    Task<Person> GetOnePerson(Guid id);
    Task CreatePerson(Person person);
    Task<ReplaceOneResult> UpdatePerson(Guid id, Person person);
    Task<DeleteResult> DeletePerson(Guid id);

}