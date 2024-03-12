using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MapWebAPI.DTOs
{
    public class LocationDto
    {
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int? LocationTypeId { get; set; }
        public string LocationType { get; set; } = null!;
        public string? IconPath { get; set; }
        public LocationReviewDto[] Reviews { get; set; }
        public LocationAttributeDto[] Attributes { get; set; }
    }   
}
