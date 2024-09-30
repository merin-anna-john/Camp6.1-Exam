using AssetManagementSystem_WebApi_MidExam.Models;
using Microsoft.EntityFrameworkCore;

namespace AssetManagementSystem_WebApi_MidExam.Repository
{
    public class LoginRepositoryImple : ILoginRepository
    {
       
        //VirtualDatabase private variable 
        private readonly AssetManagementSystemDbWebApiContext _context;

        //DI
        public LoginRepositoryImple(AssetManagementSystemDbWebApiContext context)
        {
            _context = context;
        }

        public async Task<Login> ValidateUser(string username, string password)
        {

            try
            {
                if (_context != null)
                {
                    var dbUser = await _context.Logins.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

                    if (dbUser != null)
                    {
                        return dbUser;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                //return StatusCode(500, $"Internal Server Error:{ex.Message}");//500 -Internal Server Error
                throw;
            }
        }
    }
}

