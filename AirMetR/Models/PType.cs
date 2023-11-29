using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AirMetR.Models
{
    public class PType
    {
        // Unique identifier for the property type
        public int PTypeId { get; set; }

        public string PTypeIcon { get; set; } = string.Empty;

        // Name of the property type
        [StringLength(50)]
        public string PTypeName { get; set; } = string.Empty;

        // Navigation property to hold the associated properties
        [JsonIgnore]
        public virtual ICollection<Property> Properties { get; set; } = new List<Property>();

    }
}

