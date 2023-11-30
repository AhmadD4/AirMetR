using System;
using AirMetR.Controllers;
using AirMetR.DAL;
using AirMetR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Moq;
using Property = AirMetR.Models.Property;

namespace XUnitTestAirMetR.Controllers
{
	public class PropertyControllerTest
	{
        private readonly Mock<IPropertyRepository> _mockRepository;
        private readonly Mock<ILogger<PropertyController>> _mockLogger;
        private readonly PropertyController _controller;

        public PropertyControllerTest()
        {
            _mockRepository = new Mock<IPropertyRepository>();
            _mockLogger = new Mock<ILogger<PropertyController>>();
            _controller = new PropertyController(_mockRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllPropertiesTest()
        {
            // Arrange
            var mockProperties = new List<Property>()
            {
                    new Property
                    {
                        Title = "Home",
                        Price = 2000,
                        Address = "Bro Sweden",
                        Description = "Cozy house featuring a comfortable bedroom, well-equipped kitchen, and a refreshing pool, perfect for a relaxing getaway.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 5,
                        CustomerId = "1",


                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 2500,
                        Address = "Oslo Norway",
                        Description = "Welcome to our charming home with a refreshing pool outside, perfect for leisurely afternoons. Enjoy the convenience of a fully-equipped kitchen, two cozy bedrooms with double beds, and a well-maintained bathroom. Relax and unwind in the tranquil ambiance of this inviting space, designed to make your stay memorable and comfortable.",
                        Guest = 4,
                        Bed = 2,
                        BedRooms = 2,
                        BathRooms = 1,
                        PTypeId = 5,
                        CustomerId = "1",


                    },
                    new Property
                    {
                        Title = "Home",
                        Price = 3500,
                        Address = "Dal Norway",
                        Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                        Guest= 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 1,
                        CustomerId = "2",

                    }
            };
            _mockRepository.Setup(repo => repo.GetAll()).ReturnsAsync(mockProperties);

            // Act
            var result = await _controller.GetAllProperties();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result?.Result);
            var returnValue = Assert.IsType<List<Property>>(actionResult.Value);
            Assert.Equal(mockProperties.Count, returnValue.Count);
        }

        [Fact]
        public async Task GetPTypesTest()
        {
            // Arrange
            var mockPTypes = new List<PType>()
            {
                   new PType { PTypeName = "House", PTypeIcon = "fas fa-house-user" },
                   new PType { PTypeName = "Cabins", PTypeIcon = "fas fa-dungeon" },
                   new PType { PTypeName = "Domes", PTypeIcon = "fas fa-campground" },
            };

            _mockRepository.Setup(repo => repo.GetAllTypes()).ReturnsAsync(mockPTypes);

            // Act
            var result = await _controller.GetPTypes();

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<PType>>(actionResult.Value);
            Assert.Equal(mockPTypes.Count, returnValue.Count);
        }

        [Fact]
        public async Task PropertyTypesOkTest()
        {
            // Arrange
            var typeId = 1; // Example type ID
            var mockProperties = new List<Property> { /* populate with test data */ };
            _mockRepository.Setup(repo => repo.GetAllByTypeId(typeId)).ReturnsAsync(mockProperties);

            // Act
            var result = await _controller.PropertyTypes(typeId);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<Property>>(actionResult.Value);
            Assert.Equal(mockProperties.Count, returnValue.Count);
        }

        [Fact]
        public async Task PropertyTypesNotFoundTest()
        {
            // Arrange
            var typeId = 1; // Example type ID
            _mockRepository.Setup(repo => repo.GetAllByTypeId(typeId)).ReturnsAsync((List<Property>?)null);

            // Act
            var result = await _controller.PropertyTypes(typeId);

            // Assert
            var actionResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal("Properties list not found!", actionResult.Value);
        }

        [Fact]
        public async Task DetailsOkTest()
        {
            // Arrange
            var propertyId = 1; // Example property ID
            var customerId = "1";
            var mockProperty = new Property {
                        Title = "Home",
                        Price = 2000,
                        Address = "Bro Sweden",
                        Description = "Cozy house featuring a comfortable bedroom, well-equipped kitchen, and a refreshing pool, perfect for a relaxing getaway.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 5,
                        CustomerId = "1",
            };
            var mockCustomer = new Customer {
                CustomerId = "1",
                Name = "Talhat Hamdy",
                Age = "28",
                Address = "OsloVeien",
                PhoneNumber = "92983929"
            };
            _mockRepository.Setup(repo => repo.GetPropertyById(propertyId)).ReturnsAsync(mockProperty);
            _mockRepository.Setup(repo => repo.Customer(customerId)).ReturnsAsync(mockCustomer);

            // Act
            var result = await _controller.Details(propertyId);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = actionResult.Value;
            Assert.NotNull(returnValue);
            // Optionally, serialize the result value to JSON and check for keys
            var jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(returnValue);
            Assert.Contains("\"Property\":", jsonResult);
            Assert.Contains("\"CustomerInfo\":", jsonResult);
        }

        [Fact]
        public async Task DetailsNotFoundTest()
        {
            // Arrange
            var propertyId = 1;
            _mockRepository.Setup(repo => repo.GetPropertyById(propertyId)).ReturnsAsync((Property?)null);

            // Act
            var result = await _controller.Details(propertyId);

            // Assert
            var actionResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Property not found for the PropertyId", actionResult.Value);
        }

        [Fact]
        public async Task CreateOkTest()
        {
            // Arrange
            var mockProperty = new Property
            {
                PropertyId = 1, 
                CustomerId = "customer123",
                Price = 120.00m, 
                Title = "Cozy Cottage by the Lake",
                Address = "123 Lakeview Drive, Lakeside Town",
                Description = "A cozy, two-bedroom lakeside cottage with a beautiful view of the lake. Perfect for a relaxing getaway.", // Example description
                Guest = 4,
                Bed = 2,
                BedRooms = 2,
                BathRooms = 1, 
                PTypeId = 2,
                PType = new PType { PTypeId = 2, PTypeName = "Cabins", PTypeIcon = "" },
                PropertyAmenities = new List<PropertyAmenity>
                {
                    new PropertyAmenity { AmenityId = 1, Amenity = new Amenity { AmenityId = 1, AmenityName = "Wi-Fi", AmenityIcon = "", IsChecked = true } },
                    new PropertyAmenity { AmenityId = 2, Amenity = new Amenity { AmenityId = 2, AmenityName = "Air Conditioning", AmenityIcon = "", IsChecked = true } }
                },
                SelectedAmenities = new List<int> { 1, 2 },
                Images = new List<PropertyImage>
                {
                    new PropertyImage { ImageUrl = "https://example.com/image1.jpg", PropertyId = 1 },
                    new PropertyImage { ImageUrl = "https://example.com/image2.jpg", PropertyId = 1 }
                },
                Files = null
            };
            _mockRepository.Setup(repo => repo.Create(It.IsAny<Property>())).ReturnsAsync(true);
            _mockRepository.Setup(repo => repo.GetPType(It.IsAny<int>())).ReturnsAsync(new PType());
            _mockRepository.Setup(repo => repo.GetAmenitiesByIds(It.IsAny<List<int>>())).ReturnsAsync(new List<Amenity>());

            // Act
            var result = await _controller.Create(mockProperty);

            // assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            Assert.IsType<ApiResponse>(okResult.Value); 
        }


        [Fact]
        public async Task CreateBadTest()
        {
            // Arrange
            var mockProperty = new Property {
                Title = "Home",
                Price = 3500,
                Address = "Skagen Denmark",
                Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                Guest = 2,
                Bed = 1,
                BedRooms = 1,
                BathRooms = 1,
                PTypeId = 1,
                CustomerId = "2",
            };
            _mockRepository.Setup(repo => repo.Customer(It.IsAny<string>())).ReturnsAsync(new Customer());
            _mockRepository.Setup(repo => repo.Create(It.IsAny<Property>())).ReturnsAsync(false);

            // Act
            var result = await _controller.Create(mockProperty);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task UpdateTest()
        {
            // Arrange
            var propertyId = 1;
            var mockProperty = new Property {
                Title = "Home",
                Price = 3500,
                Address = "Skagen Denmark",
                Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                Guest = 2,
                Bed = 1,
                BedRooms = 1,
                BathRooms = 1,
                PTypeId = 1,
                CustomerId = "2",
            };
            _mockRepository.Setup(repo => repo.GetPropertyById(propertyId)).ReturnsAsync((Property?)null);

            // Act
            var result = await _controller.Update(propertyId, mockProperty);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task UpdateBadTest()
        {
            // Arrange
            var propertyId = 1;
            var mockProperty = new Property {
                Title = "Home",
                Price = 3500,
                Address = "Skagen Denmark",
                Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                Guest = 2,
                Bed = 1,
                BedRooms = 1,
                BathRooms = 1,
                PTypeId = 1,
                CustomerId = "2",
            };
            _mockRepository.Setup(repo => repo.GetPropertyById(propertyId)).ReturnsAsync(mockProperty);
            _mockRepository.Setup(repo => repo.Update(It.IsAny<Property>())).ReturnsAsync(false);

            // Act
            var result = await _controller.Update(propertyId, mockProperty);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public async Task DeleteOkTest()
        {
            // Arrange
            var propertyId = 1;
            var mockProperty = new Property(); // Assuming existence of a property
            _mockRepository.Setup(repo => repo.GetPropertyById(propertyId)).ReturnsAsync(mockProperty);
            _mockRepository.Setup(repo => repo.Delete(propertyId)).ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(propertyId);

            // Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var resultValue = Assert.IsType<ApiResponse>(actionResult.Value);
            Assert.Equal("Property deleted successfully", resultValue.Message);
        }


        [Fact]
        public async Task DeleteBadTest()
        {
            // Arrange
            var propertyId = 1;
            var mockProperty = new Property();
            _mockRepository.Setup(repo => repo.GetPropertyById(propertyId)).ReturnsAsync(mockProperty);
            _mockRepository.Setup(repo => repo.Delete(propertyId)).ReturnsAsync(false);

            // Act
            var result = await _controller.Delete(propertyId);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}

