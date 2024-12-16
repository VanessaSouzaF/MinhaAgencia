using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class PaymentService : IPaymentService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public PaymentService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaymentDto> CreatePaymentAsync(PaymentCreateDto paymentDto)
    {
        var payment = _mapper.Map<Payment>(paymentDto);
        payment.Id = Guid.NewGuid();
        payment.PaidAt = DateTime.UtcNow; // Definir a data de pagamento

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        return _mapper.Map<PaymentDto>(payment);
    }

    public async Task<List<PaymentDto>> GetPaymentsByCustomerIdAsync(Guid customerId)
    {
        var payments = await _context.Payments
            .Where(p => p.CustomerId == customerId)
            .ToListAsync();

        return _mapper.Map<List<PaymentDto>>(payments);
    }

    public async Task<List<PaymentDto>> GetPaymentsByPostIdAsync(Guid postId)
    {
        var payments = await _context.Payments
            .Where(p => p.PostId == postId)  // Caso a entidade Post tenha o relacionamento com o Payment
            .ToListAsync();

        return _mapper.Map<List<PaymentDto>>(payments);
    }

    public async Task<PaymentDto> GetPaymentByIdAsync(Guid paymentId)
    {
        var payment = await _context.Payments
            .FirstOrDefaultAsync(p => p.Id == paymentId);

        if (payment == null)
        {
            throw new KeyNotFoundException("Payment not found.");
        }

        return _mapper.Map<PaymentDto>(payment);
    }

    public async Task UpdatePaymentAsync(Guid paymentId, PaymentCreateDto paymentDto)
    {
        var existingPayment = await _context.Payments
            .FirstOrDefaultAsync(p => p.Id == paymentId);

        if (existingPayment == null)
        {
            throw new KeyNotFoundException("Payment not found.");
        }

        _mapper.Map(paymentDto, existingPayment); // Atualiza os campos do pagamento
        await _context.SaveChangesAsync();
    }

    public async Task DeletePaymentAsync(Guid paymentId)
    {
        var payment = await _context.Payments
            .FirstOrDefaultAsync(p => p.Id == paymentId);

        if (payment == null)
        {
            throw new KeyNotFoundException("Payment not found.");
        }

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
    }
}



