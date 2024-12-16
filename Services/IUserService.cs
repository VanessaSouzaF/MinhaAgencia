public interface IUserService
{
    Task<UserDto> CreateUserAsync(UserCreateDto userDto);
    Task<List<UserDto>> GetAllUsersAsync();
    Task<UserDto?> GetUserByIdAsync(Guid id);
    Task<UserDto> UpdateUserAsync(Guid id, UserCreateDto userDto);
    Task<bool> DeleteUserAsync(Guid id);
}

