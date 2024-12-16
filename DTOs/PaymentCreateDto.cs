public class PaymentCreateDto
{
    public decimal Amount { get; set; }
    public string? PaymentMethod { get; set; }
    public Guid CustomerId { get; set; }
    public Guid? PostId { get; set; } // Se aplicável.
}
