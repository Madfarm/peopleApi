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

make a database folder and then in that folder make a MongoDBSettings.cs file
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


