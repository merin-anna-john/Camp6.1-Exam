using AssetManagementSystem_WebApi_MidExam.Models;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;

namespace AssetManagementSystem_WebApi_MidExam.Repository
{
    public class AssetRepositoryImple:IAssetRepository
    {

        //VirtualDatabase private variable 
        private readonly AssetManagementSystemDbWebApiContext _context;

        //DI
        public AssetRepositoryImple(AssetManagementSystemDbWebApiContext context)
        {
            _context = context;
        }

        #region 1.GetAllAssets
        public async Task<IEnumerable<AssetMaster>> GetAllAssets()
        {
            try
            {
                if (_context != null)
                {
                    var assets = await _context.AssetMasters
                                       .Include(a => a.AmAtype)
                                       .Include(a => a.AmAd)
                                       .Include(a => a.AmMake)
                                       .ToListAsync();
                    return assets;
                }
                return new List<AssetMaster>();
            }
            catch (Exception ex)
            {
                //return StatusCode(500, $"Internal Server Error:{ex.Message}");//500 -Internal Server Error
                throw;
            }
        }
        #endregion

        #region 2. Insert Asset and Return Asset Record

        public async Task<AssetMaster> InsertAssetReturnRecord(AssetMaster asset)
        {
            try
            {
                // Check if asset object is not null
                if (asset == null)
                {
                    throw new ArgumentNullException(nameof(asset), "Asset data is null");
                }

                // Ensure the context is not null
                if (_context == null)
                {
                    throw new InvalidOperationException("Database context is not initialized");
                }

                // Add the asset record to the DbContext
                await _context.AssetMasters.AddAsync(asset);

                // Save changes to the database
                await _context.SaveChangesAsync();

                // Retrieve the asset with the related AssetType, AssetDefinition, and Vendor
                var assetWithRelatedData = await _context.AssetMasters
                    .Include(a => a.AmAtype)        // Eager load AssetType data
                    .Include(a => a.AmAd)           // Eager load AssetDefinition data
                    .Include(a => a.AmMake)         // Eager load Vendor (Make) data
                    .FirstOrDefaultAsync(a => a.AmId == asset.AmId);

                // Return the added asset record with its related data
                return assetWithRelatedData;
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                throw new Exception($"An error occurred while inserting the asset record: {ex.Message}", ex);
            }
        }

        #endregion


        #region 3. Update Asset and Return Asset Record
        public async Task<AssetMaster> UpdateAssetReturnRecord(int id, AssetMaster asset)
        {
            try
            {
                // Ensure the context is not null
                if (_context == null)
                {
                    throw new InvalidOperationException("Database context is not initialized");
                }

                // Find the asset in the database by ID
                var existingAsset = await _context.AssetMasters.FirstOrDefaultAsync(a => a.AmId == id);

                // If asset does not exist, return null
                if (existingAsset == null)
                {
                    return null;
                }

                // Update the asset properties
                existingAsset.AmAtypeId = asset.AmAtypeId;
                existingAsset.AmMakeId = asset.AmMakeId;
                existingAsset.AmAdId = asset.AmAdId;
                existingAsset.AmModel = asset.AmModel;
                existingAsset.AmSnumber = asset.AmSnumber;
                existingAsset.AmMyyear = asset.AmMyyear;
                existingAsset.AmPdate = asset.AmPdate;
                existingAsset.AmWarranty = asset.AmWarranty;
                existingAsset.AmFrom = asset.AmFrom;
                existingAsset.AmTo = asset.AmTo;

                // Save changes to the database
                await _context.SaveChangesAsync();

                // Return the updated asset record
                return existingAsset;
            }
            catch (Exception ex)
            {
                // Log exception if necessary and rethrow
                throw new Exception($"An error occurred while updating the asset record: {ex.Message}", ex);
            }
        }
        #endregion

        #region 4.Search
        public async Task<AssetMaster> GetAssetById(int id)
        {
            try
            {
                // Ensure the context is not null
                if (_context == null)
                {
                    throw new InvalidOperationException("Database context is not initialized");
                }

                // Retrieve the asset by ID, including related entities (if needed)
                var asset = await _context.AssetMasters
                    .Include(a => a.AmAd)       // Include AssetDefinition data if needed
                    .Include(a => a.AmAtype)    // Include AssetType data if needed
                    .Include(a => a.AmMake)     // Include Vendor data if needed
                    .FirstOrDefaultAsync(a => a.AmId == id);

                return asset;  // Returns the asset if found, otherwise null
            }
            catch (Exception ex)
            {
                // Log and rethrow exception if necessary
                throw new Exception($"An error occurred while retrieving the asset with ID {id}: {ex.Message}", ex);
            }
        }
        #endregion
    }
}
