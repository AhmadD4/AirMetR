using System;
using System.Text.Json.Serialization;

namespace AirMetR.Models
{
    public class PropertyAmenity
    {
        // Unique identifier for a PropertyAmenity
        public int PropertyAmenityId { get; set; }

        // Foreign key to the Property
        public int PropertyId { get; set; }

        // Foreign key to the Amenity
        public int AmenityId { get; set; }

        // Navigation property to the associated Property
        [JsonIgnore]
        public virtual Property? Property { get; set; }

        // Navigation property to the associated Amenity
        public virtual Amenity? Amenity { get; set; }
    }
}

