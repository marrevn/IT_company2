using System;
using System.Collections.Generic;

namespace ITCompanyApp2.Models;

public partial class Priority
{
    public short Id { get; set; }

    public string PriorityName { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
