using System.Collections.Generic;
using System.Threading.Tasks;
using EFAssignment2.Application.Dtos;

namespace EFAssignment2.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(long id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task CreateUserAsync(UserDto userDto);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(long id);
    }
}
