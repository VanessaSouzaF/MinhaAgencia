using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(AppDbContext context, IMapper mapper, IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }

    public async Task<UserDto> CreateUserAsync(UserCreateDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        user.Id = Guid.NewGuid();

        // Hash da senha antes de salvar
        user.Password = _passwordHasher.HashPassword(user, userDto.Password);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return _mapper.Map<UserDto>(user);
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var users = await _context.Users.ToListAsync();
        return _mapper.Map<List<UserDto>>(users);
    }

    public async Task<UserDto?> GetUserByIdAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);
        return user == null ? null : _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> UpdateUserAsync(Guid id, UserCreateDto userDto)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        user.Name = userDto.Name;
        user.Email = userDto.Email;

        // Atualiza a senha apenas se ela for enviada
        if (!string.IsNullOrEmpty(userDto.Password))
        {
            user.Password = _passwordHasher.HashPassword(user, userDto.Password);
        }

        user.RoleId = userDto.RoleId;
        user.CustomerId = userDto.CustomerId;

        await _context.SaveChangesAsync();

        return _mapper.Map<UserDto>(user);
    }

    public async Task<bool> DeleteUserAsync(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return false;
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return true;
    }
}

