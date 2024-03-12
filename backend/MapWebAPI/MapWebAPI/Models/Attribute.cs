using System;
using System.Collections.Generic;

namespace MapWebAPI.Models;

public partial class Attribute
{
    public int AttributeId { get; set; }

    public int? LocationTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;

    public virtual LocationType? LocationType { get; set; }
}
