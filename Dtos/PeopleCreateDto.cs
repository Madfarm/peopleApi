namespace PeopleApi.Dtos;

public record PeopleCreateDto
{
    public string Name { get; init; }
    public int Age { get; init; }
    public string Pic { get; init; }
}