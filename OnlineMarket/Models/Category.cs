namespace IT_RunCourseSecondPartAPI.Models;

public class Category : IEntity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public string Name { get; set; } = string.Empty;
    public List<Product>? Products { get; set; }
    public bool IsDeleted { get; set; }
}