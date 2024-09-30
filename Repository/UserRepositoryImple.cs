using AssetManagementSystem_WebApi_MidExam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManagementSystem_WebApi_MidExam.Repository
{
    public class UserRepositoryImple : IUserRepository
    {
        // Private variable for the context
        private readonly AssetManagementSystemDbWebApiContext _context;

        // Dependency Injection for the database context
        public UserRepositoryImple(AssetManagementSystemDbWebApiContext context)
        {
            _context = context;
        }

        #region 1. GetAllUsers
        public async Task<IEnumerable<Login>> GetAllUsers()
        {
            try
            {
                if (_context != null)
                {
                    // Include UserRegistrations related to the Login entity
                    var users = await _context.Logins.Include(u => u.UserRegistrations).ToListAsync();
                    return users;
                }
                return new List<Login>(); // Return an empty list if context is null
            }
            catch (Exception ex)
            {
                // Handle the exception properly, optionally log it
                throw new Exception($"Internal Server Error: {ex.Message}");
            }
        }
        #endregion

        #region 2. GetUserById
        public async Task<Login> GetUserById(int id)
        {
            try
            {
                if (_context != null)
                {
                    var user = await _context.Logins.Include(u => u.UserRegistrations)
                                                    .FirstOrDefaultAsync(u => u.LId == id);
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle exception properly
                throw new Exception($"Error retrieving user by ID: {ex.Message}");
            }
        }
        #endregion

        #region 3. InsertUserReturnRecord
        public async Task<Login> InsertUserReturnRecord(UserRegistration userRegistration)
        {
            try
            {
                if (_context != null)
                {
                    // Create a new Login object
                    var login = new Login
                    {
                        Username = userRegistration.FirstName.ToLower() + userRegistration.LastName.ToLower(),
                        Password = "defaultPassword", // Set a default password or generate one
                        Usertype = "User" // Set a default user type or use a parameter
                    };

                    // Add the login and user registration to the context
                    _context.Logins.Add(login);
                    userRegistration.LId = login.LId;
                    _context.UserRegistrations.Add(userRegistration);

                    // Save changes asynchronously
                    await _context.SaveChangesAsync();

                    return login;
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle exception properly
                throw new Exception($"Error inserting user: {ex.Message}");
            }
        }
        #endregion


        #region 4. UpdateUserReturnRecord
        public async Task<Login> UpdatUserReturnRecord(int id, UserRegistration userRegistration)
        {
            try
            {
                if (_context != null)
                {
                    var login = await _context.Logins.Include(u => u.UserRegistrations)
                                                     .FirstOrDefaultAsync(u => u.LId == id);
                    if (login != null)
                    {
                        // Update the user details
                        var existingUserRegistration = await _context.UserRegistrations.FirstOrDefaultAsync(u => u.LId == id);
                        if (existingUserRegistration != null)
                        {
                            existingUserRegistration.FirstName = userRegistration.FirstName;
                            existingUserRegistration.LastName = userRegistration.LastName;
                            existingUserRegistration.Age = userRegistration.Age;
                            existingUserRegistration.Gender = userRegistration.Gender;
                            existingUserRegistration.Address = userRegistration.Address;
                            existingUserRegistration.PhoneNumber = userRegistration.PhoneNumber;

                            // Save changes asynchronously
                            await _context.SaveChangesAsync();

                            return login;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                // Handle exception properly
                throw new Exception($"Error updating user: {ex.Message}");
            }
        }

        #endregion
    }
}
