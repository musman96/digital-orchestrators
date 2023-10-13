using System;
using System.Collections.Generic;

namespace FBI.WebAPI.Models;

public partial class CriminalDetail
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? LastKnownAddress { get; set; }

    public byte[]? Photo { get; set; }

    public string? PrisonName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<ListofCrime> ListofCrimes { get; set; } = new List<ListofCrime>();
}
