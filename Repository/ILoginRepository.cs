using AssetManagementSystem_WebApi_MidExam.Models;

namespace AssetManagementSystem_WebApi_MidExam.Repository
{
    public interface ILoginRepository
    {
        //get user details by using username and password
        public Task<Login> ValidateUser(string username, string password);
    }
}
