using System;
using System.Collections.Generic;

namespace MapWebAPI.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? LocationId { get; set; }

    public int? UserId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public virtual Location? Location { get; set; }
}
