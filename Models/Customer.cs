public class Customer
{
    public Guid Id { get; set; } // Identificador único
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;
    public DateTime DateRegistration { get; set; } = DateTime.UtcNow;

    // Relacionamentos
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
}

