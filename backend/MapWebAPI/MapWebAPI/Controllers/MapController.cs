using MapWebAPI.DTOs;
using MapWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace MapWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly MapAppDbContext _context;

        public LocationsController(MapAppDbContext context)
        {
            _context = context;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDto>>> GetLocations()
        {
            var locationsDto = await _context.Locations
                .Include(location => location.Reviews)
                .Include(location => location.LocationType)
                    .ThenInclude(locationType => locationType.Attributes)
                .Select(location => new LocationDto
                {
                    Name = location.Name,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude,
                    LocationTypeId = location.LocationTypeId,
                    LocationType = location.LocationType.TypeName,
                    IconPath = location.LocationType.IconPath,
                    Reviews = location.Reviews.Select(review => new LocationReviewDto
                    {
                        Rating = review.Rating,
                        Comment = review.Comment
                    }).ToArray(),
                    Attributes = location.LocationType.Attributes.Select(attribute => new LocationAttributeDto
                    {
                        Name = attribute.Name,
                        Value = attribute.Value
                    }).ToArray()
                }).ToListAsync();

            return locationsDto;
        }

        [HttpGet]
        [Route("GetLocationTypes")]
        public async Task<ActionResult<IEnumerable<LocationTypesDto>>> GetLocationTypes()
        {
            var locationTypesDto = await _context.LocationTypes
                .Select(locationType => new LocationTypesDto
                {
                    TypeName = locationType.TypeName,
                    IconPath = locationType.IconPath
                }).ToListAsync();

            return locationTypesDto;
        }


        [HttpGet]
        [Route("GetLocationById/{id}")]
        public async Task<ActionResult<Location>> GetLocationById(int id)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return location;
        }

        [HttpPost]
        [Route("AddLocation")]
        public async Task<ActionResult<Location>> AddLocation(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocationById", new { id = location.LocationId }, location);
        }

        [HttpPut]
        [Route("UpdateLocation/{id}")]
        public async Task<IActionResult> UpdateLocation(int id, Location location)
        {
            if (id != location.LocationId)
            {
                return BadRequest();
            }

            _context.Entry(location).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                Console.Error.WriteLine("Location not found");
            }

            return NoContent();
        }
    }
}