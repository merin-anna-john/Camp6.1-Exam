using AssetManagementSystem_WebApi_MidExam.Models;

namespace AssetManagementSystem_WebApi_MidExam.Repository
{
    public interface IAssetRepository
    {
        //1.Get all Employees-Search all
        public Task<IEnumerable<AssetMaster>> GetAllAssets();
        //2.Insert
        public Task<AssetMaster> InsertAssetReturnRecord(AssetMaster asset);
        //3.Update
        public Task<AssetMaster> UpdateAssetReturnRecord(int id, AssetMaster asset);
        //4.Search
        public Task<AssetMaster> GetAssetById(int id);

    }
}
