using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    // Criar pagamento
    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] PaymentCreateDto paymentDto)
    {
        var payment = await _paymentService.CreatePaymentAsync(paymentDto);
        return CreatedAtAction(nameof(GetPaymentById), new { id = payment.Id }, payment);
    }

    // Obter pagamentos por CustomerId
    [HttpGet("customer/{customerId:guid}")]
    public async Task<IActionResult> GetPaymentsByCustomerId(Guid customerId)
    {
        var payments = await _paymentService.GetPaymentsByCustomerIdAsync(customerId);
        return Ok(payments);
    }

    // Obter pagamentos por PostId
    [HttpGet("post/{postId:guid}")]
    public async Task<IActionResult> GetPaymentsByPostId(Guid postId)
    {
        var payments = await _paymentService.GetPaymentsByPostIdAsync(postId);
        return Ok(payments);
    }

    // Obter pagamento por ID
    [HttpGet("{paymentId:guid}")]
    public async Task<IActionResult> GetPaymentById(Guid paymentId)
    {
        var payment = await _paymentService.GetPaymentByIdAsync(paymentId);
        return Ok(payment);
    }

    // Atualizar pagamento
    [HttpPut("{paymentId:guid}")]
    public async Task<IActionResult> UpdatePayment(Guid paymentId, [FromBody] PaymentCreateDto paymentDto)
    {
        await _paymentService.UpdatePaymentAsync(paymentId, paymentDto);
        return NoContent();
    }

    // Excluir pagamento
    [HttpDelete("{paymentId:guid}")]
    public async Task<IActionResult> DeletePayment(Guid paymentId)
    {
        await _paymentService.DeletePaymentAsync(paymentId);
        return NoContent();
    }
}




