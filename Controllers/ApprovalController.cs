using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class ApprovalsController : ControllerBase
{
    private readonly IApprovalService _approvalService;

    public ApprovalsController(IApprovalService approvalService)
    {
        _approvalService = approvalService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateApproval([FromBody] ApprovalCreateDto approvalDto)
    {
        var approval = await _approvalService.CreateApprovalAsync(approvalDto);
        return CreatedAtAction(nameof(GetApprovalById), new { id = approval.Id }, approval);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllApprovals()
    {
        var approvals = await _approvalService.GetAllApprovalsAsync();
        return Ok(approvals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetApprovalById(Guid id)
    {
        var approval = await _approvalService.GetApprovalByIdAsync(id);

        if (approval == null)
        {
            return NotFound();
        }

        return Ok(approval);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateApproval(Guid id, [FromBody] ApprovalCreateDto approvalDto)
    {
        try
        {
            var updatedApproval = await _approvalService.UpdateApprovalAsync(id, approvalDto);
            return Ok(updatedApproval);
        }
        catch (Exception ex)
        {
            return NotFound(new { Message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApproval(Guid id)
    {
        var success = await _approvalService.DeleteApprovalAsync(id);

        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
}




