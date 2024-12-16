public class ApprovalCreateDto
{
    public bool IsApproved { get; set; }
    public string? Status { get; set; } = "Pending";
    public string? Comments { get; set; }
    public DateTime ApprovedAt { get; set; } = DateTime.UtcNow;
    public Guid PostId { get; set; }
}
