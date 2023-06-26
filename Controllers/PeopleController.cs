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

    public PeopleController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    } 
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

        return CreatedAtAction(nameof(GetPeople), new {id = person.Id}, person.AsDto());
    }
    [HttpGet]
    public async Task<List<Person>> GetPeople()
    {
        return await _mongoDBService.GetPeople();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDto>> GetOnePerson(Guid id)
    {
        var existingPerson = await _mongoDBService.GetOnePerson(id);

        if (existingPerson is null)
        {
            return NoContent();
        }

        return existingPerson.AsDto();
    }
}
