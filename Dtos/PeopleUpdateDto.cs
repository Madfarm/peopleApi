namespace PeopleApi.Dtos;

public record PeopleUpdateDto
{
    public string Name { get; init; }
    public int Age { get; init; }
    public string Pic { get; init; }
}