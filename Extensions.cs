using PeopleApi.Dtos;
using PeopleApi.Models;

namespace PeopleApi;

public static class Extensions
{
    public static PersonDto AsDto(this Person person)
    {
         return new PersonDto
         {
            Id = person.Id,
            Name = person.Name,
            Age = person.Age,
            Pic = person.Pic
         };
    }
}