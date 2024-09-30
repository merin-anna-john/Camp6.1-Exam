using AssetManagementSystem_WebApi_MidExam.Models;

namespace AssetManagementSystem_WebApi_MidExam.Repository
{
    public interface IUserRepository
    {
        //1.Get all Users - using ViewModel
        public Task<IEnumerable<Login>> GetAllUsers();

        //2.Insert a User - Return Employee Record
        public Task<Login> InsertUserReturnRecord(UserRegistration userRegistration);

        //3.Update an User with ID and employee - Return Employee
        public Task<Login> UpdatUserReturnRecord(int id, UserRegistration userRegistration);

        //4.Search User by id
        public Task<Login> GetUserById(int id);

    }
}
