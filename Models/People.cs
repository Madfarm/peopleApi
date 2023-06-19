namespace PeopleApi.Models;


public record Person
{
    public string Name { get; init; }
    public int Age { get; init; }
    public string Pic { get; init; }
}