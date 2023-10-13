using System;
using System.Collections.Generic;

namespace FBI.WebAPI.Models;

public partial class Option
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public long OptionGroupId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public virtual ICollection<NextOfKin> NextOfKins { get; set; } = new List<NextOfKin>();

    public virtual OptionGroup OptionGroup { get; set; } = null!;
}
