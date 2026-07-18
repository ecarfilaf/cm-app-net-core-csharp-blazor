namespace frontend.Services;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = "Viewer";
    public bool Active { get; set; } = true;
    public DateOnly CreatedAt { get; set; }
}
