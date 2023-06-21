namespace PeopleApi.Dtos;

public record PersonDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Age { get; init; }
    public string Pic { get; init; }
}