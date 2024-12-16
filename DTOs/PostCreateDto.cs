public class PostCreateDto
{
    public string Content { get; set; } = string.Empty;
    public DateTime ScheduledDate { get; set; }
    public string MediaUrl { get; set; } = string.Empty;
    public Guid CustomerId { get; set; }
}
