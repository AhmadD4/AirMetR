﻿using System;
using Microsoft.EntityFrameworkCore;

namespace AirMetR.Models
{
    public static class DBInit
    {
        public static void Seed(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            PropertyDbContext context = serviceScope.ServiceProvider.GetRequiredService<PropertyDbContext>();
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (!context.Customers.Any())
            {
                var Customer = new List<Customer>
                {
                   new Customer
                   {
                     CustomerId = "1",
                     Name = "Talhat Hamdy",
                     Age = "28",
                     Address = "OsloVeien",
                     PhoneNumber = "92983929"

                   },

                    new Customer
                   {
                     CustomerId = "2",
                     Name = "Per Hansen",
                     Age = "47",
                     Address = "SkiVeien",
                     PhoneNumber = "93483929"

                   },

                    new Customer
                   {
                     CustomerId = "3",
                     Name = "Abo-Mohammed",
                     Age = "22",
                     Address = "KremleVeien",
                     PhoneNumber = "96583929"
                   },

                    new Customer
                   {
                     CustomerId = "4",
                     Name = "Abo al-zeen",
                     Age = "24",
                     Address = "KremleVeien",
                     PhoneNumber = "96583929"
                   },

                    new Customer
                   {
                     CustomerId = "5",
                     Name = "Mohammed Mouaz Zaidan",
                     Age = "24",
                     Address = "KremleVeien",
                     PhoneNumber = "96583929"
                   },

                     new Customer
                   {
                     CustomerId = "6",
                     Name = "AlQamar W Alshamas",
                     Age = "24",
                     Address = "KremleVeien",
                     PhoneNumber = "96583929"
                   },
                };
                context.AddRange(Customer);
                context.SaveChanges();
            }

            if (!context.PTypes.Any())
            {
                var pType = new List<PType>
                {
                   new PType { PTypeName = "House", PTypeIcon = "fas fa-house-user" },
                   new PType { PTypeName = "Cabins", PTypeIcon = "fas fa-dungeon" },
                   new PType { PTypeName = "Domes", PTypeIcon = "fas fa-campground" },
                   new PType { PTypeName = "Treehouses", PTypeIcon = "fas fa-house" },
                   new PType { PTypeName = "Amazing Pools", PTypeIcon = "fas fa-swimming-pool" },
                   new PType { PTypeName = "Houseboats", PTypeIcon = "fas fa-ship" },
                };
                context.AddRange(pType);
                context.SaveChanges();
            }
            if (!context.Amenities.Any())
            {
                var amanity = new List<Amenity>
                {
                    new Amenity { AmenityName = "WiFi", AmenityIcon = "fa-solid fa-wifi", IsChecked = false},
                    new Amenity { AmenityName = "Kitchen", AmenityIcon = "fa-solid fa-utensils", IsChecked = false},
                    new Amenity { AmenityName = "Dedicated workspace", AmenityIcon = "fa-solid fa-briefcase", IsChecked = false},
                    new Amenity { AmenityName = "Free street parking", AmenityIcon = "fa-solid fa-parking", IsChecked = false},
                    new Amenity { AmenityName = "Pool", AmenityIcon = "fa-solid fa-swimming-pool", IsChecked = false},
                    new Amenity { AmenityName = "TV with standard cable", AmenityIcon = "fa-solid fa-tv", IsChecked = false},
                    new Amenity { AmenityName = "Hair dryer", AmenityIcon = "fa-solid fa-fan", IsChecked = false},
                    new Amenity { AmenityName = "Microwave", AmenityIcon = "fa-solid fa-burger", IsChecked = false},
                    new Amenity { AmenityName = "Fireplace", AmenityIcon = "fa-solid fa-fire", IsChecked = false},
                    new Amenity { AmenityName = "Alarm", AmenityIcon = "fa-solid fa-bell", IsChecked = false},
                    new Amenity { AmenityName = "Air conditioning", AmenityIcon = "fa-solid fa-wind", IsChecked = false},
                    new Amenity { AmenityName = "Washing machine", AmenityIcon = "fa-solid fa-shirt", IsChecked = false},
                    new Amenity { AmenityName = "Refrigerator", AmenityIcon = "fa-solid fa-calendar", IsChecked = false},
                    new Amenity { AmenityName = "Oven", AmenityIcon = "fa-solid fa-fire-burner", IsChecked = false},
                    new Amenity { AmenityName = "Smoking", AmenityIcon = "fa-solid fa-smoking", IsChecked = false},
                    new Amenity { AmenityName = "Kitchen Set", AmenityIcon = "fa-solid fa-kitchen-set", IsChecked = false},
                };
                context.AddRange(amanity);
                context.SaveChanges();
            }

            if (!context.Properties.Any())
            {
                var properties = new List<Property>
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

                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 3500,
                        Address = "Skagen Denmark",
                        Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                        Guest= 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 1,
                        CustomerId = "2",

                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 2700,
                        Address = "Amestrdam Netherlands",
                        Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                        Guest= 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 1,
                        CustomerId = "2",

                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 1400,
                        Address = "Paris France",
                        Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                        Guest= 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 1,
                        CustomerId = "2",

                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 2300,
                        Address = "Berlin Germany",
                        Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                        Guest= 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 5,
                        CustomerId = "2",

                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 3000,
                        Address = "Pandrup Denmark",
                        Description = "Charming home featuring a refreshing pool, fully equipped kitchen, two comfortable bedrooms with double beds, and a clean bathroom. Ideal for a relaxing and enjoyable stay",
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
                        Price = 1500,
                        Address = "Ås Norway",
                        Description = "Charming home with a refreshing pool outside, perfect for relaxation and leisure. The property comprises a comfortable bedroom furnished with a double bed, a well-equipped kitchen, and a clean bathroom. Enjoy the tranquility and convenience of this inviting space.",
                        Guest = 4,
                        Bed = 2,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 5,
                        CustomerId = "1",


                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 2000,
                        Address = "Moss Norway",
                        Description = "Idyllic home featuring a private pool outside, an inviting kitchen, and a cozy bedroom furnished with a double bed. Enjoy the perfect blend of comfort and serenity in this delightful abode, ideal for a relaxing getaway",
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
                        Address = "Trondheim Norway",
                        Description = "Charming retreat boasting 2 bedrooms, one elegantly furnished with a double bed for adults and the other thoughtfully arranged with a comfortable bed for children. Discover the tranquil ambiance and delightful amenities, perfect for a memorable family vacation",
                        Bed = 2,
                        Guest = 4,
                        BedRooms = 2,
                        BathRooms = 1,
                        PTypeId = 5,
                        CustomerId = "1",

                    },
                    new Property
                    {
                        Title = "Home",
                        Price = 1500,
                        Address = "Verdal Norway",
                        Description = "Charming retreat boasting 2 bedrooms, one elegantly furnished with a double bed for adults and the other thoughtfully arranged with a comfortable bed for children. Discover the tranquil ambiance and delightful amenities, perfect for a memorable family vacation",
                        Bed = 1,
                        Guest = 4,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 5,
                        CustomerId = "1",

                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 3000,
                        Address = "Dal Norway",
                        Description = "Charming retreat boasting 2 bedrooms, one elegantly furnished with a double bed for adults and the other thoughtfully arranged with a comfortable bed for children. Discover the tranquil ambiance and delightful amenities, perfect for a memorable family vacation",
                        Bed = 2,
                        Guest = 4,
                        BedRooms = 2,
                        BathRooms = 1,
                        PTypeId = 5,
                        CustomerId = "1",

                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 2000,
                        Address = "London UK",
                        Description = "Charming retreat boasting 2 bedrooms, one elegantly furnished with a double bed for adults and the other thoughtfully arranged with a comfortable bed for children. Discover the tranquil ambiance and delightful amenities, perfect for a memorable family vacation",
                        Bed = 1,
                        Guest = 4,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 5,
                        CustomerId = "1",

                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 1750,
                        Address = "Gdańsk Poland",
                        Description = "Charming retreat boasting 2 bedrooms, one elegantly furnished with a double bed for adults and the other thoughtfully arranged with a comfortable bed for children. Discover the tranquil ambiance and delightful amenities, perfect for a memorable family vacation",
                        Bed = 2,
                        Guest = 4,
                        BedRooms = 2,
                        BathRooms = 1,
                        PTypeId = 5,
                        CustomerId = "1",

                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 1500,
                        Address = "Copenhagen Denmark",
                        Description = "Charming retreat boasting 2 bedrooms, one elegantly furnished with a double bed for adults and the other thoughtfully arranged with a comfortable bed for children. Discover the tranquil ambiance and delightful amenities, perfect for a memorable family vacation",
                        Bed = 2,
                        Guest = 4,
                        BedRooms = 2,
                        BathRooms = 1,
                        PTypeId = 5,
                        CustomerId = "1",

                    },

                     new Property
                    {
                        Title = "Home",
                        Price = 1200,
                        Address = "Stockholms Sweden",
                        Description = "Charming retreat boasting 2 bedrooms, one elegantly furnished with a double bed for adults and the other thoughtfully arranged with a comfortable bed for children. Discover the tranquil ambiance and delightful amenities, perfect for a memorable family vacation",
                        Bed = 2,
                        Guest = 4,
                        BedRooms = 2,
                        BathRooms = 1,
                        PTypeId = 1,
                        CustomerId = "1",

                    },

                     new Property
                    {
                        Title = "Home",
                        Price = 1600,
                        Address = "Uppsala Sweden",
                        Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 1,
                        CustomerId = "2",


                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 2500,
                        Address = "Opddal Norway",
                        Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId =1 ,
                        CustomerId = "2",


                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 3500,
                        Address = " Hamburg Germany",
                        Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 1,
                        CustomerId = "2",


                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 1850,
                        Address = "North Berwick Scotland, UK",
                        Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 1,
                        CustomerId = "2",


                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 1400,
                        Address = "Bygdøy Norway",
                        Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 1,
                        CustomerId = "2",


                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 3500,
                        Address = "Trondheim Norway",
                        Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                        Guest =2,
                        Bed = 1,
                        BedRooms = 2,
                        BathRooms = 1,
                        PTypeId = 1,
                        CustomerId = "2",

                    },

                    new Property
                    {
                        Title = "Home",
                        Price = 1100,
                        Address = "Ski Norway",
                        Description = "Charming home with a well-equipped kitchen, a comfortable bedroom featuring a double bed, and a modern bathroom. Perfect for a relaxing and convenient stay",
                        Guest =2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 1,
                        CustomerId = "2",

                    },

                    new Property
                    {
                        Title = "Domes",
                        Price = 1000,
                        Address = "Verdal Norway",
                        Description = "A charming cabin featuring a double bed and a dining table, boasting stunning views of the picturesque surroundings.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 3,
                        CustomerId = "3",

                    },

                    new Property
                    {
                        Title = "Domes",
                        Price = 900,
                        Address = "Ringerike Norway",
                        Description = "A charming cabin featuring a double bed and a dining table, boasting stunning views of the picturesque surroundings.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 3,
                        CustomerId = "3",

                    },

                    new Property
                    {
                        Title = "Domes",
                        Price = 1200,
                        Address = "Rozłopy Poland",
                        Description = "A charming cabin featuring a double bed and a dining table, boasting stunning views of the picturesque surroundings.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 3,
                        CustomerId = "3",

                    },

                    new Property
                    {
                        Title = "Domes",
                        Price = 1150,
                        Address = "Nørre Alslev Denmark",
                        Description = "A charming cabin featuring a double bed and a dining table, boasting stunning views of the picturesque surroundings.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 3,
                        CustomerId = "3",

                    },

                    new Property
                    {
                        Title = "Domes",
                        Price = 850,
                        Address = "Ham Belgium",
                        Description = "A charming cabin featuring a double bed and a dining table, boasting stunning views of the picturesque surroundings.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 3,
                        CustomerId = "3",

                    },

                    new Property
                    {
                        Title = "Domes",
                        Price = 1200,
                        Address = "Mielno Poland",
                        Description = "A charming cabin featuring a double bed and a dining table, boasting stunning views of the picturesque surroundings.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 3,
                        CustomerId = "3",

                    },

                    new Property
                    {
                        Title = "Domes",
                        Price = 1450,
                        Address = "Viirelaid Estonia",
                        Description = "A charming cabin featuring a double bed and a dining table, boasting stunning views of the picturesque surroundings.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 3,
                        CustomerId = "3",

                    },

                    new Property
                    {
                        Title = "Domes",
                        Price = 999,
                        Address = "Namur Belgium",
                        Description = "A charming cabin featuring a double bed and a dining table, boasting stunning views of the picturesque surroundings.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 3,
                        CustomerId = "3",

                    },

                     new Property
                    {
                        Title = "Domes",
                        Price = 1350,
                        Address = "Dolní Branná Czechia",
                        Description = "A charming cabin featuring a double bed and a dining table, boasting stunning views of the picturesque surroundings.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 3,
                        CustomerId = "3",

                    },

                      new Property
                    {
                        Title = "Domes",
                        Price = 1150,
                        Address = "Zeewolde Netherlands",
                        Description = "A charming cabin featuring a double bed and a dining table, boasting stunning views of the picturesque surroundings.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 3,
                        CustomerId = "3",

                    },

                       new Property
                    {
                        Title = "Domes",
                        Price = 1000,
                        Address = "Oppdal Norway",
                        Description = "A charming cabin featuring a double bed and a dining table, boasting stunning views of the picturesque surroundings.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 3,
                        CustomerId = "3",

                    },


                       new Property
                    {
                        Title = "Domes",
                        Price = 750,
                        Address = "Dal Norway",
                        Description = "A charming cabin featuring a double bed and a dining table, boasting stunning views of the picturesque surroundings.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 3,
                        CustomerId = "3",

                    },


                       new Property
                    {
                        Title = "Treehouse",
                        Price = 1900,
                        Address = "Bergen Norway",
                        Description = "Perched in the lush embrace of towering trees, this cozy treehouse features a well-equipped kitchen and a snug bedroom with a double bed, providing a peaceful sanctuary amidst nature's embrace.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 4,
                        CustomerId = "4",

                    },

                        new Property
                    {
                        Title = "Treehouse",
                        Price = 1500,
                        Address = "Vestby Norway",
                        Description = "Perched in the lush embrace of towering trees, this cozy treehouse features a well-equipped kitchen and a snug bedroom with a double bed, providing a peaceful sanctuary amidst nature's embrace.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 4,
                        CustomerId = "4",

                    },

                        new Property
                    {
                        Title = "Treehouse",
                        Price = 1650,
                        Address = "Ås Norway",
                        Description = "Perched in the lush embrace of towering trees, this cozy treehouse features a well-equipped kitchen and a snug bedroom with a double bed, providing a peaceful sanctuary amidst nature's embrace.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 4,
                        CustomerId = "4",

                    },

                       new Property
                    {
                        Title = "Treehouse",
                        Price = 2000,
                        Address = " Eworthy United Kingdom",
                        Description = "Perched in the lush embrace of towering trees, this cozy treehouse features a well-equipped kitchen and a snug bedroom with a double bed, providing a peaceful sanctuary amidst nature's embrace.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 4,
                        CustomerId = "4",

                    },

                         new Property
                    {
                        Title = "Treehouse",
                        Price = 1500,
                        Address = "Värnamo Sweden",
                        Description = "Perched in the lush embrace of towering trees, this cozy treehouse features a well-equipped kitchen and a snug bedroom with a double bed, providing a peaceful sanctuary amidst nature's embrace.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 4,
                        CustomerId = "4",

                    },


                         new Property
                    {
                        Title = "Treehouse",
                        Price = 1750,
                        Address = "Uppsala Sweden",
                        Description = "Perched in the lush embrace of towering trees, this cozy treehouse features a well-equipped kitchen and a snug bedroom with a double bed, providing a peaceful sanctuary amidst nature's embrace.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 4,
                        CustomerId = "4",

                    },

                        new Property
                    {
                        Title = "Treehouse",
                        Price = 1200,
                        Address = "Ambleteuse France",
                        Description = "Perched in the lush embrace of towering trees, this cozy treehouse features a well-equipped kitchen and a snug bedroom with a double bed, providing a peaceful sanctuary amidst nature's embrace.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 4,
                        CustomerId = "4",

                    },


                        new Property
                    {
                        Title = "Treehouse",
                        Price = 1850,
                        Address = "Kirikuküla Estonia",
                        Description = "Perched in the lush embrace of towering trees, this cozy treehouse features a well-equipped kitchen and a snug bedroom with a double bed, providing a peaceful sanctuary amidst nature's embrace.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 4,
                        CustomerId = "4",

                    },


                        new Property
                    {
                        Title = "Treehouse",
                        Price = 1350,
                        Address = "Halden Norway",
                        Description = "Perched in the lush embrace of towering trees, this cozy treehouse features a well-equipped kitchen and a snug bedroom with a double bed, providing a peaceful sanctuary amidst nature's embrace.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 4,
                        CustomerId = "4",

                    },

                        new Property
                    {
                        Title = "Treehouse",
                        Price = 2300,
                        Address = "Rättvik Sweden",
                        Description = "Perched in the lush embrace of towering trees, this cozy treehouse features a well-equipped kitchen and a snug bedroom with a double bed, providing a peaceful sanctuary amidst nature's embrace.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 4,
                        CustomerId = "4",

                    },

                        new Property
                    {
                        Title = "Treehouse",
                        Price = 1900,
                        Address = "Jõgisoo Estonia",
                        Description = "Perched in the lush embrace of towering trees, this cozy treehouse features a well-equipped kitchen and a snug bedroom with a double bed, providing a peaceful sanctuary amidst nature's embrace.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 4,
                        CustomerId = "4",

                    },

                        new Property
                    {
                        Title = "Treehouse",
                        Price = 2000,
                        Address = "Iveland Norway",
                        Description = "Perched in the lush embrace of towering trees, this cozy treehouse features a well-equipped kitchen and a snug bedroom with a double bed, providing a peaceful sanctuary amidst nature's embrace.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 4,
                        CustomerId = "4",

                    },

                        new Property
                    {
                        Title = "Cabin",
                        Price = 1750,
                        Address = "Nedre Eggedal Norway",
                        Description = "Cozy cabin with a double bed, nestled in tranquil surroundings, featuring a well-equipped kitchen for delightful meals.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 2,
                        CustomerId = "5",

                    },

                        new Property
                    {
                        Title = "Cabin",
                        Price = 1999,
                        Address = "Modum Norway",
                        Description = "Cozy cabin with a double bed, nestled in tranquil surroundings, featuring a well-equipped kitchen for delightful meals.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 2,
                        CustomerId = "5",

                    },

                         new Property
                    {
                        Title = "Cabin",
                        Price = 1350,
                        Address = "Eggedal Norway",
                        Description = "Cozy cabin with a double bed, nestled in tranquil surroundings, featuring a well-equipped kitchen for delightful meals.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 2,
                        CustomerId = "5",

                    },


                         new Property
                    {
                        Title = "Cabin",
                        Price = 1500,
                        Address = "Modum Norway",
                        Description = "Cozy cabin with a double bed, nestled in tranquil surroundings, featuring a well-equipped kitchen for delightful meals.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 2,
                        CustomerId = "5",

                    },


                        new Property
                    {
                        Title = "Cabin",
                        Price = 1100,
                        Address = "Ås Norway",
                        Description = "Cozy cabin with a double bed, nestled in tranquil surroundings, featuring a well-equipped kitchen for delightful meals.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 2,
                        CustomerId = "5",

                    },

                         new Property
                    {
                        Title = "Cabin",
                        Price = 2000,
                        Address = "Aurskog-Høland Norway",
                        Description = "Cozy cabin with a double bed, nestled in tranquil surroundings, featuring a well-equipped kitchen for delightful meals.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 2,
                        CustomerId = "5",

                    },


                         new Property
                    {
                        Title = "Cabin",
                        Price = 2100,
                        Address = "Nesoddtangen Norway",
                        Description = "Cozy cabin with a double bed, nestled in tranquil surroundings, featuring a well-equipped kitchen for delightful meals.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 2,
                        CustomerId = "5",

                    },


                         new Property
                    {
                        Title = "Cabin",
                        Price = 900,
                        Address = "Son Norway",
                        Description = "Cozy cabin with a double bed, nestled in tranquil surroundings, featuring a well-equipped kitchen for delightful meals.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 2,
                        CustomerId = "5",

                    },


                         new Property
                    {
                        Title = "Cabin",
                        Price = 1450,
                        Address = "Årjäng Sweden",
                        Description = "Cozy cabin with a double bed, nestled in tranquil surroundings, featuring a well-equipped kitchen for delightful meals.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 2,
                        CustomerId = "5",

                    },


                         new Property
                    {
                        Title = "Cabin",
                        Price = 1400,
                        Address = "Gran Norway",
                        Description = "Cozy cabin with a double bed, nestled in tranquil surroundings, featuring a well-equipped kitchen for delightful meals.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 2,
                        CustomerId = "5",

                    },

                        new Property
                    {
                        Title = "Cabin",
                        Price = 1550,
                        Address = "Nesbyen Norway",
                        Description = "Cozy cabin with a double bed, nestled in tranquil surroundings, featuring a well-equipped kitchen for delightful meals.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 2,
                        CustomerId = "5",

                    },

                         new Property
                    {
                        Title = "Cabin",
                        Price = 2250,
                        Address = "Tunhovd Norway",
                        Description = "Cozy cabin with a double bed, nestled in tranquil surroundings, featuring a well-equipped kitchen for delightful meals.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 2,
                        CustomerId = "5",

                    },

                         new Property
                    {
                        Title = "Houseboat",
                        Price = 3000,
                        Address = "Bengtsfors Sweden",
                        Description = "Quaint boathouse with a cozy bedroom and kitchen, along with a small boat for peaceful fishing trips nearby.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 6,
                        CustomerId = "6",

                    },

                         new Property
                    {
                        Title = "Houseboat",
                        Price = 1750,
                        Address = "Gislaved Sweden",
                        Description = "Quaint boathouse with a cozy bedroom and kitchen, along with a small boat for peaceful fishing trips nearby.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 6,
                        CustomerId = "6",

                    },

                         new Property
                    {
                        Title = "Houseboat",
                        Price = 1900,
                        Address = "Langweer Netherlands",
                        Description = "Quaint boathouse with a cozy bedroom and kitchen, along with a small boat for peaceful fishing trips nearby.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 6,
                        CustomerId = "6",

                    },

                        new Property
                    {
                        Title = "Houseboat",
                        Price = 1350,
                        Address = "Kirkkonummi Finland",
                        Description = "Quaint boathouse with a cozy bedroom and kitchen, along with a small boat for peaceful fishing trips nearby.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 6,
                        CustomerId = "6",

                    },


                        new Property
                    {
                        Title = "Houseboat",
                        Price = 1500,
                        Address = "Warns Netherlands",
                        Description = "Quaint boathouse with a cozy bedroom and kitchen, along with a small boat for peaceful fishing trips nearby.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 6,
                        CustomerId = "6",

                    },


                        new Property
                    {
                        Title = "Houseboat",
                        Price = 2300,
                        Address = "Neuruppin Germany",
                        Description = "Quaint boathouse with a cozy bedroom and kitchen, along with a small boat for peaceful fishing trips nearby.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 6,
                        CustomerId = "6",

                    },

                        new Property
                    {
                        Title = "Houseboat",
                        Price = 950,
                        Address = "Finspång Sweden",
                        Description = "Quaint boathouse with a cozy bedroom and kitchen, along with a small boat for peaceful fishing trips nearby.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 6,
                        CustomerId = "6",

                    },



                        new Property
                    {
                        Title = "Houseboat",
                        Price = 1100,
                        Address = "Großefehn Germany",
                        Description = "Quaint boathouse with a cozy bedroom and kitchen, along with a small boat for peaceful fishing trips nearby.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 6,
                        CustomerId = "6",

                    },


                        new Property
                    {
                        Title = "Houseboat",
                        Price = 1450,
                        Address = "Hamburg Germany",
                        Description = "Quaint boathouse with a cozy bedroom and kitchen, along with a small boat for peaceful fishing trips nearby.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 6,
                        CustomerId = "6",

                    },


                        new Property
                    {
                        Title = "Houseboat",
                        Price = 1200,
                        Address = "Sneek Netherlands",
                        Description = "Quaint boathouse with a cozy bedroom and kitchen, along with a small boat for peaceful fishing trips nearby.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 6,
                        CustomerId = "6",

                    },

                         new Property
                    {
                        Title = "Houseboat",
                        Price = 2100,
                        Address = "Grou Netherlands",
                        Description = "Quaint boathouse with a cozy bedroom and kitchen, along with a small boat for peaceful fishing trips nearby.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 6,
                        CustomerId = "6",

                    },

                         new Property
                    {
                        Title = "Houseboat",
                        Price = 2000,
                        Address = "Offingawier Netherlands",
                        Description = "Quaint boathouse with a cozy bedroom and kitchen, along with a small boat for peaceful fishing trips nearby.",
                        Guest = 2,
                        Bed = 1,
                        BedRooms = 1,
                        BathRooms = 1,
                        PTypeId = 6,
                        CustomerId = "6",

                    },
                };

