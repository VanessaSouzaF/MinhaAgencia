using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class CustomerService : ICustomerService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper; // Usando AutoMapper para simplificar

    public CustomerService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDto> CreateCustomerAsync(CustomerCreateDto customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        customer.Id = Guid.NewGuid();
        customer.DateRegistration = DateTime.UtcNow;

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<List<CustomerDto>> GetAllCustomersAsync()
    {
        var customers = await _context.Customers.ToListAsync();
        return _mapper.Map<List<CustomerDto>>(customers);
    }

    public async Task<CustomerDto?> GetCustomerByIdAsync(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);
        return customer == null ? null : _mapper.Map<CustomerDto>(customer);
    }

    public async Task<CustomerDto> UpdateCustomerAsync(Guid id, CustomerCreateDto customerDto)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer == null)
        {
            throw new Exception("Customer not found");
        }

        customer.Name = customerDto.Name;
        customer.Email = customerDto.Email;
        customer.Telephone = customerDto.Telephone;

        await _context.SaveChangesAsync();

        return _mapper.Map<CustomerDto>(customer);
    }

    public async Task<bool> DeleteCustomerAsync(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);

        if (customer == null)
        {
            return false;
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return true;
    }
}


