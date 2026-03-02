using System;
using System.Collections.Generic;

namespace ITCompanyApp2.Models;

public partial class Status
{
    public short Id { get; set; }

    public string StatusesName { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
