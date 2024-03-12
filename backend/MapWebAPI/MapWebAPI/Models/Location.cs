using System;
using System.Collections.Generic;

namespace MapWebAPI.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public int? LocationTypeId { get; set; }

    public virtual LocationType? LocationType { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
