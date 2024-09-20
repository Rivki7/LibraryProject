using LibraryProjectRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryContext _libraryContext;

        public UserRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await _libraryContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllUsersAsync in UserRepository: {ex.Message}");
                return null;
            }
        }

        public async Task<User> GetUserById(int userId)
        {
            try
            {
                return await _libraryContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserByIdAsync in UserRepository: {ex.Message}");
                return null;
            }
        }

        public async Task<User> AddUser(User user)
        {
            try
            {
                _libraryContext.Users.Add(user);
                await _libraryContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddUserAsync in UserRepository: {ex.Message}");
                return null;
            }
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                _libraryContext.Entry(user).State = EntityState.Modified;
                await _libraryContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateUserAsync in UserRepository: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var user = await GetUserById(userId);
                if (user != null)
                {
                    _libraryContext.Users.Remove(user);
                    await _libraryContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteUserAsync in UserRepository: {ex.Message}");
                return false;
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            try
            {
                return await _libraryContext.Users.FirstOrDefaultAsync(u => u.Email == email); 

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserByEmail in UserRepository: {ex.Message}");
                return null;
            }
        }
    }
}
