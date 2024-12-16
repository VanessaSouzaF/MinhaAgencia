public class ApprovalDto
{
    public Guid Id { get; set; }
    public bool IsApproved { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public DateTime ApprovedAt { get; set; }
    public Guid PostId { get; set; }
}
