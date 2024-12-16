public interface ICustomerService
{
    Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto customerDto);
    Task<List<CustomerDto>> GetAllCustomersAsync();
    Task<CustomerDto?> GetCustomerByIdAsync(Guid id);
    Task<CustomerDto> UpdateCustomerAsync(Guid id, CustomerCreateDto customerDto);
    Task<bool> DeleteCustomerAsync(Guid id);
}

