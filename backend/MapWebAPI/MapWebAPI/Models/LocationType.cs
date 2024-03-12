using System;
using System.Collections.Generic;

namespace MapWebAPI.Models;

public partial class LocationType
{
    public int LocationTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public string? IconPath { get; set; }

    public virtual ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
