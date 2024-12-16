using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class RoleService : IRoleService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public RoleService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RoleDto> CreateRoleAsync(RoleCreateDto roleDto)
    {
        var role = _mapper.Map<Role>(roleDto);
        role.Id = Guid.NewGuid();

        _context.Roles.Add(role);
        await _context.SaveChangesAsync();

        return _mapper.Map<RoleDto>(role);
    }

    public async Task UpdateRoleAsync(Guid roleId, RoleCreateDto roleDto)
    {
        var existingRole = await _context.Roles.FindAsync(roleId);
        if (existingRole == null)
        {
            throw new KeyNotFoundException("Role not found.");
        }

        _mapper.Map(roleDto, existingRole); // Atualiza os campos
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRoleAsync(Guid roleId)
    {
        var role = await _context.Roles.FindAsync(roleId);
        if (role == null)
        {
            throw new KeyNotFoundException("Role not found.");
        }

        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
    }

    public async Task<List<RoleDto>> GetRolesAsync()
    {
        var roles = await _context.Roles.ToListAsync();
        return _mapper.Map<List<RoleDto>>(roles);
    }
}