                context.AddRange(properties);
                context.SaveChanges();
            }
            if (!context.PropertyImages.Any())
            {
                var imageProperty = new List<PropertyImage>
                {
                    new PropertyImage {ImageUrl = "/images/hs1.jpg", PropertyId = 1},
                    new PropertyImage {ImageUrl = "/images/hs2.jpg", PropertyId = 1},
                    new PropertyImage {ImageUrl = "/images/hs3.jpg", PropertyId = 1},
                    new PropertyImage {ImageUrl = "/images/hs4.jpg", PropertyId = 1},
                    new PropertyImage {ImageUrl = "/images/hs5.jpg", PropertyId = 1},
                    new PropertyImage {ImageUrl = "/images/hs6.jpg", PropertyId = 1},

                    new PropertyImage {ImageUrl = "/images/h1.jpg", PropertyId = 2},
                    new PropertyImage {ImageUrl = "/images/h2.jpg", PropertyId = 2},
                    new PropertyImage {ImageUrl = "/images/h3.jpg", PropertyId = 2},
                    new PropertyImage {ImageUrl = "/images/h4.jpg", PropertyId = 2},
                    new PropertyImage {ImageUrl = "/images/h5.jpg", PropertyId = 2},
                    new PropertyImage {ImageUrl = "/images/h6.jpg", PropertyId = 2},

                    new PropertyImage {ImageUrl = "/images/1.jpg", PropertyId = 7},
                    new PropertyImage {ImageUrl = "/images/2.jpg", PropertyId = 7},
                    new PropertyImage {ImageUrl = "/images/3.jpg", PropertyId = 7},
                    new PropertyImage {ImageUrl = "/images/4.jpg", PropertyId = 7},
                    new PropertyImage {ImageUrl = "/images/5.jpg", PropertyId = 7},
                    new PropertyImage {ImageUrl = "/images/6.jpg", PropertyId = 7},

                    new PropertyImage {ImageUrl = "/images/7.jpg", PropertyId = 8},
                    new PropertyImage {ImageUrl = "/images/8.jpg", PropertyId = 8},
                    new PropertyImage {ImageUrl = "/images/9.jpg", PropertyId = 8},
                    new PropertyImage {ImageUrl = "/images/10.jpg", PropertyId = 8},

                    new PropertyImage {ImageUrl = "/images/11.jpg", PropertyId = 9},
                    new PropertyImage {ImageUrl = "/images/12.jpg", PropertyId = 9},
                    new PropertyImage {ImageUrl = "/images/13.jpg", PropertyId = 9},
                    new PropertyImage {ImageUrl = "/images/14.jpg", PropertyId = 9},
                    new PropertyImage {ImageUrl = "/images/15.jpg", PropertyId = 9},
                    new PropertyImage {ImageUrl = "/images/16.jpg", PropertyId = 9},

                    new PropertyImage {ImageUrl = "/images/17.jpg", PropertyId = 10},
                    new PropertyImage {ImageUrl = "/images/18.jpg", PropertyId = 10},
                    new PropertyImage {ImageUrl = "/images/19.jpg", PropertyId = 10},
                    new PropertyImage {ImageUrl = "/images/20.jpg", PropertyId = 10},
                    new PropertyImage {ImageUrl = "/images/21.jpg", PropertyId = 10},
                    new PropertyImage {ImageUrl = "/images/22.jpg", PropertyId = 10},

                    new PropertyImage {ImageUrl = "/images/23.jpg", PropertyId = 11},
                    new PropertyImage {ImageUrl = "/images/24.jpg", PropertyId = 11},
                    new PropertyImage {ImageUrl = "/images/25.jpg", PropertyId = 11},
                    new PropertyImage {ImageUrl = "/images/26.jpg", PropertyId = 11},
                    new PropertyImage {ImageUrl = "/images/27.jpg", PropertyId = 11},


                    new PropertyImage {ImageUrl = "/images/28.jpg", PropertyId = 12},
                    new PropertyImage {ImageUrl = "/images/29.jpg", PropertyId = 12},
                    new PropertyImage {ImageUrl = "/images/30.jpg", PropertyId = 12},
                    new PropertyImage {ImageUrl = "/images/31.jpg", PropertyId = 12},
                    new PropertyImage {ImageUrl = "/images/32.jpg", PropertyId = 12},

                    new PropertyImage {ImageUrl = "/images/33.jpg", PropertyId = 13},
                    new PropertyImage {ImageUrl = "/images/34.jpg", PropertyId = 13},
                    new PropertyImage {ImageUrl = "/images/35.jpg", PropertyId = 13},
                    new PropertyImage {ImageUrl = "/images/36.jpg", PropertyId = 13},

                    new PropertyImage {ImageUrl = "/images/37.jpg", PropertyId = 14},
                    new PropertyImage {ImageUrl = "/images/38.jpg", PropertyId = 14},
                    new PropertyImage {ImageUrl = "/images/39.jpg", PropertyId = 14},
                    new PropertyImage {ImageUrl = "/images/40.jpg", PropertyId = 14},
                    new PropertyImage {ImageUrl = "/images/41.jpg", PropertyId = 14},
                    new PropertyImage {ImageUrl = "/images/42.jpg", PropertyId = 14},


                    new PropertyImage {ImageUrl = "/images/43.jpg", PropertyId = 15},
                    new PropertyImage {ImageUrl = "/images/44.jpg", PropertyId = 15},
                    new PropertyImage {ImageUrl = "/images/45.jpg", PropertyId = 15},
                    new PropertyImage {ImageUrl = "/images/46.jpg", PropertyId = 15},
                    new PropertyImage {ImageUrl = "/images/47.jpg", PropertyId = 15},
                    new PropertyImage {ImageUrl = "/images/48.jpg", PropertyId = 15},

                    new PropertyImage {ImageUrl = "/images/49.jpg", PropertyId = 16},
                    new PropertyImage {ImageUrl = "/images/50.jpg", PropertyId = 16},
                    new PropertyImage {ImageUrl = "/images/51.jpg", PropertyId = 16},
                    new PropertyImage {ImageUrl = "/images/52.jpg", PropertyId = 16},
                    new PropertyImage {ImageUrl = "/images/53.jpg", PropertyId = 16},

                    new PropertyImage {ImageUrl = "/images/54.jpg", PropertyId = 17},
                    new PropertyImage {ImageUrl = "/images/55.jpg", PropertyId = 17},
                    new PropertyImage {ImageUrl = "/images/56.jpg", PropertyId = 17},
                    new PropertyImage {ImageUrl = "/images/57.jpg", PropertyId = 17},

                    new PropertyImage {ImageUrl = "/images/58.jpg", PropertyId = 18},
                    new PropertyImage {ImageUrl = "/images/59.jpg", PropertyId = 18},
                    new PropertyImage {ImageUrl = "/images/60.jpg", PropertyId = 18},
                    new PropertyImage {ImageUrl = "/images/61.jpg", PropertyId = 18},

                    new PropertyImage {ImageUrl = "/images/62.jpg", PropertyId = 19},
                    new PropertyImage {ImageUrl = "/images/63.jpg", PropertyId = 19},
                    new PropertyImage {ImageUrl = "/images/64.jpg", PropertyId = 19},
                    new PropertyImage {ImageUrl = "/images/65.jpg", PropertyId = 19},

                    new PropertyImage {ImageUrl = "/images/66.jpg", PropertyId = 20},
                    new PropertyImage {ImageUrl = "/images/67.jpg", PropertyId = 20},
                    new PropertyImage {ImageUrl = "/images/68.jpg", PropertyId = 20},
                    new PropertyImage {ImageUrl = "/images/69.jpg", PropertyId = 20},

                    new PropertyImage {ImageUrl = "/images/70.jpg", PropertyId = 21},
                    new PropertyImage {ImageUrl = "/images/71.jpg", PropertyId = 21},
                    new PropertyImage {ImageUrl = "/images/72.jpg", PropertyId = 21},
                    new PropertyImage {ImageUrl = "/images/73.jpg", PropertyId = 21},

                    new PropertyImage {ImageUrl = "/images/74.jpg", PropertyId = 22},
                    new PropertyImage {ImageUrl = "/images/75.jpg", PropertyId = 22},
                    new PropertyImage {ImageUrl = "/images/76.jpg", PropertyId = 22},
                    new PropertyImage {ImageUrl = "/images/77.jpg", PropertyId = 22},

                    new PropertyImage {ImageUrl = "/images/78.jpg", PropertyId = 23},
                    new PropertyImage {ImageUrl = "/images/79.jpg", PropertyId = 23},
                    new PropertyImage {ImageUrl = "/images/80.jpg", PropertyId = 23},
                    new PropertyImage {ImageUrl = "/images/81.jpg", PropertyId = 23},

                    new PropertyImage {ImageUrl = "/images/82.jpg", PropertyId = 3},
                    new PropertyImage {ImageUrl = "/images/83.jpg", PropertyId = 3},
                    new PropertyImage {ImageUrl = "/images/84.jpg", PropertyId = 3},
                    new PropertyImage {ImageUrl = "/images/85.jpg", PropertyId = 3},

                    new PropertyImage {ImageUrl = "/images/86.jpg", PropertyId = 4},
                    new PropertyImage {ImageUrl = "/images/87.jpg", PropertyId = 4},
                    new PropertyImage {ImageUrl = "/images/88.jpg", PropertyId = 4},
                    new PropertyImage {ImageUrl = "/images/89.jpg", PropertyId = 4},

                    new PropertyImage {ImageUrl = "/images/90.jpg", PropertyId = 5},
                    new PropertyImage {ImageUrl = "/images/91.jpg", PropertyId = 5},
                    new PropertyImage {ImageUrl = "/images/92.jpg", PropertyId = 5},
                    new PropertyImage {ImageUrl = "/images/93.jpg", PropertyId = 5},

                    new PropertyImage {ImageUrl = "/images/94.jpg", PropertyId = 6},
                    new PropertyImage {ImageUrl = "/images/95.jpg", PropertyId = 6},
                    new PropertyImage {ImageUrl = "/images/96.jpg", PropertyId = 6},
                    new PropertyImage {ImageUrl = "/images/97.jpg", PropertyId = 6},

                    new PropertyImage {ImageUrl = "/images/98.jpg", PropertyId = 24},
                    new PropertyImage {ImageUrl = "/images/99.jpg", PropertyId = 24},
                    new PropertyImage {ImageUrl = "/images/100.jpg", PropertyId = 24},
                    new PropertyImage {ImageUrl = "/images/101.jpg", PropertyId = 24},

                    new PropertyImage {ImageUrl = "/images/102.jpg", PropertyId = 25},
                    new PropertyImage {ImageUrl = "/images/103.jpg", PropertyId = 25},
                    new PropertyImage {ImageUrl = "/images/104.jpg", PropertyId = 25},

                    new PropertyImage {ImageUrl = "/images/105.jpg", PropertyId = 26},
                    new PropertyImage {ImageUrl = "/images/106.jpg", PropertyId = 26},
                    new PropertyImage {ImageUrl = "/images/107.jpg", PropertyId = 26},

                    new PropertyImage {ImageUrl = "/images/108.jpg", PropertyId = 27},
                    new PropertyImage {ImageUrl = "/images/109.jpg", PropertyId = 27},
                    new PropertyImage {ImageUrl = "/images/110.jpg", PropertyId = 27},

                    new PropertyImage {ImageUrl = "/images/111.jpg", PropertyId = 28},
                    new PropertyImage {ImageUrl = "/images/112.jpg", PropertyId = 28},
                    new PropertyImage {ImageUrl = "/images/113.jpg", PropertyId = 28},

                    new PropertyImage {ImageUrl = "/images/114.jpg", PropertyId = 29},
                    new PropertyImage {ImageUrl = "/images/115.jpg", PropertyId = 29},
                    new PropertyImage {ImageUrl = "/images/116.jpg", PropertyId = 29},

                    new PropertyImage {ImageUrl = "/images/117.jpg", PropertyId = 30},
                    new PropertyImage {ImageUrl = "/images/118.jpg", PropertyId = 30},
                    new PropertyImage {ImageUrl = "/images/119.jpg", PropertyId = 30},

                    new PropertyImage {ImageUrl = "/images/120.jpg", PropertyId = 31},
                    new PropertyImage {ImageUrl = "/images/121.jpg", PropertyId = 31},
                    new PropertyImage {ImageUrl = "/images/122.jpg", PropertyId = 31},

                    new PropertyImage {ImageUrl = "/images/123.jpg", PropertyId = 32},
                    new PropertyImage {ImageUrl = "/images/124.jpg", PropertyId = 32},
                    new PropertyImage {ImageUrl = "/images/125.jpg", PropertyId = 32},

                    new PropertyImage {ImageUrl = "/images/126.jpg", PropertyId = 33},
                    new PropertyImage {ImageUrl = "/images/127.jpg", PropertyId = 33},
                    new PropertyImage {ImageUrl = "/images/128.jpg", PropertyId = 33},

                    new PropertyImage {ImageUrl = "/images/129.jpg", PropertyId = 34},
                    new PropertyImage {ImageUrl = "/images/130.jpg", PropertyId = 34},
                    new PropertyImage {ImageUrl = "/images/131.jpg", PropertyId = 34},

                    new PropertyImage {ImageUrl = "/images/132.jpg", PropertyId = 35},
                    new PropertyImage {ImageUrl = "/images/133.jpg", PropertyId = 35},
                    new PropertyImage {ImageUrl = "/images/134.jpg", PropertyId = 35},

                    new PropertyImage {ImageUrl = "/images/135.jpg", PropertyId = 36},
                    new PropertyImage {ImageUrl = "/images/136.jpg", PropertyId = 36},
                    new PropertyImage {ImageUrl = "/images/137.jpg", PropertyId = 36},

                    new PropertyImage {ImageUrl = "/images/138.jpg", PropertyId = 37},
                    new PropertyImage {ImageUrl = "/images/139.jpg", PropertyId = 37},
                    new PropertyImage {ImageUrl = "/images/140.jpg", PropertyId = 37},

                    new PropertyImage {ImageUrl = "/images/141.jpg", PropertyId = 38},
                    new PropertyImage {ImageUrl = "/images/142.jpg", PropertyId = 38},
                    new PropertyImage {ImageUrl = "/images/143.jpg", PropertyId = 38},

                    new PropertyImage {ImageUrl = "/images/144.jpg", PropertyId = 39},
                    new PropertyImage {ImageUrl = "/images/145.jpg", PropertyId = 39},
                    new PropertyImage {ImageUrl = "/images/146.jpg", PropertyId = 39},

                    new PropertyImage {ImageUrl = "/images/147.jpg", PropertyId = 40},
                    new PropertyImage {ImageUrl = "/images/148.jpg", PropertyId = 40},
                    new PropertyImage {ImageUrl = "/images/149.jpg", PropertyId = 40},

                    new PropertyImage {ImageUrl = "/images/150.jpg", PropertyId = 41},
                    new PropertyImage {ImageUrl = "/images/151.jpg", PropertyId = 41},
                    new PropertyImage {ImageUrl = "/images/152.jpg", PropertyId = 41},

                    new PropertyImage {ImageUrl = "/images/153.jpg", PropertyId = 42},
                    new PropertyImage {ImageUrl = "/images/154.jpg", PropertyId = 42},
                    new PropertyImage {ImageUrl = "/images/155.jpg", PropertyId = 42},

                    new PropertyImage {ImageUrl = "/images/156.jpg", PropertyId = 43},
                    new PropertyImage {ImageUrl = "/images/157.jpg", PropertyId = 43},
                    new PropertyImage {ImageUrl = "/images/158.jpg", PropertyId = 43},

                    new PropertyImage {ImageUrl = "/images/159.jpg", PropertyId = 44},
                    new PropertyImage {ImageUrl = "/images/160.jpg", PropertyId = 44},
                    new PropertyImage {ImageUrl = "/images/161.jpg", PropertyId = 44},

                    new PropertyImage {ImageUrl = "/images/162.jpg", PropertyId = 45},
                    new PropertyImage {ImageUrl = "/images/163.jpg", PropertyId = 45},
                    new PropertyImage {ImageUrl = "/images/164.jpg", PropertyId = 45},

                    new PropertyImage {ImageUrl = "/images/165.jpg", PropertyId = 46},
                    new PropertyImage {ImageUrl = "/images/166.jpg", PropertyId = 46},
                    new PropertyImage {ImageUrl = "/images/167.jpg", PropertyId = 46},

                    new PropertyImage {ImageUrl = "/images/168.jpg", PropertyId = 47},
                    new PropertyImage {ImageUrl = "/images/169.jpg", PropertyId = 47},
                    new PropertyImage {ImageUrl = "/images/170.jpg", PropertyId = 47},

                    new PropertyImage {ImageUrl = "/images/171.jpg", PropertyId = 48},
                    new PropertyImage {ImageUrl = "/images/172.jpg", PropertyId = 48},
                    new PropertyImage {ImageUrl = "/images/173.jpg", PropertyId = 48},

                    new PropertyImage {ImageUrl = "/images/174.jpg", PropertyId = 49},
                    new PropertyImage {ImageUrl = "/images/175.jpg", PropertyId = 49},
                    new PropertyImage {ImageUrl = "/images/176.jpg", PropertyId = 49},

                    new PropertyImage {ImageUrl = "/images/177.jpg", PropertyId = 50},
                    new PropertyImage {ImageUrl = "/images/178.jpg", PropertyId = 50},
                    new PropertyImage {ImageUrl = "/images/179.jpg", PropertyId = 50},

                    new PropertyImage {ImageUrl = "/images/180.jpg", PropertyId = 51},
                    new PropertyImage {ImageUrl = "/images/181.jpg", PropertyId = 51},
                    new PropertyImage {ImageUrl = "/images/182.jpg", PropertyId = 51},

                    new PropertyImage {ImageUrl = "/images/183.jpg", PropertyId = 52},
                    new PropertyImage {ImageUrl = "/images/184.jpg", PropertyId = 52},
                    new PropertyImage {ImageUrl = "/images/185.jpg", PropertyId = 52},

                    new PropertyImage {ImageUrl = "/images/186.jpg", PropertyId = 53},
                    new PropertyImage {ImageUrl = "/images/187.jpg", PropertyId = 53},
                    new PropertyImage {ImageUrl = "/images/188.jpg", PropertyId = 53},

                    new PropertyImage {ImageUrl = "/images/189.jpg", PropertyId = 54},
                    new PropertyImage {ImageUrl = "/images/190.jpg", PropertyId = 54},
                    new PropertyImage {ImageUrl = "/images/191.jpg", PropertyId = 54},

                    new PropertyImage {ImageUrl = "/images/192.jpg", PropertyId = 55},
                    new PropertyImage {ImageUrl = "/images/193.jpg", PropertyId = 55},
                    new PropertyImage {ImageUrl = "/images/194.jpg", PropertyId = 55},

                    new PropertyImage {ImageUrl = "/images/195.jpg", PropertyId = 56},
                    new PropertyImage {ImageUrl = "/images/196.jpg", PropertyId = 56},
                    new PropertyImage {ImageUrl = "/images/197.jpg", PropertyId = 56},

                    new PropertyImage {ImageUrl = "/images/198.jpg", PropertyId = 57},
                    new PropertyImage {ImageUrl = "/images/199.jpg", PropertyId = 57},
                    new PropertyImage {ImageUrl = "/images/200.jpg", PropertyId = 57},

                    new PropertyImage {ImageUrl = "/images/201.jpg", PropertyId = 58},
                    new PropertyImage {ImageUrl = "/images/202.jpg", PropertyId = 58},
                    new PropertyImage {ImageUrl = "/images/203.jpg", PropertyId = 58},

                    new PropertyImage {ImageUrl = "/images/204.jpg", PropertyId = 59},
                    new PropertyImage {ImageUrl = "/images/205.jpg", PropertyId = 59},
                    new PropertyImage {ImageUrl = "/images/206.jpg", PropertyId = 59},

                    new PropertyImage {ImageUrl = "/images/207.jpg", PropertyId = 60},
                    new PropertyImage {ImageUrl = "/images/208.jpg", PropertyId = 60},
                    new PropertyImage {ImageUrl = "/images/209.jpg", PropertyId = 60},

                    new PropertyImage {ImageUrl = "/images/210.jpg", PropertyId = 61},
                    new PropertyImage {ImageUrl = "/images/211.jpg", PropertyId = 61},
                    new PropertyImage {ImageUrl = "/images/212.jpg", PropertyId = 61},

                    new PropertyImage {ImageUrl = "/images/213.jpg", PropertyId = 62},
                    new PropertyImage {ImageUrl = "/images/214.jpg", PropertyId = 62},
                    new PropertyImage {ImageUrl = "/images/215.jpg", PropertyId = 62},

                    new PropertyImage {ImageUrl = "/images/216.jpg", PropertyId = 63},
                    new PropertyImage {ImageUrl = "/images/217.jpg", PropertyId = 63},
                    new PropertyImage {ImageUrl = "/images/218.jpg", PropertyId = 63},

                    new PropertyImage {ImageUrl = "/images/219.jpg", PropertyId = 64},
                    new PropertyImage {ImageUrl = "/images/220.jpg", PropertyId = 64},
                    new PropertyImage {ImageUrl = "/images/221.jpg", PropertyId = 64},

                    new PropertyImage {ImageUrl = "/images/222.jpg", PropertyId = 65},
                    new PropertyImage {ImageUrl = "/images/223.jpg", PropertyId = 65},
                    new PropertyImage {ImageUrl = "/images/224.jpg", PropertyId = 65},

                    new PropertyImage {ImageUrl = "/images/225.jpg", PropertyId = 66},
                    new PropertyImage {ImageUrl = "/images/226.jpg", PropertyId = 66},
                    new PropertyImage {ImageUrl = "/images/227.jpg", PropertyId = 66},

                    new PropertyImage {ImageUrl = "/images/228.jpg", PropertyId = 67},
                    new PropertyImage {ImageUrl = "/images/229.jpg", PropertyId = 67},
                    new PropertyImage {ImageUrl = "/images/230.jpg", PropertyId = 67},

                    new PropertyImage {ImageUrl = "/images/231.jpg", PropertyId = 68},
                    new PropertyImage {ImageUrl = "/images/232.jpg", PropertyId = 68},
                    new PropertyImage {ImageUrl = "/images/233.jpg", PropertyId = 68},

                    new PropertyImage {ImageUrl = "/images/234.jpg", PropertyId = 69},
                    new PropertyImage {ImageUrl = "/images/235.jpg", PropertyId = 69},
                    new PropertyImage {ImageUrl = "/images/236.jpg", PropertyId = 69},

                    new PropertyImage {ImageUrl = "/images/237.jpg", PropertyId = 70},
                    new PropertyImage {ImageUrl = "/images/238.jpg", PropertyId = 70},
                    new PropertyImage {ImageUrl = "/images/239.jpg", PropertyId = 70},

                    new PropertyImage {ImageUrl = "/images/240.jpg", PropertyId = 71},
                    new PropertyImage {ImageUrl = "/images/241.jpg", PropertyId = 71},
                    new PropertyImage {ImageUrl = "/images/242.jpg", PropertyId = 71},

                    new PropertyImage {ImageUrl = "/images/243.jpg", PropertyId = 72},
                    new PropertyImage {ImageUrl = "/images/244.jpg", PropertyId = 72},
                    new PropertyImage {ImageUrl = "/images/245.jpg", PropertyId = 72},
                };
                context.AddRange(imageProperty);
                context.SaveChanges();
            }

