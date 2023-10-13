using System;
using System.Collections.Generic;

namespace FBI.WebAPI.Models;

public partial class NextOfKin
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public long? RelationshipId { get; set; }

    public string? ContactNumber { get; set; }

    public string? Address { get; set; }
    public Guid CriminalId { get; set; }

    public virtual Option? Relationship { get; set; }
}
