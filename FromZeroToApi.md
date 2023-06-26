## Step 1 - set up the project
dotnet new webapi -o <name of directory>

say yes to adding debugging and build code

dotnet new gitignore

git init
gh repo create

delete the template stuff - weatherforecast and weatherforecast controller

## Step 2 - Database Connection
dotnet add package MongoDB.Driver

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

initialize the .NET secret manager
dotnet users-secrets init

in appsettings.json,
add a new object

in Program.cs,




