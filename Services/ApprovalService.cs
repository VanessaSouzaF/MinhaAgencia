using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class ApprovalService : IApprovalService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ApprovalService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ApprovalDto> CreateApprovalAsync(ApprovalCreateDto approvalDto)
    {
        var approval = _mapper.Map<Approval>(approvalDto);
        approval.Id = Guid.NewGuid();

        _context.Approvals.Add(approval);
        await _context.SaveChangesAsync();

        return _mapper.Map<ApprovalDto>(approval);
    }

    public async Task<List<ApprovalDto>> GetAllApprovalsAsync()
    {
        var approvals = await _context.Approvals.ToListAsync();
        return _mapper.Map<List<ApprovalDto>>(approvals);
    }

    public async Task<ApprovalDto?> GetApprovalByIdAsync(Guid id)
    {
        var approval = await _context.Approvals.FindAsync(id);
        return approval == null ? null : _mapper.Map<ApprovalDto>(approval);
    }

    public async Task<ApprovalDto> UpdateApprovalAsync(Guid id, ApprovalCreateDto approvalDto)
    {
        var approval = await _context.Approvals.FindAsync(id);

        if (approval == null)
        {
            throw new Exception("Approval not found");
        }

        approval.IsApproved = approvalDto.IsApproved;
        approval.Status = approvalDto.Status;
        approval.Comments = approvalDto.Comments;
        approval.ApprovedAt = approvalDto.ApprovedAt;
        approval.PostId = approvalDto.PostId;

        await _context.SaveChangesAsync();

        return _mapper.Map<ApprovalDto>(approval);
    }

    public async Task<bool> DeleteApprovalAsync(Guid id)
    {
        var approval = await _context.Approvals.FindAsync(id);

        if (approval == null)
        {
            return false;
        }

        _context.Approvals.Remove(approval);
        await _context.SaveChangesAsync();

        return true;
    }
}



