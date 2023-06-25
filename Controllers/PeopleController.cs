using Microsoft.AspNetCore.Mvc;
using PeopleApi.Models;

namespace PeopleApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController :  ControllerBase
{
    [HttpPost]
    public async CreatePerson([FromBody] )
}
