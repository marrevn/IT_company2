using System;
using System.Collections.Generic;

namespace ITCompanyApp2.Models;

public partial class Task
{
    public int Id { get; set; }

    public string NameTasks { get; set; } = null!;

    public short IdStatusTask { get; set; }

    public short IdPriority { get; set; }

    public int IdProject { get; set; }

    public short IdUser { get; set; }

    public DateOnly DateCreate { get; set; }

    public DateOnly DateComplete { get; set; }

    public string Description { get; set; } = null!;

    public virtual Priority Priority { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;

    public virtual StatusesTask StatusesTask { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
