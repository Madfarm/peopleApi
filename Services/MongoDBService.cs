using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PeopleApi.Database;
using PeopleApi.Models;
using PeopleApi.Repositories;

namespace PeopleApi.Services;

public class MongoDBService : IPeopleRepository
{
    private readonly IMongoCollection<Person> _peopleCollection;
    private readonly FilterDefinitionBuilder<Person> filterBuilder = Builders<Person>.Filter;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        var client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        var database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _peopleCollection = database.GetCollection<Person>(mongoDBSettings.Value.CollectionName);

        System.Console.WriteLine(_peopleCollection);
    }

    public async Task CreatePerson(Person person)
    {
        await _peopleCollection.InsertOneAsync(person);
        return;
    }

    public Task<DeleteResult> DeletePerson()
    {
        throw new NotImplementedException();
    }

    public Task<Person> GetOnePerson()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Person>> GetPeople()
    {
        throw new NotImplementedException();
    }

    public Task<ReplaceOneResult> UpdatePerson()
    {
        throw new NotImplementedException();
    }
}