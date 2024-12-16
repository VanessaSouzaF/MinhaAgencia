public interface IRoleService
{
    Task<RoleDto> CreateRoleAsync(RoleCreateDto roleDto);
    Task UpdateRoleAsync(Guid roleId, RoleCreateDto roleDto);
    Task DeleteRoleAsync(Guid roleId);
    Task<List<RoleDto>> GetRolesAsync();
}




