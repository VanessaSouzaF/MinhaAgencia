public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty; // Deve ser armazenada de forma segura

    public Guid RoleId { get; set; } // Chave estrangeira para Role
    public Role? Role{ get; set; }
    public Guid CustomerId { get; set;}
    public Customer? Customer { get; set; }


}
