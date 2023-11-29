﻿using Microsoft.EntityFrameworkCore;
using AirMetR.Models;
using Microsoft.CodeAnalysis;

namespace AirMetR.DAL
{
    // Implementation of the IPropertyRepository interface
    public class PropertyRepository : IPropertyRepository
    {
        // Dependency injection of DbContext and Logger
        private readonly PropertyDbContext _db;
        private readonly ILogger<PropertyRepository> _logger;

        public PropertyRepository(PropertyDbContext db, ILogger<PropertyRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        // Retrieve all properties
        public async Task<IEnumerable<Property>?> GetAll()
        {
            try
            {
                return await _db.Properties.Include(p => p.Images).ToListAsync(); // Include images
            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] property ToListAsync() failed when GetAll(), error message: {e}", e.Message);
                return null;
            }

        }
        // Retrieve properties by their type id
        public async Task<IEnumerable<Property>?> GetAllByTypeId(int typeId)
        {
            try
            {
                return await _db.Properties.Where(p => p.PType.PTypeId == typeId).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] property ToListAsync() failed when GetAllByTypeId() for PropertyTypeId {PTypeId:0000}, error message: {e}", typeId, e.Message);
                return null;
            }
        }

        // Retrieve properties owned by a specific user
        public async Task<IEnumerable<Property>?> GetAllByUserId(string userId)
        {
            try
            {
                return await _db.Properties.Where(p => p.CustomerId == userId).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] property ToListAsync() failed when GetAllByUserId() for UserId {UserId:0000}, error message: {e}", userId, e.Message);
                return null;
            }
        }

        // Retrieve a single property by its id
        public async Task<Property?> GetPropertyById(int id)
        {
            try
            {
                // Include images
                return await _db.Properties.Include(p => p.Images).Include(p => p.PropertyAmenities).FirstOrDefaultAsync(i => i.PropertyId == id);

            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] property FirstOrDefaultAsync(id) failed when GetPropertyById for PropertyId {PropertyId:0000}, error message: {e}", id, e.Message);
                return null;
            }
        }

        // Creates a new property in the database
        public async Task<bool> Create(Property property)
        {
            try
            {
                _db.Properties.Add(property);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] property creation failed for property {@property}, error message: {e}", property, e.Message);
                return false;
            }
        }

        // Updates an existing in the database
        public async Task<bool> Update(Property property)
        {
            try
            {
                _db.Properties.Update(property);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] property Update(property) failed when updating the Property {Property:0000}, error message: {e}", property, e.Message);
                return false;
            }
        }

        // Deletes a property by its id
        public async Task<bool> Delete(int id)
        {
            try
            {
                var property = await _db.Properties.FindAsync(id);
                if (property == null)
                {
                    _logger.LogError("[PropertyRepository] property deletion failed for PropertyId {PropertyId:0000}, error message: {e}", id);
                    return false;
                }

                _db.Properties.Remove(property);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] property deletion failed for PropertyId {PropertyId:0000}, error message: {e}", id, e.Message);
                return false;
            }
        }

        // Adds new images to an existing property
        public async Task<bool> AddNewImages(int propertyId, List<PropertyImage> newImages)
        {
            try
            {
                await _db.PropertyImages.AddRangeAsync(newImages);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] propertyImages AddRangeAsync(newImages) failed when AddNewImages for PropertyId {PropertyId:0000}, error message: {e}", propertyId, e.Message);
                return false;
            }
        }

        // Deletes an image by its id
        public async Task<int> DeleteImage(int id)
        {
            try
            {
                var image = await _db.PropertyImages.FirstOrDefaultAsync(i => i.Id == id);
                if (image == null)
                {
                    _logger.LogError("[PropertyRepository] propertyImages FirstOrDefaultAsync(id) failed when DeleteImage for ImageId {ImageId:0000}", id);
                    return -1;
                }

                // Delete the image file from the server
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", image.ImageUrl.TrimStart('/'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                // Delete the image record from the database
                _db.PropertyImages.Remove(image);
                await _db.SaveChangesAsync();

                return image.PropertyId;
            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] propertyImages deletion failed for ImageId {ImageId:0000}, error message: {e}", id, e.Message);
                return -1;
            }
        }

        // Retrieves property type details by its id
        public async Task<PType?> GetPType(int id)
        {
            try
            {
                return await _db.PTypes.FindAsync(id);

            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] PTypes FindAsync(id) failed when GetPType for Id {Id:0000}, error message: {e}", id, e.Message);
                return null;
            }
        }

        // Retrieves all available property types
        public async Task<IEnumerable<PType>?> GetAllTypes()
        {
            try
            {
                return await _db.PTypes.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] PTypes ToListAsync() failed when GetAllTypes(), error message: {e}", e.Message);
                return null;
            }
        }


        public async Task<List<Amenity>> GetAmenitiesByIds(List<int> amenityIds)
        {
            return await _db.Amenities
                                 .Where(a => amenityIds.Contains(a.AmenityId))
                                 .ToListAsync();
        }

        // Retrieves all available amenities
        public async Task<IEnumerable<Amenity>?> GetAllAmenities()
        {
            try
            {
                return await _db.Amenities.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] Amenities ToListAsync() failed when GetAllAmenities(), error message: {e}", e.Message);
                return null;
            }
        }

        // Removes all amenities for a specific property
        public async Task<bool> RemoveAmenitiesForProperty(int propertyId)
        {
            try
            {
                var existingAmenities = await _db.PropertyAmenities.Where(pa => pa.PropertyId == propertyId).ToListAsync();

                if (existingAmenities == null)
                {
                    _logger.LogError("[PropertyRepository] propertyAmenities deletion failed for PropertyId {PropertyId:0000}, error message: {e}", propertyId);
                    return false;
                }

                _db.PropertyAmenities.RemoveRange(existingAmenities);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] AmenitiesForProperty deletion failed for Property {PropertyId:0000}, error message: {e}", propertyId, e.Message);
                return false;
            }
        }

        // Adds selected amenities to a specific property
        public async Task<bool> AddAmenitiesToProperty(int propertyId, List<Amenity> selectedAmenities)
        {
            try
            {
                // Fetch the property entity from the database
                var property = await _db.Properties.Include(p => p.PropertyAmenities).SingleOrDefaultAsync(p => p.PropertyId == propertyId);

                if (property == null)
                {
                    _logger.LogError("[PropertyRepository] property Not found for PropertyId {PropertyId:0000}, error message: {e}", propertyId);
                    return false;
                }

                // Initialize PropertyAmenities if it's null
                if (property.PropertyAmenities == null)
                {
                    property.PropertyAmenities = new List<PropertyAmenity>();
                }

                // Add the selected amenities
                foreach (var amenity in selectedAmenities)
                {
                    property.PropertyAmenities.Add(new PropertyAmenity { PropertyId = propertyId, AmenityId = amenity.AmenityId });
                }

                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] AmenitiesForProperty add failed for Property {PropertyId:0000}, error message: {e}", propertyId, e.Message);
                return false;
            }
        }
        // Retrieves customer details by their id
        public async Task<Customer?> Customer(string customerId)
        {
            try
            {
                Customer? customer = await _db.Customers.Where(p => p.CustomerId == customerId).FirstOrDefaultAsync();
                if (customer == null)
                {
                    _logger.LogError("[PropertyRepository] customer not found for customerId {customerId:0000}, error message: {e}", customerId);
                    return null;
                }
                return customer;

            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] customer FirstOrDefaultAsync() failed when Customer for customerId {CustomerId:0000}, error message: {e}", customerId, e.Message);
                return null;
            }
        }

    }

}
