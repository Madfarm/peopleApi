using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PeopleApi.Database;
using PeopleApi.Models;

namespace PeopleApi.Services;

public class MongoDBService
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
}