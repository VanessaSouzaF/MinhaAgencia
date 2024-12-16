public class Post
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime ScheduledDate { get; set; }
    public string MediaUrl { get; set; } = string.Empty;
    public bool IsPublished { get; set; }
    public DateTime PublishedDate { get; set; }

    // Relacionamentos
    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public ICollection<Approval> Approvals { get; set; } = new List<Approval>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();

}

