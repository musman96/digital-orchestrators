using System;
using System.Collections.Generic;

namespace FBI.WebAPI.Models;

public partial class OptionGroup
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<Option> Options { get; set; } = new List<Option>();
}
