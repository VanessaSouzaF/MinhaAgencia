public interface IPaymentService
{
    Task<PaymentDto> CreatePaymentAsync(PaymentCreateDto paymentDto);
    Task<List<PaymentDto>> GetPaymentsByCustomerIdAsync(Guid customerId);
    Task<List<PaymentDto>> GetPaymentsByPostIdAsync(Guid postId);
    Task<PaymentDto> GetPaymentByIdAsync(Guid paymentId); // Método adicional para buscar pagamento por ID
    Task UpdatePaymentAsync(Guid paymentId, PaymentCreateDto paymentDto); // Método para atualização de pagamento
    Task DeletePaymentAsync(Guid paymentId); // Método para excluir um pagamento
}
