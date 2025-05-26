namespace IT_RunCourseSecondPartAPI.Models;

public class Category : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}