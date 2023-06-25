using Microsoft.AspNetCore.Mvc;
using PeopleApi.Dtos;
using PeopleApi.Models;
using PeopleApi.Services;

namespace PeopleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController :  ControllerBase
{
    private readonly MongoDBService _mongoDBService; 
    [HttpPost]
    public async Task<ActionResult> CreatePerson([FromBody] PeopleCreateDto peopleDto)
    {
        Person person = new()
        {
            Name = peopleDto.Name,
            Age = peopleDto.Age,
            Pic = peopleDto.Pic,
            dateCreated = DateTimeOffset.UtcNow
        };
        await _mongoDBService.CreatePerson(person);

        return CreatedAtAction(nameof(GetPeople))
    }

    public async Task<List<Person>> GetPeople()
    {
        return await _mongoDBService.GetPeople();
    }
}
