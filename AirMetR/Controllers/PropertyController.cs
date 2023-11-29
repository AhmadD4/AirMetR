using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirMetR.DAL;
using AirMetR.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirMetR.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PropertyController : ControllerBase
    {
        // Dependency injection of required services
        private readonly IPropertyRepository _propertyRepository;

        private readonly ILogger<PropertyController> _logger;

        public PropertyController(IPropertyRepository propertyRepository, ILogger<PropertyController> logger)
        {
            _propertyRepository = propertyRepository;
            _logger = logger;
        }
        /// <summary>
        /// Retrieves a specific item by unique id
        /// </summary>
        /// <param name="id">The item's unique identifier</param>
        /// <returns>Returns the item with the specified id</returns>
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>?> GetAllProperties()
        {
            try
            {
                List<Property>? properties = (List<Property>?)await _propertyRepository.GetAll();
                return Ok(properties);
            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyRepository] property ToListAsync() failed when GetAll(), error message: {e}", e.Message);
                return null;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetPTypes()
        {
            var PTypes = await _propertyRepository.GetAllTypes() ?? new List<PType>();
            return Ok(PTypes);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Property>>> PropertyTypes(int id)
        {
            // Fetch properties by typeId from the repository
            List<Property>? properties = (List<Property>?)await _propertyRepository.GetAllByTypeId(id);
            if (properties == null)
            {
                _logger.LogError("[HomeController] Property list not found while executing _propertyRepository.GetAllByTypeId()");
                return NotFound("Properties list not found!");
            }

            // Return the properties as JSON
            return Ok(properties);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Property>>> List()
        {
            // Retrieve customer information using user id
            Customer? customerInfo = await _propertyRepository.Customer("2");
            List<Property>? properties = (List<Property>?)await _propertyRepository.GetAllByUserId("2");
            if (properties == null)
            {
                _logger.LogWarning("[CustomerController] Property list not found while executing _propertyRepository.GetAllByUserId()");
                return NotFound("Properties not found");
            }
            // Return both properties and customer information as JSON
            var result = new
            {
                CustomerInfo = customerInfo,
                Properties = properties
            };

            // Return the properties as JSON
            return Ok(result);
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(int id)
        {
            // Fetch the property details using the given id
            var property = await _propertyRepository.GetPropertyById(id);
            if (property == null)
            {
                // Log and return error if property not found
                _logger.LogError("[PropertyController] property not found for the PropertyId {PropertyId:0000}", id);
                return NotFound("Property not found for the PropertyId");
            }
            Customer? customerInfo = await _propertyRepository.Customer(property.CustomerId);
            // Return both properties and customer information as JSON
            var result = new
            {
                CustomerInfo = customerInfo,
                Property = property
            };

            // Return the properties as JSON
            return Ok(result);
        }

        // POST api/values
        [HttpGet]
        public async Task<IActionResult> GetCreateData()
        {
            // Fetch all property types and amenities
            var PTypes = await _propertyRepository.GetAllTypes() ?? new List<PType>();
            var Amenities = await _propertyRepository.GetAllAmenities() ?? new List<Amenity>();
            if (PTypes == null || Amenities == null)
            {
                // Log warning and return NotFound if any of these are not found
                _logger.LogWarning("[PropertyController] PTypes or Amenities Not found!");
                return NotFound("PTypes or Amenities Not found!");
            }
            else
            {
                var responseData = new
                {
                    PTypes = PTypes.Select(pt => new { pt.PTypeId, pt.PTypeName }),
                    Amenities = Amenities.Select(a => new { a.AmenityId, a.AmenityName, a.AmenityIcon })
                };
                return Ok(responseData);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Property property)
        {
            try
            {
                _logger.LogInformation("[PropertyController]property and amenities. Property: {@property}, PropertyAmenities: {@property.PropertyAmenities}", property, property.PropertyAmenities);

                // Get the user id and fetch the customer data of the currently logged-in user
                var userId = property.CustomerId;
                Customer? customer = await _propertyRepository.Customer(userId);
                if (customer == null)
                {
                    _logger.LogWarning("[PropertyController] User Not found!");
                    return NotFound("User not found!");// Handle null userId
                }

                // Handle uploaded image files
                if (property.Files != null)
                {
                    // Define the path for storing uploaded images
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "ClientApp/public/images");
                    // If the directory does not exist, create a new one
                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }

                    // Initialize a list to store property images URLs
                    List<PropertyImage> images = new();

                    // Save each uploaded file
                    foreach (var file in property.Files)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(uploads, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        images.Add(new PropertyImage { ImageUrl = $"/images/{fileName}" });
                    }

                    // Add the saved images to the property object
                    property.Images = images;
                }

                // Initialize a new property with the collected data
                var newProperty = new Property
                {
                    CustomerId = userId,
                    Title = property.Title,
                    Price = property.Price,
                    Address = property.Address,
                    Description = property.Description,
                    Guest = property.Guest,
                    Bed = property.Bed,
                    BedRooms = property.BedRooms,
                    BathRooms = property.BathRooms,
                    PTypeId = property.PTypeId,
                    Images = property.Images
                };

                // Fetch the property type associated with the new property
                newProperty.PType = await _propertyRepository.GetPType(newProperty.PTypeId) ?? new PType();

                // Handle Amenities
                if (property.SelectedAmenities != null)
                {
                    var selectedAmenities = await _propertyRepository.GetAmenitiesByIds(property.SelectedAmenities);
                    // Add the selected amenities to the property
                    foreach (var amenity in selectedAmenities)
                    {
                        newProperty.PropertyAmenities.Add(new PropertyAmenity { Amenity = amenity });
                    }
                }

                // Add the property to the database and check the return status
                bool returnOk = await _propertyRepository.Create(newProperty);

                if (returnOk)
                {
                    return Ok(new { message = "Property created successfully." });
                }
                else
                {
                    return BadRequest(new { message = "Property creation failed." });
                }
            }
            catch (Exception)
            {
                // Log any validation errors from the ModelState
                var errors = ModelState.SelectMany(x => x.Value?.Errors?.Select(p => p.ErrorMessage) ?? Enumerable.Empty<string>()).ToList();
                _logger.LogWarning("[PropertyController] Model State is not valid. Errors: {@errors}", errors);
                return BadRequest("Property creation failed.");
            }

        }

        // GET: Fetch property details for updating
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUpdateData(int id)
        {
            // Fetch property details by id
            var property = await _propertyRepository.GetPropertyById(id);
            // Check if property exists
            if (property == null)
            {
                _logger.LogError("[PropertyController] Property not found for the PropertyId {PropertyId:0000}", id);
                return NotFound(new { message = $"Property not found for the PropertyId {id}" });
            }

            // Fetch all amenities and property types
            var amenities = await _propertyRepository.GetAllAmenities() ?? new List<Amenity>();
            var pTypes = await _propertyRepository.GetAllTypes() ?? new List<PType>();
            if (pTypes == null || amenities == null)
            {
                _logger.LogWarning("[PropertyController] PTypes or Amenities Not found!");
                return NotFound(new { message = "PTypes or Amenities Not found!" });
            }

            // Create a response object
            var response = new
            {
                property = property, // Assuming this object has all the necessary details
                PTypes = pTypes.Select(pt => new { pt.PTypeId, pt.PTypeName }),
                Amenities = amenities.Select(a => new { a.AmenityId, a.AmenityName, a.AmenityIcon })
            };

            return Ok(response);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] Property updatedProperty)
        {
            try
            {
                // Fetch property by id
                var property = await _propertyRepository.GetPropertyById(id);
                if (property == null)
                {
                    _logger.LogError("[PropertyController] Property not found for the PropertyId {PropertyId:0000}", id);
                    return NotFound(new { message = "Property not found for the PropertyId" });
                }

                property.Title = updatedProperty.Title;
                property.Price = updatedProperty.Price;
                property.Address = updatedProperty.Address;
                property.Description = updatedProperty.Description;
                property.Guest = updatedProperty.Guest;
                property.Bed = updatedProperty.Bed;
                property.BedRooms = updatedProperty.BedRooms;
                property.BathRooms = updatedProperty.BathRooms;
                property.PTypeId = updatedProperty.PTypeId;

                // If there are new files/images uploaded
                if (updatedProperty.Files != null && updatedProperty.Files.Count > 0)
                {
                    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "ClientApp/public/images");
                    var newImages = new List<PropertyImage>();

                    if (!Directory.Exists(uploads))
                    {
                        Directory.CreateDirectory(uploads);
                    }

                    // Save the new images
                    foreach (var file in updatedProperty.Files)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var filePath = Path.Combine(uploads, fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        // Create new PropertyImage and add to list
                        var newImage = new PropertyImage { ImageUrl = $"/images/{fileName}", PropertyId = property.PropertyId };
                        newImages.Add(newImage);
                    }
                    // Add new images to the property
                    await _propertyRepository.AddNewImages(property.PropertyId, newImages);
                }
                // Manage Amenities
                // Remove existing amenities and add selected amenities
                await _propertyRepository.RemoveAmenitiesForProperty(property.PropertyId);
                // Handle Amenities
                if (updatedProperty.SelectedAmenities != null)
                {
                    var selectedAmenities = await _propertyRepository.GetAmenitiesByIds(updatedProperty.SelectedAmenities);
                    // Add the selected amenities to the property
                    foreach (var amenity in selectedAmenities)
                    {
                        property.PropertyAmenities.Add(new PropertyAmenity { Amenity = amenity });
                    }
                }
                // Update the property and check for success
                var result = await _propertyRepository.Update(property);
                if (result)
                {
                    return Ok(new { message = "Property updated successfully." });
                }
                else
                {
                    _logger.LogWarning("[PropertyController] Property update failed for PropertyId {PropertyId:0000}", id);
                    return BadRequest(new { message = "Failed to update property." });
                }


            }
            catch (Exception e)
            {
                _logger.LogError("[PropertyController] Error updating property: {Error}", e.Message);
                return BadRequest(new { message = "Failed to update property." });
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteImage(int id)
        {
            // Delete the image by id and get the result
            int result = await _propertyRepository.DeleteImage(id);
            if (result == -1)
            {
                _logger.LogError("[PropertyController] Image not found when deleting the PropertyId {PropertyId:0000}", id);
                return BadRequest(new { message = "Property not found for the PropertyId" });
            }

            // Return JSON response
            return Ok(new { message = "Image deleted successfully" });
        }




        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Fetch the property using the given id
            var property = await _propertyRepository.GetPropertyById(id);
            if (property == null)
            {
                // Log and return error if property not found
                _logger.LogError("[PropertyController] Property not found for the PropertyId {PropertyId:0000}", id);
                return NotFound(new { message = "Property not found for the PropertyId" });
            }

            // Delete the property and check the result
            bool returnOk = await _propertyRepository.Delete(id);
            if (!returnOk)
            {
                _logger.LogError("[PropertyController] Property deletion failed for the PropertyId {PropertyId:0000}", id);
                return BadRequest(new { message = "Property deletion failed" });
            }

            // Return a successful response
            return Ok(new { message = "Property deleted successfully" });
        }

    }
}
