using Microsoft.AspNetCore.Mvc;
using PeopleApi.Models;

namespace PeopleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController :  ControllerBase
{
    [HttpGet]
    public IEnumerable<Person> GetPeople()
    {
        List<Person> people = new()
        {
            new Person { Id= new Guid() , Name = "Matt", Age = 6, Pic = "https://placekitten.com/200/300" },
            new Person { Id= new Guid() , Name = "Hiomno", Age = 57, Pic = "https://placekitten.com/200/300" },
            new Person { Id= new Guid() , Name = "Cry-sis", Age = 21, Pic = "https://placekitten.com/200/300" },
            new Person { Id= new Guid() , Name = "Simpman", Age = 35, Pic = "https://placekitten.com/300/200" }
        };
        return people;
    }
}
