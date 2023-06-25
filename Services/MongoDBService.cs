using Microsoft.Extensions.Options;
using MongoDB.Bson;
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

    public async Task<List<Person>> GetPeople()
    {
        return await _peopleCollection.Find(new BsonDocument()).ToListAsync();
    }

    public Task<ReplaceOneResult> UpdatePerson()
    {
        throw new NotImplementedException();
    }
}