using System;
using System.Collections.Generic;

namespace FBI.WebAPI.Models;

public partial class ListofCrime
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public DateTime? DateCommitted { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public Guid? CriminalId { get; set; }

    public virtual CriminalDetail? Criminal { get; set; }
}
