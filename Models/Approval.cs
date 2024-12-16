public class Approval
{
    public Guid Id { get; set; }  // Identificador único da aprovação
    public bool IsApproved { get; set; }  // Status da aprovação (aprovado ou não)
    public string? Status { get; set; } = "Pending";// Status adicional, como 'pendente', 'aprovado', 'rejeitado', etc.

    public string? Comments { get; set; }  // Comentários adicionais sobre a aprovação
    public DateTime ApprovedAt { get; set; }  // Data e hora da aprovação
    public Guid PostId { get; set; }  // Chave estrangeira para o Post ou outro objeto que está sendo aprovado
    public Post? Post { get; set; }  // Relacionamento com o Post
}


