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
            return Ok(property);
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
