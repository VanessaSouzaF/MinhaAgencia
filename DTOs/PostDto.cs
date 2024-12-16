public class PostDto
{
    public Guid Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTime ScheduledDate { get; set; }
    public string MediaUrl { get; set; } = string.Empty;
    public bool IsPublished { get; set; }
    public DateTime? PublishedDate { get; set; }
    public Guid CustomerId { get; set; }
}

