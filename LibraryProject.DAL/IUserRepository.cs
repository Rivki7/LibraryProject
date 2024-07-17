using LibraryProject.DAL.Models;

namespace LibraryProjectRepository
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<bool> DeleteUser(int userId);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int userId);
        Task<User> UpdateUser(User user);

      
    }
}