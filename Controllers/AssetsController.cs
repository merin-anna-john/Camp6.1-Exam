using AssetManagementSystem_WebApi_MidExam.Models;
using AssetManagementSystem_WebApi_MidExam.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagementSystem_WebApi_MidExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {

        //call repository
        private readonly IAssetRepository _repository;

        //DI
        public AssetsController(IAssetRepository repository)
        {
            _repository = repository;
        }

        #region 1. Get All Assets - Search All - api/assets
        [HttpGet("assets")]
        public async Task<ActionResult<IEnumerable<AssetMaster>>> GetAllAssets()
        {
            var assets = await _repository.GetAllAssets();
            if (assets == null || !assets.Any())
            {
                return NotFound("No assets found");
            }
            return Ok(assets);
        }
        #endregion


        #region 2. Insert an Asset - Return Asset Record
        [HttpPost("asset")]
        public async Task<ActionResult<AssetMaster>> InsertNewAssetReturn(AssetMaster asset)
        {
            try
            {
                // Check if the asset is valid
                if (!ModelState.IsValid)
                {
                    // Return the validation errors
                    return BadRequest(ModelState);
                }

                // Insert a new asset record and return the object named asset
                var newAsset = await _repository.InsertAssetReturnRecord(asset);

                // If the asset object is successfully created, return 201 Created
                if (newAsset != null)
                {
                    return Ok(newAsset);
                }

                // If the asset could not be inserted, return NotFound
                return NotFound("Asset could not be created");
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error with the exception message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

        #region 3. Update an Asset with ID and asset - Return Asset
        [HttpPut("{id}")]  
        public async Task<ActionResult<AssetMaster>> UpdateAssetReturnRecord(int id, AssetMaster asset)
        {
            try
            {
                // Check if the asset is valid
                if (!ModelState.IsValid)
                {
                    // Return the validation errors
                    return BadRequest(ModelState);
                }

                // Update the asset record and return the updated object
                var updatedAsset = await _repository.UpdateAssetReturnRecord(id, asset);

                // If the asset could not be updated, return NotFound
                if (updatedAsset == null)
                {
                    return NotFound("Asset not found");
                }

                // If the asset object is successfully updated, return 200 OK
                return Ok(updatedAsset);
            }
            catch (Exception ex)
            {
                // Return a 500 Internal Server Error with the exception message
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

        #region 4.Get Asset - Search Asset by id
        //https://localhost:7022/api/assets/3 
        [HttpGet("{id}")] //{} interpolation - passing value along with URL/endpoint
        public async Task<ActionResult<AssetMaster>> GetAssetById(int id)
        {
            var asset = await _repository.GetAssetById(id);
            if (asset == null)
            {
                return NotFound($"Asset with ID {id} not found.");
            }
            return Ok(asset);
        }
        #endregion

    }
}
