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

    public async Task<DeleteResult> DeletePerson(Guid id)
    {
       var filter = filterBuilder.Eq(person => person.Id, id);
       return await _peopleCollection.DeleteOneAsync(filter);
    }

    public async Task<Person> GetOnePerson(Guid id)
    {
        var filter = filterBuilder.Eq(person => person.Id, id);
        return await _peopleCollection.Find(filter).SingleOrDefaultAsync();
    }

    public async Task<List<Person>> GetPeople()
    {
        return await _peopleCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<ReplaceOneResult> UpdatePerson(Guid id, Person newPerson)
    {
        var filter = filterBuilder.Eq(person => person.Id, id);
        return await _peopleCollection.ReplaceOneAsync(filter, newPerson);

    }
}