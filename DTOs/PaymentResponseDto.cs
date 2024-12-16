public class PaymentDto
{
    public Guid Id { get; set; }
    public string? TransactionId { get; set; }
    public decimal Amount { get; set; }
    public string? PaymentMethod { get; set; }
    public DateTime PaidAt { get; set; }
    public bool IsSuccessful { get; set; }
    public Guid CustomerId { get; set; }
    public Guid? PostId { get; set; }
}

