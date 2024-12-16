
public class CustomerDto
{
    public Guid Id { get; set; }  // Certifique-se de que a propriedade Id existe
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;
    public DateTime DateRegistration { get; set; }

}