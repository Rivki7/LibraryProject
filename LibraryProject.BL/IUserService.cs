using Entities.DTO;

namespace LibraryProjectService
{
    public interface IUserService
    {
        Task<UserDTO> AddUser(CreateUserDTO userDTO);
        Task<bool> DeleteUser(int userId);
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(int userId);
        Task<UserDTO> UpdateUser(UserDTO userDTO);
        //Task<UserDTO> LoginAsync(string email, string password);

    }
}