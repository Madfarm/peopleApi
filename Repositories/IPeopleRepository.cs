using MongoDB.Driver;
using PeopleApi.Dtos;
using PeopleApi.Models;

namespace PeopleApi.Repositories;

public interface IPeopleRepository
{
    Task<List<Person>> GetPeople();
    Task<Person> GetOnePerson();
    Task CreatePerson(Person person);
    Task<ReplaceOneResult> UpdatePerson();
    Task<DeleteResult> DeletePerson();

}