using AutoMapper;
using Entities.DTO;
using LibraryProject.DAL.Models;
using LibraryProjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProjectService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            try
            {
                var users = await _userRepository.GetAllUsers();
                return _mapper.Map<List<UserDTO>>(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllUsersAsync in UserService: {ex.Message}");
                return null;
            }
        }

        public async Task<UserDTO> GetUserById(int userId)
        {
            try
            {
                var user = await _userRepository.GetUserById(userId);
                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetUserByIdAsync in UserService: {ex.Message}");
                return null;
            }
        }

        public async Task<UserDTO> AddUser(UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                var addedUser = await _userRepository.AddUser(user);
                return _mapper.Map<UserDTO>(addedUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in AddUserAsync in UserService: {ex.Message}");
                return null;
            }
        }

        public async Task<UserDTO> UpdateUser(UserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                var updatedUser = await _userRepository.UpdateUser(user);
                return _mapper.Map<UserDTO>(updatedUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateUserAsync in UserService: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                return await _userRepository.DeleteUser(userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DeleteUserAsync in UserService: {ex.Message}");
                return false;
            }
        }
    }
}
