## Step 1 - set up the project
dotnet new webapi -o <name of directory>

say yes to adding debugging and build code

dotnet new gitignore

git init
gh repo create

delete the template stuff - weatherforecast and weatherforecast controller

## Step 2 - Model
Add the mongodb driver package to our project,
dotnet add package MongoDB.Driver


make Models/<Name Of Model>.cs

put it in the approproate namespace,
<name of api>.Models;
- or - 
<name of api>.Entities;

then build the schema via properties in a record
use the [BsonId] and [BsonRepresentation(BsonType.ObjectId)] attribute on the id so that mongo's ObjectId can be representated as a string in our application,


public record ModelName
{   
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; init; }
    public type PropertyName { get; init; }
    public type PropertyName { get; init; }
    public type PropertyName { get; init; }
}



## Step 3 - Database Connection

make a Database or Settings folder and then in that folder make a MongoDBSettings.cs file
in that file,
make a namespace for the database settings, and add a class with the properties that will host the connection details

ex: 
namespace <api name>.database;

public class MongoDBSettings
{
    public string ConnectionURI { get; set;}
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }
}



in appsettings.json,
add a new object:

"MongoDB": {
    "DatabaseName":"<name of database>",
    "CollectionName": "<name of collection>"
}





initialize the .NET secret manager
dotnet user-secrets init

then add the connection string to our secrets manager with the cli
dotnet user-secrets set MongoDB:ConnectionURI "<connection string here>"



Now to gain access to these values
in Program.cs,
builder.Services.Configure<name of type here as the generic>(builder.Configuration.GetSection("<name of section>"));

ex: 
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));


now we need to create a service that actually connects to MongoDb
create Services/MongoDBService.cs

in that file,
add it to the appropriate namespace then declare a public class named MongoDBSettings and create a private readonly property that's going hold the mongo collection

ex: 
namespace <api name>.Services;

public class MongoDBSettings
{
    private readonly IMongoCollection<the model> _modelNameCollection;
}


then in the constructor for that class, pass in the IOptions object that we configured earlier and initialize the mongo client, the database, and finally the collection by grabbing the appropriate strings from the IOptions object

ex: 
namespace <api name>.Services;

public class MongoDBService
{
    private readonly IMongoCollection<the model> _modelNameCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        var client = new MongoClient(mongDBSettings.Value.ConnectionURI);
        var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        _modelNameCollection = database.GetCollection<the model>(mongoDBSettings.Value.CollectionName);
    }
}



then in program.cs,
inject the mongodbservice into the application as a dependency with the appropriate lifetime

ex:

builder.Services.AddSingleton<MongoDBService>();


## Step 4 - Set up the database interactions in the service

in the MongoDBService class, add a private readonly property for a filter definition,
private readonly FilterDefinitionBuilder<the model> filterBuilder = Builders<the model>.Filter;

then build out the crud operations for the model via methods on that class using the async task syntax


## Step 5 - Controller => Read and AsDto()

## Step 5(cont) - Controller => Create and CreateDto

## Step 5(cont) - Controller => Update and UpdateDto

## Step 5(cont) - Controller => Delete

## Step 6 - Health Checks
in program.cs, add the health check service:
builder.Services.AddHealthChecks();




then configure the endpoint for healthchecks with middleware,
app.MapHealthChecks("<url path here>");


then run this in the terminal,
dotnet add package AspNetCore.HealthChecks.MongoDb


now the health check will ping Mongo also
