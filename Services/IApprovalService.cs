public interface IApprovalService
{
    Task<ApprovalDto> CreateApprovalAsync(ApprovalCreateDto approvalDto);
    Task<List<ApprovalDto>> GetAllApprovalsAsync();
    Task<ApprovalDto?> GetApprovalByIdAsync(Guid id);
    Task<ApprovalDto> UpdateApprovalAsync(Guid id, ApprovalCreateDto approvalDto);
    Task<bool> DeleteApprovalAsync(Guid id);
}


