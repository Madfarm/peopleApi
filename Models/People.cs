namespace PeopleApi.Models;


public record Person
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Age { get; init; }
    public string Pic { get; init; }
}