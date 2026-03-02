using System;
using System.Collections.Generic;

namespace ITCompanyApp2.Models;

public partial class StatusesTask
{
    public short Id { get; set; }

    public string StatusTasksName { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
