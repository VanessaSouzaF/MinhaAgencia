public class Payment
{
    public Guid Id { get; set; }  // Identificador único.
    public string? TransactionId { get; set; }  // Identificador da transação (opcional).
    public decimal Amount { get; set; }  // Valor do pagamento.
    public string? PaymentMethod { get; set; }  // Método de pagamento (opcional).
    public DateTime PaidAt { get; set; }  // Data e hora do pagamento.
    public bool IsSuccessful { get; set; }  // Indica se o pagamento foi bem-sucedido.

    // Relacionamento com o cliente.
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public Guid? PostId { get; set; } // FK opcional para associar um pagamento a um post.
    public Post? Post { get; set; }
}


