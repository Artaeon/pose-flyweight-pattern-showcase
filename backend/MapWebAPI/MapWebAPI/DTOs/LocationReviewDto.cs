using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MapWebAPI.DTOs
{
    public class LocationReviewDto
    {                
        public int? UserId { get; set; }

        public int Rating { get; set; }

        public string? Comment { get; set; }
    }
}
