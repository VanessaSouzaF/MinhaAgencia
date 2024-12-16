public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } // Descrição do papel.


    public ICollection<User>? Users { get; set; }  // Um Role pode ter muitos Users

}