            if (!context.PropertyAmenities.Any())
            {
                var propertyAmenities = new List<PropertyAmenity>
                {
                    new PropertyAmenity {AmenityId = 1, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 5, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 1},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 5, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 2},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 2},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 5, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 7},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 7},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 5, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 8},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 8},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 5, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 9},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 9},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 5, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 10},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 10},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 5, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 11},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 11},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 5, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 12},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 12},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 13},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 13},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 13},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 13},
                    new PropertyAmenity {AmenityId = 5, PropertyId = 13},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 13},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 13},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 13},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 13},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 13},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 1},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 13},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 13},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 13},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 13},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 13},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 5, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 14},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 14},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 5, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 15},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 15},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 5, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 16},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 16},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 3},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 3},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 3},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 3},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 3},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 3},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 3},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 3},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 3},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 3},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 3},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 3},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 3},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 3},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 3},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 4},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 4},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 4},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 4},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 4},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 4},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 4},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 4},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 4},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 4},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 4},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 4},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 4},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 4},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 4},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 5},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 5},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 5},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 5},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 5},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 5},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 5},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 5},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 5},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 5},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 5},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 5},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 5},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 5},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 5},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 6},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 6},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 6},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 6},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 6},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 6},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 6},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 6},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 6},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 6},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 6},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 6},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 6},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 6},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 6},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 17},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 17},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 17},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 17},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 17},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 17},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 17},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 17},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 17},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 17},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 17},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 17},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 17},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 17},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 17},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 18},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 18},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 18},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 18},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 18},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 18},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 18},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 18},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 18},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 18},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 18},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 18},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 18},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 18},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 18},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 19},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 19},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 19},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 19},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 19},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 19},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 19},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 19},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 19},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 19},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 19},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 19},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 19},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 19},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 19},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 20},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 20},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 20},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 20},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 20},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 20},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 20},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 20},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 20},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 20},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 20},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 20},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 20},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 20},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 20},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 21},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 21},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 21},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 21},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 21},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 21},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 21},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 21},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 21},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 21},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 21},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 21},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 21},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 21},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 21},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 22},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 22},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 22},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 22},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 22},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 22},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 22},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 22},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 22},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 22},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 22},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 22},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 22},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 22},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 22},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 23},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 23},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 23},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 23},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 23},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 23},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 23},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 23},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 23},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 23},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 23},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 23},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 23},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 23},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 23},

                    new PropertyAmenity {AmenityId = 1, PropertyId = 24},
                    new PropertyAmenity {AmenityId = 2, PropertyId = 24},
                    new PropertyAmenity {AmenityId = 3, PropertyId = 24},
                    new PropertyAmenity {AmenityId = 4, PropertyId = 24},
                    new PropertyAmenity {AmenityId = 6, PropertyId = 24},
                    new PropertyAmenity {AmenityId = 7, PropertyId = 24},
                    new PropertyAmenity {AmenityId = 8, PropertyId = 24},
                    new PropertyAmenity {AmenityId = 9, PropertyId = 24},
                    new PropertyAmenity {AmenityId = 10, PropertyId = 24},
                    new PropertyAmenity {AmenityId = 11, PropertyId = 24},
                    new PropertyAmenity {AmenityId = 12, PropertyId = 24},
                    new PropertyAmenity {AmenityId = 13, PropertyId = 24},
                    new PropertyAmenity {AmenityId = 14, PropertyId = 24},
                    new PropertyAmenity {AmenityId = 15, PropertyId = 24},
                    new PropertyAmenity {AmenityId = 16, PropertyId = 24},

                    new PropertyAmenity { AmenityId = 1, PropertyId = 25 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 25 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 25 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 25 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 25 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 25 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 25 },


                    new PropertyAmenity { AmenityId = 1, PropertyId = 26 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 26 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 26 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 26 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 26 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 26 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 26 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 27 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 27 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 27 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 27 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 27 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 27 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 27 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 28 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 28 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 28 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 28 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 28 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 28 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 28 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 29 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 29 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 29 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 29 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 29 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 29 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 29 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 30 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 30 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 30 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 30 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 30 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 30 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 30 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 31 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 31 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 31 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 31 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 31 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 31 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 31 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 32 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 32 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 32 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 32 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 32 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 32 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 32 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 33 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 33 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 33 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 33 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 33 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 33 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 33 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 34 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 34 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 34 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 34 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 34 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 34 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 34 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 35 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 35 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 35 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 35 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 35 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 35 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 35 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 36 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 36 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 36 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 36 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 36 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 36 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 36 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 37 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 37 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 37 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 37 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 37 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 37 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 37 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 37 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 37 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 37 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 37 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 37 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 37 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 37 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 37 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 38 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 38 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 38 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 38 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 38 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 38 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 38 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 38 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 38 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 38 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 38 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 38 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 38 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 38 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 38 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 39 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 39 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 39 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 39 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 39 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 39 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 39 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 39 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 39 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 39 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 39 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 39 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 39 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 39 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 39 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 40 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 40 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 40 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 40 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 40 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 40 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 40 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 40 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 40 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 40 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 40 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 40 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 40 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 40 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 40 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 41 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 41 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 41 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 41 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 41 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 41 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 41 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 41 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 41 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 41 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 41 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 41 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 41 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 41 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 41 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 42 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 42 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 42 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 42 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 42 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 42 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 42 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 42 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 42 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 42 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 42 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 42 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 42 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 42 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 42 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 43 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 43 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 43 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 43 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 43 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 43 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 43 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 43 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 43 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 43 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 43 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 43 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 43 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 43 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 43 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 44 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 44 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 44 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 44 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 44 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 44 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 44 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 44 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 44 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 44 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 44 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 44 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 44 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 44 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 44 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 45 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 45 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 45 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 45 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 45 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 45 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 45 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 45 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 45 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 45 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 45 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 45 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 45 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 45 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 45 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 46 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 46 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 46 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 46 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 46 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 46 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 46 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 46 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 46 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 46 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 46 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 46 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 46 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 46 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 46 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 47 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 47 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 47 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 47 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 47 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 47 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 47 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 47 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 47 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 47 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 47 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 47 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 47 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 47 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 47 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 48 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 48 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 48 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 48 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 48 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 48 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 48 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 48 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 48 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 48 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 48 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 48 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 48 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 48 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 48 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 49 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 49 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 49 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 49 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 49 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 49 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 49 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 49 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 49 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 49 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 49 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 49 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 49 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 49 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 49 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 50 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 50 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 50 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 50 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 50 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 50 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 50 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 50 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 50 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 50 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 50 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 50 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 50 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 50 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 50 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 51 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 51 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 51 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 51 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 51 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 51 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 51 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 51 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 51 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 51 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 51 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 51 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 51 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 51 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 51 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 52 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 52 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 52 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 52 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 52 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 52 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 52 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 52 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 52 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 52 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 52 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 52 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 52 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 52 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 52 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 53 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 53 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 53 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 53 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 53 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 53 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 53 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 53 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 53 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 53 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 53 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 53 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 53 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 53 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 53 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 54 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 54 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 54 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 54 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 54 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 54 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 54 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 54 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 54 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 54 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 54 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 54 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 54 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 54 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 54 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 55 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 55 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 55 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 55 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 55 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 55 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 55 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 55 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 55 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 55 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 55 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 55 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 55 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 55 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 55 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 56 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 56 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 56 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 56 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 56 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 56 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 56 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 56 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 56 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 56 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 56 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 56 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 56 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 56 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 56 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 57 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 57 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 57 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 57 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 57 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 57 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 57 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 57 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 57 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 57 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 57 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 57 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 57 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 57 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 57 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 58 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 58 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 58 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 58 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 58 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 58 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 58 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 58 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 58 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 58 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 58 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 58 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 58 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 58 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 58 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 59 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 59 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 59 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 59 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 59 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 59 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 59 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 59 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 59 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 59 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 59 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 59 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 59 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 59 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 59 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 60 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 60 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 60 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 60 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 60 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 60 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 60 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 60 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 60 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 60 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 60 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 60 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 60 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 60 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 60 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 61 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 61 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 61 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 61 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 61 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 61 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 61 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 61 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 61 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 61 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 61 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 61 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 61 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 61 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 61 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 62 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 62 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 62 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 62 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 62 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 62 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 62 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 62 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 62 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 62 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 62 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 62 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 62 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 62 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 62 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 63 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 63 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 63 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 63 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 63 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 63 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 63 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 63 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 63 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 63 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 63 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 63 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 63 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 63 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 63 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 64 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 64 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 64 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 64 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 64 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 64 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 64 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 64 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 64 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 64 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 64 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 64 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 64 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 64 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 64 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 65 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 65 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 65 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 65 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 65 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 65 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 65 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 65 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 65 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 65 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 65 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 65 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 65 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 65 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 65 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 66 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 66 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 66 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 66 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 66 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 66 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 66 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 66 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 66 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 66 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 66 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 66 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 66 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 66 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 66 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 67 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 67 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 67 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 67 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 67 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 67 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 67 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 67 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 67 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 67 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 67 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 67 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 67 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 67 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 67 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 68 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 68 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 68 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 68 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 68 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 68 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 68 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 68 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 68 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 68 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 68 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 68 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 68 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 68 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 68 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 69 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 69 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 69 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 69 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 69 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 69 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 69 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 69 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 69 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 69 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 69 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 69 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 69 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 69 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 69 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 70 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 70 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 70 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 70 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 70 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 70 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 70 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 70 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 70 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 70 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 70 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 70 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 70 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 70 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 70 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 71 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 71 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 71 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 71 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 71 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 71 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 71 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 71 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 71 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 71 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 71 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 71 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 71 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 71 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 71 },

                    new PropertyAmenity { AmenityId = 1, PropertyId = 72 },
                    new PropertyAmenity { AmenityId = 2, PropertyId = 72 },
                    new PropertyAmenity { AmenityId = 3, PropertyId = 72 },
                    new PropertyAmenity { AmenityId = 4, PropertyId = 72 },
                    new PropertyAmenity { AmenityId = 6, PropertyId = 72 },
                    new PropertyAmenity { AmenityId = 7, PropertyId = 72 },
                    new PropertyAmenity { AmenityId = 8, PropertyId = 72 },
                    new PropertyAmenity { AmenityId = 9, PropertyId = 72 },
                    new PropertyAmenity { AmenityId = 10, PropertyId = 72 },
                    new PropertyAmenity { AmenityId = 11, PropertyId = 72 },
                    new PropertyAmenity { AmenityId = 12, PropertyId = 72 },
                    new PropertyAmenity { AmenityId = 13, PropertyId = 72 },
                    new PropertyAmenity { AmenityId = 14, PropertyId = 72 },
                    new PropertyAmenity { AmenityId = 15, PropertyId = 72 },
                    new PropertyAmenity { AmenityId = 16, PropertyId = 72 },




                };
                context.AddRange(propertyAmenities);
                context.SaveChanges();
            }

            if (!context.Reservations.Any())
            {
                var reservations = new List<Reservation>
                {
                    new Reservation { CustomerId = "1", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 3 },
                    new Reservation { CustomerId = "1", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 4 },
                    new Reservation { CustomerId = "1", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 5 },
                    new Reservation { CustomerId = "1", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 6 },
                    new Reservation { CustomerId = "1", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 7 },


                    new Reservation { CustomerId = "3", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 3 },
                    new Reservation { CustomerId = "3", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 4 },
                    new Reservation { CustomerId = "3", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 5 },
                    new Reservation { CustomerId = "3", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 6 },
                    new Reservation { CustomerId = "3", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 7 },


                    new Reservation { CustomerId = "4", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 3 },
                    new Reservation { CustomerId = "4", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 4 },
                    new Reservation { CustomerId = "4", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 5 },
                    new Reservation { CustomerId = "4", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 6 },
                    new Reservation { CustomerId = "4", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 7 },


                    new Reservation { CustomerId = "4", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 3 },
                    new Reservation { CustomerId = "4", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 4 },
                    new Reservation { CustomerId = "4", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 5 },
                    new Reservation { CustomerId = "4", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 6 },
                    new Reservation { CustomerId = "4", StartDate = DateTime.Today.AddDays(8), EndDate = DateTime.Today.AddDays(14), NumberOfGuests = 1, PropertyId = 7 },

                };
                context.AddRange(reservations);
                context.SaveChanges();
            }
        }
    }
}



